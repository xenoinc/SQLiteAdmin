/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-28
 * Author:  Damian Suess
 * File:    ViewAViewModel.cs
 * Description:
 *
 */

using Prism.Mvvm;

namespace Xeno.SQLiteAdmin.EditorModule.ViewModels
{
  public class ViewAViewModel : BindableBase
  {
    private string _message;

    public ViewAViewModel()
    {
      Message = "View A from your Prism Module";
    }

    public string Message
    {
      get { return _message; }
      set { SetProperty(ref _message, value); }
    }
  }
}
