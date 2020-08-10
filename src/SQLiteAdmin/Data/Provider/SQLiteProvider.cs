/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-8
 * File:    SQLiteProvider.cs
 * Description:
 *  Sqlite provider
 *  
 * Reference:
 *  - https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/encryption?tabs=visual-studio
 *
 * Change Log:
 *  2017-0308 * Initial creation
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using log4net;

namespace Xeno.SQLiteAdmin.Data.Provider
{
  public class SQLiteProvider : IProvider
  {
    private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    private SQLiteDataAdapter _adapter;
    private SQLiteCommand _command;
    private SQLiteConnection _connection;

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
      this.Properties.Add(DatabaseProperty.SqliteVersion, "3");

      if (!string.IsNullOrEmpty(password))
        this.Properties.Add(DatabaseProperty.SqlitePassword, password);
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
          string pw = this.Properties[DatabaseProperty.SqlitePassword];
          if (!string.IsNullOrEmpty(pw))
            cs += $"Password={pw};";
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

    public DatabaseProviderType ProviderType { get { return DatabaseProviderType.SQLite; } }

    public string SQLiteVersion { get { return "3"; } }

    public void Close()
    {
      if (_connection != null)
      {
        try
        {
          _connection.Close();
        }
        catch { }
      }
    }

    public int ExecuteNonQuery(string query, out Exception hasException)
    {
      int rowsAffected = 0;
      hasException = null;

      try
      {
        _connection = new SQLiteConnection(this.ConnectionString);
        _connection.StateChange += Sqlite_StateChange;

        _connection.Open();

        _connection.Update += Sqlite_Update;
        _connection.Progress += Sqlite_Progress;
      }
      catch (Exception e)
      {
        hasException = e;
        Log.Error($"Error occurred connecting to db: {e.Message}");

        _connection.Progress -= Sqlite_Progress;
        _connection.Update -= Sqlite_Update;
        _connection.StateChange -= Sqlite_StateChange;

        return 0;
      }

      // Method 1
      try
      {
        Log.Debug($"Executing query:\r\n{query}");

        using (SQLiteCommand cmd = new SQLiteCommand())
        {
          cmd.Connection = _connection;
          cmd.CommandText = query;

          // rowsAffected = cmd.ExecuteNonQuery();
          //var dataSet = cmd.ExecuteScalar();
          //if (dataSet != null)
          //{
          //  ;
          //}

          var reader = cmd.ExecuteReader();
          while (reader.Read())
          {
            var items = ReadSingleRow((IDataRecord)reader);
          }

        }
      }
      catch (Exception ex)
      {
        hasException = ex;
        Log.Error($"Error occurred executing query: {ex.Message}");
      }

      // Method 2
      //_sqlCmd = _sqlCon.CreateCommand();
      //_sqlCmd.CommandText = query;
      //rowsAffected = _sqlCmd.ExecuteNonQuery();

      _connection.Close();

      _connection.Progress -= Sqlite_Progress;
      _connection.Update -= Sqlite_Update;
      _connection.StateChange -= Sqlite_StateChange;

      return rowsAffected;
    }

    private List<string> ReadSingleRow(IDataRecord record)
    {
      var rowItems = new List<string>();
      Log.Debug("DataRecord: " + record.ToString());

      for (int ndx = 0; ndx < record.FieldCount; ++ndx)
      {
        string x = record[ndx].ToString();
        rowItems.Add(x);
      }

      return rowItems;
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
      this._connection = new SQLiteConnection(this.ConnectionString);
      this._connection.Open();

      // Deprecated feature
      //// this._connection.ChangePassword(newPassword);

      var command = _connection.CreateCommand();
      command.CommandText = "SELECT quote($newPassword);";
      command.Parameters.AddWithValue("$newPassword", newPassword);
      var quotedNewPass = (string)command.ExecuteScalar();

      command.CommandText = $"PRAGMA rekey = {quotedNewPass}";
      command.Parameters.Clear();
      command.ExecuteNonQuery();

      this.Properties[DatabaseProperty.SqlitePassword] = newPassword;

      this._connection.Close();

      return false;
    }

    private void Sqlite_StateChange(object sender, StateChangeEventArgs e)
    {
      Log.Debug($"State Changed from {e.OriginalState} to {e.CurrentState}");
    }

    private void Sqlite_Progress(object sender, ProgressEventArgs e)
    {
      // SQLiteProgressReturnCode - Continue, Interrupt
      Log.Debug($"Return code: '{e.ReturnCode.ToString()}'; Progress data: " + e.ToString());
    }

    private void Sqlite_Update(object sender, UpdateEventArgs e)
    {
      // UpdateEventType: Delete, Insert, Update
      Log.Debug(
        $"Db: '{e.Database}' " +
        $"Table: '{e.Table}' " +
        $"RowId: '{e.RowId}' " +
        $"had a(n) '{e.Event.ToString()}'");
    }

    //private bool ConnectionOpen()
    //{
    //}

    //private bool ConnectionClose()
    //{
    //}
  }
}