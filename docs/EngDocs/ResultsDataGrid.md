WinForms - Send results to DataGrid

```cs
using System.Data.SQLite; private void btnClose_Click(object sender, EventArgs e)
{
  Close() ;
}
private void btngo_Click(object sender, EventArgs e)
{
  const string filename = @"C:\cplus\tutorials\c#\SQLite\MyDatabase.sqlite";
  const string sql = "select * from friends;";
  var conn = new SQLiteConnection("Data Source=" + filename + ";Version=3;") ;
  try
  {
    conn.Open() ;
    DataSet ds = new DataSet() ;
    var da = new SQLiteDataAdapter(sql, conn) ;
    da.Fill(ds) ;
    grid.DataSource = ds.Tables[0].DefaultView;
  }
  catch (Exception)
  {
throw;
  }
}
```