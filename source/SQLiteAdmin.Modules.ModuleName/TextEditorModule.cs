using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Xeno.SQLiteAdmin.Core;
using Xeno.SQLiteAdmin.Modules.TextEditorModule.Views;

namespace Xeno.SQLiteAdmin.Modules.Sample1
{
  public class TextEditorModule : IModule
  {
    private readonly IRegionManager _regionManager;
    private readonly IEventAggregator _eventAggregator;

    public TextEditorModule(IRegionManager regionManager, IEventAggregator eventAggregator)
    {
      _regionManager = regionManager;
      _eventAggregator = eventAggregator;
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(TextEditView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterForNavigation<TextEditView>();
    }
  }
}