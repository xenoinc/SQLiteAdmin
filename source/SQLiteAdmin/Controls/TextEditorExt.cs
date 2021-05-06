using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;

namespace Xeno.SQLiteAdmin.Controls
{
  public class TextEditorExt : TextEditor, INotifyPropertyChanged
  {
    public static DependencyProperty CaretOffsetProperty =
         DependencyProperty.Register(nameof(CaretOffset), typeof(int), typeof(TextEditorExt),
         // binding changed callback: set value of underlying property
         new PropertyMetadata((obj, args) =>
         {
           TextEditorExt target = (TextEditorExt)obj;
           target.CaretOffset = (int)args.NewValue;
         }));

    public TextEditorExt()
    {
      FontSize = 12;
      FontFamily = new FontFamily("Consolas");
      Options = new TextEditorOptions {
        IndentationSize = 3,
        ConvertTabsToSpaces = true
      };
    }

    /// <summary>
    /// Implement the INotifyPropertyChanged event handler.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    public new int CaretOffset
    {
      get => base.CaretOffset;
      set => base.CaretOffset = value;
    }

    public int Length => base.Text.Length;

    //public void RaisePropertyChanged(string info)
    //{
    //  if (PropertyChanged != null)
    //  {
    //    PropertyChanged(this, new PropertyChangedEventArgs(info));
    //  }
    //}

    protected override void OnTextChanged(EventArgs e)
    {
      RaisePropertyChanged(nameof(Length));
      base.OnTextChanged(e);
    }

    #region 1896

    /// <summary>Dependency property for the editor text property binding.</summary>
    public static readonly DependencyProperty TextProperty =
      DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextEditorExt),
      new PropertyMetadata((obj, args) =>
      {
        TextEditorExt target = (TextEditorExt)obj;
        target.Text = (string)args.NewValue;
      }));

    private static bool _canScroll = true;

    /// <summary>Provide access to the Text.</summary>
    public new string Text
    {
      get { return base.Text; }
      set { base.Text = value; }
    }

    /// <summary>
    /// Event that handles when the caret changes.
    /// </summary>
    private void TextArea_CaretPositionChanged(object sender, EventArgs e)
    {
      try
      {
        _canScroll = false;
        this.TextLocation = TextLocation;
      }
      finally
      {
        _canScroll = true;
      }
    }

    /// <summary>Event handler to update properties based upon the selection changed event.</summary>
    private void TextArea_SelectionChanged(object sender, EventArgs e)
    {
      this.SelectionStart = SelectionStart;
      this.SelectionLength = SelectionLength;
    }

    #endregion 1896

    ///// <summary>
    ///// DependencyProperty for the TextEditorCaretOffset binding.
    ///// </summary>
    //public static DependencyProperty CaretOffsetProperty =
    //    DependencyProperty.Register("CaretOffset", typeof(int), typeof(TextEditorEx),
    //    new PropertyMetadata((obj, args) =>
    //    {
    //      TextEditorEx target = (TextEditorEx)obj;
    //      if (target.CaretOffset != (int)args.NewValue)
    //        target.CaretOffset = (int)args.NewValue;
    //    }));
    //
    ///// <summary>
    ///// Access to the SelectionStart property.
    ///// </summary>
    //public new int CaretOffset
    //{
    //  get { return base.CaretOffset; }
    //  set { SetValue(CaretOffsetProperty, value); }
    //}

    #region Selection.

    /// <summary>DependencyProperty for the TextEditor SelectedText property.</summary>
    public static readonly DependencyProperty SelectedTextProperty =
      DependencyProperty.Register(nameof(SelectedText), typeof(string), typeof(TextEditorExt),
        new PropertyMetadata((obj, args) =>
        {
          TextEditorExt target = (TextEditorExt)obj;
          target.SelectedText = (string)args.NewValue;
        }));

    /// <summary>
    /// DependencyProperty for the TextEditor SelectionLength property.
    /// </summary>
    public static readonly DependencyProperty SelectionLengthProperty =
      DependencyProperty.Register(nameof(SelectionLength), typeof(int), typeof(TextEditorExt),
        new PropertyMetadata((obj, args) =>
        {
          TextEditorExt target = (TextEditorExt)obj;
          if (target.SelectionLength != (int)args.NewValue)
          {
            target.SelectionLength = (int)args.NewValue;
            target.Select(target.SelectionStart, (int)args.NewValue);
          }
        }));

    /// <summary>
    /// DependencyProperty for the TextEditor SelectionStart property.
    /// </summary>
    public static readonly DependencyProperty SelectionStartProperty =
      DependencyProperty.Register(nameof(SelectionStart), typeof(int), typeof(TextEditorExt),
      new PropertyMetadata((obj, args) =>
      {
        TextEditorExt target = (TextEditorExt)obj;
        if (target.SelectionStart != (int)args.NewValue)
        {
          target.SelectionStart = (int)args.NewValue;
          target.Select((int)args.NewValue, target.SelectionLength);
        }
      }));

    /// <summary>
    /// DependencyProperty for the TextLocation. Setting this value
    /// will scroll the TextEditor to the desired TextLocation.
    /// </summary>
    public static readonly DependencyProperty TextLocationProperty =
      DependencyProperty.Register(nameof(TextLocation), typeof(TextLocation), typeof(TextEditorExt),
        new PropertyMetadata((obj, args) =>
        {
          TextEditorExt target = (TextEditorExt)obj;
          TextLocation loc = (TextLocation)args.NewValue;
          if (_canScroll)
            target.ScrollTo(loc.Line, loc.Column);
        }));

    /// <summary>Access to the SelectedText property.</summary>
    public new string SelectedText
    {
      get => base.SelectedText;
      set => SetValue(SelectedTextProperty, value);
    }

    /// <summary>
    /// Access to the SelectionLength property.
    /// </summary>
    public new int SelectionLength
    {
      get => base.SelectionLength;
      set => SetValue(SelectionLengthProperty, value);
    }

    /// <summary>
    /// Access to the SelectionStart property.
    /// </summary>
    public new int SelectionStart
    {
      get => base.SelectionStart;
      set => SetValue(SelectionStartProperty, value);
    }

    /// <summary>
    /// Get or set the TextLocation. Setting will scroll to that location.
    /// </summary>
    public TextLocation TextLocation
    {
      get => base.Document.GetLocation(SelectionStart);
      set => SetValue(TextLocationProperty, value);
    }

    #endregion Selection.

    #region Properties.

    ///// <summary>
    ///// The currently loaded file name. This is bound to the ViewModel
    ///// consuming the editor control.
    ///// </summary>
    //public string FilePath
    //{
    //  get { return (string)GetValue(FilePathProperty); }
    //  set { SetValue(FilePathProperty, value); }
    //}
    //
    //// Using a DependencyProperty as the backing store for FilePath.
    //// This enables animation, styling, binding, etc...
    //public static readonly DependencyProperty FilePathProperty =
    //     DependencyProperty.Register("FilePath", typeof(string), typeof(TextEditorEx),
    //     new PropertyMetadata(String.Empty, OnFilePathChanged));

    #endregion Properties.

    #region Raise Property Changed.

    ///// <summary>
    ///// Implement the INotifyPropertyChanged event handler.
    ///// </summary>
    //public event PropertyChangedEventHandler PropertyChanged;

    public void RaisePropertyChanged([CallerMemberName] string caller = null)
    {
      var handler = PropertyChanged;
      if (handler != null)
        PropertyChanged(this, new PropertyChangedEventArgs(caller));
    }

    #endregion Raise Property Changed.
  }
}
