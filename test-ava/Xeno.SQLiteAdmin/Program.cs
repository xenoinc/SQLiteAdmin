/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-25
 * Author:  Damian Suess
 * File:    Program.cs
 * Description:
 *
 */

using Avalonia;
using Avalonia.Logging.Serilog;
using Xeno.SQLiteAdmin.Services;
using Xeno.SQLiteAdmin.ViewModels;
using Xeno.SQLiteAdmin.Views;

namespace Xeno.SQLiteAdmin
{
  internal class Program
  {
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    public static void Main(string[] args) => BuildAvaloniaApp().Start(AppMain, args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToDebug()
            .UseReactiveUI();

    // Your application's entry point. Here you can initialize your MVVM framework, DI
    // container, etc.
    private static void AppMain(Application app, string[] args)
    {
      var todoService = new TodoService();

      var window = new MainWindow
      {
        DataContext = new MainWindowViewModel(todoService),
      };

      app.Run(window);
    }
  }
}