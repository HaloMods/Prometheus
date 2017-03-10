using System;
using System.Drawing;
using System.Windows.Forms;
using Interfaces;
using Prometheus.Properties;
using XPTable.Models;

namespace Prometheus.Controls
{
  public partial class ListOutputListener : UserControl, IOutputListener
  {
    private int historyLength = 100;
    
    public int HistoryLength
    {
      get { return historyLength; }
      set { historyLength = value; }
    }
    
    public ListOutputListener()
    {
      InitializeComponent();
      InitializeTable();
    }

    private void InitializeTable()
    {
      ImageColumn iconColumn = new ImageColumn("Information", 25);
      iconColumn.DrawText = true;
      TextColumn timestampColumn = new TextColumn("Timestamp", 75);
      TextColumn textColumn = new TextColumn("Text", 100);
      textColumn.Width = table.Width;
      
      table.ColumnModel = new ColumnModel(new Column[] { iconColumn, timestampColumn, textColumn });
      table.TableModel = new TableModel();
      table.TableModel.RowHeight = 21;
      table.SizeChanged += new EventHandler(table_SizeChanged);
    }

    void table_SizeChanged(object sender, EventArgs e)
    {
      table.ColumnModel.Columns[2].Width = table.Width-(25 + 100);
    }

    public delegate void WriteDelegate(string text, string additionalInformation, OutputTypes outputTypes);
    
    public void Write(string text, string additionalInformation, OutputTypes outputTypes)
    {
      if (table.InvokeRequired)
      {
        WriteDelegate write = new WriteDelegate(Write);
        table.Invoke(write, text, additionalInformation, outputTypes);
      }
      else
      {
        Bitmap icon = new Bitmap(1, 1);
        Color foreColor = Color.Black;
        if (outputTypes == OutputTypes.Information)
        {
          icon = Resources.information16;
          foreColor = Color.Black;
        }
        if (outputTypes == OutputTypes.Warning)
        {
          icon = Resources.warning16;
          foreColor = Color.Orange;
        }
        if (outputTypes == OutputTypes.Error)
        {
          icon = Resources.error16;
          foreColor = Color.Red;
        }
        if (outputTypes == OutputTypes.Debug)
        {
          icon = Resources.data16;
          foreColor = Color.Green;
        }
        if (table.TableModel.Rows.Count > historyLength)
          table.TableModel.Rows.RemoveAt(0);

        Cell cellIcon = new Cell("", icon);
        cellIcon.Editable = false;

        Cell cellTimeStamp = new Cell(DateTime.Now.ToLongTimeString());
        cellTimeStamp.Editable = false;
        cellTimeStamp.ForeColor = foreColor;
        
        Cell cellText = new Cell(text);
        cellText.Editable = false;
        cellText.ForeColor = foreColor;
        cellText.Tag = additionalInformation;
        
        table.TableModel.Rows.Add(new Row(new Cell[] { cellIcon, cellTimeStamp, cellText }));
        table.EnsureVisible(table.TableModel.Rows.Count - 1, 0);
      }
    }
  }
}