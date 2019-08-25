/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    MainWindowViewModel.cs
 * Description:
 *
 */

using Xeno.SQLiteAdmin.Services;

namespace Xeno.SQLiteAdmin.ViewModels
{
  public class MainWindowViewModel : ViewModelBase
  {
    public MainWindowViewModel(TodoService todoService)
    {
      TodoList = new TodoListViewModel(todoService.GetItems());
    }

    public MainWindowViewModel()
    {
      TodoList = new TodoListViewModel();
    }

    public string Greeting => "Welcome to Avalonia!";
    public TodoListViewModel TodoList { get; }
  }
}
