/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    App.xaml.cs
 * Description:
 *  Application entry-point
 */

using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Xeno.SQLiteAdmin.Dialogs;
using Xeno.SQLiteAdmin.Services;
using Xeno.SQLiteAdmin.ViewModels;
using Xeno.SQLiteAdmin.Views;

namespace Xeno.SQLiteAdmin
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App
  {
    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
      moduleCatalog.AddModule<EditorModule.EditorModule>();
    }

    protected override Window CreateShell()
    {
      LoadTheme();

      return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Services
      // containerRegistry.RegisterSingleton<ILogService, LogService>();
      // containerRegistry.RegisterSingleton<IDatabaseService, DatabaseService>();
      containerRegistry.RegisterInstance<IDatabaseService>(new DatabaseService());

      // Views
      containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
      containerRegistry.RegisterDialog<ConfirmationDialog, ConfirmationDialogViewModel>();

      // Custom window host
      //containerRegistry.RegisterDialogWindow<CustomDialogWindow>();
    }

    private void LoadTheme()
    {
      // System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Xeno.SQLiteAdmin.HighlightThemes.DeepBlack")

      //using (var stream = new System.IO.MemoryStream(Xeno.SQLiteAdmin.HighlightThemes.DeepBlack))
      //{
      //  using (var reader = new System.Xml.XmlTextReader(stream))
      //  {
      //    ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.RegisterHighlighting("SQL", new string[0],
      //        ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(reader,
      //            ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance));
      //  }
      //}
    }
  }
}
