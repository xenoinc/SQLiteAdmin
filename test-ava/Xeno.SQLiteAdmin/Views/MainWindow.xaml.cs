/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    MainWindow.xaml.cs
 * Description:
 *
 */

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Xeno.SQLiteAdmin.Views
{
  public class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
#if DEBUG
      this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}