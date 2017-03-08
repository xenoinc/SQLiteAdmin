﻿/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-3
 * File:    SyntaxEditor.cs
 * Description:
 *  Windows Forms wrapper for AvalonEdit
 * 
 * Resources:
 *  https://github.com/icsharpcode/AvalonEdit
 * Change Log:
 *  2017-0303 * Initial creation
 */

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Markup;

using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Utils;

namespace Xeno.AvalonEditWF
{
  /// <summary>The text editor control. Contains a scrollable TextArea.</summary>
  [Localizability(LocalizationCategory.Text), ContentProperty("Text")]
  public partial class TextEditor : UserControl //, ICSharpCode.AvalonEdit.TextEditor
  {
    #region Constructor

    private ICSharpCode.AvalonEdit.TextEditor _editor;
    private System.Windows.Forms.Integration.ElementHost _elementHost;

    /// <summary>Creates a new TextEditor instance</summary>
    public TextEditor()
      : this(new TextArea())
    {
    }

    /// <summary>Creates a new TextEditor instance</summary>
    public TextEditor(TextArea textArea)
    {
      InitializeComponent();

      InitElementHost();

      InitEditor();

      _elementHost.Child = _editor;
    }

    private void TextEditor_Load(object sender, EventArgs e) { }

    public void InitElementHost()
    {
      this.SuspendLayout();

      this._elementHost = new System.Windows.Forms.Integration.ElementHost();
      this._elementHost.Dock = System.Windows.Forms.DockStyle.Fill;
      this._elementHost.Location = new System.Drawing.Point(0, 0);
      this._elementHost.Name = "_elementHost";
      this._elementHost.Size = new System.Drawing.Size(169, 82);
      this._elementHost.TabIndex = 1;
      this._elementHost.Text = "_elementHost";
      this._elementHost.Child = null;

      this.Controls.Add(_elementHost);
      this.ResumeLayout(false);
    }

    public void InitEditor()
    {
      _editor = new ICSharpCode.AvalonEdit.TextEditor();
      //IHighlightingDefinition sqlHighlight;

      _editor.TextArea.TextEntering += Editor_TextArea_TextEntering;
      _editor.TextArea.TextEntered += Editor_TextArea_TextEntered;

      _editor.Text = "-- Welcome to SQLite Admin";
      _editor.ShowLineNumbers = true;

      //DispatcherTimer foldingUpdateTimer = new DispatcherTimer();
      //foldingUpdateTimer.Interval = TimeSpan.FromSeconds(2);
      //foldingUpdateTimer.Tick += delegate { UpdateFoldings(); };
      //foldingUpdateTimer.Start();
    }

    #endregion Constructor

    #region Wrapped Properties

    //public static readonly DependencyProperty DocumentProperty = TextView.DocumentProperty.AddOwner(typeof(TextEditor), new FrameworkPropertyMetadata(OnDocumentChanged));

    public TextDocument Document { get; set; }

    /// <summary>Specifies whether line numbers are shown on the left to the text view.</summary>
    [Description("Show line numbers"), Category("Data")]
    public bool ShowLineNumbers
    {
      get { return _editor.ShowLineNumbers; }
      set
      {
        _editor.ShowLineNumbers = value;
        _elementHost.Refresh();
      }
    }

    /// <summary>Gets/Sets the text of the current document</summary>
    [DefaultValue("")]
    [Localizability(LocalizationCategory.Text)]
    [Description("Display text"), Category("Data")]
    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    public override string Text
    {
      get { return _editor.Text; }
      set
      {
        _editor.Text = value;
        _elementHost.Refresh();
      }
    }

    /// <summary>Gets/sets the syntax highlighting definition used to colorize the text.</summary>
    public IHighlightingDefinition SyntaxHighlighting
    {
      get { return _editor.SyntaxHighlighting; }
      set { _editor.SyntaxHighlighting = value; }
    }

    #endregion Properties

    #region Wrapped Methods



    #endregion Wrapped Methods

    #region Methods

    public void OpenFile()
    {
      throw new NotImplementedException();
    }

    public void SaveFile()
    {
      throw new NotImplementedException();
    }

    #endregion Methods

    #region Events

    private FoldingManager _foldingManager;
    private object _foldingStrategy;

    private void UpdateFoldings()
    {
      throw new NotImplementedException();

      //if (_foldingStrategy is BraceFoldingStrategy)
      //{
      //  ((BraceFoldingStrategy)_foldingStrategy).UpdateFoldings(_foldingManager, this.Editor.Document);
      //}

      //if (_foldingStrategy is XmlFoldingStrategy)
      //{
      //  ((XmlFoldingStrategy)_foldingStrategy).UpdateFoldings(_foldingManager, this.Editor.Document);
      //}
    }

    private void Editor_TextArea_TextEntering(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
      //throw new NotImplementedException();
    }

    private void Editor_TextArea_TextEntered(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
      //throw new NotImplementedException();
    }

    #endregion Events
  }
}
