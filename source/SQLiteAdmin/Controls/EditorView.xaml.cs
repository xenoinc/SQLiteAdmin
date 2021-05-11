﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit;

namespace Xeno.SQLiteAdmin.Controls
{
  /// <summary>
  /// Interaction logic for TextEditorExt2.xaml
  /// </summary>
  public partial class EditorView : UserControl
  {
    public EditorView()
    {
      InitializeComponent();
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
