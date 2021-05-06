using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Xeno.SQLiteAdmin.Modules.Sample1;
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
      moduleCatalog.AddModule<Sample1Module>();
    }

    protected override Window CreateShell()
    {
      return Container.Resolve<MainView>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterSingleton<IMessageService, MessageService>();
    }
  }
}
