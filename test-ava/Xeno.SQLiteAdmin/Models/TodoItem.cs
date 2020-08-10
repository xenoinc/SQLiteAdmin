/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    TodoItem.cs
 * Description:
 *
 */

namespace Xeno.SQLiteAdmin.Models
{
  public class TodoItem
  {
    public string Description { get; set; }

    public bool IsChecked { get; set; }
  }
}
