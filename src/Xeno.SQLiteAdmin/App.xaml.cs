using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Xeno.SQLiteAdmin.Modules.ModuleName;
using Xeno.SQLiteAdmin.Services;
using Xeno.SQLiteAdmin.Services.Interfaces;
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
      moduleCatalog.AddModule<ModuleNameModule>();
    }

    protected override Window CreateShell()
    {
      return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterSingleton<IMessageService, MessageService>();
    }
  }
}
