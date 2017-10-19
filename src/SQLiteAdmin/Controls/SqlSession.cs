/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-7
 * File:    SqlSession.cs
 * Description:
 *  SQL Session with TextEditor
 *
 * Note:
 *  TextEditor1 is NOT the actual editor; use _textEditor.
 *  It's only there so we can test property changes w/ VS Properties window
 *
 * Change Log:
 *  2017-0307 * Initial creation
 *  2017-1018 + Added Cut/Copy/Paste
 */

using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit.Highlighting;
using Xeno.SQLiteAdmin.Data;
using Xeno.SQLiteAdmin.Data.Provider;

namespace Xeno.SQLiteAdmin.Views
{
  public partial class SqlSession : UserControl
  {
    #region Fields

    private IDatabaseProvider _db;

    private Xeno.AvalonEditWF.TextEditor _textEditor;

    /// <summary>Session file's title</summary>
    private string _title;

    #endregion Fields

    #region ctr/~dtr

    /// <summary>Construct user control and auto load a file</summary>
    public SqlSession() : this("Unknown") { }

    /// <summary>Construct user control and auto load a file</summary>
    /// <remarks>If fullFilePath is provided, the Title is ignored.</remarks>
    /// <param name="title"></param>
    public SqlSession(string title) : this(title, "") { }

    /// <summary>Construct user control and auto load a file</summary>
    /// <remarks>If fullFilePath is provided, the Title is ignored.</remarks>
    /// <param name="title"></param>
    /// <param name="fullFilePath"></param>
    public SqlSession(string title, string fullFilePath) : this(title, fullFilePath, "") { }

    /// <summary>Construct user control and auto load a file</summary>
    /// <remarks>If fullFilePath is provided, the Title is ignored.</remarks>
    /// <param name="title">Title of file (blank if FullPath is provided)</param>
    /// <param name="fullFilePath">Full file path to query</param>
    /// <param name="dbConnection">SQLite Database file path</param>
    public SqlSession(string title, string fullFilePath, string dbConnection)
    {
      InitializeComponent();

      InitEditor();

      InitDatabase(dbConnection);

      FilePath = fullFilePath;

      // Auto-load file if provided
      if (FilePath == string.Empty)
      {
        Title = title;
      }
      else
      {
        Editor.Editor.Load(fullFilePath);
      }
    }

    ~SqlSession()
    {
      if (_db != null)
      {
        _db.Close();
      }
    }

    #endregion ctr/~dtr

    public Xeno.AvalonEditWF.TextEditor Editor { get { return _textEditor; } }

    /// <summary>Opened query file's path</summary>
    public string FilePath { get; set; }

    /// <summary>Has file's contents been changed</summary>
    public bool IsFileChanged { get; private set; }

    /// <summary>Get/Set the DB provider</summary>
    public DatabaseProvider SetDatabaseProvider { get; set; }

    /// <summary>Gets/sets the syntax highlighting definition used to colorize the text.</summary>
    public IHighlightingDefinition SyntaxHighlighting
    {
      get { return _textEditor.SyntaxHighlighting; }
      set { _textEditor.SyntaxHighlighting = value; }
    }

    /// <summary>All text in editor</summary>
    [DefaultValue("")]
    [Localizability(LocalizationCategory.Text)]
    [Description("Display text"), Category("Data")]
    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    public override string Text
    {
      get { return _textEditor.Text; }
      set { _textEditor.Text = value; }
    }

    /// <summary>Get text from selection</summary>
    /// <returns></returns>
    public string TextSelected
    {
      get
      {
        //TODO: Get text from selection; currently gets all text
        string query = _textEditor.Text;
        return query;
      }
    }

    public string Title
    {
      get
      {
        return _title;
      }
      set
      {
        // TODO: Set Title - verify that this isn't buggy
        if (string.IsNullOrEmpty(this.FilePath))
        {
          _title = value;
        }
        else
        {
          _title = Path.GetFileName(this.FilePath);
        }
      }
    }

    public void InitDatabase(string sqliteDbPath = "", string password = "")
    {
      if (File.Exists(sqliteDbPath))
      {
        if (string.IsNullOrEmpty(password))
          _db = new SQLiteProvider(sqliteDbPath);
        else
        {
          try
          {
            _db = new SQLiteProvider(sqliteDbPath, password);
          }
          catch
          {
            //TODO: InitDatabase - Handle invalid password
          }
        }
      }
      else
        _db = new SQLiteProvider();
    }

    private void InitEditor()
    {
      //TODO: Remove Me - Keeping around so we can toy with some properties in VS
      //this.textEditor1.Load -= new System.EventHandler(this.textEditor1_Load);
      this.Controls.Remove(textEditor1);
      textEditor1.Dispose();

      // Configure Editor Defaults from Settings
      _textEditor = new Xeno.AvalonEditWF.TextEditor();
      _textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      _textEditor.Document = null;
      _textEditor.Location = new System.Drawing.Point(0, 0);
      _textEditor.Name = "_textEditor";
      _textEditor.ShowLineNumbers = true;
      _textEditor.Size = new System.Drawing.Size(473, 134);
      _textEditor.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      // _textEditor.Editor.FontFamily = new System.Windows.Media.FontFamily("Consolas");
      _textEditor.SyntaxHighlighting = null;
      _textEditor.TabIndex = 1;

      // Database wireups
      this.SetDatabaseProvider = Xeno.SQLiteAdmin.Data.DatabaseProvider.SQLite;

      // Add the control
      this.Controls.Add(_textEditor);
      this.Dock = DockStyle.Fill;
    }

    #region Methods - Editor

    /// <summary>Copy editor's contents to clipboard</summary>
    public void Copy()
    {
      this._textEditor.Editor.Copy();
    }

    /// <summary>Cut the selected editor contents to clipboard</summary>
    public void Cut()
    {
      _textEditor.Editor.Cut();
    }

    /// <summary>Paste clipboard's contents to editor</summary>
    public void Paste()
    {
      this._textEditor.Editor.Paste();
    }

    #endregion Methods - Editor

    #region Methods - Database

    /// <summary>Make a connection to database</summary>
    /// <returns></returns>
    public bool Connect()
    {
      throw new NotImplementedException();

      return false;
    }

    public int Execute()
    {
      //TODO: Execute - If there is text selected, execute that. If NOTHING selected, execute ALL
      //TODO: Execute - Output results to either Text, DataGrid, or file
      this._db.ExecuteNonQuery(_textEditor.Text);
      return 0;
    }

    private int ExecuteNonQuery(string query)
    {
      int rowsAffected = 0;

      return rowsAffected;
    }

    private int ExecuteQuery(string query)
    {
      throw new NotImplementedException();
      return 0;
    }

    #endregion Methods - Database

    #region Methods - File I/O

    public bool LoadFile(string path)
    {
      this.IsFileChanged = false;
      _textEditor.Text = File.ReadAllText(path);
      this.FilePath = path;
      //this.FileName =

      return false;
    }

    public bool SaveFile(string path)
    {
      this.IsFileChanged = false;

      throw new NotImplementedException();

      return false;
    }

    #endregion Methods - File I/O
  }
}