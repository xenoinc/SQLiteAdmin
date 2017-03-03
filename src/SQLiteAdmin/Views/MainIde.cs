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

namespace Xeno.SQLiteAdmin
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

    private void btnTestSetText_Click(object sender, EventArgs e)
    {
      syntaxEditor1.Text = "Lorem Ipsum can be boring";
      textEditor1.Text = "Here is an external control";
    }

    private void btnTestToggleLines_Click(object sender, EventArgs e)
    {
      syntaxEditor1.ShowLineNumbers = !syntaxEditor1.ShowLineNumbers;
      textEditor1.ShowLineNumbers = !textEditor1.ShowLineNumbers;
    }

    private void btnTestGetText_Click(object sender, EventArgs e)
    {
      string tmp;
      tmp = syntaxEditor1.Text;
      syntaxEditor1.Text = textEditor1.Text;
      textEditor1.Text = tmp;
    }

  }
}
