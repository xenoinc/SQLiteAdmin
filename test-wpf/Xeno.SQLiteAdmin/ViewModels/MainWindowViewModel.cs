/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    MainWindowViewModel.cs
 * Description:
 *
 */

using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Xeno.SQLiteAdmin.Services;

namespace Xeno.SQLiteAdmin.ViewModels
{
  public class MainWindowViewModel : BindableBase
  {
    private IDialogService _dialogService;
    private string _title = "Prism Application";

    public MainWindowViewModel(IDialogService dialogService)
    {
      _dialogService = dialogService;

      // ShowDialogCommand = new DelegateCommand(OnShowDialog);
    }

    // Used when defined by the constructor
    // public DelegateCommand ShowDialogCommand { get; private set; }

    public DelegateCommand ShowDialogCommand => new DelegateCommand(OnShowDialog);

    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
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
