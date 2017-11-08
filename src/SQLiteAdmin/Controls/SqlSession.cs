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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit.Highlighting;
using log4net;
using Xeno.SQLiteAdmin.Data;
using Xeno.SQLiteAdmin.Data.Provider;

namespace Xeno.SQLiteAdmin.Controls
{
  public partial class SqlSession : UserControl
  {
    private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private IDatabaseProvider _db;
    private bool _showResultsPanel;
    private Xeno.AvalonEditWF.TextEditor _textEditor;

    /// <summary>Session file's title</summary>
    private string _title;

    #region ctr/~dtr

    /// <summary>Construct user control and auto load a file</summary>
    public SqlSession() : this("Unknown", "", null) { }

    /// <summary>Construct user control and auto load a file</summary>
    /// <remarks>If fullFilePath is provided, the Title is ignored.</remarks>
    /// <param name="title"></param>
    public SqlSession(string title) : this(title, "", null) { }

    /// <summary>Construct user control and auto load a file</summary>
    /// <remarks>If fullFilePath is provided, the Title is ignored.</remarks>
    /// <param name="title"></param>
    /// <param name="fullFilePath"></param>
    public SqlSession(string title, string sqlFilePath) : this(title, sqlFilePath, null) { }

    /// <summary>Construct user control and auto load a file</summary>
    /// <remarks>If fullFilePath is provided, the Title is ignored.</remarks>
    /// <param name="title">Title of file (blank if FullPath is provided)</param>
    /// <param name="fullFilePath">Full file path to query</param>
    /// <param name="dbConnection">SQLite Database file path</param>
    public SqlSession(string title, string sqlFilePath = "", IDatabaseProvider provider = null)
    {
      ProviderProperties = new Dictionary<DatabaseProperty, string>();

      InitializeComponent();

      InitEditor();

      InitOutput();

      InitDatabase(provider);

      FilePath = sqlFilePath;

      // Auto-load file if provided
      if (FilePath == string.Empty)
      {
        Title = title;
      }
      else
      {
        Editor.Editor.Load(sqlFilePath);
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
    public bool IsDirty
    {
      get
      {
        return this.Editor.IsDirty;
      }

      private set
      {
        this.Editor.IsDirty = value;
      }
    }

    /// <summary>Output results to file</summary>
    public string OutputToFile { get; set; }

    /// <summary>Database Provider (SQLite, SQLiteCrypt, MySQL, etc.</summary>
    public DatabaseProvider ProviderType { get; set; }

    public QueryOutputType QueryOutputType { get; set; }

    public Dictionary<DatabaseProperty, string> ProviderProperties { get; set; }

    /// <summary>Show output results</summary>
    public bool ShowResults
    {
      get { return _showResultsPanel; }
      set
      {
        _showResultsPanel = value;
        if (_showResultsPanel)
        {
          splitContainer.Panel2Collapsed = false;
        }
        else
        {
          splitContainer.Panel2Collapsed = true;
        }
      }
    }

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
        return _title + (IsDirty == true ? "*" : string.Empty);
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

    public void InitDatabase(IDatabaseProvider provider, string password = "") // , string sqliteDbPath = "", string password = "")
    {
      if (provider != null && provider.ProviderType != DatabaseProvider.Unknown)
      {
        _db = provider;
        this.ProviderType = _db.ProviderType;

        if (_db.ProviderType == DatabaseProvider.SQLite)
        {
          string connString = provider.ConnectionString;
        }

        //if (File.Exists(sqliteDbPath))
        //{
        //  if (string.IsNullOrEmpty(password))
        //    _db = new SQLiteProvider(sqliteDbPath);
        //  else
        //  {
        //    try
        //    {
        //      _db = new SQLiteProvider(sqliteDbPath, password);
        //    }
        //    catch
        //    {
        //      //TODO: InitDatabase - Handle invalid password
        //    }
        //  }
        //}
        //else
        //  _db = new SQLiteProvider();
      }
      else
      {
        // Log.Debug("Provider not specified");
      }
    }

    /// <summary>Initialize Query Editor</summary>
    private void InitEditor()
    {
      //TODO: Remove Me - Keeping around so we can toy with some properties in VS
      //this.textEditor1.Load -= new System.EventHandler(this.textEditor1_Load);
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel1.Controls.Remove(textEditor1);
      this.Controls.Remove(textEditor1);
      this.textEditor1.Dispose();

      _textEditor = new Xeno.AvalonEditWF.TextEditor();

      // Configure Editor Defaults from Settings
      _textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      _textEditor.Document = null;
      _textEditor.Location = new System.Drawing.Point(0, 0);
      _textEditor.Name = "_textEditor";
      _textEditor.ShowLineNumbers = true;
      _textEditor.SyntaxHighlighting = null;
      _textEditor.TabIndex = 1;
      _textEditor.Size = new System.Drawing.Size(473, 134);
      _textEditor.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      // _textEditor.Editor.FontFamily = new System.Windows.Media.FontFamily("Consolas");
      //_textEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Editor_KeyPress);

      // Database wire-ups (defaults)
      this.ProviderType = Xeno.SQLiteAdmin.Data.DatabaseProvider.SQLite;

      // Add the control
      this.splitContainer.Panel1.Controls.Add(_textEditor);
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.ResumeLayout(false);
      this.Dock = DockStyle.Fill;
    }

    /// <summary>Initialize Results Panel</summary>
    private void InitOutput()
    {
      //TODO: Get last used QueryOutputType from settings
      var outputType = QueryOutputType.Text;
      bool showResultsPanel = true;

      switch (outputType)
      {
        case QueryOutputType.File:
          var fileName = string.Empty;
          SetOutputType(outputType, fileName);
          break;

        case QueryOutputType.Text:
        case QueryOutputType.DataGrid:
        default:
          SetOutputType(outputType);
          break;
      }

      ShowResults = showResultsPanel;
    }

    #region Methods - Editor

    //private void Editor_KeyPress(object sender, KeyPressEventArgs e)
    //{
    //  if (!IsDirty)
    //    IsDirty = true;
    //}

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

    public void LoadSyntaxDefinition(string fullName)
    {
      throw new NotImplementedException();

      //https://stackoverflow.com/questions/16169584/avalonedit-change-syntax-highlighting-in-code
      //
      //      ICSharpCode.AvalonEdit.TextEditor textEditor = new ICSharpCode.AvalonEdit.TextEditor();
      //      textEditor.ShowLineNumbers = true;
      //      string dir = @"C:\Program Files\MyFolder\";
      //#if DEBUG
      //      dir = @"C:\Dev\Sandbox\SharpDevelop-master\src\Libraries\AvalonEdit\ICSharpCode.AvalonEdit\Highlighting\Resources\";
      //#endif
      //
      //      Stream xshd_stream = File.OpenRead(dir + "CSharp-Mode.xshd");
      //      System.Xml.XmlTextReader xshd_reader = new System.Xml.XmlTextReader(xshd_stream);
      //      textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(
      //        xshd_reader,
      //        ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance);
      //      xshd_reader.Close();
      //      xshd_stream.Close();
    }

    /// <summary>Paste clipboard's contents to editor</summary>
    public void Paste()
    {
      this._textEditor.Editor.Paste();
    }

    public void SetOutputType(QueryOutputType outputType, string fileName = "")
    {
      switch (outputType)
      {
        case QueryOutputType.File:
          OutputToFile = fileName;
          break;

        case QueryOutputType.Text:
        case QueryOutputType.DataGrid:
        default:

          break;
      }
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

      Log.Debug("Executing query");

      Exception ex;

      this._db.ExecuteNonQuery(_textEditor.Text, out ex);

      if (ex != null)
      {
        // Display the error
        Log.Error("Query ExecuteNonQuery encountered an error. " + ex.Message);

        System.Windows.Forms.MessageBox.Show(ex.Message, "Error Executing Query");
      }

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
      this.IsDirty = false;

      _textEditor.Text = File.ReadAllText(path);
      this.FilePath = path;
      //this.FileName =

      return false;
    }

    public bool SaveFile(string path)
    {
      this.IsDirty = false;

      throw new NotImplementedException();

      return false;
    }

    #endregion Methods - File I/O
  }
}