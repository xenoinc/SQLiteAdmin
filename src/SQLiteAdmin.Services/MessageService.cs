using Xeno.SQLiteAdmin.Services.Interfaces;

namespace Xeno.SQLiteAdmin.Services
{
  public class MessageService : IMessageService
  {
    public string GetMessage()
    {
      return "Hello from the Message Service";
    }
  }
}
