/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-28
 * Author:  Damian Suess
 * File:    EditorModule.cs
 * Description:
 *  Custom module for container provider
 */

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Xeno.SQLiteAdmin.EditorModule.Views;

namespace Xeno.SQLiteAdmin.EditorModule
{
  public class EditorModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      // Uncomment when ready
      //
      //var regionManager = containerProvider.Resolve<IRegionManager>();
      //IRegion region = regionManager.Regions["ContentRegion"];
      //
      //// Add controls to container provider
      //var editor = containerProvider.Resolve<ViewA>();
      //region.Add(editor);
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
  }
}