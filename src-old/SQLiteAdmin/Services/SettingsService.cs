/* Copyright Xeno Innovations, Inc. 2011-2019
 * Author:  Damian Suess
 * Date:    2019-4-10
 * File:    SettingsService.cs
 * Description:
 *
 * Change Log:
 *  2019-410 * Initial creation
 */

using System.Data.SQLite;

namespace Xeno.SQLiteAdmin.Services
{
  public class SettingsService : ISettingsService
  {
    public void InitSettings()
    {
      string file = "Settings.sqlite";
      SQLiteConnection.CreateFile(file);

      SQLiteConnection conn = new SQLiteConnection($"Data Source={file};Version=3;");
      conn.Open();

      string sql = "CREATE TABLE Settings (Name VARCHAR(20), Data VARCHAR(255))";

      SQLiteCommand cmd = new SQLiteCommand(sql, conn);
      cmd.ExecuteNonQuery();

      sql = "INSERT INTO Settings (Name, Data) values ('Installed', 'Today')";

      cmd = new SQLiteCommand(sql, conn);
      cmd.ExecuteNonQuery();

      conn.Close();
    }
  }
}