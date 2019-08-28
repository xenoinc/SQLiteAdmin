/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    TodoAddViewModel.cs
 * Description:
 *
 */

using System.Reactive;
using ReactiveUI;
using Xeno.SQLiteAdmin.Models;

namespace Xeno.SQLiteAdmin.ViewModels
{
  public class TodoAddViewModel : ViewModelBase
  {
    private string _description;

    public TodoAddViewModel()
    {
      var okEnabled = this.WhenAnyValue(
        x => x.Description,
        x => !string.IsNullOrWhiteSpace(x));

      Ok = ReactiveCommand.Create(
        () => new TodoItem { Description = Description },
        okEnabled);

      Cancel = ReactiveCommand.Create(() => { });
    }

    public ReactiveCommand<Unit, Unit> Cancel { get; }

    public string Description { get; set; }

    public ReactiveCommand<Unit, TodoItem> Ok { get; }
  }
}
