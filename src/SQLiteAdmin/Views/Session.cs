/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-01-24
 * File:    Session.cs
 * Description:
 *  
 * To Do:
 * Change Log:
 *  2017-0124 * Initial creation
 */

using System;

using System.Windows.Forms;
using ICSharpCode.AvalonEdit;

namespace SQLiteAdmin.Views
{
  public partial class Session : Form
  {
    public TextEditor Editor { get; set; }

    public Session()
    {
      InitializeComponent();

      Editor = new ICSharpCode.AvalonEdit.TextEditor();
      elementHost1.Child = Editor;
    }

    private void Session_Load(object sender, EventArgs e)
    {

    }
    
    public void SetSyntax(string res)
    {
      // this.Editor.SyntaxHighlighting = 
    }
 

  }
}
