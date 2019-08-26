/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    TodoService.cs
 * Description:
 *  ToDo List Service
 */

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xeno.SQLiteAdmin.Models;

namespace Xeno.SQLiteAdmin.Services
{
  public class TodoService
  {
    public ObservableCollection<TodoItem> Items { get; }

    public IEnumerable<TodoItem> GetItems() => new[]
        {
      new TodoItem { Description = "Walk the dog" },
      new TodoItem { Description = "Buy some milk" },
      new TodoItem { Description = "Learn Avalonia", IsChecked = true
    }};
  }
}
