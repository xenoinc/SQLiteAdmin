/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-8
 * File:    IDatabase.cs
 * Description:
 *  Interface for all database providers so we can
 *  have a uniform command set
 *
 * Change Log:
 *  2017-0308 * Initial creation
 */

using System.Data;

namespace Xeno.SQLiteAdmin.Data
{
  public interface IDatabaseProvider
  {
    DatabaseProvider ProviderType { get; }

    string ConnectionString { get; set; }

    void Close();

    int ExecuteNonQuery(string query);

    DataSet ExecuteQuery(string query);
  }
}
