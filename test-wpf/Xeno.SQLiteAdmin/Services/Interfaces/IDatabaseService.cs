/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-28
 * Author:  Damian Suess
 * File:    IDatabaseService.cs
 * Description:
 *  Database Service Interface
 */

using System.Data;
using Xeno.SQLiteAdmin.Engines;

namespace Xeno.SQLiteAdmin.Services
{
  public interface IDatabaseService
  {
    /// <summary>Connection string</summary>
    string ConnectionString { get; set; }

    /// <summary>Installed database engine (TBD)</summary>
    ISqlEngine DatabaseEngine { get; set; }

    int ExecuteNonQuery(string query);

    DataSet ExecuteQuery(string query);
  }
}
