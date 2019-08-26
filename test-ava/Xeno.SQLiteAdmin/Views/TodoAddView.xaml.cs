/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    TodoAddView.xaml.cs
 * Description:
 *
 */

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Xeno.SQLiteAdmin.Views
{
  public class TodoAddView : UserControl
  {
    public TodoAddView()
    {
      this.InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
