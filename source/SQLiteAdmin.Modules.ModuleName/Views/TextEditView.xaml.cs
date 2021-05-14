using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Xeno.SQLiteAdmin.Modules.TextEditorModule.Views
{
  /// <summary>
  /// Interaction logic for ViewA.xaml
  /// </summary>
  public partial class TextEditView : UserControl
  {
    public TextEditView()
    {
      try
      {
        InitializeComponent();
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }

      AvalonTextEditor.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(AvalonTextEditor_PreviewMouseWheel);
    }

    /// <summary>Resize the editor's font size.</summary>
    /// <param name="increase">Increase or decrease</param>
    public void UpdateFontSize(bool increase)
    {
      const double FONT_MAX_SIZE = 60d;
      const double FONT_MIN_SIZE = 5d;

      double currentSize = AvalonTextEditor.FontSize;

      if (increase && currentSize < FONT_MAX_SIZE)
      {
        double newSize = Math.Min(FONT_MAX_SIZE, currentSize + 1);
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
        this.UpdateFontSize(e.Delta > 0);
        e.Handled = true;
      }
    }

    private void AvalonTextEditor_Unloaded(object sender, RoutedEventArgs e)
    {
      AvalonTextEditor.PreviewMouseWheel -= new System.Windows.Input.MouseWheelEventHandler(AvalonTextEditor_PreviewMouseWheel);
    }
  }
}
