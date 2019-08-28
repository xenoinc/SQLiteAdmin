/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    TodoListView.xaml.cs
 * Description:
 *
 */

using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Xeno.SQLiteAdmin.Views
{
  public class TodoListView : UserControl
  {
    public TodoListView()
    {
      this.InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}