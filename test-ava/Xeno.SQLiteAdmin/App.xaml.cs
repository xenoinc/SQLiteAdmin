/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    App.xaml.cs
 * Description:
 *
 */

using Avalonia;
using Avalonia.Markup.Xaml;

namespace Xeno.SQLiteAdmin
{
  public class App : Application
  {
    public override void Initialize()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
