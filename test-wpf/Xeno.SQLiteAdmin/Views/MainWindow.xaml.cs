/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    MainWindow.xaml.cs
 * Description:
 *
 */

using System.Windows;
using System.Windows.Input;

namespace Xeno.SQLiteAdmin.Views
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      AvalonTextEditor.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(AvalonTextEditor_PreviewMouseWheel);
    }

    private void AvalonTextEditor_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
      // 
      //
      //if (Keyboard.Modifiers == ModifierKeys.Control)
      //{
      //  double fontSize = this.FontSize + e.Delta / 25.0;
      //
      //  if (fontSize < 6)
      //    AvalonTextEditor.FontSize = 6;
      //  else
      //  {
      //    if (fontSize > 200)
      //      AvalonTextEditor.FontSize = 200;
      //    else
      //      this.FontSize = fontSize;
      //  }
      //
      //  e.Handled = true;
      //}
    }

    private void AvalonTextEditor_Unloaded(object sender, RoutedEventArgs e)
    {
      AvalonTextEditor.PreviewMouseWheel -= new System.Windows.Input.MouseWheelEventHandler(AvalonTextEditor_PreviewMouseWheel);
    }
  }
}
