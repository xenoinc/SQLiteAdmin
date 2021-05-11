/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    MainWindow.xaml.cs
 * Description:
 *  Main Window View
 */

using System;
using System.Windows;
using System.Windows.Input;

namespace Xeno.SQLiteAdmin.Views
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainView : Window
  {
    public MainView()
    {
      InitializeComponent();

      //// AvalonTextEditor.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(AvalonTextEditor_PreviewMouseWheel);
    }

    /*
    /// <summary>Resize the editor's font size.</summary>
    /// <param name="increase">Increase or decrease</param>
    public void UpdateFontSize(bool increase)
    {
      const double FONT_MAX_SIZE = 60d;
      const double FONT_MIN_SIZE = 5d;

      var currentSize = AvalonTextEditor.FontSize;

      if (increase && currentSize < FONT_MAX_SIZE)
      {
        var newSize = Math.Min(FONT_MAX_SIZE, currentSize + 1);
        AvalonTextEditor.FontSize = newSize;
      }
      else if (currentSize > FONT_MIN_SIZE)
      {
        double newSize = Math.Max(FONT_MIN_SIZE, currentSize - 1);
        AvalonTextEditor.FontSize = newSize;
      }
    }

    private void AvalonTextEditor_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
      if (Keyboard.Modifiers == ModifierKeys.Control)
      {
        UpdateFontSize(e.Delta > 0);
        e.Handled = true;
      }
    }

    private void AvalonTextEditor_Unloaded(object sender, RoutedEventArgs e)
    {
      AvalonTextEditor.PreviewMouseWheel -= new System.Windows.Input.MouseWheelEventHandler(AvalonTextEditor_PreviewMouseWheel);
    }
    */
  }
}
