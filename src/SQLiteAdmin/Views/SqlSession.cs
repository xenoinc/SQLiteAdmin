/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-7
 * File:    SqlSession.cs
 * Description:
 *
 * To Do:
 * Change Log:
 *  2017-37 * Initial creation
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
        string query = textEditor1.Text;
        return query;
      }
    }

    /// <summary>All text in editor</summary>
    [DefaultValue("")]
    [Localizability(LocalizationCategory.Text)]
    [Description("Display text"), Category("Data")]
    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    public override string Text { get { return textEditor1.Text; } }

    /// <summary>Gets/sets the syntax highlighting definition used to colorize the text.</summary>
    public IHighlightingDefinition SyntaxHighlighting
    {
      get { return textEditor1.SyntaxHighlighting; }
      set { textEditor1.SyntaxHighlighting = value; }
    }

    /// <summary>Opened query file's path</summary>
    public string FilePath { get; set; }
    

    /// <summary>Has file's contents been changed</summary>
    public bool IsFileChanged { get; private set; }

    /// <summary>Session file's title</summary>
    public string Title
    {
      get
      {
        if (string.IsNullOrEmpty(this.FilePath))
          return "New X";
        else
          return Path.GetFileName(this.FilePath);
      }
    }

    #endregion Properties

    #region Constructors

    public SqlSession()
    {
      InitializeComponent();

      InitDatabase();
    }

    public void InitDatabase()
    {
      _db = new SQLiteProvider();
    }

    private void textEditor1_Load(object sender, EventArgs e) { }

    #endregion Constructors

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
        this._db.ExecuteNonQuery(textEditor1.Text);
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
    
    #endregion Private methods - Database


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
      textEditor1.Text = File.ReadAllText(path);
      this.FilePath = path;
      //this.FileName = 

      return false;

    }

    #endregion Methods - File I/O
    
  }
}