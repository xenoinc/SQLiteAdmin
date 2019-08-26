/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    App.xaml.cs
 * Description:
 *
 */

using System.Windows;
using Prism.Ioc;
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
    }
  }
}
