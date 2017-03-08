/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-8
 * File:    SQLiteProvider.cs
 * Description:
 *  
 * To Do:
 * Change Log:
 *  2017-38 * Initial creation
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Xeno.SQLiteAdmin.Data.Provider
{
  public class SQLiteProvider : IDatabaseProvider
  {

    public int ExecuteNonQuery(string query)
    {
      int rowsAffected = 0;

      throw new NotImplementedException();

      return rowsAffected;
    }

    public DataSet ExecuteQuery(string query)
    {
      var ds = new DataSet();

      return ds;
    }

  }
}
