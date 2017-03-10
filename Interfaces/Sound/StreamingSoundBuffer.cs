using System;
using System.Threading;
using Microsoft.DirectX.DirectSound;

namespace Interfaces.Sound
{
  public class StreamingSoundBuffer : IDisposable
  {
    private int readPosition = 0;
    private int writePosition = 0;
    private byte[] data = null;
    private Device device = null;
    private Notify notifier = null;
    private Thread dataManager = null;
    private AutoResetEvent notifyEvent = null;
    private SecondaryBuffer buffer = null;
    private ISoundDataProvider provider = null;

    private volatile bool abort = false;
    private volatile bool disposed = false;

    private const int BufferSize = 262144;
    private const int Notifications = 4;
    private const int SectorSize = BufferSize / Notifications;
    private static int NextID = 0;

    public StreamingSoundBuffer(Device device, WaveFormat format, ISoundDataProvider provider)
    {
      NextID++;

      this.device = device;
      this.provider = provider;

      BufferDescription description = new BufferDescription(format);
      description.BufferBytes = BufferSize;
      description.ControlPositionNotify = true;
      description.CanGetCurrentPosition = true;
      description.ControlVolume = true;
      description.LocateInHardware = false;
      description.LocateInSoftware = true;
      description.GlobalFocus = false;
      description.StickyFocus = false;

      try
      {
        buffer = new SecondaryBuffer(description, device);
        buffer.SetCurrentPosition(0);
        buffer.Volume = 0;
      }
      catch (Exception ex)
      {
        if (buffer != null)
          buffer.Dispose();
        throw new SoundSystemException(ex, "Failed to create SecondaryBuffer ID {0}.", NextID);
      }

      notifier = new Notify(buffer);
      notifyEvent = new AutoResetEvent(false);
      BufferPositionNotify[] notifications = new BufferPositionNotify[Notifications];
      for (int i = 0; i < Notifications; i++)
      {
        if (notifyEvent.SafeWaitHandle.IsClosed || notifyEvent.SafeWaitHandle.IsInvalid)
          throw new SoundSystemException("SecondaryBuffer ID {0} notifier handle was closed or invalid.", NextID);
        else
        {
          notifications[i].EventNotifyHandle = notifyEvent.SafeWaitHandle.DangerousGetHandle();
          notifications[i].Offset = SectorSize * i - 1;
        }
      }
      notifier.SetNotificationPositions(notifications, Notifications);

      data = provider.GetNextChunk();
      FillData();
      FillData(); // do this twice, to have a 370 or so ms lead, in case something were to happen

      dataManager = new Thread(new ThreadStart(DataStream));
      dataManager.Name = "Prometheus Sound Stream #" + NextID.ToString();
      dataManager.Priority = ThreadPriority.AboveNormal;
      dataManager.Start(); // must lock buffer from now on
    }

    public void Start()
    {
      if (dataManager.ThreadState == ThreadState.Stopped)
        dataManager.Start();

      if (!disposed)
        lock (buffer)
          buffer.Play(0, BufferPlayFlags.Looping);
    }

    public void Stop()
    {
      if (!disposed)
        lock (buffer)
          buffer.Stop();
    }

    private byte[] GetData()
    {
      byte[] sector = new byte[SectorSize];
      int localWritePosition = 0;

      while (localWritePosition < SectorSize)
      {
        int localSectorSize = Math.Min(SectorSize - localWritePosition, data.Length - readPosition);
        Array.Copy(data, readPosition, sector, localWritePosition, localSectorSize);
        localWritePosition += localSectorSize;
        readPosition += localSectorSize;

        if (readPosition >= data.Length)
        {
          data = provider.GetNextChunk();
          readPosition = 0;
          if (data.Length == 0)
          {
            abort = true;
            break;
          }
        }
      }

      return sector;
    }

    private void FillData()
    {
      lock (buffer)
        buffer.Write(writePosition, GetData(), LockFlag.None);
      writePosition += SectorSize;
      writePosition %= BufferSize;
    }

    private void DataStream()
    {
      while (true)
      {
        notifyEvent.WaitOne(Timeout.Infinite, true);
        if (abort) // must check for abort after signal
          break;
        FillData();
      }
      Stopping();
    }

    private void Stopping()
    {
      Stop();
      abort = false;
    }

    public void Dispose()
    {
      abort = true;
      if (dataManager.ThreadState != ThreadState.Stopped)
        dataManager.Abort();
      lock (buffer)
        buffer.Dispose();
      disposed = true;
    }
  }
}
