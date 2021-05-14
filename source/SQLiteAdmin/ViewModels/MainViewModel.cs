using System;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Xeno.SQLiteAdmin.Core.Events;

namespace Xeno.SQLiteAdmin.ViewModels
{
  public class MainViewModel : BindableBase
  {
    ////private IDatabaseService _dbService;
    private IDialogService _dialogService;

    private IEventAggregator _eventAggregator;
    private IRegionManager _regionManager;
    private string _titleBase = "SQLite Admin - Empty";
    private string _titleDisplayed = "SQLite Admin - Empty";

    public MainViewModel(IDialogService dialogService, IRegionManager regionManager, IEventAggregator eventAggregator)
    {
      _dialogService = dialogService;
      _regionManager = regionManager;
      _eventAggregator = eventAggregator;
    }

    public DelegateCommand CmdExecuteCode => new DelegateCommand(OnExecuteCode);

    public DelegateCommand<string> CmdNavigate => new DelegateCommand<string>(OnNavigate);

    public DelegateCommand CmdOpenFile => new DelegateCommand(OnFileOpen);

    public DelegateCommand CmdSaveFile => new DelegateCommand(OnFileSave);

    public DelegateCommand CmdShowDialog => new DelegateCommand(OnShowDialog);

    public string Title
    {
      get => _titleDisplayed;
      set => SetProperty(ref _titleDisplayed, _titleDisplayed);
    }

    private void Log(string x)
    {
      System.Diagnostics.Debug.WriteLine(x);
    }

    private void OnExecuteCode()
    {
      _eventAggregator.GetEvent<SqlExecuteEvent>().Publish("REFERENCE-TO-SELECTED-TAB");
    }

    private void OnFileOpen()
    {
      throw new NotImplementedException();
    }

    private void OnFileSave()
    {
      throw new NotImplementedException();
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
      //_dialogService.ShowConfirmation(message, r =>
      //{
      //  if (r.Result == ButtonResult.None)
      //    Title = "Result is None";
      //  else if (r.Result == ButtonResult.OK)
      //    Title = "Result is OK";
      //  else if (r.Result == ButtonResult.Cancel)
      //    Title = "Result is Cancel";
      //  else
      //    Title = "I don't know what you did!?";
      //});
    }
  }
}
