﻿/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    MainWindowViewModel.cs
 * Description:
 *  Main window with editor (on first pass)
 *
 * Resources:
 *  -> https://stackoverflow.com/questions/18964176/two-way-binding-to-avalonedit-document-text-using-mvvm
 *  -> https://stackoverflow.com/questions/12344367/making-avalonedit-mvvm-compatible/41482439
 *  -> https://stackoverflow.com/questions/21911439/mvvm-binding-with-avalonedit-selectionstart-selectionlength
 *  - https://code-examples.net/en/q/1215ed0
 *  - https://code-examples.net/en/q/bc5c2f
 */

using System.IO;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Xeno.SQLiteAdmin.Services;

namespace Xeno.SQLiteAdmin.ViewModels
{
  public class MainWindowViewModel : BindableBase
  {
    private IDatabaseService _dbService;
    private IDialogService _dialogService;
    private TextDocument _editorDocument;
    private string _editorFile;
    private string _editorFontFamily;
    private string _editorFontSize;
    private bool _editorIsDirty;
    private bool _editorIsReadOnly;
    // private string _editorSelectedText;
    private int _editorSelectionLength;
    private int _editorSelectionStart;
    private IHighlightingDefinition _editorSyntaxType;

    private string _editorText;
    private bool _editorWordWrap;
    private IRegionManager _regionManager;
    private string _titleBase = "SQLite Admin - Empty";
    private string _titleDisplayed = "SQLite Admin - Empty";

    public MainWindowViewModel(IDialogService dialogService, IRegionManager regionManager, IDatabaseService dbService)
    {
      _dialogService = dialogService;
      _regionManager = regionManager;
      _dbService = dbService;

      InitAvalonEdit();

      // ShowDialogCommand = new DelegateCommand(OnShowDialog);

      EditorText = "select * from sqlite_master";
    }

    public TextDocument EditorDocument
    {
      get => _editorDocument;
      set
      {
        if (_editorDocument != value)
        {
          _editorDocument = value;
          RaisePropertyChanged();
        }
      }
    }

    public string EditorFile
    {
      get => _editorFile;
      set
      {
        if (_editorFile == value)
          return;

        if (!File.Exists(_editorFile))
        {
          // Display file doesn't exist warning
          return;
        }

        _editorFile = value;
        EditorIsDirty = false;
        // editor.Document = _editorFile;

        RaisePropertyChanged();
      }
    }

    // Used when defined by the constructor
    // public DelegateCommand ShowDialogCommand { get; private set; }
    public string EditorFontFamily
    {
      get => _editorFontFamily;
      set
      {
        if (_editorFontFamily != value)
        {
          _editorFontFamily = value;
          RaisePropertyChanged();
        }
      }
    }

    public string EditorFontSize
    {
      get => _editorFontSize;
      set
      {
        if (_editorFontSize != value)
        {
          _editorFontSize = value;
          RaisePropertyChanged();
        }
      }
    }

    public bool EditorIsDirty
    {
      get => _editorIsDirty;
      set
      {
        if (_editorIsDirty != value)
        {
          _editorIsDirty = value;
          RaisePropertyChanged();
          RaisePropertyChanged(Title);
        }
      }
    }

    public bool EditorIsReadOnly
    {
      get => _editorIsReadOnly;
      set
      {
        if (_editorIsReadOnly != value)
        {
          _editorIsReadOnly = value;
          RaisePropertyChanged();
        }
      }
    }

    public string EditorSelectedText
    {
      get
      {
        if (EditorSelectionStart < 0)
        {
          System.Diagnostics.Debug.WriteLine("Editor SelectionStart less than 0");

          return string.Empty;
        }

        if (EditorSelectionLength <= 0)
        {
          System.Diagnostics.Debug.WriteLine("Editor selection length is 0");
          return string.Empty;
        }

        if (EditorSelectionLength > EditorText.Length)
        {
          System.Diagnostics.Debug.WriteLine("Editor selection is greater than text length?!");
          return string.Empty;
        }

        int start = EditorSelectionStart;
        int len = EditorSelectionLength;

        return EditorText.Substring(EditorSelectionStart, EditorSelectionLength);
      }

      //get => _editorSelectedText;
      //set
      //{
      //  if (_editorSelectedText != value)
      //  {
      //    _editorSelectedText = value;
      //    RaisePropertyChanged();
      //  }
      //}
    }

    public int EditorSelectionLength
    {
      get => _editorSelectionLength;
      set
      {
        if (_editorSelectionLength != value)
        {
          _editorSelectionLength = value;
          RaisePropertyChanged();
        }
      }
    }

    public int EditorSelectionStart
    {
      get => _editorSelectionStart;
      set
      {
        if (_editorSelectionStart != value)
        {
          _editorSelectionStart = value;
          RaisePropertyChanged();
        }
      }
    }

    /// <summary>
    ///   AvalonEdit exposes a Highlighting property that controls whether keywords,
    ///   comments and other interesting text parts are colored or highlighted in any
    ///   other visual way. This property exposes the highlighting information for the
    ///   text file managed in this ViewModel class.
    /// </summary>
    public IHighlightingDefinition EditorSyntaxType
    {
      get => _editorSyntaxType;
      set
      {
        if (_editorSyntaxType != value)
        {
          _editorSyntaxType = value;
          RaisePropertyChanged();
        }
      }
    }

    public string EditorText
    {
      get => _editorText;
      set
      {
        if (_editorText != value)
        {
          _editorText = value;
          RaisePropertyChanged();
        }
      }
    }

    public bool EditorWordWrap
    {
      get => _editorWordWrap;
      set
      {
        if (_editorWordWrap == value)
          return;

        _editorWordWrap = value;
        RaisePropertyChanged();
      }
    }

    public DelegateCommand ExecuteCodeCommand => new DelegateCommand(OnExecuteCode);

    public DelegateCommand<string> NavigateCommand => new DelegateCommand<string>(OnNavigate);

    public DelegateCommand ShowDialogCommand => new DelegateCommand(OnShowDialog);

    public string Title
    {
      get => _titleDisplayed;
      set
      {
        _titleBase = value;
        _titleDisplayed = _titleBase + (EditorIsDirty ? "*" : string.Empty);

        RaisePropertyChanged();
      }
    }

    private void InitAvalonEdit()
    {
      // Set the default syntax highlighting to TSQL
      var syntaxDef = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("TSQL");

      EditorDocument = new TextDocument();
      EditorIsReadOnly = false;
      EditorIsDirty = false;
      EditorFontFamily = "Consolas";
      EditorFontSize = "12px";
      EditorSyntaxType = syntaxDef;
    }

    private void OnExecuteCode()
    {
      var text = EditorSelectionLength > 0 ? EditorSelectedText : EditorText;

      System.Diagnostics.Debug.WriteLine($"Exec - SelectedText: '{EditorSelectedText}'");
      System.Diagnostics.Debug.WriteLine($"Exec - Text: '{EditorText}'");
      System.Diagnostics.Debug.WriteLine($"Exec Query: '{text}'");

      // _dbService.ExecuteNonQuery(text);

      var ds = _dbService.ExecuteQuery(text);
      if (ds != null)
      {
        var t = ds.Tables;
        var count = t.Count;

        Log("Row Count: " + count);

        if (count == 0)
          return;

        Log(t[0].ToString());

        foreach (System.Data.DataColumn dc in ds.Tables[0].Columns)
        {
          Log("Column: " + dc.ColumnName);
        }

        foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
        {
          Log("Row[0]: " + dr[0].ToString());

          for (int i = 1; i < dr.ItemArray.Length; i++)
          {
            Log($"Row[{i}]: {dr[i].ToString()}");
          }

          //// Assign alternating backcolor
          //if (iCounter % 2 == 0)
          //{
          //  SqlResultsListView.Items[iCounter].BackColor = Color.AliceBlue;
          //}
          //
          //iCounter++
        }
      }
    }

    private void Log(string x)
    {
      System.Diagnostics.Debug.WriteLine(x);
    }

    /// <summary>Navigate to a module</summary>
    /// <param name="navPath">Navigation path</param>
    private void OnNavigate(string navPath)
    {
      if (!string.IsNullOrEmpty(navPath))
        _regionManager.RequestNavigate("ContentRegion", navPath);
    }

    private void OnShowDialog()
    {
      var message = "This is a message that should be shown in the dialog.";

      // NOTE: This uses our class extension for Prism's Dialog Service
      _dialogService.ShowConfirmation(message, r =>
      {
        if (r.Result == ButtonResult.None)
          Title = "Result is None";
        else if (r.Result == ButtonResult.OK)
          Title = "Result is OK";
        else if (r.Result == ButtonResult.Cancel)
          Title = "Result is Cancel";
        else
          Title = "I don't know what you did!?";
      });
    }
  }
}
