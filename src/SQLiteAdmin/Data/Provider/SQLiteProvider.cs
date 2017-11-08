/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-8
 * File:    SQLiteProvider.cs
 * Description:
 *
 * Change Log:
 *  2017-0308 * Initial creation
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Xeno.SQLiteAdmin.Data.Provider
{
  public class SQLiteProvider : IDatabaseProvider
  {
    private SQLiteDataAdapter _sqlAdapter;
    private SQLiteCommand _sqlCmd;
    private SQLiteConnection _sqlCon;

    private DataSet _ds = new DataSet();
    private DataTable _dt = new DataTable();

    public SQLiteProvider() : this(string.Empty, string.Empty)
    {
    }

    public SQLiteProvider(string dbFile) : this(dbFile, string.Empty)
    {
    }

    public SQLiteProvider(string dbFile, string password)
    {
      this.Properties = new Dictionary<DatabaseProperty, string>();
      this.Properties.Add(DatabaseProperty.SqliteDatabase, dbFile);
      this.Properties.Add(DatabaseProperty.SqlitePassword, password);
      this.Properties.Add(DatabaseProperty.SqliteVersion, "3");
    }

    public string ConnectionString
    {
      get
      {
        string cs = $"Data Source={this.Properties[DatabaseProperty.SqliteDatabase]};" +
                    $"Version={this.Properties[DatabaseProperty.SqliteVersion]};" +
                    "New=False;" +
                    "Compress=True;";

        if (Properties.ContainsKey(DatabaseProperty.SqlitePassword))
        {
          cs += $"Password={this.Properties[DatabaseProperty.SqlitePassword]};";
        }
        //if (!string.IsNullOrEmpty(this.Password))
        //  cs += $";Password={this.Password};";

        return cs;
      }

      set { ConnectionString = value; }
    }

    //public string DbFile { get; set; }

    //public string Password { get; set; }

    public Dictionary<DatabaseProperty, string> Properties { get; set; }

    public DatabaseProvider ProviderType { get { return DatabaseProvider.SQLite; } }

    public string SQLiteVersion { get { return "3"; } }

    public void Close()
    {
      if (_sqlCon != null)
      {
        try
        {
          _sqlCon.Close();
        }
        catch { }
      }
    }

    public int ExecuteNonQuery(string query, out Exception hasException)
    {
      int rowsAffected = 0;
      hasException = null;

      _sqlCon = new SQLiteConnection(this.ConnectionString);
      _sqlCon.Open();

      //TODO: Add more events
      _sqlCon.Update += SQLiteConnection_Update;

      // Method 1
      try
      {
        using (SQLiteCommand cmd = new SQLiteCommand())
        {
          cmd.Connection = _sqlCon;
          cmd.CommandText = query;
          rowsAffected = cmd.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        hasException = ex;
      }

      // Method 2
      //_sqlCmd = _sqlCon.CreateCommand();
      //_sqlCmd.CommandText = query;
      //rowsAffected = _sqlCmd.ExecuteNonQuery();

      _sqlCon.Close();

      _sqlCon.Update -= SQLiteConnection_Update;

      return rowsAffected;
    }

    public DataSet ExecuteQuery(string query)
    {
      var ds = new DataSet();

      // Reference: https://www.codeproject.com/Tips/988690/WinForms-WPF-Using-SQLite-DataBase

      return ds;
    }

    /// <summary>Stop execution of current command</summary>
    /// <returns></returns>
    public bool StopExecuting()
    {
      throw new NotImplementedException();
      return false;
    }

    public bool UpdatePassword(string newPassword)
    {
      this._sqlCon = new SQLiteConnection(this.ConnectionString);

      this._sqlCon.Open();
      this._sqlCon.ChangePassword(newPassword);
      this.Properties[DatabaseProperty.SqlitePassword] = newPassword;

      this._sqlCon.Close();

      return false;
    }

    private void SQLiteConnection_Update(object sender, UpdateEventArgs e)
    {
      throw new NotImplementedException();
    }

    //private bool ConnectionOpen()
    //{
    //}

    //private bool ConnectionClose()
    //{
    //}
  }
}
