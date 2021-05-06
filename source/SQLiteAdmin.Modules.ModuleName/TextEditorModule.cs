using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Xeno.SQLiteAdmin.Core;
using Xeno.SQLiteAdmin.Modules.Sample1.Views;

namespace Xeno.SQLiteAdmin.Modules.Sample1
{
  public class TextEditorModule : IModule
  {
    private readonly IRegionManager _regionManager;

    public TextEditorModule(IRegionManager regionManager)
    {
      _regionManager = regionManager;
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(ViewA));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterForNavigation<ViewA>();
    }
  }
}