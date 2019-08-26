/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    ViewLocator.cs
 * Description:
 *
 */

using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Xeno.SQLiteAdmin.ViewModels;

namespace Xeno.SQLiteAdmin
{
  public class ViewLocator : IDataTemplate
  {
    public bool SupportsRecycling => false;

    public IControl Build(object data)
    {
      var name = data.GetType().FullName.Replace("ViewModel", "View");
      var type = Type.GetType(name);

      if (type != null)
      {
        return (Control)Activator.CreateInstance(type);
      }
      else
      {
        return new TextBlock { Text = "Not Found: " + name };
      }
    }

    public bool Match(object data)
    {
      return data is ViewModelBase;
    }
  }
}