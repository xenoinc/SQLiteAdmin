/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    MainWindowViewModel.cs
 * Description:
 *
 */

using System;
using System.Reactive.Linq;
using Xeno.SQLiteAdmin.Models;
using Xeno.SQLiteAdmin.Services;
using ReactiveUI;

namespace Xeno.SQLiteAdmin.ViewModels
{
  public class MainWindowViewModel : ViewModelBase
  {
    private ViewModelBase _content;

    public MainWindowViewModel(TodoService todoService)
    {
      Content = TodoList = new TodoListViewModel(todoService.GetItems());
    }

    public MainWindowViewModel()
    {
      TodoList = new TodoListViewModel();
    }

    public ViewModelBase Content
    {
      get => _content;
      private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public TodoListViewModel TodoList { get; }

    public void AddItem()
    {
      var vm = new TodoAddViewModel();

      Observable.Merge(
        vm.Ok,
        vm.Cancel.Select(_ => (TodoItem)null))
        .Take(1)
        .Subscribe(model =>
        {
          if (model != null)
            TodoList.Items.Add(model);

          Content = TodoList;
        });

      Content = vm;
    }
  }
}
