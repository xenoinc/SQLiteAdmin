/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-26
 * Author:  Damian Suess
 * File:    CustomDialogWindow.xaml.cs
 * Description:
 *
 */

using System.Windows;
using Prism.Services.Dialogs;

namespace Xeno.SQLiteAdmin.Dialogs
{
  /// <summary>Interaction logic for CustomDialogWindow.xaml</summary>
  public partial class CustomDialogWindow : Window, IDialogWindow
  {
    public CustomDialogWindow()
    {
      InitializeComponent();
    }

    public IDialogResult Result { get; set; }
  }
}
