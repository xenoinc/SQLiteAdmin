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
    #region Attributes

    private IDatabaseProvider _db;

    private Xeno.AvalonEditWF.TextEditor _textEditor;

    #endregion Attributes

    #region Properties

    /// <summary>Get/Set the DB provider</summary>
    public DatabaseProvider SetDatabaseProvider { get; set; }

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

    /// <summary>All text in editor</summary>
    [DefaultValue("")]
    [Localizability(LocalizationCategory.Text)]
    [Description("Display text"), Category("Data")]
    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    public override string Text { get { return _textEditor.Text; } }

    /// <summary>Gets/sets the syntax highlighting definition used to colorize the text.</summary>
    public IHighlightingDefinition SyntaxHighlighting
    {
      get { return _textEditor.SyntaxHighlighting; }
      set { _textEditor.SyntaxHighlighting = value; }
    }

    /// <summary>Opened query file's path</summary>
    public string FilePath { get; set; }

    /// <summary>Has file's contents been changed</summary>
    public bool IsFileChanged { get; private set; }

    /// <summary>Session file's title</summary>
    private string _title;

    public string Title
    {
      get
      {
        return _title;
        //  if (string.IsNullOrEmpty(this.FilePath))
        //    return "New X";
        //  else
        //    return Path.GetFileName(this.FilePath);
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

    public Xeno.AvalonEditWF.TextEditor Editor { get { return _textEditor; } }

    #endregion Properties

    #region Constructors

    public SqlSession() : this("Unknown")
    {
    }

    public SqlSession(string name)
    {
      InitializeComponent();

      InitEditor();

      InitDatabase();
    }

    private void InitEditor()
    {
      // Only keep this around so we can see the properties in the C# menu
      this.textEditor1.Load -= new System.EventHandler(this.textEditor1_Load);
      this.Controls.Remove(textEditor1);
      textEditor1.Dispose();

      // Now create our REAL editor
      this._textEditor = new Xeno.AvalonEditWF.TextEditor();
      this._textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this._textEditor.Document = null;
      this._textEditor.Location = new System.Drawing.Point(0, 0);
      this._textEditor.Name = "textEditor1";
      this._textEditor.ShowLineNumbers = true;
      this._textEditor.Size = new System.Drawing.Size(473, 134);
      this._textEditor.SyntaxHighlighting = null;
      this._textEditor.TabIndex = 1;
      //this._textEditor.Load += new System.EventHandler(this.textEditor_Load);

      this.Controls.Add(_textEditor);
    }

    public void InitDatabase()
    {
      _db = new SQLiteProvider();
    }

    private void textEditor1_Load(object sender, EventArgs e)
    {
    }

    #endregion Constructors

    #region Methods - Editor

    /// <summary>Cut the selected editor contents to clipboard</summary>
    public void Cut()
    {
      _textEditor.Editor.Cut();
    }

    /// <summary>Copy editor's contents to clipboard</summary>
    public void Copy()
    {
      this._textEditor.Editor.Copy();
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

    public int Execute(bool selection = false)
    {
      if (!selection)
      {
        this._db.ExecuteNonQuery(_textEditor.Text);
      }
      else
      {
        throw new NotImplementedException();
      }

      return 0;
    }

    #endregion Methods - Database

    #region Private Methods - Database

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

    #endregion Private Methods - Database

    #region Methods - File I/O

    public bool SaveFile(string path)
    {
      this.IsFileChanged = false;

      throw new NotImplementedException();

      return false;
    }

    public bool LoadFile(string path)
    {
      this.IsFileChanged = false;
      _textEditor.Text = File.ReadAllText(path);
      this.FilePath = path;
      //this.FileName =

      return false;
    }

    #endregion Methods - File I/O
  }
}