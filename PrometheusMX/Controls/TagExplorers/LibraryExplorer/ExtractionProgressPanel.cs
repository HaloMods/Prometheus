using System;
using System.IO;
using System.Windows.Forms;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ExtractionProgressPanel : UserControl
  {
    private int tagCount;
    private int totalExtracted;
    private string currentMap;
    private string title;
    private string currentTag;

    private delegate void SetValueDelegate(object value);
    
    public int TagCount
    {
      get { return tagCount; }
      set
      {
        tagCount = value;
        UpdateCounts();
      }
    }

    public int TotalExtracted
    {
      get { return totalExtracted; }
      set
      {
        totalExtracted = value;
        UpdateCounts();
      }
    }

    private bool openingMap = false;

    public bool OpeningMap
    {
      get { return openingMap; }
      set
      {
        openingMap = value;
        UpdateCurrentMapText();
      }
    }

    public bool ExtractingTags
    {
      get { return !openingMap; }
      set
      {
        openingMap = !value;
        UpdateCurrentMapText();
      }
    }

    public string CurrentMap
    {
      get { return currentMap; }
      set { currentMap = value; }
    }

    private void UpdateCurrentMapText()
    {
      if (String.IsNullOrEmpty(currentMap)) currentMap = "NA";
      string labelText;
      if (ExtractingTags)
        labelText = "Extracting from " + currentMap + "";
      else
        labelText = "Opening " + currentMap + "...";

      if (lblCurrentMap.InvokeRequired)
      {
        SetValueDelegate d = delegate(object text) { lblCurrentMap.Text = (string)text; };
        Invoke(d, new object[] { labelText });
      }
      else
        lblCurrentMap.Text = labelText;
    }

    public string Title
    {
      get { return title; }
      set
      {
        title = value;
        if (lblTitle.InvokeRequired)
        {
          SetValueDelegate d = delegate(object text) { lblTitle.Text = (string)text; };
          Invoke(d, new object[] { value });
        }
        else
          lblTitle.Text = value;
      }
    }
    
    public string CurrentTag
    {
      get { return currentTag; }
      set
      {
        currentTag = value;
        UpdateTag();
      }
    }

    public new bool Visible
    {
      get { return base.Visible; }
      set
      {
        if (value)
          busyIndicator.FadeIn();
        else
          busyIndicator.FadeOut();
        base.Visible = value;
      }
    } 

    public event EventHandler Cancel;
    
    public ExtractionProgressPanel()
    {
      InitializeComponent();
      if (!DesignMode)
      {
        Init();
      }
    }
    
    public void Init()
    {
      btnCancel.Click += new EventHandler(btnCancel_Click);
      lblStatus.Text = "Idle";
      lblCurrentMap.Text = "";
      lblExtension.Text = "";
      lblFilename.Text = "";
      lblFolder.Text = "";
      lblTitle.Text = "Decompiler Progress";
      pbExtractionProgress.Minimum = 0;
      pbExtractionProgress.Value = 0;
      btnCancel.Text = "Cancel";
      btnCancel.Enabled = true;
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
      if (Cancel != null)
      {
        Cancel(this, new EventArgs());
        // Set the button to reflect that we are attempting to cancel.
        btnCancel.Text = "Please Wait...";
        btnCancel.Enabled = false;
        Title = "Cancelling...";
      }
    }

    private void UpdateCounts()
    {
      if (pbExtractionProgress.InvokeRequired)
      {
        SetValueDelegate d = delegate(object maxValue) { pbExtractionProgress.Maximum = (int)maxValue; };
        Invoke(d, new object[] { tagCount });
        SetValueDelegate d2 = delegate(object value) { pbExtractionProgress.Value = (int)value; };
        Invoke(d2, new object[] { totalExtracted });
      }
      else
      {
        pbExtractionProgress.Maximum = tagCount;
        pbExtractionProgress.Value = totalExtracted;
      }
      
      string status = "Extracted " + totalExtracted + " of " + tagCount + " tags.";
      if (lblStatus.InvokeRequired)
      {
        SetValueDelegate d = delegate(object text) { lblStatus.Text = (string)text; };
        Invoke(d, new object[] { status });
      }
      else
        lblStatus.Text = status;
    }
    
    private void UpdateTag()
    {
      string folder = Path.GetDirectoryName(currentTag);
      string file = Path.GetFileNameWithoutExtension(currentTag);
      string extenstion = Path.GetExtension(currentTag).Trim('.');
      if (lblFolder.InvokeRequired)
      {
        SetValueDelegate d = delegate(object text) { lblFolder.Text = (string)text; };
        Invoke(d, new object[] { folder });
        SetValueDelegate d2 = delegate(object text) { lblFilename.Text = (string)text; };
        Invoke(d2, new object[] { file });
        SetValueDelegate d3 = delegate(object text) { lblExtension.Text = (string)text; };
        Invoke(d3, new object[] { extenstion });
      }
      else
      {
        lblFolder.Text = folder;
        lblFilename.Text = file;
        lblExtension.Text = extenstion;
      }
    }
  }
}