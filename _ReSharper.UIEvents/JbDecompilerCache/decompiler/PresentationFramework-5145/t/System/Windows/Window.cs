// Type: System.Windows.Window
// Assembly: PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\WPF\PresentationFramework.dll

using MS.Internal;
using MS.Internal.AppModel;
using MS.Internal.Interop;
using MS.Internal.KnownBoxes;
using MS.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shell;
using System.Windows.Threading;

namespace System.Windows
{
  [Localizability(LocalizationCategory.Ignore)]
  [UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows)]
  public class Window : ContentControl, IWindowService
  {
    public static readonly DependencyProperty TaskbarItemInfoProperty = DependencyProperty.Register("TaskbarItemInfo", typeof (TaskbarItemInfo), typeof (Window), new PropertyMetadata((object) null, (PropertyChangedCallback) ((d, e) => ((Window) d).OnTaskbarItemInfoChanged(e)), new CoerceValueCallback(Window.VerifyAccessCoercion)));
    public static readonly DependencyProperty AllowsTransparencyProperty = DependencyProperty.Register("AllowsTransparency", typeof (bool), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(Window.OnAllowsTransparencyChanged), new CoerceValueCallback(Window.CoerceAllowsTransparency)));
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof (string), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) string.Empty, new PropertyChangedCallback(Window._OnTitleChanged)), new ValidateValueCallback(Window._ValidateText));
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof (ImageSource), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(Window._OnIconChanged), new CoerceValueCallback(Window.VerifyAccessCoercion)));
    public static readonly DependencyProperty SizeToContentProperty = DependencyProperty.Register("SizeToContent", typeof (SizeToContent), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) SizeToContent.Manual, new PropertyChangedCallback(Window._OnSizeToContentChanged)), new ValidateValueCallback(Window._ValidateSizeToContentCallback));
    public static readonly DependencyProperty TopProperty = Canvas.TopProperty.AddOwner(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) double.NaN, new PropertyChangedCallback(Window._OnTopChanged), new CoerceValueCallback(Window.CoerceTop)));
    public static readonly DependencyProperty LeftProperty = Canvas.LeftProperty.AddOwner(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) double.NaN, new PropertyChangedCallback(Window._OnLeftChanged), new CoerceValueCallback(Window.CoerceLeft)));
    public static readonly DependencyProperty ShowInTaskbarProperty = DependencyProperty.Register("ShowInTaskbar", typeof (bool), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.TrueBox, new PropertyChangedCallback(Window._OnShowInTaskbarChanged), new CoerceValueCallback(Window.VerifyAccessCoercion)));
    private static readonly DependencyPropertyKey IsActivePropertyKey = DependencyProperty.RegisterReadOnly("IsActive", typeof (bool), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.FalseBox));
    public static readonly DependencyProperty IsActiveProperty = Window.IsActivePropertyKey.DependencyProperty;
    public static readonly DependencyProperty WindowStyleProperty = DependencyProperty.Register("WindowStyle", typeof (WindowStyle), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) WindowStyle.SingleBorderWindow, new PropertyChangedCallback(Window._OnWindowStyleChanged), new CoerceValueCallback(Window.CoerceWindowStyle)), new ValidateValueCallback(Window._ValidateWindowStyleCallback));
    public static readonly DependencyProperty WindowStateProperty = DependencyProperty.Register("WindowState", typeof (WindowState), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) WindowState.Normal, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Window._OnWindowStateChanged), new CoerceValueCallback(Window.VerifyAccessCoercion)), new ValidateValueCallback(Window._ValidateWindowStateCallback));
    public static readonly DependencyProperty ResizeModeProperty = DependencyProperty.Register("ResizeMode", typeof (ResizeMode), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) ResizeMode.CanResize, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(Window._OnResizeModeChanged), new CoerceValueCallback(Window.VerifyAccessCoercion)), new ValidateValueCallback(Window._ValidateResizeModeCallback));
    public static readonly DependencyProperty TopmostProperty = DependencyProperty.Register("Topmost", typeof (bool), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(Window._OnTopmostChanged), new CoerceValueCallback(Window.VerifyAccessCoercion)));
    public static readonly DependencyProperty ShowActivatedProperty = DependencyProperty.Register("ShowActivated", typeof (bool), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.TrueBox, (PropertyChangedCallback) null, new CoerceValueCallback(Window.VerifyAccessCoercion)));
    internal static readonly RoutedCommand DialogCancelCommand = new RoutedCommand("DialogCancel", typeof (Window));
    private static readonly object EVENT_SOURCEINITIALIZED = new object();
    private static readonly object EVENT_CLOSING = new object();
    private static readonly object EVENT_CLOSED = new object();
    private static readonly object EVENT_ACTIVATED = new object();
    private static readonly object EVENT_DEACTIVATED = new object();
    private static readonly object EVENT_STATECHANGED = new object();
    private static readonly object EVENT_LOCATIONCHANGED = new object();
    private static readonly object EVENT_CONTENTRENDERED = new object();
    internal static readonly DependencyProperty IWindowServiceProperty = DependencyProperty.RegisterAttached("IWindowService", typeof (IWindowService), typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.OverridesInheritanceBehavior));
    [SecurityCritical]
    private IntPtr _ownerHandle = IntPtr.Zero;
    private bool _updateHwndSize = true;
    private bool _updateHwndLocation = true;
    private double _trackMaxWidthDeviceUnits = double.PositiveInfinity;
    private double _trackMaxHeightDeviceUnits = double.PositiveInfinity;
    [SecurityTreatAsSafe]
    [SecurityCritical]
    private double _actualTop = double.NaN;
    [SecurityTreatAsSafe]
    [SecurityCritical]
    private double _actualLeft = double.NaN;
    private bool? _dialogResult = new bool?();
    [SecurityCritical]
    private IntPtr _dialogOwnerHandle = IntPtr.Zero;
    private Point _prePanningLocation = new Point(double.NaN, double.NaN);
    private Window.SourceWindowHelper _swh;
    private Window _ownerWindow;
    private WindowCollection _ownedWindows;
    private ArrayList _threadWindowHandles;
    private bool _updateStartupLocation;
    private bool _isVisible;
    private bool _isVisibilitySet;
    private bool _resetKeyboardCuesProperty;
    private bool _previousKeyboardCuesProperty;
    private static bool _dialogCommandAdded;
    private bool _postContentRenderedFromLoadedHandler;
    private bool _disposed;
    private bool _appShuttingDown;
    private bool _ignoreCancel;
    private bool _showingAsDialog;
    private bool _isClosing;
    private bool _visibilitySetInternally;
    private bool _hwndCreatedButNotShown;
    private double _trackMinWidthDeviceUnits;
    private double _trackMinHeightDeviceUnits;
    [SecurityCritical]
    private bool _inTrustedSubWindow;
    private ImageSource _icon;
    private MS.Win32.NativeMethods.IconHandle _defaultLargeIconHandle;
    private MS.Win32.NativeMethods.IconHandle _defaultSmallIconHandle;
    private MS.Win32.NativeMethods.IconHandle _currentLargeIconHandle;
    private MS.Win32.NativeMethods.IconHandle _currentSmallIconHandle;
    [SecurityCritical]
    private IntPtr _dialogPreviousActiveHandle;
    private DispatcherFrame _dispatcherFrame;
    private WindowStartupLocation _windowStartupLocation;
    private WindowState _previousWindowState;
    [SecurityCritical]
    private HwndSource _hiddenWindow;
    private EventHandlerList _events;
    private SecurityCriticalDataForSet<int> _styleDoNotUse;
    private SecurityCriticalDataForSet<int> _styleExDoNotUse;
    private Window.HwndStyleManager _manager;
    private Control _resizeGripControl;
    [SecurityCritical]
    private static readonly WindowMessage WM_TASKBARBUTTONCREATED;
    [SecurityCritical]
    private static readonly WindowMessage WM_APPLYTASKBARITEMINFO;
    [SecurityCritical]
    private ITaskbarList3 _taskbarList;
    [SecurityCritical]
    private DispatcherTimer _taskbarRetryTimer;
    private Size _overlaySize;
    private DispatcherOperation _contentRenderedCallback;
    private WeakReference _currentPanningTarget;
    private static DependencyObjectType _dType;
    private const int c_MaximumThumbButtons = 7;

    protected internal override IEnumerator LogicalChildren
    {
      get
      {
        return (IEnumerator) new SingleChildEnumerator(this.Content);
      }
    }

    public TaskbarItemInfo TaskbarItemInfo
    {
      get
      {
        this.VerifyContextAndObjectState();
        return (TaskbarItemInfo) this.GetValue(Window.TaskbarItemInfoProperty);
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.SetValue(Window.TaskbarItemInfoProperty, (object) value);
      }
    }

    public bool AllowsTransparency
    {
      get
      {
        return (bool) this.GetValue(Window.AllowsTransparencyProperty);
      }
      set
      {
        this.SetValue(Window.AllowsTransparencyProperty, BooleanBoxes.Box(value));
      }
    }

    [Localizability(LocalizationCategory.Title)]
    public string Title
    {
      get
      {
        this.VerifyContextAndObjectState();
        return (string) this.GetValue(Window.TitleProperty);
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.SetValue(Window.TitleProperty, (object) value);
      }
    }

    public ImageSource Icon
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return (ImageSource) this.GetValue(Window.IconProperty);
      }
      [SecurityCritical] set
      {
        this.VerifyApiSupported();
        SecurityHelper.DemandUIWindowPermission();
        this.VerifyContextAndObjectState();
        this.SetValue(Window.IconProperty, (object) value);
      }
    }

    public SizeToContent SizeToContent
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return (SizeToContent) this.GetValue(Window.SizeToContentProperty);
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        this.SetValue(Window.SizeToContentProperty, (object) value);
      }
    }

    [TypeConverter("System.Windows.LengthConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
    public double Top
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return (double) this.GetValue(Window.TopProperty);
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        this.SetValue(Window.TopProperty, (object) value);
      }
    }

    [TypeConverter("System.Windows.LengthConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
    public double Left
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return (double) this.GetValue(Window.LeftProperty);
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        this.SetValue(Window.LeftProperty, (object) value);
      }
    }

    public Rect RestoreBounds
    {
      [SecurityCritical] get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        if (!this._inTrustedSubWindow)
          SecurityHelper.DemandUIWindowPermission();
        if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
          return Rect.Empty;
        else
          return this.GetNormalRectLogicalUnits(this.CriticalHandle);
      }
    }

    [DefaultValue(WindowStartupLocation.Manual)]
    public WindowStartupLocation WindowStartupLocation
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return this._windowStartupLocation;
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        if (!Window.IsValidWindowStartupLocation(value))
          throw new InvalidEnumArgumentException("value", (int) value, typeof (WindowStartupLocation));
        this._windowStartupLocation = value;
      }
    }

    public bool ShowInTaskbar
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return (bool) this.GetValue(Window.ShowInTaskbarProperty);
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        this.SetValue(Window.ShowInTaskbarProperty, BooleanBoxes.Box(value));
      }
    }

    public bool IsActive
    {
      get
      {
        this.VerifyContextAndObjectState();
        return (bool) this.GetValue(Window.IsActiveProperty);
      }
    }

    [DefaultValue(null)]
    public Window Owner
    {
      [SecurityCritical] get
      {
        this.VerifyApiSupported();
        SecurityHelper.DemandUIWindowPermission();
        this.VerifyContextAndObjectState();
        return this._ownerWindow;
      }
      [SecurityCritical] set
      {
        this.VerifyApiSupported();
        SecurityHelper.DemandUIWindowPermission();
        this.VerifyContextAndObjectState();
        if (value == this)
          throw new ArgumentException(System.Windows.SR.Get("CannotSetOwnerToItself"));
        if (this._showingAsDialog)
          throw new InvalidOperationException(System.Windows.SR.Get("CantSetOwnerAfterDialogIsShown"));
        if (value != null && value.IsSourceWindowNull)
        {
          if (value._disposed)
            throw new InvalidOperationException(System.Windows.SR.Get("CantSetOwnerToClosedWindow"));
          else
            throw new InvalidOperationException(System.Windows.SR.Get("CantSetOwnerWhosHwndIsNotCreated"));
        }
        else
        {
          if (this._ownerWindow == value)
            return;
          if (!this._disposed)
          {
            if (value != null)
            {
              WindowCollection ownedWindows = this.OwnedWindows;
              for (int index = 0; index < ownedWindows.Count; ++index)
              {
                if (ownedWindows[index] == value)
                  throw new ArgumentException(System.Windows.SR.Get("CircularOwnerChild", (object) value, (object) this));
              }
            }
            if (this._ownerWindow != null)
              this._ownerWindow.OwnedWindowsInternal.Remove(this);
          }
          this._ownerWindow = value;
          if (this._disposed)
            return;
          this.SetOwnerHandle(this._ownerWindow != null ? this._ownerWindow.CriticalHandle : IntPtr.Zero);
          if (this._ownerWindow == null)
            return;
          this._ownerWindow.OwnedWindowsInternal.Add(this);
        }
      }
    }

    bool IsOwnerNull
    {
      [SecurityTreatAsSafe, SecurityCritical] private get
      {
        return this._ownerWindow == null;
      }
    }

    public WindowCollection OwnedWindows
    {
      get
      {
        this.VerifyContextAndObjectState();
        return this.OwnedWindowsInternal.Clone();
      }
    }

    [TypeConverter(typeof (DialogResultConverter))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool? DialogResult
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return this._dialogResult;
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        if (!this._showingAsDialog)
          throw new InvalidOperationException(System.Windows.SR.Get("DialogResultMustBeSetAfterShowDialog"));
        bool? nullable1 = this._dialogResult;
        bool? nullable2 = value;
        if ((nullable1.GetValueOrDefault() != nullable2.GetValueOrDefault() ? 1 : (nullable1.HasValue != nullable2.HasValue ? 1 : 0)) == 0)
          return;
        this._dialogResult = value;
        if (this._isClosing)
          return;
        this.Close();
      }
    }

    public WindowStyle WindowStyle
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return (WindowStyle) this.GetValue(Window.WindowStyleProperty);
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        this.SetValue(Window.WindowStyleProperty, (object) value);
      }
    }

    public WindowState WindowState
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return (WindowState) this.GetValue(Window.WindowStateProperty);
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        this.SetValue(Window.WindowStateProperty, (object) value);
      }
    }

    public ResizeMode ResizeMode
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return (ResizeMode) this.GetValue(Window.ResizeModeProperty);
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        this.SetValue(Window.ResizeModeProperty, (object) value);
      }
    }

    public bool Topmost
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return (bool) this.GetValue(Window.TopmostProperty);
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        this.SetValue(Window.TopmostProperty, BooleanBoxes.Box(value));
      }
    }

    public bool ShowActivated
    {
      get
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        return (bool) this.GetValue(Window.ShowActivatedProperty);
      }
      set
      {
        this.VerifyContextAndObjectState();
        this.VerifyApiSupported();
        this.SetValue(Window.ShowActivatedProperty, BooleanBoxes.Box(value));
      }
    }

    internal bool IsSourceWindowNull
    {
      [SecurityCritical, SecurityTreatAsSafe] get
      {
        if (this._swh != null)
          return this._swh.IsSourceWindowNull;
        else
          return true;
      }
    }

    internal bool IsCompositionTargetInvalid
    {
      [SecurityTreatAsSafe, SecurityCritical] get
      {
        if (this._swh != null)
          return this._swh.IsCompositionTargetInvalid;
        else
          return true;
      }
    }

    internal MS.Win32.NativeMethods.RECT WorkAreaBoundsForNearestMonitor
    {
      get
      {
        return this._swh.WorkAreaBoundsForNearestMonitor;
      }
    }

    internal Size WindowSize
    {
      get
      {
        return this._swh.WindowSize;
      }
    }

    internal HwndSource HwndSourceWindow
    {
      [SecurityCritical, SecurityTreatAsSafe] get
      {
        SecurityHelper.DemandUIWindowPermission();
        if (this._swh != null)
          return this._swh.HwndSourceWindow;
        else
          return (HwndSource) null;
      }
    }

    internal bool HwndCreatedButNotShown
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._hwndCreatedButNotShown;
      }
    }

    internal bool IsDisposed
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._disposed;
      }
    }

    internal bool IsVisibilitySet
    {
      get
      {
        this.VerifyContextAndObjectState();
        return this._isVisibilitySet;
      }
    }

    internal IntPtr CriticalHandle
    {
      [SecurityCritical] get
      {
        this.VerifyContextAndObjectState();
        if (this._swh != null)
          return this._swh.CriticalHandle;
        else
          return IntPtr.Zero;
      }
    }

    internal IntPtr OwnerHandle
    {
      [SecurityCritical, SecurityTreatAsSafe] get
      {
        SecurityHelper.DemandUIWindowPermission();
        this.VerifyContextAndObjectState();
        return this._ownerHandle;
      }
      [SecurityTreatAsSafe, SecurityCritical] set
      {
        SecurityHelper.DemandUIWindowPermission();
        this.VerifyContextAndObjectState();
        if (this._showingAsDialog)
          throw new InvalidOperationException(System.Windows.SR.Get("CantSetOwnerAfterDialogIsShown"));
        this.SetOwnerHandle(value);
      }
    }

    internal int Win32Style
    {
      get
      {
        this.VerifyContextAndObjectState();
        return this._Style;
      }
      set
      {
        this.VerifyContextAndObjectState();
        this._Style = value;
      }
    }

    internal int _Style
    {
      get
      {
        if (this.Manager != null || this.IsSourceWindowNull)
          return this._styleDoNotUse.Value;
        else
          return this._swh.StyleFromHwnd;
      }
      [SecurityCritical, SecurityTreatAsSafe] set
      {
        SecurityHelper.DemandUIWindowPermission();
        this._styleDoNotUse = new SecurityCriticalDataForSet<int>(value);
        this.Manager.Dirty = true;
      }
    }

    internal int _StyleEx
    {
      get
      {
        if (this.Manager != null || this.IsSourceWindowNull)
          return this._styleExDoNotUse.Value;
        else
          return this._swh.StyleExFromHwnd;
      }
      [SecurityCritical, SecurityTreatAsSafe] set
      {
        SecurityHelper.DemandUIWindowPermission();
        this._styleExDoNotUse = new SecurityCriticalDataForSet<int>(value);
        this.Manager.Dirty = true;
      }
    }

    internal Window.HwndStyleManager Manager
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._manager;
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this._manager = value;
      }
    }

    bool IWindowService.UserResized
    {
      get
      {
        return false;
      }
    }

    bool CanCenterOverWPFOwner
    {
      private get
      {
        if (this.Owner == null || this.Owner.IsSourceWindowNull && (DoubleUtil.IsNaN(this.Owner.Width) || DoubleUtil.IsNaN(this.Owner.Height)) || (DoubleUtil.IsNaN(this.Owner.Left) || DoubleUtil.IsNaN(this.Owner.Top)))
          return false;
        else
          return true;
      }
    }

    private SizeToContent HwndSourceSizeToContent
    {
      get
      {
        return this._swh.HwndSourceSizeToContent;
      }
      set
      {
        this._swh.HwndSourceSizeToContent = value;
      }
    }

    MS.Win32.NativeMethods.RECT WindowBounds
    {
      private get
      {
        return this._swh.WindowBounds;
      }
    }

    int StyleFromHwnd
    {
      private get
      {
        if (this._swh == null)
          return 0;
        else
          return this._swh.StyleFromHwnd;
      }
    }

    int StyleExFromHwnd
    {
      private get
      {
        if (this._swh == null)
          return 0;
        else
          return this._swh.StyleExFromHwnd;
      }
    }

    WindowCollection OwnedWindowsInternal
    {
      private get
      {
        if (this._ownedWindows == null)
          this._ownedWindows = new WindowCollection();
        return this._ownedWindows;
      }
    }

    Application App
    {
      private get
      {
        return Application.Current;
      }
    }

    bool IsInsideApp
    {
      private get
      {
        return Application.Current != null;
      }
    }

    EventHandlerList Events
    {
      private get
      {
        if (this._events == null)
          this._events = new EventHandlerList();
        return this._events;
      }
    }

    internal override DependencyObjectType DTypeThemeStyleKey
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return Window._dType;
      }
    }

    public event EventHandler SourceInitialized
    {
      add
      {
        this.Events.AddHandler(Window.EVENT_SOURCEINITIALIZED, (Delegate) value);
      }
      remove
      {
        this.Events.RemoveHandler(Window.EVENT_SOURCEINITIALIZED, (Delegate) value);
      }
    }

    public event EventHandler Activated
    {
      add
      {
        this.Events.AddHandler(Window.EVENT_ACTIVATED, (Delegate) value);
      }
      remove
      {
        this.Events.RemoveHandler(Window.EVENT_ACTIVATED, (Delegate) value);
      }
    }

    public event EventHandler Deactivated
    {
      add
      {
        this.Events.AddHandler(Window.EVENT_DEACTIVATED, (Delegate) value);
      }
      remove
      {
        this.Events.RemoveHandler(Window.EVENT_DEACTIVATED, (Delegate) value);
      }
    }

    public event EventHandler StateChanged
    {
      add
      {
        this.Events.AddHandler(Window.EVENT_STATECHANGED, (Delegate) value);
      }
      remove
      {
        this.Events.RemoveHandler(Window.EVENT_STATECHANGED, (Delegate) value);
      }
    }

    public event EventHandler LocationChanged
    {
      add
      {
        this.Events.AddHandler(Window.EVENT_LOCATIONCHANGED, (Delegate) value);
      }
      remove
      {
        this.Events.RemoveHandler(Window.EVENT_LOCATIONCHANGED, (Delegate) value);
      }
    }

    public event CancelEventHandler Closing
    {
      add
      {
        this.Events.AddHandler(Window.EVENT_CLOSING, (Delegate) value);
      }
      remove
      {
        this.Events.RemoveHandler(Window.EVENT_CLOSING, (Delegate) value);
      }
    }

    public event EventHandler Closed
    {
      add
      {
        this.Events.AddHandler(Window.EVENT_CLOSED, (Delegate) value);
      }
      remove
      {
        this.Events.RemoveHandler(Window.EVENT_CLOSED, (Delegate) value);
      }
    }

    public event EventHandler ContentRendered
    {
      add
      {
        this.Events.AddHandler(Window.EVENT_CONTENTRENDERED, (Delegate) value);
      }
      remove
      {
        this.Events.RemoveHandler(Window.EVENT_CONTENTRENDERED, (Delegate) value);
      }
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    static Window()
    {
      FrameworkElement.HeightProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(Window._OnHeightChanged)));
      FrameworkElement.MinHeightProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(Window._OnMinHeightChanged)));
      FrameworkElement.MaxHeightProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(Window._OnMaxHeightChanged)));
      FrameworkElement.WidthProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(Window._OnWidthChanged)));
      FrameworkElement.MinWidthProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(Window._OnMinWidthChanged)));
      FrameworkElement.MaxWidthProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(Window._OnMaxWidthChanged)));
      UIElement.VisibilityProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) Visibility.Collapsed, new PropertyChangedCallback(Window._OnVisibilityChanged), new CoerceValueCallback(Window.CoerceVisibility)));
      Control.IsTabStopProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.FalseBox));
      KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) KeyboardNavigationMode.Cycle));
      KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) KeyboardNavigationMode.Cycle));
      KeyboardNavigation.ControlTabNavigationProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) KeyboardNavigationMode.Cycle));
      FocusManager.IsFocusScopeProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.TrueBox));
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (Window)));
      Window._dType = DependencyObjectType.FromSystemTypeInternal(typeof (Window));
      FrameworkElement.FlowDirectionProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(Window._OnFlowDirectionChanged)));
      UIElement.RenderTransformProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata((object) Transform.Identity, new PropertyChangedCallback(Window._OnRenderTransformChanged), new CoerceValueCallback(Window.CoerceRenderTransform)));
      UIElement.ClipToBoundsProperty.OverrideMetadata(typeof (Window), (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(Window._OnClipToBoundsChanged), new CoerceValueCallback(Window.CoerceClipToBounds)));
      Window.WM_TASKBARBUTTONCREATED = MS.Win32.UnsafeNativeMethods.RegisterWindowMessage("TaskbarButtonCreated");
      Window.WM_APPLYTASKBARITEMINFO = MS.Win32.UnsafeNativeMethods.RegisterWindowMessage("WPF_ApplyTaskbarItemInfo");
      EventManager.RegisterClassHandler(typeof (Window), UIElement.ManipulationCompletedEvent, (Delegate) new EventHandler<ManipulationCompletedEventArgs>(Window.OnStaticManipulationCompleted), true);
      EventManager.RegisterClassHandler(typeof (Window), UIElement.ManipulationInertiaStartingEvent, (Delegate) new EventHandler<ManipulationInertiaStartingEventArgs>(Window.OnStaticManipulationInertiaStarting), true);
    }

    [SecurityCritical]
    public Window()
    {
      SecurityHelper.DemandUnmanagedCode();
      this._inTrustedSubWindow = false;
      this.Initialize();
    }

    [SecurityCritical]
    internal Window(bool inRbw)
    {
      if (inRbw)
      {
        this._inTrustedSubWindow = true;
      }
      else
      {
        this._inTrustedSubWindow = false;
        SecurityHelper.DemandUnmanagedCode();
      }
      this.Initialize();
    }

    public void Show()
    {
      this.VerifyContextAndObjectState();
      this.VerifyCanShow();
      this.VerifyNotClosing();
      this.VerifyConsistencyWithAllowsTransparency();
      this.UpdateVisibilityProperty(Visibility.Visible);
      this.ShowHelper(BooleanBoxes.TrueBox);
    }

    public void Hide()
    {
      this.VerifyContextAndObjectState();
      if (this._disposed)
        return;
      this.UpdateVisibilityProperty(Visibility.Hidden);
      this.ShowHelper(BooleanBoxes.FalseBox);
    }

    [SecurityCritical]
    public void Close()
    {
      this.VerifyApiSupported();
      SecurityHelper.DemandUIWindowPermission();
      this.VerifyContextAndObjectState();
      this.InternalClose(false, false);
    }

    [SecurityCritical]
    public void DragMove()
    {
      this.VerifyApiSupported();
      SecurityHelper.DemandUIWindowPermission();
      this.VerifyContextAndObjectState();
      this.VerifyHwndCreateShowState();
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      if (Mouse.LeftButton != MouseButtonState.Pressed)
        throw new InvalidOperationException(System.Windows.SR.Get("DragMoveFail"));
      if (this.WindowState != WindowState.Normal)
        return;
      MS.Win32.UnsafeNativeMethods.SendMessage(this.CriticalHandle, WindowMessage.WM_SYSCOMMAND, (IntPtr) 61458, IntPtr.Zero);
      MS.Win32.UnsafeNativeMethods.SendMessage(this.CriticalHandle, WindowMessage.WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
    }

    [SecurityCritical]
    public bool? ShowDialog()
    {
      this.VerifyApiSupported();
      SecurityHelper.DemandUnrestrictedUIPermission();
      this.VerifyContextAndObjectState();
      this.VerifyCanShow();
      this.VerifyNotClosing();
      this.VerifyConsistencyWithAllowsTransparency();
      if (this._isVisible)
        throw new InvalidOperationException(System.Windows.SR.Get("ShowDialogOnVisible"));
      if (this._showingAsDialog)
        throw new InvalidOperationException(System.Windows.SR.Get("ShowDialogOnModal"));
      this._dialogOwnerHandle = this._ownerHandle;
      if (!MS.Win32.UnsafeNativeMethods.IsWindow(new HandleRef((object) null, this._dialogOwnerHandle)))
        this._dialogOwnerHandle = IntPtr.Zero;
      this._dialogPreviousActiveHandle = MS.Win32.UnsafeNativeMethods.GetActiveWindow();
      if (this._dialogOwnerHandle == IntPtr.Zero)
        this._dialogOwnerHandle = this._dialogPreviousActiveHandle;
      if (this._dialogOwnerHandle != IntPtr.Zero && this._dialogOwnerHandle == MS.Win32.UnsafeNativeMethods.GetDesktopWindow())
        this._dialogOwnerHandle = IntPtr.Zero;
      if (this._dialogOwnerHandle != IntPtr.Zero)
      {
        while (this._dialogOwnerHandle != IntPtr.Zero && (MS.Win32.UnsafeNativeMethods.GetWindowLong(new HandleRef((object) this, this._dialogOwnerHandle), -16) & 1073741824) == 1073741824)
          this._dialogOwnerHandle = MS.Win32.UnsafeNativeMethods.GetParent(new HandleRef((object) null, this._dialogOwnerHandle));
      }
      this._threadWindowHandles = new ArrayList();
      MS.Win32.UnsafeNativeMethods.EnumThreadWindows(SafeNativeMethods.GetCurrentThreadId(), new MS.Win32.NativeMethods.EnumThreadWindowsCallback(this.ThreadWindowsCallback), MS.Win32.NativeMethods.NullHandleRef);
      this.EnableThreadWindows(false);
      if (SafeNativeMethods.GetCapture() != IntPtr.Zero)
        SafeNativeMethods.ReleaseCapture();
      this.EnsureDialogCommand();
      try
      {
        this._showingAsDialog = true;
        this.Show();
      }
      catch
      {
        if (this._threadWindowHandles != null)
          this.EnableThreadWindows(true);
        if (this._dialogPreviousActiveHandle != IntPtr.Zero && MS.Win32.UnsafeNativeMethods.IsWindow(new HandleRef((object) null, this._dialogPreviousActiveHandle)))
          MS.Win32.UnsafeNativeMethods.TrySetFocus(new HandleRef((object) null, this._dialogPreviousActiveHandle), ref this._dialogPreviousActiveHandle);
        this.ClearShowKeyboardCueState();
        this._showingAsDialog = false;
        throw;
      }
      finally
      {
        this._showingAsDialog = false;
      }
      return this._dialogResult;
    }

    [SecurityCritical]
    public bool Activate()
    {
      this.VerifyApiSupported();
      SecurityHelper.DemandUIWindowPermission();
      this.VerifyContextAndObjectState();
      this.VerifyHwndCreateShowState();
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return false;
      else
        return MS.Win32.UnsafeNativeMethods.SetForegroundWindow(new HandleRef((object) null, this.CriticalHandle));
    }

    public static Window GetWindow(DependencyObject dependencyObject)
    {
      if (dependencyObject == null)
        throw new ArgumentNullException("dependencyObject");
      else
        return dependencyObject.GetValue(Window.IWindowServiceProperty) as Window;
    }

    protected override AutomationPeer OnCreateAutomationPeer()
    {
      return (AutomationPeer) new WindowAutomationPeer(this);
    }

    protected internal override sealed void OnVisualParentChanged(DependencyObject oldParent)
    {
      this.VerifyContextAndObjectState();
      base.OnVisualParentChanged(oldParent);
      if (VisualTreeHelper.GetParent((DependencyObject) this) != null)
        throw new InvalidOperationException(System.Windows.SR.Get("WindowMustBeRoot"));
    }

    protected override Size MeasureOverride(Size availableSize)
    {
      this.VerifyContextAndObjectState();
      Size constraint = new Size(availableSize.Width, availableSize.Height);
      Window.WindowMinMax windowMinMax = this.GetWindowMinMax();
      constraint.Width = Math.Max(windowMinMax.minWidth, Math.Min(constraint.Width, windowMinMax.maxWidth));
      constraint.Height = Math.Max(windowMinMax.minHeight, Math.Min(constraint.Height, windowMinMax.maxHeight));
      Size size = this.MeasureOverrideHelper(constraint);
      size = new Size(Math.Max(size.Width, windowMinMax.minWidth), Math.Max(size.Height, windowMinMax.minHeight));
      return size;
    }

    protected override Size ArrangeOverride(Size arrangeBounds)
    {
      this.VerifyContextAndObjectState();
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid || this.VisualChildrenCount <= 0)
        return arrangeBounds;
      UIElement element = this.GetVisualChild(0) as UIElement;
      if (element != null)
      {
        Size sizeInMeasureUnits = this.GetHwndNonClientAreaSizeInMeasureUnits();
        Size size = new Size();
        size.Width = Math.Max(0.0, arrangeBounds.Width - sizeInMeasureUnits.Width);
        size.Height = Math.Max(0.0, arrangeBounds.Height - sizeInMeasureUnits.Height);
        element.Arrange(new Rect(size));
        if (this.FlowDirection == FlowDirection.RightToLeft)
          FrameworkElement.InternalSetLayoutTransform(element, (Transform) new MatrixTransform(-1.0, 0.0, 0.0, 1.0, size.Width, 0.0));
      }
      return arrangeBounds;
    }

    protected override void OnContentChanged(object oldContent, object newContent)
    {
      base.OnContentChanged(oldContent, newContent);
      this.SetIWindowService();
      if (this.IsLoaded)
      {
        this.PostContentRendered();
      }
      else
      {
        if (this._postContentRenderedFromLoadedHandler)
          return;
        this.Loaded += new RoutedEventHandler(this.LoadedHandler);
        this._postContentRenderedFromLoadedHandler = true;
      }
    }

    protected virtual void OnSourceInitialized(EventArgs e)
    {
      this.VerifyContextAndObjectState();
      EventHandler eventHandler = (EventHandler) this.Events[Window.EVENT_SOURCEINITIALIZED];
      if (eventHandler == null)
        return;
      eventHandler((object) this, e);
    }

    protected virtual void OnActivated(EventArgs e)
    {
      this.VerifyContextAndObjectState();
      EventHandler eventHandler = (EventHandler) this.Events[Window.EVENT_ACTIVATED];
      if (eventHandler == null)
        return;
      eventHandler((object) this, e);
    }

    protected virtual void OnDeactivated(EventArgs e)
    {
      this.VerifyContextAndObjectState();
      EventHandler eventHandler = (EventHandler) this.Events[Window.EVENT_DEACTIVATED];
      if (eventHandler == null)
        return;
      eventHandler((object) this, e);
    }

    protected virtual void OnStateChanged(EventArgs e)
    {
      this.VerifyContextAndObjectState();
      EventHandler eventHandler = (EventHandler) this.Events[Window.EVENT_STATECHANGED];
      if (eventHandler == null)
        return;
      eventHandler((object) this, e);
    }

    protected virtual void OnLocationChanged(EventArgs e)
    {
      this.VerifyContextAndObjectState();
      EventHandler eventHandler = (EventHandler) this.Events[Window.EVENT_LOCATIONCHANGED];
      if (eventHandler == null)
        return;
      eventHandler((object) this, e);
    }

    protected virtual void OnClosing(CancelEventArgs e)
    {
      this.VerifyContextAndObjectState();
      CancelEventHandler cancelEventHandler = (CancelEventHandler) this.Events[Window.EVENT_CLOSING];
      if (cancelEventHandler == null)
        return;
      cancelEventHandler((object) this, e);
    }

    protected virtual void OnClosed(EventArgs e)
    {
      this.VerifyContextAndObjectState();
      EventHandler eventHandler = (EventHandler) this.Events[Window.EVENT_CLOSED];
      if (eventHandler == null)
        return;
      eventHandler((object) this, e);
    }

    protected virtual void OnContentRendered(EventArgs e)
    {
      this.VerifyContextAndObjectState();
      DependencyObject element = this.Content as DependencyObject;
      if (element != null)
      {
        IInputElement focusedElement = FocusManager.GetFocusedElement(element);
        if (focusedElement != null)
          focusedElement.Focus();
      }
      EventHandler eventHandler = (EventHandler) this.Events[Window.EVENT_CONTENTRENDERED];
      if (eventHandler == null)
        return;
      eventHandler((object) this, e);
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    internal Point DeviceToLogicalUnits(Point ptDeviceUnits)
    {
      Invariant.Assert(!this.IsCompositionTargetInvalid, "IsCompositionTargetInvalid is supposed to be false here");
      return this._swh.CompositionTarget.TransformFromDevice.Transform(ptDeviceUnits);
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    internal Point LogicalToDeviceUnits(Point ptLogicalUnits)
    {
      Invariant.Assert(!this.IsCompositionTargetInvalid, "IsCompositionTargetInvalid is supposed to be false here");
      return this._swh.CompositionTarget.TransformToDevice.Transform(ptLogicalUnits);
    }

    internal static bool VisibilityToBool(Visibility v)
    {
      switch (v)
      {
        case Visibility.Visible:
          return true;
        case Visibility.Hidden:
        case Visibility.Collapsed:
          return false;
        default:
          return false;
      }
    }

    internal virtual void SetResizeGripControl(Control ctrl)
    {
      this._resizeGripControl = ctrl;
    }

    internal virtual void ClearResizeGripControl(Control oldCtrl)
    {
      if (oldCtrl != this._resizeGripControl)
        return;
      this._resizeGripControl = (Control) null;
    }

    internal virtual void TryClearingMainWindow()
    {
      if (!this.IsInsideApp || this != this.App.MainWindow)
        return;
      this.App.MainWindow = (Window) null;
    }

    [SecurityCritical]
    internal void InternalClose(bool shutdown, bool ignoreCancel)
    {
      this.VerifyNotClosing();
      if (this._disposed)
        return;
      this._appShuttingDown = shutdown;
      this._ignoreCancel = ignoreCancel;
      if (this.IsSourceWindowNull)
      {
        this._isClosing = true;
        CancelEventArgs e = new CancelEventArgs(false);
        try
        {
          this.OnClosing(e);
        }
        catch
        {
          this.CloseWindowBeforeShow();
          throw;
        }
        if (this.ShouldCloseWindow(e.Cancel))
          this.CloseWindowBeforeShow();
        else
          this._isClosing = false;
      }
      else
        MS.Win32.UnsafeNativeMethods.UnsafeSendMessage(this.CriticalHandle, WindowMessage.WM_CLOSE, new IntPtr(), new IntPtr());
    }

    internal override void OnAncestorChanged()
    {
      base.OnAncestorChanged();
      if (this.Parent != null)
        throw new InvalidOperationException(System.Windows.SR.Get("WindowMustBeRoot"));
    }

    internal virtual void CreateAllStyle()
    {
      this._Style = 34078720;
      this._StyleEx = 0;
      this.CreateWindowStyle();
      this.CreateWindowState();
      if (this._isVisible)
        this._Style |= 268435456;
      this.SetTaskbarStatus();
      this.CreateTopmost();
      this.CreateResizibility();
      this.CreateRtl();
    }

    [SecurityCritical]
    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal virtual void CreateSourceWindowDuringShow()
    {
      this.CreateSourceWindow(true);
    }

    [SecurityCritical]
    internal void CreateSourceWindow(bool duringShow)
    {
      this.VerifyContextAndObjectState();
      this.VerifyCanShow();
      this.VerifyNotClosing();
      this.VerifyConsistencyWithAllowsTransparency();
      if (!duringShow)
        this.VerifyApiSupported();
      double requestedTop = 0.0;
      double requestedLeft = 0.0;
      double requestedWidth = 0.0;
      double requestedHeight = 0.0;
      this.GetRequestedDimensions(ref requestedLeft, ref requestedTop, ref requestedWidth, ref requestedHeight);
      using (Window.HwndStyleManager hwndStyleManager = Window.HwndStyleManager.StartManaging(this, this.StyleFromHwnd, this.StyleExFromHwnd))
      {
        this.CreateAllStyle();
        HwndSource sourceWindow = new HwndSource(this.CreateHwndSourceParameters());
        this._swh = new Window.SourceWindowHelper(sourceWindow);
        sourceWindow.SizeToContentChanged += new EventHandler(this.OnSourceSizeToContentChanged);
        hwndStyleManager.Dirty = false;
        this.CorrectStyleForBorderlessWindowCase();
      }
      this._swh.AddDisposedHandler(new EventHandler(this.OnSourceWindowDisposed));
      this._hwndCreatedButNotShown = !duringShow;
      if (Utilities.IsOSWindows7OrNewer)
      {
        MSGFLTINFO extStatus;
        MS.Win32.UnsafeNativeMethods.ChangeWindowMessageFilterEx(this._swh.CriticalHandle, Window.WM_TASKBARBUTTONCREATED, MSGFLT.ALLOW, out extStatus);
        MS.Win32.UnsafeNativeMethods.ChangeWindowMessageFilterEx(this._swh.CriticalHandle, WindowMessage.WM_COMMAND, MSGFLT.ALLOW, out extStatus);
      }
      this.SetupInitialState(requestedTop, requestedLeft, requestedWidth, requestedHeight);
      this.OnSourceInitialized(EventArgs.Empty);
    }

    [SecurityCritical]
    internal virtual HwndSourceParameters CreateHwndSourceParameters()
    {
      return new HwndSourceParameters(this.Title, int.MaxValue, int.MaxValue)
      {
        UsesPerPixelOpacity = this.AllowsTransparency,
        WindowStyle = this._Style,
        ExtendedWindowStyle = this._StyleEx,
        ParentWindow = this._ownerHandle,
        AdjustSizingForNonClientArea = true,
        HwndSourceHook = new HwndSourceHook(this.WindowFilterMessage)
      };
    }

    internal virtual void CorrectStyleForBorderlessWindowCase()
    {
      using (Window.HwndStyleManager.StartManaging(this, this.StyleFromHwnd, this.StyleExFromHwnd))
      {
        if (this.WindowStyle != WindowStyle.None)
          return;
        this._Style = this._swh.StyleFromHwnd;
        this._Style &= -12582913;
      }
    }

    internal virtual void GetRequestedDimensions(ref double requestedLeft, ref double requestedTop, ref double requestedWidth, ref double requestedHeight)
    {
      requestedTop = this.Top;
      requestedLeft = this.Left;
      requestedWidth = this.Width;
      requestedHeight = this.Height;
    }

    [SecurityCritical]
    internal virtual void SetupInitialState(double requestedTop, double requestedLeft, double requestedWidth, double requestedHeight)
    {
      this.HwndSourceSizeToContent = (SizeToContent) this.GetValue(Window.SizeToContentProperty);
      this.UpdateIcon();
      MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
      Size currentSizeDeviceUnits = new Size((double) (windowBounds.right - windowBounds.left), (double) (windowBounds.bottom - windowBounds.top));
      double leftDeviceUnits = (double) windowBounds.left;
      double topDeviceUnits = (double) windowBounds.top;
      bool flag = false;
      Point point1 = this.DeviceToLogicalUnits(new Point(leftDeviceUnits, topDeviceUnits));
      this._actualLeft = point1.X;
      this._actualTop = point1.Y;
      try
      {
        this._updateHwndLocation = false;
        this.CoerceValue(Window.TopProperty);
        this.CoerceValue(Window.LeftProperty);
      }
      finally
      {
        this._updateHwndLocation = true;
      }
      Point point2 = this.LogicalToDeviceUnits(new Point(requestedWidth, requestedHeight));
      Point point3 = this.LogicalToDeviceUnits(new Point(requestedLeft, requestedTop));
      if (!DoubleUtil.IsNaN(requestedWidth) && !DoubleUtil.AreClose(currentSizeDeviceUnits.Width, point2.X))
      {
        flag = true;
        currentSizeDeviceUnits.Width = point2.X;
        if (this.WindowState != WindowState.Normal)
          this.UpdateHwndRestoreBounds(requestedWidth, Window.BoundsSpecified.Width);
      }
      if (!DoubleUtil.IsNaN(requestedHeight) && !DoubleUtil.AreClose(currentSizeDeviceUnits.Height, point2.Y))
      {
        flag = true;
        currentSizeDeviceUnits.Height = point2.Y;
        if (this.WindowState != WindowState.Normal)
          this.UpdateHwndRestoreBounds(requestedHeight, Window.BoundsSpecified.Height);
      }
      if (!DoubleUtil.IsNaN(requestedLeft) && !DoubleUtil.AreClose(leftDeviceUnits, point3.X))
      {
        flag = true;
        leftDeviceUnits = point3.X;
        if (this.WindowState != WindowState.Normal)
          this.UpdateHwndRestoreBounds(requestedLeft, Window.BoundsSpecified.Left);
      }
      if (!DoubleUtil.IsNaN(requestedTop) && !DoubleUtil.AreClose(topDeviceUnits, point3.Y))
      {
        flag = true;
        topDeviceUnits = point3.Y;
        if (this.WindowState != WindowState.Normal)
          this.UpdateHwndRestoreBounds(requestedTop, Window.BoundsSpecified.Top);
      }
      Point point4 = this.LogicalToDeviceUnits(new Point(this.MinWidth, this.MinHeight));
      Point point5 = this.LogicalToDeviceUnits(new Point(this.MaxWidth, this.MaxHeight));
      if (!double.IsPositiveInfinity(point5.X) && currentSizeDeviceUnits.Width > point5.X)
      {
        flag = true;
        currentSizeDeviceUnits.Width = point5.X;
      }
      if (!double.IsPositiveInfinity(point4.Y) && currentSizeDeviceUnits.Height > point5.Y)
      {
        flag = true;
        currentSizeDeviceUnits.Height = point5.Y;
      }
      if (currentSizeDeviceUnits.Width < point4.X)
      {
        flag = true;
        currentSizeDeviceUnits.Width = point4.X;
      }
      if (currentSizeDeviceUnits.Height < point4.Y)
      {
        flag = true;
        currentSizeDeviceUnits.Height = point4.Y;
      }
      if ((this.CalculateWindowLocation(ref leftDeviceUnits, ref topDeviceUnits, currentSizeDeviceUnits) || flag) && this.WindowState == WindowState.Normal)
      {
        MS.Win32.UnsafeNativeMethods.SetWindowPos(new HandleRef((object) this, this.CriticalHandle), new HandleRef((object) null, IntPtr.Zero), DoubleUtil.DoubleToInt(leftDeviceUnits), DoubleUtil.DoubleToInt(topDeviceUnits), DoubleUtil.DoubleToInt(currentSizeDeviceUnits.Width), DoubleUtil.DoubleToInt(currentSizeDeviceUnits.Height), 20);
        try
        {
          this._updateHwndLocation = false;
          this._updateStartupLocation = true;
          this.CoerceValue(Window.TopProperty);
          this.CoerceValue(Window.LeftProperty);
        }
        finally
        {
          this._updateHwndLocation = true;
          this._updateStartupLocation = false;
        }
      }
      if (this.HwndCreatedButNotShown)
        return;
      this.SetRootVisualAndUpdateSTC();
    }

    [SecurityCritical]
    internal void SetRootVisual()
    {
      this.SetIWindowService();
      if (this.IsSourceWindowNull)
        return;
      this._swh.RootVisual = (Visual) this;
    }

    [SecurityCritical]
    internal void SetRootVisualAndUpdateSTC()
    {
      this.SetRootVisual();
      if (this.IsSourceWindowNull || this.SizeToContent == SizeToContent.Manual && !this.HwndCreatedButNotShown)
        return;
      MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
      double leftDeviceUnits = (double) windowBounds.left;
      double topDeviceUnits = (double) windowBounds.top;
      Point point = this.LogicalToDeviceUnits(new Point(this.ActualWidth, this.ActualHeight));
      if (!this.CalculateWindowLocation(ref leftDeviceUnits, ref topDeviceUnits, new Size(point.X, point.Y)) || this.WindowState != WindowState.Normal)
        return;
      MS.Win32.UnsafeNativeMethods.SetWindowPos(new HandleRef((object) this, this.CriticalHandle), new HandleRef((object) null, IntPtr.Zero), DoubleUtil.DoubleToInt(leftDeviceUnits), DoubleUtil.DoubleToInt(topDeviceUnits), 0, 0, 21);
      try
      {
        this._updateHwndLocation = false;
        this._updateStartupLocation = true;
        this.CoerceValue(Window.TopProperty);
        this.CoerceValue(Window.LeftProperty);
      }
      finally
      {
        this._updateHwndLocation = true;
        this._updateStartupLocation = false;
      }
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    internal virtual void UpdateTitle(string title)
    {
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      MS.Win32.UnsafeNativeMethods.SetWindowText(new HandleRef((object) this, this.CriticalHandle), title);
    }

    internal void HandleActivate(bool windowActivated)
    {
      if (windowActivated && !this.IsActive)
      {
        this.SetValue(Window.IsActivePropertyKey, BooleanBoxes.TrueBox);
        this.OnActivated(EventArgs.Empty);
      }
      else
      {
        if (windowActivated || !this.IsActive)
          return;
        this.SetValue(Window.IsActivePropertyKey, BooleanBoxes.FalseBox);
        this.OnDeactivated(EventArgs.Empty);
      }
    }

    internal virtual void UpdateHeight(double newHeight)
    {
      if (this.WindowState == WindowState.Normal)
        this.UpdateHwndSizeOnWidthHeightChange(this.DeviceToLogicalUnits(new Point((double) this.WindowBounds.Width, 0.0)).X, newHeight);
      else
        this.UpdateHwndRestoreBounds(newHeight, Window.BoundsSpecified.Height);
    }

    internal virtual void UpdateWidth(double newWidth)
    {
      if (this.WindowState == WindowState.Normal)
      {
        Point point = this.DeviceToLogicalUnits(new Point(0.0, (double) this.WindowBounds.Height));
        this.UpdateHwndSizeOnWidthHeightChange(newWidth, point.Y);
      }
      else
        this.UpdateHwndRestoreBounds(newWidth, Window.BoundsSpecified.Width);
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    internal virtual void VerifyApiSupported()
    {
    }

    internal virtual Window.WindowMinMax GetWindowMinMax()
    {
      Window.WindowMinMax windowMinMax = new Window.WindowMinMax();
      Invariant.Assert(!this.IsCompositionTargetInvalid, "IsCompositionTargetInvalid is supposed to be false here");
      Point point1 = this.DeviceToLogicalUnits(new Point(this._trackMaxWidthDeviceUnits, this._trackMaxHeightDeviceUnits));
      Point point2 = this.DeviceToLogicalUnits(new Point(this._trackMinWidthDeviceUnits, this._trackMinHeightDeviceUnits));
      windowMinMax.minWidth = Math.Max(this.MinWidth, point2.X);
      windowMinMax.maxWidth = this.MinWidth <= this.MaxWidth ? (double.IsPositiveInfinity(this.MaxWidth) ? point1.X : Math.Min(this.MaxWidth, point1.X)) : Math.Min(this.MinWidth, point1.X);
      windowMinMax.minHeight = Math.Max(this.MinHeight, point2.Y);
      windowMinMax.maxHeight = this.MinHeight <= this.MaxHeight ? (double.IsPositiveInfinity(this.MaxHeight) ? point1.Y : Math.Min(this.MaxHeight, point1.Y)) : Math.Min(this.MinHeight, point1.Y);
      return windowMinMax;
    }

    internal void VerifyContextAndObjectState()
    {
      this.VerifyAccess();
    }

    [SecurityCritical]
    internal static void CalculateCenterScreenPosition(IntPtr hMonitor, Size currentSizeDeviceUnits, ref double leftDeviceUnits, ref double topDeviceUnits)
    {
      MS.Win32.NativeMethods.RECT rect = Window.WorkAreaBoundsForMointor(hMonitor);
      double num1 = (double) (rect.right - rect.left);
      double num2 = (double) (rect.bottom - rect.top);
      leftDeviceUnits = (double) rect.left + (num1 - currentSizeDeviceUnits.Width) / 2.0;
      topDeviceUnits = (double) rect.top + (num2 - currentSizeDeviceUnits.Height) / 2.0;
    }

    internal virtual void WmMoveChangedHelper()
    {
      if (this.WindowState != WindowState.Normal)
        return;
      try
      {
        this._updateHwndLocation = false;
        this.SetValue(Window.LeftProperty, (object) this._actualLeft);
        this.SetValue(Window.TopProperty, (object) this._actualTop);
      }
      finally
      {
        this._updateHwndLocation = true;
      }
      this.OnLocationChanged(EventArgs.Empty);
    }

    internal virtual bool HandleWmNcHitTestMsg(IntPtr lParam, ref IntPtr refInt)
    {
      if (this._resizeGripControl == null || this.ResizeMode != ResizeMode.CanResizeWithGrip)
        return false;
      MS.Win32.NativeMethods.POINT relativeToWindow = this.GetPointRelativeToWindow(MS.Win32.NativeMethods.SignedLOWORD(lParam), MS.Win32.NativeMethods.SignedHIWORD(lParam));
      Point inPoint = this.DeviceToLogicalUnits(new Point((double) relativeToWindow.x, (double) relativeToWindow.y));
      GeneralTransform generalTransform = this.TransformToDescendant((Visual) this._resizeGripControl);
      Point result = inPoint;
      if (generalTransform == null || !generalTransform.TryTransform(inPoint, out result) || (result.X < 0.0 || result.Y < 0.0) || result.X > this._resizeGripControl.RenderSize.Width || result.Y > this._resizeGripControl.RenderSize.Height)
        return false;
      refInt = this.FlowDirection != FlowDirection.RightToLeft ? new IntPtr(17) : new IntPtr(16);
      return true;
    }

    internal virtual int nCmdForShow()
    {
      int num;
      switch (this.WindowState)
      {
        case WindowState.Minimized:
          num = this.ShowActivated ? 2 : 7;
          break;
        case WindowState.Maximized:
          num = 3;
          break;
        default:
          num = this.ShowActivated ? 5 : 8;
          break;
      }
      return num;
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    internal void Flush()
    {
      Window.HwndStyleManager manager = this.Manager;
      if (!manager.Dirty || !(this.CriticalHandle != IntPtr.Zero))
        return;
      MS.Win32.UnsafeNativeMethods.CriticalSetWindowLong(new HandleRef((object) this, this.CriticalHandle), -16, (IntPtr) this._styleDoNotUse.Value);
      MS.Win32.UnsafeNativeMethods.CriticalSetWindowLong(new HandleRef((object) this, this.CriticalHandle), -20, (IntPtr) this._styleExDoNotUse.Value);
      MS.Win32.UnsafeNativeMethods.SetWindowPos(new HandleRef((object) this, this.CriticalHandle), MS.Win32.NativeMethods.NullHandleRef, 0, 0, 0, 0, 55);
      manager.Dirty = false;
    }

    protected override void OnManipulationBoundaryFeedback(ManipulationBoundaryFeedbackEventArgs e)
    {
      base.OnManipulationBoundaryFeedback(e);
      if (!PresentationSource.UnderSamePresentationSource(e.OriginalSource as DependencyObject, (DependencyObject) this) || e.Handled)
        return;
      if ((this._currentPanningTarget == null || !this._currentPanningTarget.IsAlive || this._currentPanningTarget.Target != e.OriginalSource) && this._swh != null)
      {
        MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
        this._prePanningLocation = this.DeviceToLogicalUnits(new Point((double) windowBounds.left, (double) windowBounds.top));
      }
      this.UpdatePanningFeedback(e.BoundaryFeedback.Translation, e.OriginalSource);
      e.CompensateForBoundaryFeedback = new Func<Point, Point>(this.CompensateForPanningFeedback);
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    private void OnTaskbarItemInfoChanged(DependencyPropertyChangedEventArgs e)
    {
      TaskbarItemInfo taskbarItemInfo1 = (TaskbarItemInfo) e.OldValue;
      TaskbarItemInfo taskbarItemInfo2 = (TaskbarItemInfo) e.NewValue;
      if (!Utilities.IsOSWindows7OrNewer || e.IsASubPropertyChange)
        return;
      if (taskbarItemInfo1 != null)
        taskbarItemInfo1.PropertyChanged -= new DependencyPropertyChangedEventHandler(this.OnTaskbarItemInfoSubPropertyChanged);
      if (taskbarItemInfo2 != null)
        taskbarItemInfo2.PropertyChanged += new DependencyPropertyChangedEventHandler(this.OnTaskbarItemInfoSubPropertyChanged);
      this.ApplyTaskbarItemInfo();
    }

    [SecurityCritical]
    private void HandleTaskbarListError(MS.Internal.Interop.HRESULT hr)
    {
      if (!hr.Failed)
        return;
      if (hr == (MS.Internal.Interop.HRESULT) Win32Error.ERROR_TIMEOUT)
      {
        if (TraceShell.IsEnabled)
        {
          TraceShell.Trace(TraceEventType.Error, TraceShell.ExplorerTaskbarTimeout);
          TraceShell.Trace(TraceEventType.Warning, TraceShell.ExplorerTaskbarRetrying);
        }
        this._taskbarRetryTimer.Start();
      }
      else if (hr == (MS.Internal.Interop.HRESULT) Win32Error.ERROR_INVALID_WINDOW_HANDLE)
      {
        if (TraceShell.IsEnabled)
          TraceShell.Trace(TraceEventType.Warning, TraceShell.ExplorerTaskbarNotRunning);
        Utilities.SafeRelease<ITaskbarList3>(ref this._taskbarList);
      }
      else
      {
        if (!TraceShell.IsEnabled)
          return;
        TraceShell.Trace(TraceEventType.Error, TraceShell.NativeTaskbarError(new object[1]
        {
          (object) hr.ToString()
        }));
      }
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private void OnTaskbarItemInfoSubPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      if (sender != this.TaskbarItemInfo || this._taskbarList == null || this._taskbarRetryTimer != null && this._taskbarRetryTimer.IsEnabled)
        return;
      DependencyProperty property = e.Property;
      MS.Internal.Interop.HRESULT hr = MS.Internal.Interop.HRESULT.S_OK;
      if (property == TaskbarItemInfo.ProgressStateProperty)
        hr = this.UpdateTaskbarProgressState();
      else if (property == TaskbarItemInfo.ProgressValueProperty)
        hr = this.UpdateTaskbarProgressValue();
      else if (property == TaskbarItemInfo.OverlayProperty)
        hr = this.UpdateTaskbarOverlay();
      else if (property == TaskbarItemInfo.DescriptionProperty)
        hr = this.UpdateTaskbarDescription();
      else if (property == TaskbarItemInfo.ThumbnailClipMarginProperty)
        hr = this.UpdateTaskbarThumbnailClipping();
      else if (property == TaskbarItemInfo.ThumbButtonInfosProperty)
        hr = this.UpdateTaskbarThumbButtons();
      this.HandleTaskbarListError(hr);
    }

    private static void OnAllowsTransparencyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    }

    private static object CoerceAllowsTransparency(DependencyObject d, object value)
    {
      value = Window.VerifyAccessCoercion(d, value);
      if (!((Window) d).IsSourceWindowNull)
        throw new InvalidOperationException(System.Windows.SR.Get("ChangeNotAllowedAfterShow"));
      else
        return value;
    }

    private static object CoerceWindowStyle(DependencyObject d, object value)
    {
      value = Window.VerifyAccessCoercion(d, value);
      if (!((Window) d).IsSourceWindowNull)
        ((Window) d).VerifyConsistencyWithAllowsTransparency((WindowStyle) value);
      return value;
    }

    [SecurityCritical]
    private void CloseWindowBeforeShow()
    {
      this.InternalDispose();
      this.OnClosed(EventArgs.Empty);
    }

    [SecurityCritical]
    private void InternalDispose()
    {
      this._disposed = true;
      this.UpdateWindowListsOnClose();
      if (this._taskbarRetryTimer != null)
      {
        this._taskbarRetryTimer.Stop();
        this._taskbarRetryTimer = (DispatcherTimer) null;
      }
      try
      {
        this.ClearSourceWindow();
        Utilities.SafeDispose<HwndSource>(ref this._hiddenWindow);
        Utilities.SafeDispose<MS.Win32.NativeMethods.IconHandle>(ref this._defaultLargeIconHandle);
        Utilities.SafeDispose<MS.Win32.NativeMethods.IconHandle>(ref this._defaultSmallIconHandle);
        Utilities.SafeDispose<MS.Win32.NativeMethods.IconHandle>(ref this._currentLargeIconHandle);
        Utilities.SafeDispose<MS.Win32.NativeMethods.IconHandle>(ref this._currentSmallIconHandle);
        Utilities.SafeRelease<ITaskbarList3>(ref this._taskbarList);
      }
      finally
      {
        this._isClosing = false;
      }
    }

    private void OnSourceSizeToContentChanged(object sender, EventArgs args)
    {
      this.SizeToContent = this.HwndSourceSizeToContent;
    }

    private void CreateWindowStyle()
    {
      this._Style &= -12582913;
      this._StyleEx &= -641;
      switch (this.WindowStyle)
      {
        case WindowStyle.None:
          this._Style &= -12582913;
          break;
        case WindowStyle.SingleBorderWindow:
          this._Style |= 12582912;
          break;
        case WindowStyle.ThreeDBorderWindow:
          this._Style |= 12582912;
          this._StyleEx |= 512;
          break;
        case WindowStyle.ToolWindow:
          this._Style |= 12582912;
          this._StyleEx |= 128;
          break;
      }
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    private void UpdateHwndSizeOnWidthHeightChange(double widthLogicalUnits, double heightLogicalUnits)
    {
      if (!this._inTrustedSubWindow)
        SecurityHelper.DemandUIWindowPermission();
      Point point = this.LogicalToDeviceUnits(new Point(widthLogicalUnits, heightLogicalUnits));
      MS.Win32.UnsafeNativeMethods.SetWindowPos(new HandleRef((object) this, this.CriticalHandle), new HandleRef((object) null, IntPtr.Zero), 0, 0, DoubleUtil.DoubleToInt(point.X), DoubleUtil.DoubleToInt(point.Y), 22);
    }

    private Size MeasureOverrideHelper(Size constraint)
    {
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return new Size(0.0, 0.0);
      if (this.VisualChildrenCount > 0)
      {
        UIElement uiElement = this.GetVisualChild(0) as UIElement;
        if (uiElement != null)
        {
          Size sizeInMeasureUnits = this.GetHwndNonClientAreaSizeInMeasureUnits();
          uiElement.Measure(new Size()
          {
            Width = constraint.Width == double.PositiveInfinity ? double.PositiveInfinity : Math.Max(0.0, constraint.Width - sizeInMeasureUnits.Width),
            Height = constraint.Height == double.PositiveInfinity ? double.PositiveInfinity : Math.Max(0.0, constraint.Height - sizeInMeasureUnits.Height)
          });
          Size desiredSize = uiElement.DesiredSize;
          return new Size(desiredSize.Width + sizeInMeasureUnits.Width, desiredSize.Height + sizeInMeasureUnits.Height);
        }
      }
      return this._swh.GetSizeFromHwndInMeasureUnits();
    }

    private void LoadedHandler(object sender, RoutedEventArgs e)
    {
      if (!this._postContentRenderedFromLoadedHandler)
        return;
      this.PostContentRendered();
      this._postContentRenderedFromLoadedHandler = false;
      this.Loaded -= new RoutedEventHandler(this.LoadedHandler);
    }

    private void PostContentRendered()
    {
      if (this._contentRenderedCallback != null)
        this._contentRenderedCallback.Abort();
      this._contentRenderedCallback = this.Dispatcher.BeginInvoke(DispatcherPriority.Input, (Delegate) (unused =>
      {
        this._contentRenderedCallback = (DispatcherOperation) null;
        this.OnContentRendered(EventArgs.Empty);
        return (object) null;
      }), (object) this);
    }

    private void EnsureDialogCommand()
    {
      if (Window._dialogCommandAdded)
        return;
      CommandBinding commandBinding = new CommandBinding((ICommand) Window.DialogCancelCommand);
      commandBinding.Executed += new ExecutedRoutedEventHandler(Window.OnDialogCommand);
      CommandManager.RegisterClassCommandBinding(typeof (Window), commandBinding);
      Window._dialogCommandAdded = true;
    }

    private static void OnDialogCommand(object target, ExecutedRoutedEventArgs e)
    {
      (target as Window).OnDialogCancelCommand();
    }

    private void OnDialogCancelCommand()
    {
      if (!this._showingAsDialog)
        return;
      this.DialogResult = new bool?(false);
    }

    private bool ThreadWindowsCallback(IntPtr hWnd, IntPtr lparam)
    {
      if (SafeNativeMethods.IsWindowVisible(new HandleRef((object) null, hWnd)) && SafeNativeMethods.IsWindowEnabled(new HandleRef((object) null, hWnd)))
        this._threadWindowHandles.Add((object) hWnd);
      return true;
    }

    [SecurityCritical]
    private void EnableThreadWindows(bool state)
    {
      for (int index = 0; index < this._threadWindowHandles.Count; ++index)
      {
        IntPtr handle = (IntPtr) this._threadWindowHandles[index];
        if (MS.Win32.UnsafeNativeMethods.IsWindow(new HandleRef((object) null, handle)))
          MS.Win32.UnsafeNativeMethods.EnableWindowNoThrow(new HandleRef((object) null, handle), state);
      }
      if (!state)
        return;
      this._threadWindowHandles = (ArrayList) null;
    }

    private void Initialize()
    {
      this.BypassLayoutPolicies = true;
      if (!this.IsInsideApp)
        return;
      if (Application.Current.Dispatcher.Thread == Dispatcher.CurrentDispatcher.Thread)
      {
        this.App.WindowsInternal.Add(this);
        if (this.App.MainWindow != null)
          return;
        this.App.MainWindow = this;
      }
      else
        this.App.NonAppWindowsInternal.Add(this);
    }

    private void VerifyCanShow()
    {
      if (this._disposed)
        throw new InvalidOperationException(System.Windows.SR.Get("ReshowNotAllowed"));
    }

    private void VerifyNotClosing()
    {
      if (this._isClosing)
        throw new InvalidOperationException(System.Windows.SR.Get("InvalidOperationDuringClosing"));
      if (!this.IsSourceWindowNull && this.IsCompositionTargetInvalid)
        throw new InvalidOperationException(System.Windows.SR.Get("InvalidCompositionTarget"));
    }

    private void VerifyHwndCreateShowState()
    {
      if (this.HwndCreatedButNotShown)
        throw new InvalidOperationException(System.Windows.SR.Get("NotAllowedBeforeShow"));
    }

    private void SetIWindowService()
    {
      if (this.GetValue(Window.IWindowServiceProperty) != null)
        return;
      this.SetValue(Window.IWindowServiceProperty, (object) this);
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    private IntPtr GetCurrentMonitorFromMousePosition()
    {
      SecurityHelper.DemandUnmanagedCode();
      MS.Win32.NativeMethods.POINT pt = new MS.Win32.NativeMethods.POINT();
      MS.Win32.UnsafeNativeMethods.TryGetCursorPos(pt);
      return SafeNativeMethods.MonitorFromPoint(new MS.Win32.NativeMethods.POINTSTRUCT(pt.x, pt.y), 2);
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    private bool CalculateWindowLocation(ref double leftDeviceUnits, ref double topDeviceUnits, Size currentSizeDeviceUnits)
    {
      double num1 = leftDeviceUnits;
      double num2 = topDeviceUnits;
      switch (this._windowStartupLocation)
      {
        case WindowStartupLocation.CenterScreen:
          IntPtr num3 = IntPtr.Zero;
          IntPtr hMonitor = this._ownerHandle == IntPtr.Zero || this._hiddenWindow != null && this._hiddenWindow.Handle == this._ownerHandle ? this.GetCurrentMonitorFromMousePosition() : Window.MonitorFromWindow(this._ownerHandle);
          if (hMonitor != IntPtr.Zero)
          {
            Window.CalculateCenterScreenPosition(hMonitor, currentSizeDeviceUnits, ref leftDeviceUnits, ref topDeviceUnits);
            break;
          }
          else
            break;
        case WindowStartupLocation.CenterOwner:
          Rect rect1 = Rect.Empty;
          if (this.CanCenterOverWPFOwner)
          {
            if (this.Owner.WindowState != WindowState.Maximized && this.Owner.WindowState != WindowState.Minimized)
            {
              Point point1;
              if (this.Owner.CriticalHandle == IntPtr.Zero)
              {
                point1 = this.Owner.LogicalToDeviceUnits(new Point(this.Owner.Width, this.Owner.Height));
              }
              else
              {
                Size windowSize = this.Owner.WindowSize;
                point1 = new Point(windowSize.Width, windowSize.Height);
              }
              Point point2 = this.Owner.LogicalToDeviceUnits(new Point(this.Owner.Left, this.Owner.Top));
              rect1 = new Rect(point2.X, point2.Y, point1.X, point1.Y);
            }
            else
              goto case 1;
          }
          else if (this._ownerHandle != IntPtr.Zero && MS.Win32.UnsafeNativeMethods.IsWindow(new HandleRef((object) null, this._ownerHandle)))
            rect1 = this.GetNormalRectDeviceUnits(this._ownerHandle);
          if (!rect1.IsEmpty)
          {
            leftDeviceUnits = rect1.X + (rect1.Width - currentSizeDeviceUnits.Width) / 2.0;
            topDeviceUnits = rect1.Y + (rect1.Height - currentSizeDeviceUnits.Height) / 2.0;
            MS.Win32.NativeMethods.RECT rect2 = Window.WorkAreaBoundsForHwnd(this._ownerHandle);
            leftDeviceUnits = Math.Min(leftDeviceUnits, (double) rect2.right - currentSizeDeviceUnits.Width);
            leftDeviceUnits = Math.Max(leftDeviceUnits, (double) rect2.left);
            topDeviceUnits = Math.Min(topDeviceUnits, (double) rect2.bottom - currentSizeDeviceUnits.Height);
            topDeviceUnits = Math.Max(topDeviceUnits, (double) rect2.top);
            break;
          }
          else
            break;
      }
      if (DoubleUtil.AreClose(num1, leftDeviceUnits))
        return !DoubleUtil.AreClose(num2, topDeviceUnits);
      else
        return true;
    }

    [SecurityCritical]
    private static MS.Win32.NativeMethods.RECT WorkAreaBoundsForHwnd(IntPtr hwnd)
    {
      return Window.WorkAreaBoundsForMointor(Window.MonitorFromWindow(hwnd));
    }

    [SecurityCritical]
    private static MS.Win32.NativeMethods.RECT WorkAreaBoundsForMointor(IntPtr hMonitor)
    {
      MS.Win32.NativeMethods.MONITORINFOEX info = new MS.Win32.NativeMethods.MONITORINFOEX();
      SafeNativeMethods.GetMonitorInfo(new HandleRef((object) null, hMonitor), info);
      return info.rcWork;
    }

    [SecurityCritical]
    private static IntPtr MonitorFromWindow(IntPtr hwnd)
    {
      IntPtr num = SafeNativeMethods.MonitorFromWindow(new HandleRef((object) null, hwnd), 2);
      if (num == IntPtr.Zero)
        throw new Win32Exception();
      else
        return num;
    }

    [SecurityCritical]
    private Rect GetNormalRectDeviceUnits(IntPtr hwndHandle)
    {
      int windowLong = MS.Win32.UnsafeNativeMethods.GetWindowLong(new HandleRef((object) this, hwndHandle), -20);
      MS.Win32.NativeMethods.WINDOWPLACEMENT placement = new MS.Win32.NativeMethods.WINDOWPLACEMENT();
      placement.length = Marshal.SizeOf(typeof (MS.Win32.NativeMethods.WINDOWPLACEMENT));
      MS.Win32.UnsafeNativeMethods.GetWindowPlacement(new HandleRef((object) this, hwndHandle), ref placement);
      Point pt = new Point((double) placement.rcNormalPosition_left, (double) placement.rcNormalPosition_top);
      if ((windowLong & 128) == 0)
        pt = this.TransformWorkAreaScreenArea(pt, Window.TransformType.WorkAreaToScreenArea);
      Point point = new Point((double) (placement.rcNormalPosition_right - placement.rcNormalPosition_left), (double) (placement.rcNormalPosition_bottom - placement.rcNormalPosition_top));
      return new Rect(pt.X, pt.Y, point.X, point.Y);
    }

    [SecurityCritical]
    private Rect GetNormalRectLogicalUnits(IntPtr hwndHandle)
    {
      Rect normalRectDeviceUnits = this.GetNormalRectDeviceUnits(hwndHandle);
      Point point1 = this.DeviceToLogicalUnits(new Point(normalRectDeviceUnits.Width, normalRectDeviceUnits.Height));
      Point point2 = this.DeviceToLogicalUnits(new Point(normalRectDeviceUnits.X, normalRectDeviceUnits.Y));
      return new Rect(point2.X, point2.Y, point1.X, point1.Y);
    }

    private void CreateWindowState()
    {
      switch (this.WindowState)
      {
        case WindowState.Minimized:
          this._Style |= 536870912;
          break;
        case WindowState.Maximized:
          this._Style |= 16777216;
          break;
      }
    }

    private void CreateTopmost()
    {
      if (this.Topmost)
        this._StyleEx |= 8;
      else
        this._StyleEx &= -9;
    }

    private void CreateResizibility()
    {
      this._Style &= -458753;
      switch (this.ResizeMode)
      {
        case ResizeMode.CanMinimize:
          this._Style |= 131072;
          break;
        case ResizeMode.CanResize:
        case ResizeMode.CanResizeWithGrip:
          this._Style |= 458752;
          break;
      }
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    private void UpdateIcon()
    {
      MS.Win32.NativeMethods.IconHandle largeIconHandle;
      MS.Win32.NativeMethods.IconHandle smallIconHandle;
      if (this._icon != null)
        IconHelper.GetIconHandlesFromImageSource(this._icon, out largeIconHandle, out smallIconHandle);
      else if (this._defaultLargeIconHandle == null && this._defaultSmallIconHandle == null)
      {
        IconHelper.GetDefaultIconHandles(out largeIconHandle, out smallIconHandle);
        this._defaultLargeIconHandle = largeIconHandle;
        this._defaultSmallIconHandle = smallIconHandle;
      }
      else
      {
        largeIconHandle = this._defaultLargeIconHandle;
        smallIconHandle = this._defaultSmallIconHandle;
      }
      HandleRef[] handleRefArray = new HandleRef[2]
      {
        new HandleRef((object) this, this.CriticalHandle),
        new HandleRef()
      };
      int num = 1;
      if (this._hiddenWindow != null)
      {
        handleRefArray[1] = new HandleRef((object) this._hiddenWindow, this._hiddenWindow.CriticalHandle);
        ++num;
      }
      for (int index = 0; index < num; ++index)
      {
        HandleRef hWnd = handleRefArray[index];
        MS.Win32.UnsafeNativeMethods.SendMessage(hWnd, WindowMessage.WM_SETICON, (IntPtr) 1, largeIconHandle);
        MS.Win32.UnsafeNativeMethods.SendMessage(hWnd, WindowMessage.WM_SETICON, (IntPtr) 0, smallIconHandle);
      }
      if (this._currentLargeIconHandle != null && this._currentLargeIconHandle != this._defaultLargeIconHandle)
        this._currentLargeIconHandle.Dispose();
      if (this._currentSmallIconHandle != null && this._currentSmallIconHandle != this._defaultSmallIconHandle)
        this._currentSmallIconHandle.Dispose();
      this._currentLargeIconHandle = largeIconHandle;
      this._currentSmallIconHandle = smallIconHandle;
    }

    [SecurityCritical]
    private void SetOwnerHandle(IntPtr ownerHandle)
    {
      if (this._ownerHandle == ownerHandle && this._ownerHandle == IntPtr.Zero)
        return;
      this._ownerHandle = !(IntPtr.Zero == ownerHandle) || this.ShowInTaskbar ? ownerHandle : this.EnsureHiddenWindow().CriticalHandle;
      if (this.IsSourceWindowNull)
        return;
      MS.Win32.UnsafeNativeMethods.SetWindowLong(new HandleRef((object) null, this.CriticalHandle), -8, this._ownerHandle);
      if (this._ownerWindow == null || !(this._ownerWindow.CriticalHandle != this._ownerHandle))
        return;
      this._ownerWindow.OwnedWindowsInternal.Remove(this);
      this._ownerWindow = (Window) null;
    }

    [SecurityCritical]
    private void OnSourceWindowDisposed(object sender, EventArgs e)
    {
      if (this._disposed)
        return;
      this.InternalDispose();
    }

    [SecurityCritical]
    private IntPtr WindowFilterMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
      IntPtr refInt = IntPtr.Zero;
      WindowMessage windowMessage = (WindowMessage) msg;
      switch (windowMessage)
      {
        case WindowMessage.WM_SIZE:
          handled = this.WmSizeChanged(wParam);
          break;
        case WindowMessage.WM_GETMINMAXINFO:
          handled = this.WmGetMinMaxInfo(lParam);
          break;
      }
      if (this._swh != null && this._swh.CompositionTarget != null)
      {
        if (windowMessage == Window.WM_TASKBARBUTTONCREATED || windowMessage == Window.WM_APPLYTASKBARITEMINFO)
        {
          if (this._taskbarRetryTimer != null)
            this._taskbarRetryTimer.Stop();
          this.ApplyTaskbarItemInfo();
        }
        else
        {
          switch (windowMessage)
          {
            case WindowMessage.WM_SHOWWINDOW:
              handled = this.WmShowWindow(wParam, lParam);
              break;
            case WindowMessage.WM_NCHITTEST:
              handled = this.WmNcHitTest(lParam, ref refInt);
              break;
            case WindowMessage.WM_COMMAND:
              handled = this.WmCommand(wParam, lParam);
              break;
            case WindowMessage.WM_DESTROY:
              handled = this.WmDestroy();
              break;
            case WindowMessage.WM_MOVE:
              handled = this.WmMoveChanged();
              break;
            case WindowMessage.WM_ACTIVATE:
              handled = this.WmActivate(wParam);
              break;
            case WindowMessage.WM_CLOSE:
              handled = this.WmClose();
              break;
            default:
              handled = false;
              break;
          }
        }
      }
      return refInt;
    }

    private bool WmCommand(IntPtr wParam, IntPtr lParam)
    {
      if (MS.Win32.NativeMethods.SignedHIWORD(wParam.ToInt32()) != 6144)
        return false;
      TaskbarItemInfo taskbarItemInfo = this.TaskbarItemInfo;
      if (taskbarItemInfo != null)
      {
        int index = MS.Win32.NativeMethods.SignedLOWORD(wParam.ToInt32());
        if (index >= 0 && index < taskbarItemInfo.ThumbButtonInfos.Count)
          taskbarItemInfo.ThumbButtonInfos[index].InvokeClick();
      }
      return true;
    }

    private bool WmClose()
    {
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return false;
      this._isClosing = true;
      CancelEventArgs e = new CancelEventArgs(false);
      try
      {
        this.OnClosing(e);
      }
      catch
      {
        this.CloseWindowFromWmClose();
        throw;
      }
      if (this.ShouldCloseWindow(e.Cancel))
      {
        this.CloseWindowFromWmClose();
        return false;
      }
      else
      {
        this._isClosing = false;
        this._dialogResult = new bool?();
        return true;
      }
    }

    private void CloseWindowFromWmClose()
    {
      if (this._showingAsDialog)
        this.DoDialogHide();
      this.ClearRootVisual();
      this.ClearHiddenWindowIfAny();
    }

    private bool ShouldCloseWindow(bool cancelled)
    {
      if (cancelled && !this._appShuttingDown)
        return this._ignoreCancel;
      else
        return true;
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private void DoDialogHide()
    {
      SecurityHelper.DemandUnmanagedCode();
      if (this._dispatcherFrame != null)
      {
        this._dispatcherFrame.Continue = false;
        this._dispatcherFrame = (DispatcherFrame) null;
      }
      if (!this._dialogResult.HasValue)
        this._dialogResult = new bool?(false);
      this._showingAsDialog = false;
      bool isActiveWindow = this._swh.IsActiveWindow;
      this.EnableThreadWindows(true);
      if (!isActiveWindow || !(this._dialogPreviousActiveHandle != IntPtr.Zero) || !MS.Win32.UnsafeNativeMethods.IsWindow(new HandleRef((object) this, this._dialogPreviousActiveHandle)))
        return;
      MS.Win32.UnsafeNativeMethods.SetActiveWindow(new HandleRef((object) this, this._dialogPreviousActiveHandle));
    }

    [SecurityCritical]
    private void UpdateWindowListsOnClose()
    {
      WindowCollection ownedWindowsInternal = this.OwnedWindowsInternal;
      while (ownedWindowsInternal.Count > 0)
        ownedWindowsInternal[0].InternalClose(false, true);
      if (!this.IsOwnerNull)
        this.Owner.OwnedWindowsInternal.Remove(this);
      if (!this.IsInsideApp)
        return;
      if (Application.Current.Dispatcher.Thread == Dispatcher.CurrentDispatcher.Thread)
      {
        this.App.WindowsInternal.Remove(this);
        if (!this._appShuttingDown && (this.App.Windows.Count == 0 && this.App.ShutdownMode == ShutdownMode.OnLastWindowClose || this.App.MainWindow == this && this.App.ShutdownMode == ShutdownMode.OnMainWindowClose))
          this.App.CriticalShutdown(0);
        this.TryClearingMainWindow();
      }
      else
        this.App.NonAppWindowsInternal.Remove(this);
    }

    [SecurityCritical]
    private bool WmDestroy()
    {
      if (this.IsSourceWindowNull)
        return false;
      if (!this._disposed)
        this.InternalDispose();
      this.OnClosed(EventArgs.Empty);
      return false;
    }

    private bool WmActivate(IntPtr wParam)
    {
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return false;
      this.HandleActivate(MS.Win32.NativeMethods.SignedLOWORD(wParam) != 0 && true);
      return false;
    }

    private void UpdateDimensionsToRestoreBounds()
    {
      Rect restoreBounds = this.RestoreBounds;
      this.SetValue(Window.LeftProperty, (object) restoreBounds.Left);
      this.SetValue(Window.TopProperty, (object) restoreBounds.Top);
      this.SetValue(FrameworkElement.WidthProperty, (object) restoreBounds.Width);
      this.SetValue(FrameworkElement.HeightProperty, (object) restoreBounds.Height);
    }

    private bool WmSizeChanged(IntPtr wParam)
    {
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return false;
      MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
      Point point = this.DeviceToLogicalUnits(new Point((double) (windowBounds.right - windowBounds.left), (double) (windowBounds.bottom - windowBounds.top)));
      try
      {
        this._updateHwndSize = false;
        this.SetValue(FrameworkElement.WidthProperty, (object) point.X);
        this.SetValue(FrameworkElement.HeightProperty, (object) point.Y);
      }
      finally
      {
        this._updateHwndSize = true;
      }
      this.UpdateTaskbarThumbnailClipping();
      switch ((int) wParam)
      {
        case 0:
          if (this._previousWindowState != WindowState.Normal)
          {
            if (this.WindowState != WindowState.Normal)
            {
              this.WindowState = WindowState.Normal;
              this.WmMoveChangedHelper();
            }
            this._previousWindowState = WindowState.Normal;
            this.OnStateChanged(EventArgs.Empty);
            break;
          }
          else
            break;
        case 1:
          if (this._previousWindowState != WindowState.Minimized)
          {
            if (this.WindowState != WindowState.Minimized)
            {
              try
              {
                this._updateHwndSize = false;
                this._updateHwndLocation = false;
                this.UpdateDimensionsToRestoreBounds();
              }
              finally
              {
                this._updateHwndSize = true;
                this._updateHwndLocation = true;
              }
              this.WindowState = WindowState.Minimized;
            }
            this._previousWindowState = WindowState.Minimized;
            this.OnStateChanged(EventArgs.Empty);
            break;
          }
          else
            break;
        case 2:
          if (this._previousWindowState != WindowState.Maximized)
          {
            if (this.WindowState != WindowState.Maximized)
            {
              try
              {
                this._updateHwndLocation = false;
                this._updateHwndSize = false;
                this.UpdateDimensionsToRestoreBounds();
              }
              finally
              {
                this._updateHwndSize = true;
                this._updateHwndLocation = true;
              }
              this.WindowState = WindowState.Maximized;
            }
            this._previousWindowState = WindowState.Maximized;
            this.OnStateChanged(EventArgs.Empty);
            break;
          }
          else
            break;
      }
      return false;
    }

    [SecurityCritical]
    private bool WmMoveChanged()
    {
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return false;
      if (!this._inTrustedSubWindow)
        SecurityHelper.DemandUIWindowPermission();
      MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
      Point point = this.DeviceToLogicalUnits(new Point((double) windowBounds.left, (double) windowBounds.top));
      if (!DoubleUtil.AreClose(this._actualLeft, point.X) || !DoubleUtil.AreClose(this._actualTop, point.Y))
      {
        this._actualLeft = point.X;
        this._actualTop = point.Y;
        this.WmMoveChangedHelper();
        AutomationPeer automationPeer = UIElementAutomationPeer.FromElement((UIElement) this);
        if (automationPeer != null)
          automationPeer.InvalidatePeer();
      }
      return false;
    }

    [SecurityCritical]
    private bool WmGetMinMaxInfo(IntPtr lParam)
    {
      MS.Win32.NativeMethods.MINMAXINFO minmaxinfo = (MS.Win32.NativeMethods.MINMAXINFO) MS.Win32.UnsafeNativeMethods.PtrToStructure(lParam, typeof (MS.Win32.NativeMethods.MINMAXINFO));
      this._trackMinWidthDeviceUnits = (double) minmaxinfo.ptMinTrackSize.x;
      this._trackMinHeightDeviceUnits = (double) minmaxinfo.ptMinTrackSize.y;
      this._trackMaxWidthDeviceUnits = (double) minmaxinfo.ptMaxTrackSize.x;
      this._trackMaxHeightDeviceUnits = (double) minmaxinfo.ptMaxTrackSize.y;
      if (!this.IsSourceWindowNull && !this.IsCompositionTargetInvalid)
      {
        Window.WindowMinMax windowMinMax = this.GetWindowMinMax();
        Point point1 = this.LogicalToDeviceUnits(new Point(windowMinMax.minWidth, windowMinMax.minHeight));
        Point point2 = this.LogicalToDeviceUnits(new Point(windowMinMax.maxWidth, windowMinMax.maxHeight));
        minmaxinfo.ptMinTrackSize.x = DoubleUtil.DoubleToInt(point1.X);
        minmaxinfo.ptMinTrackSize.y = DoubleUtil.DoubleToInt(point1.Y);
        minmaxinfo.ptMaxTrackSize.x = DoubleUtil.DoubleToInt(point2.X);
        minmaxinfo.ptMaxTrackSize.y = DoubleUtil.DoubleToInt(point2.Y);
        Marshal.StructureToPtr((object) minmaxinfo, lParam, true);
      }
      return true;
    }

    private bool WmNcHitTest(IntPtr lParam, ref IntPtr refInt)
    {
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return false;
      else
        return this.HandleWmNcHitTestMsg(lParam, ref refInt);
    }

    private bool WmShowWindow(IntPtr wParam, IntPtr lParam)
    {
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return false;
      switch (MS.Win32.NativeMethods.IntPtrToInt32(lParam))
      {
        case 1:
          this._isVisible = false;
          this.UpdateVisibilityProperty(Visibility.Hidden);
          break;
        case 3:
          this._isVisible = true;
          this.UpdateVisibilityProperty(Visibility.Visible);
          break;
      }
      return false;
    }

    private static void _OnIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((Window) d).OnIconChanged(e.NewValue as ImageSource);
    }

    private void OnIconChanged(ImageSource newIcon)
    {
      this._icon = newIcon;
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      this.UpdateIcon();
    }

    private static void _OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((Window) d).OnTitleChanged();
    }

    private static bool _ValidateText(object value)
    {
      return value != null;
    }

    private void OnTitleChanged()
    {
      this.UpdateTitle(this.Title);
    }

    private static void _OnShowInTaskbarChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((Window) d).OnShowInTaskbarChanged();
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    private void OnShowInTaskbarChanged()
    {
      if (!this._inTrustedSubWindow)
        SecurityHelper.DemandUIWindowPermission();
      this.VerifyApiSupported();
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      bool flag = false;
      if (this._isVisible)
      {
        MS.Win32.UnsafeNativeMethods.SetWindowPos(new HandleRef((object) this, this.CriticalHandle), MS.Win32.NativeMethods.NullHandleRef, 0, 0, 0, 0, 1175);
        flag = true;
      }
      using (Window.HwndStyleManager.StartManaging(this, this.StyleFromHwnd, this.StyleExFromHwnd))
        this.SetTaskbarStatus();
      if (!flag)
        return;
      MS.Win32.UnsafeNativeMethods.SetWindowPos(new HandleRef((object) this, this.CriticalHandle), MS.Win32.NativeMethods.NullHandleRef, 0, 0, 0, 0, 1111);
    }

    private static bool _ValidateWindowStateCallback(object value)
    {
      return Window.IsValidWindowState((WindowState) value);
    }

    private static void _OnWindowStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((Window) d).OnWindowStateChanged((WindowState) e.NewValue);
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    private void OnWindowStateChanged(WindowState windowState)
    {
      SecurityHelper.DemandUIWindowPermission();
      if (!this.IsSourceWindowNull && !this.IsCompositionTargetInvalid)
      {
        if (this._isVisible)
        {
          HandleRef hWnd = new HandleRef((object) this, this.CriticalHandle);
          int style = this._Style;
          switch (windowState)
          {
            case WindowState.Normal:
              if ((style & 16777216) == 16777216)
              {
                if (this.ShowActivated || this.IsActive)
                {
                  MS.Win32.UnsafeNativeMethods.ShowWindow(hWnd, 9);
                  break;
                }
                else
                {
                  MS.Win32.UnsafeNativeMethods.ShowWindow(hWnd, 4);
                  break;
                }
              }
              else if ((style & 536870912) == 536870912)
              {
                MS.Win32.NativeMethods.WINDOWPLACEMENT placement = new MS.Win32.NativeMethods.WINDOWPLACEMENT();
                placement.length = Marshal.SizeOf((object) placement);
                MS.Win32.UnsafeNativeMethods.GetWindowPlacement(hWnd, ref placement);
                if ((placement.flags & 2) == 2)
                {
                  MS.Win32.UnsafeNativeMethods.ShowWindow(hWnd, 9);
                  break;
                }
                else if (this.ShowActivated)
                {
                  MS.Win32.UnsafeNativeMethods.ShowWindow(hWnd, 9);
                  break;
                }
                else
                {
                  MS.Win32.UnsafeNativeMethods.ShowWindow(hWnd, 4);
                  break;
                }
              }
              else
                break;
            case WindowState.Minimized:
              if ((style & 536870912) != 536870912)
              {
                MS.Win32.UnsafeNativeMethods.ShowWindow(hWnd, 6);
                break;
              }
              else
                break;
            case WindowState.Maximized:
              if ((style & 16777216) != 16777216)
              {
                MS.Win32.UnsafeNativeMethods.ShowWindow(hWnd, 3);
                break;
              }
              else
                break;
          }
        }
      }
      else
        this._previousWindowState = windowState;
      try
      {
        this._updateHwndLocation = false;
        this.CoerceValue(Window.TopProperty);
        this.CoerceValue(Window.LeftProperty);
      }
      finally
      {
        this._updateHwndLocation = true;
      }
    }

    private static bool _ValidateWindowStyleCallback(object value)
    {
      return Window.IsValidWindowStyle((WindowStyle) value);
    }

    private static void _OnWindowStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((Window) d).OnWindowStyleChanged((WindowStyle) e.NewValue);
    }

    private void OnWindowStyleChanged(WindowStyle windowStyle)
    {
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      using (Window.HwndStyleManager.StartManaging(this, this.StyleFromHwnd, this.StyleExFromHwnd))
        this.CreateWindowStyle();
    }

    private static void _OnTopmostChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((Window) d).OnTopmostChanged((bool) e.NewValue);
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private void OnTopmostChanged(bool topmost)
    {
      SecurityHelper.DemandUIWindowPermission();
      this.VerifyApiSupported();
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      MS.Win32.UnsafeNativeMethods.SetWindowPos(new HandleRef((object) null, this.CriticalHandle), topmost ? MS.Win32.NativeMethods.HWND_TOPMOST : MS.Win32.NativeMethods.HWND_NOTOPMOST, 0, 0, 0, 0, 19);
    }

    private static object CoerceVisibility(DependencyObject d, object value)
    {
      Window window = (Window) d;
      if ((Visibility) value == Visibility.Visible)
      {
        window.VerifyCanShow();
        window.VerifyConsistencyWithAllowsTransparency();
        window.VerifyNotClosing();
        window.VerifyConsistencyWithShowActivated();
      }
      return value;
    }

    private static void _OnVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      Window window = (Window) d;
      window._isVisibilitySet = true;
      if (window._visibilitySetInternally)
        return;
      bool flag = Window.VisibilityToBool((Visibility) e.NewValue);
      window.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new DispatcherOperationCallback(window.ShowHelper), flag ? BooleanBoxes.TrueBox : BooleanBoxes.FalseBox);
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private void SafeCreateWindowDuringShow()
    {
      if (this.IsSourceWindowNull)
      {
        if (!this._inTrustedSubWindow)
          SecurityHelper.DemandUIWindowPermission();
        this.CreateSourceWindowDuringShow();
      }
      else
      {
        if (!this.HwndCreatedButNotShown)
          return;
        this.SetRootVisualAndUpdateSTC();
        this._hwndCreatedButNotShown = false;
      }
    }

    private void SetShowKeyboardCueState()
    {
      if (!KeyboardNavigation.IsKeyboardMostRecentInputDevice())
        return;
      this._previousKeyboardCuesProperty = (bool) this.GetValue(KeyboardNavigation.ShowKeyboardCuesProperty);
      this.SetValue(KeyboardNavigation.ShowKeyboardCuesProperty, BooleanBoxes.TrueBox);
      this._resetKeyboardCuesProperty = true;
    }

    private void ClearShowKeyboardCueState()
    {
      if (!this._resetKeyboardCuesProperty)
        return;
      this._resetKeyboardCuesProperty = false;
      this.SetValue(KeyboardNavigation.ShowKeyboardCuesProperty, BooleanBoxes.Box(this._previousKeyboardCuesProperty));
    }

    private void UpdateVisibilityProperty(Visibility value)
    {
      try
      {
        this._visibilitySetInternally = true;
        this.SetValue(UIElement.VisibilityProperty, (object) value);
      }
      finally
      {
        this._visibilitySetInternally = false;
      }
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private object ShowHelper(object booleanBox)
    {
      if (this._disposed)
        return (object) null;
      bool flag = (bool) booleanBox;
      this._isClosing = false;
      if (this._isVisible == flag)
        return (object) null;
      if (flag)
      {
        if (Application.IsShuttingDown)
          return (object) null;
        this.SetShowKeyboardCueState();
        this.SafeCreateWindowDuringShow();
        this._isVisible = true;
      }
      else
      {
        if (!this._inTrustedSubWindow)
          SecurityHelper.DemandUIWindowPermission();
        this.ClearShowKeyboardCueState();
        if (this._showingAsDialog)
          this.DoDialogHide();
        this._isVisible = false;
      }
      if (!this.IsSourceWindowNull)
      {
        MS.Win32.UnsafeNativeMethods.ShowWindow(new HandleRef((object) this, this.CriticalHandle), !flag ? 0 : this.nCmdForShow());
        this.SafeStyleSetter();
      }
      if (this._showingAsDialog)
      {
        if (this._isVisible)
        {
          try
          {
            ComponentDispatcher.PushModal();
            this._dispatcherFrame = new DispatcherFrame();
            Dispatcher.PushFrame(this._dispatcherFrame);
          }
          finally
          {
            ComponentDispatcher.PopModal();
          }
        }
      }
      return (object) null;
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    private void SafeStyleSetter()
    {
      new UIPermission(UIPermissionWindow.AllWindows).Assert();
      try
      {
        using (Window.HwndStyleManager.StartManaging(this, this.StyleFromHwnd, this.StyleExFromHwnd))
          this._Style = this._isVisible ? this._Style | 268435456 : this._Style;
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
    }

    private static bool _ValidateSizeToContentCallback(object value)
    {
      return Window.IsValidSizeToContent((SizeToContent) value);
    }

    private static object _SizeToContentGetValueOverride(DependencyObject d)
    {
      return (object) (d as Window).SizeToContent;
    }

    private static void _OnSizeToContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      (d as Window).OnSizeToContentChanged((SizeToContent) e.NewValue);
    }

    private void OnSizeToContentChanged(SizeToContent sizeToContent)
    {
      this.VerifyApiSupported();
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      this.HwndSourceSizeToContent = sizeToContent;
    }

    private static void ValidateLengthForHeightWidth(double l)
    {
      if (double.IsPositiveInfinity(l) || DoubleUtil.IsNaN(l) || l <= (double) int.MaxValue && l >= (double) int.MinValue)
        return;
      throw new ArgumentException(System.Windows.SR.Get("ValueNotBetweenInt32MinMax", new object[1]
      {
        (object) l
      }));
    }

    private static void ValidateTopLeft(double length)
    {
      if (double.IsPositiveInfinity(length) || double.IsNegativeInfinity(length))
      {
        throw new ArgumentException(System.Windows.SR.Get("InvalidValueForTopLeft", new object[1]
        {
          (object) length
        }));
      }
      else
      {
        if (length <= (double) int.MaxValue && length >= (double) int.MinValue)
          return;
        throw new ArgumentException(System.Windows.SR.Get("ValueNotBetweenInt32MinMax", new object[1]
        {
          (object) length
        }));
      }
    }

    private static void _OnHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      Window window = d as Window;
      if (!window._updateHwndSize)
        return;
      window.OnHeightChanged((double) e.NewValue);
    }

    private void OnHeightChanged(double height)
    {
      Window.ValidateLengthForHeightWidth(height);
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid || DoubleUtil.IsNaN(height))
        return;
      this.UpdateHeight(height);
    }

    private static void _OnMinHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      (d as Window).OnMinHeightChanged((double) e.NewValue);
    }

    private void OnMinHeightChanged(double minHeight)
    {
      this.VerifyApiSupported();
      Window.ValidateLengthForHeightWidth(minHeight);
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
      Point point = this.DeviceToLogicalUnits(new Point((double) windowBounds.Width, (double) windowBounds.Height));
      if (minHeight <= point.Y || this.WindowState != WindowState.Normal)
        return;
      this.UpdateHwndSizeOnWidthHeightChange(point.X, minHeight);
    }

    private static void _OnMaxHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      (d as Window).OnMaxHeightChanged((double) e.NewValue);
    }

    private void OnMaxHeightChanged(double maxHeight)
    {
      this.VerifyApiSupported();
      Window.ValidateLengthForHeightWidth(this.MaxHeight);
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
      Point point = this.DeviceToLogicalUnits(new Point((double) windowBounds.Width, (double) windowBounds.Height));
      if (maxHeight >= point.Y || this.WindowState != WindowState.Normal)
        return;
      this.UpdateHwndSizeOnWidthHeightChange(point.X, maxHeight);
    }

    private static void _OnWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      Window window = d as Window;
      if (!window._updateHwndSize)
        return;
      window.OnWidthChanged((double) e.NewValue);
    }

    private void OnWidthChanged(double width)
    {
      Window.ValidateLengthForHeightWidth(width);
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid || DoubleUtil.IsNaN(width))
        return;
      this.UpdateWidth(width);
    }

    private static void _OnMinWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      (d as Window).OnMinWidthChanged((double) e.NewValue);
    }

    private void OnMinWidthChanged(double minWidth)
    {
      this.VerifyApiSupported();
      Window.ValidateLengthForHeightWidth(minWidth);
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
      Point point = this.DeviceToLogicalUnits(new Point((double) windowBounds.Width, (double) windowBounds.Height));
      if (minWidth <= point.X || this.WindowState != WindowState.Normal)
        return;
      this.UpdateHwndSizeOnWidthHeightChange(minWidth, point.Y);
    }

    private static void _OnMaxWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      (d as Window).OnMaxWidthChanged((double) e.NewValue);
    }

    private void OnMaxWidthChanged(double maxWidth)
    {
      this.VerifyApiSupported();
      Window.ValidateLengthForHeightWidth(maxWidth);
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
      Point point = this.DeviceToLogicalUnits(new Point((double) windowBounds.Width, (double) windowBounds.Height));
      if (maxWidth >= point.X || this.WindowState != WindowState.Normal)
        return;
      this.UpdateHwndSizeOnWidthHeightChange(maxWidth, point.Y);
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private void UpdateHwndRestoreBounds(double newValue, Window.BoundsSpecified specifiedRestoreBounds)
    {
      SecurityHelper.DemandUIWindowPermission();
      MS.Win32.NativeMethods.WINDOWPLACEMENT placement = new MS.Win32.NativeMethods.WINDOWPLACEMENT();
      placement.length = Marshal.SizeOf(typeof (MS.Win32.NativeMethods.WINDOWPLACEMENT));
      MS.Win32.UnsafeNativeMethods.GetWindowPlacement(new HandleRef((object) this, this.CriticalHandle), ref placement);
      double x1 = this.LogicalToDeviceUnits(new Point(newValue, 0.0)).X;
      switch (specifiedRestoreBounds)
      {
        case Window.BoundsSpecified.Height:
          placement.rcNormalPosition_bottom = placement.rcNormalPosition_top + DoubleUtil.DoubleToInt(x1);
          break;
        case Window.BoundsSpecified.Width:
          placement.rcNormalPosition_right = placement.rcNormalPosition_left + DoubleUtil.DoubleToInt(x1);
          break;
        case Window.BoundsSpecified.Top:
          double y1 = newValue;
          if ((this.StyleExFromHwnd & 128) == 0)
            y1 = this.TransformWorkAreaScreenArea(new Point(0.0, y1), Window.TransformType.ScreenAreaToWorkArea).Y;
          double y2 = this.LogicalToDeviceUnits(new Point(0.0, y1)).Y;
          int num1 = placement.rcNormalPosition_bottom - placement.rcNormalPosition_top;
          placement.rcNormalPosition_top = DoubleUtil.DoubleToInt(y2);
          placement.rcNormalPosition_bottom = placement.rcNormalPosition_top + num1;
          break;
        case Window.BoundsSpecified.Left:
          double x2 = newValue;
          if ((this.StyleExFromHwnd & 128) == 0)
            x2 = this.TransformWorkAreaScreenArea(new Point(x2, 0.0), Window.TransformType.ScreenAreaToWorkArea).X;
          double x3 = this.LogicalToDeviceUnits(new Point(x2, 0.0)).X;
          int num2 = placement.rcNormalPosition_right - placement.rcNormalPosition_left;
          placement.rcNormalPosition_left = DoubleUtil.DoubleToInt(x3);
          placement.rcNormalPosition_right = placement.rcNormalPosition_left + num2;
          break;
      }
      if (!this._isVisible)
        placement.showCmd = 0;
      MS.Win32.UnsafeNativeMethods.SetWindowPlacement(new HandleRef((object) this, this.CriticalHandle), ref placement);
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private Point TransformWorkAreaScreenArea(Point pt, Window.TransformType transformType)
    {
      int num1 = 0;
      int num2 = 0;
      if (!this._inTrustedSubWindow)
        SecurityHelper.DemandUIWindowPermission();
      IntPtr handle = SafeNativeMethods.MonitorFromWindow(new HandleRef((object) this, this.CriticalHandle), 0);
      if (handle != IntPtr.Zero)
      {
        MS.Win32.NativeMethods.MONITORINFOEX info = new MS.Win32.NativeMethods.MONITORINFOEX();
        info.cbSize = Marshal.SizeOf(typeof (MS.Win32.NativeMethods.MONITORINFOEX));
        SafeNativeMethods.GetMonitorInfo(new HandleRef((object) this, handle), info);
        MS.Win32.NativeMethods.RECT rect1 = info.rcWork;
        MS.Win32.NativeMethods.RECT rect2 = info.rcMonitor;
        num1 = rect1.left - rect2.left;
        num2 = rect1.top - rect2.top;
      }
      return transformType != Window.TransformType.WorkAreaToScreenArea ? new Point(pt.X - (double) num1, pt.Y - (double) num2) : new Point(pt.X + (double) num1, pt.Y + (double) num2);
    }

    private static object CoerceTop(DependencyObject d, object value)
    {
      Window window = d as Window;
      window.VerifyApiSupported();
      double num = (double) value;
      Window.ValidateTopLeft(num);
      if (window.IsSourceWindowNull || window.IsCompositionTargetInvalid)
        return value;
      if (double.IsNaN(num))
        return (object) window._actualTop;
      if (window.WindowState != WindowState.Normal || !window._updateStartupLocation || window.WindowStartupLocation == WindowStartupLocation.Manual)
        return value;
      else
        return (object) window._actualTop;
    }

    private static void _OnTopChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      Window window = d as Window;
      if (!window._updateHwndLocation)
        return;
      window.OnTopChanged((double) e.NewValue);
    }

    private void OnTopChanged(double newTop)
    {
      if (!this.IsSourceWindowNull && !this.IsCompositionTargetInvalid)
      {
        if (DoubleUtil.IsNaN(newTop))
          return;
        if (this.WindowState == WindowState.Normal)
        {
          Invariant.Assert(!double.IsNaN(this._actualLeft), "_actualLeft cannot be NaN after show");
          this.UpdateHwndPositionOnTopLeftChange(double.IsNaN(this.Left) ? this._actualLeft : this.Left, newTop);
        }
        else
          this.UpdateHwndRestoreBounds(newTop, Window.BoundsSpecified.Top);
      }
      else
        this._actualTop = newTop;
    }

    private static object CoerceLeft(DependencyObject d, object value)
    {
      Window window = d as Window;
      window.VerifyApiSupported();
      double num = (double) value;
      Window.ValidateTopLeft(num);
      if (window.IsSourceWindowNull || window.IsCompositionTargetInvalid)
        return value;
      if (double.IsNaN(num))
        return (object) window._actualLeft;
      if (window.WindowState != WindowState.Normal || !window._updateStartupLocation || window.WindowStartupLocation == WindowStartupLocation.Manual)
        return value;
      else
        return (object) window._actualLeft;
    }

    private static void _OnLeftChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      Window window = d as Window;
      if (!window._updateHwndLocation)
        return;
      window.OnLeftChanged((double) e.NewValue);
    }

    private void OnLeftChanged(double newLeft)
    {
      if (!this.IsSourceWindowNull && !this.IsCompositionTargetInvalid)
      {
        if (DoubleUtil.IsNaN(newLeft))
          return;
        if (this.WindowState == WindowState.Normal)
        {
          Invariant.Assert(!double.IsNaN(this._actualTop), "_actualTop cannot be NaN after show");
          this.UpdateHwndPositionOnTopLeftChange(newLeft, double.IsNaN(this.Top) ? this._actualTop : this.Top);
        }
        else
          this.UpdateHwndRestoreBounds(newLeft, Window.BoundsSpecified.Left);
      }
      else
        this._actualLeft = newLeft;
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    private void UpdateHwndPositionOnTopLeftChange(double leftLogicalUnits, double topLogicalUnits)
    {
      SecurityHelper.DemandUIWindowPermission();
      Point point = this.LogicalToDeviceUnits(new Point(leftLogicalUnits, topLogicalUnits));
      MS.Win32.UnsafeNativeMethods.SetWindowPos(new HandleRef((object) this, this.CriticalHandle), new HandleRef((object) null, IntPtr.Zero), DoubleUtil.DoubleToInt(point.X), DoubleUtil.DoubleToInt(point.Y), 0, 0, 21);
    }

    private static bool _ValidateResizeModeCallback(object value)
    {
      return Window.IsValidResizeMode((ResizeMode) value);
    }

    private static void _OnResizeModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      (d as Window).OnResizeModeChanged();
    }

    private void OnResizeModeChanged()
    {
      this.VerifyApiSupported();
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      using (Window.HwndStyleManager.StartManaging(this, this.StyleFromHwnd, this.StyleExFromHwnd))
        this.CreateResizibility();
    }

    private static object VerifyAccessCoercion(DependencyObject d, object value)
    {
      ((Window) d).VerifyApiSupported();
      return value;
    }

    private static void _OnFlowDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      (d as Window).OnFlowDirectionChanged();
    }

    private void OnFlowDirectionChanged()
    {
      if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid)
        return;
      using (Window.HwndStyleManager.StartManaging(this, this.StyleFromHwnd, this.StyleExFromHwnd))
        this.CreateRtl();
    }

    private static object CoerceRenderTransform(DependencyObject d, object value)
    {
      Transform transform = (Transform) value;
      if (value != null)
      {
        if (transform != null)
        {
          Matrix matrix = transform.Value;
          if (transform.Value.IsIdentity)
            goto label_4;
        }
        throw new InvalidOperationException(System.Windows.SR.Get("TransformNotSupported"));
      }
label_4:
      return value;
    }

    private static void _OnRenderTransformChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    }

    private static object CoerceClipToBounds(DependencyObject d, object value)
    {
      if ((bool) value)
        throw new InvalidOperationException(System.Windows.SR.Get("ClipToBoundsNotSupported"));
      else
        return value;
    }

    private static void _OnClipToBoundsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    }

    [SecurityCritical]
    private HwndSource EnsureHiddenWindow()
    {
      if (this._hiddenWindow == null)
      {
        HwndSourceParameters parameters = new HwndSourceParameters("Hidden Window");
        parameters.SetSize(int.MaxValue, int.MaxValue);
        parameters.SetPosition(int.MaxValue, int.MaxValue);
        parameters.WindowStyle = 13565952;
        this._hiddenWindow = new HwndSource(parameters);
      }
      return this._hiddenWindow;
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private void SetTaskbarStatus()
    {
      if (!this.ShowInTaskbar)
      {
        SecurityHelper.DemandUIWindowPermission();
        this.EnsureHiddenWindow();
        if (this._ownerHandle == IntPtr.Zero)
        {
          this.SetOwnerHandle(this._hiddenWindow.Handle);
          if (!this.IsSourceWindowNull && !this.IsCompositionTargetInvalid)
            this.UpdateIcon();
        }
        this._StyleEx &= -262145;
      }
      else
      {
        this._StyleEx |= 262144;
        if (this.IsSourceWindowNull || this._hiddenWindow == null || !(this._ownerHandle == this._hiddenWindow.Handle))
          return;
        this.SetOwnerHandle(IntPtr.Zero);
      }
    }

    [SecurityCritical]
    private void OnTaskbarRetryTimerTick(object sender, EventArgs e)
    {
      MS.Win32.UnsafeNativeMethods.PostMessage(new HandleRef((object) this, this.CriticalHandle), Window.WM_APPLYTASKBARITEMINFO, IntPtr.Zero, IntPtr.Zero);
    }

    [SecurityCritical]
    private void ApplyTaskbarItemInfo()
    {
      if (!Utilities.IsOSWindows7OrNewer)
      {
        if (!TraceShell.IsEnabled)
          return;
        TraceShell.Trace(TraceEventType.Warning, TraceShell.NotOnWindows7);
      }
      else
      {
        if (this.IsSourceWindowNull || this.IsCompositionTargetInvalid || this._taskbarRetryTimer != null && this._taskbarRetryTimer.IsEnabled)
          return;
        if (this._taskbarList == null)
        {
          if (this.TaskbarItemInfo == null)
            return;
          ITaskbarList comObject = (ITaskbarList) null;
          try
          {
            comObject = (ITaskbarList) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("56FDF344-FD6D-11d0-958A-006097C9A090")));
            comObject.HrInit();
            this._taskbarList = (ITaskbarList3) comObject;
            comObject = (ITaskbarList) null;
          }
          finally
          {
            Utilities.SafeRelease<ITaskbarList>(ref comObject);
          }
          this._overlaySize = new Size((double) MS.Win32.UnsafeNativeMethods.GetSystemMetrics(SM.CXSMICON), (double) MS.Win32.UnsafeNativeMethods.GetSystemMetrics(SM.CYSMICON));
          if (this._taskbarRetryTimer == null)
          {
            this._taskbarRetryTimer = new DispatcherTimer()
            {
              Interval = new TimeSpan(0, 1, 0)
            };
            this._taskbarRetryTimer.Tick += new EventHandler(this.OnTaskbarRetryTimerTick);
          }
        }
        MS.Internal.Interop.HRESULT hresult = MS.Internal.Interop.HRESULT.S_OK;
        MS.Internal.Interop.HRESULT hr = this.RegisterTaskbarThumbButtons();
        if (hr.Succeeded)
          hr = this.UpdateTaskbarProgressState();
        if (hr.Succeeded)
          hr = this.UpdateTaskbarOverlay();
        if (hr.Succeeded)
          hr = this.UpdateTaskbarDescription();
        if (hr.Succeeded)
          hr = this.UpdateTaskbarThumbnailClipping();
        if (hr.Succeeded)
          hr = this.UpdateTaskbarThumbButtons();
        this.HandleTaskbarListError(hr);
      }
    }

    [SecurityCritical]
    private MS.Internal.Interop.HRESULT UpdateTaskbarProgressState()
    {
      TaskbarItemInfo taskbarItemInfo = this.TaskbarItemInfo;
      TBPF tbpFlags = TBPF.NOPROGRESS;
      if (taskbarItemInfo != null)
      {
        switch (taskbarItemInfo.ProgressState)
        {
          case TaskbarItemProgressState.None:
            tbpFlags = TBPF.NOPROGRESS;
            break;
          case TaskbarItemProgressState.Indeterminate:
            tbpFlags = TBPF.INDETERMINATE;
            break;
          case TaskbarItemProgressState.Normal:
            tbpFlags = TBPF.NORMAL;
            break;
          case TaskbarItemProgressState.Error:
            tbpFlags = TBPF.ERROR;
            break;
          case TaskbarItemProgressState.Paused:
            tbpFlags = TBPF.PAUSED;
            break;
          default:
            tbpFlags = TBPF.NOPROGRESS;
            break;
        }
      }
      MS.Internal.Interop.HRESULT hresult = this._taskbarList.SetProgressState(this.CriticalHandle, tbpFlags);
      if (hresult.Succeeded)
        hresult = this.UpdateTaskbarProgressValue();
      return hresult;
    }

    [SecurityCritical]
    private MS.Internal.Interop.HRESULT UpdateTaskbarProgressValue()
    {
      TaskbarItemInfo taskbarItemInfo = this.TaskbarItemInfo;
      if (taskbarItemInfo == null || taskbarItemInfo.ProgressState == TaskbarItemProgressState.None || taskbarItemInfo.ProgressState == TaskbarItemProgressState.Indeterminate)
        return MS.Internal.Interop.HRESULT.S_OK;
      else
        return this._taskbarList.SetProgressValue(this.CriticalHandle, (ulong) (taskbarItemInfo.ProgressValue * 1000.0), 1000UL);
    }

    [SecurityCritical]
    private MS.Internal.Interop.HRESULT UpdateTaskbarOverlay()
    {
      TaskbarItemInfo taskbarItemInfo = this.TaskbarItemInfo;
      MS.Win32.NativeMethods.IconHandle hIcon = MS.Win32.NativeMethods.IconHandle.GetInvalidIcon();
      try
      {
        if (taskbarItemInfo != null && taskbarItemInfo.Overlay != null)
          hIcon = IconHelper.CreateIconHandleFromImageSource(taskbarItemInfo.Overlay, this._overlaySize);
        return this._taskbarList.SetOverlayIcon(this.CriticalHandle, hIcon, (string) null);
      }
      finally
      {
        hIcon.Dispose();
      }
    }

    [SecurityCritical]
    private MS.Internal.Interop.HRESULT UpdateTaskbarDescription()
    {
      TaskbarItemInfo taskbarItemInfo = this.TaskbarItemInfo;
      string pszTip = "";
      if (taskbarItemInfo != null)
        pszTip = taskbarItemInfo.Description ?? "";
      return this._taskbarList.SetThumbnailTooltip(this.CriticalHandle, pszTip);
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    private MS.Internal.Interop.HRESULT UpdateTaskbarThumbnailClipping()
    {
      if (this._taskbarList == null)
        return MS.Internal.Interop.HRESULT.S_OK;
      if (this._taskbarRetryTimer != null && this._taskbarRetryTimer.IsEnabled || MS.Win32.UnsafeNativeMethods.IsIconic(this.CriticalHandle))
        return MS.Internal.Interop.HRESULT.S_FALSE;
      TaskbarItemInfo taskbarItemInfo = this.TaskbarItemInfo;
      MS.Win32.NativeMethods.RefRECT prcClip = (MS.Win32.NativeMethods.RefRECT) null;
      if (taskbarItemInfo != null && !taskbarItemInfo.ThumbnailClipMargin.IsZero)
      {
        Thickness thumbnailClipMargin = taskbarItemInfo.ThumbnailClipMargin;
        MS.Win32.NativeMethods.RECT rect1 = new MS.Win32.NativeMethods.RECT();
        SafeNativeMethods.GetClientRect(new HandleRef((object) this, this.CriticalHandle), out rect1);
        Rect rect2 = new Rect(this.DeviceToLogicalUnits(new Point((double) rect1.left, (double) rect1.top)), this.DeviceToLogicalUnits(new Point((double) rect1.right, (double) rect1.bottom)));
        if (thumbnailClipMargin.Left + thumbnailClipMargin.Right >= rect2.Width || thumbnailClipMargin.Top + thumbnailClipMargin.Bottom >= rect2.Height)
        {
          prcClip = new MS.Win32.NativeMethods.RefRECT(0, 0, 0, 0);
        }
        else
        {
          Rect rect3 = new Rect(this.LogicalToDeviceUnits(new Point(thumbnailClipMargin.Left, thumbnailClipMargin.Top)), this.LogicalToDeviceUnits(new Point(rect2.Width - thumbnailClipMargin.Right, rect2.Height - thumbnailClipMargin.Bottom)));
          prcClip = new MS.Win32.NativeMethods.RefRECT((int) rect3.Left, (int) rect3.Top, (int) rect3.Right, (int) rect3.Bottom);
        }
      }
      return this._taskbarList.SetThumbnailClip(this.CriticalHandle, prcClip);
    }

    [SecurityCritical]
    private MS.Internal.Interop.HRESULT RegisterTaskbarThumbButtons()
    {
      THUMBBUTTON[] pButtons = new THUMBBUTTON[7];
      for (int index = 0; index < 7; ++index)
        pButtons[index] = new THUMBBUTTON()
        {
          iId = (uint) index,
          dwFlags = THBF.DISABLED | THBF.NOBACKGROUND | THBF.HIDDEN | THBF.NONINTERACTIVE,
          dwMask = THB.ICON | THB.TOOLTIP | THB.FLAGS
        };
      MS.Internal.Interop.HRESULT hresult = this._taskbarList.ThumbBarAddButtons(this.CriticalHandle, (uint) pButtons.Length, pButtons);
      if (hresult == MS.Internal.Interop.HRESULT.E_INVALIDARG)
        hresult = MS.Internal.Interop.HRESULT.S_FALSE;
      return hresult;
    }

    [SecurityCritical]
    private MS.Internal.Interop.HRESULT UpdateTaskbarThumbButtons()
    {
      THUMBBUTTON[] pButtons = new THUMBBUTTON[7];
      TaskbarItemInfo taskbarItemInfo = this.TaskbarItemInfo;
      ThumbButtonInfoCollection buttonInfoCollection = (ThumbButtonInfoCollection) null;
      if (taskbarItemInfo != null)
        buttonInfoCollection = taskbarItemInfo.ThumbButtonInfos;
      List<MS.Win32.NativeMethods.IconHandle> list = new List<MS.Win32.NativeMethods.IconHandle>();
      try
      {
        uint num1 = 0U;
        if (buttonInfoCollection != null)
        {
          foreach (ThumbButtonInfo thumbButtonInfo in (FreezableCollection<ThumbButtonInfo>) buttonInfoCollection)
          {
            THUMBBUTTON thumbbutton = new THUMBBUTTON()
            {
              iId = num1,
              dwMask = THB.ICON | THB.TOOLTIP | THB.FLAGS
            };
            switch (thumbButtonInfo.Visibility)
            {
              case Visibility.Hidden:
                thumbbutton.dwFlags = THBF.DISABLED | THBF.NOBACKGROUND;
                thumbbutton.hIcon = IntPtr.Zero;
                break;
              case Visibility.Collapsed:
                thumbbutton.dwFlags = THBF.HIDDEN;
                break;
              default:
                thumbbutton.szTip = thumbButtonInfo.Description ?? "";
                if (thumbButtonInfo.ImageSource != null)
                {
                  MS.Win32.NativeMethods.IconHandle handleFromImageSource = IconHelper.CreateIconHandleFromImageSource(thumbButtonInfo.ImageSource, this._overlaySize);
                  thumbbutton.hIcon = handleFromImageSource.CriticalGetHandle();
                  list.Add(handleFromImageSource);
                }
                if (!thumbButtonInfo.IsBackgroundVisible)
                  thumbbutton.dwFlags |= THBF.NOBACKGROUND;
                if (!thumbButtonInfo.IsEnabled)
                {
                  thumbbutton.dwFlags |= THBF.DISABLED;
                }
                else
                {
                  // ISSUE: explicit reference operation
                  // ISSUE: variable of a reference type
                  THUMBBUTTON& local = @thumbbutton;
                  // ISSUE: explicit reference operation
                  int num2 = (int) (^local).dwFlags;
                  // ISSUE: explicit reference operation
                  (^local).dwFlags = (THBF) num2;
                }
                if (!thumbButtonInfo.IsInteractive)
                  thumbbutton.dwFlags |= THBF.NONINTERACTIVE;
                if (thumbButtonInfo.DismissWhenClicked)
                {
                  thumbbutton.dwFlags |= THBF.DISMISSONCLICK;
                  break;
                }
                else
                  break;
            }
            pButtons[(IntPtr) num1] = thumbbutton;
            ++num1;
            if ((int) num1 == 7)
              break;
          }
        }
        for (; num1 < 7U; ++num1)
          pButtons[(IntPtr) num1] = new THUMBBUTTON()
          {
            iId = num1,
            dwFlags = THBF.DISABLED | THBF.NOBACKGROUND | THBF.HIDDEN,
            dwMask = THB.ICON | THB.TOOLTIP | THB.FLAGS
          };
        return this._taskbarList.ThumbBarUpdateButtons(this.CriticalHandle, (uint) pButtons.Length, pButtons);
      }
      finally
      {
        foreach (SafeHandle safeHandle in list)
          safeHandle.Dispose();
      }
    }

    private void CreateRtl()
    {
      if (this.FlowDirection == FlowDirection.LeftToRight)
      {
        this._StyleEx &= -4194305;
      }
      else
      {
        if (this.FlowDirection != FlowDirection.RightToLeft)
          throw new InvalidOperationException(System.Windows.SR.Get("IncorrectFlowDirection"));
        this._StyleEx |= 4194304;
      }
    }

    private void ClearRootVisual()
    {
      if (this._swh == null)
        return;
      this._swh.ClearRootVisual();
    }

    private MS.Win32.NativeMethods.POINT GetPointRelativeToWindow(int x, int y)
    {
      return this._swh.GetPointRelativeToWindow(x, y, this.FlowDirection);
    }

    private Size GetHwndNonClientAreaSizeInMeasureUnits()
    {
      if (!this.AllowsTransparency)
        return this._swh.GetHwndNonClientAreaSizeInMeasureUnits();
      else
        return new Size(0.0, 0.0);
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private void ClearSourceWindow()
    {
      if (this._swh == null)
        return;
      try
      {
        this._swh.RemoveDisposedHandler(new EventHandler(this.OnSourceWindowDisposed));
      }
      finally
      {
        HwndSource hwndSourceWindow = this._swh.HwndSourceWindow;
        this._swh = (Window.SourceWindowHelper) null;
        if (hwndSourceWindow != null)
          hwndSourceWindow.SizeToContentChanged -= new EventHandler(this.OnSourceSizeToContentChanged);
      }
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private void ClearHiddenWindowIfAny()
    {
      if (this._hiddenWindow == null || !(this._hiddenWindow.Handle == this._ownerHandle))
        return;
      this.SetOwnerHandle(IntPtr.Zero);
    }

    private void VerifyConsistencyWithAllowsTransparency()
    {
      if (!this.AllowsTransparency)
        return;
      this.VerifyConsistencyWithAllowsTransparency(this.WindowStyle);
    }

    private void VerifyConsistencyWithAllowsTransparency(WindowStyle style)
    {
      if (this.AllowsTransparency && style != WindowStyle.None)
        throw new InvalidOperationException(System.Windows.SR.Get("MustUseWindowStyleNone"));
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    private void VerifyConsistencyWithShowActivated()
    {
      if (!this._inTrustedSubWindow && this.WindowState == WindowState.Maximized && !this.ShowActivated)
        throw new InvalidOperationException(System.Windows.SR.Get("ShowNonActivatedAndMaximized"));
    }

    private static bool IsValidSizeToContent(SizeToContent value)
    {
      if (value != SizeToContent.Manual && value != SizeToContent.Width && value != SizeToContent.Height)
        return value == SizeToContent.WidthAndHeight;
      else
        return true;
    }

    private static bool IsValidResizeMode(ResizeMode value)
    {
      if (value != ResizeMode.NoResize && value != ResizeMode.CanMinimize && value != ResizeMode.CanResize)
        return value == ResizeMode.CanResizeWithGrip;
      else
        return true;
    }

    private static bool IsValidWindowStartupLocation(WindowStartupLocation value)
    {
      if (value != WindowStartupLocation.CenterOwner && value != WindowStartupLocation.CenterScreen)
        return value == WindowStartupLocation.Manual;
      else
        return true;
    }

    private static bool IsValidWindowState(WindowState value)
    {
      if (value != WindowState.Maximized && value != WindowState.Minimized)
        return value == WindowState.Normal;
      else
        return true;
    }

    private static bool IsValidWindowStyle(WindowStyle value)
    {
      if (value != WindowStyle.None && value != WindowStyle.SingleBorderWindow && value != WindowStyle.ThreeDBorderWindow)
        return value == WindowStyle.ToolWindow;
      else
        return true;
    }

    private static void OnStaticManipulationInertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
    {
      Window window = sender as Window;
      if (window == null)
        return;
      window.EndPanningFeedback(true);
    }

    private static void OnStaticManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
    {
      Window window = sender as Window;
      if (window == null)
        return;
      window.EndPanningFeedback(false);
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private void UpdatePanningFeedback(Vector totalOverpanOffset, object originalSource)
    {
      if (this._currentPanningTarget != null && !this._currentPanningTarget.IsAlive)
      {
        this._currentPanningTarget = (WeakReference) null;
        this.EndPanningFeedback(false);
      }
      if (this._swh == null)
        return;
      if (this._currentPanningTarget == null)
        this._currentPanningTarget = new WeakReference(originalSource);
      if (originalSource != this._currentPanningTarget.Target)
        return;
      this._swh.UpdatePanningFeedback(totalOverpanOffset, false);
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private void EndPanningFeedback(bool animateBack)
    {
      if (this._swh != null)
        this._swh.EndPanningFeedback(animateBack);
      this._currentPanningTarget = (WeakReference) null;
      this._prePanningLocation = new Point(double.NaN, double.NaN);
    }

    private Point CompensateForPanningFeedback(Point point)
    {
      if (double.IsNaN(this._prePanningLocation.X) || double.IsNaN(this._prePanningLocation.Y) || this._swh == null)
        return point;
      MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
      Point point1 = this.DeviceToLogicalUnits(new Point((double) windowBounds.left, (double) windowBounds.top));
      return new Point(point.X - (this._prePanningLocation.X - point1.X), point.Y - (this._prePanningLocation.Y - point1.Y));
    }

    internal struct WindowMinMax
    {
      internal double minWidth;
      internal double maxWidth;
      internal double minHeight;
      internal double maxHeight;

      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
      internal WindowMinMax(double minSize, double maxSize)
      {
        this.minWidth = minSize;
        this.maxWidth = maxSize;
        this.minHeight = minSize;
        this.maxHeight = maxSize;
      }
    }

    internal class SourceWindowHelper
    {
      [SecurityCritical]
      private HwndSource _sourceWindow;
      [SecurityCritical]
      private HwndPanningFeedback _panningFeedback;

      internal bool IsSourceWindowNull
      {
        [SecurityCritical, SecurityTreatAsSafe] get
        {
          return this._sourceWindow == null;
        }
      }

      internal bool IsCompositionTargetInvalid
      {
        [SecurityCritical, SecurityTreatAsSafe] get
        {
          return this.CompositionTarget == null;
        }
      }

      internal IntPtr CriticalHandle
      {
        [SecurityCritical] get
        {
          if (this._sourceWindow != null)
            return this._sourceWindow.CriticalHandle;
          else
            return IntPtr.Zero;
        }
      }

      internal MS.Win32.NativeMethods.RECT WorkAreaBoundsForNearestMonitor
      {
        [SecurityTreatAsSafe, SecurityCritical] get
        {
          MS.Win32.NativeMethods.MONITORINFOEX info = new MS.Win32.NativeMethods.MONITORINFOEX();
          info.cbSize = Marshal.SizeOf(typeof (MS.Win32.NativeMethods.MONITORINFOEX));
          IntPtr handle = SafeNativeMethods.MonitorFromWindow(new HandleRef((object) this, this.CriticalHandle), 2);
          if (handle != IntPtr.Zero)
            SafeNativeMethods.GetMonitorInfo(new HandleRef((object) this, handle), info);
          return info.rcWork;
        }
      }

      MS.Win32.NativeMethods.RECT ClientBounds
      {
        [SecurityCritical, SecurityTreatAsSafe] private get
        {
          MS.Win32.NativeMethods.RECT rect = new MS.Win32.NativeMethods.RECT(0, 0, 0, 0);
          SafeNativeMethods.GetClientRect(new HandleRef((object) this, this.CriticalHandle), out rect);
          return rect;
        }
      }

      internal MS.Win32.NativeMethods.RECT WindowBounds
      {
        [SecurityCritical, SecurityTreatAsSafe] get
        {
          MS.Win32.NativeMethods.RECT rect = new MS.Win32.NativeMethods.RECT(0, 0, 0, 0);
          SafeNativeMethods.GetWindowRect(new HandleRef((object) this, this.CriticalHandle), out rect);
          return rect;
        }
      }

      internal SizeToContent HwndSourceSizeToContent
      {
        [SecurityTreatAsSafe, SecurityCritical] get
        {
          return this._sourceWindow.SizeToContent;
        }
        [SecurityCritical, SecurityTreatAsSafe] set
        {
          this._sourceWindow.SizeToContent = value;
        }
      }

      internal Visual RootVisual
      {
        [SecurityCritical] set
        {
          this._sourceWindow.RootVisual = value;
        }
      }

      internal bool IsActiveWindow
      {
        [SecurityCritical, SecurityTreatAsSafe] get
        {
          return this._sourceWindow.CriticalHandle == MS.Win32.UnsafeNativeMethods.GetActiveWindow();
        }
      }

      internal HwndSource HwndSourceWindow
      {
        [SecurityCritical, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
        {
          return this._sourceWindow;
        }
      }

      internal HwndTarget CompositionTarget
      {
        [SecurityCritical] get
        {
          if (this._sourceWindow != null)
          {
            HwndTarget compositionTarget = this._sourceWindow.CompositionTarget;
            if (compositionTarget != null && !compositionTarget.IsDisposed)
              return compositionTarget;
          }
          return (HwndTarget) null;
        }
      }

      internal Size WindowSize
      {
        get
        {
          MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
          return new Size((double) (windowBounds.right - windowBounds.left), (double) (windowBounds.bottom - windowBounds.top));
        }
      }

      internal int StyleExFromHwnd
      {
        [SecurityCritical, SecurityTreatAsSafe] get
        {
          return MS.Win32.UnsafeNativeMethods.GetWindowLong(new HandleRef((object) this, this.CriticalHandle), -20);
        }
      }

      internal int StyleFromHwnd
      {
        [SecurityCritical, SecurityTreatAsSafe] get
        {
          return MS.Win32.UnsafeNativeMethods.GetWindowLong(new HandleRef((object) this, this.CriticalHandle), -16);
        }
      }

      [SecurityCritical]
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
      internal SourceWindowHelper(HwndSource sourceWindow)
      {
        this._sourceWindow = sourceWindow;
      }

      [SecurityCritical]
      [SecurityTreatAsSafe]
      internal MS.Win32.NativeMethods.POINT GetPointRelativeToWindow(int x, int y, FlowDirection flowDirection)
      {
        MS.Win32.NativeMethods.POINT windowScreenLocation = this.GetWindowScreenLocation(flowDirection);
        return new MS.Win32.NativeMethods.POINT(x - windowScreenLocation.x, y - windowScreenLocation.y);
      }

      [SecurityTreatAsSafe]
      [SecurityCritical]
      internal Size GetSizeFromHwndInMeasureUnits()
      {
        Point point1 = new Point(0.0, 0.0);
        MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
        point1.X = (double) (windowBounds.right - windowBounds.left);
        point1.Y = (double) (windowBounds.bottom - windowBounds.top);
        Point point2 = this._sourceWindow.CompositionTarget.TransformFromDevice.Transform(point1);
        return new Size(point2.X, point2.Y);
      }

      [SecurityCritical]
      [SecurityTreatAsSafe]
      internal Size GetHwndNonClientAreaSizeInMeasureUnits()
      {
        MS.Win32.NativeMethods.RECT clientBounds = this.ClientBounds;
        MS.Win32.NativeMethods.RECT windowBounds = this.WindowBounds;
        Point point = this._sourceWindow.CompositionTarget.TransformFromDevice.Transform(new Point((double) (windowBounds.right - windowBounds.left - (clientBounds.right - clientBounds.left)), (double) (windowBounds.bottom - windowBounds.top - (clientBounds.bottom - clientBounds.top))));
        return new Size(point.X, point.Y);
      }

      [SecurityTreatAsSafe]
      [SecurityCritical]
      internal void ClearRootVisual()
      {
        if (this._sourceWindow.RootVisual == null)
          return;
        this._sourceWindow.RootVisual = (Visual) null;
      }

      [SecurityCritical]
      internal void AddDisposedHandler(EventHandler theHandler)
      {
        if (this._sourceWindow == null)
          return;
        this._sourceWindow.Disposed += theHandler;
      }

      [SecurityCritical]
      internal void RemoveDisposedHandler(EventHandler theHandler)
      {
        if (this._sourceWindow == null)
          return;
        this._sourceWindow.Disposed -= theHandler;
      }

      [SecurityTreatAsSafe]
      [SecurityCritical]
      internal void UpdatePanningFeedback(Vector totalOverpanOffset, bool animate)
      {
        if (this._panningFeedback == null && this._sourceWindow != null)
          this._panningFeedback = new HwndPanningFeedback(this._sourceWindow);
        if (this._panningFeedback == null)
          return;
        this._panningFeedback.UpdatePanningFeedback(totalOverpanOffset, animate);
      }

      [SecurityCritical]
      [SecurityTreatAsSafe]
      internal void EndPanningFeedback(bool animateBack)
      {
        if (this._panningFeedback == null)
          return;
        this._panningFeedback.EndPanningFeedback(animateBack);
        this._panningFeedback = (HwndPanningFeedback) null;
      }

      [SecurityCritical]
      private MS.Win32.NativeMethods.POINT GetWindowScreenLocation(FlowDirection flowDirection)
      {
        MS.Win32.NativeMethods.POINT pt = new MS.Win32.NativeMethods.POINT(0, 0);
        if (flowDirection == FlowDirection.RightToLeft)
        {
          MS.Win32.NativeMethods.RECT rect = new MS.Win32.NativeMethods.RECT(0, 0, 0, 0);
          SafeNativeMethods.GetClientRect(new HandleRef((object) this, this.CriticalHandle), out rect);
          pt = new MS.Win32.NativeMethods.POINT(rect.right, rect.top);
        }
        MS.Win32.UnsafeNativeMethods.ClientToScreen(new HandleRef((object) this, this._sourceWindow.CriticalHandle), pt);
        return pt;
      }
    }

    internal class HwndStyleManager : IDisposable
    {
      private Window _window;
      private int _refCount;
      private bool _fDirty;

      internal bool Dirty
      {
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
        {
          return this._fDirty;
        }
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
        {
          this._fDirty = value;
        }
      }

      private HwndStyleManager(Window w, int Style, int StyleEx)
      {
        this._window = w;
        this._window.Manager = this;
        if (!w.IsSourceWindowNull)
        {
          this._window._Style = Style;
          this._window._StyleEx = StyleEx;
          this.Dirty = false;
        }
        this._refCount = 1;
      }

      internal static Window.HwndStyleManager StartManaging(Window w, int Style, int StyleEx)
      {
        if (w.Manager == null)
          return new Window.HwndStyleManager(w, Style, StyleEx);
        ++w.Manager._refCount;
        return w.Manager;
      }

      void IDisposable.Dispose()
      {
        --this._refCount;
        if (this._refCount != 0)
          return;
        this._window.Flush();
        if (this._window.Manager != this)
          return;
        this._window.Manager = (Window.HwndStyleManager) null;
      }
    }

    private enum TransformType
    {
      WorkAreaToScreenArea,
      ScreenAreaToWorkArea,
    }

    private enum BoundsSpecified
    {
      Height,
      Width,
      Top,
      Left,
    }
  }
}
