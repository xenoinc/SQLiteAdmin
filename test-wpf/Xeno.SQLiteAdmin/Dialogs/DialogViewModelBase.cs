/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    DialogViewModelBase.cs
 * Description:
 *  Base dialog view model
 */

using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Xeno.SQLiteAdmin.Dialogs
{
  public class DialogViewModelBase : BindableBase, IDialogAware
  {
    private DelegateCommand<string> _closeDialogCommand;

    private string _title;

    public event Action<IDialogResult> RequestClose;

    public DelegateCommand<string> CloseDialogCommand =>
              _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    public bool CanCloseDialog()
    {
      return true;
    }

    public virtual void OnDialogClosed()
    {
    }

    public virtual void OnDialogOpened(IDialogParameters parameters)
    {
    }

    protected virtual void CloseDialog(string parameter)
    {
      ButtonResult result = ButtonResult.None;

      if (parameter?.ToLower() == "true")
        result = ButtonResult.OK;
      else if (parameter?.ToLower() == "false")
        result = ButtonResult.Cancel;

      RequestClose?.Invoke(new DialogResult(result));
    }
  }
}
