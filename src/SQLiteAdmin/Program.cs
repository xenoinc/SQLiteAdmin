/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-01-24
 * File:    Program.cs
 * Description:
 *
 * To Do:
 * Change Log:
 *  2017-0124 * Initial creation
 */

using System;
using System.Windows.Forms;
using log4net;

namespace Xeno.SQLiteAdmin
{
  internal static class Program
  {
    private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      log4net.Config.XmlConfigurator.Configure();
      Log.Debug("############################");
      Log.Debug("Let's do this!!   ლ(｀ー´ლ)");

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainIde());

      Log.Debug("Goodnight          ( ͡◉ ͜ʖ ͡◉)﻿.");
      Log.Debug("############################");
    }
  }
}
