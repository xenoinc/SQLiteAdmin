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
using System.Data;
using System.Data.SQLite;

namespace Xeno.SQLiteAdmin.Data.Provider
{
  public class SQLiteProvider : IDatabaseProvider
  {
    private DataSet _ds = new DataSet();
    private DataTable _dt = new DataTable();
    private SQLiteDataAdapter _sqlAdapter;
    private SQLiteCommand _sqlCmd;
    private SQLiteConnection _sqlCon;

    public SQLiteProvider() : this(string.Empty, string.Empty)
    {
    }

    public SQLiteProvider(string dbFile) : this(dbFile, string.Empty)
    {
    }

    public SQLiteProvider(string dbFile, string password)
    {
      this.DbFile = dbFile;
      this.Password = password;
    }

    public string ConnectionString
    {
      get
      {
        string cs = $"Data Source={this.DbFile};Version={this.SQLiteVersion};New=False;Compress=True;";

        if (!string.IsNullOrEmpty(this.Password))
          cs += $";Password={this.Password};";

        return cs;
      }

      set { ConnectionString = value; }
    }

    public string DbFile { get; set; }

    public string Password { get; set; }

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

    public int ExecuteNonQuery(string query)
    {
      int rowsAffected = 0;

      throw new NotImplementedException();

      _sqlCon = new SQLiteConnection(this.ConnectionString);
      _sqlCon.Open();

      // Method 1
      using (SQLiteCommand cmd = new SQLiteCommand())
      {
        cmd.Connection = _sqlCon;
        cmd.CommandText = query;
        rowsAffected = cmd.ExecuteNonQuery();
      }

      // Method 2
      //_sqlCmd = _sqlCon.CreateCommand();
      //_sqlCmd.CommandText = query;
      //rowsAffected = _sqlCmd.ExecuteNonQuery();

      _sqlCon.Close();

      return rowsAffected;
    }

    public DataSet ExecuteQuery(string query)
    {
      var ds = new DataSet();

      // Reference: https://www.codeproject.com/Tips/988690/WinForms-WPF-Using-SQLite-DataBase

      return ds;
    }

    public bool UpdatePassword(string newPassword)
    {
      this._sqlCon = new SQLiteConnection(this.ConnectionString);

      this._sqlCon.Open();
      this._sqlCon.ChangePassword(newPassword);
      this.Password = newPassword;

      this._sqlCon.Close();

      return false;
    }

    //private bool ConnectionOpen()
    //{
    //}

    //private bool ConnectionClose()
    //{
    //}
  }
}
