/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    TodoListViewModel.cs
 * Description:
 *
 */

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xeno.SQLiteAdmin.Models;

namespace Xeno.SQLiteAdmin.ViewModels
{
  public class TodoListViewModel : ViewModelBase
  {
    public TodoListViewModel()
    {
      Items = new ObservableCollection<TodoItem>();
    }

    public TodoListViewModel(IEnumerable<TodoItem> items)
    {
      Items = new ObservableCollection<TodoItem>(items);
    }

    public ObservableCollection<TodoItem> Items { get; }
  }
}
