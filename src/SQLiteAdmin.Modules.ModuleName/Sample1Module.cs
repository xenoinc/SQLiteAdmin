using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Xeno.SQLiteAdmin.Core;
using Xeno.SQLiteAdmin.Modules.Sample1.Views;

namespace Xeno.SQLiteAdmin.Modules.Sample1
{
  public class Sample1Module : IModule
  {
    private readonly IRegionManager _regionManager;

    public Sample1Module(IRegionManager regionManager)
    {
      _regionManager = regionManager;
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      _regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewA");
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterForNavigation<ViewA>();
    }
  }
}