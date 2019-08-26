/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    MainWindowViewModel.cs
 * Description:
 *
 */

using Prism.Mvvm;

namespace Xeno.SQLiteAdmin.ViewModels
{
  public class MainWindowViewModel : BindableBase
  {
    private string _title = "Prism Application";

    public MainWindowViewModel()
    {
    }

    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }
  }
}
