using Prism.Mvvm;

namespace Xeno.SQLiteAdmin.ViewModels
{
  public class MainViewModel : BindableBase
  {
    private string _title = "Prism Application";

    public MainViewModel()
    {
    }

    public string Title
    {
      get => _title;
      set => SetProperty(ref _title, value);
    }
  }
}
