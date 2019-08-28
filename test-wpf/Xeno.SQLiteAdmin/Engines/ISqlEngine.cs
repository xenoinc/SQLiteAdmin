/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-28
 * Author:  Damian Suess
 * File:    ISqliteEngine.cs
 * Description:
 *  Each implementation of a SQL engine connection should use the same basic ISqlEngine interface
 *  which will be consumed by the DatabaseService link to our engine.
 *
 * NOTES:
 *  Though we plan on implementing for SQLite first, consider options for SQLCipher, SQL Server, MySQL, etc.
 *
 *  This interface links up to the Database Service to perform the basic tasks of:
 *    - Connection String
 *    - Host (file path)
 *    - Password (if using SQLCipher or other engine)
 *    - Connection Open/Close
 *    - int Execute (NonQuery such as INSERT, UPDATE, DELETE, PRAGMA)
 *    - DataSet ExecuteScalar (SELECT statement and perhaps returns a specified data types <T>?)
 */

using System.Data;

namespace Xeno.SQLiteAdmin.Engines
{
  public interface ISqlEngine
  {
    /// <summary>Connection string</summary>
    string ConnectionString { get; set; }

    // void Connect();
    // void Connect(string connectionString);
    // void Disconnect();

    int ExecuteNonQuery(string query);

    DataSet ExecuteQuery(string query);
  }
}
