/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-8
 * File:    Options.cs
 * Description:
 *  Options window
 *  
 * To Do:
 *  [ ] Change this to use Mono.Addins. NEVER HARD CODE!
 *  
 * Change Log:
 *  2017-38 * Initial creation
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xeno.SQLiteAdmin.Data;
using Xeno.SQLiteAdmin.Data.Provider;

namespace Xeno.SQLiteAdmin.Views
{
  public partial class OptionsForm : Form
  {
    public OptionsForm()
    {
      InitializeComponent();
      InitSettings();
    }

    private void Options_Load(object sender, EventArgs e)
    {
      
    }

    private void InitSettings()
    {
      ComboDefaultDbProvider.Items.Clear();

      foreach (DatabaseProvider item in Enum.GetValues(typeof(DatabaseProvider)))
      {
        ComboDefaultDbProvider.Items.Add(item.ToString());
      }
    }
  }
}
