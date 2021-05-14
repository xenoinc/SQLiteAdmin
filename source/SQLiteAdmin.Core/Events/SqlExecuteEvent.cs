using System;
using System.Collections.Generic;
using System.Text;
using Prism.Events;

namespace Xeno.SQLiteAdmin.Core.Events
{
  public class SqlExecuteEvent : PubSubEvent<string>
  {
  }
}
