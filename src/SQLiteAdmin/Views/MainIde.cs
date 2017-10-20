/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-01-24
 * File:    MainIde.cs
 * Description:
 *
 * To Do:
 * Change Log:
 *  2017-0124 * Initial creation
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Xeno.SQLiteAdmin.Controls;
using Xeno.SQLiteAdmin.Views;

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

    #endregion Menu Events

    #region Tab Manager

    private void NewSqlSession()
    {
      int count = SqlSessions.Count;
      ++count;
      string title = "Query" + count.ToString();

      TabPage page = new TabPage(title);

      //TODO: Configure new SqlSession from Options
      SqlSession editor = new SqlSession(title);

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
      SaveFileDialog dlg = new SaveFileDialog();
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
      throw new NotImplementedException();
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      //TODO: Get index of active selected tab
      //ActiveSession =
    }

    private void TabOpenFile()
    {
      Stream stream;
      OpenFileDialog dlg = new OpenFileDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        if ((stream = dlg.OpenFile()) != null)
        {
          string fileName = dlg.FileName;
          string buffer = File.ReadAllText(fileName);

          ActiveSqlSession.Editor.Text = buffer;
        }
      }
    }

    #endregion Tab Manager

    #region ToolBar Events

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
      ActiveSqlSession.Execute();
    }

    #endregion ToolBar Events
  }
}
