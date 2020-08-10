/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    NotificationDialogViewModel.cs
 * Description:
 *  Notification dialog view model
 */

using Prism.Services.Dialogs;

namespace Xeno.SQLiteAdmin.Dialogs
{
  public class NotificationDialogViewModel : DialogViewModelBase
  {
    private string _message;

    public NotificationDialogViewModel()
    {
      Title = "Notification";
    }

    public string Message
    {
      get { return _message; }
      set { SetProperty(ref _message, value); }
    }

    public override void OnDialogOpened(IDialogParameters parameters)
    {
      Message = parameters.GetValue<string>("message");
    }
  }
}
