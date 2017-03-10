using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

using Interfaces;
using Interfaces.Helpers;
using Interfaces.Rendering.Radiosity;
using Core;
using Core.Rendering;
using Core.Radiosity;

namespace Prometheus.Dialogs
{
  public partial class PrometheusGUI
  {
    private RadiosityOptions dialogRadiosityOptions;
    //private RadiosityRenderer renderRadiosity = null;

    private System.Windows.Forms.Timer radiosityProgressTimer;
    private HighPerformanceBuffer<long> radiosityProgressBuffer;
    private HighPerformanceBuffer<float> radiositySecondsRemaining;

    protected void InitializeRadiosity()
    {
      // Setup radiosity worker class.
      //renderRadiosity = new RadiosityRenderer(components);
      RadiosityRenderer.Instance.OnComplete += new RadiosityRenderer.ProcessingCompleteHandler(RadiosityOnComplete);

      // Setup radiosity dialog box
      dialogRadiosityOptions = new RadiosityOptions();
      dialogRadiosityOptions.OnRun += new RadiosityOptions.RunEventHandler(OnRadiosityRun);
      dialogRadiosityOptions.OnCancel += new RadiosityOptions.CancelEventHandler(OnRadiosityCancel);
      dialogRadiosityOptions.OnClose += new RadiosityOptions.FormClosedEventHandler(OnRadiosityCancel);

      // Setup progress timer
      radiosityProgressTimer = new System.Windows.Forms.Timer();
      radiosityProgressTimer.Tick += new EventHandler(radiosityProgressTimer_Tick);
    }

    /// <summary>
    /// Called when user presses the cancel button in the lightmap option dialog.
    /// </summary>
    private void OnRadiosityCancel()
    {
      RadiosityRenderer.RequestStop();
    }

    /// <summary>
    /// Run when the run button on the radiosity dialog is clicked.
    /// </summary>
    private void OnRadiosityRun()
    {
      // Set up GUI.
      icRadiosityStatus.Visible = true;

      // Setup radiosity rendering.
      RadiosityRenderer.Instance.MaxPhotons = dialogRadiosityOptions.PhotonCount;
      RadiosityRenderer.Instance.MaxBounces = dialogRadiosityOptions.MaxBounces;
      RadiosityRenderer.Instance.PhotonRadius = dialogRadiosityOptions.TexelRadius;

      liRadiosityStatus.Visible = true;
      pbarxRadiosity.ProgressType = DevComponents.DotNetBar.eProgressItemType.Standard;

      // Set up timer
      radiosityProgressTimer.Interval = 100;
      radiosityProgressBuffer = new HighPerformanceBuffer<long>(5000 / radiosityProgressTimer.Interval);
      radiositySecondsRemaining = new HighPerformanceBuffer<float>(1000 / radiosityProgressTimer.Interval);
      radiosityProgressBuffer.Add(0);
      radiosityProgressTimer.Start();

      // Choose wether to render in a thread (more responsive GUI) 
      // or sequentially (less responsive GUI).
      if (dialogRadiosityOptions.IsRunThreaded)
      {
        RadiosityRenderer.Instance.BeginThreaded();
      }
      else
      {
        RadiosityRenderer.Instance.BeginThreaded();
      }
    }

    float radiosityElapsedSeconds = 0f;
    float radiosityElapsedSinceUpdate = 0f;
    void radiosityProgressTimer_Tick(object sender, EventArgs e)
    {
      int complete = RadiosityRenderer.Progress;
      int total = RadiosityRenderer.ProgressTotal;
      radiosityProgressBuffer.Add(complete);

      float estimate = radiosityEstimateTimeRemaining();

      #region Use estimate to notify user
      if ((estimate != 0f) && (radiosityElapsedSeconds > 5f))
      {
        radiositySecondsRemaining.Add(estimate);
        if (radiositySecondsRemaining.itemsAdded >= radiositySecondsRemaining.Size)
        {
          // use buffered data
          float totalSeconds = 0f;
          for (int x = 0; x < radiositySecondsRemaining.Size; x++)
            totalSeconds += radiositySecondsRemaining[x];
          estimate = totalSeconds / radiositySecondsRemaining.Size;
        }

        this.liRadiosityStatus.Text = string.Format("{4} ({0} out of {1} photons complete) ETA: {2:f2} Elapsed: {3:f1}", complete, total, Strings.ComputeReadableTime(estimate), Strings.ComputeReadableTime(radiosityElapsedSeconds), RadiosityRenderer.StoreCount);
      }
      else
        this.liRadiosityStatus.Text = string.Format("{4} ({0} out of {1} photons complete) ETA: waiting... Elapsed: {3:f1}", complete, total, 0f, Strings.ComputeReadableTime(radiosityElapsedSeconds), RadiosityRenderer.CurrentOperation);
      pbarxRadiosity.Text = RadiosityRenderer.CurrentOperation;
      barStatusBar.Refresh();
      #endregion

      pbarxRadiosity.Maximum = total;
      pbarxRadiosity.Value = complete;

      //if (complete == total)
      //        RadiosityOnComplete();
      if (complete != total)
      {
        float elapsed = (float)radiosityProgressTimer.Interval / 1000f;
        radiosityElapsedSeconds += elapsed;
        if (!RadiosityRenderer.UpdateRequested)
        {
          radiosityElapsedSinceUpdate += elapsed;
          if (radiosityElapsedSinceUpdate >= 10f)
          {
            RadiosityRenderer.RequestUpdate();
            radiosityElapsedSinceUpdate = 0f;
          }
        }
      }
    }

    private float radiosityEstimateTimeRemaining()
    {
      if (radiosityProgressBuffer == null)
        return 50000;

      long delta = 0, tempEstimate = 0;
      int calcLength = 0;

      int complete = RadiosityRenderer.Progress,
          total = RadiosityRenderer.ProgressTotal,
          length = (radiosityProgressBuffer.itemsAdded > radiosityProgressBuffer.Size) ? radiosityProgressBuffer.Size : radiosityProgressBuffer.itemsAdded;

      if (length != 0)
      {
        for (int x = 1; x < length; x++)
        {
          long dif = radiosityProgressBuffer[x] - radiosityProgressBuffer[x - 1];
          if (dif != 0)
          {
            delta += radiosityProgressBuffer[x] - radiosityProgressBuffer[x - 1];
            calcLength++;
          }
        }

        if (delta != 0)
        {
          // Compute the number of seconds remaining.
          tempEstimate = (((long)(total - complete) * (long)calcLength * (long)radiosityProgressTimer.Interval) / (1000 * delta));
        }
      }

      return (float)tempEstimate;
    }

    /// <summary>
    /// Resets the GUI once the radiosity calculations have completed.
    /// </summary>
    private void RadiosityOnComplete()
    {
      //icRadiosityStatus.Visible = false;
      radiosityProgressTimer.Stop();
    }

    #region Radiosity Progress

    #region Progress Bar

    private void pbarxRadiosity_MouseEnter(object sender, EventArgs e)
    {
      #region Build Tooltip
      
      /* The below StringBuilder should construct a string of the following structure:
       * 
       * <p><h6>Stage (<font color="navy">1 of 3</font>)</h6>
       * Stage: Bouncing
       * <br />Progress: 50%
       * <br />Time Remaining: ~1d 14h 33m 10s</p>
       * 
       * <p><h6>Settings</h6>
       * Photons: 4,000,000
       * <br />Bounce Limit: 10
       * <br />Light Count: 18
       * <br />Auto Save: Enabled (5 min)</p>
       * 
       * <b>Time Elapsed</b>: 1d 15h 11m 58s
       */

      StringBuilder tooltip = new StringBuilder();

      int stageNumber = 2, photonCount = 4000000, bounceLimit = 10, lightCount = 18, autoSaveTime = 5, textureNumber = 1, totalTextures = 8;
      bool autoSave = true;
      RadiosityStage stage = RadiosityRenderer.CurrentStage;
      string stageName = RadiosityStageHelper.Instance[stage];
      stageNumber = (int)stage;
      photonCount = RadiosityRenderer.PhotonCount;
      bounceLimit = RadiosityRenderer.Instance.MaxBounces;
      lightCount = RadiosityRenderer.Instance.m_lights.Count;


      tooltip.Append("<p><h6>Stage (<font color=\"navy\">");
      tooltip.Append(stageNumber + " of " + (int)RadiosityStage.Done);
      tooltip.Append("</font>)</h6>");
      tooltip.Append("Stage: ");
      tooltip.Append(stageName);

      if (RadiosityStageHelper.HasProgress(stage))
      {
        tooltip.Append("<br />Progress: ");

        switch (stage)
        {
          case RadiosityStage.ScenarioLoading:
            tooltip.Append("Processing");
            break;
          case RadiosityStage.PhotonBouncing:
            tooltip.Append(((pbarxRadiosity.Value / pbarxRadiosity.Maximum) * 100) + "%");
            break;
          case RadiosityStage.TreeBalancing:
            tooltip.Append(((pbarxRadiosity.Value / pbarxRadiosity.Maximum) * 100) + "%");
            break;
          case RadiosityStage.TextureGeneration:
            tooltip.Append("Texture ");
            tooltip.Append(textureNumber + " of " + totalTextures);
            break;
        }

        tooltip.Append("<br />Time Remaining: ");
        tooltip.Append(Strings.ComputeReadableTime(radiosityEstimateTimeRemaining())); //~1d 14h 33m 10s
        tooltip.Append("</p>");
      }

      tooltip.Append("<p><h6>Settings</h6>");
      tooltip.Append("Photons: ");
      tooltip.Append(String.Format("{0:0,0}", photonCount));
      tooltip.Append("<br />Bounce Limit: ");
      tooltip.Append(String.Format("{0:0,0}", bounceLimit));
      tooltip.Append("<br />Light Count: ");
      tooltip.Append(String.Format("{0:0,0}", lightCount));
      tooltip.Append("<br />Auto Save: ");
      tooltip.Append((autoSave) ? "Enabled " : "Disabled");
      if(autoSave)
        tooltip.Append("(" + autoSaveTime + " min)");
      tooltip.Append("</p>");

      tooltip.Append("<b>Time Elapsed</b>: ");
      tooltip.Append(Strings.ComputeReadableTime(radiosityElapsedSeconds)); // 1d 15h 11m 58s

      this.stStatusBar.SetSuperTooltip(this.pbarxRadiosity, new DevComponents.DotNetBar.SuperTooltipInfo("<img src=\"global::Prometheus.Properties.Resources.lightbulb_on16\" /><span padding" +
                  "=\"0,0,2,0\">&nbsp;<b>Radiosity Progress</b></span>", "", tooltip.ToString(), null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));

      #endregion
    }

    #endregion

    #region Label (Currently Unused)
    private void liRadiosityStatus_MouseEnter(object sender, EventArgs e)
    {
      liRadiosityStatus.ForeColor = Color.Orange;
      liRadiosityStatus.Text = "<u>Radiosity Processing</u>: ";
      barStatusBar.Refresh();
    }

    private void liRadiosityStatus_MouseLeave(object sender, EventArgs e)
    {
      liRadiosityStatus.ForeColor = Color.White;
      liRadiosityStatus.Text = "Radiosity Processing: ";
      barStatusBar.Refresh();
    }

    private void liRadiosityStatus_Click(object sender, EventArgs e)
    {
      launchRadiosityOptions(null, EventArgs.Empty);
    }
    #endregion

    #endregion
  }

  class HighPerformanceBuffer<T>
  {
    T[] items;
    int position;
    int size;
    public int itemsAdded;

    public HighPerformanceBuffer(int size)
    {
      this.size = size;
      items = new T[size];

      position = 0;
      itemsAdded = 0;
    }

    public T this[int index]
    {
      get
      {
        int trueIndex = position + index;
        if (trueIndex >= size)
          trueIndex -= size;
        return items[trueIndex];
      }
    }

    internal T[] UnderlyingArray { get { return items; } }
    public int Size { get { return size; } }

    public void Add(T val)
    {
      items[position++] = val;

      if (position == size)
        position = 0;
      itemsAdded++;
    }
  }
}