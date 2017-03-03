/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-2
 * File:    SyntaxEditor.cs
 * Description:
 *  WinForms wrapper for AvalonEdit
 *
 * References:
 *  https://github.com/icsharpcode/AvalonEdit/blob/master/ICSharpCode.AvalonEdit.Sample/Window1.xaml.cs
 * Change Log:
 *  2017-32 * Initial creation
 */

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;

namespace Xeno.SQLiteAdmin.Control
{
  public partial class SyntaxEditor : UserControl
  {
    #region Constructor
    private TextEditor _editor;

    /// <summary>Creates a new TextEditor instance</summary>
    public SyntaxEditor()
    {
      InitializeComponent();

      InitEditor();

      elementHost1.Child = _editor;
    }

    public void InitEditor()
    {
      _editor = new ICSharpCode.AvalonEdit.TextEditor();
      //IHighlightingDefinition sqlHighlight;

      _editor.TextArea.TextEntering += Editor_TextArea_TextEntering;
      _editor.TextArea.TextEntered += Editor_TextArea_TextEntered;

      _editor.Text = "Sample AvalonEdit text";
      _editor.ShowLineNumbers = true;

      //DispatcherTimer foldingUpdateTimer = new DispatcherTimer();
      //foldingUpdateTimer.Interval = TimeSpan.FromSeconds(2);
      //foldingUpdateTimer.Tick += delegate { UpdateFoldings(); };
      //foldingUpdateTimer.Start();
    }

    #endregion Constructor

    #region Properties
    
    /// <summary>Specifies whether line numbers are shown on the left to the text view.</summary>
    public bool ShowLineNumbers
    {
      get { return _editor.ShowLineNumbers; }
      set
      {
        _editor.ShowLineNumbers = value;
        elementHost1.Refresh();
      }
    }

    /// <summary>Gets/Sets the text of the current document</summary>
    [DefaultValue("")]
    [Localizability(LocalizationCategory.Text)]
    public override string Text
    {
      get { return _editor.Text; }
      set
      {
        _editor.Text = value;
        elementHost1.Refresh();
      }
    }

    /// <summary>Gets/sets the syntax highlighting definition used to colorize the text.</summary>
    public IHighlightingDefinition SyntaxHighlighting
    {
      get { return _editor.SyntaxHighlighting; }
      set { _editor.SyntaxHighlighting = value; }
    }

    #endregion Properties

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