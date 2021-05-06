using Prism.Mvvm;
using Prism.Navigation;

namespace Xeno.SQLiteAdmin.Core.Mvvm
{
  public abstract class ViewModelBase : BindableBase, IDestructible
  {
    protected ViewModelBase()
    {

    }

    public virtual void Destroy()
    {

    }
  }
}
