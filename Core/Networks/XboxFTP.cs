using System;
using System.Net;

namespace Core.Networks
{
  /// <summary>
  /// Represents a FTP connection to an Xbox console.
  /// </summary>
  public class XboxFTP
  {
    private ushort port = 0;
    private IPAddress ip = null;
    private string username = null;
    private string password = null;
    private WebClient client = new WebClient();
    
    /// <summary>
    /// Creates a new instance of the XboxFTP class.
    /// </summary>
    /// <param name="user">username</param>
    /// <param name="pass">password</param>
    /// <param name="ipAddress">ip address</param>
    /// <param name="portNumber">port</param>
    public XboxFTP(string user, string pass, long ipAddress, ushort portNumber)
    {
      username = user;
      password = pass;
      ip = new IPAddress(ipAddress);
      port = portNumber;
    }

    /// <summary>
    /// Reads a binary file from the Xbox and returns the binary data.
    /// </summary>
    public byte[] ReadRemote(string filepath)
    { return client.DownloadData(CreateUri(filepath)); }

    /// <summary>
    /// Reads a binary file from the Xbox and saves it to disk.
    /// </summary>
    public void DownloadFile(string source, string destination)
    { client.DownloadFile(CreateUri(source), destination); }

    /// <summary>
    /// Writes an on-disk file to the Xbox.
    /// </summary>
    public void UploadFile(string source, string destination)
    { client.UploadFile(CreateUri(destination), source); }

    /// <summary>
    /// Writes an in-memory file to the Xbox.
    /// </summary>
    public void UploadBinary(byte[] data, string destination)
    { client.UploadData(CreateUri(destination), data); }

    private string CreateUri(string filepath)
    {
      filepath.Replace('\\', '/');
      if(String.IsNullOrEmpty(username))
        return String.Format(@"ftp://{0}:{1}/{2}", ip.ToString(), port, filepath);
      else if (String.IsNullOrEmpty(password))
        return String.Format(@"ftp://{0}@{1}:{2}/{3}", username, ip.ToString(), port, filepath);
      else
        return String.Format(@"ftp://{0}:{1}@{2}:{3}/{4}", username, password, ip.ToString(), port, filepath);
    }

    ~XboxFTP()
    { client.Dispose(); }
  }
}
