// Type: System.Windows.Threading.DispatcherObject
// Assembly: WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\WPF\WindowsBase.dll

using MS.Internal.WindowsBase;
using System.ComponentModel;
using System.Runtime;

namespace System.Windows.Threading
{
  public abstract class DispatcherObject
  {
    private Dispatcher _dispatcher;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public Dispatcher Dispatcher
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._dispatcher;
      }
    }

    protected DispatcherObject()
    {
      this._dispatcher = Dispatcher.CurrentDispatcher;
    }

    [FriendAccessAllowed]
    internal void DetachFromDispatcher()
    {
      this._dispatcher = (Dispatcher) null;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool CheckAccess()
    {
      bool flag = true;
      Dispatcher dispatcher = this._dispatcher;
      if (dispatcher != null)
        flag = dispatcher.CheckAccess();
      return flag;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void VerifyAccess()
    {
      Dispatcher dispatcher = this._dispatcher;
      if (dispatcher == null)
        return;
      dispatcher.VerifyAccess();
    }
  }
}
