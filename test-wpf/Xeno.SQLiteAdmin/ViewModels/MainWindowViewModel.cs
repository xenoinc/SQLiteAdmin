/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    MainWindowViewModel.cs
 * Description:
 *
 */

using System.IO;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Xeno.SQLiteAdmin.Services;

namespace Xeno.SQLiteAdmin.ViewModels
{
  public class MainWindowViewModel : BindableBase
  {
    private IDialogService _dialogService;
    private string _editorFile;
    private IRegionManager _regionManager;
    private string _title = "Prism Application";

    public MainWindowViewModel(IDialogService dialogService, IRegionManager regionManager)
    {
      _dialogService = dialogService;
      _regionManager = regionManager;

      // ShowDialogCommand = new DelegateCommand(OnShowDialog);
    }

    // Used when defined by the constructor
    // public DelegateCommand ShowDialogCommand { get; private set; }

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
        // editor.IsDirty = false;
        // editor.Document = _editorFile;

        RaisePropertyChanged();
      }
    }

    public DelegateCommand<string> NavigateCommand => new DelegateCommand<string>(OnNavigate);
    public DelegateCommand ShowDialogCommand => new DelegateCommand(OnShowDialog);

    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
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
