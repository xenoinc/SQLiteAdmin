using System;
using Xeno.SQLiteAdmin.Services.Interfaces;

namespace Xeno.SQLiteAdmin.Services
{
  public class MessageService : IMessageService
  {
    public string GetMessage()
    {
      return $"-- What the dev?!{Environment.NewLine}select * from FungKuFit.News;";
    }
  }
}
