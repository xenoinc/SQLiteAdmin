/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-28
 * Author:  Damian Suess
 * File:    SqliteNetPclEngine.cs
 * Description:
 *  SQLite-Net-PCL engine implementation
 */

using System;
using System.Data;

namespace Xeno.SQLiteAdmin.Engines.SQLiteNetPcl
{
  public class SqliteNetPclEngine : ISqlEngine
  {
    /// <summary>Connection string</summary>
    public string ConnectionString { get; set; }

    //public void Connect()
    //{
    //  throw new NotImplementedException();
    //}
    //
    //public void Connect(string connectionString)
    //{
    //  throw new NotImplementedException();
    //}
    //
    //public void Disconnect()
    //{
    //}

    public int ExecuteNonQuery(string query)
    {
      throw new NotImplementedException();
    }

    public DataSet ExecuteQuery(string query)
    {
      throw new NotImplementedException();
    }

    private void GetQueryType(string query)
    {
      //RunSql::StatementType RunSql::getQueryType(const QString&query)
      //{
      //  // Helper function for getting the type of a given query
      //
      //  if (query.startsWith("SELECT", Qt::CaseInsensitive)) return SelectStatement;
      //  if (query.startsWith("ALTER", Qt::CaseInsensitive)) return AlterStatement;
      //  if (query.startsWith("DROP", Qt::CaseInsensitive)) return DropStatement;
      //  if (query.startsWith("ROLLBACK", Qt::CaseInsensitive)) return RollbackStatement;
      //  if (query.startsWith("PRAGMA", Qt::CaseInsensitive)) return PragmaStatement;
      //  if (query.startsWith("VACUUM", Qt::CaseInsensitive)) return VacuumStatement;
      //  if (query.startsWith("INSERT", Qt::CaseInsensitive)) return InsertStatement;
      //  if (query.startsWith("UPDATE", Qt::CaseInsensitive)) return UpdateStatement;
      //  if (query.startsWith("DELETE", Qt::CaseInsensitive)) return DeleteStatement;
      //  if (query.startsWith("CREATE", Qt::CaseInsensitive)) return CreateStatement;
      //  if (query.startsWith("ATTACH", Qt::CaseInsensitive)) return AttachStatement;
      //  if (query.startsWith("DETACH", Qt::CaseInsensitive)) return DetachStatement;
      //
      //  return OtherStatement;
      //}
    }
  }
}
