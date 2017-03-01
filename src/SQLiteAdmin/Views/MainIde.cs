/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-01-24
 * File:    MainIde.cs
 * Description:
 *  
 * To Do:
 * Change Log:
 *  2017-0124 * Initial creation
 */


using System;
using System.Windows.Forms;

namespace SQLiteAdmin
{
  public partial class MainIde : Form
  {
    public MainIde()
    {
      InitializeComponent();
    }

    private void MainIde_Load(object sender, EventArgs e)
    {

    }

    private void menuNew_Click(object sender, EventArgs e)
    {
      Form frm = new Views.Session();
      frm.Show();
    }
  }
}
