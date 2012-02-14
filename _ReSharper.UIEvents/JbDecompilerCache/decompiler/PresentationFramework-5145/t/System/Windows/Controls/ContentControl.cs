// Type: System.Windows.Controls.ContentControl
// Assembly: PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\WPF\PresentationFramework.dll

using MS.Internal;
using MS.Internal.Controls;
using MS.Internal.KnownBoxes;
using MS.Internal.PresentationFramework;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace System.Windows.Controls
{
  [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
  [DefaultProperty("Content")]
  [ContentProperty("Content")]
  public class ContentControl : Control, IAddChild
  {
    [CommonDependencyProperty]
    public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof (object), typeof (ContentControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(ContentControl.OnContentChanged)));
    private static readonly DependencyPropertyKey HasContentPropertyKey = DependencyProperty.RegisterReadOnly("HasContent", typeof (bool), typeof (ContentControl), (PropertyMetadata) new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, FrameworkPropertyMetadataOptions.None));
    [CommonDependencyProperty]
    public static readonly DependencyProperty HasContentProperty = ContentControl.HasContentPropertyKey.DependencyProperty;
    [CommonDependencyProperty]
    public static readonly DependencyProperty ContentTemplateProperty = DependencyProperty.Register("ContentTemplate", typeof (DataTemplate), typeof (ContentControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(ContentControl.OnContentTemplateChanged)));
    [CommonDependencyProperty]
    public static readonly DependencyProperty ContentTemplateSelectorProperty = DependencyProperty.Register("ContentTemplateSelector", typeof (DataTemplateSelector), typeof (ContentControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(ContentControl.OnContentTemplateSelectorChanged)));
    [CommonDependencyProperty]
    public static readonly DependencyProperty ContentStringFormatProperty = DependencyProperty.Register("ContentStringFormat", typeof (string), typeof (ContentControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(ContentControl.OnContentStringFormatChanged)));
    private static DependencyObjectType _dType;

    protected internal override IEnumerator LogicalChildren
    {
      get
      {
        object content = this.Content;
        if (this.ContentIsNotLogical || content == null)
          return EmptyEnumerator.Instance;
        if (this.TemplatedParent != null)
        {
          DependencyObject current = content as DependencyObject;
          if (current != null)
          {
            DependencyObject parent = LogicalTreeHelper.GetParent(current);
            if (parent != null && parent != this)
              return EmptyEnumerator.Instance;
          }
        }
        return (IEnumerator) new ContentModelTreeEnumerator(this, content);
      }
    }

    [Bindable(true)]
    [CustomCategory("Content")]
    public object Content
    {
      get
      {
        return this.GetValue(ContentControl.ContentProperty);
      }
      set
      {
        this.SetValue(ContentControl.ContentProperty, value);
      }
    }

    [Browsable(false)]
    [ReadOnly(true)]
    public bool HasContent
    {
      get
      {
        return (bool) this.GetValue(ContentControl.HasContentProperty);
      }
    }

    [Bindable(true)]
    [CustomCategory("Content")]
    public DataTemplate ContentTemplate
    {
      get
      {
        return (DataTemplate) this.GetValue(ContentControl.ContentTemplateProperty);
      }
      set
      {
        this.SetValue(ContentControl.ContentTemplateProperty, (object) value);
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Bindable(true)]
    [CustomCategory("Content")]
    public DataTemplateSelector ContentTemplateSelector
    {
      get
      {
        return (DataTemplateSelector) this.GetValue(ContentControl.ContentTemplateSelectorProperty);
      }
      set
      {
        this.SetValue(ContentControl.ContentTemplateSelectorProperty, (object) value);
      }
    }

    [CustomCategory("Content")]
    [Bindable(true)]
    public string ContentStringFormat
    {
      get
      {
        return (string) this.GetValue(ContentControl.ContentStringFormatProperty);
      }
      set
      {
        this.SetValue(ContentControl.ContentStringFormatProperty, (object) value);
      }
    }

    internal bool ContentIsNotLogical
    {
      get
      {
        return this.ReadControlFlag(Control.ControlBoolFlags.ContentIsNotLogical);
      }
      set
      {
        this.WriteControlFlag(Control.ControlBoolFlags.ContentIsNotLogical, value);
      }
    }

    internal bool ContentIsItem
    {
      get
      {
        return this.ReadControlFlag(Control.ControlBoolFlags.ContentIsItem);
      }
      set
      {
        this.WriteControlFlag(Control.ControlBoolFlags.ContentIsItem, value);
      }
    }

    internal override int EffectiveValuesInitialSize
    {
      get
      {
        return 4;
      }
    }

    internal override DependencyObjectType DTypeThemeStyleKey
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return ContentControl._dType;
      }
    }

    static ContentControl()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (ContentControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (ContentControl)));
      ContentControl._dType = DependencyObjectType.FromSystemTypeInternal(typeof (ContentControl));
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    public ContentControl()
    {
    }

    internal override string GetPlainText()
    {
      return ContentControl.ContentObjectToString(this.Content);
    }

    internal static string ContentObjectToString(object content)
    {
      if (content == null)
        return string.Empty;
      FrameworkElement frameworkElement = content as FrameworkElement;
      if (frameworkElement != null)
        return frameworkElement.GetPlainText();
      else
        return content.ToString();
    }

    internal void PrepareContentControl(object item, DataTemplate itemTemplate, DataTemplateSelector itemTemplateSelector, string itemStringFormat)
    {
      if (item != this)
      {
        this.ContentIsNotLogical = true;
        if (this.ContentIsItem || !this.HasNonDefaultValue(ContentControl.ContentProperty))
        {
          this.Content = item;
          this.ContentIsItem = true;
        }
        if (itemTemplate != null)
          this.SetValue(ContentControl.ContentTemplateProperty, (object) itemTemplate);
        if (itemTemplateSelector != null)
          this.SetValue(ContentControl.ContentTemplateSelectorProperty, (object) itemTemplateSelector);
        if (itemStringFormat == null)
          return;
        this.SetValue(ContentControl.ContentStringFormatProperty, (object) itemStringFormat);
      }
      else
        this.ContentIsNotLogical = false;
    }

    internal void ClearContentControl(object item)
    {
      if (item == this || !this.ContentIsItem)
        return;
      this.Content = BindingExpressionBase.DisconnectedItem;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual bool ShouldSerializeContent()
    {
      return this.ReadLocalValue(ContentControl.ContentProperty) != DependencyProperty.UnsetValue;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    void IAddChild.AddChild(object value)
    {
      this.AddChild(value);
    }

    protected virtual void AddChild(object value)
    {
      if (this.Content != null && value != null)
        throw new InvalidOperationException(System.Windows.SR.Get("ContentControlCannotHaveMultipleContent"));
      this.Content = value;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    void IAddChild.AddText(string text)
    {
      this.AddText(text);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    protected virtual void AddText(string text)
    {
      this.AddChild((object) text);
    }

    protected virtual void OnContentChanged(object oldContent, object newContent)
    {
      this.RemoveLogicalChild(oldContent);
      if (this.ContentIsNotLogical)
        return;
      if (this.TemplatedParent != null)
      {
        DependencyObject current = newContent as DependencyObject;
        if (current != null)
        {
          DependencyObject parent = LogicalTreeHelper.GetParent(current);
          FrameworkElement frameworkElement = parent as FrameworkElement;
          if (frameworkElement != null && !frameworkElement.IsAncestorOf((DependencyObject) this))
            frameworkElement.RemoveLogicalChild(newContent);
          else if (parent != null)
            return;
        }
      }
      this.AddLogicalChild(newContent);
    }

    protected virtual void OnContentTemplateChanged(DataTemplate oldContentTemplate, DataTemplate newContentTemplate)
    {
      Helper.CheckTemplateAndTemplateSelector("Content", ContentControl.ContentTemplateProperty, ContentControl.ContentTemplateSelectorProperty, (DependencyObject) this);
    }

    protected virtual void OnContentTemplateSelectorChanged(DataTemplateSelector oldContentTemplateSelector, DataTemplateSelector newContentTemplateSelector)
    {
      Helper.CheckTemplateAndTemplateSelector("Content", ContentControl.ContentTemplateProperty, ContentControl.ContentTemplateSelectorProperty, (DependencyObject) this);
    }

    protected virtual void OnContentStringFormatChanged(string oldContentStringFormat, string newContentStringFormat)
    {
    }

    private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ContentControl contentControl = (ContentControl) d;
      contentControl.SetValue(ContentControl.HasContentPropertyKey, e.NewValue != null ? BooleanBoxes.TrueBox : BooleanBoxes.FalseBox);
      contentControl.OnContentChanged(e.OldValue, e.NewValue);
    }

    private static void OnContentTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((ContentControl) d).OnContentTemplateChanged((DataTemplate) e.OldValue, (DataTemplate) e.NewValue);
    }

    private static void OnContentTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((ContentControl) d).OnContentTemplateSelectorChanged((DataTemplateSelector) e.NewValue, (DataTemplateSelector) e.NewValue);
    }

    private static void OnContentStringFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((ContentControl) d).OnContentStringFormatChanged((string) e.OldValue, (string) e.NewValue);
    }
  }
}
