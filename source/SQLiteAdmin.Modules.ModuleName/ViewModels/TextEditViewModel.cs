using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using Xeno.SQLiteAdmin.Core.Events;
using Xeno.SQLiteAdmin.Core.Mvvm;
using Xeno.SQLiteAdmin.Services.Interfaces;

namespace Xeno.SQLiteAdmin.Modules.TextEditorModule.ViewModels
{
  public class TextEditViewModel : RegionViewModelBase
  {
    private IDatabaseService _dbService;
    private IDialogService _dialogService;

    private TextDocument _editorDocument;
    private string _editorFile;
    private string _editorFontFamily;
    private string _editorFontSize;
    private bool _editorIsDirty;
    private bool _editorIsReadOnly;
    private int _editorSelectionLength;
    private int _editorSelectionStart;
    private IHighlightingDefinition _editorSyntaxType;
    private string _editorText;
    private bool _editorWordWrap;
    //// private string _editorSelectedText;

    private IEventAggregator _eventAggregator;
    private IRegionManager _regionManager;

    private string _titleBase = "SQLite Admin - Empty";
    private string _titleDisplayed = "SQLite Admin - Empty";

    public TextEditViewModel(IRegionManager regionManager, IMessageService messageService, IEventAggregator eventAggregator, IDatabaseService dbService) :
      base(regionManager)
    {
      _dbService = dbService;
      _eventAggregator = eventAggregator;

      Text = messageService.GetMessage();

      //// EditorDocument = new TextDocument();
      EditorIsReadOnly = false;
      EditorIsDirty = false;
      EditorFontFamily = "Consolas";
      EditorFontSize = "12px";

      var syntaxDef = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("TSQL");
      EditorSyntaxType = syntaxDef;

      _eventAggregator.GetEvent<SqlExecuteEvent>().Subscribe(OnExecute);

      ////_eventAggregator.GetEvent<SqlExecuteEvent>().Subscribe(
      ////  OnExecute,
      ////  ThreadOption.PublisherThread,
      ////  false,
      ////  (filter) => filter.Contains("THIS-TAB-REFERENCE"));
    }

    ////public string EditorFile
    ////{
    ////  get => _editorFile;
    ////  set
    ////  {
    ////    if (!SetProperty(ref _editorFile, value))
    ////      return;
    ////
    ////    if (!File.Exists(_editorFile))
    ////    {
    ////      // Display file doesn't exist warning
    ////      return;
    ////    }
    ////
    ////    EditorIsDirty = false;
    ////  }
    ////}

    // Used when defined by the constructor
    // public DelegateCommand ShowDialogCommand { get; private set; }
    public string EditorFontFamily
    {
      get => _editorFontFamily;
      set => SetProperty(ref _editorFontFamily, value);
    }

    public string EditorFontSize
    {
      get => _editorFontSize;
      set => SetProperty(ref _editorFontSize, value);
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
          RaisePropertyChanged(nameof(Title));
        }
      }
    }

    public bool EditorIsReadOnly
    {
      get => _editorIsReadOnly;
      set => SetProperty(ref _editorIsReadOnly, value);
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
      set => SetProperty(ref _editorSelectionLength, value);
    }

    public int EditorSelectionStart
    {
      get => _editorSelectionStart;
      set => SetProperty(ref _editorSelectionStart, value);
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
      set => SetProperty(ref _editorSyntaxType, value);
    }

    public string EditorText
    {
      get => _editorText;
      set => SetProperty(ref _editorText, value);
    }

    public bool EditorWordWrap
    {
      get => _editorWordWrap;
      set => SetProperty(ref _editorWordWrap, value);
    }

    public string Text
    {
      get => _editorText;
      set => SetProperty(ref _editorText, value);
    }

    public string Title
    {
      get => _titleDisplayed;
      set
      {
        SetProperty(ref _titleDisplayed, value);
        ////_titleBase = value;
        ////var title = _titleBase + (EditorIsDirty ? "*" : string.Empty);
        ////SetProperty(ref _titleDisplayed, title);
      }
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
      // do something
    }

    private void OnExecute(string misc)
    {
      var text = EditorSelectionLength > 0 ? EditorSelectedText : EditorText;

      System.Diagnostics.Debug.WriteLine($"Exec - SelectedText: '{EditorSelectedText}'");
      System.Diagnostics.Debug.WriteLine($"Exec - Text: '{EditorText}'");
      System.Diagnostics.Debug.WriteLine($"Exec Query: '{text}'");

      /*
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
      */
    }
  }
}
