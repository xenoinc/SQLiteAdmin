/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    App.xaml.cs
 * Description:
 *  Application entry-point
 */

using System.Windows;
using Prism.Ioc;
using Xeno.SQLiteAdmin.Dialogs;
using Xeno.SQLiteAdmin.Views;

namespace Xeno.SQLiteAdmin
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App
  {
    protected override Window CreateShell()
    {
      return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
      containerRegistry.RegisterDialog<ConfirmationDialog, ConfirmationDialogViewModel>();

      //register a custom window host
      //containerRegistry.RegisterDialogWindow<CustomDialogWindow>();
    }
  }
}
