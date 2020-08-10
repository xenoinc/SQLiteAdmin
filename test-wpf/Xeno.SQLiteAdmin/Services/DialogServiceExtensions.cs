/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    DialogServiceExtensions.cs
 * Description:
 *  Class extension for Prism.Services.Dialogs's IDialogService
 */

using System;
using Prism.Services.Dialogs;

namespace Xeno.SQLiteAdmin.Services
{
  public static class DialogServiceExtensions
  {
    public static void ShowConfirmation(this IDialogService dialogService, string message, Action<IDialogResult> callBack)
    {
      dialogService.ShowDialog("ConfirmationDialog", new DialogParameters($"message={message}"), callBack);
    }

    public static void ShowNotification(this IDialogService dialogService, string message, Action<IDialogResult> callBack)
    {
      dialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), callBack);
    }
  }
}
