// Type: System.Windows.FrameworkElement
// Assembly: PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\WPF\PresentationFramework.dll

using MS.Internal;
using MS.Internal.KnownBoxes;
using MS.Internal.PresentationFramework;
using MS.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime;
using System.Security;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace System.Windows
{
  [UsableDuringInitialization(true)]
  [RuntimeNameProperty("Name")]
  [StyleTypedProperty(Property = "FocusVisualStyle", StyleTargetType = typeof (Control))]
  [XmlLangProperty("Language")]
  public class FrameworkElement : UIElement, IFrameworkInputElement, IInputElement, ISupportInitialize, IHaveResources, IQueryAmbient
  {
    private static readonly Type _typeofThis = typeof (FrameworkElement);
    [CommonDependencyProperty]
    public static readonly DependencyProperty StyleProperty = DependencyProperty.Register("Style", typeof (Style), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FrameworkElement.OnStyleChanged)));
    public static readonly DependencyProperty OverridesDefaultStyleProperty = DependencyProperty.Register("OverridesDefaultStyle", typeof (bool), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FrameworkElement.OnThemeStyleKeyChanged)));
    public static readonly DependencyProperty UseLayoutRoundingProperty = DependencyProperty.Register("UseLayoutRounding", typeof (bool), typeof (FrameworkElement), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(FrameworkElement.OnUseLayoutRoundingChanged)));
    protected internal static readonly DependencyProperty DefaultStyleKeyProperty = DependencyProperty.Register("DefaultStyleKey", typeof (object), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FrameworkElement.OnThemeStyleKeyChanged)));
    internal static readonly NumberSubstitution DefaultNumberSubstitution = new NumberSubstitution(NumberCultureSource.User, (CultureInfo) null, NumberSubstitutionMethod.AsCulture);
    public static readonly DependencyProperty DataContextProperty = DependencyProperty.Register("DataContext", typeof (object), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(FrameworkElement.OnDataContextChanged)));
    internal static readonly EventPrivateKey DataContextChangedKey = new EventPrivateKey();
    public static readonly DependencyProperty BindingGroupProperty = DependencyProperty.Register("BindingGroup", typeof (BindingGroup), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.Inherits));
    public static readonly DependencyProperty LanguageProperty = DependencyProperty.RegisterAttached("Language", typeof (XmlLanguage), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) XmlLanguage.GetLanguage("en-US"), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.Inherits));
    [CommonDependencyProperty]
    public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof (string), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) string.Empty, FrameworkPropertyMetadataOptions.None, (PropertyChangedCallback) null, (CoerceValueCallback) null, true), new ValidateValueCallback(NameValidationHelper.NameValidationCallback));
    public static readonly DependencyProperty TagProperty = DependencyProperty.Register("Tag", typeof (object), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) null));
    public static readonly DependencyProperty InputScopeProperty = InputMethod.InputScopeProperty.AddOwner(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.Inherits));
    public static readonly RoutedEvent RequestBringIntoViewEvent = EventManager.RegisterRoutedEvent("RequestBringIntoView", RoutingStrategy.Bubble, typeof (RequestBringIntoViewEventHandler), FrameworkElement._typeofThis);
    public static readonly RoutedEvent SizeChangedEvent = EventManager.RegisterRoutedEvent("SizeChanged", RoutingStrategy.Direct, typeof (SizeChangedEventHandler), FrameworkElement._typeofThis);
    private static PropertyMetadata _actualWidthMetadata = (PropertyMetadata) new ReadOnlyFrameworkPropertyMetadata((object) 0.0, new GetReadOnlyValueCallback(FrameworkElement.GetActualWidth));
    private static readonly DependencyPropertyKey ActualWidthPropertyKey = DependencyProperty.RegisterReadOnly("ActualWidth", typeof (double), FrameworkElement._typeofThis, FrameworkElement._actualWidthMetadata);
    public static readonly DependencyProperty ActualWidthProperty = FrameworkElement.ActualWidthPropertyKey.DependencyProperty;
    private static PropertyMetadata _actualHeightMetadata = (PropertyMetadata) new ReadOnlyFrameworkPropertyMetadata((object) 0.0, new GetReadOnlyValueCallback(FrameworkElement.GetActualHeight));
    private static readonly DependencyPropertyKey ActualHeightPropertyKey = DependencyProperty.RegisterReadOnly("ActualHeight", typeof (double), FrameworkElement._typeofThis, FrameworkElement._actualHeightMetadata);
    public static readonly DependencyProperty ActualHeightProperty = FrameworkElement.ActualHeightPropertyKey.DependencyProperty;
    public static readonly DependencyProperty LayoutTransformProperty = DependencyProperty.Register("LayoutTransform", typeof (Transform), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) Transform.Identity, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FrameworkElement.OnLayoutTransformChanged)));
    [CommonDependencyProperty]
    public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof (double), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FrameworkElement.OnTransformDirty)), new ValidateValueCallback(FrameworkElement.IsWidthHeightValid));
    [CommonDependencyProperty]
    public static readonly DependencyProperty MinWidthProperty = DependencyProperty.Register("MinWidth", typeof (double), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) 0.0, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FrameworkElement.OnTransformDirty)), new ValidateValueCallback(FrameworkElement.IsMinWidthHeightValid));
    [CommonDependencyProperty]
    public static readonly DependencyProperty MaxWidthProperty = DependencyProperty.Register("MaxWidth", typeof (double), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) double.PositiveInfinity, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FrameworkElement.OnTransformDirty)), new ValidateValueCallback(FrameworkElement.IsMaxWidthHeightValid));
    [CommonDependencyProperty]
    public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof (double), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FrameworkElement.OnTransformDirty)), new ValidateValueCallback(FrameworkElement.IsWidthHeightValid));
    [CommonDependencyProperty]
    public static readonly DependencyProperty MinHeightProperty = DependencyProperty.Register("MinHeight", typeof (double), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) 0.0, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FrameworkElement.OnTransformDirty)), new ValidateValueCallback(FrameworkElement.IsMinWidthHeightValid));
    [CommonDependencyProperty]
    public static readonly DependencyProperty MaxHeightProperty = DependencyProperty.Register("MaxHeight", typeof (double), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) double.PositiveInfinity, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(FrameworkElement.OnTransformDirty)), new ValidateValueCallback(FrameworkElement.IsMaxWidthHeightValid));
    [CommonDependencyProperty]
    public static readonly DependencyProperty FlowDirectionProperty = DependencyProperty.RegisterAttached("FlowDirection", typeof (FlowDirection), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) FlowDirection.LeftToRight, FrameworkPropertyMetadataOptions.AffectsParentArrange | FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(FrameworkElement.OnFlowDirectionChanged), new CoerceValueCallback(FrameworkElement.CoerceFlowDirectionProperty)), new ValidateValueCallback(FrameworkElement.IsValidFlowDirection));
    [CommonDependencyProperty]
    public static readonly DependencyProperty MarginProperty = DependencyProperty.Register("Margin", typeof (Thickness), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure), new ValidateValueCallback(FrameworkElement.IsMarginValid));
    [CommonDependencyProperty]
    public static readonly DependencyProperty HorizontalAlignmentProperty = DependencyProperty.Register("HorizontalAlignment", typeof (HorizontalAlignment), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) HorizontalAlignment.Stretch, FrameworkPropertyMetadataOptions.AffectsArrange), new ValidateValueCallback(FrameworkElement.ValidateHorizontalAlignmentValue));
    [CommonDependencyProperty]
    public static readonly DependencyProperty VerticalAlignmentProperty = DependencyProperty.Register("VerticalAlignment", typeof (VerticalAlignment), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) VerticalAlignment.Stretch, FrameworkPropertyMetadataOptions.AffectsArrange), new ValidateValueCallback(FrameworkElement.ValidateVerticalAlignmentValue));
    private static Style _defaultFocusVisualStyle = (Style) null;
    public static readonly DependencyProperty FocusVisualStyleProperty = DependencyProperty.Register("FocusVisualStyle", typeof (Style), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) FrameworkElement.DefaultFocusVisualStyle));
    public static readonly DependencyProperty CursorProperty = DependencyProperty.Register("Cursor", typeof (Cursor), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(FrameworkElement.OnCursorChanged)));
    public static readonly DependencyProperty ForceCursorProperty = DependencyProperty.Register("ForceCursor", typeof (bool), FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(FrameworkElement.OnForceCursorChanged)));
    internal static readonly EventPrivateKey InitializedKey = new EventPrivateKey();
    internal static readonly DependencyPropertyKey LoadedPendingPropertyKey = DependencyProperty.RegisterReadOnly("LoadedPending", typeof (object[]), FrameworkElement._typeofThis, new PropertyMetadata((PropertyChangedCallback) null));
    internal static readonly DependencyProperty LoadedPendingProperty = FrameworkElement.LoadedPendingPropertyKey.DependencyProperty;
    internal static readonly DependencyPropertyKey UnloadedPendingPropertyKey = DependencyProperty.RegisterReadOnly("UnloadedPending", typeof (object[]), FrameworkElement._typeofThis, new PropertyMetadata((PropertyChangedCallback) null));
    internal static readonly DependencyProperty UnloadedPendingProperty = FrameworkElement.UnloadedPendingPropertyKey.DependencyProperty;
    public static readonly RoutedEvent LoadedEvent = EventManager.RegisterRoutedEvent("Loaded", RoutingStrategy.Direct, typeof (RoutedEventHandler), FrameworkElement._typeofThis);
    public static readonly RoutedEvent UnloadedEvent = EventManager.RegisterRoutedEvent("Unloaded", RoutingStrategy.Direct, typeof (RoutedEventHandler), FrameworkElement._typeofThis);
    public static readonly DependencyProperty ToolTipProperty = ToolTipService.ToolTipProperty.AddOwner(FrameworkElement._typeofThis);
    public static readonly DependencyProperty ContextMenuProperty = ContextMenuService.ContextMenuProperty.AddOwner(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) null));
    public static readonly RoutedEvent ToolTipOpeningEvent = ToolTipService.ToolTipOpeningEvent.AddOwner(FrameworkElement._typeofThis);
    public static readonly RoutedEvent ToolTipClosingEvent = ToolTipService.ToolTipClosingEvent.AddOwner(FrameworkElement._typeofThis);
    public static readonly RoutedEvent ContextMenuOpeningEvent = ContextMenuService.ContextMenuOpeningEvent.AddOwner(FrameworkElement._typeofThis);
    public static readonly RoutedEvent ContextMenuClosingEvent = ContextMenuService.ContextMenuClosingEvent.AddOwner(FrameworkElement._typeofThis);
    private static readonly UncommonField<SizeBox> UnclippedDesiredSizeField = new UncommonField<SizeBox>();
    private static readonly UncommonField<FrameworkElement.LayoutTransformData> LayoutTransformDataField = new UncommonField<FrameworkElement.LayoutTransformData>();
    internal static readonly UncommonField<ResourceDictionary> ResourcesField = new UncommonField<ResourceDictionary>();
    internal static DependencyObjectType UIElementDType = DependencyObjectType.FromSystemTypeInternal(typeof (UIElement));
    private static DependencyObjectType _controlDType = (DependencyObjectType) null;
    private static DependencyObjectType _contentPresenterDType = (DependencyObjectType) null;
    private static DependencyObjectType _pageFunctionBaseDType = (DependencyObjectType) null;
    private static DependencyObjectType _pageDType = (DependencyObjectType) null;
    internal static readonly EventPrivateKey ResourcesChangedKey = new EventPrivateKey();
    internal static readonly EventPrivateKey InheritedPropertyChangedKey = new EventPrivateKey();
    internal new static DependencyObjectType DType = DependencyObjectType.FromSystemTypeInternal(typeof (FrameworkElement));
    private static readonly UncommonField<DependencyObject> InheritanceContextField = new UncommonField<DependencyObject>();
    private static readonly UncommonField<DependencyObject> MentorField = new UncommonField<DependencyObject>();
    private InternalFlags2 _flags2 = InternalFlags2.R0 | InternalFlags2.R1 | InternalFlags2.R2 | InternalFlags2.R3 | InternalFlags2.R4 | InternalFlags2.R5 | InternalFlags2.R6 | InternalFlags2.R7 | InternalFlags2.R8 | InternalFlags2.R9 | InternalFlags2.RA | InternalFlags2.RB | InternalFlags2.RC | InternalFlags2.RD | InternalFlags2.RE | InternalFlags2.RF;
    private Style _themeStyleCache;
    private Style _styleCache;
    internal DependencyObject _templatedParent;
    private UIElement _templateChild;
    private InternalFlags _flags;
    [ThreadStatic]
    private static FrameworkElement.FrameworkServices _frameworkServices;
    private new DependencyObject _parent;
    private FrugalObjectList<DependencyProperty> _inheritableProperties;

    public Style Style
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._styleCache;
      }
      set
      {
        this.SetValue(FrameworkElement.StyleProperty, (object) value);
      }
    }

    public bool OverridesDefaultStyle
    {
      get
      {
        return (bool) this.GetValue(FrameworkElement.OverridesDefaultStyleProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.OverridesDefaultStyleProperty, BooleanBoxes.Box(value));
      }
    }

    public bool UseLayoutRounding
    {
      get
      {
        return (bool) this.GetValue(FrameworkElement.UseLayoutRoundingProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.UseLayoutRoundingProperty, BooleanBoxes.Box(value));
      }
    }

    protected internal object DefaultStyleKey
    {
      get
      {
        return this.GetValue(FrameworkElement.DefaultStyleKeyProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.DefaultStyleKeyProperty, value);
      }
    }

    internal Style ThemeStyle
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._themeStyleCache;
      }
    }

    internal virtual DependencyObjectType DTypeThemeStyleKey
    {
      get
      {
        return (DependencyObjectType) null;
      }
    }

    internal virtual FrameworkTemplate TemplateInternal
    {
      get
      {
        return (FrameworkTemplate) null;
      }
    }

    internal virtual FrameworkTemplate TemplateCache
    {
      get
      {
        return (FrameworkTemplate) null;
      }
      set
      {
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public TriggerCollection Triggers
    {
      get
      {
        TriggerCollection triggerCollection = EventTrigger.TriggerCollectionField.GetValue((DependencyObject) this);
        if (triggerCollection == null)
        {
          triggerCollection = new TriggerCollection(this);
          EventTrigger.TriggerCollectionField.SetValue((DependencyObject) this, triggerCollection);
        }
        return triggerCollection;
      }
    }

    public DependencyObject TemplatedParent
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._templatedParent;
      }
    }

    internal bool IsTemplateRoot
    {
      get
      {
        return this.TemplateChildIndex == 1;
      }
    }

    internal virtual UIElement TemplateChild
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._templateChild;
      }
      set
      {
        if (value == this._templateChild)
          return;
        this.RemoveVisualChild((Visual) this._templateChild);
        this._templateChild = value;
        this.AddVisualChild((Visual) value);
      }
    }

    internal virtual FrameworkElement StateGroupsRoot
    {
      get
      {
        return this._templateChild as FrameworkElement;
      }
    }

    protected override int VisualChildrenCount
    {
      get
      {
        if (this._templateChild != null)
          return 1;
        else
          return 0;
      }
    }

    internal bool HasResources
    {
      get
      {
        ResourceDictionary resourceDictionary = FrameworkElement.ResourcesField.GetValue((DependencyObject) this);
        if (resourceDictionary == null)
          return false;
        if (resourceDictionary.Count <= 0)
          return resourceDictionary.MergedDictionaries.Count > 0;
        else
          return true;
      }
    }

    [Ambient]
    public ResourceDictionary Resources
    {
      get
      {
        ResourceDictionary resourceDictionary = FrameworkElement.ResourcesField.GetValue((DependencyObject) this);
        if (resourceDictionary == null)
        {
          resourceDictionary = new ResourceDictionary();
          resourceDictionary.AddOwner((DispatcherObject) this);
          FrameworkElement.ResourcesField.SetValue((DependencyObject) this, resourceDictionary);
          if (TraceResourceDictionary.IsEnabled)
            TraceResourceDictionary.TraceActivityItem(TraceResourceDictionary.NewResourceDictionary, (object) this, (object) 0, (object) resourceDictionary);
        }
        return resourceDictionary;
      }
      set
      {
        ResourceDictionary oldDictionary = FrameworkElement.ResourcesField.GetValue((DependencyObject) this);
        FrameworkElement.ResourcesField.SetValue((DependencyObject) this, value);
        if (TraceResourceDictionary.IsEnabled)
          TraceResourceDictionary.Trace(TraceEventType.Start, TraceResourceDictionary.NewResourceDictionary, (object) this, (object) oldDictionary, (object) value);
        if (oldDictionary != null)
          oldDictionary.RemoveOwner((DispatcherObject) this);
        if (value != null && !value.ContainsOwner((DispatcherObject) this))
          value.AddOwner((DispatcherObject) this);
        if (oldDictionary != value)
          TreeWalkHelper.InvalidateOnResourcesChange(this, (FrameworkContentElement) null, new ResourcesChangeInfo(oldDictionary, value));
        if (!TraceResourceDictionary.IsEnabled)
          return;
        TraceResourceDictionary.Trace(TraceEventType.Stop, TraceResourceDictionary.NewResourceDictionary, (object) this, (object) oldDictionary, (object) value);
      }
    }

    ResourceDictionary IHaveResources.Resources
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.Resources;
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.Resources = value;
      }
    }

    protected internal InheritanceBehavior InheritanceBehavior
    {
      get
      {
        return (InheritanceBehavior) ((uint) (this._flags & (InternalFlags) 56) >> 3);
      }
      set
      {
        if (this.IsInitialized)
          throw new InvalidOperationException(System.Windows.SR.Get("Illegal_InheritanceBehaviorSettor"));
        if ((uint) value < 0U || (uint) value > 6U)
          throw new InvalidEnumArgumentException("value", (int) value, typeof (InheritanceBehavior));
        this._flags = (InternalFlags) ((int) ((uint) value << 3) & 56) | this._flags & (InternalFlags) 4294967239;
        if (this._parent == null)
          return;
        TreeWalkHelper.InvalidateOnTreeChange(this, (FrameworkContentElement) null, this._parent, true);
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Localizability(LocalizationCategory.NeverLocalize)]
    public object DataContext
    {
      get
      {
        return this.GetValue(FrameworkElement.DataContextProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.DataContextProperty, value);
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Localizability(LocalizationCategory.NeverLocalize)]
    public BindingGroup BindingGroup
    {
      get
      {
        return (BindingGroup) this.GetValue(FrameworkElement.BindingGroupProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.BindingGroupProperty, (object) value);
      }
    }

    public XmlLanguage Language
    {
      get
      {
        return (XmlLanguage) this.GetValue(FrameworkElement.LanguageProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.LanguageProperty, (object) value);
      }
    }

    [DesignerSerializationOptions(DesignerSerializationOptions.SerializeAsAttribute)]
    [Localizability(LocalizationCategory.NeverLocalize)]
    [MergableProperty(false)]
    public string Name
    {
      get
      {
        return (string) this.GetValue(FrameworkElement.NameProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.NameProperty, (object) value);
      }
    }

    [Localizability(LocalizationCategory.NeverLocalize)]
    public object Tag
    {
      get
      {
        return this.GetValue(FrameworkElement.TagProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.TagProperty, value);
      }
    }

    public InputScope InputScope
    {
      get
      {
        return (InputScope) this.GetValue(FrameworkElement.InputScopeProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.InputScopeProperty, (object) value);
      }
    }

    public double ActualWidth
    {
      get
      {
        return this.RenderSize.Width;
      }
    }

    public double ActualHeight
    {
      get
      {
        return this.RenderSize.Height;
      }
    }

    public Transform LayoutTransform
    {
      get
      {
        return (Transform) this.GetValue(FrameworkElement.LayoutTransformProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.LayoutTransformProperty, (object) value);
      }
    }

    [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
    [TypeConverter(typeof (LengthConverter))]
    public double Width
    {
      get
      {
        return (double) this.GetValue(FrameworkElement.WidthProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.WidthProperty, (object) value);
      }
    }

    [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
    [TypeConverter(typeof (LengthConverter))]
    public double MinWidth
    {
      get
      {
        return (double) this.GetValue(FrameworkElement.MinWidthProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.MinWidthProperty, (object) value);
      }
    }

    [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
    [TypeConverter(typeof (LengthConverter))]
    public double MaxWidth
    {
      get
      {
        return (double) this.GetValue(FrameworkElement.MaxWidthProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.MaxWidthProperty, (object) value);
      }
    }

    [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
    [TypeConverter(typeof (LengthConverter))]
    public double Height
    {
      get
      {
        return (double) this.GetValue(FrameworkElement.HeightProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.HeightProperty, (object) value);
      }
    }

    [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
    [TypeConverter(typeof (LengthConverter))]
    public double MinHeight
    {
      get
      {
        return (double) this.GetValue(FrameworkElement.MinHeightProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.MinHeightProperty, (object) value);
      }
    }

    [TypeConverter(typeof (LengthConverter))]
    [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
    public double MaxHeight
    {
      get
      {
        return (double) this.GetValue(FrameworkElement.MaxHeightProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.MaxHeightProperty, (object) value);
      }
    }

    [Localizability(LocalizationCategory.None)]
    public FlowDirection FlowDirection
    {
      get
      {
        if (!this.IsRightToLeft)
          return FlowDirection.LeftToRight;
        else
          return FlowDirection.RightToLeft;
      }
      set
      {
        this.SetValue(FrameworkElement.FlowDirectionProperty, (object) value);
      }
    }

    public Thickness Margin
    {
      get
      {
        return (Thickness) this.GetValue(FrameworkElement.MarginProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.MarginProperty, (object) value);
      }
    }

    public HorizontalAlignment HorizontalAlignment
    {
      get
      {
        return (HorizontalAlignment) this.GetValue(FrameworkElement.HorizontalAlignmentProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.HorizontalAlignmentProperty, (object) value);
      }
    }

    public VerticalAlignment VerticalAlignment
    {
      get
      {
        return (VerticalAlignment) this.GetValue(FrameworkElement.VerticalAlignmentProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.VerticalAlignmentProperty, (object) value);
      }
    }

    internal static Style DefaultFocusVisualStyle
    {
      get
      {
        if (FrameworkElement._defaultFocusVisualStyle == null)
        {
          Style style = new Style();
          style.Seal();
          FrameworkElement._defaultFocusVisualStyle = style;
        }
        return FrameworkElement._defaultFocusVisualStyle;
      }
    }

    public Style FocusVisualStyle
    {
      get
      {
        return (Style) this.GetValue(FrameworkElement.FocusVisualStyleProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.FocusVisualStyleProperty, (object) value);
      }
    }

    public Cursor Cursor
    {
      get
      {
        return (Cursor) this.GetValue(FrameworkElement.CursorProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.CursorProperty, (object) value);
      }
    }

    public bool ForceCursor
    {
      get
      {
        return (bool) this.GetValue(FrameworkElement.ForceCursorProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.ForceCursorProperty, BooleanBoxes.Box(value));
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool IsInitialized
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.IsInitialized);
      }
    }

    public bool IsLoaded
    {
      get
      {
        object[] loadedPending = this.LoadedPending;
        object[] unloadedPending = this.UnloadedPending;
        if (loadedPending != null || unloadedPending != null)
          return unloadedPending != null;
        if (this.SubtreeHasLoadedChangeHandler)
          return this.IsLoadedCache;
        else
          return BroadcastEventHelper.IsParentLoaded((DependencyObject) this);
      }
    }

    internal static PopupControlService PopupControlService
    {
      get
      {
        return FrameworkElement.EnsureFrameworkServices()._popupControlService;
      }
    }

    internal static KeyboardNavigation KeyboardNavigation
    {
      get
      {
        return FrameworkElement.EnsureFrameworkServices()._keyboardNavigation;
      }
    }

    [Category("Appearance")]
    [Localizability(LocalizationCategory.ToolTip)]
    [Bindable(true)]
    public object ToolTip
    {
      get
      {
        return ToolTipService.GetToolTip((DependencyObject) this);
      }
      set
      {
        ToolTipService.SetToolTip((DependencyObject) this, value);
      }
    }

    public ContextMenu ContextMenu
    {
      get
      {
        return this.GetValue(FrameworkElement.ContextMenuProperty) as ContextMenu;
      }
      set
      {
        this.SetValue(FrameworkElement.ContextMenuProperty, (object) value);
      }
    }

    internal bool HasResourceReference
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.HasResourceReferences);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.HasResourceReferences, value);
      }
    }

    internal bool IsLogicalChildrenIterationInProgress
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.IsLogicalChildrenIterationInProgress);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.IsLogicalChildrenIterationInProgress, value);
      }
    }

    internal bool InVisibilityCollapsedTree
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.InVisibilityCollapsedTree);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.InVisibilityCollapsedTree, value);
      }
    }

    internal bool SubtreeHasLoadedChangeHandler
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag2(InternalFlags2.TreeHasLoadedChangeHandler);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag2(InternalFlags2.TreeHasLoadedChangeHandler, value);
      }
    }

    internal bool IsLoadedCache
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag2(InternalFlags2.IsLoadedCache);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag2(InternalFlags2.IsLoadedCache, value);
      }
    }

    internal bool IsParentAnFE
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag2(InternalFlags2.IsParentAnFE);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag2(InternalFlags2.IsParentAnFE, value);
      }
    }

    internal bool IsTemplatedParentAnFE
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag2(InternalFlags2.IsTemplatedParentAnFE);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag2(InternalFlags2.IsTemplatedParentAnFE, value);
      }
    }

    internal bool HasLogicalChildren
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.HasLogicalChildren);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.HasLogicalChildren, value);
      }
    }

    private bool NeedsClipBounds
    {
      get
      {
        return this.ReadInternalFlag(InternalFlags.NeedsClipBounds);
      }
      set
      {
        this.WriteInternalFlag(InternalFlags.NeedsClipBounds, value);
      }
    }

    private bool HasWidthEverChanged
    {
      get
      {
        return this.ReadInternalFlag(InternalFlags.HasWidthEverChanged);
      }
      set
      {
        this.WriteInternalFlag(InternalFlags.HasWidthEverChanged, value);
      }
    }

    private bool HasHeightEverChanged
    {
      get
      {
        return this.ReadInternalFlag(InternalFlags.HasHeightEverChanged);
      }
      set
      {
        this.WriteInternalFlag(InternalFlags.HasHeightEverChanged, value);
      }
    }

    internal bool IsRightToLeft
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.IsRightToLeft);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.IsRightToLeft, value);
      }
    }

    internal int TemplateChildIndex
    {
      get
      {
        uint num = (uint) (this._flags2 & (InternalFlags2.R0 | InternalFlags2.R1 | InternalFlags2.R2 | InternalFlags2.R3 | InternalFlags2.R4 | InternalFlags2.R5 | InternalFlags2.R6 | InternalFlags2.R7 | InternalFlags2.R8 | InternalFlags2.R9 | InternalFlags2.RA | InternalFlags2.RB | InternalFlags2.RC | InternalFlags2.RD | InternalFlags2.RE | InternalFlags2.RF));
        if ((int) num == (int) ushort.MaxValue)
          return -1;
        else
          return (int) num;
      }
      set
      {
        if (value < -1 || value >= (int) ushort.MaxValue)
          throw new ArgumentOutOfRangeException("value", System.Windows.SR.Get("TemplateChildIndexOutOfRange"));
        this._flags2 = (value == -1 ? InternalFlags2.R0 | InternalFlags2.R1 | InternalFlags2.R2 | InternalFlags2.R3 | InternalFlags2.R4 | InternalFlags2.R5 | InternalFlags2.R6 | InternalFlags2.R7 | InternalFlags2.R8 | InternalFlags2.R9 | InternalFlags2.RA | InternalFlags2.RB | InternalFlags2.RC | InternalFlags2.RD | InternalFlags2.RE | InternalFlags2.RF : (InternalFlags2) value) | this._flags2 & ~(InternalFlags2.R0 | InternalFlags2.R1 | InternalFlags2.R2 | InternalFlags2.R3 | InternalFlags2.R4 | InternalFlags2.R5 | InternalFlags2.R6 | InternalFlags2.R7 | InternalFlags2.R8 | InternalFlags2.R9 | InternalFlags2.RA | InternalFlags2.RB | InternalFlags2.RC | InternalFlags2.RD | InternalFlags2.RE | InternalFlags2.RF);
      }
    }

    internal bool IsRequestingExpression
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag2(InternalFlags2.IsRequestingExpression);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag2(InternalFlags2.IsRequestingExpression, value);
      }
    }

    internal bool BypassLayoutPolicies
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag2(InternalFlags2.BypassLayoutPolicies);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag2(InternalFlags2.BypassLayoutPolicies, value);
      }
    }

    static DependencyObjectType ControlDType
    {
      private get
      {
        if (FrameworkElement._controlDType == null)
          FrameworkElement._controlDType = DependencyObjectType.FromSystemTypeInternal(typeof (Control));
        return FrameworkElement._controlDType;
      }
    }

    static DependencyObjectType ContentPresenterDType
    {
      private get
      {
        if (FrameworkElement._contentPresenterDType == null)
          FrameworkElement._contentPresenterDType = DependencyObjectType.FromSystemTypeInternal(typeof (ContentPresenter));
        return FrameworkElement._contentPresenterDType;
      }
    }

    static DependencyObjectType PageDType
    {
      private get
      {
        if (FrameworkElement._pageDType == null)
          FrameworkElement._pageDType = DependencyObjectType.FromSystemTypeInternal(typeof (Page));
        return FrameworkElement._pageDType;
      }
    }

    static DependencyObjectType PageFunctionBaseDType
    {
      private get
      {
        if (FrameworkElement._pageFunctionBaseDType == null)
          FrameworkElement._pageFunctionBaseDType = DependencyObjectType.FromSystemTypeInternal(typeof (PageFunctionBase));
        return FrameworkElement._pageFunctionBaseDType;
      }
    }

    internal override int EffectiveValuesInitialSize
    {
      get
      {
        return 7;
      }
    }

    internal static double DpiScaleX
    {
      get
      {
        if (SystemParameters.DpiX != 96)
          return (double) SystemParameters.DpiX / 96.0;
        else
          return 1.0;
      }
    }

    internal static double DpiScaleY
    {
      get
      {
        if (SystemParameters.Dpi != 96)
          return (double) SystemParameters.Dpi / 96.0;
        else
          return 1.0;
      }
    }

    public DependencyObject Parent
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ContextVerifiedGetParent();
      }
    }

    protected internal virtual IEnumerator LogicalChildren
    {
      get
      {
        return (IEnumerator) null;
      }
    }

    internal bool ThisHasLoadedChangeEventHandler
    {
      get
      {
        if (this.EventHandlersStore != null && (this.EventHandlersStore.Contains(FrameworkElement.LoadedEvent) || this.EventHandlersStore.Contains(FrameworkElement.UnloadedEvent)) || (this.Style != null && this.Style.HasLoadedChangeHandler || this.ThemeStyle != null && this.ThemeStyle.HasLoadedChangeHandler) || (this.TemplateInternal != null && this.TemplateInternal.HasLoadedChangeHandler || this.HasFefLoadedChangeHandler))
          return true;
        else
          return false;
      }
    }

    internal bool HasFefLoadedChangeHandler
    {
      get
      {
        if (this.TemplatedParent == null)
          return false;
        FrameworkElementFactory fefTreeRoot = BroadcastEventHelper.GetFEFTreeRoot(this.TemplatedParent);
        if (fefTreeRoot == null)
          return false;
        FrameworkElementFactory fef = StyleHelper.FindFEF(fefTreeRoot, this.TemplateChildIndex);
        if (fef == null)
          return false;
        else
          return fef.HasLoadedChangeHandler;
      }
    }

    internal override DependencyObject InheritanceContext
    {
      get
      {
        return FrameworkElement.InheritanceContextField.GetValue((DependencyObject) this);
      }
    }

    internal bool IsStyleUpdateInProgress
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.IsStyleUpdateInProgress);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.IsStyleUpdateInProgress, value);
      }
    }

    internal bool IsThemeStyleUpdateInProgress
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.IsThemeStyleUpdateInProgress);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.IsThemeStyleUpdateInProgress, value);
      }
    }

    internal bool StoresParentTemplateValues
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.StoresParentTemplateValues);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.StoresParentTemplateValues, value);
      }
    }

    internal bool HasNumberSubstitutionChanged
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.HasNumberSubstitutionChanged);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.HasNumberSubstitutionChanged, value);
      }
    }

    internal bool HasTemplateGeneratedSubTree
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.HasTemplateGeneratedSubTree);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.HasTemplateGeneratedSubTree, value);
      }
    }

    internal bool HasImplicitStyleFromResources
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.HasImplicitStyleFromResources);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.HasImplicitStyleFromResources, value);
      }
    }

    internal bool ShouldLookupImplicitStyles
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.ShouldLookupImplicitStyles);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.ShouldLookupImplicitStyles, value);
      }
    }

    internal bool IsStyleSetFromGenerator
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag2(InternalFlags2.IsStyleSetFromGenerator);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag2(InternalFlags2.IsStyleSetFromGenerator, value);
      }
    }

    internal bool HasStyleChanged
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag2(InternalFlags2.HasStyleChanged);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag2(InternalFlags2.HasStyleChanged, value);
      }
    }

    internal bool HasTemplateChanged
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag2(InternalFlags2.HasTemplateChanged);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag2(InternalFlags2.HasTemplateChanged, value);
      }
    }

    internal bool HasStyleInvalidated
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag2(InternalFlags2.HasStyleInvalidated);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag2(InternalFlags2.HasStyleInvalidated, value);
      }
    }

    internal bool HasStyleEverBeenFetched
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.HasStyleEverBeenFetched);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.HasStyleEverBeenFetched, value);
      }
    }

    internal bool HasLocalStyle
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.HasLocalStyle);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.HasLocalStyle, value);
      }
    }

    internal bool HasThemeStyleEverBeenFetched
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.HasThemeStyleEverBeenFetched);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.HasThemeStyleEverBeenFetched, value);
      }
    }

    internal bool AncestorChangeInProgress
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.AncestorChangeInProgress);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.AncestorChangeInProgress, value);
      }
    }

    internal FrugalObjectList<DependencyProperty> InheritableProperties
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._inheritableProperties;
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this._inheritableProperties = value;
      }
    }

    internal object[] LoadedPending
    {
      get
      {
        return (object[]) this.GetValue(FrameworkElement.LoadedPendingProperty);
      }
    }

    internal object[] UnloadedPending
    {
      get
      {
        return (object[]) this.GetValue(FrameworkElement.UnloadedPendingProperty);
      }
    }

    internal override bool HasMultipleInheritanceContexts
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag2(InternalFlags2.HasMultipleInheritanceContexts);
      }
    }

    internal bool PotentiallyHasMentees
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadInternalFlag(InternalFlags.PotentiallyHasMentees);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteInternalFlag(InternalFlags.PotentiallyHasMentees, value);
      }
    }

    public event EventHandler<DataTransferEventArgs> TargetUpdated
    {
      add
      {
        this.AddHandler(Binding.TargetUpdatedEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(Binding.TargetUpdatedEvent, (Delegate) value);
      }
    }

    public event EventHandler<DataTransferEventArgs> SourceUpdated
    {
      add
      {
        this.AddHandler(Binding.SourceUpdatedEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(Binding.SourceUpdatedEvent, (Delegate) value);
      }
    }

    public event DependencyPropertyChangedEventHandler DataContextChanged
    {
      add
      {
        this.EventHandlersStoreAdd(FrameworkElement.DataContextChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(FrameworkElement.DataContextChangedKey, (Delegate) value);
      }
    }

    public event RequestBringIntoViewEventHandler RequestBringIntoView
    {
      add
      {
        this.AddHandler(FrameworkElement.RequestBringIntoViewEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(FrameworkElement.RequestBringIntoViewEvent, (Delegate) value);
      }
    }

    public event SizeChangedEventHandler SizeChanged
    {
      add
      {
        this.AddHandler(FrameworkElement.SizeChangedEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(FrameworkElement.SizeChangedEvent, (Delegate) value);
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler Initialized
    {
      add
      {
        this.EventHandlersStoreAdd(FrameworkElement.InitializedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(FrameworkElement.InitializedKey, (Delegate) value);
      }
    }

    public event RoutedEventHandler Loaded
    {
      add
      {
        this.AddHandler(FrameworkElement.LoadedEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(FrameworkElement.LoadedEvent, (Delegate) value);
      }
    }

    public event RoutedEventHandler Unloaded
    {
      add
      {
        this.AddHandler(FrameworkElement.UnloadedEvent, (Delegate) value, false);
      }
      remove
      {
        this.RemoveHandler(FrameworkElement.UnloadedEvent, (Delegate) value);
      }
    }

    public event ToolTipEventHandler ToolTipOpening
    {
      add
      {
        this.AddHandler(FrameworkElement.ToolTipOpeningEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(FrameworkElement.ToolTipOpeningEvent, (Delegate) value);
      }
    }

    public event ToolTipEventHandler ToolTipClosing
    {
      add
      {
        this.AddHandler(FrameworkElement.ToolTipClosingEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(FrameworkElement.ToolTipClosingEvent, (Delegate) value);
      }
    }

    public event ContextMenuEventHandler ContextMenuOpening
    {
      add
      {
        this.AddHandler(FrameworkElement.ContextMenuOpeningEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(FrameworkElement.ContextMenuOpeningEvent, (Delegate) value);
      }
    }

    public event ContextMenuEventHandler ContextMenuClosing
    {
      add
      {
        this.AddHandler(FrameworkElement.ContextMenuClosingEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(FrameworkElement.ContextMenuClosingEvent, (Delegate) value);
      }
    }

    internal event EventHandler ResourcesChanged
    {
      add
      {
        this.PotentiallyHasMentees = true;
        this.EventHandlersStoreAdd(FrameworkElement.ResourcesChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(FrameworkElement.ResourcesChangedKey, (Delegate) value);
      }
    }

    internal event InheritedPropertyChangedEventHandler InheritedPropertyChanged
    {
      add
      {
        this.PotentiallyHasMentees = true;
        this.EventHandlersStoreAdd(FrameworkElement.InheritedPropertyChangedKey, (Delegate) value);
      }
      remove
      {
        this.EventHandlersStoreRemove(FrameworkElement.InheritedPropertyChangedKey, (Delegate) value);
      }
    }

    static FrameworkElement()
    {
      UIElement.SnapsToDevicePixelsProperty.OverrideMetadata(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));
      EventManager.RegisterClassHandler(FrameworkElement._typeofThis, Mouse.QueryCursorEvent, (Delegate) new QueryCursorEventHandler(FrameworkElement.OnQueryCursorOverride), true);
      EventManager.RegisterClassHandler(FrameworkElement._typeofThis, Keyboard.PreviewGotKeyboardFocusEvent, (Delegate) new KeyboardFocusChangedEventHandler(FrameworkElement.OnPreviewGotKeyboardFocus));
      EventManager.RegisterClassHandler(FrameworkElement._typeofThis, Keyboard.GotKeyboardFocusEvent, (Delegate) new KeyboardFocusChangedEventHandler(FrameworkElement.OnGotKeyboardFocus));
      EventManager.RegisterClassHandler(FrameworkElement._typeofThis, Keyboard.LostKeyboardFocusEvent, (Delegate) new KeyboardFocusChangedEventHandler(FrameworkElement.OnLostKeyboardFocus));
      UIElement.AllowDropProperty.OverrideMetadata(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, FrameworkPropertyMetadataOptions.Inherits));
      Stylus.IsPressAndHoldEnabledProperty.AddOwner(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.TrueBox, FrameworkPropertyMetadataOptions.Inherits));
      Stylus.IsFlicksEnabledProperty.AddOwner(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.TrueBox, FrameworkPropertyMetadataOptions.Inherits));
      Stylus.IsTapFeedbackEnabledProperty.AddOwner(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.TrueBox, FrameworkPropertyMetadataOptions.Inherits));
      Stylus.IsTouchFeedbackEnabledProperty.AddOwner(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.TrueBox, FrameworkPropertyMetadataOptions.Inherits));
      PropertyChangedCallback propertyChangedCallback = new PropertyChangedCallback(FrameworkElement.NumberSubstitutionChanged);
      NumberSubstitution.CultureSourceProperty.OverrideMetadata(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) NumberCultureSource.User, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits, propertyChangedCallback));
      NumberSubstitution.CultureOverrideProperty.OverrideMetadata(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits, propertyChangedCallback));
      NumberSubstitution.SubstitutionProperty.OverrideMetadata(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) NumberSubstitutionMethod.AsCulture, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits, propertyChangedCallback));
      EventManager.RegisterClassHandler(FrameworkElement._typeofThis, FrameworkElement.ToolTipOpeningEvent, (Delegate) new ToolTipEventHandler(FrameworkElement.OnToolTipOpeningThunk));
      EventManager.RegisterClassHandler(FrameworkElement._typeofThis, FrameworkElement.ToolTipClosingEvent, (Delegate) new ToolTipEventHandler(FrameworkElement.OnToolTipClosingThunk));
      EventManager.RegisterClassHandler(FrameworkElement._typeofThis, FrameworkElement.ContextMenuOpeningEvent, (Delegate) new ContextMenuEventHandler(FrameworkElement.OnContextMenuOpeningThunk));
      EventManager.RegisterClassHandler(FrameworkElement._typeofThis, FrameworkElement.ContextMenuClosingEvent, (Delegate) new ContextMenuEventHandler(FrameworkElement.OnContextMenuClosingThunk));
      TextElement.FontFamilyProperty.OverrideMetadata(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) SystemFonts.MessageFontFamily, FrameworkPropertyMetadataOptions.Inherits, (PropertyChangedCallback) null, new CoerceValueCallback(FrameworkElement.CoerceFontFamily)));
      TextElement.FontSizeProperty.OverrideMetadata(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) SystemFonts.MessageFontSize, FrameworkPropertyMetadataOptions.Inherits, (PropertyChangedCallback) null, new CoerceValueCallback(FrameworkElement.CoerceFontSize)));
      TextElement.FontStyleProperty.OverrideMetadata(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) SystemFonts.MessageFontStyle, FrameworkPropertyMetadataOptions.Inherits, (PropertyChangedCallback) null, new CoerceValueCallback(FrameworkElement.CoerceFontStyle)));
      TextElement.FontWeightProperty.OverrideMetadata(FrameworkElement._typeofThis, (PropertyMetadata) new FrameworkPropertyMetadata((object) SystemFonts.MessageFontWeight, FrameworkPropertyMetadataOptions.Inherits, (PropertyChangedCallback) null, new CoerceValueCallback(FrameworkElement.CoerceFontWeight)));
      TextOptions.TextRenderingModeProperty.OverrideMetadata(typeof (FrameworkElement), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(FrameworkElement.TextRenderingMode_Changed)));
    }

    public FrameworkElement()
    {
      PropertyMetadata metadata = FrameworkElement.StyleProperty.GetMetadata(this.DependencyObjectType);
      Style style = (Style) metadata.DefaultValue;
      if (style != null)
        FrameworkElement.OnStyleChanged((DependencyObject) this, new DependencyPropertyChangedEventArgs(FrameworkElement.StyleProperty, metadata, (object) null, (object) style));
      if ((FlowDirection) FrameworkElement.FlowDirectionProperty.GetDefaultValue(this.DependencyObjectType) == FlowDirection.RightToLeft)
        this.IsRightToLeft = true;
      Application current = Application.Current;
      if (current != null && current.HasImplicitStylesInResources)
        this.ShouldLookupImplicitStyles = true;
      FrameworkElement.EnsureFrameworkServices();
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeStyle()
    {
      if (!this.IsStyleSetFromGenerator)
        return this.ReadLocalValue(FrameworkElement.StyleProperty) != DependencyProperty.UnsetValue;
      else
        return false;
    }

    internal static void OnThemeStyleChanged(DependencyObject d, object oldValue, object newValue)
    {
      FrameworkElement fe = (FrameworkElement) d;
      StyleHelper.UpdateThemeStyleCache(fe, (FrameworkContentElement) null, (Style) oldValue, (Style) newValue, ref fe._themeStyleCache);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal virtual void OnTemplateChangedInternal(FrameworkTemplate oldTemplate, FrameworkTemplate newTemplate)
    {
      this.HasTemplateChanged = true;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    protected internal virtual void OnStyleChanged(Style oldStyle, Style newStyle)
    {
      this.HasStyleChanged = true;
    }

    protected internal virtual void ParentLayoutInvalidated(UIElement child)
    {
    }

    public bool ApplyTemplate()
    {
      this.OnPreApplyTemplate();
      bool flag = false;
      UncommonField<HybridDictionary[]> templateDataField = StyleHelper.TemplateDataField;
      FrameworkTemplate templateInternal = this.TemplateInternal;
      int num = 2;
      for (int index = 0; templateInternal != null && index < num && !this.HasTemplateGeneratedSubTree; ++index)
      {
        flag = templateInternal.ApplyTemplateContent(templateDataField, this);
        if (flag)
        {
          this.HasTemplateGeneratedSubTree = true;
          StyleHelper.InvokeDeferredActions((DependencyObject) this, templateInternal);
          this.OnApplyTemplate();
        }
        if (templateInternal != this.TemplateInternal)
          templateInternal = this.TemplateInternal;
        else
          break;
      }
      this.OnPostApplyTemplate();
      return flag;
    }

    internal virtual void OnPreApplyTemplate()
    {
    }

    public virtual void OnApplyTemplate()
    {
    }

    internal virtual void OnPostApplyTemplate()
    {
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    public void BeginStoryboard(Storyboard storyboard)
    {
      this.BeginStoryboard(storyboard, HandoffBehavior.SnapshotAndReplace, false);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    public void BeginStoryboard(Storyboard storyboard, HandoffBehavior handoffBehavior)
    {
      this.BeginStoryboard(storyboard, handoffBehavior, false);
    }

    public void BeginStoryboard(Storyboard storyboard, HandoffBehavior handoffBehavior, bool isControllable)
    {
      if (storyboard == null)
        throw new ArgumentNullException("storyboard");
      storyboard.Begin(this, handoffBehavior, isControllable);
    }

    internal static FrameworkElement FindNamedFrameworkElement(FrameworkElement startElement, string targetName)
    {
      if (targetName == null || targetName.Length == 0)
        return startElement;
      DependencyObject logicalNode = LogicalTreeHelper.FindLogicalNode((DependencyObject) startElement, targetName);
      if (logicalNode == null)
      {
        throw new ArgumentException(System.Windows.SR.Get("TargetNameNotFound", new object[1]
        {
          (object) targetName
        }));
      }
      else
      {
        FrameworkObject frameworkObject = new FrameworkObject(logicalNode);
        if (frameworkObject.IsFE)
          return frameworkObject.FE;
        throw new InvalidOperationException(System.Windows.SR.Get("NamedObjectMustBeFrameworkElement", new object[1]
        {
          (object) targetName
        }));
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTriggers()
    {
      TriggerCollection triggerCollection = EventTrigger.TriggerCollectionField.GetValue((DependencyObject) this);
      if (triggerCollection == null || triggerCollection.Count == 0)
        return false;
      else
        return true;
    }

    protected override Visual GetVisualChild(int index)
    {
      if (this._templateChild == null)
        throw new ArgumentOutOfRangeException("index", (object) index, System.Windows.SR.Get("Visual_ArgumentOutOfRange"));
      if (index != 0)
        throw new ArgumentOutOfRangeException("index", (object) index, System.Windows.SR.Get("Visual_ArgumentOutOfRange"));
      else
        return (Visual) this._templateChild;
    }

    bool IQueryAmbient.IsAmbientPropertyAvailable(string propertyName)
    {
      if (!(propertyName != "Resources"))
        return this.HasResources;
      else
        return true;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeResources()
    {
      if (this.Resources == null || this.Resources.Count == 0)
        return false;
      else
        return true;
    }

    protected internal DependencyObject GetTemplateChild(string childName)
    {
      FrameworkTemplate templateInternal = this.TemplateInternal;
      if (templateInternal == null)
        return (DependencyObject) null;
      else
        return StyleHelper.FindNameInTemplateContent((DependencyObject) this, childName, templateInternal) as DependencyObject;
    }

    public object FindResource(object resourceKey)
    {
      if (resourceKey == null)
        throw new ArgumentNullException("resourceKey");
      object resourceInternal = FrameworkElement.FindResourceInternal(this, (FrameworkContentElement) null, resourceKey);
      if (resourceInternal == DependencyProperty.UnsetValue)
        MS.Internal.Helper.ResourceFailureThrow(resourceKey);
      return resourceInternal;
    }

    public object TryFindResource(object resourceKey)
    {
      if (resourceKey == null)
        throw new ArgumentNullException("resourceKey");
      object obj = FrameworkElement.FindResourceInternal(this, (FrameworkContentElement) null, resourceKey);
      if (obj == DependencyProperty.UnsetValue)
        obj = (object) null;
      return obj;
    }

    internal static object FindImplicitStyleResource(FrameworkElement fe, object resourceKey, out object source)
    {
      if (fe.ShouldLookupImplicitStyles)
      {
        object unlinkedParent = (object) null;
        bool allowDeferredResourceReference = false;
        bool mustReturnDeferredResourceReference = false;
        bool isImplicitStyleLookup = true;
        DependencyObject boundaryElement = (DependencyObject) null;
        if (!(fe is Control))
          boundaryElement = fe.TemplatedParent;
        return FrameworkElement.FindResourceInternal(fe, (FrameworkContentElement) null, FrameworkElement.StyleProperty, resourceKey, unlinkedParent, allowDeferredResourceReference, mustReturnDeferredResourceReference, boundaryElement, isImplicitStyleLookup, out source);
      }
      else
      {
        source = (object) null;
        return DependencyProperty.UnsetValue;
      }
    }

    internal static object FindImplicitStyleResource(FrameworkContentElement fce, object resourceKey, out object source)
    {
      if (fce.ShouldLookupImplicitStyles)
      {
        object unlinkedParent = (object) null;
        bool allowDeferredResourceReference = false;
        bool mustReturnDeferredResourceReference = false;
        bool isImplicitStyleLookup = true;
        DependencyObject templatedParent = fce.TemplatedParent;
        return FrameworkElement.FindResourceInternal((FrameworkElement) null, fce, FrameworkContentElement.StyleProperty, resourceKey, unlinkedParent, allowDeferredResourceReference, mustReturnDeferredResourceReference, templatedParent, isImplicitStyleLookup, out source);
      }
      else
      {
        source = (object) null;
        return DependencyProperty.UnsetValue;
      }
    }

    internal static object FindResourceInternal(FrameworkElement fe, FrameworkContentElement fce, object resourceKey)
    {
      object source;
      return FrameworkElement.FindResourceInternal(fe, fce, (DependencyProperty) null, resourceKey, (object) null, false, false, (DependencyObject) null, false, out source);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal static object FindResourceFromAppOrSystem(object resourceKey, out object source, bool disableThrowOnResourceNotFound, bool allowDeferredResourceReference, bool mustReturnDeferredResourceReference)
    {
      return FrameworkElement.FindResourceInternal((FrameworkElement) null, (FrameworkContentElement) null, (DependencyProperty) null, resourceKey, (object) null, allowDeferredResourceReference, mustReturnDeferredResourceReference, (DependencyObject) null, disableThrowOnResourceNotFound, out source);
    }

    internal static object FindResourceInternal(FrameworkElement fe, FrameworkContentElement fce, DependencyProperty dp, object resourceKey, object unlinkedParent, bool allowDeferredResourceReference, bool mustReturnDeferredResourceReference, DependencyObject boundaryElement, bool isImplicitStyleLookup, out object source)
    {
      InheritanceBehavior inheritanceBehavior = InheritanceBehavior.Default;
      if (TraceResourceDictionary.IsEnabled)
        TraceResourceDictionary.Trace(TraceEventType.Start, TraceResourceDictionary.FindResource, (object) new FrameworkObject(fe, fce).DO, resourceKey);
      try
      {
        if (fe != null || fce != null || unlinkedParent != null)
        {
          object resourceInTree = FrameworkElement.FindResourceInTree(fe, fce, dp, resourceKey, unlinkedParent, allowDeferredResourceReference, mustReturnDeferredResourceReference, boundaryElement, out inheritanceBehavior, out source);
          if (resourceInTree != DependencyProperty.UnsetValue)
            return resourceInTree;
        }
        Application current = Application.Current;
        if (current != null && (inheritanceBehavior == InheritanceBehavior.Default || inheritanceBehavior == InheritanceBehavior.SkipToAppNow || inheritanceBehavior == InheritanceBehavior.SkipToAppNext))
        {
          object resourceInternal = current.FindResourceInternal(resourceKey, allowDeferredResourceReference, mustReturnDeferredResourceReference);
          if (resourceInternal != null)
          {
            source = (object) current;
            if (TraceResourceDictionary.IsEnabled)
              TraceResourceDictionary.TraceActivityItem(TraceResourceDictionary.FoundResourceInApplication, resourceKey, resourceInternal);
            return resourceInternal;
          }
        }
        if (!isImplicitStyleLookup)
        {
          if (inheritanceBehavior != InheritanceBehavior.SkipAllNow)
          {
            if (inheritanceBehavior != InheritanceBehavior.SkipAllNext)
            {
              object resourceInternal = SystemResources.FindResourceInternal(resourceKey, allowDeferredResourceReference, mustReturnDeferredResourceReference);
              if (resourceInternal != null)
              {
                source = (object) SystemResourceHost.Instance;
                if (TraceResourceDictionary.IsEnabled)
                  TraceResourceDictionary.TraceActivityItem(TraceResourceDictionary.FoundResourceInTheme, source, resourceKey, resourceInternal);
                return resourceInternal;
              }
            }
          }
        }
      }
      finally
      {
        if (TraceResourceDictionary.IsEnabled)
          TraceResourceDictionary.Trace(TraceEventType.Stop, TraceResourceDictionary.FindResource, (object) new FrameworkObject(fe, fce).DO, resourceKey);
      }
      if (TraceResourceDictionary.IsEnabledOverride && !isImplicitStyleLookup)
      {
        if (fe != null && fe.IsLoaded || fce != null && fce.IsLoaded)
          TraceResourceDictionary.Trace(TraceEventType.Warning, TraceResourceDictionary.ResourceNotFound, resourceKey);
        else if (TraceResourceDictionary.IsEnabled)
          TraceResourceDictionary.TraceActivityItem(TraceResourceDictionary.ResourceNotFound, resourceKey);
      }
      source = (object) null;
      return DependencyProperty.UnsetValue;
    }

    internal static object FindResourceInTree(FrameworkElement feStart, FrameworkContentElement fceStart, DependencyProperty dp, object resourceKey, object unlinkedParent, bool allowDeferredResourceReference, bool mustReturnDeferredResourceReference, DependencyObject boundaryElement, out InheritanceBehavior inheritanceBehavior, out object source)
    {
      FrameworkObject frameworkObject1 = new FrameworkObject(feStart, fceStart);
      FrameworkObject frameworkObject2 = frameworkObject1;
      int num = 0;
      bool flag = true;
      inheritanceBehavior = InheritanceBehavior.Default;
      while (flag)
      {
        if (num > ContextLayoutManager.s_LayoutRecursionLimit)
          throw new InvalidOperationException(System.Windows.SR.Get("LogicalTreeLoop"));
        ++num;
        Style style1 = (Style) null;
        FrameworkTemplate frameworkTemplate = (FrameworkTemplate) null;
        Style style2 = (Style) null;
        if (frameworkObject2.IsFE)
        {
          FrameworkElement fe = frameworkObject2.FE;
          object resourceOnSelf = fe.FindResourceOnSelf(resourceKey, allowDeferredResourceReference, mustReturnDeferredResourceReference);
          if (resourceOnSelf != DependencyProperty.UnsetValue)
          {
            source = (object) fe;
            if (TraceResourceDictionary.IsEnabled)
              TraceResourceDictionary.TraceActivityItem(TraceResourceDictionary.FoundResourceOnElement, source, resourceKey, resourceOnSelf);
            return resourceOnSelf;
          }
          else
          {
            if (fe != frameworkObject1.FE || StyleHelper.ShouldGetValueFromStyle(dp))
              style1 = fe.Style;
            if (fe != frameworkObject1.FE || StyleHelper.ShouldGetValueFromTemplate(dp))
              frameworkTemplate = fe.TemplateInternal;
            if (fe != frameworkObject1.FE || StyleHelper.ShouldGetValueFromThemeStyle(dp))
              style2 = fe.ThemeStyle;
          }
        }
        else if (frameworkObject2.IsFCE)
        {
          FrameworkContentElement fce = frameworkObject2.FCE;
          object resourceOnSelf = fce.FindResourceOnSelf(resourceKey, allowDeferredResourceReference, mustReturnDeferredResourceReference);
          if (resourceOnSelf != DependencyProperty.UnsetValue)
          {
            source = (object) fce;
            if (TraceResourceDictionary.IsEnabled)
              TraceResourceDictionary.TraceActivityItem(TraceResourceDictionary.FoundResourceOnElement, source, resourceKey, resourceOnSelf);
            return resourceOnSelf;
          }
          else
          {
            if (fce != frameworkObject1.FCE || StyleHelper.ShouldGetValueFromStyle(dp))
              style1 = fce.Style;
            if (fce != frameworkObject1.FCE || StyleHelper.ShouldGetValueFromThemeStyle(dp))
              style2 = fce.ThemeStyle;
          }
        }
        if (style1 != null)
        {
          object resource = style1.FindResource(resourceKey, allowDeferredResourceReference, mustReturnDeferredResourceReference);
          if (resource != DependencyProperty.UnsetValue)
          {
            source = (object) style1;
            if (TraceResourceDictionary.IsEnabled)
              TraceResourceDictionary.TraceActivityItem(TraceResourceDictionary.FoundResourceInStyle, (object) style1.Resources, resourceKey, (object) style1, (object) frameworkObject2.DO, resource);
            return resource;
          }
        }
        if (frameworkTemplate != null)
        {
          object resource = frameworkTemplate.FindResource(resourceKey, allowDeferredResourceReference, mustReturnDeferredResourceReference);
          if (resource != DependencyProperty.UnsetValue)
          {
            source = (object) frameworkTemplate;
            if (TraceResourceDictionary.IsEnabled)
              TraceResourceDictionary.TraceActivityItem(TraceResourceDictionary.FoundResourceInTemplate, (object) frameworkTemplate.Resources, resourceKey, (object) frameworkTemplate, (object) frameworkObject2.DO, resource);
            return resource;
          }
        }
        if (style2 != null)
        {
          object resource = style2.FindResource(resourceKey, allowDeferredResourceReference, mustReturnDeferredResourceReference);
          if (resource != DependencyProperty.UnsetValue)
          {
            source = (object) style2;
            if (TraceResourceDictionary.IsEnabled)
              TraceResourceDictionary.TraceActivityItem(TraceResourceDictionary.FoundResourceInThemeStyle, (object) style2.Resources, resourceKey, (object) style2, (object) frameworkObject2.DO, resource);
            return resource;
          }
        }
        if (boundaryElement == null || frameworkObject2.DO != boundaryElement)
        {
          if (frameworkObject2.IsValid && TreeWalkHelper.SkipNext(frameworkObject2.InheritanceBehavior))
          {
            inheritanceBehavior = frameworkObject2.InheritanceBehavior;
            break;
          }
          else
          {
            if (unlinkedParent != null)
            {
              DependencyObject d = unlinkedParent as DependencyObject;
              if (d != null)
              {
                frameworkObject2.Reset(d);
                if (frameworkObject2.IsValid)
                {
                  flag = true;
                }
                else
                {
                  DependencyObject frameworkParent = FrameworkElement.GetFrameworkParent(unlinkedParent);
                  if (frameworkParent != null)
                  {
                    frameworkObject2.Reset(frameworkParent);
                    flag = true;
                  }
                  else
                    flag = false;
                }
              }
              else
                flag = false;
              unlinkedParent = (object) null;
            }
            else
            {
              frameworkObject2 = frameworkObject2.FrameworkParent;
              flag = frameworkObject2.IsValid;
            }
            if (frameworkObject2.IsValid && TreeWalkHelper.SkipNow(frameworkObject2.InheritanceBehavior))
            {
              inheritanceBehavior = frameworkObject2.InheritanceBehavior;
              break;
            }
          }
        }
        else
          break;
      }
      source = (object) null;
      return DependencyProperty.UnsetValue;
    }

    internal static object FindTemplateResourceInternal(DependencyObject target, object item, Type templateType)
    {
      if (item == null || item is UIElement)
        return (object) null;
      Type type;
      object dataType = ContentPresenter.DataTypeForItem(item, target, out type);
      ArrayList keys = new ArrayList();
      int exactMatch = -1;
      for (; dataType != null; dataType = (object) type)
      {
        object obj = (object) null;
        if (templateType == typeof (ItemContainerTemplate))
          obj = (object) new ItemContainerTemplateKey(dataType);
        else if (templateType == typeof (DataTemplate))
          obj = (object) new DataTemplateKey(dataType);
        if (obj != null)
          keys.Add(obj);
        if (exactMatch == -1)
          exactMatch = keys.Count;
        if (type != (Type) null)
        {
          type = type.BaseType;
          if (type == typeof (object))
            type = (Type) null;
        }
      }
      int count = keys.Count;
      object obj1 = FrameworkElement.FindTemplateResourceInTree(target, keys, exactMatch, ref count);
      if (count >= exactMatch)
      {
        object resourceFromAppOrSystem = MS.Internal.Helper.FindTemplateResourceFromAppOrSystem(target, keys, exactMatch, ref count);
        if (resourceFromAppOrSystem != null)
          obj1 = resourceFromAppOrSystem;
      }
      return obj1;
    }

    internal bool HasNonDefaultValue(DependencyProperty dp)
    {
      return !MS.Internal.Helper.HasDefaultValue((DependencyObject) this, dp);
    }

    internal static INameScope FindScope(DependencyObject d)
    {
      DependencyObject scopeOwner;
      return FrameworkElement.FindScope(d, out scopeOwner);
    }

    internal static INameScope FindScope(DependencyObject d, out DependencyObject scopeOwner)
    {
      for (; d != null; d = LogicalTreeHelper.GetParent(d) ?? MS.Internal.Helper.FindMentor(d.InheritanceContext))
      {
        INameScope nameScope = NameScope.NameScopeFromObject((object) d);
        if (nameScope != null)
        {
          scopeOwner = d;
          return nameScope;
        }
      }
      scopeOwner = (DependencyObject) null;
      return (INameScope) null;
    }

    public void SetResourceReference(DependencyProperty dp, object name)
    {
      this.SetValue(dp, (object) new ResourceReferenceExpression(name));
      this.HasResourceReference = true;
    }

    internal override sealed void EvaluateBaseValueCore(DependencyProperty dp, PropertyMetadata metadata, ref EffectiveValueEntry newEntry)
    {
      if (dp == FrameworkElement.StyleProperty)
      {
        this.HasStyleEverBeenFetched = true;
        this.HasImplicitStyleFromResources = false;
        this.IsStyleSetFromGenerator = false;
      }
      this.GetRawValue(dp, metadata, ref newEntry);
      Storyboard.GetComplexPathValue((DependencyObject) this, dp, ref newEntry, metadata);
    }

    internal void GetRawValue(DependencyProperty dp, PropertyMetadata metadata, ref EffectiveValueEntry entry)
    {
      if (entry.BaseValueSourceInternal == BaseValueSourceInternal.Local && entry.GetFlattenedEntry(RequestFlags.FullyResolved).Value != DependencyProperty.UnsetValue || this.TemplateChildIndex != -1 && this.GetValueFromTemplatedParent(dp, ref entry))
        return;
      if (dp != FrameworkElement.StyleProperty)
      {
        if (StyleHelper.GetValueFromStyleOrTemplate(new FrameworkObject(this, (FrameworkContentElement) null), dp, ref entry))
          return;
      }
      else
      {
        object source;
        object implicitStyleResource = FrameworkElement.FindImplicitStyleResource(this, (object) this.GetType(), out source);
        if (implicitStyleResource != DependencyProperty.UnsetValue)
        {
          this.HasImplicitStyleFromResources = true;
          entry.BaseValueSourceInternal = BaseValueSourceInternal.ImplicitReference;
          entry.Value = implicitStyleResource;
          return;
        }
      }
      FrameworkPropertyMetadata fmetadata = metadata as FrameworkPropertyMetadata;
      if (fmetadata == null || !fmetadata.Inherits)
        return;
      object inheritableValue = this.GetInheritableValue(dp, fmetadata);
      if (inheritableValue == DependencyProperty.UnsetValue)
        return;
      entry.BaseValueSourceInternal = BaseValueSourceInternal.Inherited;
      entry.Value = inheritableValue;
    }

    internal Expression GetExpressionCore(DependencyProperty dp, PropertyMetadata metadata)
    {
      this.IsRequestingExpression = true;
      EffectiveValueEntry newEntry = new EffectiveValueEntry(dp);
      newEntry.Value = DependencyProperty.UnsetValue;
      this.EvaluateBaseValueCore(dp, metadata, ref newEntry);
      this.IsRequestingExpression = false;
      return newEntry.Value as Expression;
    }

    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
      DependencyProperty property = e.Property;
      base.OnPropertyChanged(e);
      if (e.IsAValueChange || e.IsASubPropertyChange)
      {
        if (property != null && property.OwnerType == typeof (PresentationSource) && property.Name == "RootSource")
          this.TryFireInitialized();
        if (property == FrameworkElement.NameProperty && EventTrace.IsEnabled(EventTrace.Keyword.KeywordGeneral, EventTrace.Level.Verbose))
        {
          int num = (int) EventTrace.EventProvider.TraceEvent(EventTrace.Event.PerfElementIDName, EventTrace.Keyword.KeywordGeneral, EventTrace.Level.Verbose, (object) PerfService.GetPerfElementID((object) this), (object) this.GetType().Name, this.GetValue(property));
        }
        if (property != FrameworkElement.StyleProperty && property != Control.TemplateProperty && property != FrameworkElement.DefaultStyleKeyProperty)
        {
          if (this.TemplatedParent != null)
          {
            FrameworkTemplate templateInternal = (this.TemplatedParent as FrameworkElement).TemplateInternal;
            StyleHelper.OnTriggerSourcePropertyInvalidated((Style) null, templateInternal, this.TemplatedParent, property, e, false, ref templateInternal.TriggerSourceRecordFromChildIndex, ref templateInternal.PropertyTriggersWithActions, this.TemplateChildIndex);
          }
          if (this.Style != null)
            StyleHelper.OnTriggerSourcePropertyInvalidated(this.Style, (FrameworkTemplate) null, (DependencyObject) this, property, e, true, ref this.Style.TriggerSourceRecordFromChildIndex, ref this.Style.PropertyTriggersWithActions, 0);
          if (this.TemplateInternal != null)
            StyleHelper.OnTriggerSourcePropertyInvalidated((Style) null, this.TemplateInternal, (DependencyObject) this, property, e, !this.HasTemplateGeneratedSubTree, ref this.TemplateInternal.TriggerSourceRecordFromChildIndex, ref this.TemplateInternal.PropertyTriggersWithActions, 0);
          if (this.ThemeStyle != null && this.Style != this.ThemeStyle)
            StyleHelper.OnTriggerSourcePropertyInvalidated(this.ThemeStyle, (FrameworkTemplate) null, (DependencyObject) this, property, e, true, ref this.ThemeStyle.TriggerSourceRecordFromChildIndex, ref this.ThemeStyle.PropertyTriggersWithActions, 0);
        }
      }
      FrameworkPropertyMetadata propertyMetadata = e.Metadata as FrameworkPropertyMetadata;
      if (propertyMetadata == null)
        return;
      if (propertyMetadata.Inherits && (this.InheritanceBehavior == InheritanceBehavior.Default || propertyMetadata.OverridesInheritanceBehavior) && (!DependencyObject.IsTreeWalkOperation(e.OperationType) || this.PotentiallyHasMentees))
      {
        EffectiveValueEntry newEntry = e.NewEntry;
        EffectiveValueEntry oldEntry1 = e.OldEntry;
        if (oldEntry1.BaseValueSourceInternal > newEntry.BaseValueSourceInternal)
        {
          newEntry = new EffectiveValueEntry(property, BaseValueSourceInternal.Inherited);
        }
        else
        {
          newEntry = newEntry.GetFlattenedEntry(RequestFlags.FullyResolved);
          newEntry.BaseValueSourceInternal = BaseValueSourceInternal.Inherited;
        }
        EffectiveValueEntry oldEntry2;
        if (oldEntry1.BaseValueSourceInternal != BaseValueSourceInternal.Default || oldEntry1.HasModifiers)
        {
          oldEntry2 = oldEntry1.GetFlattenedEntry(RequestFlags.FullyResolved);
          oldEntry2.BaseValueSourceInternal = BaseValueSourceInternal.Inherited;
        }
        else
          oldEntry2 = new EffectiveValueEntry();
        InheritablePropertyChangeInfo info = new InheritablePropertyChangeInfo((DependencyObject) this, property, oldEntry2, newEntry);
        if (!DependencyObject.IsTreeWalkOperation(e.OperationType))
          TreeWalkHelper.InvalidateOnInheritablePropertyChange(this, (FrameworkContentElement) null, info, true);
        if (this.PotentiallyHasMentees)
          TreeWalkHelper.OnInheritedPropertyChanged((DependencyObject) this, ref info, this.InheritanceBehavior);
      }
      if (!e.IsAValueChange && !e.IsASubPropertyChange || this.AncestorChangeInProgress && this.InVisibilityCollapsedTree)
        return;
      bool affectsParentMeasure = propertyMetadata.AffectsParentMeasure;
      bool affectsParentArrange = propertyMetadata.AffectsParentArrange;
      if (propertyMetadata.AffectsMeasure || propertyMetadata.AffectsArrange || (affectsParentArrange || affectsParentMeasure))
      {
        for (Visual visual = VisualTreeHelper.GetParent((DependencyObject) this) as Visual; visual != null; visual = VisualTreeHelper.GetParent((DependencyObject) visual) as Visual)
        {
          UIElement uiElement = visual as UIElement;
          if (uiElement != null)
          {
            if (FrameworkElement.DType.IsInstanceOfType((DependencyObject) uiElement))
              ((FrameworkElement) uiElement).ParentLayoutInvalidated((UIElement) this);
            if (affectsParentMeasure)
              uiElement.InvalidateMeasure();
            if (affectsParentArrange)
            {
              uiElement.InvalidateArrange();
              break;
            }
            else
              break;
          }
        }
      }
      if (propertyMetadata.AffectsMeasure && (!this.BypassLayoutPolicies || property != FrameworkElement.WidthProperty && property != FrameworkElement.HeightProperty))
        this.InvalidateMeasure();
      if (propertyMetadata.AffectsArrange)
        this.InvalidateArrange();
      if (!propertyMetadata.AffectsRender || !e.IsAValueChange && propertyMetadata.SubPropertiesDoNotAffectRender)
        return;
      this.InvalidateVisual();
    }

    internal static DependencyObject GetFrameworkParent(object current)
    {
      FrameworkObject frameworkObject = new FrameworkObject(current as DependencyObject);
      frameworkObject = frameworkObject.FrameworkParent;
      return frameworkObject.DO;
    }

    internal static bool GetFrameworkParent(FrameworkElement current, out FrameworkElement feParent, out FrameworkContentElement fceParent)
    {
      FrameworkObject frameworkObject = new FrameworkObject(current, (FrameworkContentElement) null);
      frameworkObject = frameworkObject.FrameworkParent;
      feParent = frameworkObject.FE;
      fceParent = frameworkObject.FCE;
      return frameworkObject.IsValid;
    }

    internal static bool GetFrameworkParent(FrameworkContentElement current, out FrameworkElement feParent, out FrameworkContentElement fceParent)
    {
      FrameworkObject frameworkObject = new FrameworkObject((FrameworkElement) null, current);
      frameworkObject = frameworkObject.FrameworkParent;
      feParent = frameworkObject.FE;
      fceParent = frameworkObject.FCE;
      return frameworkObject.IsValid;
    }

    internal static bool GetContainingFrameworkElement(DependencyObject current, out FrameworkElement fe, out FrameworkContentElement fce)
    {
      FrameworkObject frameworkElement = FrameworkObject.GetContainingFrameworkElement(current);
      if (frameworkElement.IsValid)
      {
        fe = frameworkElement.FE;
        fce = frameworkElement.FCE;
        return true;
      }
      else
      {
        fe = (FrameworkElement) null;
        fce = (FrameworkContentElement) null;
        return false;
      }
    }

    internal static void GetTemplatedParentChildRecord(DependencyObject templatedParent, int childIndex, out ChildRecord childRecord, out bool isChildRecordValid)
    {
      isChildRecordValid = false;
      childRecord = new ChildRecord();
      if (templatedParent == null)
        return;
      FrameworkTemplate templateInternal = new FrameworkObject(templatedParent, true).FE.TemplateInternal;
      if (templateInternal == null || 0 > childIndex || childIndex >= templateInternal.ChildRecordFromChildIndex.Count)
        return;
      childRecord = templateInternal.ChildRecordFromChildIndex[childIndex];
      isChildRecordValid = true;
    }

    internal virtual string GetPlainText()
    {
      return (string) null;
    }

    internal virtual void pushTextRenderingMode()
    {
      if (DependencyPropertyHelper.GetValueSource((DependencyObject) this, TextOptions.TextRenderingModeProperty).BaseValueSource <= BaseValueSource.Inherited)
        return;
      this.VisualTextRenderingMode = TextOptions.GetTextRenderingMode((DependencyObject) this);
    }

    internal virtual void OnAncestorChanged()
    {
    }

    protected internal override void OnVisualParentChanged(DependencyObject oldParent)
    {
      DependencyObject parentInternal = VisualTreeHelper.GetParentInternal((DependencyObject) this);
      if (parentInternal != null)
        this.ClearInheritanceContext();
      BroadcastEventHelper.AddOrRemoveHasLoadedChangeHandlerFlag((DependencyObject) this, oldParent, parentInternal);
      BroadcastEventHelper.BroadcastLoadedOrUnloadedEvent((DependencyObject) this, oldParent, parentInternal);
      if (parentInternal != null && !(parentInternal is FrameworkElement))
      {
        Visual visual = parentInternal as Visual;
        if (visual != null)
          visual.VisualAncestorChanged += new Visual.AncestorChangedEventHandler(this.OnVisualAncestorChanged);
        else if (parentInternal is Visual3D)
          ((Visual3D) parentInternal).VisualAncestorChanged += new Visual.AncestorChangedEventHandler(this.OnVisualAncestorChanged);
      }
      else if (oldParent != null && !(oldParent is FrameworkElement))
      {
        Visual visual = oldParent as Visual;
        if (visual != null)
          visual.VisualAncestorChanged -= new Visual.AncestorChangedEventHandler(this.OnVisualAncestorChanged);
        else if (oldParent is Visual3D)
          ((Visual3D) oldParent).VisualAncestorChanged -= new Visual.AncestorChangedEventHandler(this.OnVisualAncestorChanged);
      }
      if (this.Parent == null)
        TreeWalkHelper.InvalidateOnTreeChange(this, (FrameworkContentElement) null, parentInternal ?? oldParent, parentInternal != null);
      this.TryFireInitialized();
      base.OnVisualParentChanged(oldParent);
    }

    internal new void OnVisualAncestorChanged(object sender, AncestorChangedEventArgs e)
    {
      FrameworkElement fe = (FrameworkElement) null;
      FrameworkContentElement fce = (FrameworkContentElement) null;
      FrameworkElement.GetContainingFrameworkElement(VisualTreeHelper.GetParent((DependencyObject) this), out fe, out fce);
      if (e.OldParent == null)
      {
        if (fe != null && VisualTreeHelper.IsAncestorOf(e.Ancestor, (DependencyObject) fe))
          return;
        BroadcastEventHelper.AddOrRemoveHasLoadedChangeHandlerFlag((DependencyObject) this, (DependencyObject) null, VisualTreeHelper.GetParent(e.Ancestor));
        BroadcastEventHelper.BroadcastLoadedOrUnloadedEvent((DependencyObject) this, (DependencyObject) null, VisualTreeHelper.GetParent(e.Ancestor));
      }
      else
      {
        if (fe != null)
          return;
        FrameworkElement.GetContainingFrameworkElement(e.OldParent, out fe, out fce);
        if (fe == null)
          return;
        BroadcastEventHelper.AddOrRemoveHasLoadedChangeHandlerFlag((DependencyObject) this, (DependencyObject) fe, (DependencyObject) null);
        BroadcastEventHelper.BroadcastLoadedOrUnloadedEvent((DependencyObject) this, (DependencyObject) fe, (DependencyObject) null);
      }
    }

    public BindingExpression GetBindingExpression(DependencyProperty dp)
    {
      return BindingOperations.GetBindingExpression((DependencyObject) this, dp);
    }

    public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
    {
      return BindingOperations.SetBinding((DependencyObject) this, dp, binding);
    }

    public BindingExpression SetBinding(DependencyProperty dp, string path)
    {
      return (BindingExpression) this.SetBinding(dp, (BindingBase) new Binding(path));
    }

    protected internal override DependencyObject GetUIParentCore()
    {
      return this._parent;
    }

    internal override object AdjustEventSource(RoutedEventArgs args)
    {
      object obj = (object) null;
      if (this._parent != null || this.HasLogicalChildren)
      {
        DependencyObject child = args.Source as DependencyObject;
        if (child == null || !this.IsLogicalDescendent(child))
        {
          args.Source = (object) this;
          obj = (object) this;
        }
      }
      return obj;
    }

    internal virtual void AdjustBranchSource(RoutedEventArgs args)
    {
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal override bool BuildRouteCore(EventRoute route, RoutedEventArgs args)
    {
      return this.BuildRouteCoreHelper(route, args, true);
    }

    internal bool BuildRouteCoreHelper(EventRoute route, RoutedEventArgs args, bool shouldAddIntermediateElementsToRoute)
    {
      bool flag = false;
      DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject) this);
      DependencyObject uiParentCore = this.GetUIParentCore();
      DependencyObject dependencyObject = route.PeekBranchNode() as DependencyObject;
      if (dependencyObject != null && this.IsLogicalDescendent(dependencyObject))
      {
        args.Source = route.PeekBranchSource();
        this.AdjustBranchSource(args);
        route.AddSource(args.Source);
        route.PopBranchNode();
        if (shouldAddIntermediateElementsToRoute)
          FrameworkElement.AddIntermediateElementsToRoute((DependencyObject) this, route, args, LogicalTreeHelper.GetParent(dependencyObject));
      }
      if (!this.IgnoreModelParentBuildRoute(args))
      {
        if (parent == null)
          flag = uiParentCore != null;
        else if (uiParentCore != null)
        {
          Visual visual = parent as Visual;
          if (visual != null)
          {
            if (visual.CheckFlagsAnd(VisualFlags.IsLayoutIslandRoot))
              flag = true;
          }
          else if (((Visual3D) parent).CheckFlagsAnd(VisualFlags.IsLayoutIslandRoot))
            flag = true;
          route.PushBranchNode((object) this, args.Source);
          args.Source = (object) parent;
        }
      }
      return flag;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal override void AddToEventRouteCore(EventRoute route, RoutedEventArgs args)
    {
      FrameworkElement.AddStyleHandlersToEventRoute(this, (FrameworkContentElement) null, route, args);
    }

    internal static void AddStyleHandlersToEventRoute(FrameworkElement fe, FrameworkContentElement fce, EventRoute route, RoutedEventArgs args)
    {
      DependencyObject source = fe != null ? (DependencyObject) fe : (DependencyObject) fce;
      FrameworkTemplate frameworkTemplate = (FrameworkTemplate) null;
      Style style;
      DependencyObject templatedParent;
      int templateChildIndex;
      if (fe != null)
      {
        style = fe.Style;
        frameworkTemplate = fe.TemplateInternal;
        templatedParent = fe.TemplatedParent;
        templateChildIndex = fe.TemplateChildIndex;
      }
      else
      {
        style = fce.Style;
        templatedParent = fce.TemplatedParent;
        templateChildIndex = fce.TemplateChildIndex;
      }
      if (style != null && style.EventHandlersStore != null)
      {
        RoutedEventHandlerInfo[] routedEventHandlers = style.EventHandlersStore.GetRoutedEventHandlers(args.RoutedEvent);
        FrameworkElement.AddStyleHandlersToEventRoute(route, source, routedEventHandlers);
      }
      if (frameworkTemplate != null && frameworkTemplate.EventHandlersStore != null)
      {
        RoutedEventHandlerInfo[] routedEventHandlers = frameworkTemplate.EventHandlersStore.GetRoutedEventHandlers(args.RoutedEvent);
        FrameworkElement.AddStyleHandlersToEventRoute(route, source, routedEventHandlers);
      }
      if (templatedParent == null)
        return;
      FrameworkTemplate templateInternal = (templatedParent as FrameworkElement).TemplateInternal;
      RoutedEventHandlerInfo[] handlers = (RoutedEventHandlerInfo[]) null;
      if (templateInternal != null && templateInternal.HasEventDependents)
        handlers = StyleHelper.GetChildRoutedEventHandlers(templateChildIndex, args.RoutedEvent, ref templateInternal.EventDependents);
      FrameworkElement.AddStyleHandlersToEventRoute(route, source, handlers);
    }

    internal virtual bool IgnoreModelParentBuildRoute(RoutedEventArgs args)
    {
      return false;
    }

    internal override bool InvalidateAutomationAncestorsCore(Stack<DependencyObject> branchNodeStack, out bool continuePastCoreTree)
    {
      bool shouldInvalidateIntermediateElements = true;
      return this.InvalidateAutomationAncestorsCoreHelper(branchNodeStack, out continuePastCoreTree, shouldInvalidateIntermediateElements);
    }

    internal bool InvalidateAutomationAncestorsCoreHelper(Stack<DependencyObject> branchNodeStack, out bool continuePastCoreTree, bool shouldInvalidateIntermediateElements)
    {
      bool flag = true;
      continuePastCoreTree = false;
      DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject) this);
      DependencyObject uiParentCore = this.GetUIParentCore();
      DependencyObject dependencyObject = branchNodeStack.Count > 0 ? branchNodeStack.Peek() : (DependencyObject) null;
      if (dependencyObject != null && this.IsLogicalDescendent(dependencyObject))
      {
        branchNodeStack.Pop();
        if (shouldInvalidateIntermediateElements)
          flag = FrameworkElement.InvalidateAutomationIntermediateElements((DependencyObject) this, LogicalTreeHelper.GetParent(dependencyObject));
      }
      if (parent == null)
        continuePastCoreTree = uiParentCore != null;
      else if (uiParentCore != null)
      {
        Visual visual = parent as Visual;
        if (visual != null)
        {
          if (visual.CheckFlagsAnd(VisualFlags.IsLayoutIslandRoot))
            continuePastCoreTree = true;
        }
        else if (((Visual3D) parent).CheckFlagsAnd(VisualFlags.IsLayoutIslandRoot))
          continuePastCoreTree = true;
        branchNodeStack.Push((DependencyObject) this);
      }
      return flag;
    }

    internal static bool InvalidateAutomationIntermediateElements(DependencyObject mergePoint, DependencyObject modelTreeNode)
    {
      UIElement e = (UIElement) null;
      ContentElement ce = (ContentElement) null;
      UIElement3D e3d = (UIElement3D) null;
      for (; modelTreeNode != null && modelTreeNode != mergePoint; modelTreeNode = LogicalTreeHelper.GetParent(modelTreeNode))
      {
        if (!UIElementHelper.InvalidateAutomationPeer(modelTreeNode, out e, out ce, out e3d))
          return false;
      }
      return true;
    }

    public void BringIntoView()
    {
      this.BringIntoView(Rect.Empty);
    }

    public void BringIntoView(Rect targetRectangle)
    {
      RequestBringIntoViewEventArgs intoViewEventArgs = new RequestBringIntoViewEventArgs((DependencyObject) this, targetRectangle);
      intoViewEventArgs.RoutedEvent = FrameworkElement.RequestBringIntoViewEvent;
      this.RaiseEvent((RoutedEventArgs) intoViewEventArgs);
    }

    public static FlowDirection GetFlowDirection(DependencyObject element)
    {
      if (element == null)
        throw new ArgumentNullException("element");
      else
        return (FlowDirection) element.GetValue(FrameworkElement.FlowDirectionProperty);
    }

    public static void SetFlowDirection(DependencyObject element, FlowDirection value)
    {
      if (element == null)
        throw new ArgumentNullException("element");
      element.SetValue(FrameworkElement.FlowDirectionProperty, (object) value);
    }

    internal static bool ValidateHorizontalAlignmentValue(object value)
    {
      HorizontalAlignment horizontalAlignment = (HorizontalAlignment) value;
      switch (horizontalAlignment)
      {
        case HorizontalAlignment.Left:
        case HorizontalAlignment.Center:
        case HorizontalAlignment.Right:
          return true;
        default:
          return horizontalAlignment == HorizontalAlignment.Stretch;
      }
    }

    internal static bool ValidateVerticalAlignmentValue(object value)
    {
      VerticalAlignment verticalAlignment = (VerticalAlignment) value;
      switch (verticalAlignment)
      {
        case VerticalAlignment.Top:
        case VerticalAlignment.Center:
        case VerticalAlignment.Bottom:
          return true;
        default:
          return verticalAlignment == VerticalAlignment.Stretch;
      }
    }

    internal static bool ShouldApplyMirrorTransform(FrameworkElement fe)
    {
      FlowDirection flowDirection = fe.FlowDirection;
      FlowDirection parentFD = FlowDirection.LeftToRight;
      DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject) fe);
      if (parent != null)
      {
        parentFD = FrameworkElement.GetFlowDirectionFromVisual(parent);
      }
      else
      {
        FrameworkElement feParent;
        FrameworkContentElement fceParent;
        if (FrameworkElement.GetFrameworkParent(fe, out feParent, out fceParent))
        {
          if (feParent != null && feParent is IContentHost)
            parentFD = feParent.FlowDirection;
          else if (fceParent != null)
            parentFD = (FlowDirection) fceParent.GetValue(FrameworkElement.FlowDirectionProperty);
        }
      }
      return FrameworkElement.ApplyMirrorTransform(parentFD, flowDirection);
    }

    internal static bool ApplyMirrorTransform(FlowDirection parentFD, FlowDirection thisFD)
    {
      if (parentFD == FlowDirection.LeftToRight && thisFD == FlowDirection.RightToLeft)
        return true;
      if (parentFD == FlowDirection.RightToLeft)
        return thisFD == FlowDirection.LeftToRight;
      else
        return false;
    }

    protected override sealed Size MeasureCore(Size availableSize)
    {
      bool useLayoutRounding = this.UseLayoutRounding;
      if (useLayoutRounding && !this.CheckFlagsAnd(VisualFlags.UseLayoutRounding))
        this.SetFlags(true, VisualFlags.UseLayoutRounding);
      this.ApplyTemplate();
      if (this.BypassLayoutPolicies)
        return this.MeasureOverride(availableSize);
      Thickness margin = this.Margin;
      double num1 = margin.Left + margin.Right;
      double num2 = margin.Top + margin.Bottom;
      if (useLayoutRounding && this is ScrollContentPresenter)
      {
        num1 = UIElement.RoundLayoutValue(num1, FrameworkElement.DpiScaleX);
        num2 = UIElement.RoundLayoutValue(num2, FrameworkElement.DpiScaleY);
      }
      Size size1 = new Size(Math.Max(availableSize.Width - num1, 0.0), Math.Max(availableSize.Height - num2, 0.0));
      FrameworkElement.MinMax minMax = new FrameworkElement.MinMax(this);
      FrameworkElement.LayoutTransformData layoutTransformData = FrameworkElement.LayoutTransformDataField.GetValue((DependencyObject) this);
      Transform layoutTransform = this.LayoutTransform;
      if (layoutTransform != null && !layoutTransform.IsIdentity)
      {
        if (layoutTransformData == null)
        {
          layoutTransformData = new FrameworkElement.LayoutTransformData();
          FrameworkElement.LayoutTransformDataField.SetValue((DependencyObject) this, layoutTransformData);
        }
        layoutTransformData.CreateTransformSnapshot(layoutTransform);
        layoutTransformData.UntransformedDS = new Size();
        if (useLayoutRounding)
          layoutTransformData.TransformedUnroundedDS = new Size();
      }
      else if (layoutTransformData != null)
      {
        layoutTransformData = (FrameworkElement.LayoutTransformData) null;
        FrameworkElement.LayoutTransformDataField.ClearValue((DependencyObject) this);
      }
      if (layoutTransformData != null)
        size1 = this.FindMaximalAreaLocalSpaceRect(layoutTransformData.Transform, size1);
      size1.Width = Math.Max(minMax.minWidth, Math.Min(size1.Width, minMax.maxWidth));
      size1.Height = Math.Max(minMax.minHeight, Math.Min(size1.Height, minMax.maxHeight));
      if (useLayoutRounding)
        size1 = UIElement.RoundLayoutSize(size1, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
      Size size2 = this.MeasureOverride(size1);
      size2 = new Size(Math.Max(size2.Width, minMax.minWidth), Math.Max(size2.Height, minMax.minHeight));
      Size size3 = size2;
      if (layoutTransformData != null)
      {
        layoutTransformData.UntransformedDS = size3;
        Rect rect = Rect.Transform(new Rect(0.0, 0.0, size3.Width, size3.Height), layoutTransformData.Transform.Value);
        size3.Width = rect.Width;
        size3.Height = rect.Height;
      }
      bool flag = false;
      if (size2.Width > minMax.maxWidth)
      {
        size2.Width = minMax.maxWidth;
        flag = true;
      }
      if (size2.Height > minMax.maxHeight)
      {
        size2.Height = minMax.maxHeight;
        flag = true;
      }
      if (layoutTransformData != null)
      {
        Rect rect = Rect.Transform(new Rect(0.0, 0.0, size2.Width, size2.Height), layoutTransformData.Transform.Value);
        size2.Width = rect.Width;
        size2.Height = rect.Height;
      }
      double val2_1 = size2.Width + num1;
      double val2_2 = size2.Height + num2;
      if (val2_1 > availableSize.Width)
      {
        val2_1 = availableSize.Width;
        flag = true;
      }
      if (val2_2 > availableSize.Height)
      {
        val2_2 = availableSize.Height;
        flag = true;
      }
      if (layoutTransformData != null)
        layoutTransformData.TransformedUnroundedDS = new Size(Math.Max(0.0, val2_1), Math.Max(0.0, val2_2));
      if (useLayoutRounding)
      {
        val2_1 = UIElement.RoundLayoutValue(val2_1, FrameworkElement.DpiScaleX);
        val2_2 = UIElement.RoundLayoutValue(val2_2, FrameworkElement.DpiScaleY);
      }
      SizeBox sizeBox1 = FrameworkElement.UnclippedDesiredSizeField.GetValue((DependencyObject) this);
      if (flag || val2_1 < 0.0 || val2_2 < 0.0)
      {
        if (sizeBox1 == null)
        {
          SizeBox sizeBox2 = new SizeBox(size3);
          FrameworkElement.UnclippedDesiredSizeField.SetValue((DependencyObject) this, sizeBox2);
        }
        else
        {
          sizeBox1.Width = size3.Width;
          sizeBox1.Height = size3.Height;
        }
      }
      else if (sizeBox1 != null)
        FrameworkElement.UnclippedDesiredSizeField.ClearValue((DependencyObject) this);
      return new Size(Math.Max(0.0, val2_1), Math.Max(0.0, val2_2));
    }

    protected override sealed void ArrangeCore(Rect finalRect)
    {
      bool useLayoutRounding = this.UseLayoutRounding;
      FrameworkElement.LayoutTransformData layoutTransformData = FrameworkElement.LayoutTransformDataField.GetValue((DependencyObject) this);
      Size size1 = Size.Empty;
      if (useLayoutRounding && !this.CheckFlagsAnd(VisualFlags.UseLayoutRounding))
        this.SetFlags(true, VisualFlags.UseLayoutRounding);
      if (this.BypassLayoutPolicies)
      {
        Size renderSize = this.RenderSize;
        this.RenderSize = this.ArrangeOverride(finalRect.Size);
        this.SetLayoutOffset(new Vector(finalRect.X, finalRect.Y), renderSize);
      }
      else
      {
        this.NeedsClipBounds = false;
        Size size2 = finalRect.Size;
        Thickness margin = this.Margin;
        double num1 = margin.Left + margin.Right;
        double num2 = margin.Top + margin.Bottom;
        size2.Width = Math.Max(0.0, size2.Width - num1);
        size2.Height = Math.Max(0.0, size2.Height - num2);
        if (useLayoutRounding && layoutTransformData != null)
        {
          Size size3 = layoutTransformData.TransformedUnroundedDS;
          size1 = layoutTransformData.TransformedUnroundedDS;
          size1.Width = Math.Max(0.0, size1.Width - num1);
          size1.Height = Math.Max(0.0, size1.Height - num2);
        }
        SizeBox sizeBox = FrameworkElement.UnclippedDesiredSizeField.GetValue((DependencyObject) this);
        Size size4;
        if (sizeBox == null)
        {
          size4 = new Size(Math.Max(0.0, this.DesiredSize.Width - num1), Math.Max(0.0, this.DesiredSize.Height - num2));
          if (size1 != Size.Empty)
          {
            size4.Width = Math.Max(size1.Width, size4.Width);
            size4.Height = Math.Max(size1.Height, size4.Height);
          }
        }
        else
          size4 = new Size(sizeBox.Width, sizeBox.Height);
        if (DoubleUtil.LessThan(size2.Width, size4.Width))
        {
          this.NeedsClipBounds = true;
          size2.Width = size4.Width;
        }
        if (DoubleUtil.LessThan(size2.Height, size4.Height))
        {
          this.NeedsClipBounds = true;
          size2.Height = size4.Height;
        }
        if (this.HorizontalAlignment != HorizontalAlignment.Stretch)
          size2.Width = size4.Width;
        if (this.VerticalAlignment != VerticalAlignment.Stretch)
          size2.Height = size4.Height;
        if (layoutTransformData != null)
        {
          Size areaLocalSpaceRect = this.FindMaximalAreaLocalSpaceRect(layoutTransformData.Transform, size2);
          size2 = areaLocalSpaceRect;
          size4 = layoutTransformData.UntransformedDS;
          if (!DoubleUtil.IsZero(areaLocalSpaceRect.Width) && !DoubleUtil.IsZero(areaLocalSpaceRect.Height) && (LayoutDoubleUtil.LessThan(areaLocalSpaceRect.Width, size4.Width) || LayoutDoubleUtil.LessThan(areaLocalSpaceRect.Height, size4.Height)))
            size2 = size4;
          if (DoubleUtil.LessThan(size2.Width, size4.Width))
          {
            this.NeedsClipBounds = true;
            size2.Width = size4.Width;
          }
          if (DoubleUtil.LessThan(size2.Height, size4.Height))
          {
            this.NeedsClipBounds = true;
            size2.Height = size4.Height;
          }
        }
        FrameworkElement.MinMax minMax = new FrameworkElement.MinMax(this);
        double num3 = Math.Max(size4.Width, minMax.maxWidth);
        if (DoubleUtil.LessThan(num3, size2.Width))
        {
          this.NeedsClipBounds = true;
          size2.Width = num3;
        }
        double num4 = Math.Max(size4.Height, minMax.maxHeight);
        if (DoubleUtil.LessThan(num4, size2.Height))
        {
          this.NeedsClipBounds = true;
          size2.Height = num4;
        }
        if (useLayoutRounding)
          size2 = UIElement.RoundLayoutSize(size2, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
        Size renderSize = this.RenderSize;
        Size size5 = this.ArrangeOverride(size2);
        this.RenderSize = size5;
        if (useLayoutRounding)
          this.RenderSize = UIElement.RoundLayoutSize(this.RenderSize, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
        Size size6 = new Size(Math.Min(size5.Width, minMax.maxWidth), Math.Min(size5.Height, minMax.maxHeight));
        if (useLayoutRounding)
          size6 = UIElement.RoundLayoutSize(size6, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
        FrameworkElement frameworkElement1 = this;
        int num5 = (frameworkElement1.NeedsClipBounds ? 1 : 0) | (DoubleUtil.LessThan(size6.Width, size5.Width) ? 1 : (DoubleUtil.LessThan(size6.Height, size5.Height) ? 1 : 0));
        frameworkElement1.NeedsClipBounds = num5 != 0;
        if (layoutTransformData != null)
        {
          Rect rect = Rect.Transform(new Rect(0.0, 0.0, size6.Width, size6.Height), layoutTransformData.Transform.Value);
          size6.Width = rect.Width;
          size6.Height = rect.Height;
          if (useLayoutRounding)
            size6 = UIElement.RoundLayoutSize(size6, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
        }
        Size size7 = new Size(Math.Max(0.0, finalRect.Width - num1), Math.Max(0.0, finalRect.Height - num2));
        if (useLayoutRounding)
          size7 = UIElement.RoundLayoutSize(size7, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
        FrameworkElement frameworkElement2 = this;
        int num6 = (frameworkElement2.NeedsClipBounds ? 1 : 0) | (DoubleUtil.LessThan(size7.Width, size6.Width) ? 1 : (DoubleUtil.LessThan(size7.Height, size6.Height) ? 1 : 0));
        frameworkElement2.NeedsClipBounds = num6 != 0;
        Vector alignmentOffset = this.ComputeAlignmentOffset(size7, size6);
        alignmentOffset.X += finalRect.X + margin.Left;
        alignmentOffset.Y += finalRect.Y + margin.Top;
        if (useLayoutRounding)
        {
          alignmentOffset.X = UIElement.RoundLayoutValue(alignmentOffset.X, FrameworkElement.DpiScaleX);
          alignmentOffset.Y = UIElement.RoundLayoutValue(alignmentOffset.Y, FrameworkElement.DpiScaleY);
        }
        this.SetLayoutOffset(alignmentOffset, renderSize);
      }
    }

    protected internal override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
      SizeChangedEventArgs changedEventArgs = new SizeChangedEventArgs((UIElement) this, sizeInfo);
      changedEventArgs.RoutedEvent = FrameworkElement.SizeChangedEvent;
      if (sizeInfo.WidthChanged)
      {
        this.HasWidthEverChanged = true;
        this.NotifyPropertyChange(new DependencyPropertyChangedEventArgs(FrameworkElement.ActualWidthProperty, FrameworkElement._actualWidthMetadata, (object) sizeInfo.PreviousSize.Width, (object) sizeInfo.NewSize.Width));
      }
      if (sizeInfo.HeightChanged)
      {
        this.HasHeightEverChanged = true;
        this.NotifyPropertyChange(new DependencyPropertyChangedEventArgs(FrameworkElement.ActualHeightProperty, FrameworkElement._actualHeightMetadata, (object) sizeInfo.PreviousSize.Height, (object) sizeInfo.NewSize.Height));
      }
      this.RaiseEvent((RoutedEventArgs) changedEventArgs);
    }

    protected override Geometry GetLayoutClip(Size layoutSlotSize)
    {
      bool useLayoutRounding = this.UseLayoutRounding;
      if (useLayoutRounding && !this.CheckFlagsAnd(VisualFlags.UseLayoutRounding))
        this.SetFlags(true, VisualFlags.UseLayoutRounding);
      if (!this.NeedsClipBounds && !this.ClipToBounds)
        return base.GetLayoutClip(layoutSlotSize);
      FrameworkElement.MinMax minMax = new FrameworkElement.MinMax(this);
      Size renderSize = this.RenderSize;
      double width = double.IsPositiveInfinity(minMax.maxWidth) ? renderSize.Width : minMax.maxWidth;
      double height = double.IsPositiveInfinity(minMax.maxHeight) ? renderSize.Height : minMax.maxHeight;
      bool flag1 = this.ClipToBounds || (DoubleUtil.LessThan(width, renderSize.Width) || DoubleUtil.LessThan(height, renderSize.Height));
      renderSize.Width = Math.Min(renderSize.Width, minMax.maxWidth);
      renderSize.Height = Math.Min(renderSize.Height, minMax.maxHeight);
      FrameworkElement.LayoutTransformData layoutTransformData = FrameworkElement.LayoutTransformDataField.GetValue((DependencyObject) this);
      Rect rect1 = new Rect();
      if (layoutTransformData != null)
      {
        rect1 = Rect.Transform(new Rect(0.0, 0.0, renderSize.Width, renderSize.Height), layoutTransformData.Transform.Value);
        renderSize.Width = rect1.Width;
        renderSize.Height = rect1.Height;
      }
      Thickness margin = this.Margin;
      double num1 = margin.Left + margin.Right;
      double num2 = margin.Top + margin.Bottom;
      Size clientSize = new Size(Math.Max(0.0, layoutSlotSize.Width - num1), Math.Max(0.0, layoutSlotSize.Height - num2));
      bool flag2 = this.ClipToBounds || DoubleUtil.LessThan(clientSize.Width, renderSize.Width) || DoubleUtil.LessThan(clientSize.Height, renderSize.Height);
      Transform directionTransform = this.GetFlowDirectionTransform();
      if (flag1 && !flag2)
      {
        Rect rect2 = new Rect(0.0, 0.0, width, height);
        if (useLayoutRounding)
          rect2 = UIElement.RoundLayoutRect(rect2, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
        RectangleGeometry rectangleGeometry = new RectangleGeometry(rect2);
        if (directionTransform != null)
          rectangleGeometry.Transform = directionTransform;
        return (Geometry) rectangleGeometry;
      }
      else
      {
        if (!flag2)
          return (Geometry) null;
        Vector alignmentOffset = this.ComputeAlignmentOffset(clientSize, renderSize);
        if (layoutTransformData != null)
        {
          Rect rect2 = new Rect(-alignmentOffset.X + rect1.X, -alignmentOffset.Y + rect1.Y, clientSize.Width, clientSize.Height);
          if (useLayoutRounding)
            rect2 = UIElement.RoundLayoutRect(rect2, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
          RectangleGeometry rectangleGeometry = new RectangleGeometry(rect2);
          Matrix matrix = layoutTransformData.Transform.Value;
          if (matrix.HasInverse)
          {
            matrix.Invert();
            rectangleGeometry.Transform = (Transform) new MatrixTransform(matrix);
          }
          if (flag1)
          {
            Rect rect3 = new Rect(0.0, 0.0, width, height);
            if (useLayoutRounding)
              rect3 = UIElement.RoundLayoutRect(rect3, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
            PathGeometry pathGeometry = Geometry.Combine((Geometry) new RectangleGeometry(rect3), (Geometry) rectangleGeometry, GeometryCombineMode.Intersect, (Transform) null);
            if (directionTransform != null)
              pathGeometry.Transform = directionTransform;
            return (Geometry) pathGeometry;
          }
          else
          {
            if (directionTransform != null)
            {
              if (rectangleGeometry.Transform != null)
                rectangleGeometry.Transform = (Transform) new MatrixTransform(rectangleGeometry.Transform.Value * directionTransform.Value);
              else
                rectangleGeometry.Transform = directionTransform;
            }
            return (Geometry) rectangleGeometry;
          }
        }
        else
        {
          Rect rect2 = new Rect(-alignmentOffset.X + rect1.X, -alignmentOffset.Y + rect1.Y, clientSize.Width, clientSize.Height);
          if (useLayoutRounding)
            rect2 = UIElement.RoundLayoutRect(rect2, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
          if (flag1)
          {
            Rect rect3 = new Rect(0.0, 0.0, width, height);
            if (useLayoutRounding)
              rect3 = UIElement.RoundLayoutRect(rect3, FrameworkElement.DpiScaleX, FrameworkElement.DpiScaleY);
            rect2.Intersect(rect3);
          }
          RectangleGeometry rectangleGeometry = new RectangleGeometry(rect2);
          if (directionTransform != null)
            rectangleGeometry.Transform = directionTransform;
          return (Geometry) rectangleGeometry;
        }
      }
    }

    internal Geometry GetLayoutClipInternal()
    {
      if (this.IsMeasureValid && this.IsArrangeValid)
        return this.GetLayoutClip(this.PreviousArrangeRect.Size);
      else
        return (Geometry) null;
    }

    protected virtual Size MeasureOverride(Size availableSize)
    {
      return new Size(0.0, 0.0);
    }

    protected virtual Size ArrangeOverride(Size finalSize)
    {
      return finalSize;
    }

    internal static void InternalSetLayoutTransform(UIElement element, Transform layoutTransform)
    {
      FrameworkElement frameworkElement = element as FrameworkElement;
      element.InternalSetOffsetWorkaround(new Vector());
      Transform transform1 = frameworkElement == null ? (Transform) null : frameworkElement.GetFlowDirectionTransform();
      Transform transform2 = element.RenderTransform;
      if (transform2 == Transform.Identity)
        transform2 = (Transform) null;
      TransformCollection transformCollection = new TransformCollection();
      transformCollection.CanBeInheritanceContext = false;
      if (transform1 != null)
        transformCollection.Add(transform1);
      if (transform2 != null)
        transformCollection.Add(transform2);
      transformCollection.Add(layoutTransform);
      element.InternalSetTransformWorkaround((Transform) new TransformGroup()
      {
        Children = transformCollection
      });
    }

    public override sealed bool MoveFocus(TraversalRequest request)
    {
      if (request == null)
        throw new ArgumentNullException("request");
      else
        return KeyboardNavigation.Current.Navigate((DependencyObject) this, request);
    }

    public override sealed DependencyObject PredictFocus(FocusNavigationDirection direction)
    {
      return KeyboardNavigation.Current.PredictFocusedElement((DependencyObject) this, direction);
    }

    protected override void OnGotFocus(RoutedEventArgs e)
    {
      if (this.IsKeyboardFocused)
        this.BringIntoView();
      base.OnGotFocus(e);
    }

    public virtual void BeginInit()
    {
      if (this.ReadInternalFlag(InternalFlags.InitPending))
        throw new InvalidOperationException(System.Windows.SR.Get("NestedBeginInitNotSupported"));
      this.WriteInternalFlag(InternalFlags.InitPending, true);
    }

    public virtual void EndInit()
    {
      if (!this.ReadInternalFlag(InternalFlags.InitPending))
        throw new InvalidOperationException(System.Windows.SR.Get("EndInitWithoutBeginInitNotSupported"));
      this.WriteInternalFlag(InternalFlags.InitPending, false);
      this.TryFireInitialized();
    }

    protected virtual void OnInitialized(EventArgs e)
    {
      if (!this.HasStyleEverBeenFetched)
        this.UpdateStyleProperty();
      if (!this.HasThemeStyleEverBeenFetched)
        this.UpdateThemeStyleProperty();
      this.RaiseInitialized(FrameworkElement.InitializedKey, e);
    }

    internal override sealed void OnPresentationSourceChanged(bool attached)
    {
      base.OnPresentationSourceChanged(attached);
      if (attached)
      {
        this.FireLoadedOnDescendentsInternal();
        if (!SystemResources.SystemResourcesHaveChanged)
          return;
        this.WriteInternalFlag(InternalFlags.CreatingRoot, true);
        this.CoerceValue(TextElement.FontFamilyProperty);
        this.CoerceValue(TextElement.FontSizeProperty);
        this.CoerceValue(TextElement.FontStyleProperty);
        this.CoerceValue(TextElement.FontWeightProperty);
        this.WriteInternalFlag(InternalFlags.CreatingRoot, false);
      }
      else
        this.FireUnloadedOnDescendentsInternal();
    }

    internal override void OnAddHandler(RoutedEvent routedEvent, Delegate handler)
    {
      base.OnAddHandler(routedEvent, handler);
      if (routedEvent != FrameworkElement.LoadedEvent && routedEvent != FrameworkElement.UnloadedEvent)
        return;
      BroadcastEventHelper.AddHasLoadedChangeHandlerFlagInAncestry((DependencyObject) this);
    }

    internal override void OnRemoveHandler(RoutedEvent routedEvent, Delegate handler)
    {
      base.OnRemoveHandler(routedEvent, handler);
      if (routedEvent != FrameworkElement.LoadedEvent && routedEvent != FrameworkElement.UnloadedEvent || this.ThisHasLoadedChangeEventHandler)
        return;
      BroadcastEventHelper.RemoveHasLoadedChangeHandlerFlagInAncestry((DependencyObject) this);
    }

    internal void OnLoaded(RoutedEventArgs args)
    {
      this.RaiseEvent(args);
    }

    internal void OnUnloaded(RoutedEventArgs args)
    {
      this.RaiseEvent(args);
    }

    internal override void AddSynchronizedInputPreOpportunityHandlerCore(EventRoute route, RoutedEventArgs args)
    {
      UIElement uiElement = this._templatedParent as UIElement;
      if (uiElement == null)
        return;
      uiElement.AddSynchronizedInputPreOpportunityHandler(route, args);
    }

    internal void RaiseClrEvent(EventPrivateKey key, EventArgs args)
    {
      EventHandlersStore eventHandlersStore = this.EventHandlersStore;
      if (eventHandlersStore == null)
        return;
      Delegate @delegate = eventHandlersStore.Get(key);
      if (@delegate == null)
        return;
      ((EventHandler) @delegate)((object) this, args);
    }

    protected virtual void OnToolTipOpening(ToolTipEventArgs e)
    {
    }

    protected virtual void OnToolTipClosing(ToolTipEventArgs e)
    {
    }

    protected virtual void OnContextMenuOpening(ContextMenuEventArgs e)
    {
    }

    protected virtual void OnContextMenuClosing(ContextMenuEventArgs e)
    {
    }

    internal static void AddIntermediateElementsToRoute(DependencyObject mergePoint, EventRoute route, RoutedEventArgs args, DependencyObject modelTreeNode)
    {
      for (; modelTreeNode != null && modelTreeNode != mergePoint; modelTreeNode = LogicalTreeHelper.GetParent(modelTreeNode))
      {
        UIElement uiElement = modelTreeNode as UIElement;
        ContentElement contentElement = modelTreeNode as ContentElement;
        UIElement3D uiElement3D = modelTreeNode as UIElement3D;
        if (uiElement != null)
        {
          uiElement.AddToEventRoute(route, args);
          FrameworkElement fe = uiElement as FrameworkElement;
          if (fe != null)
            FrameworkElement.AddStyleHandlersToEventRoute(fe, (FrameworkContentElement) null, route, args);
        }
        else if (contentElement != null)
        {
          contentElement.AddToEventRoute(route, args);
          FrameworkContentElement fce = contentElement as FrameworkContentElement;
          if (fce != null)
            FrameworkElement.AddStyleHandlersToEventRoute((FrameworkElement) null, fce, route, args);
        }
        else if (uiElement3D != null)
          uiElement3D.AddToEventRoute(route, args);
      }
    }

    internal void EventHandlersStoreAdd(EventPrivateKey key, Delegate handler)
    {
      this.EnsureEventHandlersStore();
      this.EventHandlersStore.Add(key, handler);
    }

    internal void EventHandlersStoreRemove(EventPrivateKey key, Delegate handler)
    {
      EventHandlersStore eventHandlersStore = this.EventHandlersStore;
      if (eventHandlersStore == null)
        return;
      eventHandlersStore.Remove(key, handler);
    }

    internal bool ReadInternalFlag(InternalFlags reqFlag)
    {
      return (this._flags & reqFlag) != (InternalFlags) 0;
    }

    internal bool ReadInternalFlag2(InternalFlags2 reqFlag)
    {
      return (this._flags2 & reqFlag) != (InternalFlags2) 0;
    }

    internal void WriteInternalFlag(InternalFlags reqFlag, bool set)
    {
      if (set)
        this._flags |= reqFlag;
      else
        this._flags &= ~reqFlag;
    }

    internal void WriteInternalFlag2(InternalFlags2 reqFlag, bool set)
    {
      if (set)
        this._flags2 |= reqFlag;
      else
        this._flags2 &= ~reqFlag;
    }

    public void RegisterName(string name, object scopedElement)
    {
      INameScope scope = FrameworkElement.FindScope((DependencyObject) this);
      if (scope != null)
        scope.RegisterName(name, scopedElement);
      else
        throw new InvalidOperationException(System.Windows.SR.Get("NameScopeNotFound", (object) name, (object) "register"));
    }

    public void UnregisterName(string name)
    {
      INameScope scope = FrameworkElement.FindScope((DependencyObject) this);
      if (scope != null)
        scope.UnregisterName(name);
      else
        throw new InvalidOperationException(System.Windows.SR.Get("NameScopeNotFound", (object) name, (object) "unregister"));
    }

    public object FindName(string name)
    {
      DependencyObject scopeOwner;
      return this.FindName(name, out scopeOwner);
    }

    internal object FindName(string name, out DependencyObject scopeOwner)
    {
      INameScope scope = FrameworkElement.FindScope((DependencyObject) this, out scopeOwner);
      if (scope != null)
        return scope.FindName(name);
      else
        return (object) null;
    }

    internal object FindResourceOnSelf(object resourceKey, bool allowDeferredResourceReference, bool mustReturnDeferredResourceReference)
    {
      ResourceDictionary resourceDictionary = FrameworkElement.ResourcesField.GetValue((DependencyObject) this);
      if (resourceDictionary != null && resourceDictionary.Contains(resourceKey))
      {
        bool canCache;
        return resourceDictionary.FetchResource(resourceKey, allowDeferredResourceReference, mustReturnDeferredResourceReference, out canCache);
      }
      else
        return DependencyProperty.UnsetValue;
    }

    internal DependencyObject ContextVerifiedGetParent()
    {
      return this._parent;
    }

    protected internal void AddLogicalChild(object child)
    {
      if (child == null)
        return;
      if (this.IsLogicalChildrenIterationInProgress)
        throw new InvalidOperationException(System.Windows.SR.Get("CannotModifyLogicalChildrenDuringTreeWalk"));
      this.TryFireInitialized();
      bool flag = true;
      try
      {
        this.HasLogicalChildren = true;
        new FrameworkObject(child as DependencyObject).ChangeLogicalParent((DependencyObject) this);
        flag = false;
      }
      finally
      {
        int num = flag ? 1 : 0;
      }
    }

    protected internal void RemoveLogicalChild(object child)
    {
      if (child == null)
        return;
      if (this.IsLogicalChildrenIterationInProgress)
        throw new InvalidOperationException(System.Windows.SR.Get("CannotModifyLogicalChildrenDuringTreeWalk"));
      FrameworkObject frameworkObject = new FrameworkObject(child as DependencyObject);
      if (frameworkObject.Parent == this)
        frameworkObject.ChangeLogicalParent((DependencyObject) null);
      IEnumerator logicalChildren = this.LogicalChildren;
      if (logicalChildren == null)
        this.HasLogicalChildren = false;
      else
        this.HasLogicalChildren = logicalChildren.MoveNext();
    }

    internal void ChangeLogicalParent(DependencyObject newParent)
    {
      this.VerifyAccess();
      if (newParent != null)
        newParent.VerifyAccess();
      if (this._parent != null && newParent != null && this._parent != newParent)
        throw new InvalidOperationException(System.Windows.SR.Get("HasLogicalParent"));
      if (newParent == this)
        throw new InvalidOperationException(System.Windows.SR.Get("CannotBeSelfParent"));
      if (newParent != null)
        this.ClearInheritanceContext();
      this.IsParentAnFE = newParent is FrameworkElement;
      DependencyObject oldParent = this._parent;
      this.OnNewParent(newParent);
      BroadcastEventHelper.AddOrRemoveHasLoadedChangeHandlerFlag((DependencyObject) this, oldParent, newParent);
      TreeWalkHelper.InvalidateOnTreeChange(this, (FrameworkContentElement) null, newParent != null ? newParent : oldParent, newParent != null);
      this.TryFireInitialized();
    }

    internal virtual void OnNewParent(DependencyObject newParent)
    {
      DependencyObject dependencyObject = this._parent;
      this._parent = newParent;
      if (this._parent != null && this._parent is ContentElement)
        UIElement.SynchronizeForceInheritProperties((UIElement) this, (ContentElement) null, (UIElement3D) null, this._parent);
      else if (dependencyObject is ContentElement)
        UIElement.SynchronizeForceInheritProperties((UIElement) this, (ContentElement) null, (UIElement3D) null, dependencyObject);
      this.SynchronizeReverseInheritPropertyFlags(dependencyObject, false);
    }

    [SecurityCritical]
    [SecurityTreatAsSafe]
    internal void OnAncestorChangedInternal(TreeChangeInfo parentTreeState)
    {
      bool inheritanceParent = this.IsSelfInheritanceParent;
      if (parentTreeState.Root != this)
      {
        this.HasStyleChanged = false;
        this.HasStyleInvalidated = false;
        this.HasTemplateChanged = false;
      }
      if (parentTreeState.IsAddOperation)
        new FrameworkObject(this, (FrameworkContentElement) null).SetShouldLookupImplicitStyles();
      if (this.HasResourceReference)
        TreeWalkHelper.OnResourcesChanged((DependencyObject) this, ResourcesChangeInfo.TreeChangeInfo, false);
      FrugalObjectList<DependencyProperty> frugalObjectList = this.InvalidateTreeDependentProperties(parentTreeState, inheritanceParent);
      parentTreeState.InheritablePropertiesStack.Push(frugalObjectList);
      this.OnAncestorChanged();
      if (!this.PotentiallyHasMentees)
        return;
      this.RaiseClrEvent(FrameworkElement.ResourcesChangedKey, EventArgs.Empty);
    }

    internal FrugalObjectList<DependencyProperty> InvalidateTreeDependentProperties(TreeChangeInfo parentTreeState, bool isSelfInheritanceParent)
    {
      this.AncestorChangeInProgress = true;
      this.InVisibilityCollapsedTree = false;
      if (parentTreeState.TopmostCollapsedParentNode == null)
      {
        if (this.Visibility == Visibility.Collapsed)
        {
          parentTreeState.TopmostCollapsedParentNode = (object) this;
          this.InVisibilityCollapsedTree = true;
        }
      }
      else
        this.InVisibilityCollapsedTree = true;
      try
      {
        if (this.IsInitialized && !this.HasLocalStyle && this != parentTreeState.Root)
          this.UpdateStyleProperty();
        ChildRecord childRecord = new ChildRecord();
        bool isChildRecordValid = false;
        Style style = this.Style;
        Style themeStyle = this.ThemeStyle;
        DependencyObject templatedParent = this.TemplatedParent;
        int templateChildIndex = this.TemplateChildIndex;
        bool hasStyleChanged = this.HasStyleChanged;
        FrameworkElement.GetTemplatedParentChildRecord(templatedParent, templateChildIndex, out childRecord, out isChildRecordValid);
        FrameworkElement feParent;
        FrameworkContentElement fceParent;
        bool frameworkParent = FrameworkElement.GetFrameworkParent(this, out feParent, out fceParent);
        DependencyObject parent = (DependencyObject) null;
        InheritanceBehavior inheritanceBehavior = InheritanceBehavior.Default;
        if (frameworkParent)
        {
          if (feParent != null)
          {
            parent = (DependencyObject) feParent;
            inheritanceBehavior = feParent.InheritanceBehavior;
          }
          else
          {
            parent = (DependencyObject) fceParent;
            inheritanceBehavior = fceParent.InheritanceBehavior;
          }
        }
        if (!TreeWalkHelper.SkipNext(this.InheritanceBehavior) && !TreeWalkHelper.SkipNow(inheritanceBehavior))
          this.SynchronizeInheritanceParent(parent);
        else if (!this.IsSelfInheritanceParent)
          this.SetIsSelfInheritanceParent();
        return TreeWalkHelper.InvalidateTreeDependentProperties(parentTreeState, this, (FrameworkContentElement) null, style, themeStyle, ref childRecord, isChildRecordValid, hasStyleChanged, isSelfInheritanceParent);
      }
      finally
      {
        this.AncestorChangeInProgress = false;
        this.InVisibilityCollapsedTree = false;
      }
    }

    internal void UpdateStyleProperty()
    {
      if (this.HasStyleInvalidated)
        return;
      if (!this.IsStyleUpdateInProgress)
      {
        this.IsStyleUpdateInProgress = true;
        try
        {
          this.InvalidateProperty(FrameworkElement.StyleProperty);
          this.HasStyleInvalidated = true;
        }
        finally
        {
          this.IsStyleUpdateInProgress = false;
        }
      }
      else
        throw new InvalidOperationException(System.Windows.SR.Get("CyclicStyleReferenceDetected", new object[1]
        {
          (object) this
        }));
    }

    internal void UpdateThemeStyleProperty()
    {
      if (!this.IsThemeStyleUpdateInProgress)
      {
        this.IsThemeStyleUpdateInProgress = true;
        try
        {
          StyleHelper.GetThemeStyle(this, (FrameworkContentElement) null);
          ContextMenu contextMenu = this.GetValueEntry(this.LookupEntry(FrameworkElement.ContextMenuProperty.GlobalIndex), FrameworkElement.ContextMenuProperty, (PropertyMetadata) null, RequestFlags.DeferredReferences).Value as ContextMenu;
          if (contextMenu != null)
            TreeWalkHelper.InvalidateOnResourcesChange((FrameworkElement) contextMenu, (FrameworkContentElement) null, ResourcesChangeInfo.ThemeChangeInfo);
          DependencyObject d = this.GetValueEntry(this.LookupEntry(FrameworkElement.ToolTipProperty.GlobalIndex), FrameworkElement.ToolTipProperty, (PropertyMetadata) null, RequestFlags.DeferredReferences).Value as DependencyObject;
          if (d != null)
          {
            FrameworkObject frameworkObject = new FrameworkObject(d);
            if (frameworkObject.IsValid)
              TreeWalkHelper.InvalidateOnResourcesChange(frameworkObject.FE, frameworkObject.FCE, ResourcesChangeInfo.ThemeChangeInfo);
          }
          this.OnThemeChanged();
        }
        finally
        {
          this.IsThemeStyleUpdateInProgress = false;
        }
      }
      else
        throw new InvalidOperationException(System.Windows.SR.Get("CyclicThemeStyleReferenceDetected", new object[1]
        {
          (object) this
        }));
    }

    internal virtual void OnThemeChanged()
    {
    }

    internal void FireLoadedOnDescendentsInternal()
    {
      if (this.LoadedPending != null)
        return;
      DependencyObject logicalParent = this.Parent ?? VisualTreeHelper.GetParent((DependencyObject) this);
      object[] unloadedPending = this.UnloadedPending;
      if (unloadedPending == null || unloadedPending[2] != logicalParent)
        BroadcastEventHelper.AddLoadedCallback((DependencyObject) this, logicalParent);
      else
        BroadcastEventHelper.RemoveUnloadedCallback((DependencyObject) this, unloadedPending);
    }

    internal void FireUnloadedOnDescendentsInternal()
    {
      if (this.UnloadedPending != null)
        return;
      DependencyObject logicalParent = this.Parent ?? VisualTreeHelper.GetParent((DependencyObject) this);
      object[] loadedPending = this.LoadedPending;
      if (loadedPending == null)
        BroadcastEventHelper.AddUnloadedCallback((DependencyObject) this, logicalParent);
      else
        BroadcastEventHelper.RemoveLoadedCallback((DependencyObject) this, loadedPending);
    }

    internal override bool ShouldProvideInheritanceContext(DependencyObject target, DependencyProperty property)
    {
      return !new FrameworkObject(target).IsValid;
    }

    internal override void AddInheritanceContext(DependencyObject context, DependencyProperty property)
    {
      base.AddInheritanceContext(context, property);
      this.TryFireInitialized();
      if (property != VisualBrush.VisualProperty && property != BitmapCacheBrush.TargetProperty || (FrameworkElement.GetFrameworkParent((object) this) != null || FrameworkObject.IsEffectiveAncestor((DependencyObject) this, context)))
        return;
      if (!this.HasMultipleInheritanceContexts && this.InheritanceContext == null)
      {
        FrameworkElement.InheritanceContextField.SetValue((DependencyObject) this, context);
        this.OnInheritanceContextChanged(EventArgs.Empty);
      }
      else
      {
        if (this.InheritanceContext == null)
          return;
        FrameworkElement.InheritanceContextField.ClearValue((DependencyObject) this);
        this.WriteInternalFlag2(InternalFlags2.HasMultipleInheritanceContexts, true);
        this.OnInheritanceContextChanged(EventArgs.Empty);
      }
    }

    internal override void RemoveInheritanceContext(DependencyObject context, DependencyProperty property)
    {
      if (this.InheritanceContext == context)
      {
        FrameworkElement.InheritanceContextField.ClearValue((DependencyObject) this);
        this.OnInheritanceContextChanged(EventArgs.Empty);
      }
      base.RemoveInheritanceContext(context, property);
    }

    internal override void OnInheritanceContextChangedCore(EventArgs args)
    {
      DependencyObject mentor1 = FrameworkElement.MentorField.GetValue((DependencyObject) this);
      DependencyObject mentor2 = MS.Internal.Helper.FindMentor(this.InheritanceContext);
      if (mentor1 == mentor2)
        return;
      FrameworkElement.MentorField.SetValue((DependencyObject) this, mentor2);
      if (mentor1 != null)
        this.DisconnectMentor(mentor1);
      if (mentor2 == null)
        return;
      this.ConnectMentor(mentor2);
    }

    internal void ChangeSubtreeHasLoadedChangedHandler(DependencyObject mentor)
    {
      FrameworkObject foMentor = new FrameworkObject(mentor);
      bool isLoaded = foMentor.IsLoaded;
      if (this.SubtreeHasLoadedChangeHandler)
        this.ConnectLoadedEvents(ref foMentor, isLoaded);
      else
        this.DisconnectLoadedEvents(ref foMentor, isLoaded);
    }

    internal void RaiseInheritedPropertyChangedEvent(ref InheritablePropertyChangeInfo info)
    {
      EventHandlersStore eventHandlersStore = this.EventHandlersStore;
      if (eventHandlersStore == null)
        return;
      Delegate @delegate = eventHandlersStore.Get(FrameworkElement.InheritedPropertyChangedKey);
      if (@delegate == null)
        return;
      InheritedPropertyChangedEventArgs e = new InheritedPropertyChangedEventArgs(ref info);
      ((InheritedPropertyChangedEventHandler) @delegate)((object) this, e);
    }

    private static void OnStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      FrameworkElement fe = (FrameworkElement) d;
      fe.HasLocalStyle = e.NewEntry.BaseValueSourceInternal == BaseValueSourceInternal.Local;
      StyleHelper.UpdateStyleCache(fe, (FrameworkContentElement) null, (Style) e.OldValue, (Style) e.NewValue, ref fe._styleCache);
    }

    private static void OnUseLayoutRoundingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((Visual) d).SetFlags((bool) e.NewValue, VisualFlags.UseLayoutRounding);
    }

    private static void OnThemeStyleKeyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((FrameworkElement) d).UpdateThemeStyleProperty();
    }

    private void PrivateInitialized()
    {
      EventTrigger.ProcessTriggerCollection(this);
    }

    private static object FindTemplateResourceInTree(DependencyObject target, ArrayList keys, int exactMatch, ref int bestMatch)
    {
      object obj = (object) null;
      FrameworkObject frameworkObject = new FrameworkObject(target);
      while (frameworkObject.IsValid)
      {
        ResourceDictionary resourceDictionary1 = FrameworkElement.GetInstanceResourceDictionary(frameworkObject.FE, frameworkObject.FCE);
        if (resourceDictionary1 != null)
        {
          object resourceDictionary2 = FrameworkElement.FindBestMatchInResourceDictionary(resourceDictionary1, keys, exactMatch, ref bestMatch);
          if (resourceDictionary2 != null)
          {
            obj = resourceDictionary2;
            if (bestMatch < exactMatch)
              return obj;
          }
        }
        ResourceDictionary resourceDictionary3 = FrameworkElement.GetStyleResourceDictionary(frameworkObject.FE, frameworkObject.FCE);
        if (resourceDictionary3 != null)
        {
          object resourceDictionary2 = FrameworkElement.FindBestMatchInResourceDictionary(resourceDictionary3, keys, exactMatch, ref bestMatch);
          if (resourceDictionary2 != null)
          {
            obj = resourceDictionary2;
            if (bestMatch < exactMatch)
              return obj;
          }
        }
        ResourceDictionary resourceDictionary4 = FrameworkElement.GetThemeStyleResourceDictionary(frameworkObject.FE, frameworkObject.FCE);
        if (resourceDictionary4 != null)
        {
          object resourceDictionary2 = FrameworkElement.FindBestMatchInResourceDictionary(resourceDictionary4, keys, exactMatch, ref bestMatch);
          if (resourceDictionary2 != null)
          {
            obj = resourceDictionary2;
            if (bestMatch < exactMatch)
              return obj;
          }
        }
        ResourceDictionary resourceDictionary5 = FrameworkElement.GetTemplateResourceDictionary(frameworkObject.FE, frameworkObject.FCE);
        if (resourceDictionary5 != null)
        {
          object resourceDictionary2 = FrameworkElement.FindBestMatchInResourceDictionary(resourceDictionary5, keys, exactMatch, ref bestMatch);
          if (resourceDictionary2 != null)
          {
            obj = resourceDictionary2;
            if (bestMatch < exactMatch)
              return obj;
          }
        }
        if (!frameworkObject.IsValid || !TreeWalkHelper.SkipNext(frameworkObject.InheritanceBehavior))
        {
          frameworkObject = frameworkObject.FrameworkParent;
          if (frameworkObject.IsValid && TreeWalkHelper.SkipNext(frameworkObject.InheritanceBehavior))
            break;
        }
        else
          break;
      }
      return obj;
    }

    private static object FindBestMatchInResourceDictionary(ResourceDictionary table, ArrayList keys, int exactMatch, ref int bestMatch)
    {
      object obj1 = (object) null;
      if (table != null)
      {
        for (int index = 0; index < bestMatch; ++index)
        {
          object obj2 = table[keys[index]];
          if (obj2 != null)
          {
            obj1 = obj2;
            bestMatch = index;
            if (bestMatch < exactMatch)
              return obj1;
          }
        }
      }
      return obj1;
    }

    private static ResourceDictionary GetInstanceResourceDictionary(FrameworkElement fe, FrameworkContentElement fce)
    {
      ResourceDictionary resourceDictionary = (ResourceDictionary) null;
      if (fe != null)
      {
        if (fe.HasResources)
          resourceDictionary = fe.Resources;
      }
      else if (fce.HasResources)
        resourceDictionary = fce.Resources;
      return resourceDictionary;
    }

    private static ResourceDictionary GetStyleResourceDictionary(FrameworkElement fe, FrameworkContentElement fce)
    {
      ResourceDictionary resourceDictionary = (ResourceDictionary) null;
      if (fe != null)
      {
        if (fe.Style != null && fe.Style._resources != null)
          resourceDictionary = fe.Style._resources;
      }
      else if (fce.Style != null && fce.Style._resources != null)
        resourceDictionary = fce.Style._resources;
      return resourceDictionary;
    }

    private static ResourceDictionary GetThemeStyleResourceDictionary(FrameworkElement fe, FrameworkContentElement fce)
    {
      ResourceDictionary resourceDictionary = (ResourceDictionary) null;
      if (fe != null)
      {
        if (fe.ThemeStyle != null && fe.ThemeStyle._resources != null)
          resourceDictionary = fe.ThemeStyle._resources;
      }
      else if (fce.ThemeStyle != null && fce.ThemeStyle._resources != null)
        resourceDictionary = fce.ThemeStyle._resources;
      return resourceDictionary;
    }

    private static ResourceDictionary GetTemplateResourceDictionary(FrameworkElement fe, FrameworkContentElement fce)
    {
      ResourceDictionary resourceDictionary = (ResourceDictionary) null;
      if (fe != null && fe.TemplateInternal != null && fe.TemplateInternal._resources != null)
        resourceDictionary = fe.TemplateInternal._resources;
      return resourceDictionary;
    }

    private bool GetValueFromTemplatedParent(DependencyProperty dp, ref EffectiveValueEntry entry)
    {
      FrameworkTemplate templateInternal = ((FrameworkElement) this._templatedParent).TemplateInternal;
      if (templateInternal != null)
        return StyleHelper.GetValueFromTemplatedParent(this._templatedParent, this.TemplateChildIndex, new FrameworkObject(this, (FrameworkContentElement) null), dp, ref templateInternal.ChildRecordFromChildIndex, templateInternal.VisualTree, ref entry);
      else
        return false;
    }

    private object GetInheritableValue(DependencyProperty dp, FrameworkPropertyMetadata fmetadata)
    {
      if (!TreeWalkHelper.SkipNext(this.InheritanceBehavior) || fmetadata.OverridesInheritanceBehavior)
      {
        InheritanceBehavior inheritanceBehavior = InheritanceBehavior.Default;
        for ({
          FrameworkElement feParent;
          FrameworkContentElement fceParent;
          bool flag = FrameworkElement.GetFrameworkParent(this, out feParent, out fceParent);
        }
        ; flag; flag = feParent == null ? FrameworkElement.GetFrameworkParent(fceParent, out feParent, out fceParent) : FrameworkElement.GetFrameworkParent(feParent, out feParent, out fceParent))
        {
          bool flag = feParent == null ? TreeWalkHelper.IsInheritanceNode(fceParent, dp, out inheritanceBehavior) : TreeWalkHelper.IsInheritanceNode(feParent, dp, out inheritanceBehavior);
          if (!TreeWalkHelper.SkipNow(inheritanceBehavior))
          {
            if (flag)
            {
              if (EventTrace.IsEnabled(EventTrace.Keyword.KeywordGeneral, EventTrace.Level.Verbose))
              {
                string str = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "[{0}]{1}({2})", (object) this.GetType().Name, (object) dp.Name, (object) this.GetHashCode());
                int num = (int) EventTrace.EventProvider.TraceEvent(EventTrace.Event.WClientPropParentCheck, EventTrace.Keyword.KeywordGeneral, EventTrace.Level.Verbose, (object) this.GetHashCode(), (object) str);
              }
              DependencyObject dependencyObject = (DependencyObject) feParent ?? (DependencyObject) fceParent;
              EntryIndex entryIndex = dependencyObject.LookupEntry(dp.GlobalIndex);
              return dependencyObject.GetValueEntry(entryIndex, dp, (PropertyMetadata) fmetadata, (RequestFlags) 12).Value;
            }
            else if (TreeWalkHelper.SkipNext(inheritanceBehavior))
              break;
          }
          else
            break;
        }
      }
      return DependencyProperty.UnsetValue;
    }

    private static void TextRenderingMode_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((FrameworkElement) d).pushTextRenderingMode();
    }

    private static void OnDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((FrameworkElement) d).RaiseDependencyPropertyChanged(FrameworkElement.DataContextChangedKey, e);
    }

    private static void AddStyleHandlersToEventRoute(EventRoute route, DependencyObject source, RoutedEventHandlerInfo[] handlers)
    {
      if (handlers == null)
        return;
      for (int index = 0; index < handlers.Length; ++index)
        route.Add((object) source, handlers[index].Handler, handlers[index].InvokeHandledEventsToo);
    }

    private static object GetActualWidth(DependencyObject d, out BaseValueSourceInternal source)
    {
      FrameworkElement frameworkElement = (FrameworkElement) d;
      if (frameworkElement.HasWidthEverChanged)
      {
        source = BaseValueSourceInternal.Local;
        return (object) frameworkElement.RenderSize.Width;
      }
      else
      {
        source = BaseValueSourceInternal.Default;
        return (object) 0.0;
      }
    }

    private static object GetActualHeight(DependencyObject d, out BaseValueSourceInternal source)
    {
      FrameworkElement frameworkElement = (FrameworkElement) d;
      if (frameworkElement.HasHeightEverChanged)
      {
        source = BaseValueSourceInternal.Local;
        return (object) frameworkElement.RenderSize.Height;
      }
      else
      {
        source = BaseValueSourceInternal.Default;
        return (object) 0.0;
      }
    }

    private static void OnLayoutTransformChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).AreTransformsClean = false;
    }

    private static bool IsWidthHeightValid(object value)
    {
      double d = (double) value;
      if (DoubleUtil.IsNaN(d))
        return true;
      if (d >= 0.0)
        return !double.IsPositiveInfinity(d);
      else
        return false;
    }

    private static bool IsMinWidthHeightValid(object value)
    {
      double d = (double) value;
      if (!DoubleUtil.IsNaN(d) && d >= 0.0)
        return !double.IsPositiveInfinity(d);
      else
        return false;
    }

    private static bool IsMaxWidthHeightValid(object value)
    {
      double num = (double) value;
      if (!DoubleUtil.IsNaN(num))
        return num >= 0.0;
      else
        return false;
    }

    private static void OnTransformDirty(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((UIElement) d).AreTransformsClean = false;
    }

    private static object CoerceFlowDirectionProperty(DependencyObject d, object value)
    {
      FrameworkElement frameworkElement = d as FrameworkElement;
      if (frameworkElement != null)
      {
        frameworkElement.InvalidateArrange();
        frameworkElement.InvalidateVisual();
        frameworkElement.AreTransformsClean = false;
      }
      return value;
    }

    private static void OnFlowDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      FrameworkElement frameworkElement = d as FrameworkElement;
      if (frameworkElement == null)
        return;
      frameworkElement.IsRightToLeft = (FlowDirection) e.NewValue == FlowDirection.RightToLeft;
      frameworkElement.AreTransformsClean = false;
    }

    private static bool IsValidFlowDirection(object o)
    {
      FlowDirection flowDirection = (FlowDirection) o;
      if (flowDirection != FlowDirection.LeftToRight)
        return flowDirection == FlowDirection.RightToLeft;
      else
        return true;
    }

    private static bool IsMarginValid(object value)
    {
      return ((Thickness) value).IsValid(true, false, true, false);
    }

    private static void OnCursorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      if (!((UIElement) d).IsMouseOver)
        return;
      Mouse.UpdateCursor();
    }

    private static void OnForceCursorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      if (!((UIElement) d).IsMouseOver)
        return;
      Mouse.UpdateCursor();
    }

    private static void OnQueryCursorOverride(object sender, QueryCursorEventArgs e)
    {
      FrameworkElement frameworkElement = (FrameworkElement) sender;
      Cursor cursor = frameworkElement.Cursor;
      if (cursor == null || e.Handled && !frameworkElement.ForceCursor)
        return;
      e.Cursor = cursor;
      e.Handled = true;
    }

    private Transform GetFlowDirectionTransform()
    {
      if (!this.BypassLayoutPolicies && FrameworkElement.ShouldApplyMirrorTransform(this))
        return (Transform) new MatrixTransform(-1.0, 0.0, 0.0, 1.0, this.RenderSize.Width, 0.0);
      else
        return (Transform) null;
    }

    private static FlowDirection GetFlowDirectionFromVisual(DependencyObject visual)
    {
      FlowDirection flowDirection = FlowDirection.LeftToRight;
      for (DependencyObject reference = visual; reference != null; reference = VisualTreeHelper.GetParent(reference))
      {
        FrameworkElement frameworkElement = reference as FrameworkElement;
        if (frameworkElement != null)
        {
          flowDirection = frameworkElement.FlowDirection;
          break;
        }
        else
        {
          object obj = reference.ReadLocalValue(FrameworkElement.FlowDirectionProperty);
          if (obj != DependencyProperty.UnsetValue)
          {
            flowDirection = (FlowDirection) obj;
            break;
          }
        }
      }
      return flowDirection;
    }

    private Size FindMaximalAreaLocalSpaceRect(Transform layoutTransform, Size transformSpaceBounds)
    {
      double d1 = transformSpaceBounds.Width;
      double d2 = transformSpaceBounds.Height;
      if (DoubleUtil.IsZero(d1) || DoubleUtil.IsZero(d2))
        return new Size(0.0, 0.0);
      bool flag1 = double.IsInfinity(d1);
      bool flag2 = double.IsInfinity(d2);
      if (flag1 && flag2)
        return new Size(double.PositiveInfinity, double.PositiveInfinity);
      if (flag1)
        d1 = d2;
      else if (flag2)
        d2 = d1;
      Matrix matrix = layoutTransform.Value;
      if (!matrix.HasInverse)
        return new Size(0.0, 0.0);
      double m11 = matrix.M11;
      double m12 = matrix.M12;
      double m21 = matrix.M21;
      double m22 = matrix.M22;
      double height;
      double width;
      if (DoubleUtil.IsZero(m12) || DoubleUtil.IsZero(m21))
      {
        double val2_1 = flag2 ? double.PositiveInfinity : Math.Abs(d2 / m22);
        double val2_2 = flag1 ? double.PositiveInfinity : Math.Abs(d1 / m11);
        if (DoubleUtil.IsZero(m12))
        {
          if (DoubleUtil.IsZero(m21))
          {
            height = val2_1;
            width = val2_2;
          }
          else
          {
            height = Math.Min(0.5 * Math.Abs(d1 / m21), val2_1);
            width = val2_2 - m21 * height / m11;
          }
        }
        else
        {
          width = Math.Min(0.5 * Math.Abs(d2 / m12), val2_2);
          height = val2_1 - m12 * width / m22;
        }
      }
      else if (DoubleUtil.IsZero(m11) || DoubleUtil.IsZero(m22))
      {
        double val2_1 = Math.Abs(d2 / m12);
        double val2_2 = Math.Abs(d1 / m21);
        if (DoubleUtil.IsZero(m11))
        {
          if (DoubleUtil.IsZero(m22))
          {
            height = val2_2;
            width = val2_1;
          }
          else
          {
            height = Math.Min(0.5 * Math.Abs(d2 / m22), val2_2);
            width = val2_1 - m22 * height / m12;
          }
        }
        else
        {
          width = Math.Min(0.5 * Math.Abs(d1 / m11), val2_1);
          height = val2_2 - m11 * width / m21;
        }
      }
      else
      {
        double val2_1 = Math.Abs(d1 / m11);
        double val1_1 = Math.Abs(d1 / m21);
        double val1_2 = Math.Abs(d2 / m12);
        double val2_2 = Math.Abs(d2 / m22);
        width = Math.Min(val1_2, val2_1) * 0.5;
        height = Math.Min(val1_1, val2_2) * 0.5;
        if (DoubleUtil.GreaterThanOrClose(val2_1, val1_2) && DoubleUtil.LessThanOrClose(val1_1, val2_2) || DoubleUtil.LessThanOrClose(val2_1, val1_2) && DoubleUtil.GreaterThanOrClose(val1_1, val2_2))
        {
          Rect rect = Rect.Transform(new Rect(0.0, 0.0, width, height), layoutTransform.Value);
          double d3 = Math.Min(d1 / rect.Width, d2 / rect.Height);
          if (!double.IsNaN(d3) && !double.IsInfinity(d3))
          {
            width *= d3;
            height *= d3;
          }
        }
      }
      return new Size(width, height);
    }

    private Vector ComputeAlignmentOffset(Size clientSize, Size inkSize)
    {
      Vector vector = new Vector();
      HorizontalAlignment horizontalAlignment = this.HorizontalAlignment;
      VerticalAlignment verticalAlignment = this.VerticalAlignment;
      if (horizontalAlignment == HorizontalAlignment.Stretch && inkSize.Width > clientSize.Width)
        horizontalAlignment = HorizontalAlignment.Left;
      if (verticalAlignment == VerticalAlignment.Stretch && inkSize.Height > clientSize.Height)
        verticalAlignment = VerticalAlignment.Top;
      vector.X = horizontalAlignment == HorizontalAlignment.Center || horizontalAlignment == HorizontalAlignment.Stretch ? (clientSize.Width - inkSize.Width) * 0.5 : (horizontalAlignment != HorizontalAlignment.Right ? 0.0 : clientSize.Width - inkSize.Width);
      vector.Y = verticalAlignment == VerticalAlignment.Center || verticalAlignment == VerticalAlignment.Stretch ? (clientSize.Height - inkSize.Height) * 0.5 : (verticalAlignment != VerticalAlignment.Bottom ? 0.0 : clientSize.Height - inkSize.Height);
      return vector;
    }

    private void SetLayoutOffset(Vector offset, Size oldRenderSize)
    {
      if (!this.AreTransformsClean || !DoubleUtil.AreClose(this.RenderSize, oldRenderSize))
      {
        Transform directionTransform = this.GetFlowDirectionTransform();
        Transform transform = this.RenderTransform;
        if (transform == Transform.Identity)
          transform = (Transform) null;
        FrameworkElement.LayoutTransformData layoutTransformData = FrameworkElement.LayoutTransformDataField.GetValue((DependencyObject) this);
        TransformGroup transformGroup = (TransformGroup) null;
        if (directionTransform != null || transform != null || layoutTransformData != null)
        {
          transformGroup = new TransformGroup();
          transformGroup.CanBeInheritanceContext = false;
          transformGroup.Children.CanBeInheritanceContext = false;
          if (directionTransform != null)
            transformGroup.Children.Add(directionTransform);
          if (layoutTransformData != null)
          {
            transformGroup.Children.Add(layoutTransformData.Transform);
            FrameworkElement.MinMax minMax = new FrameworkElement.MinMax(this);
            Size renderSize = this.RenderSize;
            if (double.IsPositiveInfinity(minMax.maxWidth))
            {
              double width = renderSize.Width;
            }
            if (double.IsPositiveInfinity(minMax.maxHeight))
            {
              double height = renderSize.Height;
            }
            renderSize.Width = Math.Min(renderSize.Width, minMax.maxWidth);
            renderSize.Height = Math.Min(renderSize.Height, minMax.maxHeight);
            Rect rect = Rect.Transform(new Rect(renderSize), layoutTransformData.Transform.Value);
            transformGroup.Children.Add((Transform) new TranslateTransform(-rect.X, -rect.Y));
          }
          if (transform != null)
          {
            Point renderTransformOrigin = this.GetRenderTransformOrigin();
            bool flag = renderTransformOrigin.X != 0.0 || renderTransformOrigin.Y != 0.0;
            if (flag)
            {
              TranslateTransform translateTransform = new TranslateTransform(-renderTransformOrigin.X, -renderTransformOrigin.Y);
              translateTransform.Freeze();
              transformGroup.Children.Add((Transform) translateTransform);
            }
            transformGroup.Children.Add(transform);
            if (flag)
            {
              TranslateTransform translateTransform = new TranslateTransform(renderTransformOrigin.X, renderTransformOrigin.Y);
              translateTransform.Freeze();
              transformGroup.Children.Add((Transform) translateTransform);
            }
          }
        }
        this.VisualTransform = (Transform) transformGroup;
        this.AreTransformsClean = true;
      }
      Vector visualOffset = this.VisualOffset;
      if (DoubleUtil.AreClose(visualOffset.X, offset.X) && DoubleUtil.AreClose(visualOffset.Y, offset.Y))
        return;
      this.VisualOffset = offset;
    }

    private Point GetRenderTransformOrigin()
    {
      Point renderTransformOrigin = this.RenderTransformOrigin;
      Size renderSize = this.RenderSize;
      return new Point(renderSize.Width * renderTransformOrigin.X, renderSize.Height * renderTransformOrigin.Y);
    }

    private static void OnPreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (e.OriginalSource != sender)
        return;
      IInputElement focusedElement1 = FocusManager.GetFocusedElement((DependencyObject) sender, true);
      if (focusedElement1 == null || focusedElement1 == sender || !Keyboard.IsFocusable(focusedElement1 as DependencyObject))
        return;
      IInputElement focusedElement2 = Keyboard.FocusedElement;
      focusedElement1.Focus();
      if (Keyboard.FocusedElement != focusedElement1 && Keyboard.FocusedElement == focusedElement2)
        return;
      e.Handled = true;
    }

    private static void OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (sender != e.OriginalSource)
        return;
      FrameworkElement frameworkElement = (FrameworkElement) sender;
      KeyboardNavigation.UpdateFocusedElement((DependencyObject) frameworkElement);
      KeyboardNavigation current = KeyboardNavigation.Current;
      KeyboardNavigation.ShowFocusVisual();
      current.NotifyFocusChanged((object) frameworkElement, e);
      current.UpdateActiveElement((DependencyObject) frameworkElement);
    }

    private static void OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (sender != e.OriginalSource)
        return;
      KeyboardNavigation.Current.HideFocusVisual();
      if (e.NewFocus != null)
        return;
      KeyboardNavigation.Current.NotifyFocusChanged(sender, e);
    }

    private void TryFireInitialized()
    {
      if (this.ReadInternalFlag(InternalFlags.InitPending) || this.ReadInternalFlag(InternalFlags.IsInitialized))
        return;
      this.WriteInternalFlag(InternalFlags.IsInitialized, true);
      this.PrivateInitialized();
      this.OnInitialized(EventArgs.Empty);
    }

    private void RaiseInitialized(EventPrivateKey key, EventArgs e)
    {
      EventHandlersStore eventHandlersStore = this.EventHandlersStore;
      if (eventHandlersStore == null)
        return;
      Delegate @delegate = eventHandlersStore.Get(key);
      if (@delegate == null)
        return;
      ((EventHandler) @delegate)((object) this, e);
    }

    private static void NumberSubstitutionChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
      ((FrameworkElement) o).HasNumberSubstitutionChanged = true;
    }

    private static bool ShouldUseSystemFont(FrameworkElement fe, DependencyProperty dp)
    {
      if ((SystemResources.SystemResourcesAreChanging || fe.ReadInternalFlag(InternalFlags.CreatingRoot) && SystemResources.SystemResourcesHaveChanged) && (fe._parent == null && VisualTreeHelper.GetParent((DependencyObject) fe) == null))
      {
        bool hasModifiers;
        return fe.GetValueSource(dp, (PropertyMetadata) null, out hasModifiers) == BaseValueSourceInternal.Default;
      }
      else
        return false;
    }

    private static object CoerceFontFamily(DependencyObject o, object value)
    {
      if (FrameworkElement.ShouldUseSystemFont((FrameworkElement) o, TextElement.FontFamilyProperty))
        return (object) SystemFonts.MessageFontFamily;
      else
        return value;
    }

    private static object CoerceFontSize(DependencyObject o, object value)
    {
      if (FrameworkElement.ShouldUseSystemFont((FrameworkElement) o, TextElement.FontSizeProperty))
        return (object) SystemFonts.MessageFontSize;
      else
        return value;
    }

    private static object CoerceFontStyle(DependencyObject o, object value)
    {
      if (FrameworkElement.ShouldUseSystemFont((FrameworkElement) o, TextElement.FontStyleProperty))
        return (object) SystemFonts.MessageFontStyle;
      else
        return value;
    }

    private static object CoerceFontWeight(DependencyObject o, object value)
    {
      if (FrameworkElement.ShouldUseSystemFont((FrameworkElement) o, TextElement.FontWeightProperty))
        return (object) SystemFonts.MessageFontWeight;
      else
        return value;
    }

    private static FrameworkElement.FrameworkServices EnsureFrameworkServices()
    {
      if (FrameworkElement._frameworkServices == null)
        FrameworkElement._frameworkServices = new FrameworkElement.FrameworkServices();
      return FrameworkElement._frameworkServices;
    }

    private static void OnToolTipOpeningThunk(object sender, ToolTipEventArgs e)
    {
      ((FrameworkElement) sender).OnToolTipOpening(e);
    }

    private static void OnToolTipClosingThunk(object sender, ToolTipEventArgs e)
    {
      ((FrameworkElement) sender).OnToolTipClosing(e);
    }

    private static void OnContextMenuOpeningThunk(object sender, ContextMenuEventArgs e)
    {
      ((FrameworkElement) sender).OnContextMenuOpening(e);
    }

    private static void OnContextMenuClosingThunk(object sender, ContextMenuEventArgs e)
    {
      ((FrameworkElement) sender).OnContextMenuClosing(e);
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

    private bool IsLogicalDescendent(DependencyObject child)
    {
      for (; child != null; child = LogicalTreeHelper.GetParent(child))
      {
        if (child == this)
          return true;
      }
      return false;
    }

    private void ClearInheritanceContext()
    {
      if (this.InheritanceContext == null)
        return;
      FrameworkElement.InheritanceContextField.ClearValue((DependencyObject) this);
      this.OnInheritanceContextChanged(EventArgs.Empty);
    }

    private void ConnectMentor(DependencyObject mentor)
    {
      FrameworkObject foMentor = new FrameworkObject(mentor);
      foMentor.InheritedPropertyChanged += new InheritedPropertyChangedEventHandler(this.OnMentorInheritedPropertyChanged);
      foMentor.ResourcesChanged += new EventHandler(this.OnMentorResourcesChanged);
      TreeWalkHelper.InvalidateOnTreeChange(this, (FrameworkContentElement) null, foMentor.DO, true);
      if (!this.SubtreeHasLoadedChangeHandler)
        return;
      bool isLoaded = foMentor.IsLoaded;
      this.ConnectLoadedEvents(ref foMentor, isLoaded);
      if (!isLoaded)
        return;
      this.FireLoadedOnDescendentsInternal();
    }

    private void DisconnectMentor(DependencyObject mentor)
    {
      FrameworkObject foMentor = new FrameworkObject(mentor);
      foMentor.InheritedPropertyChanged -= new InheritedPropertyChangedEventHandler(this.OnMentorInheritedPropertyChanged);
      foMentor.ResourcesChanged -= new EventHandler(this.OnMentorResourcesChanged);
      TreeWalkHelper.InvalidateOnTreeChange(this, (FrameworkContentElement) null, foMentor.DO, false);
      if (!this.SubtreeHasLoadedChangeHandler)
        return;
      bool isLoaded = foMentor.IsLoaded;
      this.DisconnectLoadedEvents(ref foMentor, isLoaded);
      if (!foMentor.IsLoaded)
        return;
      this.FireUnloadedOnDescendentsInternal();
    }

    private void OnMentorLoaded(object sender, RoutedEventArgs e)
    {
      FrameworkObject frameworkObject = new FrameworkObject((DependencyObject) sender);
      frameworkObject.Loaded -= new RoutedEventHandler(this.OnMentorLoaded);
      frameworkObject.Unloaded += new RoutedEventHandler(this.OnMentorUnloaded);
      BroadcastEventHelper.BroadcastLoadedSynchronously((DependencyObject) this, this.IsLoaded);
    }

    private void OnMentorUnloaded(object sender, RoutedEventArgs e)
    {
      FrameworkObject frameworkObject = new FrameworkObject((DependencyObject) sender);
      frameworkObject.Unloaded -= new RoutedEventHandler(this.OnMentorUnloaded);
      frameworkObject.Loaded += new RoutedEventHandler(this.OnMentorLoaded);
      BroadcastEventHelper.BroadcastUnloadedSynchronously((DependencyObject) this, this.IsLoaded);
    }

    private void ConnectLoadedEvents(ref FrameworkObject foMentor, bool isLoaded)
    {
      if (!foMentor.IsValid)
        return;
      if (isLoaded)
        foMentor.Unloaded += new RoutedEventHandler(this.OnMentorUnloaded);
      else
        foMentor.Loaded += new RoutedEventHandler(this.OnMentorLoaded);
    }

    private void DisconnectLoadedEvents(ref FrameworkObject foMentor, bool isLoaded)
    {
      if (!foMentor.IsValid)
        return;
      if (isLoaded)
        foMentor.Unloaded -= new RoutedEventHandler(this.OnMentorUnloaded);
      else
        foMentor.Loaded -= new RoutedEventHandler(this.OnMentorLoaded);
    }

    private void OnMentorInheritedPropertyChanged(object sender, InheritedPropertyChangedEventArgs e)
    {
      TreeWalkHelper.InvalidateOnInheritablePropertyChange(this, (FrameworkContentElement) null, e.Info, false);
    }

    private void OnMentorResourcesChanged(object sender, EventArgs e)
    {
      TreeWalkHelper.InvalidateOnResourcesChange(this, (FrameworkContentElement) null, ResourcesChangeInfo.CatastrophicDictionaryChangeInfo);
    }

    private class LayoutTransformData
    {
      internal Size UntransformedDS;
      internal Size TransformedUnroundedDS;
      private Transform _transform;

      internal Transform Transform
      {
        get
        {
          return this._transform;
        }
      }

      internal void CreateTransformSnapshot(Transform sourceTransform)
      {
        this._transform = (Transform) new MatrixTransform(sourceTransform.Value);
        this._transform.Freeze();
      }
    }

    private class FrameworkServices
    {
      internal KeyboardNavigation _keyboardNavigation;
      internal PopupControlService _popupControlService;

      internal FrameworkServices()
      {
        this._keyboardNavigation = new KeyboardNavigation();
        this._popupControlService = new PopupControlService();
      }
    }

    private struct MinMax
    {
      internal double minWidth;
      internal double maxWidth;
      internal double minHeight;
      internal double maxHeight;

      internal MinMax(FrameworkElement e)
      {
        this.maxHeight = e.MaxHeight;
        this.minHeight = e.MinHeight;
        double height = e.Height;
        this.maxHeight = Math.Max(Math.Min(DoubleUtil.IsNaN(height) ? double.PositiveInfinity : height, this.maxHeight), this.minHeight);
        this.minHeight = Math.Max(Math.Min(this.maxHeight, DoubleUtil.IsNaN(height) ? 0.0 : height), this.minHeight);
        this.maxWidth = e.MaxWidth;
        this.minWidth = e.MinWidth;
        double width = e.Width;
        this.maxWidth = Math.Max(Math.Min(DoubleUtil.IsNaN(width) ? double.PositiveInfinity : width, this.maxWidth), this.minWidth);
        this.minWidth = Math.Max(Math.Min(this.maxWidth, DoubleUtil.IsNaN(width) ? 0.0 : width), this.minWidth);
      }
    }
  }
}
