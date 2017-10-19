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
using System.Windows.Forms;
using Xeno.SQLiteAdmin.Views;

namespace Xeno.SQLiteAdmin
{
  public partial class MainIde : Form
  {
    /// <summary>Open SQL Sessions</summary>
    private List<SqlSession> SqlSessions { get; set; }

    /// <summary>Get set when we select an active tab</summary>
    private SqlSession ActiveSession { get; set; }

    #region Initialization

    public MainIde()
    {
      InitializeComponent();

      InitSessions();
    }

    private void MainIde_Load(object sender, EventArgs e)
    {
      Form frm = new Views.Session();
      frm.Show();
    }

    private void InitSessions()
    {
      // TODO: InitSessions - Check options, AutoLoadPreviousSessions

      // Create single instance for now
      SqlSessions = new List<SqlSession>();
      //ActiveSession = new SqlSession();
      //SqlSessions.Add(ActiveSession);

      CreateNewSqlSession();

      // Create user control
    }

    #endregion Initialization

    #region GUI Events

    private void btnTestSetText_Click(object sender, EventArgs e)
    {
      //TextEditor1.Text = "Here is an external control";
    }

    private void btnTestToggleLines_Click(object sender, EventArgs e)
    {
      //TextEditor1.ShowLineNumbers = !TextEditor1.ShowLineNumbers;
    }

    private void btnTestGetText_Click(object sender, EventArgs e)
    {
      //string tmp;
      //tmp = TextEditor1.Text;
      //tmp += "Here's more text";
      //TextEditor1.Text = tmp;
    }

    private void tsExecute_Click(object sender, EventArgs e)
    {
      tsExecuteAll_Click(sender, e);
    }

    private void tsExecuteAll_Click(object sender, EventArgs e)
    {
      //SqlSession1.Execute(false);
    }

    private void tsExecuteSelection_Click(object sender, EventArgs e)
    {
      //SqlSession1.Execute(true);
    }

    #endregion GUI Events

    #region Menu Events

    private void MenuFileNew_Click(object sender, EventArgs e)
    {
      CreateNewSqlSession();
    }

    private void MenuFileExit_Click(object sender, EventArgs e)
    {
      //TODO: Check if we need to save things & can't exit
      bool cancelExit = false;

      if (!cancelExit)
        Application.Exit();
    }

    private void MenuFileSave_Click(object sender, EventArgs e)
    {
      SaveAllSessions();
    }

    private void MenuEditCut_Click(object sender, EventArgs e)
    {
      GetActiveSqlSession().Cut();
    }

    private void MenuEditCopy_Click(object sender, EventArgs e)
    {
      GetActiveSqlSession().Copy();
    }

    private void MenuEditPaste_Click(object sender, EventArgs e)
    {
      GetActiveSqlSession().Paste();
    }

    private void MenuToolsOptions_Click(object sender, EventArgs e)
    {
      Form frm = new Views.Options();
      frm.ShowDialog(this);
    }

    #endregion Menu Events

    #region Tab Manager

    /// <summary>Get the current active tab selected</summary>
    /// <returns></returns>
    private SqlSession GetActiveSqlSession()
    {
      SqlSession session = null;
      TabPage page = tabControl1.SelectedTab;

      if (page != null)
      {
        session = page.Controls[0] as SqlSession;
      }

      return session;
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      //TODO: Get index of active selected tab
      //ActiveSession =
    }

    #endregion Tab Manager

    #region Private Methods

    private void CreateNewSqlSession()
    {
      int count = SqlSessions.Count;
      ++count;
      string name = "Query" + count.ToString();

      TabPage page = new TabPage(name);

      //TODO: Configure new SqlSession from Options
      SqlSession sqlSession = new SqlSession(name);
      sqlSession.Dock = DockStyle.Fill;
      sqlSession.FilePath = string.Empty;
      sqlSession.SetDatabaseProvider = Xeno.SQLiteAdmin.Data.DatabaseProvider.SQLite;
      sqlSession.SyntaxHighlighting = null;
      sqlSession.Editor.ShowLineNumbers = true;

      page.Controls.Add(sqlSession);
      tabControl1.TabPages.Add(page);

      SqlSessions.Add(sqlSession);

      //// SqlSession Text Editor
      //Views.SqlSession sql;
      //sql = new Xeno.SQLiteAdmin.Views.SqlSession();
      //this.panel1.Controls.Add(sql);
      //
      //sql.FilePath = null;
      //sql.Location = new System.Drawing.Point(221, 139);
      //sql.Name = "SqlSession1";
      //sql.SetDatabaseProvider = Xeno.SQLiteAdmin.Data.DatabaseProvider.SQLite;
      //sql.Size = new System.Drawing.Size(378, 147);
      //sql.SyntaxHighlighting = null;
      //sql.TabIndex = 6;
      //
      //// -----------------
      //// Text Editor
      //AvalonEditWF.TextEditor TextEditor1;
      //TextEditor1 = new Xeno.AvalonEditWF.TextEditor();
      //this.panel1.Controls.Add(this.TextEditor1);
      //
      //this.TextEditor1.Document = null;
      //this.TextEditor1.Location = new System.Drawing.Point(221, 28);
      //this.TextEditor1.Name = "TextEditor1";
      //this.TextEditor1.ShowLineNumbers = true;
      //this.TextEditor1.Size = new System.Drawing.Size(378, 105);
      //this.TextEditor1.SyntaxHighlighting = null;
      //this.TextEditor1.TabIndex = 4;
    }

    private void SaveAllSessions()
    {
    }

    #endregion Private Methods
  }
}
