// Type: System.Windows.Controls.Control
// Assembly: PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\WPF\PresentationFramework.dll

using MS.Internal.KnownBoxes;
using MS.Internal.PresentationFramework;
using MS.Utility;
using System;
using System.ComponentModel;
using System.Runtime;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace System.Windows.Controls
{
  public class Control : FrameworkElement
  {
    [CommonDependencyProperty]
    public static readonly DependencyProperty BorderBrushProperty = Border.BorderBrushProperty.AddOwner(typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata(Border.BorderBrushProperty.DefaultMetadata.DefaultValue, FrameworkPropertyMetadataOptions.None));
    [CommonDependencyProperty]
    public static readonly DependencyProperty BorderThicknessProperty = Border.BorderThicknessProperty.AddOwner(typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata(Border.BorderThicknessProperty.DefaultMetadata.DefaultValue, FrameworkPropertyMetadataOptions.None));
    [CommonDependencyProperty]
    public static readonly DependencyProperty BackgroundProperty = Panel.BackgroundProperty.AddOwner(typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata(Panel.BackgroundProperty.DefaultMetadata.DefaultValue, FrameworkPropertyMetadataOptions.None));
    [CommonDependencyProperty]
    public static readonly DependencyProperty ForegroundProperty = TextElement.ForegroundProperty.AddOwner(typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata((object) SystemColors.ControlTextBrush, FrameworkPropertyMetadataOptions.Inherits));
    [CommonDependencyProperty]
    public static readonly DependencyProperty FontFamilyProperty = TextElement.FontFamilyProperty.AddOwner(typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata((object) SystemFonts.MessageFontFamily, FrameworkPropertyMetadataOptions.Inherits));
    [CommonDependencyProperty]
    public static readonly DependencyProperty FontSizeProperty = TextElement.FontSizeProperty.AddOwner(typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata((object) SystemFonts.MessageFontSize, FrameworkPropertyMetadataOptions.Inherits));
    [CommonDependencyProperty]
    public static readonly DependencyProperty FontStretchProperty = TextElement.FontStretchProperty.AddOwner(typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata(TextElement.FontStretchProperty.DefaultMetadata.DefaultValue, FrameworkPropertyMetadataOptions.Inherits));
    [CommonDependencyProperty]
    public static readonly DependencyProperty FontStyleProperty = TextElement.FontStyleProperty.AddOwner(typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata((object) SystemFonts.MessageFontStyle, FrameworkPropertyMetadataOptions.Inherits));
    [CommonDependencyProperty]
    public static readonly DependencyProperty FontWeightProperty = TextElement.FontWeightProperty.AddOwner(typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata((object) SystemFonts.MessageFontWeight, FrameworkPropertyMetadataOptions.Inherits));
    [CommonDependencyProperty]
    public static readonly DependencyProperty HorizontalContentAlignmentProperty = DependencyProperty.Register("HorizontalContentAlignment", typeof (HorizontalAlignment), typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata((object) HorizontalAlignment.Left), new ValidateValueCallback(FrameworkElement.ValidateHorizontalAlignmentValue));
    [CommonDependencyProperty]
    public static readonly DependencyProperty VerticalContentAlignmentProperty = DependencyProperty.Register("VerticalContentAlignment", typeof (VerticalAlignment), typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata((object) VerticalAlignment.Top), new ValidateValueCallback(FrameworkElement.ValidateVerticalAlignmentValue));
    [CommonDependencyProperty]
    public static readonly DependencyProperty TabIndexProperty = KeyboardNavigation.TabIndexProperty.AddOwner(typeof (Control));
    [CommonDependencyProperty]
    public static readonly DependencyProperty IsTabStopProperty = KeyboardNavigation.IsTabStopProperty.AddOwner(typeof (Control));
    [CommonDependencyProperty]
    public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register("Padding", typeof (Thickness), typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(), FrameworkPropertyMetadataOptions.AffectsParentMeasure));
    [CommonDependencyProperty]
    public static readonly DependencyProperty TemplateProperty = DependencyProperty.Register("Template", typeof (ControlTemplate), typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(Control.OnTemplateChanged)));
    public static readonly RoutedEvent PreviewMouseDoubleClickEvent = EventManager.RegisterRoutedEvent("PreviewMouseDoubleClick", RoutingStrategy.Direct, typeof (MouseButtonEventHandler), typeof (Control));
    public static readonly RoutedEvent MouseDoubleClickEvent = EventManager.RegisterRoutedEvent("MouseDoubleClick", RoutingStrategy.Direct, typeof (MouseButtonEventHandler), typeof (Control));
    private ControlTemplate _templateCache;
    internal Control.ControlBoolFlags _controlBoolField;

    [Category("Appearance")]
    [Bindable(true)]
    public Brush BorderBrush
    {
      get
      {
        return (Brush) this.GetValue(Control.BorderBrushProperty);
      }
      set
      {
        this.SetValue(Control.BorderBrushProperty, (object) value);
      }
    }

    [Bindable(true)]
    [Category("Appearance")]
    public Thickness BorderThickness
    {
      get
      {
        return (Thickness) this.GetValue(Control.BorderThicknessProperty);
      }
      set
      {
        this.SetValue(Control.BorderThicknessProperty, (object) value);
      }
    }

    [Bindable(true)]
    [Category("Appearance")]
    public Brush Background
    {
      get
      {
        return (Brush) this.GetValue(Control.BackgroundProperty);
      }
      set
      {
        this.SetValue(Control.BackgroundProperty, (object) value);
      }
    }

    [Category("Appearance")]
    [Bindable(true)]
    public Brush Foreground
    {
      get
      {
        return (Brush) this.GetValue(Control.ForegroundProperty);
      }
      set
      {
        this.SetValue(Control.ForegroundProperty, (object) value);
      }
    }

    [Category("Appearance")]
    [Localizability(LocalizationCategory.Font)]
    [Bindable(true)]
    public FontFamily FontFamily
    {
      get
      {
        return (FontFamily) this.GetValue(Control.FontFamilyProperty);
      }
      set
      {
        this.SetValue(Control.FontFamilyProperty, (object) value);
      }
    }

    [Bindable(true)]
    [Localizability(LocalizationCategory.None)]
    [Category("Appearance")]
    [TypeConverter(typeof (FontSizeConverter))]
    public double FontSize
    {
      get
      {
        return (double) this.GetValue(Control.FontSizeProperty);
      }
      set
      {
        this.SetValue(Control.FontSizeProperty, (object) value);
      }
    }

    [Category("Appearance")]
    [Bindable(true)]
    public FontStretch FontStretch
    {
      get
      {
        return (FontStretch) this.GetValue(Control.FontStretchProperty);
      }
      set
      {
        this.SetValue(Control.FontStretchProperty, (object) value);
      }
    }

    [Category("Appearance")]
    [Bindable(true)]
    public FontStyle FontStyle
    {
      get
      {
        return (FontStyle) this.GetValue(Control.FontStyleProperty);
      }
      set
      {
        this.SetValue(Control.FontStyleProperty, (object) value);
      }
    }

    [Bindable(true)]
    [Category("Appearance")]
    public FontWeight FontWeight
    {
      get
      {
        return (FontWeight) this.GetValue(Control.FontWeightProperty);
      }
      set
      {
        this.SetValue(Control.FontWeightProperty, (object) value);
      }
    }

    [Category("Layout")]
    [Bindable(true)]
    public HorizontalAlignment HorizontalContentAlignment
    {
      get
      {
        return (HorizontalAlignment) this.GetValue(Control.HorizontalContentAlignmentProperty);
      }
      set
      {
        this.SetValue(Control.HorizontalContentAlignmentProperty, (object) value);
      }
    }

    [Category("Layout")]
    [Bindable(true)]
    public VerticalAlignment VerticalContentAlignment
    {
      get
      {
        return (VerticalAlignment) this.GetValue(Control.VerticalContentAlignmentProperty);
      }
      set
      {
        this.SetValue(Control.VerticalContentAlignmentProperty, (object) value);
      }
    }

    [Category("Behavior")]
    [Bindable(true)]
    public int TabIndex
    {
      get
      {
        return (int) this.GetValue(Control.TabIndexProperty);
      }
      set
      {
        this.SetValue(Control.TabIndexProperty, (object) value);
      }
    }

    [Category("Behavior")]
    [Bindable(true)]
    public bool IsTabStop
    {
      get
      {
        return (bool) this.GetValue(Control.IsTabStopProperty);
      }
      set
      {
        this.SetValue(Control.IsTabStopProperty, BooleanBoxes.Box(value));
      }
    }

    [Category("Layout")]
    [Bindable(true)]
    public Thickness Padding
    {
      get
      {
        return (Thickness) this.GetValue(Control.PaddingProperty);
      }
      set
      {
        this.SetValue(Control.PaddingProperty, (object) value);
      }
    }

    public ControlTemplate Template
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._templateCache;
      }
      set
      {
        this.SetValue(Control.TemplateProperty, (object) value);
      }
    }

    internal override FrameworkTemplate TemplateInternal
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return (FrameworkTemplate) this.Template;
      }
    }

    internal override FrameworkTemplate TemplateCache
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return (FrameworkTemplate) this._templateCache;
      }
      set
      {
        this._templateCache = (ControlTemplate) value;
      }
    }

    protected internal virtual bool HandlesScrolling
    {
      get
      {
        return false;
      }
    }

    internal bool VisualStateChangeSuspended
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.ReadControlFlag(Control.ControlBoolFlags.VisualStateChangeSuspended);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.WriteControlFlag(Control.ControlBoolFlags.VisualStateChangeSuspended, value);
      }
    }

    public event MouseButtonEventHandler PreviewMouseDoubleClick
    {
      add
      {
        this.AddHandler(Control.PreviewMouseDoubleClickEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(Control.PreviewMouseDoubleClickEvent, (Delegate) value);
      }
    }

    public event MouseButtonEventHandler MouseDoubleClick
    {
      add
      {
        this.AddHandler(Control.MouseDoubleClickEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(Control.MouseDoubleClickEvent, (Delegate) value);
      }
    }

    static Control()
    {
      UIElement.FocusableProperty.OverrideMetadata(typeof (Control), (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.TrueBox));
      EventManager.RegisterClassHandler(typeof (Control), UIElement.PreviewMouseLeftButtonDownEvent, (Delegate) new MouseButtonEventHandler(Control.HandleDoubleClick), true);
      EventManager.RegisterClassHandler(typeof (Control), UIElement.MouseLeftButtonDownEvent, (Delegate) new MouseButtonEventHandler(Control.HandleDoubleClick), true);
      EventManager.RegisterClassHandler(typeof (Control), UIElement.PreviewMouseRightButtonDownEvent, (Delegate) new MouseButtonEventHandler(Control.HandleDoubleClick), true);
      EventManager.RegisterClassHandler(typeof (Control), UIElement.MouseRightButtonDownEvent, (Delegate) new MouseButtonEventHandler(Control.HandleDoubleClick), true);
      UIElement.IsKeyboardFocusedPropertyKey.OverrideMetadata(typeof (Control), new PropertyMetadata(new PropertyChangedCallback(Control.OnVisualStatePropertyChanged)));
    }

    public Control()
    {
      PropertyMetadata metadata = Control.TemplateProperty.GetMetadata(this.DependencyObjectType);
      ControlTemplate controlTemplate = (ControlTemplate) metadata.DefaultValue;
      if (controlTemplate == null)
        return;
      Control.OnTemplateChanged((DependencyObject) this, new DependencyPropertyChangedEventArgs(Control.TemplateProperty, metadata, (object) null, (object) controlTemplate));
    }

    internal override void OnTemplateChangedInternal(FrameworkTemplate oldTemplate, FrameworkTemplate newTemplate)
    {
      this.OnTemplateChanged((ControlTemplate) oldTemplate, (ControlTemplate) newTemplate);
    }

    protected virtual void OnTemplateChanged(ControlTemplate oldTemplate, ControlTemplate newTemplate)
    {
    }

    public override string ToString()
    {
      string str = !this.CheckAccess() ? (string) this.Dispatcher.Invoke(DispatcherPriority.Send, new TimeSpan(0, 0, 0, 0, 20), (Delegate) (o => (object) this.GetPlainText()), (object) null) : this.GetPlainText();
      if (string.IsNullOrEmpty(str))
        return base.ToString();
      return System.Windows.SR.Get("ToStringFormatString_Control", (object) base.ToString(), (object) str);
    }

    protected virtual void OnPreviewMouseDoubleClick(MouseButtonEventArgs e)
    {
      this.RaiseEvent((RoutedEventArgs) e);
    }

    protected virtual void OnMouseDoubleClick(MouseButtonEventArgs e)
    {
      this.RaiseEvent((RoutedEventArgs) e);
    }

    internal override void OnPreApplyTemplate()
    {
      this.VisualStateChangeSuspended = true;
      base.OnPreApplyTemplate();
    }

    internal override void OnPostApplyTemplate()
    {
      base.OnPostApplyTemplate();
      this.VisualStateChangeSuspended = false;
      this.UpdateVisualState(false);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void UpdateVisualState()
    {
      this.UpdateVisualState(true);
    }

    internal void UpdateVisualState(bool useTransitions)
    {
      EventTrace.EasyTraceEvent(EventTrace.Keyword.KeywordGeneral | EventTrace.Keyword.KeywordPerf, EventTrace.Level.Info, EventTrace.Event.UpdateVisualStateStart);
      if (!this.VisualStateChangeSuspended)
        this.ChangeVisualState(useTransitions);
      EventTrace.EasyTraceEvent(EventTrace.Keyword.KeywordGeneral | EventTrace.Keyword.KeywordPerf, EventTrace.Level.Info, EventTrace.Event.UpdateVisualStateEnd);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal virtual void ChangeVisualState(bool useTransitions)
    {
      this.ChangeValidationVisualState(useTransitions);
    }

    internal void ChangeValidationVisualState(bool useTransitions)
    {
      if (Validation.GetHasError((DependencyObject) this))
      {
        if (this.IsKeyboardFocused)
          VisualStateManager.GoToState((FrameworkElement) this, "InvalidFocused", useTransitions);
        else
          VisualStateManager.GoToState((FrameworkElement) this, "InvalidUnfocused", useTransitions);
      }
      else
        VisualStateManager.GoToState((FrameworkElement) this, "Valid", useTransitions);
    }

    internal static void OnVisualStatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      Control control = d as Control;
      if (control == null)
        return;
      control.UpdateVisualState();
    }

    protected override Size MeasureOverride(Size constraint)
    {
      if (this.VisualChildrenCount > 0)
      {
        UIElement uiElement = (UIElement) this.GetVisualChild(0);
        if (uiElement != null)
        {
          uiElement.Measure(constraint);
          return uiElement.DesiredSize;
        }
      }
      return new Size(0.0, 0.0);
    }

    protected override Size ArrangeOverride(Size arrangeBounds)
    {
      if (this.VisualChildrenCount > 0)
      {
        UIElement uiElement = (UIElement) this.GetVisualChild(0);
        if (uiElement != null)
          uiElement.Arrange(new Rect(arrangeBounds));
      }
      return arrangeBounds;
    }

    internal bool ReadControlFlag(Control.ControlBoolFlags reqFlag)
    {
      return (this._controlBoolField & reqFlag) != (Control.ControlBoolFlags) 0;
    }

    internal void WriteControlFlag(Control.ControlBoolFlags reqFlag, bool set)
    {
      if (set)
        this._controlBoolField |= reqFlag;
      else
        this._controlBoolField &= ~reqFlag;
    }

    private static bool IsMarginValid(object value)
    {
      Thickness thickness = (Thickness) value;
      if (thickness.Left >= 0.0 && thickness.Right >= 0.0 && thickness.Top >= 0.0)
        return thickness.Bottom >= 0.0;
      else
        return false;
    }

    private static void OnTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      StyleHelper.UpdateTemplateCache((FrameworkElement) d, (FrameworkTemplate) e.OldValue, (FrameworkTemplate) e.NewValue, Control.TemplateProperty);
    }

    private static void HandleDoubleClick(object sender, MouseButtonEventArgs e)
    {
      if (e.ClickCount != 2)
        return;
      Control control = (Control) sender;
      MouseButtonEventArgs e1 = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice);
      if (e.RoutedEvent == UIElement.PreviewMouseLeftButtonDownEvent || e.RoutedEvent == UIElement.PreviewMouseRightButtonDownEvent)
      {
        e1.RoutedEvent = Control.PreviewMouseDoubleClickEvent;
        e1.Source = e.OriginalSource;
        e1.OverrideSource(e.Source);
        control.OnPreviewMouseDoubleClick(e1);
      }
      else
      {
        e1.RoutedEvent = Control.MouseDoubleClickEvent;
        e1.Source = e.OriginalSource;
        e1.OverrideSource(e.Source);
        control.OnMouseDoubleClick(e1);
      }
      if (!e1.Handled)
        return;
      e.Handled = true;
    }

    internal enum ControlBoolFlags : ushort
    {
      ContentIsNotLogical = (ushort) 1,
      IsSpaceKeyDown = (ushort) 2,
      HeaderIsNotLogical = (ushort) 4,
      CommandDisabled = (ushort) 8,
      ContentIsItem = (ushort) 16,
      HeaderIsItem = (ushort) 32,
      ScrollHostValid = (ushort) 64,
      ContainsSelection = (ushort) 128,
      VisualStateChangeSuspended = (ushort) 256,
    }
  }
}
