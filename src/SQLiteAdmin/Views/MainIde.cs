/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-01-24
 * File:    MainIde.cs
 * Description:
 *
 * TODO: Switch to MVP pattern
 * TODO: Later consider changing to WPF?
 *
 * Change Log:
 *  2017-0124 * Initial creation
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Xeno.SQLiteAdmin.Controls;
using Xeno.SQLiteAdmin.Data;
using Xeno.SQLiteAdmin.Data.Provider;

namespace Xeno.SQLiteAdmin
{
  public partial class MainIde : Form
  {
    private const int WM_HOTKEY = 0x0312;
    private int _hotkeyCtrlS = 0;

    public MainIde()
    {
      InitializeComponent();
      InitIde();
    }

    private enum KeyModifier
    {
      None = 0,
      Alt = 1,
      Control = 2,
      Shift = 4,
      WinKey = 8
    }

    /// <summary>Get the active tab selected</summary>
    /// <returns></returns>
    private SqlSession ActiveSqlSession
    {
      get
      {
        SqlSession session = null;
        TabPage page = tabControl1.SelectedTab;

        if (page != null)
        {
          session = page.Controls[0] as SqlSession;
        }

        return session;
      }
    }

    /// <summary>Open SQL Sessions</summary>
    private List<SqlSession> SqlSessions { get; set; }

    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);

      if (m.Msg == WM_HOTKEY)
      {
        if (m.WParam.ToInt32() == _hotkeyCtrlS)
        {
          SaveActiveSession();
        }

        // HotKey Breakdown:
        //Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);              // The key of the hotkey that was pressed.
        //KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);   // The modifier of the hotkey that was pressed.
        //int id = m.WParam.ToInt32();                                    // The id of the hotkey that was pressed.
      }
    }

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    private void InitHotKeys()
    {
      RegisterHotKey(this.Handle, _hotkeyCtrlS, (int)KeyModifier.Control, Keys.S.GetHashCode());
    }

    private void InitIde()
    {
      InitSessions();
      InitHotKeys();
    }

    private void InitSessions()
    {
      // TODO: InitSessions - Check options, AutoLoadPreviousSessions

      // Create single instance for now
      SqlSessions = new List<SqlSession>();
      //ActiveSession = new SqlSession();
      //SqlSessions.Add(ActiveSession);

      NewSqlSession();

      // Create user control
    }

    private void MainIde_FormClosing(object sender, FormClosingEventArgs e)
    {
      UnregisterHotKey(this.Handle, _hotkeyCtrlS);
    }

    private void MainIde_Load(object sender, EventArgs e)
    {
      // Test loading external session
      //Form frm = new Views.SessionForm();
      //frm.Show();
    }

    #region Menu Events

    private void MenuEditCopy_Click(object sender, EventArgs e)
    {
      ActiveSqlSession.Copy();
    }

    private void MenuEditCut_Click(object sender, EventArgs e)
    {
      ActiveSqlSession.Cut();
    }

    private void MenuEditPaste_Click(object sender, EventArgs e)
    {
      ActiveSqlSession.Paste();
    }

    private void MenuFileExit_Click(object sender, EventArgs e)
    {
      //TODO: Check if we need to save things & can't exit
      bool cancelExit = false;

      if (!cancelExit)
        Application.Exit();
    }

    private void MenuFileNew_Click(object sender, EventArgs e)
    {
      NewSqlSession();
    }

    private void MenuFileOpenFile_Click(object sender, EventArgs e)
    {
      TabOpenFile();
    }

    private void MenuFileSave_Click(object sender, EventArgs e)
    {
      SaveActiveSession();
    }

    private void MenuToolsOptions_Click(object sender, EventArgs e)
    {
      Form frm = new Views.OptionsForm();
      frm.ShowDialog(this);
    }

    private void MenuWindowResultsPane_Click(object sender, EventArgs e)
    {
      ActiveSqlSession.ShowResults = !ActiveSqlSession.ShowResults;
      MenuWindowResultsPane.Checked = ActiveSqlSession.ShowResults;
    }

    #endregion Menu Events

    #region Tab Manager

    private void NewSqlSession()
    {
      int count = SqlSessions.Count;
      ++count;
      string title = "Query" + count.ToString();

      TabPage page = new TabPage(title);

      //TODO: Configure new SqlSession from Options
      SqlSession editor = new SqlSession(title, string.Empty, ActiveSessionProviderDetails);

      //editor.Font = new System.Drawing.Font()
      //{
      //  Family = "";
      //};

      page.Controls.Add(editor);
      tabControl1.TabPages.Add(page);

      SqlSessions.Add(editor);
    }

    private void SaveActiveSession()
    {
      SaveFileDialog dlg = new SaveFileDialog()
      {
        Filter = "SQL files (*.sql)|*.sql|All files (*)|*",
        FilterIndex = 1,
        RestoreDirectory = true
      };
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        using (Stream s = File.Open(dlg.FileName, FileMode.CreateNew))
        using (StreamWriter writer = new StreamWriter(s))
        {
          writer.Write(ActiveSqlSession.Editor.Text);
        }
      }
    }

    /// <summary>Save all sessions</summary>
    /// <remarks>Consider using a dialog with a list to select which files</remarks>
    private void SaveAllSessions()
    {
      //throw new NotImplementedException();
      SaveActiveSession();
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      //TODO: Get index of active selected tab
      //ActiveSession =
    }

    private void TabOpenFile()
    {
      Stream stream;
      OpenFileDialog dlg = new OpenFileDialog()
      {
        Filter = "SQL files (*.sql)|*.sql|All files (*)|*",
        FilterIndex = 1,
        RestoreDirectory = true
      };

      if (dlg.ShowDialog() == DialogResult.OK)
      {
        if ((stream = dlg.OpenFile()) != null)
        {
          string fileName = dlg.FileName;
          try
          {
            string buffer = File.ReadAllText(fileName);
            ActiveSqlSession.Editor.Text = buffer;
            ActiveSqlSession.InitDatabase(ActiveSessionProviderDetails);
          }
          catch (Exception ex)
          {
            MessageBox.Show("An issue occurred attempting to open file.\n\r" + ex.Message);
          }
        }
      }
    }

    #endregion Tab Manager

    #region ToolBar Events

    private void ToolDatabasePicker_Click(object sender, EventArgs e)
    {
      string path = ChooseSqliteDbDialog();
      if (File.Exists(path))
      {
        ToolDatabasePath.Text = path;
        AddRecentDbFile(path);

        UpdateSessionConnection(path);
      }
    }

    private void ToolDbgGetText_Click(object sender, EventArgs e)
    {
      //string tmp;
      //tmp = TextEditor1.Text;
      //tmp += "Here's more text";
      //TextEditor1.Text = tmp;
    }

    private void ToolDbgSetText_Click(object sender, EventArgs e)
    {
      //TextEditor1.Text = "Here is an external control";
    }

    private void ToolDbgToggleLines_Click(object sender, EventArgs e)
    {
      ActiveSqlSession.Editor.ShowLineNumbers = !ActiveSqlSession.Editor.ShowLineNumbers;
      ToolDbgToggleLines.Checked = ActiveSqlSession.Editor.ShowLineNumbers;
    }

    private void ToolNewQuery_Click(object sender, EventArgs e)
    {
      NewSqlSession();
    }

    private void ToolSqlExecute_Click(object sender, EventArgs e)
    {
      ExecuteQuery();
    }

    #endregion ToolBar Events

    #region Private Methods

    private string ActiveSqliteDatabase { get; set; }

    private string ActiveSqlitePassword { get; set; }

    /// <summary>Current selected provider</summary>
    private Data.IDatabaseProvider ActiveSessionProviderDetails
    {
      get
      {
        IDatabaseProvider provider = new Data.Provider.SQLiteProvider();
        provider.Properties[DatabaseProperty.SqliteDatabase] = ActiveSqliteDatabase;
        provider.Properties[DatabaseProperty.SqlitePassword] = ActiveSqlitePassword;
        return provider;
      }
    }

    /// <summary>Set the DB connection for active session</summary>
    /// <param name="dbPath"></param>
    private void UpdateSessionConnection(string dbPath)
    {
      ActiveSqliteDatabase = dbPath;
      ActiveSqlSession.ProviderProperties[DatabaseProperty.SqliteDatabase] = ActiveSqliteDatabase;
      ActiveSqlSession.ProviderProperties[DatabaseProperty.SqlitePassword] = ActiveSqlitePassword;
    }

    /// <summary>Execute based upon currently selected database path</summary>
    private void ExecuteQuery()
    {
      // 1. Ensure we're executing against selected DB from dropdown
      ActiveSqlSession.InitDatabase(ActiveSessionProviderDetails);

      // 2. Execute
      //TODO: ExecuteQuery via Thread-safe operation
      ActiveSqlSession.Execute();

      // 3. Ensure we're returning feedback via EventHandler
    }

    /// <summary>Add file path to picker list</summary>
    /// <param name="filePath"></param>
    private void AddRecentDbFile(string filePath)
    {
      //TODO: Save paths and filename in array & link to ComboBox
      if (File.Exists(filePath))
      {
        ToolDatabasePath.Items.Add(filePath);
      }
    }

    /// <summary>Find SQLite DB file</summary>
    /// <param name="baseDir">Starting folder</param>
    /// <returns>File path of selected DB file</returns>
    private string ChooseSqliteDbDialog(string baseDir = "")
    {
      string fileName = string.Empty;
      OpenFileDialog dlg = new OpenFileDialog()
      {
        //DereferenceLinks = true,
        Filter = "SQLite DB files|*.db|All files|*",
        FilterIndex = 1,
        InitialDirectory = baseDir,
        RestoreDirectory = true
      };

      if (dlg.ShowDialog() == DialogResult.OK)
        fileName = dlg.FileName;

      return fileName;
    }

    #endregion Private Methods
  }
}
