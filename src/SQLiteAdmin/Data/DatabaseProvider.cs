/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-8
 * File:    DatabaseProvider.cs
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

namespace Xeno.SQLiteAdmin.Data
{
  public enum DatabaseProvider
  {
    Unknown,
    SQLite,
    SQLiteCrypt,
    MSSQL,
    MySQL
  }
}
