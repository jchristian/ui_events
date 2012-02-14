// Type: System.Windows.UIElement
// Assembly: PresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\WPF\PresentationCore.dll

using MS.Internal;
using MS.Internal.KnownBoxes;
using MS.Internal.Media;
using MS.Internal.Permissions;
using MS.Internal.PresentationCore;
using MS.Utility;
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
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Composition;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;

namespace System.Windows
{
  [UidProperty("Uid")]
  public class UIElement : Visual, IAnimatable, IInputElement
  {
    private static readonly System.Type _typeofThis = typeof (UIElement);
    public static readonly RoutedEvent PreviewMouseDownEvent = Mouse.PreviewMouseDownEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent MouseDownEvent = Mouse.MouseDownEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewMouseUpEvent = Mouse.PreviewMouseUpEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent MouseUpEvent = Mouse.MouseUpEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewMouseLeftButtonDownEvent = EventManager.RegisterRoutedEvent("PreviewMouseLeftButtonDown", RoutingStrategy.Direct, typeof (MouseButtonEventHandler), UIElement._typeofThis);
    public static readonly RoutedEvent MouseLeftButtonDownEvent = EventManager.RegisterRoutedEvent("MouseLeftButtonDown", RoutingStrategy.Direct, typeof (MouseButtonEventHandler), UIElement._typeofThis);
    public static readonly RoutedEvent PreviewMouseLeftButtonUpEvent = EventManager.RegisterRoutedEvent("PreviewMouseLeftButtonUp", RoutingStrategy.Direct, typeof (MouseButtonEventHandler), UIElement._typeofThis);
    public static readonly RoutedEvent MouseLeftButtonUpEvent = EventManager.RegisterRoutedEvent("MouseLeftButtonUp", RoutingStrategy.Direct, typeof (MouseButtonEventHandler), UIElement._typeofThis);
    public static readonly RoutedEvent PreviewMouseRightButtonDownEvent = EventManager.RegisterRoutedEvent("PreviewMouseRightButtonDown", RoutingStrategy.Direct, typeof (MouseButtonEventHandler), UIElement._typeofThis);
    public static readonly RoutedEvent MouseRightButtonDownEvent = EventManager.RegisterRoutedEvent("MouseRightButtonDown", RoutingStrategy.Direct, typeof (MouseButtonEventHandler), UIElement._typeofThis);
    public static readonly RoutedEvent PreviewMouseRightButtonUpEvent = EventManager.RegisterRoutedEvent("PreviewMouseRightButtonUp", RoutingStrategy.Direct, typeof (MouseButtonEventHandler), UIElement._typeofThis);
    public static readonly RoutedEvent MouseRightButtonUpEvent = EventManager.RegisterRoutedEvent("MouseRightButtonUp", RoutingStrategy.Direct, typeof (MouseButtonEventHandler), UIElement._typeofThis);
    public static readonly RoutedEvent PreviewMouseMoveEvent = Mouse.PreviewMouseMoveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent MouseMoveEvent = Mouse.MouseMoveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewMouseWheelEvent = Mouse.PreviewMouseWheelEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent MouseWheelEvent = Mouse.MouseWheelEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent MouseEnterEvent = Mouse.MouseEnterEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent MouseLeaveEvent = Mouse.MouseLeaveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent GotMouseCaptureEvent = Mouse.GotMouseCaptureEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent LostMouseCaptureEvent = Mouse.LostMouseCaptureEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent QueryCursorEvent = Mouse.QueryCursorEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewStylusDownEvent = Stylus.PreviewStylusDownEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent StylusDownEvent = Stylus.StylusDownEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewStylusUpEvent = Stylus.PreviewStylusUpEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent StylusUpEvent = Stylus.StylusUpEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewStylusMoveEvent = Stylus.PreviewStylusMoveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent StylusMoveEvent = Stylus.StylusMoveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewStylusInAirMoveEvent = Stylus.PreviewStylusInAirMoveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent StylusInAirMoveEvent = Stylus.StylusInAirMoveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent StylusEnterEvent = Stylus.StylusEnterEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent StylusLeaveEvent = Stylus.StylusLeaveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewStylusInRangeEvent = Stylus.PreviewStylusInRangeEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent StylusInRangeEvent = Stylus.StylusInRangeEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewStylusOutOfRangeEvent = Stylus.PreviewStylusOutOfRangeEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent StylusOutOfRangeEvent = Stylus.StylusOutOfRangeEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewStylusSystemGestureEvent = Stylus.PreviewStylusSystemGestureEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent StylusSystemGestureEvent = Stylus.StylusSystemGestureEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent GotStylusCaptureEvent = Stylus.GotStylusCaptureEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent LostStylusCaptureEvent = Stylus.LostStylusCaptureEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent StylusButtonDownEvent = Stylus.StylusButtonDownEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent StylusButtonUpEvent = Stylus.StylusButtonUpEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewStylusButtonDownEvent = Stylus.PreviewStylusButtonDownEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewStylusButtonUpEvent = Stylus.PreviewStylusButtonUpEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewKeyDownEvent = Keyboard.PreviewKeyDownEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent KeyDownEvent = Keyboard.KeyDownEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewKeyUpEvent = Keyboard.PreviewKeyUpEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent KeyUpEvent = Keyboard.KeyUpEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewGotKeyboardFocusEvent = Keyboard.PreviewGotKeyboardFocusEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent GotKeyboardFocusEvent = Keyboard.GotKeyboardFocusEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewLostKeyboardFocusEvent = Keyboard.PreviewLostKeyboardFocusEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent LostKeyboardFocusEvent = Keyboard.LostKeyboardFocusEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewTextInputEvent = TextCompositionManager.PreviewTextInputEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent TextInputEvent = TextCompositionManager.TextInputEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewQueryContinueDragEvent = DragDrop.PreviewQueryContinueDragEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent QueryContinueDragEvent = DragDrop.QueryContinueDragEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewGiveFeedbackEvent = DragDrop.PreviewGiveFeedbackEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent GiveFeedbackEvent = DragDrop.GiveFeedbackEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewDragEnterEvent = DragDrop.PreviewDragEnterEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent DragEnterEvent = DragDrop.DragEnterEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewDragOverEvent = DragDrop.PreviewDragOverEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent DragOverEvent = DragDrop.DragOverEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewDragLeaveEvent = DragDrop.PreviewDragLeaveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent DragLeaveEvent = DragDrop.DragLeaveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewDropEvent = DragDrop.PreviewDropEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent DropEvent = DragDrop.DropEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewTouchDownEvent = Touch.PreviewTouchDownEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent TouchDownEvent = Touch.TouchDownEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewTouchMoveEvent = Touch.PreviewTouchMoveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent TouchMoveEvent = Touch.TouchMoveEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent PreviewTouchUpEvent = Touch.PreviewTouchUpEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent TouchUpEvent = Touch.TouchUpEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent GotTouchCaptureEvent = Touch.GotTouchCaptureEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent LostTouchCaptureEvent = Touch.LostTouchCaptureEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent TouchEnterEvent = Touch.TouchEnterEvent.AddOwner(UIElement._typeofThis);
    public static readonly RoutedEvent TouchLeaveEvent = Touch.TouchLeaveEvent.AddOwner(UIElement._typeofThis);
    internal static readonly DependencyPropertyKey IsMouseDirectlyOverPropertyKey = DependencyProperty.RegisterReadOnly("IsMouseDirectlyOver", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(UIElement.IsMouseDirectlyOver_Changed)));
    public static readonly DependencyProperty IsMouseDirectlyOverProperty = UIElement.IsMouseDirectlyOverPropertyKey.DependencyProperty;
    internal static readonly EventPrivateKey IsMouseDirectlyOverChangedKey = new EventPrivateKey();
    internal static readonly DependencyPropertyKey IsMouseOverPropertyKey = DependencyProperty.RegisterReadOnly("IsMouseOver", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox));
    public static readonly DependencyProperty IsMouseOverProperty = UIElement.IsMouseOverPropertyKey.DependencyProperty;
    internal static readonly DependencyPropertyKey IsStylusOverPropertyKey = DependencyProperty.RegisterReadOnly("IsStylusOver", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox));
    public static readonly DependencyProperty IsStylusOverProperty = UIElement.IsStylusOverPropertyKey.DependencyProperty;
    internal static readonly DependencyPropertyKey IsKeyboardFocusWithinPropertyKey = DependencyProperty.RegisterReadOnly("IsKeyboardFocusWithin", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox));
    public static readonly DependencyProperty IsKeyboardFocusWithinProperty = UIElement.IsKeyboardFocusWithinPropertyKey.DependencyProperty;
    internal static readonly EventPrivateKey IsKeyboardFocusWithinChangedKey = new EventPrivateKey();
    internal static readonly DependencyPropertyKey IsMouseCapturedPropertyKey = DependencyProperty.RegisterReadOnly("IsMouseCaptured", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(UIElement.IsMouseCaptured_Changed)));
    public static readonly DependencyProperty IsMouseCapturedProperty = UIElement.IsMouseCapturedPropertyKey.DependencyProperty;
    internal static readonly EventPrivateKey IsMouseCapturedChangedKey = new EventPrivateKey();
    internal static readonly DependencyPropertyKey IsMouseCaptureWithinPropertyKey = DependencyProperty.RegisterReadOnly("IsMouseCaptureWithin", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox));
    public static readonly DependencyProperty IsMouseCaptureWithinProperty = UIElement.IsMouseCaptureWithinPropertyKey.DependencyProperty;
    internal static readonly EventPrivateKey IsMouseCaptureWithinChangedKey = new EventPrivateKey();
    internal static readonly DependencyPropertyKey IsStylusDirectlyOverPropertyKey = DependencyProperty.RegisterReadOnly("IsStylusDirectlyOver", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(UIElement.IsStylusDirectlyOver_Changed)));
    public static readonly DependencyProperty IsStylusDirectlyOverProperty = UIElement.IsStylusDirectlyOverPropertyKey.DependencyProperty;
    internal static readonly EventPrivateKey IsStylusDirectlyOverChangedKey = new EventPrivateKey();
    internal static readonly DependencyPropertyKey IsStylusCapturedPropertyKey = DependencyProperty.RegisterReadOnly("IsStylusCaptured", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(UIElement.IsStylusCaptured_Changed)));
    public static readonly DependencyProperty IsStylusCapturedProperty = UIElement.IsStylusCapturedPropertyKey.DependencyProperty;
    internal static readonly EventPrivateKey IsStylusCapturedChangedKey = new EventPrivateKey();
    internal static readonly DependencyPropertyKey IsStylusCaptureWithinPropertyKey = DependencyProperty.RegisterReadOnly("IsStylusCaptureWithin", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox));
    public static readonly DependencyProperty IsStylusCaptureWithinProperty = UIElement.IsStylusCaptureWithinPropertyKey.DependencyProperty;
    internal static readonly EventPrivateKey IsStylusCaptureWithinChangedKey = new EventPrivateKey();
    internal static readonly DependencyPropertyKey IsKeyboardFocusedPropertyKey = DependencyProperty.RegisterReadOnly("IsKeyboardFocused", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(UIElement.IsKeyboardFocused_Changed)));
    public static readonly DependencyProperty IsKeyboardFocusedProperty = UIElement.IsKeyboardFocusedPropertyKey.DependencyProperty;
    internal static readonly EventPrivateKey IsKeyboardFocusedChangedKey = new EventPrivateKey();
    internal static readonly DependencyPropertyKey AreAnyTouchesDirectlyOverPropertyKey = DependencyProperty.RegisterReadOnly("AreAnyTouchesDirectlyOver", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox));
    public static readonly DependencyProperty AreAnyTouchesDirectlyOverProperty = UIElement.AreAnyTouchesDirectlyOverPropertyKey.DependencyProperty;
    internal static readonly DependencyPropertyKey AreAnyTouchesOverPropertyKey = DependencyProperty.RegisterReadOnly("AreAnyTouchesOver", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox));
    public static readonly DependencyProperty AreAnyTouchesOverProperty = UIElement.AreAnyTouchesOverPropertyKey.DependencyProperty;
    internal static readonly DependencyPropertyKey AreAnyTouchesCapturedPropertyKey = DependencyProperty.RegisterReadOnly("AreAnyTouchesCaptured", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox));
    public static readonly DependencyProperty AreAnyTouchesCapturedProperty = UIElement.AreAnyTouchesCapturedPropertyKey.DependencyProperty;
    internal static readonly DependencyPropertyKey AreAnyTouchesCapturedWithinPropertyKey = DependencyProperty.RegisterReadOnly("AreAnyTouchesCapturedWithin", typeof (bool), UIElement._typeofThis, new PropertyMetadata(BooleanBoxes.FalseBox));
    public static readonly DependencyProperty AreAnyTouchesCapturedWithinProperty = UIElement.AreAnyTouchesCapturedWithinPropertyKey.DependencyProperty;
    public static readonly DependencyProperty AllowDropProperty = DependencyProperty.Register("AllowDrop", typeof (bool), typeof (UIElement), new PropertyMetadata(BooleanBoxes.FalseBox));
    [CommonDependencyProperty]
    public static readonly DependencyProperty RenderTransformProperty = DependencyProperty.Register("RenderTransform", typeof (Transform), typeof (UIElement), new PropertyMetadata((object) Transform.Identity, new PropertyChangedCallback(UIElement.RenderTransform_Changed)));
    public static readonly DependencyProperty RenderTransformOriginProperty = DependencyProperty.Register("RenderTransformOrigin", typeof (Point), typeof (UIElement), new PropertyMetadata((object) new Point(0.0, 0.0), new PropertyChangedCallback(UIElement.RenderTransformOrigin_Changed)), new ValidateValueCallback(UIElement.IsRenderTransformOriginValid));
    public static readonly DependencyProperty OpacityProperty = DependencyProperty.Register("Opacity", typeof (double), typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata((object) 1.0, new PropertyChangedCallback(UIElement.Opacity_Changed)));
    public static readonly DependencyProperty OpacityMaskProperty = DependencyProperty.Register("OpacityMask", typeof (Brush), typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(new PropertyChangedCallback(UIElement.OpacityMask_Changed)));
    public static readonly DependencyProperty BitmapEffectProperty = DependencyProperty.Register("BitmapEffect", typeof (BitmapEffect), typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(new PropertyChangedCallback(UIElement.OnBitmapEffectChanged)));
    public static readonly DependencyProperty EffectProperty = DependencyProperty.Register("Effect", typeof (Effect), typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(new PropertyChangedCallback(UIElement.OnEffectChanged)));
    public static readonly DependencyProperty BitmapEffectInputProperty = DependencyProperty.Register("BitmapEffectInput", typeof (BitmapEffectInput), typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(new PropertyChangedCallback(UIElement.OnBitmapEffectInputChanged)));
    public static readonly DependencyProperty CacheModeProperty = DependencyProperty.Register("CacheMode", typeof (CacheMode), typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(new PropertyChangedCallback(UIElement.OnCacheModeChanged)));
    public static readonly DependencyProperty UidProperty = DependencyProperty.Register("Uid", typeof (string), typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata((object) string.Empty));
    [CommonDependencyProperty]
    public static readonly DependencyProperty VisibilityProperty = DependencyProperty.Register("Visibility", typeof (Visibility), typeof (UIElement), new PropertyMetadata(VisibilityBoxes.VisibleBox, new PropertyChangedCallback(UIElement.OnVisibilityChanged)), new ValidateValueCallback(UIElement.ValidateVisibility));
    [CommonDependencyProperty]
    public static readonly DependencyProperty ClipToBoundsProperty = DependencyProperty.Register("ClipToBounds", typeof (bool), typeof (UIElement), new PropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(UIElement.ClipToBounds_Changed)));
    public static readonly DependencyProperty ClipProperty = DependencyProperty.Register("Clip", typeof (Geometry), typeof (UIElement), new PropertyMetadata((object) null, new PropertyChangedCallback(UIElement.Clip_Changed)));
    public static readonly DependencyProperty SnapsToDevicePixelsProperty = DependencyProperty.Register("SnapsToDevicePixels", typeof (bool), typeof (UIElement), new PropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(UIElement.SnapsToDevicePixels_Changed)));
    public static readonly RoutedEvent GotFocusEvent = FocusManager.GotFocusEvent.AddOwner(typeof (UIElement));
    public static readonly RoutedEvent LostFocusEvent = FocusManager.LostFocusEvent.AddOwner(typeof (UIElement));
    internal static readonly DependencyPropertyKey IsFocusedPropertyKey = DependencyProperty.RegisterReadOnly("IsFocused", typeof (bool), typeof (UIElement), new PropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(UIElement.IsFocused_Changed)));
    public static readonly DependencyProperty IsFocusedProperty = UIElement.IsFocusedPropertyKey.DependencyProperty;
    [CommonDependencyProperty]
    public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.Register("IsEnabled", typeof (bool), typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(BooleanBoxes.TrueBox, new PropertyChangedCallback(UIElement.OnIsEnabledChanged), new CoerceValueCallback(UIElement.CoerceIsEnabled)));
    internal static readonly EventPrivateKey IsEnabledChangedKey = new EventPrivateKey();
    public static readonly DependencyProperty IsHitTestVisibleProperty = DependencyProperty.Register("IsHitTestVisible", typeof (bool), typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(BooleanBoxes.TrueBox, new PropertyChangedCallback(UIElement.OnIsHitTestVisibleChanged), new CoerceValueCallback(UIElement.CoerceIsHitTestVisible)));
    internal static readonly EventPrivateKey IsHitTestVisibleChangedKey = new EventPrivateKey();
    private static PropertyMetadata _isVisibleMetadata = (PropertyMetadata) new ReadOnlyPropertyMetadata(BooleanBoxes.FalseBox, new GetReadOnlyValueCallback(UIElement.GetIsVisible), new PropertyChangedCallback(UIElement.OnIsVisibleChanged));
    internal static readonly DependencyPropertyKey IsVisiblePropertyKey = DependencyProperty.RegisterReadOnly("IsVisible", typeof (bool), typeof (UIElement), UIElement._isVisibleMetadata);
    public static readonly DependencyProperty IsVisibleProperty = UIElement.IsVisiblePropertyKey.DependencyProperty;
    internal static readonly EventPrivateKey IsVisibleChangedKey = new EventPrivateKey();
    [CommonDependencyProperty]
    public static readonly DependencyProperty FocusableProperty = DependencyProperty.Register("Focusable", typeof (bool), typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(UIElement.OnFocusableChanged)));
    internal static readonly EventPrivateKey FocusableChangedKey = new EventPrivateKey();
    public static readonly DependencyProperty IsManipulationEnabledProperty = DependencyProperty.Register("IsManipulationEnabled", typeof (bool), typeof (UIElement), new PropertyMetadata(BooleanBoxes.FalseBox, new PropertyChangedCallback(UIElement.OnIsManipulationEnabledChanged)));
    public static readonly RoutedEvent ManipulationStartingEvent = Manipulation.ManipulationStartingEvent.AddOwner(typeof (UIElement));
    public static readonly RoutedEvent ManipulationStartedEvent = Manipulation.ManipulationStartedEvent.AddOwner(typeof (UIElement));
    public static readonly RoutedEvent ManipulationDeltaEvent = Manipulation.ManipulationDeltaEvent.AddOwner(typeof (UIElement));
    public static readonly RoutedEvent ManipulationInertiaStartingEvent = Manipulation.ManipulationInertiaStartingEvent.AddOwner(typeof (UIElement));
    public static readonly RoutedEvent ManipulationBoundaryFeedbackEvent = Manipulation.ManipulationBoundaryFeedbackEvent.AddOwner(typeof (UIElement));
    public static readonly RoutedEvent ManipulationCompletedEvent = Manipulation.ManipulationCompletedEvent.AddOwner(typeof (UIElement));
    private static double _dpiScaleX = 1.0;
    private static double _dpiScaleY = 1.0;
    private static bool _setDpi = true;
    internal static readonly UncommonField<EventHandlersStore> EventHandlersStoreField = new UncommonField<EventHandlersStore>();
    internal static readonly UncommonField<InputBindingCollection> InputBindingCollectionField = new UncommonField<InputBindingCollection>();
    internal static readonly UncommonField<CommandBindingCollection> CommandBindingCollectionField = new UncommonField<CommandBindingCollection>();
    private static readonly UncommonField<object> LayoutUpdatedListItemsField = new UncommonField<object>();
    private static readonly UncommonField<EventHandler> LayoutUpdatedHandlersField = new UncommonField<EventHandler>();
    private static readonly UncommonField<StylusPlugInCollection> StylusPlugInsField = new UncommonField<StylusPlugInCollection>();
    private static readonly UncommonField<AutomationPeer> AutomationPeerField = new UncommonField<AutomationPeer>();
    internal static readonly FocusWithinProperty FocusWithinProperty = new FocusWithinProperty();
    internal static readonly MouseOverProperty MouseOverProperty = new MouseOverProperty();
    internal static readonly MouseCaptureWithinProperty MouseCaptureWithinProperty = new MouseCaptureWithinProperty();
    internal static readonly StylusOverProperty StylusOverProperty = new StylusOverProperty();
    internal static readonly StylusCaptureWithinProperty StylusCaptureWithinProperty = new StylusCaptureWithinProperty();
    internal static readonly TouchesOverProperty TouchesOverProperty = new TouchesOverProperty();
    internal static readonly TouchesCapturedWithinProperty TouchesCapturedWithinProperty = new TouchesCapturedWithinProperty();
    internal const int MAX_ELEMENTS_IN_ROUTE = 4096;
    private CoreFlags _flags;
    private Rect _finalRect;
    private Size _desiredSize;
    private Size _previousAvailableSize;
    private IDrawingContent _drawingContent;
    internal ContextLayoutManager.LayoutQueue.Request MeasureRequest;
    internal ContextLayoutManager.LayoutQueue.Request ArrangeRequest;
    private int _persistId;
    internal SizeChangedInfo sizeChangedInfo;
    private Size _size;

    public bool HasAnimatedProperties
    {
      get
      {
        this.VerifyAccess();
        return this.IAnimatable_HasAnimatedProperties;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public InputBindingCollection InputBindings
    {
      get
      {
        this.VerifyAccess();
        InputBindingCollection bindingCollection = UIElement.InputBindingCollectionField.GetValue((DependencyObject) this);
        if (bindingCollection == null)
        {
          bindingCollection = new InputBindingCollection((DependencyObject) this);
          UIElement.InputBindingCollectionField.SetValue((DependencyObject) this, bindingCollection);
        }
        return bindingCollection;
      }
    }

    internal InputBindingCollection InputBindingsInternal
    {
      get
      {
        this.VerifyAccess();
        return UIElement.InputBindingCollectionField.GetValue((DependencyObject) this);
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public CommandBindingCollection CommandBindings
    {
      get
      {
        this.VerifyAccess();
        CommandBindingCollection bindingCollection = UIElement.CommandBindingCollectionField.GetValue((DependencyObject) this);
        if (bindingCollection == null)
        {
          bindingCollection = new CommandBindingCollection();
          UIElement.CommandBindingCollectionField.SetValue((DependencyObject) this, bindingCollection);
        }
        return bindingCollection;
      }
    }

    internal CommandBindingCollection CommandBindingsInternal
    {
      get
      {
        this.VerifyAccess();
        return UIElement.CommandBindingCollectionField.GetValue((DependencyObject) this);
      }
    }

    internal EventHandlersStore EventHandlersStore
    {
      [FriendAccessAllowed] get
      {
        if (!this.ReadFlag(CoreFlags.ExistsEventHandlersStore))
          return (EventHandlersStore) null;
        else
          return UIElement.EventHandlersStoreField.GetValue((DependencyObject) this);
      }
    }

    public bool AllowDrop
    {
      get
      {
        return (bool) this.GetValue(UIElement.AllowDropProperty);
      }
      set
      {
        this.SetValue(UIElement.AllowDropProperty, BooleanBoxes.Box(value));
      }
    }

    protected StylusPlugInCollection StylusPlugIns
    {
      get
      {
        StylusPlugInCollection plugInCollection = UIElement.StylusPlugInsField.GetValue((DependencyObject) this);
        if (plugInCollection == null)
        {
          plugInCollection = new StylusPlugInCollection(this);
          UIElement.StylusPlugInsField.SetValue((DependencyObject) this, plugInCollection);
        }
        return plugInCollection;
      }
    }

    public Size DesiredSize
    {
      get
      {
        if (this.Visibility == Visibility.Collapsed)
          return new Size(0.0, 0.0);
        else
          return this._desiredSize;
      }
    }

    internal Size PreviousConstraint
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._previousAvailableSize;
      }
    }

    public bool IsMeasureValid
    {
      get
      {
        return !this.MeasureDirty;
      }
    }

    public bool IsArrangeValid
    {
      get
      {
        return !this.ArrangeDirty;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Size RenderSize
    {
      get
      {
        if (this.Visibility == Visibility.Collapsed)
          return new Size();
        else
          return this._size;
      }
      set
      {
        this._size = value;
        this.InvalidateHitTestBounds();
      }
    }

    public Transform RenderTransform
    {
      get
      {
        return (Transform) this.GetValue(UIElement.RenderTransformProperty);
      }
      set
      {
        this.SetValue(UIElement.RenderTransformProperty, (object) value);
      }
    }

    public Point RenderTransformOrigin
    {
      get
      {
        return (Point) this.GetValue(UIElement.RenderTransformOriginProperty);
      }
      set
      {
        this.SetValue(UIElement.RenderTransformOriginProperty, (object) value);
      }
    }

    public bool IsMouseDirectlyOver
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.IsMouseDirectlyOver_ComputeValue();
      }
    }

    public bool IsMouseOver
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.IsMouseOverCache);
      }
    }

    public bool IsStylusOver
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.IsStylusOverCache);
      }
    }

    public bool IsKeyboardFocusWithin
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.IsKeyboardFocusWithinCache);
      }
    }

    public bool IsMouseCaptured
    {
      get
      {
        return (bool) this.GetValue(UIElement.IsMouseCapturedProperty);
      }
    }

    public bool IsMouseCaptureWithin
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.IsMouseCaptureWithinCache);
      }
    }

    public bool IsStylusDirectlyOver
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.IsStylusDirectlyOver_ComputeValue();
      }
    }

    public bool IsStylusCaptured
    {
      get
      {
        return (bool) this.GetValue(UIElement.IsStylusCapturedProperty);
      }
    }

    public bool IsStylusCaptureWithin
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.IsStylusCaptureWithinCache);
      }
    }

    public bool IsKeyboardFocused
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.IsKeyboardFocused_ComputeValue();
      }
    }

    public bool IsInputMethodEnabled
    {
      get
      {
        return (bool) this.GetValue(InputMethod.IsInputMethodEnabledProperty);
      }
    }

    [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
    public double Opacity
    {
      get
      {
        return (double) this.GetValue(UIElement.OpacityProperty);
      }
      set
      {
        this.SetValue(UIElement.OpacityProperty, (object) value);
      }
    }

    public Brush OpacityMask
    {
      get
      {
        return (Brush) this.GetValue(UIElement.OpacityMaskProperty);
      }
      set
      {
        this.SetValue(UIElement.OpacityMaskProperty, (object) value);
      }
    }

    [Obsolete("BitmapEffects are deprecated and no longer function.  Consider using Effects where appropriate instead.")]
    public BitmapEffect BitmapEffect
    {
      get
      {
        return (BitmapEffect) this.GetValue(UIElement.BitmapEffectProperty);
      }
      set
      {
        this.SetValue(UIElement.BitmapEffectProperty, (object) value);
      }
    }

    public Effect Effect
    {
      get
      {
        return (Effect) this.GetValue(UIElement.EffectProperty);
      }
      set
      {
        this.SetValue(UIElement.EffectProperty, (object) value);
      }
    }

    [Obsolete("BitmapEffects are deprecated and no longer function.  Consider using Effects where appropriate instead.")]
    public BitmapEffectInput BitmapEffectInput
    {
      get
      {
        return (BitmapEffectInput) this.GetValue(UIElement.BitmapEffectInputProperty);
      }
      set
      {
        this.SetValue(UIElement.BitmapEffectInputProperty, (object) value);
      }
    }

    public CacheMode CacheMode
    {
      get
      {
        return (CacheMode) this.GetValue(UIElement.CacheModeProperty);
      }
      set
      {
        this.SetValue(UIElement.CacheModeProperty, (object) value);
      }
    }

    public string Uid
    {
      get
      {
        return (string) this.GetValue(UIElement.UidProperty);
      }
      set
      {
        this.SetValue(UIElement.UidProperty, (object) value);
      }
    }

    [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
    public Visibility Visibility
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.VisibilityCache;
      }
      set
      {
        this.SetValue(UIElement.VisibilityProperty, VisibilityBoxes.Box(value));
      }
    }

    public bool ClipToBounds
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ClipToBoundsCache;
      }
      set
      {
        this.SetValue(UIElement.ClipToBoundsProperty, BooleanBoxes.Box(value));
      }
    }

    public Geometry Clip
    {
      get
      {
        return (Geometry) this.GetValue(UIElement.ClipProperty);
      }
      set
      {
        this.SetValue(UIElement.ClipProperty, (object) value);
      }
    }

    public bool SnapsToDevicePixels
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.SnapsToDevicePixelsCache;
      }
      set
      {
        this.SetValue(UIElement.SnapsToDevicePixelsProperty, value);
      }
    }

    protected internal virtual bool HasEffectiveKeyboardFocus
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.IsKeyboardFocused;
      }
    }

    public bool IsFocused
    {
      get
      {
        return (bool) this.GetValue(UIElement.IsFocusedProperty);
      }
    }

    public bool IsEnabled
    {
      get
      {
        return (bool) this.GetValue(UIElement.IsEnabledProperty);
      }
      set
      {
        this.SetValue(UIElement.IsEnabledProperty, BooleanBoxes.Box(value));
      }
    }

    protected virtual bool IsEnabledCore
    {
      get
      {
        return true;
      }
    }

    public bool IsHitTestVisible
    {
      get
      {
        return (bool) this.GetValue(UIElement.IsHitTestVisibleProperty);
      }
      set
      {
        this.SetValue(UIElement.IsHitTestVisibleProperty, BooleanBoxes.Box(value));
      }
    }

    public bool IsVisible
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.IsVisibleCache);
      }
    }

    public bool Focusable
    {
      get
      {
        return (bool) this.GetValue(UIElement.FocusableProperty);
      }
      set
      {
        this.SetValue(UIElement.FocusableProperty, BooleanBoxes.Box(value));
      }
    }

    [Obsolete("PersistId is an obsolete property and may be removed in a future release.  The value of this property is not defined.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int PersistId
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._persistId;
      }
    }

    internal Rect PreviousArrangeRect
    {
      [FriendAccessAllowed, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._finalRect;
      }
    }

    private Visibility VisibilityCache
    {
      get
      {
        if (this.CheckFlagsAnd(VisualFlags.VisibilityCache_Visible))
          return Visibility.Visible;
        if (this.CheckFlagsAnd(VisualFlags.VisibilityCache_TakesSpace))
          return Visibility.Hidden;
        else
          return Visibility.Collapsed;
      }
      set
      {
        switch (value)
        {
          case Visibility.Visible:
            this.SetFlags(true, VisualFlags.VisibilityCache_Visible);
            this.SetFlags(false, VisualFlags.VisibilityCache_TakesSpace);
            break;
          case Visibility.Hidden:
            this.SetFlags(false, VisualFlags.VisibilityCache_Visible);
            this.SetFlags(true, VisualFlags.VisibilityCache_TakesSpace);
            break;
          case Visibility.Collapsed:
            this.SetFlags(false, VisualFlags.VisibilityCache_Visible);
            this.SetFlags(false, VisualFlags.VisibilityCache_TakesSpace);
            break;
        }
      }
    }

    [CustomCategory("Touch_Category")]
    public bool IsManipulationEnabled
    {
      get
      {
        return (bool) this.GetValue(UIElement.IsManipulationEnabledProperty);
      }
      set
      {
        this.SetValue(UIElement.IsManipulationEnabledProperty, value);
      }
    }

    public bool AreAnyTouchesOver
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.TouchesOverCache);
      }
    }

    public bool AreAnyTouchesDirectlyOver
    {
      get
      {
        return (bool) this.GetValue(UIElement.AreAnyTouchesDirectlyOverProperty);
      }
    }

    public bool AreAnyTouchesCapturedWithin
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.TouchesCapturedWithinCache);
      }
    }

    public bool AreAnyTouchesCaptured
    {
      get
      {
        return (bool) this.GetValue(UIElement.AreAnyTouchesCapturedProperty);
      }
    }

    public IEnumerable<TouchDevice> TouchesCaptured
    {
      get
      {
        return TouchDevice.GetCapturedTouches((IInputElement) this, false);
      }
    }

    public IEnumerable<TouchDevice> TouchesCapturedWithin
    {
      get
      {
        return TouchDevice.GetCapturedTouches((IInputElement) this, true);
      }
    }

    public IEnumerable<TouchDevice> TouchesOver
    {
      get
      {
        return TouchDevice.GetTouchesOver((IInputElement) this, true);
      }
    }

    public IEnumerable<TouchDevice> TouchesDirectlyOver
    {
      get
      {
        return TouchDevice.GetTouchesOver((IInputElement) this, false);
      }
    }

    internal bool HasAutomationPeer
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.HasAutomationPeer);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteFlag(CoreFlags.HasAutomationPeer, value);
      }
    }

    private bool RenderingInvalidated
    {
      get
      {
        return this.ReadFlag(CoreFlags.RenderingInvalidated);
      }
      set
      {
        this.WriteFlag(CoreFlags.RenderingInvalidated, value);
      }
    }

    internal bool SnapsToDevicePixelsCache
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.SnapsToDevicePixelsCache);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteFlag(CoreFlags.SnapsToDevicePixelsCache, value);
      }
    }

    internal bool ClipToBoundsCache
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.ClipToBoundsCache);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteFlag(CoreFlags.ClipToBoundsCache, value);
      }
    }

    internal bool MeasureDirty
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.MeasureDirty);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteFlag(CoreFlags.MeasureDirty, value);
      }
    }

    internal bool ArrangeDirty
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.ArrangeDirty);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteFlag(CoreFlags.ArrangeDirty, value);
      }
    }

    internal bool MeasureInProgress
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.MeasureInProgress);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteFlag(CoreFlags.MeasureInProgress, value);
      }
    }

    internal bool ArrangeInProgress
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.ArrangeInProgress);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteFlag(CoreFlags.ArrangeInProgress, value);
      }
    }

    internal bool NeverMeasured
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.NeverMeasured);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteFlag(CoreFlags.NeverMeasured, value);
      }
    }

    internal bool NeverArranged
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.NeverArranged);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteFlag(CoreFlags.NeverArranged, value);
      }
    }

    internal bool MeasureDuringArrange
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.MeasureDuringArrange);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteFlag(CoreFlags.MeasureDuringArrange, value);
      }
    }

    internal bool AreTransformsClean
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadFlag(CoreFlags.AreTransformsClean);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteFlag(CoreFlags.AreTransformsClean, value);
      }
    }

    public event MouseButtonEventHandler PreviewMouseDown
    {
      add
      {
        this.AddHandler(Mouse.PreviewMouseDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.PreviewMouseDownEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler MouseDown
    {
      add
      {
        this.AddHandler(Mouse.MouseDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.MouseDownEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler PreviewMouseUp
    {
      add
      {
        this.AddHandler(Mouse.PreviewMouseUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.PreviewMouseUpEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler MouseUp
    {
      add
      {
        this.AddHandler(Mouse.MouseUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.MouseUpEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler PreviewMouseLeftButtonDown
    {
      add
      {
        this.AddHandler(UIElement.PreviewMouseLeftButtonDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.PreviewMouseLeftButtonDownEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler MouseLeftButtonDown
    {
      add
      {
        this.AddHandler(UIElement.MouseLeftButtonDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.MouseLeftButtonDownEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler PreviewMouseLeftButtonUp
    {
      add
      {
        this.AddHandler(UIElement.PreviewMouseLeftButtonUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.PreviewMouseLeftButtonUpEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler MouseLeftButtonUp
    {
      add
      {
        this.AddHandler(UIElement.MouseLeftButtonUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.MouseLeftButtonUpEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler PreviewMouseRightButtonDown
    {
      add
      {
        this.AddHandler(UIElement.PreviewMouseRightButtonDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.PreviewMouseRightButtonDownEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler MouseRightButtonDown
    {
      add
      {
        this.AddHandler(UIElement.MouseRightButtonDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.MouseRightButtonDownEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler PreviewMouseRightButtonUp
    {
      add
      {
        this.AddHandler(UIElement.PreviewMouseRightButtonUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.PreviewMouseRightButtonUpEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler MouseRightButtonUp
    {
      add
      {
        this.AddHandler(UIElement.MouseRightButtonUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.MouseRightButtonUpEvent, (Delegate) value);
      }
    }

    public event MouseEventHandler PreviewMouseMove
    {
      add
      {
        this.AddHandler(Mouse.PreviewMouseMoveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.PreviewMouseMoveEvent, (Delegate) value);
      }
    }

    public event MouseEventHandler MouseMove
    {
      add
      {
        this.AddHandler(Mouse.MouseMoveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.MouseMoveEvent, (Delegate) value);
      }
    }

    public event MouseWheelEventHandler PreviewMouseWheel
    {
      add
      {
        this.AddHandler(Mouse.PreviewMouseWheelEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.PreviewMouseWheelEvent, (Delegate) value);
      }
    }

    public event MouseWheelEventHandler MouseWheel
    {
      add
      {
        this.AddHandler(Mouse.MouseWheelEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.MouseWheelEvent, (Delegate) value);
      }
    }

    public event MouseEventHandler MouseEnter
    {
      add
      {
        this.AddHandler(Mouse.MouseEnterEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.MouseEnterEvent, (Delegate) value);
      }
    }

    public event MouseEventHandler MouseLeave
    {
      add
      {
        this.AddHandler(Mouse.MouseLeaveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.MouseLeaveEvent, (Delegate) value);
      }
    }

    public event MouseEventHandler GotMouseCapture
    {
      add
      {
        this.AddHandler(Mouse.GotMouseCaptureEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.GotMouseCaptureEvent, (Delegate) value);
      }
    }

    public event MouseEventHandler LostMouseCapture
    {
      add
      {
        this.AddHandler(Mouse.LostMouseCaptureEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.LostMouseCaptureEvent, (Delegate) value);
      }
    }

    public event QueryCursorEventHandler QueryCursor
    {
      add
      {
        this.AddHandler(Mouse.QueryCursorEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Mouse.QueryCursorEvent, (Delegate) value);
      }
    }

    public event StylusDownEventHandler PreviewStylusDown
    {
      add
      {
        this.AddHandler(Stylus.PreviewStylusDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.PreviewStylusDownEvent, (Delegate) value);
      }
    }

    public event StylusDownEventHandler StylusDown
    {
      add
      {
        this.AddHandler(Stylus.StylusDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.StylusDownEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler PreviewStylusUp
    {
      add
      {
        this.AddHandler(Stylus.PreviewStylusUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.PreviewStylusUpEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler StylusUp
    {
      add
      {
        this.AddHandler(Stylus.StylusUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.StylusUpEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler PreviewStylusMove
    {
      add
      {
        this.AddHandler(Stylus.PreviewStylusMoveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.PreviewStylusMoveEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler StylusMove
    {
      add
      {
        this.AddHandler(Stylus.StylusMoveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.StylusMoveEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler PreviewStylusInAirMove
    {
      add
      {
        this.AddHandler(Stylus.PreviewStylusInAirMoveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.PreviewStylusInAirMoveEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler StylusInAirMove
    {
      add
      {
        this.AddHandler(Stylus.StylusInAirMoveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.StylusInAirMoveEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler StylusEnter
    {
      add
      {
        this.AddHandler(Stylus.StylusEnterEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.StylusEnterEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler StylusLeave
    {
      add
      {
        this.AddHandler(Stylus.StylusLeaveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.StylusLeaveEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler PreviewStylusInRange
    {
      add
      {
        this.AddHandler(Stylus.PreviewStylusInRangeEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.PreviewStylusInRangeEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler StylusInRange
    {
      add
      {
        this.AddHandler(Stylus.StylusInRangeEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.StylusInRangeEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler PreviewStylusOutOfRange
    {
      add
      {
        this.AddHandler(Stylus.PreviewStylusOutOfRangeEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.PreviewStylusOutOfRangeEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler StylusOutOfRange
    {
      add
      {
        this.AddHandler(Stylus.StylusOutOfRangeEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.StylusOutOfRangeEvent, (Delegate) value);
      }
    }

    public event StylusSystemGestureEventHandler PreviewStylusSystemGesture
    {
      add
      {
        this.AddHandler(Stylus.PreviewStylusSystemGestureEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.PreviewStylusSystemGestureEvent, (Delegate) value);
      }
    }

    public event StylusSystemGestureEventHandler StylusSystemGesture
    {
      add
      {
        this.AddHandler(Stylus.StylusSystemGestureEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.StylusSystemGestureEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler GotStylusCapture
    {
      add
      {
        this.AddHandler(Stylus.GotStylusCaptureEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.GotStylusCaptureEvent, (Delegate) value);
      }
    }

    public event StylusEventHandler LostStylusCapture
    {
      add
      {
        this.AddHandler(Stylus.LostStylusCaptureEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.LostStylusCaptureEvent, (Delegate) value);
      }
    }

    public event StylusButtonEventHandler StylusButtonDown
    {
      add
      {
        this.AddHandler(Stylus.StylusButtonDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.StylusButtonDownEvent, (Delegate) value);
      }
    }

    public event StylusButtonEventHandler StylusButtonUp
    {
      add
      {
        this.AddHandler(Stylus.StylusButtonUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.StylusButtonUpEvent, (Delegate) value);
      }
    }

    public event StylusButtonEventHandler PreviewStylusButtonDown
    {
      add
      {
        this.AddHandler(Stylus.PreviewStylusButtonDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.PreviewStylusButtonDownEvent, (Delegate) value);
      }
    }

    public event StylusButtonEventHandler PreviewStylusButtonUp
    {
      add
      {
        this.AddHandler(Stylus.PreviewStylusButtonUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Stylus.PreviewStylusButtonUpEvent, (Delegate) value);
      }
    }

    public event KeyEventHandler PreviewKeyDown
    {
      add
      {
        this.AddHandler(Keyboard.PreviewKeyDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Keyboard.PreviewKeyDownEvent, (Delegate) value);
      }
    }

    public event KeyEventHandler KeyDown
    {
      add
      {
        this.AddHandler(Keyboard.KeyDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Keyboard.KeyDownEvent, (Delegate) value);
      }
    }

    public event KeyEventHandler PreviewKeyUp
    {
      add
      {
        this.AddHandler(Keyboard.PreviewKeyUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Keyboard.PreviewKeyUpEvent, (Delegate) value);
      }
    }

    public event KeyEventHandler KeyUp
    {
      add
      {
        this.AddHandler(Keyboard.KeyUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Keyboard.KeyUpEvent, (Delegate) value);
      }
    }

    public event KeyboardFocusChangedEventHandler PreviewGotKeyboardFocus
    {
      add
      {
        this.AddHandler(Keyboard.PreviewGotKeyboardFocusEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Keyboard.PreviewGotKeyboardFocusEvent, (Delegate) value);
      }
    }

    public event KeyboardFocusChangedEventHandler GotKeyboardFocus
    {
      add
      {
        this.AddHandler(Keyboard.GotKeyboardFocusEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Keyboard.GotKeyboardFocusEvent, (Delegate) value);
      }
    }

    public event KeyboardFocusChangedEventHandler PreviewLostKeyboardFocus
    {
      add
      {
        this.AddHandler(Keyboard.PreviewLostKeyboardFocusEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Keyboard.PreviewLostKeyboardFocusEvent, (Delegate) value);
      }
    }

    public event KeyboardFocusChangedEventHandler LostKeyboardFocus
    {
      add
      {
        this.AddHandler(Keyboard.LostKeyboardFocusEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Keyboard.LostKeyboardFocusEvent, (Delegate) value);
      }
    }

    public event TextCompositionEventHandler PreviewTextInput
    {
      add
      {
        this.AddHandler(TextCompositionManager.PreviewTextInputEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(TextCompositionManager.PreviewTextInputEvent, (Delegate) value);
      }
    }

    public event TextCompositionEventHandler TextInput
    {
      add
      {
        this.AddHandler(TextCompositionManager.TextInputEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(TextCompositionManager.TextInputEvent, (Delegate) value);
      }
    }

    public event QueryContinueDragEventHandler PreviewQueryContinueDrag
    {
      add
      {
        this.AddHandler(DragDrop.PreviewQueryContinueDragEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.PreviewQueryContinueDragEvent, (Delegate) value);
      }
    }

    public event QueryContinueDragEventHandler QueryContinueDrag
    {
      add
      {
        this.AddHandler(DragDrop.QueryContinueDragEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.QueryContinueDragEvent, (Delegate) value);
      }
    }

    public event GiveFeedbackEventHandler PreviewGiveFeedback
    {
      add
      {
        this.AddHandler(DragDrop.PreviewGiveFeedbackEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.PreviewGiveFeedbackEvent, (Delegate) value);
      }
    }

    public event GiveFeedbackEventHandler GiveFeedback
    {
      add
      {
        this.AddHandler(DragDrop.GiveFeedbackEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.GiveFeedbackEvent, (Delegate) value);
      }
    }

    public event DragEventHandler PreviewDragEnter
    {
      add
      {
        this.AddHandler(DragDrop.PreviewDragEnterEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.PreviewDragEnterEvent, (Delegate) value);
      }
    }

    public event DragEventHandler DragEnter
    {
      add
      {
        this.AddHandler(DragDrop.DragEnterEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.DragEnterEvent, (Delegate) value);
      }
    }

    public event DragEventHandler PreviewDragOver
    {
      add
      {
        this.AddHandler(DragDrop.PreviewDragOverEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.PreviewDragOverEvent, (Delegate) value);
      }
    }

    public event DragEventHandler DragOver
    {
      add
      {
        this.AddHandler(DragDrop.DragOverEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.DragOverEvent, (Delegate) value);
      }
    }

    public event DragEventHandler PreviewDragLeave
    {
      add
      {
        this.AddHandler(DragDrop.PreviewDragLeaveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.PreviewDragLeaveEvent, (Delegate) value);
      }
    }

    public event DragEventHandler DragLeave
    {
      add
      {
        this.AddHandler(DragDrop.DragLeaveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.DragLeaveEvent, (Delegate) value);
      }
    }

    public event DragEventHandler PreviewDrop
    {
      add
      {
        this.AddHandler(DragDrop.PreviewDropEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.PreviewDropEvent, (Delegate) value);
      }
    }

    public event DragEventHandler Drop
    {
      add
      {
        this.AddHandler(DragDrop.DropEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(DragDrop.DropEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<TouchEventArgs> PreviewTouchDown
    {
      add
      {
        this.AddHandler(Touch.PreviewTouchDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Touch.PreviewTouchDownEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<TouchEventArgs> TouchDown
    {
      add
      {
        this.AddHandler(Touch.TouchDownEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Touch.TouchDownEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<TouchEventArgs> PreviewTouchMove
    {
      add
      {
        this.AddHandler(Touch.PreviewTouchMoveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Touch.PreviewTouchMoveEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<TouchEventArgs> TouchMove
    {
      add
      {
        this.AddHandler(Touch.TouchMoveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Touch.TouchMoveEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<TouchEventArgs> PreviewTouchUp
    {
      add
      {
        this.AddHandler(Touch.PreviewTouchUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Touch.PreviewTouchUpEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<TouchEventArgs> TouchUp
    {
      add
      {
        this.AddHandler(Touch.TouchUpEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Touch.TouchUpEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<TouchEventArgs> GotTouchCapture
    {
      add
      {
        this.AddHandler(Touch.GotTouchCaptureEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Touch.GotTouchCaptureEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<TouchEventArgs> LostTouchCapture
    {
      add
      {
        this.AddHandler(Touch.LostTouchCaptureEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Touch.LostTouchCaptureEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<TouchEventArgs> TouchEnter
    {
      add
      {
        this.AddHandler(Touch.TouchEnterEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Touch.TouchEnterEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<TouchEventArgs> TouchLeave
    {
      add
      {
        this.AddHandler(Touch.TouchLeaveEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(Touch.TouchLeaveEvent, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler IsMouseDirectlyOverChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.IsMouseDirectlyOverChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.IsMouseDirectlyOverChangedKey, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler IsKeyboardFocusWithinChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.IsKeyboardFocusWithinChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.IsKeyboardFocusWithinChangedKey, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler IsMouseCapturedChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.IsMouseCapturedChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.IsMouseCapturedChangedKey, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler IsMouseCaptureWithinChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.IsMouseCaptureWithinChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.IsMouseCaptureWithinChangedKey, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler IsStylusDirectlyOverChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.IsStylusDirectlyOverChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.IsStylusDirectlyOverChangedKey, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler IsStylusCapturedChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.IsStylusCapturedChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.IsStylusCapturedChangedKey, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler IsStylusCaptureWithinChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.IsStylusCaptureWithinChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.IsStylusCaptureWithinChangedKey, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler IsKeyboardFocusedChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.IsKeyboardFocusedChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.IsKeyboardFocusedChangedKey, (Delegate) value);
      }
    }

    public event EventHandler LayoutUpdated
    {
      add
      {
        if (this.getLayoutUpdatedHandler(value) != null)
          return;
        LayoutEventList.ListItem listItem = ContextLayoutManager.From(this.Dispatcher).LayoutEvents.Add((object) value);
        this.addLayoutUpdatedHandler(value, listItem);
      }
      remove
      {
        LayoutEventList.ListItem layoutUpdatedHandler = this.getLayoutUpdatedHandler(value);
        if (layoutUpdatedHandler == null)
          return;
        this.removeLayoutUpdatedHandler(value);
        ContextLayoutManager.From(this.Dispatcher).LayoutEvents.Remove(layoutUpdatedHandler);
      }
    }

    public event RoutedEventHandler GotFocus
    {
      add
      {
        this.AddHandler(UIElement.GotFocusEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(UIElement.GotFocusEvent, (Delegate) value);
      }
    }

    public event RoutedEventHandler LostFocus
    {
      add
      {
        this.AddHandler(UIElement.LostFocusEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(UIElement.LostFocusEvent, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler IsEnabledChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.IsEnabledChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.IsEnabledChangedKey, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler IsHitTestVisibleChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.IsHitTestVisibleChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.IsHitTestVisibleChangedKey, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler IsVisibleChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.IsVisibleChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.IsVisibleChangedKey, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler FocusableChanged
    {
      add
      {
        this.EventHandlersStoreAdd(UIElement.FocusableChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(UIElement.FocusableChangedKey, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<ManipulationStartingEventArgs> ManipulationStarting
    {
      add
      {
        this.AddHandler(UIElement.ManipulationStartingEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.ManipulationStartingEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<ManipulationStartedEventArgs> ManipulationStarted
    {
      add
      {
        this.AddHandler(UIElement.ManipulationStartedEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.ManipulationStartedEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<ManipulationDeltaEventArgs> ManipulationDelta
    {
      add
      {
        this.AddHandler(UIElement.ManipulationDeltaEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.ManipulationDeltaEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<ManipulationInertiaStartingEventArgs> ManipulationInertiaStarting
    {
      add
      {
        this.AddHandler(UIElement.ManipulationInertiaStartingEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.ManipulationInertiaStartingEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<ManipulationBoundaryFeedbackEventArgs> ManipulationBoundaryFeedback
    {
      add
      {
        this.AddHandler(UIElement.ManipulationBoundaryFeedbackEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.ManipulationBoundaryFeedbackEvent, (Delegate) value);
      }
    }

    [CustomCategory("Touch_Category")]
    public event EventHandler<ManipulationCompletedEventArgs> ManipulationCompleted
    {
      add
      {
        this.AddHandler(UIElement.ManipulationCompletedEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(UIElement.ManipulationCompletedEvent, (Delegate) value);
      }
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    static UIElement()
    {
      UIElement.RegisterEvents(typeof (UIElement));
      RenderOptions.EdgeModeProperty.OverrideMetadata(typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(new PropertyChangedCallback(UIElement.EdgeMode_Changed)));
      RenderOptions.BitmapScalingModeProperty.OverrideMetadata(typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(new PropertyChangedCallback(UIElement.BitmapScalingMode_Changed)));
      RenderOptions.ClearTypeHintProperty.OverrideMetadata(typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(new PropertyChangedCallback(UIElement.ClearTypeHint_Changed)));
      TextOptionsInternal.TextHintingModeProperty.OverrideMetadata(typeof (UIElement), (PropertyMetadata) new UIPropertyMetadata(new PropertyChangedCallback(UIElement.TextHintingMode_Changed)));
      EventManager.RegisterClassHandler(typeof (UIElement), UIElement.ManipulationStartingEvent, (Delegate) new EventHandler<ManipulationStartingEventArgs>(UIElement.OnManipulationStartingThunk));
      EventManager.RegisterClassHandler(typeof (UIElement), UIElement.ManipulationStartedEvent, (Delegate) new EventHandler<ManipulationStartedEventArgs>(UIElement.OnManipulationStartedThunk));
      EventManager.RegisterClassHandler(typeof (UIElement), UIElement.ManipulationDeltaEvent, (Delegate) new EventHandler<ManipulationDeltaEventArgs>(UIElement.OnManipulationDeltaThunk));
      EventManager.RegisterClassHandler(typeof (UIElement), UIElement.ManipulationInertiaStartingEvent, (Delegate) new EventHandler<ManipulationInertiaStartingEventArgs>(UIElement.OnManipulationInertiaStartingThunk));
      EventManager.RegisterClassHandler(typeof (UIElement), UIElement.ManipulationBoundaryFeedbackEvent, (Delegate) new EventHandler<ManipulationBoundaryFeedbackEventArgs>(UIElement.OnManipulationBoundaryFeedbackThunk));
      EventManager.RegisterClassHandler(typeof (UIElement), UIElement.ManipulationCompletedEvent, (Delegate) new EventHandler<ManipulationCompletedEventArgs>(UIElement.OnManipulationCompletedThunk));
    }

    public UIElement()
    {
      this.Initialize();
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    public void ApplyAnimationClock(DependencyProperty dp, AnimationClock clock)
    {
      this.ApplyAnimationClock(dp, clock, HandoffBehavior.SnapshotAndReplace);
    }

    public void ApplyAnimationClock(DependencyProperty dp, AnimationClock clock, HandoffBehavior handoffBehavior)
    {
      if (dp == null)
        throw new ArgumentNullException("dp");
      if (!AnimationStorage.IsPropertyAnimatable((DependencyObject) this, dp))
        throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("Animation_DependencyPropertyIsNotAnimatable", (object) dp.Name, (object) this.GetType()), "dp");
      else if (clock != null && !AnimationStorage.IsAnimationValid(dp, clock.Timeline))
      {
        throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("Animation_AnimationTimelineTypeMismatch", (object) clock.Timeline.GetType(), (object) dp.Name, (object) dp.PropertyType), "clock");
      }
      else
      {
        if (!HandoffBehaviorEnum.IsDefined(handoffBehavior))
          throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("Animation_UnrecognizedHandoffBehavior"));
        if (this.IsSealed)
          throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("IAnimatable_CantAnimateSealedDO", (object) dp, (object) this.GetType()));
        else
          AnimationStorage.ApplyAnimationClock((DependencyObject) this, dp, clock, handoffBehavior);
      }
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    public void BeginAnimation(DependencyProperty dp, AnimationTimeline animation)
    {
      this.BeginAnimation(dp, animation, HandoffBehavior.SnapshotAndReplace);
    }

    public void BeginAnimation(DependencyProperty dp, AnimationTimeline animation, HandoffBehavior handoffBehavior)
    {
      if (dp == null)
        throw new ArgumentNullException("dp");
      if (!AnimationStorage.IsPropertyAnimatable((DependencyObject) this, dp))
        throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("Animation_DependencyPropertyIsNotAnimatable", (object) dp.Name, (object) this.GetType()), "dp");
      else if (animation != null && !AnimationStorage.IsAnimationValid(dp, animation))
      {
        throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("Animation_AnimationTimelineTypeMismatch", (object) animation.GetType(), (object) dp.Name, (object) dp.PropertyType), "animation");
      }
      else
      {
        if (!HandoffBehaviorEnum.IsDefined(handoffBehavior))
          throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("Animation_UnrecognizedHandoffBehavior"));
        if (this.IsSealed)
          throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("IAnimatable_CantAnimateSealedDO", (object) dp, (object) this.GetType()));
        else
          AnimationStorage.BeginAnimation((DependencyObject) this, dp, animation, handoffBehavior);
      }
    }

    public object GetAnimationBaseValue(DependencyProperty dp)
    {
      if (dp == null)
        throw new ArgumentNullException("dp");
      else
        return this.GetValueEntry(this.LookupEntry(dp.GlobalIndex), dp, (PropertyMetadata) null, RequestFlags.AnimationBaseValue).Value;
    }

    [UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows)]
    internal override sealed void EvaluateAnimatedValueCore(DependencyProperty dp, PropertyMetadata metadata, ref EffectiveValueEntry entry)
    {
      if (!this.IAnimatable_HasAnimatedProperties)
        return;
      AnimationStorage storage = AnimationStorage.GetStorage((DependencyObject) this, dp);
      if (storage == null)
        return;
      storage.EvaluateAnimatedValue(metadata, ref entry);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeInputBindings()
    {
      InputBindingCollection bindingCollection = UIElement.InputBindingCollectionField.GetValue((DependencyObject) this);
      if (bindingCollection != null && bindingCollection.Count > 0)
        return true;
      else
        return false;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCommandBindings()
    {
      CommandBindingCollection bindingCollection = UIElement.CommandBindingCollectionField.GetValue((DependencyObject) this);
      if (bindingCollection != null && bindingCollection.Count > 0)
        return true;
      else
        return false;
    }

    internal virtual bool BuildRouteCore(EventRoute route, RoutedEventArgs args)
    {
      return false;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void BuildRoute(EventRoute route, RoutedEventArgs args)
    {
      UIElement.BuildRouteHelper((DependencyObject) this, route, args);
    }

    public void RaiseEvent(RoutedEventArgs e)
    {
      if (e == null)
        throw new ArgumentNullException("e");
      e.ClearUserInitiated();
      UIElement.RaiseEventImpl((DependencyObject) this, e);
    }

    [SecurityCritical]
    internal void RaiseEvent(RoutedEventArgs args, bool trusted)
    {
      if (args == null)
        throw new ArgumentNullException("args");
      if (trusted)
      {
        this.RaiseTrustedEvent(args);
      }
      else
      {
        args.ClearUserInitiated();
        UIElement.RaiseEventImpl((DependencyObject) this, args);
      }
    }

    [SecurityCritical]
    [UserInitiatedRoutedEventPermission]
    internal void RaiseTrustedEvent(RoutedEventArgs args)
    {
      if (args == null)
        throw new ArgumentNullException("args");
      args.MarkAsUserInitiated();
      try
      {
        UIElement.RaiseEventImpl((DependencyObject) this, args);
      }
      finally
      {
        args.ClearUserInitiated();
      }
    }

    internal virtual object AdjustEventSource(RoutedEventArgs args)
    {
      return (object) null;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    public void AddHandler(RoutedEvent routedEvent, Delegate handler)
    {
      this.AddHandler(routedEvent, handler, false);
    }

    public void AddHandler(RoutedEvent routedEvent, Delegate handler, bool handledEventsToo)
    {
      if (routedEvent == null)
        throw new ArgumentNullException("routedEvent");
      if (handler == null)
        throw new ArgumentNullException("handler");
      if (!routedEvent.IsLegalHandler(handler))
        throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("HandlerTypeIllegal"));
      this.EnsureEventHandlersStore();
      this.EventHandlersStore.AddRoutedEventHandler(routedEvent, handler, handledEventsToo);
      this.OnAddHandler(routedEvent, handler);
    }

    internal virtual void OnAddHandler(RoutedEvent routedEvent, Delegate handler)
    {
    }

    public void RemoveHandler(RoutedEvent routedEvent, Delegate handler)
    {
      if (routedEvent == null)
        throw new ArgumentNullException("routedEvent");
      if (handler == null)
        throw new ArgumentNullException("handler");
      if (!routedEvent.IsLegalHandler(handler))
        throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("HandlerTypeIllegal"));
      EventHandlersStore eventHandlersStore = this.EventHandlersStore;
      if (eventHandlersStore == null)
        return;
      eventHandlersStore.RemoveRoutedEventHandler(routedEvent, handler);
      this.OnRemoveHandler(routedEvent, handler);
      if (eventHandlersStore.Count != 0)
        return;
      UIElement.EventHandlersStoreField.ClearValue((DependencyObject) this);
      this.WriteFlag(CoreFlags.ExistsEventHandlersStore, false);
    }

    internal virtual void OnRemoveHandler(RoutedEvent routedEvent, Delegate handler)
    {
    }

    public void AddToEventRoute(EventRoute route, RoutedEventArgs e)
    {
      if (route == null)
        throw new ArgumentNullException("route");
      if (e == null)
        throw new ArgumentNullException("e");
      for (RoutedEventHandlerInfoList eventHandlerInfoList = GlobalEventManager.GetDTypedClassListeners(this.DependencyObjectType, e.RoutedEvent); eventHandlerInfoList != null; eventHandlerInfoList = eventHandlerInfoList.Next)
      {
        for (int index = 0; index < eventHandlerInfoList.Handlers.Length; ++index)
          route.Add((object) this, eventHandlerInfoList.Handlers[index].Handler, eventHandlerInfoList.Handlers[index].InvokeHandledEventsToo);
      }
      EventHandlersStore eventHandlersStore = this.EventHandlersStore;
      if (eventHandlersStore != null)
      {
        FrugalObjectList<RoutedEventHandlerInfo> frugalObjectList = eventHandlersStore[e.RoutedEvent];
        if (frugalObjectList != null)
        {
          for (int index = 0; index < frugalObjectList.Count; ++index)
            route.Add((object) this, frugalObjectList[index].Handler, frugalObjectList[index].InvokeHandledEventsToo);
        }
      }
      this.AddToEventRouteCore(route, e);
    }

    internal virtual void AddToEventRouteCore(EventRoute route, RoutedEventArgs args)
    {
    }

    [FriendAccessAllowed]
    internal void EnsureEventHandlersStore()
    {
      if (this.EventHandlersStore != null)
        return;
      UIElement.EventHandlersStoreField.SetValue((DependencyObject) this, new EventHandlersStore());
      this.WriteFlag(CoreFlags.ExistsEventHandlersStore, true);
    }

    internal virtual bool InvalidateAutomationAncestorsCore(Stack<DependencyObject> branchNodeStack, out bool continuePastVisualTree)
    {
      continuePastVisualTree = false;
      return true;
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    internal static void RegisterEvents(System.Type type)
    {
      EventManager.RegisterClassHandler(type, Mouse.PreviewMouseDownEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnPreviewMouseDownThunk), true);
      EventManager.RegisterClassHandler(type, Mouse.MouseDownEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnMouseDownThunk), true);
      EventManager.RegisterClassHandler(type, Mouse.PreviewMouseUpEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnPreviewMouseUpThunk), true);
      EventManager.RegisterClassHandler(type, Mouse.MouseUpEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnMouseUpThunk), true);
      EventManager.RegisterClassHandler(type, UIElement.PreviewMouseLeftButtonDownEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnPreviewMouseLeftButtonDownThunk), false);
      EventManager.RegisterClassHandler(type, UIElement.MouseLeftButtonDownEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnMouseLeftButtonDownThunk), false);
      EventManager.RegisterClassHandler(type, UIElement.PreviewMouseLeftButtonUpEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnPreviewMouseLeftButtonUpThunk), false);
      EventManager.RegisterClassHandler(type, UIElement.MouseLeftButtonUpEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnMouseLeftButtonUpThunk), false);
      EventManager.RegisterClassHandler(type, UIElement.PreviewMouseRightButtonDownEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnPreviewMouseRightButtonDownThunk), false);
      EventManager.RegisterClassHandler(type, UIElement.MouseRightButtonDownEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnMouseRightButtonDownThunk), false);
      EventManager.RegisterClassHandler(type, UIElement.PreviewMouseRightButtonUpEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnPreviewMouseRightButtonUpThunk), false);
      EventManager.RegisterClassHandler(type, UIElement.MouseRightButtonUpEvent, (Delegate) new MouseButtonEventHandler(UIElement.OnMouseRightButtonUpThunk), false);
      EventManager.RegisterClassHandler(type, Mouse.PreviewMouseMoveEvent, (Delegate) new MouseEventHandler(UIElement.OnPreviewMouseMoveThunk), false);
      EventManager.RegisterClassHandler(type, Mouse.MouseMoveEvent, (Delegate) new MouseEventHandler(UIElement.OnMouseMoveThunk), false);
      EventManager.RegisterClassHandler(type, Mouse.PreviewMouseWheelEvent, (Delegate) new MouseWheelEventHandler(UIElement.OnPreviewMouseWheelThunk), false);
      EventManager.RegisterClassHandler(type, Mouse.MouseWheelEvent, (Delegate) new MouseWheelEventHandler(UIElement.OnMouseWheelThunk), false);
      EventManager.RegisterClassHandler(type, Mouse.MouseEnterEvent, (Delegate) new MouseEventHandler(UIElement.OnMouseEnterThunk), false);
      EventManager.RegisterClassHandler(type, Mouse.MouseLeaveEvent, (Delegate) new MouseEventHandler(UIElement.OnMouseLeaveThunk), false);
      EventManager.RegisterClassHandler(type, Mouse.GotMouseCaptureEvent, (Delegate) new MouseEventHandler(UIElement.OnGotMouseCaptureThunk), false);
      EventManager.RegisterClassHandler(type, Mouse.LostMouseCaptureEvent, (Delegate) new MouseEventHandler(UIElement.OnLostMouseCaptureThunk), false);
      EventManager.RegisterClassHandler(type, Mouse.QueryCursorEvent, (Delegate) new QueryCursorEventHandler(UIElement.OnQueryCursorThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.PreviewStylusDownEvent, (Delegate) new StylusDownEventHandler(UIElement.OnPreviewStylusDownThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.StylusDownEvent, (Delegate) new StylusDownEventHandler(UIElement.OnStylusDownThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.PreviewStylusUpEvent, (Delegate) new StylusEventHandler(UIElement.OnPreviewStylusUpThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.StylusUpEvent, (Delegate) new StylusEventHandler(UIElement.OnStylusUpThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.PreviewStylusMoveEvent, (Delegate) new StylusEventHandler(UIElement.OnPreviewStylusMoveThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.StylusMoveEvent, (Delegate) new StylusEventHandler(UIElement.OnStylusMoveThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.PreviewStylusInAirMoveEvent, (Delegate) new StylusEventHandler(UIElement.OnPreviewStylusInAirMoveThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.StylusInAirMoveEvent, (Delegate) new StylusEventHandler(UIElement.OnStylusInAirMoveThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.StylusEnterEvent, (Delegate) new StylusEventHandler(UIElement.OnStylusEnterThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.StylusLeaveEvent, (Delegate) new StylusEventHandler(UIElement.OnStylusLeaveThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.PreviewStylusInRangeEvent, (Delegate) new StylusEventHandler(UIElement.OnPreviewStylusInRangeThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.StylusInRangeEvent, (Delegate) new StylusEventHandler(UIElement.OnStylusInRangeThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.PreviewStylusOutOfRangeEvent, (Delegate) new StylusEventHandler(UIElement.OnPreviewStylusOutOfRangeThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.StylusOutOfRangeEvent, (Delegate) new StylusEventHandler(UIElement.OnStylusOutOfRangeThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.PreviewStylusSystemGestureEvent, (Delegate) new StylusSystemGestureEventHandler(UIElement.OnPreviewStylusSystemGestureThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.StylusSystemGestureEvent, (Delegate) new StylusSystemGestureEventHandler(UIElement.OnStylusSystemGestureThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.GotStylusCaptureEvent, (Delegate) new StylusEventHandler(UIElement.OnGotStylusCaptureThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.LostStylusCaptureEvent, (Delegate) new StylusEventHandler(UIElement.OnLostStylusCaptureThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.StylusButtonDownEvent, (Delegate) new StylusButtonEventHandler(UIElement.OnStylusButtonDownThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.StylusButtonUpEvent, (Delegate) new StylusButtonEventHandler(UIElement.OnStylusButtonUpThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.PreviewStylusButtonDownEvent, (Delegate) new StylusButtonEventHandler(UIElement.OnPreviewStylusButtonDownThunk), false);
      EventManager.RegisterClassHandler(type, Stylus.PreviewStylusButtonUpEvent, (Delegate) new StylusButtonEventHandler(UIElement.OnPreviewStylusButtonUpThunk), false);
      EventManager.RegisterClassHandler(type, Keyboard.PreviewKeyDownEvent, (Delegate) new KeyEventHandler(UIElement.OnPreviewKeyDownThunk), false);
      EventManager.RegisterClassHandler(type, Keyboard.KeyDownEvent, (Delegate) new KeyEventHandler(UIElement.OnKeyDownThunk), false);
      EventManager.RegisterClassHandler(type, Keyboard.PreviewKeyUpEvent, (Delegate) new KeyEventHandler(UIElement.OnPreviewKeyUpThunk), false);
      EventManager.RegisterClassHandler(type, Keyboard.KeyUpEvent, (Delegate) new KeyEventHandler(UIElement.OnKeyUpThunk), false);
      EventManager.RegisterClassHandler(type, Keyboard.PreviewGotKeyboardFocusEvent, (Delegate) new KeyboardFocusChangedEventHandler(UIElement.OnPreviewGotKeyboardFocusThunk), false);
      EventManager.RegisterClassHandler(type, Keyboard.GotKeyboardFocusEvent, (Delegate) new KeyboardFocusChangedEventHandler(UIElement.OnGotKeyboardFocusThunk), false);
      EventManager.RegisterClassHandler(type, Keyboard.PreviewLostKeyboardFocusEvent, (Delegate) new KeyboardFocusChangedEventHandler(UIElement.OnPreviewLostKeyboardFocusThunk), false);
      EventManager.RegisterClassHandler(type, Keyboard.LostKeyboardFocusEvent, (Delegate) new KeyboardFocusChangedEventHandler(UIElement.OnLostKeyboardFocusThunk), false);
      EventManager.RegisterClassHandler(type, TextCompositionManager.PreviewTextInputEvent, (Delegate) new TextCompositionEventHandler(UIElement.OnPreviewTextInputThunk), false);
      EventManager.RegisterClassHandler(type, TextCompositionManager.TextInputEvent, (Delegate) new TextCompositionEventHandler(UIElement.OnTextInputThunk), false);
      EventManager.RegisterClassHandler(type, CommandManager.PreviewExecutedEvent, (Delegate) new ExecutedRoutedEventHandler(UIElement.OnPreviewExecutedThunk), false);
      EventManager.RegisterClassHandler(type, CommandManager.ExecutedEvent, (Delegate) new ExecutedRoutedEventHandler(UIElement.OnExecutedThunk), false);
      EventManager.RegisterClassHandler(type, CommandManager.PreviewCanExecuteEvent, (Delegate) new CanExecuteRoutedEventHandler(UIElement.OnPreviewCanExecuteThunk), false);
      EventManager.RegisterClassHandler(type, CommandManager.CanExecuteEvent, (Delegate) new CanExecuteRoutedEventHandler(UIElement.OnCanExecuteThunk), false);
      EventManager.RegisterClassHandler(type, CommandDevice.CommandDeviceEvent, (Delegate) new CommandDeviceEventHandler(UIElement.OnCommandDeviceThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.PreviewQueryContinueDragEvent, (Delegate) new QueryContinueDragEventHandler(UIElement.OnPreviewQueryContinueDragThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.QueryContinueDragEvent, (Delegate) new QueryContinueDragEventHandler(UIElement.OnQueryContinueDragThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.PreviewGiveFeedbackEvent, (Delegate) new GiveFeedbackEventHandler(UIElement.OnPreviewGiveFeedbackThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.GiveFeedbackEvent, (Delegate) new GiveFeedbackEventHandler(UIElement.OnGiveFeedbackThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.PreviewDragEnterEvent, (Delegate) new DragEventHandler(UIElement.OnPreviewDragEnterThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.DragEnterEvent, (Delegate) new DragEventHandler(UIElement.OnDragEnterThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.PreviewDragOverEvent, (Delegate) new DragEventHandler(UIElement.OnPreviewDragOverThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.DragOverEvent, (Delegate) new DragEventHandler(UIElement.OnDragOverThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.PreviewDragLeaveEvent, (Delegate) new DragEventHandler(UIElement.OnPreviewDragLeaveThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.DragLeaveEvent, (Delegate) new DragEventHandler(UIElement.OnDragLeaveThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.PreviewDropEvent, (Delegate) new DragEventHandler(UIElement.OnPreviewDropThunk), false);
      EventManager.RegisterClassHandler(type, DragDrop.DropEvent, (Delegate) new DragEventHandler(UIElement.OnDropThunk), false);
      EventManager.RegisterClassHandler(type, Touch.PreviewTouchDownEvent, (Delegate) new EventHandler<TouchEventArgs>(UIElement.OnPreviewTouchDownThunk), false);
      EventManager.RegisterClassHandler(type, Touch.TouchDownEvent, (Delegate) new EventHandler<TouchEventArgs>(UIElement.OnTouchDownThunk), false);
      EventManager.RegisterClassHandler(type, Touch.PreviewTouchMoveEvent, (Delegate) new EventHandler<TouchEventArgs>(UIElement.OnPreviewTouchMoveThunk), false);
      EventManager.RegisterClassHandler(type, Touch.TouchMoveEvent, (Delegate) new EventHandler<TouchEventArgs>(UIElement.OnTouchMoveThunk), false);
      EventManager.RegisterClassHandler(type, Touch.PreviewTouchUpEvent, (Delegate) new EventHandler<TouchEventArgs>(UIElement.OnPreviewTouchUpThunk), false);
      EventManager.RegisterClassHandler(type, Touch.TouchUpEvent, (Delegate) new EventHandler<TouchEventArgs>(UIElement.OnTouchUpThunk), false);
      EventManager.RegisterClassHandler(type, Touch.GotTouchCaptureEvent, (Delegate) new EventHandler<TouchEventArgs>(UIElement.OnGotTouchCaptureThunk), false);
      EventManager.RegisterClassHandler(type, Touch.LostTouchCaptureEvent, (Delegate) new EventHandler<TouchEventArgs>(UIElement.OnLostTouchCaptureThunk), false);
      EventManager.RegisterClassHandler(type, Touch.TouchEnterEvent, (Delegate) new EventHandler<TouchEventArgs>(UIElement.OnTouchEnterThunk), false);
      EventManager.RegisterClassHandler(type, Touch.TouchLeaveEvent, (Delegate) new EventHandler<TouchEventArgs>(UIElement.OnTouchLeaveThunk), false);
    }

    protected virtual void OnPreviewMouseDown(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnMouseDown(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnPreviewMouseUp(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnMouseUp(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnMouseLeftButtonUp(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnPreviewMouseRightButtonDown(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnMouseRightButtonDown(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnMouseRightButtonUp(MouseButtonEventArgs e)
    {
    }

    protected virtual void OnPreviewMouseMove(MouseEventArgs e)
    {
    }

    protected virtual void OnMouseMove(MouseEventArgs e)
    {
    }

    protected virtual void OnPreviewMouseWheel(MouseWheelEventArgs e)
    {
    }

    protected virtual void OnMouseWheel(MouseWheelEventArgs e)
    {
    }

    protected virtual void OnMouseEnter(MouseEventArgs e)
    {
    }

    protected virtual void OnMouseLeave(MouseEventArgs e)
    {
    }

    protected virtual void OnGotMouseCapture(MouseEventArgs e)
    {
    }

    protected virtual void OnLostMouseCapture(MouseEventArgs e)
    {
    }

    protected virtual void OnQueryCursor(QueryCursorEventArgs e)
    {
    }

    protected virtual void OnPreviewStylusDown(StylusDownEventArgs e)
    {
    }

    protected virtual void OnStylusDown(StylusDownEventArgs e)
    {
    }

    protected virtual void OnPreviewStylusUp(StylusEventArgs e)
    {
    }

    protected virtual void OnStylusUp(StylusEventArgs e)
    {
    }

    protected virtual void OnPreviewStylusMove(StylusEventArgs e)
    {
    }

    protected virtual void OnStylusMove(StylusEventArgs e)
    {
    }

    protected virtual void OnPreviewStylusInAirMove(StylusEventArgs e)
    {
    }

    protected virtual void OnStylusInAirMove(StylusEventArgs e)
    {
    }

    protected virtual void OnStylusEnter(StylusEventArgs e)
    {
    }

    protected virtual void OnStylusLeave(StylusEventArgs e)
    {
    }

    protected virtual void OnPreviewStylusInRange(StylusEventArgs e)
    {
    }

    protected virtual void OnStylusInRange(StylusEventArgs e)
    {
    }

    protected virtual void OnPreviewStylusOutOfRange(StylusEventArgs e)
    {
    }

    protected virtual void OnStylusOutOfRange(StylusEventArgs e)
    {
    }

    protected virtual void OnPreviewStylusSystemGesture(StylusSystemGestureEventArgs e)
    {
    }

    protected virtual void OnStylusSystemGesture(StylusSystemGestureEventArgs e)
    {
    }

    protected virtual void OnGotStylusCapture(StylusEventArgs e)
    {
    }

    protected virtual void OnLostStylusCapture(StylusEventArgs e)
    {
    }

    protected virtual void OnStylusButtonDown(StylusButtonEventArgs e)
    {
    }

    protected virtual void OnStylusButtonUp(StylusButtonEventArgs e)
    {
    }

    protected virtual void OnPreviewStylusButtonDown(StylusButtonEventArgs e)
    {
    }

    protected virtual void OnPreviewStylusButtonUp(StylusButtonEventArgs e)
    {
    }

    protected virtual void OnPreviewKeyDown(KeyEventArgs e)
    {
    }

    protected virtual void OnKeyDown(KeyEventArgs e)
    {
    }

    protected virtual void OnPreviewKeyUp(KeyEventArgs e)
    {
    }

    protected virtual void OnKeyUp(KeyEventArgs e)
    {
    }

    protected virtual void OnPreviewGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
    {
    }

    protected virtual void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
    {
    }

    protected virtual void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
    {
    }

    protected virtual void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
    {
    }

    protected virtual void OnPreviewTextInput(TextCompositionEventArgs e)
    {
    }

    protected virtual void OnTextInput(TextCompositionEventArgs e)
    {
    }

    protected virtual void OnPreviewQueryContinueDrag(QueryContinueDragEventArgs e)
    {
    }

    protected virtual void OnQueryContinueDrag(QueryContinueDragEventArgs e)
    {
    }

    protected virtual void OnPreviewGiveFeedback(GiveFeedbackEventArgs e)
    {
    }

    protected virtual void OnGiveFeedback(GiveFeedbackEventArgs e)
    {
    }

    protected virtual void OnPreviewDragEnter(DragEventArgs e)
    {
    }

    protected virtual void OnDragEnter(DragEventArgs e)
    {
    }

    protected virtual void OnPreviewDragOver(DragEventArgs e)
    {
    }

    protected virtual void OnDragOver(DragEventArgs e)
    {
    }

    protected virtual void OnPreviewDragLeave(DragEventArgs e)
    {
    }

    protected virtual void OnDragLeave(DragEventArgs e)
    {
    }

    protected virtual void OnPreviewDrop(DragEventArgs e)
    {
    }

    protected virtual void OnDrop(DragEventArgs e)
    {
    }

    protected virtual void OnPreviewTouchDown(TouchEventArgs e)
    {
    }

    protected virtual void OnTouchDown(TouchEventArgs e)
    {
    }

    protected virtual void OnPreviewTouchMove(TouchEventArgs e)
    {
    }

    protected virtual void OnTouchMove(TouchEventArgs e)
    {
    }

    protected virtual void OnPreviewTouchUp(TouchEventArgs e)
    {
    }

    protected virtual void OnTouchUp(TouchEventArgs e)
    {
    }

    protected virtual void OnGotTouchCapture(TouchEventArgs e)
    {
    }

    protected virtual void OnLostTouchCapture(TouchEventArgs e)
    {
    }

    protected virtual void OnTouchEnter(TouchEventArgs e)
    {
    }

    protected virtual void OnTouchLeave(TouchEventArgs e)
    {
    }

    protected virtual void OnIsMouseDirectlyOverChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    protected virtual void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    internal void RaiseIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs args)
    {
      this.OnIsKeyboardFocusWithinChanged(args);
      this.RaiseDependencyPropertyChanged(UIElement.IsKeyboardFocusWithinChangedKey, args);
    }

    protected virtual void OnIsMouseCapturedChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    protected virtual void OnIsMouseCaptureWithinChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    internal void RaiseIsMouseCaptureWithinChanged(DependencyPropertyChangedEventArgs args)
    {
      this.OnIsMouseCaptureWithinChanged(args);
      this.RaiseDependencyPropertyChanged(UIElement.IsMouseCaptureWithinChangedKey, args);
    }

    protected virtual void OnIsStylusDirectlyOverChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    protected virtual void OnIsStylusCapturedChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    protected virtual void OnIsStylusCaptureWithinChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    internal void RaiseIsStylusCaptureWithinChanged(DependencyPropertyChangedEventArgs args)
    {
      this.OnIsStylusCaptureWithinChanged(args);
      this.RaiseDependencyPropertyChanged(UIElement.IsStylusCaptureWithinChangedKey, args);
    }

    protected virtual void OnIsKeyboardFocusedChanged(DependencyPropertyChangedEventArgs e)
    {
    }

    internal bool ReadFlag(CoreFlags field)
    {
      return (this._flags & field) != CoreFlags.None;
    }

    internal void WriteFlag(CoreFlags field, bool value)
    {
      if (value)
        this._flags |= field;
      else
        this._flags &= ~field;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void InvalidateMeasureInternal()
    {
      this.MeasureDirty = true;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void InvalidateArrangeInternal()
    {
      this.ArrangeDirty = true;
    }

    public void InvalidateMeasure()
    {
      if (this.MeasureDirty || this.MeasureInProgress)
        return;
      if (!this.NeverMeasured)
      {
        ContextLayoutManager contextLayoutManager = ContextLayoutManager.From(this.Dispatcher);
        if (EventTrace.IsEnabled(EventTrace.Keyword.KeywordLayout, EventTrace.Level.Verbose) && contextLayoutManager.MeasureQueue.IsEmpty)
        {
          int num = (int) EventTrace.EventProvider.TraceEvent(EventTrace.Event.WClientLayoutInvalidated, EventTrace.Keyword.KeywordLayout, EventTrace.Level.Verbose, (object) PerfService.GetPerfElementID((object) this));
        }
        contextLayoutManager.MeasureQueue.Add(this);
      }
      this.MeasureDirty = true;
    }

    public void InvalidateArrange()
    {
      if (this.ArrangeDirty || this.ArrangeInProgress)
        return;
      if (!this.NeverArranged)
        ContextLayoutManager.From(this.Dispatcher).ArrangeQueue.Add(this);
      this.ArrangeDirty = true;
    }

    public void InvalidateVisual()
    {
      this.InvalidateArrange();
      this.RenderingInvalidated = true;
    }

    protected virtual void OnChildDesiredSizeChanged(UIElement child)
    {
      if (!this.IsMeasureValid)
        return;
      this.InvalidateMeasure();
    }

    internal static void PropagateSuspendLayout(Visual v)
    {
      if (v.CheckFlagsAnd(VisualFlags.IsLayoutIslandRoot) || v.CheckFlagsAnd(VisualFlags.IsLayoutSuspended))
        return;
      if (Invariant.Strict && v.CheckFlagsAnd(VisualFlags.IsUIElement))
      {
        UIElement uiElement = (UIElement) v;
        Invariant.Assert(!uiElement.MeasureInProgress && !uiElement.ArrangeInProgress);
      }
      v.SetFlags(true, VisualFlags.IsLayoutSuspended);
      v.TreeLevel = 0U;
      int visualChildrenCount = v.InternalVisualChildrenCount;
      for (int index = 0; index < visualChildrenCount; ++index)
      {
        Visual visualChild = v.InternalGetVisualChild(index);
        if (visualChild != null)
          UIElement.PropagateSuspendLayout(visualChild);
      }
    }

    internal static void PropagateResumeLayout(Visual parent, Visual v)
    {
      if (v.CheckFlagsAnd(VisualFlags.IsLayoutIslandRoot))
        return;
      bool flag1 = parent != null && parent.CheckFlagsAnd(VisualFlags.IsLayoutSuspended);
      uint num = parent == null ? 0U : parent.TreeLevel;
      if (flag1)
        return;
      v.SetFlags(false, VisualFlags.IsLayoutSuspended);
      v.TreeLevel = num + 1U;
      if (v.CheckFlagsAnd(VisualFlags.IsUIElement))
      {
        UIElement e = (UIElement) v;
        Invariant.Assert(!e.MeasureInProgress && !e.ArrangeInProgress);
        bool flag2 = e.MeasureDirty && !e.NeverMeasured && e.MeasureRequest == null;
        bool flag3 = e.ArrangeDirty && !e.NeverArranged && e.ArrangeRequest == null;
        ContextLayoutManager contextLayoutManager = flag2 || flag3 ? ContextLayoutManager.From(e.Dispatcher) : (ContextLayoutManager) null;
        if (flag2)
          contextLayoutManager.MeasureQueue.Add(e);
        if (flag3)
          contextLayoutManager.ArrangeQueue.Add(e);
      }
      int visualChildrenCount = v.InternalVisualChildrenCount;
      for (int index = 0; index < visualChildrenCount; ++index)
      {
        Visual visualChild = v.InternalGetVisualChild(index);
        if (visualChild != null)
          UIElement.PropagateResumeLayout(v, visualChild);
      }
    }

    public void Measure(Size availableSize)
    {
      bool flag1 = false;
      long num1 = 0L;
      if (ContextLayoutManager.From(this.Dispatcher).AutomationEvents.Count != 0)
        UIElementHelper.InvalidateAutomationAncestors((DependencyObject) this);
      if (EventTrace.IsEnabled(EventTrace.Keyword.KeywordLayout, EventTrace.Level.Verbose))
      {
        num1 = PerfService.GetPerfElementID((object) this);
        flag1 = true;
        int num2 = (int) EventTrace.EventProvider.TraceEvent(EventTrace.Event.WClientMeasureElementBegin, EventTrace.Keyword.KeywordLayout, EventTrace.Level.Verbose, (object) num1, (object) availableSize.Width, (object) availableSize.Height);
      }
      try
      {
        using (this.Dispatcher.DisableProcessing())
        {
          if (DoubleUtil.IsNaN(availableSize.Width) || DoubleUtil.IsNaN(availableSize.Height))
            throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("UIElement_Layout_NaNMeasure"));
          bool neverMeasured = this.NeverMeasured;
          if (neverMeasured)
          {
            this.switchVisibilityIfNeeded(this.Visibility);
            this.pushVisualEffects();
          }
          bool flag2 = DoubleUtil.AreClose(availableSize, this._previousAvailableSize);
          if (this.Visibility == Visibility.Collapsed || this.CheckFlagsAnd(VisualFlags.IsLayoutSuspended))
          {
            if (this.MeasureRequest != null)
              ContextLayoutManager.From(this.Dispatcher).MeasureQueue.Remove(this);
            if (flag2)
              return;
            this.InvalidateMeasureInternal();
            this._previousAvailableSize = availableSize;
          }
          else
          {
            if (this.IsMeasureValid && !neverMeasured && flag2)
              return;
            this.NeverMeasured = false;
            Size size1 = this._desiredSize;
            this.InvalidateArrange();
            this.MeasureInProgress = true;
            Size size2 = new Size(0.0, 0.0);
            ContextLayoutManager contextLayoutManager = ContextLayoutManager.From(this.Dispatcher);
            bool flag3 = true;
            try
            {
              contextLayoutManager.EnterMeasure();
              size2 = this.MeasureCore(availableSize);
              flag3 = false;
            }
            finally
            {
              this.MeasureInProgress = false;
              this._previousAvailableSize = availableSize;
              contextLayoutManager.ExitMeasure();
              if (flag3 && contextLayoutManager.GetLastExceptionElement() == null)
                contextLayoutManager.SetLastExceptionElement(this);
            }
            if (double.IsPositiveInfinity(size2.Width) || double.IsPositiveInfinity(size2.Height))
              throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("UIElement_Layout_PositiveInfinityReturned", new object[1]
              {
                (object) this.GetType().FullName
              }));
            else if (DoubleUtil.IsNaN(size2.Width) || DoubleUtil.IsNaN(size2.Height))
            {
              throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("UIElement_Layout_NaNReturned", new object[1]
              {
                (object) this.GetType().FullName
              }));
            }
            else
            {
              this.MeasureDirty = false;
              if (this.MeasureRequest != null)
                ContextLayoutManager.From(this.Dispatcher).MeasureQueue.Remove(this);
              this._desiredSize = size2;
              if (this.MeasureDuringArrange || DoubleUtil.AreClose(size1, size2))
                return;
              UIElement uiParent;
              IContentHost ich;
              this.GetUIParentOrICH(out uiParent, out ich);
              if (uiParent != null && !uiParent.MeasureInProgress)
              {
                uiParent.OnChildDesiredSizeChanged(this);
              }
              else
              {
                if (ich == null)
                  return;
                ich.OnChildDesiredSizeChanged(this);
              }
            }
          }
        }
      }
      finally
      {
        if (flag1)
        {
          int num2 = (int) EventTrace.EventProvider.TraceEvent(EventTrace.Event.WClientMeasureElementEnd, EventTrace.Keyword.KeywordLayout, EventTrace.Level.Verbose, (object) num1, (object) this._desiredSize.Width, (object) this._desiredSize.Height);
        }
      }
    }

    internal void GetUIParentOrICH(out UIElement uiParent, out IContentHost ich)
    {
      ich = (IContentHost) null;
      uiParent = (UIElement) null;
      for (Visual visual = VisualTreeHelper.GetParent((DependencyObject) this) as Visual; visual != null; visual = VisualTreeHelper.GetParent((DependencyObject) visual) as Visual)
      {
        ich = visual as IContentHost;
        if (ich != null)
          break;
        if (visual.CheckFlagsAnd(VisualFlags.IsUIElement))
        {
          uiParent = (UIElement) visual;
          break;
        }
      }
    }

    internal UIElement GetUIParentWithinLayoutIsland()
    {
      UIElement uiElement = (UIElement) null;
      for (Visual visual = VisualTreeHelper.GetParent((DependencyObject) this) as Visual; visual != null && !visual.CheckFlagsAnd(VisualFlags.IsLayoutIslandRoot); visual = VisualTreeHelper.GetParent((DependencyObject) visual) as Visual)
      {
        if (visual.CheckFlagsAnd(VisualFlags.IsUIElement))
        {
          uiElement = (UIElement) visual;
          break;
        }
      }
      return uiElement;
    }

    public void Arrange(Rect finalRect)
    {
      bool flag1 = false;
      long num1 = 0L;
      if (ContextLayoutManager.From(this.Dispatcher).AutomationEvents.Count != 0)
        UIElementHelper.InvalidateAutomationAncestors((DependencyObject) this);
      if (EventTrace.IsEnabled(EventTrace.Keyword.KeywordLayout, EventTrace.Level.Verbose))
      {
        num1 = PerfService.GetPerfElementID((object) this);
        flag1 = true;
        int num2 = (int) EventTrace.EventProvider.TraceEvent(EventTrace.Event.WClientArrangeElementBegin, EventTrace.Keyword.KeywordLayout, EventTrace.Level.Verbose, (object) num1, (object) finalRect.Top, (object) finalRect.Left, (object) finalRect.Width, (object) finalRect.Height);
      }
      try
      {
        using (this.Dispatcher.DisableProcessing())
        {
          if (double.IsPositiveInfinity(finalRect.Width) || double.IsPositiveInfinity(finalRect.Height) || (DoubleUtil.IsNaN(finalRect.Width) || DoubleUtil.IsNaN(finalRect.Height)))
          {
            DependencyObject dependencyObject = (DependencyObject) (this.GetUIParent() as UIElement);
            throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("UIElement_Layout_InfinityArrange", dependencyObject == null ? (object) "" : (object) dependencyObject.GetType().FullName, (object) this.GetType().FullName));
          }
          else if (this.Visibility == Visibility.Collapsed || this.CheckFlagsAnd(VisualFlags.IsLayoutSuspended))
          {
            if (this.ArrangeRequest != null)
              ContextLayoutManager.From(this.Dispatcher).ArrangeQueue.Remove(this);
            this._finalRect = finalRect;
          }
          else
          {
            if (this.MeasureDirty || this.NeverMeasured)
            {
              try
              {
                this.MeasureDuringArrange = true;
                if (this.NeverMeasured)
                  this.Measure(finalRect.Size);
                else
                  this.Measure(this.PreviousConstraint);
              }
              finally
              {
                this.MeasureDuringArrange = false;
              }
            }
            if (this.IsArrangeValid && !this.NeverArranged && DoubleUtil.AreClose(finalRect, this._finalRect))
              return;
            bool neverArranged = this.NeverArranged;
            this.NeverArranged = false;
            this.ArrangeInProgress = true;
            ContextLayoutManager contextLayoutManager = ContextLayoutManager.From(this.Dispatcher);
            Size renderSize = this.RenderSize;
            bool flag2 = false;
            bool flag3 = true;
            if (this.CheckFlagsAnd(VisualFlags.UseLayoutRounding))
            {
              UIElement.EnsureDpiScale();
              finalRect = UIElement.RoundLayoutRect(finalRect, UIElement._dpiScaleX, UIElement._dpiScaleY);
            }
            try
            {
              contextLayoutManager.EnterArrange();
              this.ArrangeCore(finalRect);
              this.ensureClip(finalRect.Size);
              flag2 = this.markForSizeChangedIfNeeded(renderSize, this.RenderSize);
              flag3 = false;
            }
            finally
            {
              this.ArrangeInProgress = false;
              contextLayoutManager.ExitArrange();
              if (flag3 && contextLayoutManager.GetLastExceptionElement() == null)
                contextLayoutManager.SetLastExceptionElement(this);
            }
            this._finalRect = finalRect;
            this.ArrangeDirty = false;
            if (this.ArrangeRequest != null)
              ContextLayoutManager.From(this.Dispatcher).ArrangeQueue.Remove(this);
            if ((flag2 || this.RenderingInvalidated || neverArranged) && this.IsRenderable())
            {
              DrawingContext drawingContext = this.RenderOpen();
              try
              {
                bool flag4 = EventTrace.IsEnabled(EventTrace.Keyword.KeywordPerf | EventTrace.Keyword.KeywordGraphics, EventTrace.Level.Verbose);
                if (flag4)
                {
                  int num2 = (int) EventTrace.EventProvider.TraceEvent(EventTrace.Event.WClientOnRenderBegin, EventTrace.Keyword.KeywordPerf | EventTrace.Keyword.KeywordGraphics, EventTrace.Level.Verbose, (object) num1);
                }
                try
                {
                  this.OnRender(drawingContext);
                }
                finally
                {
                  if (flag4)
                  {
                    int num3 = (int) EventTrace.EventProvider.TraceEvent(EventTrace.Event.WClientOnRenderEnd, EventTrace.Keyword.KeywordPerf | EventTrace.Keyword.KeywordGraphics, EventTrace.Level.Verbose, (object) num1);
                  }
                }
              }
              finally
              {
                drawingContext.Close();
                this.RenderingInvalidated = false;
              }
              this.updatePixelSnappingGuidelines();
            }
            if (!neverArranged)
              return;
            this.EndPropertyInitialization();
          }
        }
      }
      finally
      {
        if (flag1)
        {
          int num2 = (int) EventTrace.EventProvider.TraceEvent(EventTrace.Event.WClientArrangeElementEnd, EventTrace.Keyword.KeywordLayout, EventTrace.Level.Verbose, (object) num1, (object) finalRect.Top, (object) finalRect.Left, (object) finalRect.Width, (object) finalRect.Height);
        }
      }
    }

    protected virtual void OnRender(DrawingContext drawingContext)
    {
    }

    internal static Size RoundLayoutSize(Size size, double dpiScaleX, double dpiScaleY)
    {
      return new Size(UIElement.RoundLayoutValue(size.Width, dpiScaleX), UIElement.RoundLayoutValue(size.Height, dpiScaleY));
    }

    internal static double RoundLayoutValue(double value, double dpiScale)
    {
      double d;
      if (!DoubleUtil.AreClose(dpiScale, 1.0))
      {
        d = Math.Round(value * dpiScale) / dpiScale;
        if (DoubleUtil.IsNaN(d) || double.IsInfinity(d) || DoubleUtil.AreClose(d, double.MaxValue))
          d = value;
      }
      else
        d = Math.Round(value);
      return d;
    }

    internal static Rect RoundLayoutRect(Rect rect, double dpiScaleX, double dpiScaleY)
    {
      return new Rect(UIElement.RoundLayoutValue(rect.X, dpiScaleX), UIElement.RoundLayoutValue(rect.Y, dpiScaleY), UIElement.RoundLayoutValue(rect.Width, dpiScaleX), UIElement.RoundLayoutValue(rect.Height, dpiScaleY));
    }

    protected internal virtual void OnRenderSizeChanged(SizeChangedInfo info)
    {
    }

    protected virtual Size MeasureCore(Size availableSize)
    {
      return new Size(0.0, 0.0);
    }

    protected virtual void ArrangeCore(Rect finalRect)
    {
      this.RenderSize = finalRect.Size;
      Transform transform = this.RenderTransform;
      if (transform == Transform.Identity)
        transform = (Transform) null;
      Vector visualOffset = this.VisualOffset;
      if (!DoubleUtil.AreClose(visualOffset.X, finalRect.X) || !DoubleUtil.AreClose(visualOffset.Y, finalRect.Y))
        this.VisualOffset = new Vector(finalRect.X, finalRect.Y);
      if (transform != null)
      {
        TransformGroup transformGroup = new TransformGroup();
        Point renderTransformOrigin = this.RenderTransformOrigin;
        bool flag = renderTransformOrigin.X != 0.0 || renderTransformOrigin.Y != 0.0;
        if (flag)
          transformGroup.Children.Add((Transform) new TranslateTransform(-(finalRect.Width * renderTransformOrigin.X), -(finalRect.Height * renderTransformOrigin.Y)));
        transformGroup.Children.Add(transform);
        if (flag)
          transformGroup.Children.Add((Transform) new TranslateTransform(finalRect.Width * renderTransformOrigin.X, finalRect.Height * renderTransformOrigin.Y));
        this.VisualTransform = (Transform) transformGroup;
      }
      else
        this.VisualTransform = (Transform) null;
    }

    internal override Rect GetHitTestBounds()
    {
      Rect rect = new Rect(this._size);
      if (this._drawingContent != null)
      {
        MediaContext mediaContext = MediaContext.From(this.Dispatcher);
        BoundsDrawingContextWalker ctx = mediaContext.AcquireBoundsDrawingContextWalker();
        Rect contentBounds = this._drawingContent.GetContentBounds(ctx);
        mediaContext.ReleaseBoundsDrawingContextWalker(ctx);
        rect.Union(contentBounds);
      }
      return rect;
    }

    protected internal override void OnVisualParentChanged(DependencyObject oldParent)
    {
      if (this._parent != null)
      {
        DependencyObject dependencyObject = this._parent;
        if (!InputElement.IsUIElement(dependencyObject) && !InputElement.IsUIElement3D(dependencyObject))
        {
          Visual visual = dependencyObject as Visual;
          if (visual != null)
          {
            visual.VisualAncestorChanged += new Visual.AncestorChangedEventHandler(this.OnVisualAncestorChanged_ForceInherit);
            dependencyObject = InputElement.GetContainingUIElement((DependencyObject) visual);
          }
          else
          {
            Visual3D visual3D = dependencyObject as Visual3D;
            if (visual3D != null)
            {
              visual3D.VisualAncestorChanged += new Visual.AncestorChangedEventHandler(this.OnVisualAncestorChanged_ForceInherit);
              dependencyObject = InputElement.GetContainingUIElement((DependencyObject) visual3D);
            }
          }
        }
        if (dependencyObject != null)
          UIElement.SynchronizeForceInheritProperties(this, (ContentElement) null, (UIElement3D) null, dependencyObject);
      }
      else
      {
        DependencyObject dependencyObject = oldParent;
        if (!InputElement.IsUIElement(dependencyObject) && !InputElement.IsUIElement3D(dependencyObject))
        {
          if (oldParent is Visual)
            ((Visual) oldParent).VisualAncestorChanged -= new Visual.AncestorChangedEventHandler(this.OnVisualAncestorChanged_ForceInherit);
          else if (oldParent is Visual3D)
            ((Visual3D) oldParent).VisualAncestorChanged -= new Visual.AncestorChangedEventHandler(this.OnVisualAncestorChanged_ForceInherit);
          dependencyObject = InputElement.GetContainingUIElement(oldParent);
        }
        if (dependencyObject != null)
          UIElement.SynchronizeForceInheritProperties(this, (ContentElement) null, (UIElement3D) null, dependencyObject);
      }
      this.SynchronizeReverseInheritPropertyFlags(oldParent, true);
    }

    internal void OnVisualAncestorChanged(object sender, AncestorChangedEventArgs e)
    {
      UIElement uiElement = sender as UIElement;
      if (uiElement == null)
        return;
      PresentationSource.OnVisualAncestorChanged((DependencyObject) uiElement, e);
    }

    internal DependencyObject GetUIParent()
    {
      return UIElementHelper.GetUIParent((DependencyObject) this, false);
    }

    internal DependencyObject GetUIParent(bool continuePastVisualTree)
    {
      return UIElementHelper.GetUIParent((DependencyObject) this, continuePastVisualTree);
    }

    internal DependencyObject GetUIParentNo3DTraversal()
    {
      return InputElement.GetContainingUIElement(this.InternalVisualParent, true);
    }

    protected internal virtual DependencyObject GetUIParentCore()
    {
      return (DependencyObject) null;
    }

    public void UpdateLayout()
    {
      ContextLayoutManager.From(this.Dispatcher).UpdateLayout();
    }

    internal static void BuildRouteHelper(DependencyObject e, EventRoute route, RoutedEventArgs args)
    {
      if (route == null)
        throw new ArgumentNullException("route");
      if (args == null)
        throw new ArgumentNullException("args");
      if (args.Source == null)
        throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("SourceNotSet"));
      if (args.RoutedEvent != route.RoutedEvent)
        throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("Mismatched_RoutedEvent"));
      if (args.RoutedEvent.RoutingStrategy == RoutingStrategy.Direct)
      {
        UIElement uiElement = e as UIElement;
        ContentElement contentElement = (ContentElement) null;
        UIElement3D uiElement3D = (UIElement3D) null;
        if (uiElement == null)
        {
          contentElement = e as ContentElement;
          if (contentElement == null)
            uiElement3D = e as UIElement3D;
        }
        if (uiElement != null)
          uiElement.AddToEventRoute(route, args);
        else if (contentElement != null)
        {
          contentElement.AddToEventRoute(route, args);
        }
        else
        {
          if (uiElement3D == null)
            return;
          uiElement3D.AddToEventRoute(route, args);
        }
      }
      else
      {
        int num = 0;
        while (e != null)
        {
          UIElement uiElement = e as UIElement;
          ContentElement contentElement = (ContentElement) null;
          UIElement3D uiElement3D = (UIElement3D) null;
          if (uiElement == null)
          {
            contentElement = e as ContentElement;
            if (contentElement == null)
              uiElement3D = e as UIElement3D;
          }
          if (num++ > 4096)
            throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("TreeLoop"));
          object source = (object) null;
          if (uiElement != null)
            source = uiElement.AdjustEventSource(args);
          else if (contentElement != null)
            source = contentElement.AdjustEventSource(args);
          else if (uiElement3D != null)
            source = uiElement3D.AdjustEventSource(args);
          if (source != null)
            route.AddSource(source);
          if (uiElement != null)
          {
            uiElement.AddSynchronizedInputPreOpportunityHandler(route, args);
            bool continuePastVisualTree = uiElement.BuildRouteCore(route, args);
            uiElement.AddToEventRoute(route, args);
            uiElement.AddSynchronizedInputPostOpportunityHandler(route, args);
            e = uiElement.GetUIParent(continuePastVisualTree);
          }
          else if (contentElement != null)
          {
            contentElement.AddSynchronizedInputPreOpportunityHandler(route, args);
            bool continuePastVisualTree = contentElement.BuildRouteCore(route, args);
            contentElement.AddToEventRoute(route, args);
            contentElement.AddSynchronizedInputPostOpportunityHandler(route, args);
            e = contentElement.GetUIParent(continuePastVisualTree);
          }
          else if (uiElement3D != null)
          {
            uiElement3D.AddSynchronizedInputPreOpportunityHandler(route, args);
            bool continuePastVisualTree = uiElement3D.BuildRouteCore(route, args);
            uiElement3D.AddToEventRoute(route, args);
            uiElement3D.AddSynchronizedInputPostOpportunityHandler(route, args);
            e = uiElement3D.GetUIParent(continuePastVisualTree);
          }
          if (e == args.Source)
            route.AddSource((object) e);
        }
      }
    }

    internal void AddSynchronizedInputPreOpportunityHandler(EventRoute route, RoutedEventArgs args)
    {
      if (!InputManager.IsSynchronizedInput)
        return;
      if (SynchronizedInputHelper.IsListening((DependencyObject) this, args))
      {
        RoutedEventHandler eventHandler = new RoutedEventHandler(this.SynchronizedInputPreOpportunityHandler);
        SynchronizedInputHelper.AddHandlerToRoute((DependencyObject) this, route, eventHandler, false);
      }
      else
        this.AddSynchronizedInputPreOpportunityHandlerCore(route, args);
    }

    internal virtual void AddSynchronizedInputPreOpportunityHandlerCore(EventRoute route, RoutedEventArgs args)
    {
    }

    internal void AddSynchronizedInputPostOpportunityHandler(EventRoute route, RoutedEventArgs args)
    {
      if (!InputManager.IsSynchronizedInput)
        return;
      if (SynchronizedInputHelper.IsListening((DependencyObject) this, args))
      {
        RoutedEventHandler eventHandler = new RoutedEventHandler(this.SynchronizedInputPostOpportunityHandler);
        SynchronizedInputHelper.AddHandlerToRoute((DependencyObject) this, route, eventHandler, true);
      }
      else
        SynchronizedInputHelper.AddParentPreOpportunityHandler((DependencyObject) this, route, args);
    }

    internal void SynchronizedInputPreOpportunityHandler(object sender, RoutedEventArgs args)
    {
      SynchronizedInputHelper.PreOpportunityHandler(sender, args);
    }

    internal void SynchronizedInputPostOpportunityHandler(object sender, RoutedEventArgs args)
    {
      if (!args.Handled || InputManager.SynchronizedInputState != SynchronizedInputStates.HadOpportunity)
        return;
      SynchronizedInputHelper.PostOpportunityHandler(sender, args);
    }

    internal bool StartListeningSynchronizedInput(SynchronizedInputType inputType)
    {
      if (InputManager.IsSynchronizedInput)
        return false;
      InputManager.StartListeningSynchronizedInput((DependencyObject) this, inputType);
      return true;
    }

    internal void CancelSynchronizedInput()
    {
      InputManager.CancelSynchronizedInput();
    }

    [FriendAccessAllowed]
    internal static void AddHandler(DependencyObject d, RoutedEvent routedEvent, Delegate handler)
    {
      if (d == null)
        throw new ArgumentNullException("d");
      UIElement uiElement = d as UIElement;
      if (uiElement != null)
      {
        uiElement.AddHandler(routedEvent, handler);
      }
      else
      {
        ContentElement contentElement = d as ContentElement;
        if (contentElement != null)
        {
          contentElement.AddHandler(routedEvent, handler);
        }
        else
        {
          UIElement3D uiElement3D = d as UIElement3D;
          if (uiElement3D != null)
            uiElement3D.AddHandler(routedEvent, handler);
          else
            throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("Invalid_IInputElement", new object[1]
            {
              (object) d.GetType()
            }));
        }
      }
    }

    [FriendAccessAllowed]
    internal static void RemoveHandler(DependencyObject d, RoutedEvent routedEvent, Delegate handler)
    {
      if (d == null)
        throw new ArgumentNullException("d");
      UIElement uiElement = d as UIElement;
      if (uiElement != null)
      {
        uiElement.RemoveHandler(routedEvent, handler);
      }
      else
      {
        ContentElement contentElement = d as ContentElement;
        if (contentElement != null)
        {
          contentElement.RemoveHandler(routedEvent, handler);
        }
        else
        {
          UIElement3D uiElement3D = d as UIElement3D;
          if (uiElement3D != null)
            uiElement3D.RemoveHandler(routedEvent, handler);
          else
            throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("Invalid_IInputElement", new object[1]
            {
              (object) d.GetType()
            }));
        }
      }
    }

    internal virtual void OnPresentationSourceChanged(bool attached)
    {
      if (attached || FocusManager.GetFocusedElement((DependencyObject) this) == null)
        return;
      FocusManager.SetFocusedElement((DependencyObject) this, (IInputElement) null);
    }

    public Point TranslatePoint(Point point, UIElement relativeTo)
    {
      return InputElement.TranslatePoint(point, (DependencyObject) this, (DependencyObject) relativeTo);
    }

    public IInputElement InputHitTest(Point point)
    {
      IInputElement enabledHit;
      IInputElement rawHit;
      this.InputHitTest(point, out enabledHit, out rawHit);
      return enabledHit;
    }

    internal void InputHitTest(Point pt, out IInputElement enabledHit, out IInputElement rawHit)
    {
      PointHitTestParameters hitTestParameters = new PointHitTestParameters(pt);
      UIElement.InputHitTestResult inputHitTestResult = new UIElement.InputHitTestResult();
      VisualTreeHelper.HitTest((Visual) this, new HitTestFilterCallback(this.InputHitTestFilterCallback), new HitTestResultCallback(inputHitTestResult.InputHitTestResultCallback), (HitTestParameters) hitTestParameters);
      DependencyObject dependencyObject = inputHitTestResult.Result;
      rawHit = dependencyObject as IInputElement;
      enabledHit = (IInputElement) null;
      for (; dependencyObject != null; dependencyObject = VisualTreeHelper.GetParentInternal(dependencyObject))
      {
        IContentHost contentHost = dependencyObject as IContentHost;
        if (contentHost != null && (bool) InputElement.GetContainingUIElement(dependencyObject).GetValue(UIElement.IsEnabledProperty))
        {
          pt = InputElement.TranslatePoint(pt, (DependencyObject) this, dependencyObject);
          enabledHit = rawHit = contentHost.InputHitTest(pt);
          if (enabledHit != null)
            break;
        }
        UIElement uiElement = dependencyObject as UIElement;
        if (uiElement != null)
        {
          if (rawHit == null)
            rawHit = (IInputElement) uiElement;
          if (uiElement.IsEnabled)
          {
            enabledHit = (IInputElement) uiElement;
            break;
          }
        }
        UIElement3D uiElement3D = dependencyObject as UIElement3D;
        if (uiElement3D != null)
        {
          if (rawHit == null)
            rawHit = (IInputElement) uiElement3D;
          if (uiElement3D.IsEnabled)
          {
            enabledHit = (IInputElement) uiElement3D;
            break;
          }
        }
        if (dependencyObject == this)
          break;
      }
    }

    internal static void RaiseEventImpl(DependencyObject sender, RoutedEventArgs args)
    {
      EventRoute eventRoute = EventRouteFactory.FetchObject(args.RoutedEvent);
      if (TraceRoutedEvent.IsEnabled)
        TraceRoutedEvent.Trace(TraceEventType.Start, TraceRoutedEvent.RaiseEvent, (object) args.RoutedEvent, (object) sender, (object) args, (object) (bool) (args.Handled ? 1 : 0));
      try
      {
        args.Source = (object) sender;
        UIElement.BuildRouteHelper(sender, eventRoute, args);
        eventRoute.InvokeHandlers((object) sender, args);
        args.Source = args.OriginalSource;
      }
      finally
      {
        if (TraceRoutedEvent.IsEnabled)
          TraceRoutedEvent.Trace(TraceEventType.Stop, TraceRoutedEvent.RaiseEvent, (object) args.RoutedEvent, (object) sender, (object) args, (object) (bool) (args.Handled ? 1 : 0));
      }
      EventRouteFactory.RecycleObject(eventRoute);
    }

    private bool IsMouseDirectlyOver_ComputeValue()
    {
      return Mouse.DirectlyOver == this;
    }

    [FriendAccessAllowed]
    internal void SynchronizeReverseInheritPropertyFlags(DependencyObject oldParent, bool isCoreParent)
    {
      if (this.IsKeyboardFocusWithin)
        Keyboard.PrimaryDevice.ReevaluateFocusAsync((DependencyObject) this, oldParent, isCoreParent);
      if (this.IsStylusOver)
        StylusLogic.CurrentStylusLogicReevaluateStylusOver((DependencyObject) this, oldParent, isCoreParent);
      if (this.IsStylusCaptureWithin)
        StylusLogic.CurrentStylusLogicReevaluateCapture((DependencyObject) this, oldParent, isCoreParent);
      if (this.IsMouseOver)
        Mouse.PrimaryDevice.ReevaluateMouseOver((DependencyObject) this, oldParent, isCoreParent);
      if (this.IsMouseCaptureWithin)
        Mouse.PrimaryDevice.ReevaluateCapture((DependencyObject) this, oldParent, isCoreParent);
      if (this.AreAnyTouchesOver)
        TouchDevice.ReevaluateDirectlyOver((DependencyObject) this, oldParent, isCoreParent);
      if (!this.AreAnyTouchesCapturedWithin)
        return;
      TouchDevice.ReevaluateCapturedWithin((DependencyObject) this, oldParent, isCoreParent);
    }

    internal virtual bool BlockReverseInheritance()
    {
      return false;
    }

    public bool CaptureMouse()
    {
      return Mouse.Capture((IInputElement) this);
    }

    public void ReleaseMouseCapture()
    {
      if (Mouse.Captured != this)
        return;
      Mouse.Capture((IInputElement) null);
    }

    private bool IsStylusDirectlyOver_ComputeValue()
    {
      return Stylus.DirectlyOver == this;
    }

    public bool CaptureStylus()
    {
      return Stylus.Capture((IInputElement) this);
    }

    public void ReleaseStylusCapture()
    {
      Stylus.Capture((IInputElement) null);
    }

    private bool IsKeyboardFocused_ComputeValue()
    {
      return Keyboard.FocusedElement == this;
    }

    public bool Focus()
    {
      if (Keyboard.Focus((IInputElement) this) == this)
        return true;
      if (this.Focusable && this.IsEnabled)
      {
        DependencyObject focusScope = FocusManager.GetFocusScope((DependencyObject) this);
        if (FocusManager.GetFocusedElement(focusScope) == null)
          FocusManager.SetFocusedElement(focusScope, (IInputElement) this);
      }
      return false;
    }

    public virtual bool MoveFocus(TraversalRequest request)
    {
      return false;
    }

    public virtual DependencyObject PredictFocus(FocusNavigationDirection direction)
    {
      return (DependencyObject) null;
    }

    protected virtual void OnAccessKey(AccessKeyEventArgs e)
    {
      this.Focus();
    }

    protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
    {
      if (this._drawingContent != null && this._drawingContent.HitTestPoint(hitTestParameters.HitPoint))
        return (HitTestResult) new PointHitTestResult((Visual) this, hitTestParameters.HitPoint);
      else
        return (HitTestResult) null;
    }

    protected override GeometryHitTestResult HitTestCore(GeometryHitTestParameters hitTestParameters)
    {
      if (this._drawingContent != null && this.GetHitTestBounds().IntersectsWith(hitTestParameters.Bounds))
      {
        IntersectionDetail intersectionDetail = this._drawingContent.HitTestGeometry(hitTestParameters.InternalHitGeometry);
        if (intersectionDetail != IntersectionDetail.Empty)
          return new GeometryHitTestResult((Visual) this, intersectionDetail);
      }
      return (GeometryHitTestResult) null;
    }

    [FriendAccessAllowed]
    internal DrawingContext RenderOpen()
    {
      return (DrawingContext) new VisualDrawingContext((Visual) this);
    }

    internal override void RenderClose(IDrawingContent newContent)
    {
      IDrawingContent drawingContent = this._drawingContent;
      if (drawingContent == null && newContent == null)
        return;
      this._drawingContent = (IDrawingContent) null;
      if (drawingContent != null)
      {
        drawingContent.PropagateChangedHandler(this.ContentsChangedHandler, false);
        this.DisconnectAttachedResource(VisualProxyFlags.IsContentConnected, (DUCE.IResource) drawingContent);
      }
      if (newContent != null)
        newContent.PropagateChangedHandler(this.ContentsChangedHandler, true);
      this._drawingContent = newContent;
      this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsContentDirty);
      Visual.PropagateFlags((Visual) this, VisualFlags.IsSubtreeDirtyForPrecompute, VisualProxyFlags.IsSubtreeDirtyForRender);
    }

    [SecurityCritical]
    internal override void FreeContent(DUCE.Channel channel)
    {
      if (this._drawingContent != null && this.CheckFlagsAnd(channel, VisualProxyFlags.IsContentConnected))
      {
        DUCE.CompositionNode.SetContent(this._proxy.GetHandle(channel), DUCE.ResourceHandle.Null, channel);
        this._drawingContent.ReleaseOnChannel(channel);
        this.SetFlags(channel, false, VisualProxyFlags.IsContentConnected);
      }
      base.FreeContent(channel);
    }

    internal override Rect GetContentBounds()
    {
      if (this._drawingContent == null)
        return Rect.Empty;
      Rect empty = Rect.Empty;
      MediaContext mediaContext = MediaContext.From(this.Dispatcher);
      BoundsDrawingContextWalker ctx = mediaContext.AcquireBoundsDrawingContextWalker();
      Rect contentBounds = this._drawingContent.GetContentBounds(ctx);
      mediaContext.ReleaseBoundsDrawingContextWalker(ctx);
      return contentBounds;
    }

    internal void WalkContent(DrawingContextWalker walker)
    {
      this.VerifyAPIReadOnly();
      if (this._drawingContent == null)
        return;
      this._drawingContent.WalkContent(walker);
    }

    internal override void RenderContent(RenderContext ctx, bool isOnChannel)
    {
      DUCE.Channel channel = ctx.Channel;
      if (this._drawingContent != null)
      {
        DUCE.IResource resource = (DUCE.IResource) this._drawingContent;
        resource.AddRefOnChannel(channel);
        DUCE.CompositionNode.SetContent(this._proxy.GetHandle(channel), resource.GetHandle(channel), channel);
        this.SetFlags(channel, true, VisualProxyFlags.IsContentConnected);
      }
      else
      {
        if (!isOnChannel)
          return;
        DUCE.CompositionNode.SetContent(this._proxy.GetHandle(channel), DUCE.ResourceHandle.Null, channel);
      }
    }

    internal override DrawingGroup GetDrawing()
    {
      this.VerifyAPIReadOnly();
      DrawingGroup drawingGroup = (DrawingGroup) null;
      if (this._drawingContent != null)
        drawingGroup = DrawingServices.DrawingGroupFromRenderData((RenderData) this._drawingContent);
      return drawingGroup;
    }

    protected virtual Geometry GetLayoutClip(Size layoutSlotSize)
    {
      if (!this.ClipToBounds)
        return (Geometry) null;
      RectangleGeometry rectangleGeometry = new RectangleGeometry(new Rect(this.RenderSize));
      rectangleGeometry.Freeze();
      return (Geometry) rectangleGeometry;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void InvokeAccessKey(AccessKeyEventArgs e)
    {
      this.OnAccessKey(e);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    protected virtual void OnGotFocus(RoutedEventArgs e)
    {
      this.RaiseEvent(e);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    protected virtual void OnLostFocus(RoutedEventArgs e)
    {
      this.RaiseEvent(e);
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    internal void UpdateIsVisibleCache()
    {
      bool flag1 = this.Visibility == Visibility.Visible;
      if (flag1)
      {
        bool flag2 = false;
        DependencyObject containingUiElement = InputElement.GetContainingUIElement(this._parent);
        if (containingUiElement != null)
          flag2 = UIElementHelper.IsVisible(containingUiElement);
        else if (PresentationSource.CriticalFromVisual((DependencyObject) this) != null)
          flag2 = true;
        if (!flag2)
          flag1 = false;
      }
      if (flag1 == this.IsVisible)
        return;
      this.WriteFlag(CoreFlags.IsVisibleCache, flag1);
      this.NotifyPropertyChange(new DependencyPropertyChangedEventArgs(UIElement.IsVisibleProperty, UIElement._isVisibleMetadata, BooleanBoxes.Box(!flag1), BooleanBoxes.Box(flag1)));
    }

    protected virtual AutomationPeer OnCreateAutomationPeer()
    {
      return (AutomationPeer) null;
    }

    internal AutomationPeer CreateAutomationPeer()
    {
      this.VerifyAccess();
      AutomationPeer automationPeer;
      if (this.HasAutomationPeer)
      {
        automationPeer = UIElement.AutomationPeerField.GetValue((DependencyObject) this);
      }
      else
      {
        automationPeer = this.OnCreateAutomationPeer();
        if (automationPeer != null)
        {
          UIElement.AutomationPeerField.SetValue((DependencyObject) this, automationPeer);
          this.HasAutomationPeer = true;
        }
      }
      return automationPeer;
    }

    internal AutomationPeer GetAutomationPeer()
    {
      this.VerifyAccess();
      if (this.HasAutomationPeer)
        return UIElement.AutomationPeerField.GetValue((DependencyObject) this);
      else
        return (AutomationPeer) null;
    }

    internal AutomationPeer CreateGenericRootAutomationPeer()
    {
      this.VerifyAccess();
      AutomationPeer automationPeer;
      if (this.HasAutomationPeer)
      {
        automationPeer = UIElement.AutomationPeerField.GetValue((DependencyObject) this);
      }
      else
      {
        automationPeer = (AutomationPeer) new GenericRootAutomationPeer(this);
        UIElement.AutomationPeerField.SetValue((DependencyObject) this, automationPeer);
        this.HasAutomationPeer = true;
      }
      return automationPeer;
    }

    [FriendAccessAllowed]
    internal void SetPersistId(int value)
    {
      this._persistId = value;
    }

    internal static void SynchronizeForceInheritProperties(UIElement uiElement, ContentElement contentElement, UIElement3D uiElement3D, DependencyObject parent)
    {
      if (uiElement != null || uiElement3D != null)
      {
        if (!(bool) parent.GetValue(UIElement.IsEnabledProperty))
        {
          if (uiElement != null)
            uiElement.CoerceValue(UIElement.IsEnabledProperty);
          else
            uiElement3D.CoerceValue(UIElement.IsEnabledProperty);
        }
        if (!(bool) parent.GetValue(UIElement.IsHitTestVisibleProperty))
        {
          if (uiElement != null)
            uiElement.CoerceValue(UIElement.IsHitTestVisibleProperty);
          else
            uiElement3D.CoerceValue(UIElement.IsHitTestVisibleProperty);
        }
        if (!(bool) parent.GetValue(UIElement.IsVisibleProperty))
          return;
        if (uiElement != null)
          uiElement.UpdateIsVisibleCache();
        else
          uiElement3D.UpdateIsVisibleCache();
      }
      else
      {
        if (contentElement == null || (bool) parent.GetValue(UIElement.IsEnabledProperty))
          return;
        contentElement.CoerceValue(UIElement.IsEnabledProperty);
      }
    }

    internal static void InvalidateForceInheritPropertyOnChildren(Visual v, DependencyProperty property)
    {
      int dor3DchildrenCount = v.InternalVisual2DOr3DChildrenCount;
      for (int index = 0; index < dor3DchildrenCount; ++index)
      {
        DependencyObject dependencyObject = v.InternalGet2DOr3DVisualChild(index);
        Visual v1 = dependencyObject as Visual;
        if (v1 != null)
        {
          UIElement uiElement = v1 as UIElement;
          if (uiElement != null)
          {
            if (property == UIElement.IsVisibleProperty)
              uiElement.UpdateIsVisibleCache();
            else
              uiElement.CoerceValue(property);
          }
          else
            UIElement.InvalidateForceInheritPropertyOnChildren(v1, property);
        }
        else
        {
          Visual3D v2 = dependencyObject as Visual3D;
          if (v2 != null)
          {
            UIElement3D uiElement3D = v2 as UIElement3D;
            if (uiElement3D != null)
            {
              if (property == UIElement.IsVisibleProperty)
                uiElement3D.UpdateIsVisibleCache();
              else
                uiElement3D.CoerceValue(property);
            }
            else
              UIElement3D.InvalidateForceInheritPropertyOnChildren(v2, property);
          }
        }
      }
    }

    protected virtual void OnManipulationStarting(ManipulationStartingEventArgs e)
    {
    }

    protected virtual void OnManipulationStarted(ManipulationStartedEventArgs e)
    {
    }

    protected virtual void OnManipulationDelta(ManipulationDeltaEventArgs e)
    {
    }

    protected virtual void OnManipulationInertiaStarting(ManipulationInertiaStartingEventArgs e)
    {
    }

    protected virtual void OnManipulationBoundaryFeedback(ManipulationBoundaryFeedbackEventArgs e)
    {
    }

    protected virtual void OnManipulationCompleted(ManipulationCompletedEventArgs e)
    {
    }

    public bool CaptureTouch(TouchDevice touchDevice)
    {
      if (touchDevice == null)
        throw new ArgumentNullException("touchDevice");
      else
        return touchDevice.Capture((IInputElement) this);
    }

    public bool ReleaseTouchCapture(TouchDevice touchDevice)
    {
      if (touchDevice == null)
        throw new ArgumentNullException("touchDevice");
      if (touchDevice.Captured != this)
        return false;
      touchDevice.Capture((IInputElement) null);
      return true;
    }

    public void ReleaseAllTouchCaptures()
    {
      TouchDevice.ReleaseAllCaptures((IInputElement) this);
    }

    private void EventHandlersStoreAdd(EventPrivateKey key, Delegate handler)
    {
      this.EnsureEventHandlersStore();
      this.EventHandlersStore.Add(key, handler);
    }

    private void EventHandlersStoreRemove(EventPrivateKey key, Delegate handler)
    {
      EventHandlersStore eventHandlersStore = this.EventHandlersStore;
      if (eventHandlersStore == null)
        return;
      eventHandlersStore.Remove(key, handler);
      if (eventHandlersStore.Count != 0)
        return;
      UIElement.EventHandlersStoreField.ClearValue((DependencyObject) this);
      this.WriteFlag(CoreFlags.ExistsEventHandlersStore, false);
    }

    [SecurityCritical]
    private static void OnPreviewMouseDownThunk(object sender, MouseButtonEventArgs e)
    {
      if (!e.Handled)
      {
        UIElement uiElement = sender as UIElement;
        if (uiElement != null)
        {
          uiElement.OnPreviewMouseDown(e);
        }
        else
        {
          ContentElement contentElement = sender as ContentElement;
          if (contentElement != null)
            contentElement.OnPreviewMouseDown(e);
          else
            ((UIElement3D) sender).OnPreviewMouseDown(e);
        }
      }
      UIElement.CrackMouseButtonEventAndReRaiseEvent((DependencyObject) sender, e);
    }

    [SecurityCritical]
    private static void OnMouseDownThunk(object sender, MouseButtonEventArgs e)
    {
      if (!e.Handled)
        CommandManager.TranslateInput((IInputElement) sender, (InputEventArgs) e);
      if (!e.Handled)
      {
        UIElement uiElement = sender as UIElement;
        if (uiElement != null)
        {
          uiElement.OnMouseDown(e);
        }
        else
        {
          ContentElement contentElement = sender as ContentElement;
          if (contentElement != null)
            contentElement.OnMouseDown(e);
          else
            ((UIElement3D) sender).OnMouseDown(e);
        }
      }
      UIElement.CrackMouseButtonEventAndReRaiseEvent((DependencyObject) sender, e);
    }

    [SecurityCritical]
    private static void OnPreviewMouseUpThunk(object sender, MouseButtonEventArgs e)
    {
      if (!e.Handled)
      {
        UIElement uiElement = sender as UIElement;
        if (uiElement != null)
        {
          uiElement.OnPreviewMouseUp(e);
        }
        else
        {
          ContentElement contentElement = sender as ContentElement;
          if (contentElement != null)
            contentElement.OnPreviewMouseUp(e);
          else
            ((UIElement3D) sender).OnPreviewMouseUp(e);
        }
      }
      UIElement.CrackMouseButtonEventAndReRaiseEvent((DependencyObject) sender, e);
    }

    [SecurityCritical]
    private static void OnMouseUpThunk(object sender, MouseButtonEventArgs e)
    {
      if (!e.Handled)
      {
        UIElement uiElement = sender as UIElement;
        if (uiElement != null)
        {
          uiElement.OnMouseUp(e);
        }
        else
        {
          ContentElement contentElement = sender as ContentElement;
          if (contentElement != null)
            contentElement.OnMouseUp(e);
          else
            ((UIElement3D) sender).OnMouseUp(e);
        }
      }
      UIElement.CrackMouseButtonEventAndReRaiseEvent((DependencyObject) sender, e);
    }

    [SecurityCritical]
    private static void OnPreviewMouseLeftButtonDownThunk(object sender, MouseButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewMouseLeftButtonDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewMouseLeftButtonDown(e);
        else
          ((UIElement3D) sender).OnPreviewMouseLeftButtonDown(e);
      }
    }

    [SecurityCritical]
    private static void OnMouseLeftButtonDownThunk(object sender, MouseButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnMouseLeftButtonDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnMouseLeftButtonDown(e);
        else
          ((UIElement3D) sender).OnMouseLeftButtonDown(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewMouseLeftButtonUpThunk(object sender, MouseButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewMouseLeftButtonUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewMouseLeftButtonUp(e);
        else
          ((UIElement3D) sender).OnPreviewMouseLeftButtonUp(e);
      }
    }

    [SecurityCritical]
    private static void OnMouseLeftButtonUpThunk(object sender, MouseButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnMouseLeftButtonUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnMouseLeftButtonUp(e);
        else
          ((UIElement3D) sender).OnMouseLeftButtonUp(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewMouseRightButtonDownThunk(object sender, MouseButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewMouseRightButtonDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewMouseRightButtonDown(e);
        else
          ((UIElement3D) sender).OnPreviewMouseRightButtonDown(e);
      }
    }

    [SecurityCritical]
    private static void OnMouseRightButtonDownThunk(object sender, MouseButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnMouseRightButtonDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnMouseRightButtonDown(e);
        else
          ((UIElement3D) sender).OnMouseRightButtonDown(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewMouseRightButtonUpThunk(object sender, MouseButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewMouseRightButtonUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewMouseRightButtonUp(e);
        else
          ((UIElement3D) sender).OnPreviewMouseRightButtonUp(e);
      }
    }

    [SecurityCritical]
    private static void OnMouseRightButtonUpThunk(object sender, MouseButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnMouseRightButtonUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnMouseRightButtonUp(e);
        else
          ((UIElement3D) sender).OnMouseRightButtonUp(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewMouseMoveThunk(object sender, MouseEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewMouseMove(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewMouseMove(e);
        else
          ((UIElement3D) sender).OnPreviewMouseMove(e);
      }
    }

    [SecurityCritical]
    private static void OnMouseMoveThunk(object sender, MouseEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnMouseMove(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnMouseMove(e);
        else
          ((UIElement3D) sender).OnMouseMove(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewMouseWheelThunk(object sender, MouseWheelEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewMouseWheel(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewMouseWheel(e);
        else
          ((UIElement3D) sender).OnPreviewMouseWheel(e);
      }
    }

    [SecurityCritical]
    private static void OnMouseWheelThunk(object sender, MouseWheelEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      CommandManager.TranslateInput((IInputElement) sender, (InputEventArgs) e);
      if (e.Handled)
        return;
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnMouseWheel(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnMouseWheel(e);
        else
          ((UIElement3D) sender).OnMouseWheel(e);
      }
    }

    [SecurityCritical]
    private static void OnMouseEnterThunk(object sender, MouseEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnMouseEnter(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnMouseEnter(e);
        else
          ((UIElement3D) sender).OnMouseEnter(e);
      }
    }

    [SecurityCritical]
    private static void OnMouseLeaveThunk(object sender, MouseEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnMouseLeave(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnMouseLeave(e);
        else
          ((UIElement3D) sender).OnMouseLeave(e);
      }
    }

    [SecurityCritical]
    private static void OnGotMouseCaptureThunk(object sender, MouseEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnGotMouseCapture(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnGotMouseCapture(e);
        else
          ((UIElement3D) sender).OnGotMouseCapture(e);
      }
    }

    [SecurityCritical]
    private static void OnLostMouseCaptureThunk(object sender, MouseEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnLostMouseCapture(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnLostMouseCapture(e);
        else
          ((UIElement3D) sender).OnLostMouseCapture(e);
      }
    }

    [SecurityCritical]
    private static void OnQueryCursorThunk(object sender, QueryCursorEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnQueryCursor(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnQueryCursor(e);
        else
          ((UIElement3D) sender).OnQueryCursor(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewStylusDownThunk(object sender, StylusDownEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewStylusDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewStylusDown(e);
        else
          ((UIElement3D) sender).OnPreviewStylusDown(e);
      }
    }

    [SecurityCritical]
    private static void OnStylusDownThunk(object sender, StylusDownEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnStylusDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnStylusDown(e);
        else
          ((UIElement3D) sender).OnStylusDown(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewStylusUpThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewStylusUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewStylusUp(e);
        else
          ((UIElement3D) sender).OnPreviewStylusUp(e);
      }
    }

    [SecurityCritical]
    private static void OnStylusUpThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnStylusUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnStylusUp(e);
        else
          ((UIElement3D) sender).OnStylusUp(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewStylusMoveThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewStylusMove(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewStylusMove(e);
        else
          ((UIElement3D) sender).OnPreviewStylusMove(e);
      }
    }

    [SecurityCritical]
    private static void OnStylusMoveThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnStylusMove(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnStylusMove(e);
        else
          ((UIElement3D) sender).OnStylusMove(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewStylusInAirMoveThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewStylusInAirMove(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewStylusInAirMove(e);
        else
          ((UIElement3D) sender).OnPreviewStylusInAirMove(e);
      }
    }

    [SecurityCritical]
    private static void OnStylusInAirMoveThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnStylusInAirMove(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnStylusInAirMove(e);
        else
          ((UIElement3D) sender).OnStylusInAirMove(e);
      }
    }

    [SecurityCritical]
    private static void OnStylusEnterThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnStylusEnter(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnStylusEnter(e);
        else
          ((UIElement3D) sender).OnStylusEnter(e);
      }
    }

    [SecurityCritical]
    private static void OnStylusLeaveThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnStylusLeave(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnStylusLeave(e);
        else
          ((UIElement3D) sender).OnStylusLeave(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewStylusInRangeThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewStylusInRange(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewStylusInRange(e);
        else
          ((UIElement3D) sender).OnPreviewStylusInRange(e);
      }
    }

    [SecurityCritical]
    private static void OnStylusInRangeThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnStylusInRange(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnStylusInRange(e);
        else
          ((UIElement3D) sender).OnStylusInRange(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewStylusOutOfRangeThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewStylusOutOfRange(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewStylusOutOfRange(e);
        else
          ((UIElement3D) sender).OnPreviewStylusOutOfRange(e);
      }
    }

    [SecurityCritical]
    private static void OnStylusOutOfRangeThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnStylusOutOfRange(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnStylusOutOfRange(e);
        else
          ((UIElement3D) sender).OnStylusOutOfRange(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewStylusSystemGestureThunk(object sender, StylusSystemGestureEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewStylusSystemGesture(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewStylusSystemGesture(e);
        else
          ((UIElement3D) sender).OnPreviewStylusSystemGesture(e);
      }
    }

    [SecurityCritical]
    private static void OnStylusSystemGestureThunk(object sender, StylusSystemGestureEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnStylusSystemGesture(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnStylusSystemGesture(e);
        else
          ((UIElement3D) sender).OnStylusSystemGesture(e);
      }
    }

    [SecurityCritical]
    private static void OnGotStylusCaptureThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnGotStylusCapture(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnGotStylusCapture(e);
        else
          ((UIElement3D) sender).OnGotStylusCapture(e);
      }
    }

    [SecurityCritical]
    private static void OnLostStylusCaptureThunk(object sender, StylusEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnLostStylusCapture(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnLostStylusCapture(e);
        else
          ((UIElement3D) sender).OnLostStylusCapture(e);
      }
    }

    [SecurityCritical]
    private static void OnStylusButtonDownThunk(object sender, StylusButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnStylusButtonDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnStylusButtonDown(e);
        else
          ((UIElement3D) sender).OnStylusButtonDown(e);
      }
    }

    [SecurityCritical]
    private static void OnStylusButtonUpThunk(object sender, StylusButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnStylusButtonUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnStylusButtonUp(e);
        else
          ((UIElement3D) sender).OnStylusButtonUp(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewStylusButtonDownThunk(object sender, StylusButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewStylusButtonDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewStylusButtonDown(e);
        else
          ((UIElement3D) sender).OnPreviewStylusButtonDown(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewStylusButtonUpThunk(object sender, StylusButtonEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewStylusButtonUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewStylusButtonUp(e);
        else
          ((UIElement3D) sender).OnPreviewStylusButtonUp(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewKeyDownThunk(object sender, KeyEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewKeyDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewKeyDown(e);
        else
          ((UIElement3D) sender).OnPreviewKeyDown(e);
      }
    }

    [SecurityCritical]
    private static void OnKeyDownThunk(object sender, KeyEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      CommandManager.TranslateInput((IInputElement) sender, (InputEventArgs) e);
      if (e.Handled)
        return;
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnKeyDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnKeyDown(e);
        else
          ((UIElement3D) sender).OnKeyDown(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewKeyUpThunk(object sender, KeyEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewKeyUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewKeyUp(e);
        else
          ((UIElement3D) sender).OnPreviewKeyUp(e);
      }
    }

    [SecurityCritical]
    private static void OnKeyUpThunk(object sender, KeyEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnKeyUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnKeyUp(e);
        else
          ((UIElement3D) sender).OnKeyUp(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewGotKeyboardFocusThunk(object sender, KeyboardFocusChangedEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewGotKeyboardFocus(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewGotKeyboardFocus(e);
        else
          ((UIElement3D) sender).OnPreviewGotKeyboardFocus(e);
      }
    }

    [SecurityCritical]
    private static void OnGotKeyboardFocusThunk(object sender, KeyboardFocusChangedEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnGotKeyboardFocus(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnGotKeyboardFocus(e);
        else
          ((UIElement3D) sender).OnGotKeyboardFocus(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewLostKeyboardFocusThunk(object sender, KeyboardFocusChangedEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewLostKeyboardFocus(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewLostKeyboardFocus(e);
        else
          ((UIElement3D) sender).OnPreviewLostKeyboardFocus(e);
      }
    }

    [SecurityCritical]
    private static void OnLostKeyboardFocusThunk(object sender, KeyboardFocusChangedEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnLostKeyboardFocus(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnLostKeyboardFocus(e);
        else
          ((UIElement3D) sender).OnLostKeyboardFocus(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewTextInputThunk(object sender, TextCompositionEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewTextInput(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewTextInput(e);
        else
          ((UIElement3D) sender).OnPreviewTextInput(e);
      }
    }

    [SecurityCritical]
    private static void OnTextInputThunk(object sender, TextCompositionEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnTextInput(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnTextInput(e);
        else
          ((UIElement3D) sender).OnTextInput(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewExecutedThunk(object sender, ExecutedRoutedEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      CommandManager.OnExecuted(sender, e);
    }

    [SecurityCritical]
    private static void OnExecutedThunk(object sender, ExecutedRoutedEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      CommandManager.OnExecuted(sender, e);
    }

    [SecurityCritical]
    private static void OnPreviewCanExecuteThunk(object sender, CanExecuteRoutedEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      CommandManager.OnCanExecute(sender, e);
    }

    [SecurityCritical]
    private static void OnCanExecuteThunk(object sender, CanExecuteRoutedEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      CommandManager.OnCanExecute(sender, e);
    }

    [SecurityCritical]
    private static void OnCommandDeviceThunk(object sender, CommandDeviceEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      CommandManager.OnCommandDevice(sender, e);
    }

    [SecurityCritical]
    private static void OnPreviewQueryContinueDragThunk(object sender, QueryContinueDragEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewQueryContinueDrag(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewQueryContinueDrag(e);
        else
          ((UIElement3D) sender).OnPreviewQueryContinueDrag(e);
      }
    }

    [SecurityCritical]
    private static void OnQueryContinueDragThunk(object sender, QueryContinueDragEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnQueryContinueDrag(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnQueryContinueDrag(e);
        else
          ((UIElement3D) sender).OnQueryContinueDrag(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewGiveFeedbackThunk(object sender, GiveFeedbackEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewGiveFeedback(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewGiveFeedback(e);
        else
          ((UIElement3D) sender).OnPreviewGiveFeedback(e);
      }
    }

    [SecurityCritical]
    private static void OnGiveFeedbackThunk(object sender, GiveFeedbackEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnGiveFeedback(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnGiveFeedback(e);
        else
          ((UIElement3D) sender).OnGiveFeedback(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewDragEnterThunk(object sender, DragEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewDragEnter(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewDragEnter(e);
        else
          ((UIElement3D) sender).OnPreviewDragEnter(e);
      }
    }

    [SecurityCritical]
    private static void OnDragEnterThunk(object sender, DragEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnDragEnter(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnDragEnter(e);
        else
          ((UIElement3D) sender).OnDragEnter(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewDragOverThunk(object sender, DragEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewDragOver(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewDragOver(e);
        else
          ((UIElement3D) sender).OnPreviewDragOver(e);
      }
    }

    [SecurityCritical]
    private static void OnDragOverThunk(object sender, DragEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnDragOver(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnDragOver(e);
        else
          ((UIElement3D) sender).OnDragOver(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewDragLeaveThunk(object sender, DragEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewDragLeave(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewDragLeave(e);
        else
          ((UIElement3D) sender).OnPreviewDragLeave(e);
      }
    }

    [SecurityCritical]
    private static void OnDragLeaveThunk(object sender, DragEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnDragLeave(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnDragLeave(e);
        else
          ((UIElement3D) sender).OnDragLeave(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewDropThunk(object sender, DragEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewDrop(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewDrop(e);
        else
          ((UIElement3D) sender).OnPreviewDrop(e);
      }
    }

    [SecurityCritical]
    private static void OnDropThunk(object sender, DragEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnDrop(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnDrop(e);
        else
          ((UIElement3D) sender).OnDrop(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewTouchDownThunk(object sender, TouchEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewTouchDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewTouchDown(e);
        else
          ((UIElement3D) sender).OnPreviewTouchDown(e);
      }
    }

    [SecurityCritical]
    private static void OnTouchDownThunk(object sender, TouchEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnTouchDown(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnTouchDown(e);
        else
          ((UIElement3D) sender).OnTouchDown(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewTouchMoveThunk(object sender, TouchEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewTouchMove(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewTouchMove(e);
        else
          ((UIElement3D) sender).OnPreviewTouchMove(e);
      }
    }

    [SecurityCritical]
    private static void OnTouchMoveThunk(object sender, TouchEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnTouchMove(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnTouchMove(e);
        else
          ((UIElement3D) sender).OnTouchMove(e);
      }
    }

    [SecurityCritical]
    private static void OnPreviewTouchUpThunk(object sender, TouchEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnPreviewTouchUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnPreviewTouchUp(e);
        else
          ((UIElement3D) sender).OnPreviewTouchUp(e);
      }
    }

    [SecurityCritical]
    private static void OnTouchUpThunk(object sender, TouchEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnTouchUp(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnTouchUp(e);
        else
          ((UIElement3D) sender).OnTouchUp(e);
      }
    }

    [SecurityCritical]
    private static void OnGotTouchCaptureThunk(object sender, TouchEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnGotTouchCapture(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnGotTouchCapture(e);
        else
          ((UIElement3D) sender).OnGotTouchCapture(e);
      }
    }

    [SecurityCritical]
    private static void OnLostTouchCaptureThunk(object sender, TouchEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnLostTouchCapture(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnLostTouchCapture(e);
        else
          ((UIElement3D) sender).OnLostTouchCapture(e);
      }
    }

    [SecurityCritical]
    private static void OnTouchEnterThunk(object sender, TouchEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnTouchEnter(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnTouchEnter(e);
        else
          ((UIElement3D) sender).OnTouchEnter(e);
      }
    }

    [SecurityCritical]
    private static void OnTouchLeaveThunk(object sender, TouchEventArgs e)
    {
      Invariant.Assert(!e.Handled, "Unexpected: Event has already been handled.");
      UIElement uiElement = sender as UIElement;
      if (uiElement != null)
      {
        uiElement.OnTouchLeave(e);
      }
      else
      {
        ContentElement contentElement = sender as ContentElement;
        if (contentElement != null)
          contentElement.OnTouchLeave(e);
        else
          ((UIElement3D) sender).OnTouchLeave(e);
      }
    }

    private static void IsMouseDirectlyOver_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).RaiseIsMouseDirectlyOverChanged(e);
    }

    private void RaiseIsMouseDirectlyOverChanged(DependencyPropertyChangedEventArgs args)
    {
      this.OnIsMouseDirectlyOverChanged(args);
      this.RaiseDependencyPropertyChanged(UIElement.IsMouseDirectlyOverChangedKey, args);
    }

    private static void IsMouseCaptured_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).RaiseIsMouseCapturedChanged(e);
    }

    private void RaiseIsMouseCapturedChanged(DependencyPropertyChangedEventArgs args)
    {
      this.OnIsMouseCapturedChanged(args);
      this.RaiseDependencyPropertyChanged(UIElement.IsMouseCapturedChangedKey, args);
    }

    private static void IsStylusDirectlyOver_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).RaiseIsStylusDirectlyOverChanged(e);
    }

    private void RaiseIsStylusDirectlyOverChanged(DependencyPropertyChangedEventArgs args)
    {
      this.OnIsStylusDirectlyOverChanged(args);
      this.RaiseDependencyPropertyChanged(UIElement.IsStylusDirectlyOverChangedKey, args);
    }

    private static void IsStylusCaptured_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).RaiseIsStylusCapturedChanged(e);
    }

    private void RaiseIsStylusCapturedChanged(DependencyPropertyChangedEventArgs args)
    {
      this.OnIsStylusCapturedChanged(args);
      this.RaiseDependencyPropertyChanged(UIElement.IsStylusCapturedChangedKey, args);
    }

    private static void IsKeyboardFocused_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).RaiseIsKeyboardFocusedChanged(e);
    }

    private void RaiseIsKeyboardFocusedChanged(DependencyPropertyChangedEventArgs args)
    {
      this.OnIsKeyboardFocusedChanged(args);
      this.RaiseDependencyPropertyChanged(UIElement.IsKeyboardFocusedChangedKey, args);
    }

    private void Initialize()
    {
      this.BeginPropertyInitialization();
      this.NeverMeasured = true;
      this.NeverArranged = true;
      this.SnapsToDevicePixelsCache = (bool) UIElement.SnapsToDevicePixelsProperty.GetDefaultValue(this.DependencyObjectType);
      this.ClipToBoundsCache = (bool) UIElement.ClipToBoundsProperty.GetDefaultValue(this.DependencyObjectType);
      this.VisibilityCache = (Visibility) UIElement.VisibilityProperty.GetDefaultValue(this.DependencyObjectType);
      this.SetFlags(true, VisualFlags.IsUIElement);
      if (!EventTrace.IsEnabled(EventTrace.Keyword.KeywordGeneral, EventTrace.Level.Verbose))
        return;
      PerfService.GetPerfElementID((object) this);
    }

    private bool IsRenderable()
    {
      if (this.NeverMeasured || this.NeverArranged || (this.ReadFlag(CoreFlags.IsCollapsed) || !this.IsMeasureValid))
        return false;
      else
        return this.IsArrangeValid;
    }

    private void addLayoutUpdatedHandler(EventHandler handler, LayoutEventList.ListItem item)
    {
      object obj = UIElement.LayoutUpdatedListItemsField.GetValue((DependencyObject) this);
      if (obj == null)
      {
        UIElement.LayoutUpdatedListItemsField.SetValue((DependencyObject) this, (object) item);
        UIElement.LayoutUpdatedHandlersField.SetValue((DependencyObject) this, handler);
      }
      else
      {
        EventHandler eventHandler = UIElement.LayoutUpdatedHandlersField.GetValue((DependencyObject) this);
        if (eventHandler != null)
        {
          Hashtable hashtable = new Hashtable(2);
          hashtable.Add((object) eventHandler, obj);
          hashtable.Add((object) handler, (object) item);
          UIElement.LayoutUpdatedHandlersField.ClearValue((DependencyObject) this);
          UIElement.LayoutUpdatedListItemsField.SetValue((DependencyObject) this, (object) hashtable);
        }
        else
          ((Hashtable) obj).Add((object) handler, (object) item);
      }
    }

    private LayoutEventList.ListItem getLayoutUpdatedHandler(EventHandler d)
    {
      object obj = UIElement.LayoutUpdatedListItemsField.GetValue((DependencyObject) this);
      if (obj == null)
        return (LayoutEventList.ListItem) null;
      EventHandler eventHandler = UIElement.LayoutUpdatedHandlersField.GetValue((DependencyObject) this);
      if (eventHandler == null)
        return (LayoutEventList.ListItem) ((Hashtable) obj)[(object) d];
      if (eventHandler == d)
        return (LayoutEventList.ListItem) obj;
      else
        return (LayoutEventList.ListItem) null;
    }

    private void removeLayoutUpdatedHandler(EventHandler d)
    {
      object obj = UIElement.LayoutUpdatedListItemsField.GetValue((DependencyObject) this);
      EventHandler eventHandler = UIElement.LayoutUpdatedHandlersField.GetValue((DependencyObject) this);
      if (eventHandler != null)
      {
        if (!(eventHandler == d))
          return;
        UIElement.LayoutUpdatedListItemsField.ClearValue((DependencyObject) this);
        UIElement.LayoutUpdatedHandlersField.ClearValue((DependencyObject) this);
      }
      else
        ((Hashtable) obj).Remove((object) d);
    }

    private void updatePixelSnappingGuidelines()
    {
      if (!this.SnapsToDevicePixels || this._drawingContent == null)
      {
        this.VisualXSnappingGuidelines = this.VisualYSnappingGuidelines = (DoubleCollection) null;
      }
      else
      {
        DoubleCollection xsnappingGuidelines = this.VisualXSnappingGuidelines;
        if (xsnappingGuidelines == null)
        {
          this.VisualXSnappingGuidelines = new DoubleCollection()
          {
            0.0,
            this.RenderSize.Width
          };
        }
        else
        {
          int index = xsnappingGuidelines.Count - 1;
          if (!DoubleUtil.AreClose(xsnappingGuidelines[index], this.RenderSize.Width))
            xsnappingGuidelines[index] = this.RenderSize.Width;
        }
        DoubleCollection ysnappingGuidelines = this.VisualYSnappingGuidelines;
        if (ysnappingGuidelines == null)
        {
          this.VisualYSnappingGuidelines = new DoubleCollection()
          {
            0.0,
            this.RenderSize.Height
          };
        }
        else
        {
          int index = ysnappingGuidelines.Count - 1;
          if (DoubleUtil.AreClose(ysnappingGuidelines[index], this.RenderSize.Height))
            return;
          ysnappingGuidelines[index] = this.RenderSize.Height;
        }
      }
    }

    private bool markForSizeChangedIfNeeded(Size oldSize, Size newSize)
    {
      bool widthChanged = !DoubleUtil.AreClose(oldSize.Width, newSize.Width);
      bool heightChanged = !DoubleUtil.AreClose(oldSize.Height, newSize.Height);
      SizeChangedInfo sizeChangedInfo = this.sizeChangedInfo;
      if (sizeChangedInfo != null)
      {
        sizeChangedInfo.Update(widthChanged, heightChanged);
        return true;
      }
      else
      {
        if (!widthChanged && !heightChanged)
          return false;
        SizeChangedInfo info = new SizeChangedInfo(this, oldSize, widthChanged, heightChanged);
        this.sizeChangedInfo = info;
        ContextLayoutManager.From(this.Dispatcher).AddToSizeChangedChain(info);
        Visual.PropagateFlags((Visual) this, VisualFlags.IsSubtreeDirtyForPrecompute, VisualProxyFlags.IsSubtreeDirtyForRender);
        return true;
      }
    }

    [SecurityTreatAsSafe]
    [SecurityCritical]
    private static void EnsureDpiScale()
    {
      if (!UIElement._setDpi)
        return;
      UIElement._setDpi = false;
      HandleRef hWnd = new HandleRef((object) null, IntPtr.Zero);
      IntPtr dc = MS.Win32.UnsafeNativeMethods.GetDC(hWnd);
      if (dc == IntPtr.Zero)
        throw new Win32Exception();
      try
      {
        int deviceCaps1 = MS.Win32.UnsafeNativeMethods.GetDeviceCaps(new HandleRef((object) null, dc), 88);
        int deviceCaps2 = MS.Win32.UnsafeNativeMethods.GetDeviceCaps(new HandleRef((object) null, dc), 90);
        UIElement._dpiScaleX = (double) deviceCaps1 / 96.0;
        UIElement._dpiScaleY = (double) deviceCaps2 / 96.0;
      }
      finally
      {
        MS.Win32.UnsafeNativeMethods.ReleaseDC(hWnd, new HandleRef((object) null, dc));
      }
    }

    private static void RenderTransform_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      UIElement uiElement = (UIElement) d;
      if (uiElement.NeverMeasured || uiElement.NeverArranged || e.IsASubPropertyChange)
        return;
      uiElement.InvalidateArrange();
      uiElement.AreTransformsClean = false;
    }

    private static bool IsRenderTransformOriginValid(object value)
    {
      Point point = (Point) value;
      if (!DoubleUtil.IsNaN(point.X) && !double.IsPositiveInfinity(point.X) && (!double.IsNegativeInfinity(point.X) && !DoubleUtil.IsNaN(point.Y)) && !double.IsPositiveInfinity(point.Y))
        return !double.IsNegativeInfinity(point.Y);
      else
        return false;
    }

    private static void RenderTransformOrigin_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      UIElement uiElement = (UIElement) d;
      if (uiElement.NeverMeasured || uiElement.NeverArranged)
        return;
      uiElement.InvalidateArrange();
      uiElement.AreTransformsClean = false;
    }

    private void OnVisualAncestorChanged_ForceInherit(object sender, AncestorChangedEventArgs e)
    {
      DependencyObject dependencyObject;
      if (e.OldParent == null)
      {
        dependencyObject = InputElement.GetContainingUIElement(this._parent);
        if (dependencyObject != null && VisualTreeHelper.IsAncestorOf(e.Ancestor, dependencyObject))
          dependencyObject = (DependencyObject) null;
      }
      else
        dependencyObject = InputElement.GetContainingUIElement(this._parent) == null ? InputElement.GetContainingUIElement(e.OldParent) : (DependencyObject) null;
      if (dependencyObject == null)
        return;
      UIElement.SynchronizeForceInheritProperties(this, (ContentElement) null, (UIElement3D) null, dependencyObject);
    }

    private HitTestFilterBehavior InputHitTestFilterCallback(DependencyObject currentNode)
    {
      HitTestFilterBehavior testFilterBehavior = HitTestFilterBehavior.Continue;
      if (UIElementHelper.IsUIElementOrUIElement3D(currentNode))
      {
        if (!UIElementHelper.IsVisible(currentNode))
          testFilterBehavior = HitTestFilterBehavior.ContinueSkipSelfAndChildren;
        if (!UIElementHelper.IsHitTestVisible(currentNode))
          testFilterBehavior = HitTestFilterBehavior.ContinueSkipSelfAndChildren;
      }
      else
        testFilterBehavior = HitTestFilterBehavior.Continue;
      return testFilterBehavior;
    }

    private static RoutedEvent CrackMouseButtonEvent(MouseButtonEventArgs e)
    {
      RoutedEvent routedEvent = (RoutedEvent) null;
      switch (e.ChangedButton)
      {
        case MouseButton.Left:
          routedEvent = e.RoutedEvent != Mouse.PreviewMouseDownEvent ? (e.RoutedEvent != Mouse.MouseDownEvent ? (e.RoutedEvent != Mouse.PreviewMouseUpEvent ? UIElement.MouseLeftButtonUpEvent : UIElement.PreviewMouseLeftButtonUpEvent) : UIElement.MouseLeftButtonDownEvent) : UIElement.PreviewMouseLeftButtonDownEvent;
          break;
        case MouseButton.Right:
          routedEvent = e.RoutedEvent != Mouse.PreviewMouseDownEvent ? (e.RoutedEvent != Mouse.MouseDownEvent ? (e.RoutedEvent != Mouse.PreviewMouseUpEvent ? UIElement.MouseRightButtonUpEvent : UIElement.PreviewMouseRightButtonUpEvent) : UIElement.MouseRightButtonDownEvent) : UIElement.PreviewMouseRightButtonDownEvent;
          break;
      }
      return routedEvent;
    }

    private static void CrackMouseButtonEventAndReRaiseEvent(DependencyObject sender, MouseButtonEventArgs e)
    {
      RoutedEvent newEvent = UIElement.CrackMouseButtonEvent(e);
      if (newEvent == null)
        return;
      UIElement.ReRaiseEventAs(sender, (RoutedEventArgs) e, newEvent);
    }

    private static void ReRaiseEventAs(DependencyObject sender, RoutedEventArgs args, RoutedEvent newEvent)
    {
      RoutedEvent routedEvent = args.RoutedEvent;
      args.OverrideRoutedEvent(newEvent);
      object source = args.Source;
      EventRoute eventRoute = EventRouteFactory.FetchObject(args.RoutedEvent);
      if (TraceRoutedEvent.IsEnabled)
        TraceRoutedEvent.Trace(TraceEventType.Start, TraceRoutedEvent.ReRaiseEventAs, (object) args.RoutedEvent, (object) sender, (object) args, (object) (bool) (args.Handled ? 1 : 0));
      try
      {
        UIElement.BuildRouteHelper(sender, eventRoute, args);
        eventRoute.ReInvokeHandlers((object) sender, args);
        args.OverrideSource(source);
        args.OverrideRoutedEvent(routedEvent);
      }
      finally
      {
        if (TraceRoutedEvent.IsEnabled)
          TraceRoutedEvent.Trace(TraceEventType.Stop, TraceRoutedEvent.ReRaiseEventAs, (object) args.RoutedEvent, (object) sender, (object) args, (object) (bool) (args.Handled ? 1 : 0));
      }
      EventRouteFactory.RecycleObject(eventRoute);
    }

    private static void Opacity_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).pushOpacity();
    }

    private void pushOpacity()
    {
      if (this.Visibility != Visibility.Visible)
        return;
      this.VisualOpacity = this.Opacity;
    }

    private static void OpacityMask_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).pushOpacityMask();
    }

    private void pushOpacityMask()
    {
      this.VisualOpacityMask = this.OpacityMask;
    }

    private static void OnBitmapEffectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).pushBitmapEffect();
    }

    private void pushBitmapEffect()
    {
      this.VisualBitmapEffect = this.BitmapEffect;
    }

    private static void OnEffectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).pushEffect();
    }

    private void pushEffect()
    {
      this.VisualEffect = this.Effect;
    }

    private static void OnBitmapEffectInputChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).pushBitmapEffectInput((BitmapEffectInput) e.NewValue);
    }

    private void pushBitmapEffectInput(BitmapEffectInput newValue)
    {
      this.VisualBitmapEffectInput = newValue;
    }

    private static void EdgeMode_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).pushEdgeMode();
    }

    private void pushEdgeMode()
    {
      this.VisualEdgeMode = RenderOptions.GetEdgeMode((DependencyObject) this);
    }

    private static void BitmapScalingMode_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).pushBitmapScalingMode();
    }

    private void pushBitmapScalingMode()
    {
      this.VisualBitmapScalingMode = RenderOptions.GetBitmapScalingMode((DependencyObject) this);
    }

    private static void ClearTypeHint_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).pushClearTypeHint();
    }

    private void pushClearTypeHint()
    {
      this.VisualClearTypeHint = RenderOptions.GetClearTypeHint((DependencyObject) this);
    }

    private static void TextHintingMode_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).pushTextHintingMode();
    }

    private void pushTextHintingMode()
    {
      this.VisualTextHintingMode = TextOptionsInternal.GetTextHintingMode((DependencyObject) this);
    }

    private static void OnCacheModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).pushCacheMode();
    }

    private void pushCacheMode()
    {
      this.VisualCacheMode = this.CacheMode;
    }

    private void pushVisualEffects()
    {
      this.pushCacheMode();
      this.pushOpacity();
      this.pushOpacityMask();
      this.pushBitmapEffect();
      this.pushEdgeMode();
      this.pushBitmapScalingMode();
      this.pushClearTypeHint();
      this.pushTextHintingMode();
    }

    private static void OnVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      UIElement uiElement = (UIElement) d;
      Visibility visibility = (Visibility) e.NewValue;
      uiElement.VisibilityCache = visibility;
      uiElement.switchVisibilityIfNeeded(visibility);
      uiElement.UpdateIsVisibleCache();
    }

    private static bool ValidateVisibility(object o)
    {
      Visibility visibility = (Visibility) o;
      switch (visibility)
      {
        case Visibility.Visible:
        case Visibility.Hidden:
          return true;
        default:
          return visibility == Visibility.Collapsed;
      }
    }

    private void switchVisibilityIfNeeded(Visibility visibility)
    {
      switch (visibility)
      {
        case Visibility.Visible:
          this.ensureVisible();
          break;
        case Visibility.Hidden:
          this.ensureInvisible(false);
          break;
        case Visibility.Collapsed:
          this.ensureInvisible(true);
          break;
      }
    }

    private void ensureVisible()
    {
      if (!this.ReadFlag(CoreFlags.IsOpacitySuppressed))
        return;
      this.VisualOpacity = this.Opacity;
      if (this.ReadFlag(CoreFlags.IsCollapsed))
      {
        this.WriteFlag(CoreFlags.IsCollapsed, false);
        this.signalDesiredSizeChange();
        this.InvalidateVisual();
      }
      this.WriteFlag(CoreFlags.IsOpacitySuppressed, false);
    }

    private void ensureInvisible(bool collapsed)
    {
      if (!this.ReadFlag(CoreFlags.IsOpacitySuppressed))
      {
        this.VisualOpacity = 0.0;
        this.WriteFlag(CoreFlags.IsOpacitySuppressed, true);
      }
      if (!this.ReadFlag(CoreFlags.IsCollapsed) && collapsed)
      {
        this.WriteFlag(CoreFlags.IsCollapsed, true);
        this.signalDesiredSizeChange();
      }
      else
      {
        if (!this.ReadFlag(CoreFlags.IsCollapsed) || collapsed)
          return;
        this.WriteFlag(CoreFlags.IsCollapsed, false);
        this.signalDesiredSizeChange();
      }
    }

    private void signalDesiredSizeChange()
    {
      UIElement uiParent;
      IContentHost ich;
      this.GetUIParentOrICH(out uiParent, out ich);
      if (uiParent != null)
      {
        uiParent.OnChildDesiredSizeChanged(this);
      }
      else
      {
        if (ich == null)
          return;
        ich.OnChildDesiredSizeChanged(this);
      }
    }

    private void ensureClip(Size layoutSlotSize)
    {
      Geometry geometry = this.GetLayoutClip(layoutSlotSize);
      if (this.Clip != null)
        geometry = geometry != null ? (Geometry) new CombinedGeometry(GeometryCombineMode.Intersect, geometry, this.Clip) : this.Clip;
      this.ChangeVisualClip(geometry, true);
    }

    private static void ClipToBounds_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      UIElement uiElement = (UIElement) d;
      uiElement.ClipToBoundsCache = (bool) e.NewValue;
      if (uiElement.NeverMeasured && uiElement.NeverArranged)
        return;
      uiElement.InvalidateArrange();
    }

    private static void Clip_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      UIElement uiElement = (UIElement) d;
      if (uiElement.NeverMeasured && uiElement.NeverArranged)
        return;
      uiElement.InvalidateArrange();
    }

    private static void SnapsToDevicePixels_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      UIElement uiElement = (UIElement) d;
      uiElement.SnapsToDevicePixelsCache = (bool) e.NewValue;
      if (uiElement.NeverMeasured && uiElement.NeverArranged)
        return;
      uiElement.InvalidateArrange();
    }

    private static void IsFocused_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      UIElement uiElement = (UIElement) d;
      if ((bool) e.NewValue)
        uiElement.OnGotFocus(new RoutedEventArgs(UIElement.GotFocusEvent, (object) uiElement));
      else
        uiElement.OnLostFocus(new RoutedEventArgs(UIElement.LostFocusEvent, (object) uiElement));
    }

    private static object CoerceIsEnabled(DependencyObject d, object value)
    {
      UIElement uiElement = (UIElement) d;
      if (!(bool) value)
        return BooleanBoxes.FalseBox;
      DependencyObject dependencyObject = (DependencyObject) (uiElement.GetUIParentCore() as ContentElement) ?? InputElement.GetContainingUIElement(uiElement._parent);
      if (dependencyObject == null || (bool) dependencyObject.GetValue(UIElement.IsEnabledProperty))
        return BooleanBoxes.Box(uiElement.IsEnabledCore);
      else
        return BooleanBoxes.FalseBox;
    }

    private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      UIElement uiElement = (UIElement) d;
      uiElement.RaiseDependencyPropertyChanged(UIElement.IsEnabledChangedKey, e);
      UIElement.InvalidateForceInheritPropertyOnChildren((Visual) uiElement, e.Property);
      InputManager.SafeCurrentNotifyHitTestInvalidated();
      AutomationPeer automationPeer = uiElement.GetAutomationPeer();
      if (automationPeer == null)
        return;
      automationPeer.InvalidatePeer();
    }

    private static object CoerceIsHitTestVisible(DependencyObject d, object value)
    {
      UIElement uiElement = (UIElement) d;
      if (!(bool) value)
        return BooleanBoxes.FalseBox;
      DependencyObject containingUiElement = InputElement.GetContainingUIElement(uiElement._parent);
      if (containingUiElement == null || UIElementHelper.IsHitTestVisible(containingUiElement))
        return BooleanBoxes.TrueBox;
      else
        return BooleanBoxes.FalseBox;
    }

    private static void OnIsHitTestVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      UIElement uiElement = (UIElement) d;
      uiElement.RaiseDependencyPropertyChanged(UIElement.IsHitTestVisibleChangedKey, e);
      UIElement.InvalidateForceInheritPropertyOnChildren((Visual) uiElement, e.Property);
      InputManager.SafeCurrentNotifyHitTestInvalidated();
    }

    private static object GetIsVisible(DependencyObject d, out BaseValueSourceInternal source)
    {
      source = BaseValueSourceInternal.Local;
      if (!((UIElement) d).IsVisible)
        return BooleanBoxes.FalseBox;
      else
        return BooleanBoxes.TrueBox;
    }

    private static void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      UIElement uiElement = (UIElement) d;
      uiElement.RaiseDependencyPropertyChanged(UIElement.IsVisibleChangedKey, e);
      UIElement.InvalidateForceInheritPropertyOnChildren((Visual) uiElement, e.Property);
      InputManager.SafeCurrentNotifyHitTestInvalidated();
    }

    private static void OnFocusableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).RaiseDependencyPropertyChanged(UIElement.FocusableChangedKey, e);
    }

    private void RaiseDependencyPropertyChanged(EventPrivateKey key, DependencyPropertyChangedEventArgs args)
    {
      EventHandlersStore eventHandlersStore = this.EventHandlersStore;
      if (eventHandlersStore == null)
        return;
      Delegate @delegate = eventHandlersStore.Get(key);
      if (@delegate == null)
        return;
      ((DependencyPropertyChangedEventHandler) @delegate)((object) this, args);
    }

    private static void OnIsManipulationEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      if ((bool) e.NewValue)
        ((UIElement) d).CoerceStylusProperties();
      else
        Manipulation.TryCompleteManipulation((UIElement) d);
    }

    private void CoerceStylusProperties()
    {
      if (!UIElement.IsDefaultValue((DependencyObject) this, Stylus.IsFlicksEnabledProperty))
        return;
      this.SetCurrentValueInternal(Stylus.IsFlicksEnabledProperty, BooleanBoxes.FalseBox);
    }

    private static bool IsDefaultValue(DependencyObject dependencyObject, DependencyProperty dependencyProperty)
    {
      bool hasModifiers;
      bool isExpression;
      bool isAnimated;
      bool isCoerced;
      bool isCurrent;
      if (dependencyObject.GetValueSource(dependencyProperty, (PropertyMetadata) null, out hasModifiers, out isExpression, out isAnimated, out isCoerced, out isCurrent) == BaseValueSourceInternal.Default && !isExpression && !isAnimated)
        return !isCoerced;
      else
        return false;
    }

    private static void OnManipulationStartingThunk(object sender, ManipulationStartingEventArgs e)
    {
      ((UIElement) sender).OnManipulationStarting(e);
    }

    private static void OnManipulationStartedThunk(object sender, ManipulationStartedEventArgs e)
    {
      ((UIElement) sender).OnManipulationStarted(e);
    }

    private static void OnManipulationDeltaThunk(object sender, ManipulationDeltaEventArgs e)
    {
      ((UIElement) sender).OnManipulationDelta(e);
    }

    private static void OnManipulationInertiaStartingThunk(object sender, ManipulationInertiaStartingEventArgs e)
    {
      ((UIElement) sender).OnManipulationInertiaStarting(e);
    }

    private static void OnManipulationBoundaryFeedbackThunk(object sender, ManipulationBoundaryFeedbackEventArgs e)
    {
      ((UIElement) sender).OnManipulationBoundaryFeedback(e);
    }

    private static void OnManipulationCompletedThunk(object sender, ManipulationCompletedEventArgs e)
    {
      ((UIElement) sender).OnManipulationCompleted(e);
    }

    private class InputHitTestResult
    {
      private HitTestResult _result;

      public DependencyObject Result
      {
        get
        {
          if (this._result == null)
            return (DependencyObject) null;
          else
            return this._result.VisualHit;
        }
      }

      public HitTestResultBehavior InputHitTestResultCallback(HitTestResult result)
      {
        this._result = result;
        return HitTestResultBehavior.Stop;
      }
    }
  }
}
