/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-11-7
 * File:    PropertyType.cs
 * Description:
 *  Database properties for connection strings
 *  and other provider settings
 *
 * References:
 *  SQLite - https://www.connectionstrings.com/sqlite/
 *
 * Change Log:
 *  2017-117 * Initial creation
 */

namespace Xeno.SQLiteAdmin.Data.Provider
{
  public enum DatabaseProperty
  {
    SqliteDatabase,
    SqlitePassword,
    SqliteVersion
  }
}
