// Type: System.Windows.DependencyObject
// Assembly: WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\WPF\WindowsBase.dll

using MS.Internal;
using MS.Internal.ComponentModel;
using MS.Internal.KnownBoxes;
using MS.Internal.WindowsBase;
using MS.Utility;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime;
using System.Windows.Markup;
using System.Windows.Threading;

namespace System.Windows
{
  [NameScopeProperty("NameScope", typeof (NameScope))]
  [TypeDescriptionProvider(typeof (DependencyObjectProvider))]
  public class DependencyObject : DispatcherObject
  {
    [FriendAccessAllowed]
    internal static readonly DependencyProperty DirectDependencyProperty = DependencyProperty.Register("__Direct", typeof (object), typeof (DependencyProperty));
    private static readonly UncommonField<EventHandler> InheritanceContextChangedHandlersField = new UncommonField<EventHandler>();
    [FriendAccessAllowed]
    internal static readonly object ExpressionInAlternativeStore = (object) new NamedObject("ExpressionInAlternativeStore");
    internal static readonly UncommonField<object> DependentListMapField = new UncommonField<object>();
    internal static DependencyObjectType DType = DependencyObjectType.FromSystemTypeInternal(typeof (DependencyObject));
    private DependencyObjectType _dType;
    internal object _contextStorage;
    private EffectiveValueEntry[] _effectiveValues;
    private uint _packedData;
    private static AlternativeExpressionStorageCallback _getExpressionCore;
    private const int NestedOperationMaximum = 153;

    public DependencyObjectType DependencyObjectType
    {
      get
      {
        if (this._dType == null)
          this._dType = DependencyObjectType.FromSystemTypeInternal(this.GetType());
        return this._dType;
      }
    }

    public bool IsSealed
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.DO_Sealed;
      }
    }

    private bool CanModifyEffectiveValues
    {
      get
      {
        return ((int) this._packedData & 524288) != 0;
      }
      set
      {
        if (value)
          this._packedData |= 524288U;
        else
          this._packedData &= 4294443007U;
      }
    }

    [FriendAccessAllowed]
    internal bool IsInheritanceContextSealed
    {
      get
      {
        return ((int) this._packedData & 16777216) != 0;
      }
      set
      {
        if (value)
          this._packedData |= 16777216U;
        else
          this._packedData &= 4278190079U;
      }
    }

    private bool DO_Sealed
    {
      get
      {
        return ((int) this._packedData & 4194304) != 0;
      }
      set
      {
        if (value)
          this._packedData |= 4194304U;
        else
          this._packedData &= 4290772991U;
      }
    }

    internal bool Freezable_Frozen
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.DO_Sealed;
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.DO_Sealed = value;
      }
    }

    internal bool Freezable_HasMultipleInheritanceContexts
    {
      get
      {
        return ((int) this._packedData & 33554432) != 0;
      }
      set
      {
        if (value)
          this._packedData |= 33554432U;
        else
          this._packedData &= 4261412863U;
      }
    }

    internal bool Freezable_UsingHandlerList
    {
      get
      {
        return ((int) this._packedData & 67108864) != 0;
      }
      set
      {
        if (value)
          this._packedData |= 67108864U;
        else
          this._packedData &= 4227858431U;
      }
    }

    internal bool Freezable_UsingContextList
    {
      get
      {
        return ((int) this._packedData & 134217728) != 0;
      }
      set
      {
        if (value)
          this._packedData |= 134217728U;
        else
          this._packedData &= 4160749567U;
      }
    }

    internal bool Freezable_UsingSingletonHandler
    {
      get
      {
        return ((int) this._packedData & 268435456) != 0;
      }
      set
      {
        if (value)
          this._packedData |= 268435456U;
        else
          this._packedData &= 4026531839U;
      }
    }

    internal bool Freezable_UsingSingletonContext
    {
      get
      {
        return ((int) this._packedData & 536870912) != 0;
      }
      set
      {
        if (value)
          this._packedData |= 536870912U;
        else
          this._packedData &= 3758096383U;
      }
    }

    internal bool Animatable_IsResourceInvalidationNecessary
    {
      [FriendAccessAllowed] get
      {
        return ((int) this._packedData & 1073741824) != 0;
      }
      [FriendAccessAllowed] set
      {
        if (value)
          this._packedData |= 1073741824U;
        else
          this._packedData &= 3221225471U;
      }
    }

    internal bool IAnimatable_HasAnimatedProperties
    {
      [FriendAccessAllowed] get
      {
        return ((int) this._packedData & int.MaxValue) != 0;
      }
      [FriendAccessAllowed] set
      {
        if (value)
          this._packedData |= (uint) int.MinValue;
        else
          this._packedData &= (uint) int.MaxValue;
      }
    }

    internal virtual DependencyObject InheritanceContext
    {
      [FriendAccessAllowed] get
      {
        return (DependencyObject) null;
      }
    }

    internal virtual bool HasMultipleInheritanceContexts
    {
      get
      {
        return false;
      }
    }

    internal bool CanBeInheritanceContext
    {
      [FriendAccessAllowed] get
      {
        return ((int) this._packedData & 2097152) != 0;
      }
      [FriendAccessAllowed] set
      {
        if (value)
          this._packedData |= 2097152U;
        else
          this._packedData &= 4292870143U;
      }
    }

    internal EffectiveValueEntry[] EffectiveValues
    {
      [FriendAccessAllowed, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._effectiveValues;
      }
    }

    internal uint EffectiveValuesCount
    {
      [FriendAccessAllowed] get
      {
        return this._packedData & 1023U;
      }
      private set
      {
        this._packedData = (uint) ((int) this._packedData & -1024 | (int) value & 1023);
      }
    }

    internal uint InheritableEffectiveValuesCount
    {
      [FriendAccessAllowed] get
      {
        return this._packedData >> 10 & 511U;
      }
      set
      {
        this._packedData = (uint) (((int) value & 511) << 10 | (int) this._packedData & -523265);
      }
    }

    private bool IsInPropertyInitialization
    {
      get
      {
        return ((int) this._packedData & 8388608) != 0;
      }
      set
      {
        if (value)
          this._packedData |= 8388608U;
        else
          this._packedData &= 4286578687U;
      }
    }

    internal DependencyObject InheritanceParent
    {
      [FriendAccessAllowed] get
      {
        if (((int) this._packedData & 1041235968) == 0)
          return (DependencyObject) this._contextStorage;
        else
          return (DependencyObject) null;
      }
    }

    internal bool IsSelfInheritanceParent
    {
      [FriendAccessAllowed] get
      {
        return ((int) this._packedData & 1048576) != 0;
      }
    }

    [FriendAccessAllowed]
    internal virtual int EffectiveValuesInitialSize
    {
      get
      {
        return 2;
      }
    }

    internal event EventHandler InheritanceContextChanged
    {
      [FriendAccessAllowed] add
      {
        EventHandler eventHandler1 = DependencyObject.InheritanceContextChangedHandlersField.GetValue(this);
        EventHandler eventHandler2 = eventHandler1 == null ? value : eventHandler1 + value;
        DependencyObject.InheritanceContextChangedHandlersField.SetValue(this, eventHandler2);
      }
      [FriendAccessAllowed] remove
      {
        EventHandler eventHandler1 = DependencyObject.InheritanceContextChangedHandlersField.GetValue(this);
        if (eventHandler1 == null)
          return;
        EventHandler eventHandler2 = eventHandler1 - value;
        if (eventHandler2 == null)
          DependencyObject.InheritanceContextChangedHandlersField.ClearValue(this);
        else
          DependencyObject.InheritanceContextChangedHandlersField.SetValue(this, eventHandler2);
      }
    }

    static DependencyObject()
    {
    }

    public DependencyObject()
    {
      this.Initialize();
    }

    [FriendAccessAllowed]
    internal virtual void Seal()
    {
      PropertyMetadata.PromoteAllCachedDefaultValues(this);
      DependencyObject.DependentListMapField.ClearValue(this);
      this.DO_Sealed = true;
    }

    public override sealed bool Equals(object obj)
    {
      return base.Equals(obj);
    }

    public override sealed int GetHashCode()
    {
      return base.GetHashCode();
    }

    public object GetValue(DependencyProperty dp)
    {
      this.VerifyAccess();
      if (dp == null)
        throw new ArgumentNullException("dp");
      else
        return this.GetValueEntry(this.LookupEntry(dp.GlobalIndex), dp, (PropertyMetadata) null, RequestFlags.FullyResolved).Value;
    }

    [FriendAccessAllowed]
    internal EffectiveValueEntry GetValueEntry(EntryIndex entryIndex, DependencyProperty dp, PropertyMetadata metadata, RequestFlags requests)
    {
      if (dp.ReadOnly)
      {
        if (metadata == null)
          metadata = dp.GetMetadata(this.DependencyObjectType);
        GetReadOnlyValueCallback onlyValueCallback = metadata.GetReadOnlyValueCallback;
        if (onlyValueCallback != null)
        {
          BaseValueSourceInternal source;
          return new EffectiveValueEntry(dp)
          {
            Value = onlyValueCallback(this, out source),
            BaseValueSourceInternal = source
          };
        }
      }
      EffectiveValueEntry effectiveValueEntry = !entryIndex.Found ? new EffectiveValueEntry(dp, BaseValueSourceInternal.Unknown) : ((requests & RequestFlags.RawEntry) == RequestFlags.FullyResolved ? this.GetEffectiveValue(entryIndex, dp, requests) : this._effectiveValues[(IntPtr) entryIndex.Index]);
      if (effectiveValueEntry.Value == DependencyProperty.UnsetValue)
      {
        if (dp.IsPotentiallyInherited)
        {
          if (metadata == null)
            metadata = dp.GetMetadata(this.DependencyObjectType);
          if (metadata.IsInherited)
          {
            DependencyObject inheritanceParent = this.InheritanceParent;
            if (inheritanceParent != null)
            {
              entryIndex = inheritanceParent.LookupEntry(dp.GlobalIndex);
              if (entryIndex.Found)
              {
                effectiveValueEntry = inheritanceParent.GetEffectiveValue(entryIndex, dp, requests & RequestFlags.DeferredReferences);
                effectiveValueEntry.BaseValueSourceInternal = BaseValueSourceInternal.Inherited;
              }
            }
          }
          if (effectiveValueEntry.Value != DependencyProperty.UnsetValue)
            return effectiveValueEntry;
        }
        if ((requests & RequestFlags.SkipDefault) == RequestFlags.FullyResolved)
        {
          if (dp.IsPotentiallyUsingDefaultValueFactory)
          {
            if (metadata == null)
              metadata = dp.GetMetadata(this.DependencyObjectType);
            if ((requests & (RequestFlags) 20) != RequestFlags.FullyResolved && metadata.UsingDefaultValueFactory)
            {
              effectiveValueEntry.BaseValueSourceInternal = BaseValueSourceInternal.Default;
              effectiveValueEntry.Value = (object) new DeferredMutableDefaultReference(metadata, this, dp);
              return effectiveValueEntry;
            }
          }
          else if (!dp.IsDefaultValueChanged)
            return EffectiveValueEntry.CreateDefaultValueEntry(dp, dp.DefaultMetadata.DefaultValue);
          if (metadata == null)
            metadata = dp.GetMetadata(this.DependencyObjectType);
          return EffectiveValueEntry.CreateDefaultValueEntry(dp, metadata.GetDefaultValue(this, dp));
        }
      }
      return effectiveValueEntry;
    }

    public void SetValue(DependencyProperty dp, object value)
    {
      this.VerifyAccess();
      PropertyMetadata metadata = this.SetupPropertyChange(dp);
      this.SetValueCommon(dp, value, metadata, false, false, OperationType.Unknown, false);
    }

    public void SetCurrentValue(DependencyProperty dp, object value)
    {
      this.VerifyAccess();
      PropertyMetadata metadata = this.SetupPropertyChange(dp);
      this.SetValueCommon(dp, value, metadata, false, true, OperationType.Unknown, false);
    }

    [FriendAccessAllowed]
    internal void SetValue(DependencyProperty dp, bool value)
    {
      this.SetValue(dp, BooleanBoxes.Box(value));
    }

    [FriendAccessAllowed]
    internal void SetCurrentValue(DependencyProperty dp, bool value)
    {
      this.SetCurrentValue(dp, BooleanBoxes.Box(value));
    }

    [FriendAccessAllowed]
    internal void SetValueInternal(DependencyProperty dp, object value)
    {
      this.VerifyAccess();
      PropertyMetadata metadata = this.SetupPropertyChange(dp);
      this.SetValueCommon(dp, value, metadata, false, false, OperationType.Unknown, true);
    }

    [FriendAccessAllowed]
    internal void SetCurrentValueInternal(DependencyProperty dp, object value)
    {
      this.VerifyAccess();
      PropertyMetadata metadata = this.SetupPropertyChange(dp);
      this.SetValueCommon(dp, value, metadata, false, true, OperationType.Unknown, true);
    }

    [FriendAccessAllowed]
    internal void SetDeferredValue(DependencyProperty dp, DeferredReference deferredReference)
    {
      PropertyMetadata metadata = this.SetupPropertyChange(dp);
      this.SetValueCommon(dp, (object) deferredReference, metadata, true, false, OperationType.Unknown, false);
    }

    [FriendAccessAllowed]
    internal void SetCurrentDeferredValue(DependencyProperty dp, DeferredReference deferredReference)
    {
      PropertyMetadata metadata = this.SetupPropertyChange(dp);
      this.SetValueCommon(dp, (object) deferredReference, metadata, true, true, OperationType.Unknown, false);
    }

    [FriendAccessAllowed]
    internal void SetMutableDefaultValue(DependencyProperty dp, object value)
    {
      PropertyMetadata metadata = this.SetupPropertyChange(dp);
      this.SetValueCommon(dp, value, metadata, false, false, OperationType.ChangeMutableDefaultValue, false);
    }

    [FriendAccessAllowed]
    internal void SetValue(DependencyPropertyKey dp, bool value)
    {
      this.SetValue(dp, BooleanBoxes.Box(value));
    }

    public void SetValue(DependencyPropertyKey key, object value)
    {
      this.VerifyAccess();
      DependencyProperty dp;
      PropertyMetadata metadata = this.SetupPropertyChange(key, out dp);
      this.SetValueCommon(dp, value, metadata, false, false, OperationType.Unknown, false);
    }

    [FriendAccessAllowed]
    internal bool ProvideSelfAsInheritanceContext(object value, DependencyProperty dp)
    {
      DependencyObject doValue = value as DependencyObject;
      if (doValue != null)
        return this.ProvideSelfAsInheritanceContext(doValue, dp);
      else
        return false;
    }

    [FriendAccessAllowed]
    internal bool ProvideSelfAsInheritanceContext(DependencyObject doValue, DependencyProperty dp)
    {
      if (doValue == null || !this.ShouldProvideInheritanceContext(doValue, dp) || !(doValue is Freezable) && (!this.CanBeInheritanceContext || doValue.IsInheritanceContextSealed))
        return false;
      DependencyObject inheritanceContext = doValue.InheritanceContext;
      doValue.AddInheritanceContext(this, dp);
      if (this == doValue.InheritanceContext)
        return this != inheritanceContext;
      else
        return false;
    }

    [FriendAccessAllowed]
    internal bool RemoveSelfAsInheritanceContext(object value, DependencyProperty dp)
    {
      DependencyObject doValue = value as DependencyObject;
      if (doValue != null)
        return this.RemoveSelfAsInheritanceContext(doValue, dp);
      else
        return false;
    }

    [FriendAccessAllowed]
    internal bool RemoveSelfAsInheritanceContext(DependencyObject doValue, DependencyProperty dp)
    {
      if (doValue == null || !this.ShouldProvideInheritanceContext(doValue, dp) || !(doValue is Freezable) && (!this.CanBeInheritanceContext || doValue.IsInheritanceContextSealed))
        return false;
      DependencyObject inheritanceContext = doValue.InheritanceContext;
      doValue.RemoveInheritanceContext(this, dp);
      if (this == inheritanceContext)
        return doValue.InheritanceContext != inheritanceContext;
      else
        return false;
    }

    public void ClearValue(DependencyProperty dp)
    {
      this.VerifyAccess();
      PropertyMetadata metadata = this.SetupPropertyChange(dp);
      this.ClearValueCommon(this.LookupEntry(dp.GlobalIndex), dp, metadata);
    }

    public void ClearValue(DependencyPropertyKey key)
    {
      this.VerifyAccess();
      DependencyProperty dp;
      PropertyMetadata metadata = this.SetupPropertyChange(key, out dp);
      this.ClearValueCommon(this.LookupEntry(dp.GlobalIndex), dp, metadata);
    }

    internal bool ContainsValue(DependencyProperty dp)
    {
      EntryIndex entryIndex = this.LookupEntry(dp.GlobalIndex);
      if (!entryIndex.Found)
        return false;
      EffectiveValueEntry effectiveValueEntry = this._effectiveValues[(IntPtr) entryIndex.Index];
      return !object.ReferenceEquals(effectiveValueEntry.IsCoercedWithCurrentValue ? effectiveValueEntry.ModifiedValue.CoercedValue : effectiveValueEntry.LocalValue, DependencyProperty.UnsetValue);
    }

    internal static void ChangeExpressionSources(Expression expr, DependencyObject d, DependencyProperty dp, DependencySource[] newSources)
    {
      if (!expr.ForwardsInvalidations)
      {
        EntryIndex entryIndex = d.LookupEntry(dp.GlobalIndex);
        if (!entryIndex.Found || d._effectiveValues[(IntPtr) entryIndex.Index].LocalValue != expr)
          throw new ArgumentException(MS.Internal.WindowsBase.SR.Get("SourceChangeExpressionMismatch"));
      }
      DependencySource[] sources = expr.GetSources();
      if (sources != null)
        DependencyObject.UpdateSourceDependentLists(d, dp, sources, expr, false);
      if (newSources == null)
        return;
      DependencyObject.UpdateSourceDependentLists(d, dp, newSources, expr, true);
    }

    public void CoerceValue(DependencyProperty dp)
    {
      this.VerifyAccess();
      EntryIndex entryIndex = this.LookupEntry(dp.GlobalIndex);
      PropertyMetadata metadata = dp.GetMetadata(this.DependencyObjectType);
      if (entryIndex.Found)
      {
        EffectiveValueEntry valueEntry = this.GetValueEntry(entryIndex, dp, metadata, RequestFlags.RawEntry);
        if (valueEntry.IsCoercedWithCurrentValue)
        {
          this.SetCurrentValue(dp, valueEntry.ModifiedValue.CoercedValue);
          return;
        }
      }
      EffectiveValueEntry newEntry = new EffectiveValueEntry(dp, FullValueSource.IsCoerced);
      int num = (int) this.UpdateEffectiveValue(entryIndex, dp, metadata, new EffectiveValueEntry(), ref newEntry, false, false, OperationType.Unknown);
    }

    [FriendAccessAllowed]
    internal void InvalidateSubProperty(DependencyProperty dp)
    {
      this.NotifyPropertyChange(new DependencyPropertyChangedEventArgs(dp, dp.GetMetadata(this.DependencyObjectType), this.GetValue(dp)));
    }

    [FriendAccessAllowed]
    internal void NotifySubPropertyChange(DependencyProperty dp)
    {
      this.InvalidateSubProperty(dp);
      Freezable freezable = this as Freezable;
      if (freezable == null)
        return;
      freezable.FireChanged();
    }

    public void InvalidateProperty(DependencyProperty dp)
    {
      this.VerifyAccess();
      if (dp == null)
        throw new ArgumentNullException("dp");
      EffectiveValueEntry newEntry = new EffectiveValueEntry(dp, BaseValueSourceInternal.Unknown);
      int num = (int) this.UpdateEffectiveValue(this.LookupEntry(dp.GlobalIndex), dp, dp.GetMetadata(this.DependencyObjectType), new EffectiveValueEntry(), ref newEntry, false, false, OperationType.Unknown);
    }

    [FriendAccessAllowed]
    internal UpdateResult UpdateEffectiveValue(EntryIndex entryIndex, DependencyProperty dp, PropertyMetadata metadata, EffectiveValueEntry oldEntry, ref EffectiveValueEntry newEntry, bool coerceWithDeferredReference, bool coerceWithCurrentValue, OperationType operationType)
    {
      if (dp == null)
        throw new ArgumentNullException("dp");
      int globalIndex = dp.GlobalIndex;
      if (oldEntry.BaseValueSourceInternal == BaseValueSourceInternal.Unknown)
        oldEntry = this.GetValueEntry(entryIndex, dp, metadata, RequestFlags.RawEntry);
      object oldValue = oldEntry.GetFlattenedEntry(RequestFlags.FullyResolved).Value;
      object controlValue = (object) null;
      if (coerceWithCurrentValue)
      {
        controlValue = newEntry.Value;
        newEntry = new EffectiveValueEntry(dp, FullValueSource.IsCoerced);
      }
      if (newEntry.BaseValueSourceInternal != BaseValueSourceInternal.Unknown && newEntry.BaseValueSourceInternal < oldEntry.BaseValueSourceInternal)
        return (UpdateResult) 0;
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      if (newEntry.Value == DependencyProperty.UnsetValue)
      {
        flag2 = newEntry.FullValueSource == FullValueSource.IsCoerced;
        flag1 = true;
        if (newEntry.BaseValueSourceInternal == BaseValueSourceInternal.Local)
          flag3 = true;
      }
      if (flag1 || !newEntry.IsAnimated && (oldEntry.IsAnimated || oldEntry.IsExpression && newEntry.IsExpression && newEntry.ModifiedValue.BaseValue == oldEntry.ModifiedValue.BaseValue))
      {
        if (!flag2)
        {
          newEntry = this.EvaluateEffectiveValue(entryIndex, dp, metadata, oldEntry, newEntry, operationType);
          entryIndex = this.CheckEntryIndex(entryIndex, globalIndex);
          bool flag4 = newEntry.Value != DependencyProperty.UnsetValue;
          if (!flag4 && metadata.IsInherited)
          {
            DependencyObject inheritanceParent = this.InheritanceParent;
            if (inheritanceParent != null)
            {
              EntryIndex entryIndex1 = inheritanceParent.LookupEntry(dp.GlobalIndex);
              if (entryIndex1.Found)
              {
                flag4 = true;
                newEntry = inheritanceParent._effectiveValues[(IntPtr) entryIndex1.Index].GetFlattenedEntry(RequestFlags.FullyResolved);
                newEntry.BaseValueSourceInternal = BaseValueSourceInternal.Inherited;
              }
            }
          }
          if (!flag4)
            newEntry = EffectiveValueEntry.CreateDefaultValueEntry(dp, metadata.GetDefaultValue(this, dp));
        }
        else if (!oldEntry.HasModifiers)
        {
          newEntry = oldEntry;
        }
        else
        {
          newEntry = new EffectiveValueEntry(dp, oldEntry.BaseValueSourceInternal);
          ModifiedValue modifiedValue = oldEntry.ModifiedValue;
          object baseValue = modifiedValue.BaseValue;
          newEntry.Value = baseValue;
          newEntry.HasExpressionMarker = oldEntry.HasExpressionMarker;
          if (oldEntry.IsExpression)
            newEntry.SetExpressionValue(modifiedValue.ExpressionValue, baseValue);
          if (oldEntry.IsAnimated)
            newEntry.SetAnimatedValue(modifiedValue.AnimatedValue, baseValue);
        }
      }
      if (coerceWithCurrentValue)
      {
        object baseValue = newEntry.GetFlattenedEntry(RequestFlags.CoercionBaseValue).Value;
        this.ProcessCoerceValue(dp, metadata, ref entryIndex, ref globalIndex, ref newEntry, ref oldEntry, ref oldValue, baseValue, controlValue, (CoerceValueCallback) null, coerceWithDeferredReference, coerceWithCurrentValue, false);
        entryIndex = this.CheckEntryIndex(entryIndex, globalIndex);
      }
      if (metadata.CoerceValueCallback != null && (!flag3 || newEntry.FullValueSource != (FullValueSource) 1))
      {
        object baseValue = newEntry.GetFlattenedEntry(RequestFlags.CoercionBaseValue).Value;
        this.ProcessCoerceValue(dp, metadata, ref entryIndex, ref globalIndex, ref newEntry, ref oldEntry, ref oldValue, baseValue, (object) null, metadata.CoerceValueCallback, coerceWithDeferredReference, false, false);
        entryIndex = this.CheckEntryIndex(entryIndex, globalIndex);
      }
      if (dp.DesignerCoerceValueCallback != null)
      {
        this.ProcessCoerceValue(dp, metadata, ref entryIndex, ref globalIndex, ref newEntry, ref oldEntry, ref oldValue, newEntry.GetFlattenedEntry(RequestFlags.FullyResolved).Value, (object) null, dp.DesignerCoerceValueCallback, false, false, true);
        entryIndex = this.CheckEntryIndex(entryIndex, globalIndex);
      }
      UpdateResult updateResult = (UpdateResult) 0;
      if (newEntry.FullValueSource != (FullValueSource) 1)
      {
        bool flag4 = false;
        if (newEntry.BaseValueSourceInternal == BaseValueSourceInternal.Inherited)
        {
          if (DependencyObject.IsTreeWalkOperation(operationType) && (newEntry.IsCoerced || newEntry.IsAnimated))
          {
            operationType = OperationType.Unknown;
            updateResult |= UpdateResult.InheritedValueOverridden;
          }
          else if (!this.IsSelfInheritanceParent)
            flag4 = true;
        }
        if (flag4)
          this.UnsetEffectiveValue(entryIndex, dp, metadata);
        else
          this.SetEffectiveValue(entryIndex, dp, metadata, newEntry, oldEntry);
      }
      else
        this.UnsetEffectiveValue(entryIndex, dp, metadata);
      bool isAValueChange = !this.Equals(dp, oldValue, newEntry.GetFlattenedEntry(RequestFlags.FullyResolved).Value);
      if (isAValueChange)
        updateResult |= UpdateResult.ValueChanged;
      if (isAValueChange || operationType == OperationType.ChangeMutableDefaultValue && oldEntry.BaseValueSourceInternal != newEntry.BaseValueSourceInternal || metadata.IsInherited && oldEntry.BaseValueSourceInternal != newEntry.BaseValueSourceInternal && (operationType != OperationType.AddChild && operationType != OperationType.RemoveChild) && operationType != OperationType.Inherit)
      {
        updateResult |= UpdateResult.NotificationSent;
        this.NotifyPropertyChange(new DependencyPropertyChangedEventArgs(dp, metadata, isAValueChange, oldEntry, newEntry, operationType));
      }
      bool flag5 = oldEntry.FullValueSource == (FullValueSource) 11;
      bool flag6 = newEntry.FullValueSource == (FullValueSource) 11;
      if (updateResult != (UpdateResult) 0 || flag5 != flag6)
      {
        if (flag5)
          this.RemoveSelfAsInheritanceContext(oldEntry.LocalValue, dp);
        if (flag6)
          this.ProvideSelfAsInheritanceContext(newEntry.LocalValue, dp);
      }
      return updateResult;
    }

    [FriendAccessAllowed]
    internal void NotifyPropertyChange(DependencyPropertyChangedEventArgs args)
    {
      this.OnPropertyChanged(args);
      if (!args.IsAValueChange && !args.IsASubPropertyChange)
        return;
      DependencyProperty property1 = args.Property;
      object obj1 = DependencyObject.DependentListMapField.GetValue(this);
      if (obj1 == null)
        return;
      FrugalMap frugalMap = (FrugalMap) obj1;
      object obj2 = frugalMap[property1.GlobalIndex];
      if (obj2 != DependencyProperty.UnsetValue)
      {
        if (((DependentList) obj2).IsEmpty)
          frugalMap[property1.GlobalIndex] = DependencyProperty.UnsetValue;
        else
          ((DependentList) obj2).InvalidateDependents(this, args);
      }
      DependencyProperty property2 = DependencyObject.DirectDependencyProperty;
      object obj3 = frugalMap[property2.GlobalIndex];
      if (obj3 == DependencyProperty.UnsetValue)
        return;
      if (((DependentList) obj3).IsEmpty)
        frugalMap[property2.GlobalIndex] = DependencyProperty.UnsetValue;
      else
        ((DependentList) obj3).InvalidateDependents(this, new DependencyPropertyChangedEventArgs(property2, (PropertyMetadata) null, (object) null));
    }

    internal virtual void EvaluateBaseValueCore(DependencyProperty dp, PropertyMetadata metadata, ref EffectiveValueEntry newEntry)
    {
    }

    internal virtual void EvaluateAnimatedValueCore(DependencyProperty dp, PropertyMetadata metadata, ref EffectiveValueEntry newEntry)
    {
    }

    protected virtual void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
      if (e.Property == null)
      {
        throw new ArgumentException(MS.Internal.WindowsBase.SR.Get("ReferenceIsNull", new object[1]
        {
          (object) "e.Property"
        }), "e");
      }
      else
      {
        if (!e.IsAValueChange && !e.IsASubPropertyChange && e.OperationType != OperationType.ChangeMutableDefaultValue)
          return;
        PropertyMetadata metadata = e.Metadata;
        if (metadata == null || metadata.PropertyChangedCallback == null)
          return;
        metadata.PropertyChangedCallback(this, e);
      }
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    protected internal virtual bool ShouldSerializeProperty(DependencyProperty dp)
    {
      return this.ContainsValue(dp);
    }

    [FriendAccessAllowed]
    internal BaseValueSourceInternal GetValueSource(DependencyProperty dp, PropertyMetadata metadata, out bool hasModifiers)
    {
      bool isExpression;
      bool isAnimated;
      bool isCoerced;
      bool isCurrent;
      return this.GetValueSource(dp, metadata, out hasModifiers, out isExpression, out isAnimated, out isCoerced, out isCurrent);
    }

    [FriendAccessAllowed]
    internal BaseValueSourceInternal GetValueSource(DependencyProperty dp, PropertyMetadata metadata, out bool hasModifiers, out bool isExpression, out bool isAnimated, out bool isCoerced, out bool isCurrent)
    {
      if (dp == null)
        throw new ArgumentNullException("dp");
      EntryIndex entryIndex = this.LookupEntry(dp.GlobalIndex);
      if (entryIndex.Found)
      {
        EffectiveValueEntry effectiveValueEntry = this._effectiveValues[(IntPtr) entryIndex.Index];
        hasModifiers = effectiveValueEntry.HasModifiers;
        isExpression = effectiveValueEntry.IsExpression;
        isAnimated = effectiveValueEntry.IsAnimated;
        isCoerced = effectiveValueEntry.IsCoerced;
        isCurrent = effectiveValueEntry.IsCoercedWithCurrentValue;
        return effectiveValueEntry.BaseValueSourceInternal;
      }
      else
      {
        isExpression = false;
        isAnimated = false;
        isCoerced = false;
        isCurrent = false;
        if (dp.ReadOnly)
        {
          if (metadata == null)
            metadata = dp.GetMetadata(this.DependencyObjectType);
          GetReadOnlyValueCallback onlyValueCallback = metadata.GetReadOnlyValueCallback;
          if (onlyValueCallback != null)
          {
            BaseValueSourceInternal source;
            object obj = onlyValueCallback(this, out source);
            hasModifiers = false;
            return source;
          }
        }
        if (dp.IsPotentiallyInherited)
        {
          if (metadata == null)
            metadata = dp.GetMetadata(this.DependencyObjectType);
          if (metadata.IsInherited)
          {
            DependencyObject inheritanceParent = this.InheritanceParent;
            if (inheritanceParent != null && inheritanceParent.LookupEntry(dp.GlobalIndex).Found)
            {
              hasModifiers = false;
              return BaseValueSourceInternal.Inherited;
            }
          }
        }
        hasModifiers = false;
        return BaseValueSourceInternal.Default;
      }
    }

    public object ReadLocalValue(DependencyProperty dp)
    {
      this.VerifyAccess();
      if (dp == null)
        throw new ArgumentNullException("dp");
      else
        return this.ReadLocalValueEntry(this.LookupEntry(dp.GlobalIndex), dp, false);
    }

    internal object ReadLocalValueEntry(EntryIndex entryIndex, DependencyProperty dp, bool allowDeferredReferences)
    {
      if (!entryIndex.Found)
        return DependencyProperty.UnsetValue;
      EffectiveValueEntry effectiveValueEntry = this._effectiveValues[(IntPtr) entryIndex.Index];
      object obj = effectiveValueEntry.IsCoercedWithCurrentValue ? effectiveValueEntry.ModifiedValue.CoercedValue : effectiveValueEntry.LocalValue;
      if (!allowDeferredReferences && effectiveValueEntry.IsDeferredReference)
      {
        DeferredReference deferredReference = obj as DeferredReference;
        if (deferredReference != null)
          obj = deferredReference.GetValue(effectiveValueEntry.BaseValueSourceInternal);
      }
      if (obj == DependencyObject.ExpressionInAlternativeStore)
        obj = DependencyProperty.UnsetValue;
      return obj;
    }

    public LocalValueEnumerator GetLocalValueEnumerator()
    {
      this.VerifyAccess();
      uint effectiveValuesCount = this.EffectiveValuesCount;
      LocalValueEntry[] snapshot = new LocalValueEntry[(IntPtr) effectiveValuesCount];
      int count = 0;
      for (uint index = 0U; index < effectiveValuesCount; ++index)
      {
        DependencyProperty dp = DependencyProperty.RegisteredPropertyList.List[this._effectiveValues[(IntPtr) index].PropertyIndex];
        if (dp != null)
        {
          object obj = this.ReadLocalValueEntry(new EntryIndex(index), dp, false);
          if (obj != DependencyProperty.UnsetValue)
            snapshot[count++] = new LocalValueEntry(dp, obj);
        }
      }
      return new LocalValueEnumerator(snapshot, count);
    }

    internal static void UpdateSourceDependentLists(DependencyObject d, DependencyProperty dp, DependencySource[] sources, Expression expr, bool add)
    {
      if (sources == null)
        return;
      if (expr.ForwardsInvalidations)
      {
        d = (DependencyObject) null;
        dp = (DependencyProperty) null;
      }
      for (int index = 0; index < sources.Length; ++index)
      {
        DependencySource dependencySource = sources[index];
        if (!dependencySource.DependencyObject.IsSealed)
        {
          object obj1 = DependencyObject.DependentListMapField.GetValue(dependencySource.DependencyObject);
          FrugalMap frugalMap = obj1 == null ? new FrugalMap() : (FrugalMap) obj1;
          object obj2 = frugalMap[dependencySource.DependencyProperty.GlobalIndex];
          if (add)
          {
            DependentList dependentList;
            if (obj2 == DependencyProperty.UnsetValue)
              frugalMap[dependencySource.DependencyProperty.GlobalIndex] = (object) (dependentList = new DependentList());
            else
              dependentList = (DependentList) obj2;
            dependentList.Add(d, dp, expr);
          }
          else if (obj2 != DependencyProperty.UnsetValue)
          {
            DependentList dependentList = (DependentList) obj2;
            dependentList.Remove(d, dp, expr);
            if (dependentList.IsEmpty)
              frugalMap[dependencySource.DependencyProperty.GlobalIndex] = DependencyProperty.UnsetValue;
          }
          DependencyObject.DependentListMapField.SetValue(dependencySource.DependencyObject, (object) frugalMap);
        }
      }
    }

    internal static void ValidateSources(DependencyObject d, DependencySource[] newSources, Expression expr)
    {
      if (newSources == null)
        return;
      Dispatcher dispatcher1 = d.Dispatcher;
      for (int index = 0; index < newSources.Length; ++index)
      {
        Dispatcher dispatcher2 = newSources[index].DependencyObject.Dispatcher;
        if (dispatcher2 != dispatcher1 && (!expr.SupportsUnboundSources || dispatcher2 != null))
          throw new ArgumentException(MS.Internal.WindowsBase.SR.Get("SourcesMustBeInSameThread"));
      }
    }

    [FriendAccessAllowed]
    internal static void RegisterForAlternativeExpressionStorage(AlternativeExpressionStorageCallback getExpressionCore, out AlternativeExpressionStorageCallback getExpression)
    {
      DependencyObject._getExpressionCore = getExpressionCore;
      getExpression = new AlternativeExpressionStorageCallback(DependencyObject.GetExpression);
    }

    internal bool HasAnyExpression()
    {
      EffectiveValueEntry[] effectiveValues = this.EffectiveValues;
      uint effectiveValuesCount = this.EffectiveValuesCount;
      bool flag = false;
      for (uint index = 0U; index < effectiveValuesCount; ++index)
      {
        DependencyProperty dp = DependencyProperty.RegisteredPropertyList.List[effectiveValues[(IntPtr) index].PropertyIndex];
        if (dp != null && this.HasExpression(new EntryIndex(index), dp))
        {
          flag = true;
          break;
        }
      }
      return flag;
    }

    [FriendAccessAllowed]
    internal bool HasExpression(EntryIndex entryIndex, DependencyProperty dp)
    {
      if (!entryIndex.Found)
        return false;
      EffectiveValueEntry effectiveValueEntry = this._effectiveValues[(IntPtr) entryIndex.Index];
      object localValue = effectiveValueEntry.LocalValue;
      return effectiveValueEntry.HasExpressionMarker || localValue is Expression;
    }

    internal virtual void AddInheritanceContext(DependencyObject context, DependencyProperty property)
    {
    }

    internal virtual void RemoveInheritanceContext(DependencyObject context, DependencyProperty property)
    {
    }

    internal virtual bool ShouldProvideInheritanceContext(DependencyObject target, DependencyProperty property)
    {
      return true;
    }

    [FriendAccessAllowed]
    internal void OnInheritanceContextChanged(EventArgs args)
    {
      EventHandler eventHandler = DependencyObject.InheritanceContextChangedHandlersField.GetValue(this);
      if (eventHandler != null)
        eventHandler((object) this, args);
      this.CanModifyEffectiveValues = false;
      try
      {
        uint effectiveValuesCount = this.EffectiveValuesCount;
        for (uint index = 0U; index < effectiveValuesCount; ++index)
        {
          DependencyProperty dp = DependencyProperty.RegisteredPropertyList.List[this._effectiveValues[(IntPtr) index].PropertyIndex];
          if (dp != null)
          {
            object obj = this.ReadLocalValueEntry(new EntryIndex(index), dp, true);
            if (obj != DependencyProperty.UnsetValue)
            {
              DependencyObject dependencyObject = obj as DependencyObject;
              if (dependencyObject != null && dependencyObject.InheritanceContext == this)
                dependencyObject.OnInheritanceContextChanged(args);
            }
          }
        }
      }
      finally
      {
        this.CanModifyEffectiveValues = true;
      }
      this.OnInheritanceContextChangedCore(args);
    }

    [FriendAccessAllowed]
    internal virtual void OnInheritanceContextChangedCore(EventArgs args)
    {
    }

    [FriendAccessAllowed]
    internal static bool IsTreeWalkOperation(OperationType operation)
    {
      if (operation != OperationType.AddChild && operation != OperationType.RemoveChild)
        return operation == OperationType.Inherit;
      else
        return true;
    }

    [Conditional("DEBUG")]
    internal void Debug_AssertNoInheritanceContextListeners()
    {
    }

    [FriendAccessAllowed]
    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void BeginPropertyInitialization()
    {
      this.IsInPropertyInitialization = true;
    }

    [FriendAccessAllowed]
    internal void EndPropertyInitialization()
    {
      this.IsInPropertyInitialization = false;
      if (this._effectiveValues == null)
        return;
      uint effectiveValuesCount = this.EffectiveValuesCount;
      if ((int) effectiveValuesCount == 0)
        return;
      uint num = effectiveValuesCount;
      if ((double) num / (double) this._effectiveValues.Length >= 0.8)
        return;
      EffectiveValueEntry[] effectiveValueEntryArray = new EffectiveValueEntry[(IntPtr) num];
      Array.Copy((Array) this._effectiveValues, 0L, (Array) effectiveValueEntryArray, 0L, (long) effectiveValuesCount);
      this._effectiveValues = effectiveValueEntryArray;
    }

    [FriendAccessAllowed]
    internal void SetIsSelfInheritanceParent()
    {
      DependencyObject inheritanceParent = this.InheritanceParent;
      if (inheritanceParent != null)
      {
        this.MergeInheritableProperties(inheritanceParent);
        this.SetInheritanceParent((DependencyObject) null);
      }
      this._packedData |= 1048576U;
    }

    [FriendAccessAllowed]
    internal void SynchronizeInheritanceParent(DependencyObject parent)
    {
      if (this.IsSelfInheritanceParent)
        return;
      if (parent != null)
      {
        if (!parent.IsSelfInheritanceParent)
          this.SetInheritanceParent(parent.InheritanceParent);
        else
          this.SetInheritanceParent(parent);
      }
      else
        this.SetInheritanceParent((DependencyObject) null);
    }

    [FriendAccessAllowed]
    internal EntryIndex LookupEntry(int targetIndex)
    {
      uint index1 = 0U;
      uint num = this.EffectiveValuesCount;
      if (num <= 0U)
        return new EntryIndex(0U, false);
      while (num - index1 > 3U)
      {
        uint index2 = (num + index1) / 2U;
        int propertyIndex = this._effectiveValues[(IntPtr) index2].PropertyIndex;
        if (targetIndex == propertyIndex)
          return new EntryIndex(index2);
        if (targetIndex <= propertyIndex)
          num = index2;
        else
          index1 = index2 + 1U;
      }
      do
      {
        int propertyIndex = this._effectiveValues[(IntPtr) index1].PropertyIndex;
        if (propertyIndex == targetIndex)
          return new EntryIndex(index1);
        if (propertyIndex <= targetIndex)
          ++index1;
        else
          break;
      }
      while (index1 < num);
      return new EntryIndex(index1, false);
    }

    internal void SetEffectiveValue(EntryIndex entryIndex, DependencyProperty dp, PropertyMetadata metadata, EffectiveValueEntry newEntry, EffectiveValueEntry oldEntry)
    {
      if (metadata != null && metadata.IsInherited && (newEntry.BaseValueSourceInternal != BaseValueSourceInternal.Inherited || newEntry.IsCoerced || newEntry.IsAnimated) && !this.IsSelfInheritanceParent)
      {
        this.SetIsSelfInheritanceParent();
        entryIndex = this.CheckEntryIndex(entryIndex, dp.GlobalIndex);
      }
      bool flag = false;
      if (oldEntry.HasExpressionMarker && !newEntry.HasExpressionMarker)
      {
        BaseValueSourceInternal valueSourceInternal = newEntry.BaseValueSourceInternal;
        int num;
        switch (valueSourceInternal)
        {
          case BaseValueSourceInternal.ThemeStyle:
          case BaseValueSourceInternal.ThemeStyleTrigger:
          case BaseValueSourceInternal.Style:
          case BaseValueSourceInternal.TemplateTrigger:
          case BaseValueSourceInternal.StyleTrigger:
          case BaseValueSourceInternal.ParentTemplate:
            num = 1;
            break;
          default:
            num = valueSourceInternal == BaseValueSourceInternal.ParentTemplateTrigger ? 1 : 0;
            break;
        }
        flag = num != 0;
      }
      if (flag)
        newEntry.RestoreExpressionMarker();
      else if (oldEntry.IsExpression && oldEntry.ModifiedValue.ExpressionValue == Expression.NoValue)
        newEntry.SetExpressionValue(newEntry.Value, oldEntry.ModifiedValue.BaseValue);
      if (entryIndex.Found)
      {
        this._effectiveValues[(IntPtr) entryIndex.Index] = newEntry;
      }
      else
      {
        this.InsertEntry(newEntry, entryIndex.Index);
        if (metadata == null || !metadata.IsInherited)
          return;
        ++this.InheritableEffectiveValuesCount;
      }
    }

    [FriendAccessAllowed]
    internal void SetEffectiveValue(EntryIndex entryIndex, DependencyProperty dp, int targetIndex, PropertyMetadata metadata, object value, BaseValueSourceInternal valueSource)
    {
      if (metadata != null && metadata.IsInherited && (valueSource != BaseValueSourceInternal.Inherited && !this.IsSelfInheritanceParent))
      {
        this.SetIsSelfInheritanceParent();
        entryIndex = this.CheckEntryIndex(entryIndex, dp.GlobalIndex);
      }
      EffectiveValueEntry entry;
      if (entryIndex.Found)
      {
        entry = this._effectiveValues[(IntPtr) entryIndex.Index];
      }
      else
      {
        entry = new EffectiveValueEntry();
        entry.PropertyIndex = targetIndex;
        this.InsertEntry(entry, entryIndex.Index);
        if (metadata != null && metadata.IsInherited)
          ++this.InheritableEffectiveValuesCount;
      }
      bool hasExpressionMarker = value == DependencyObject.ExpressionInAlternativeStore;
      if (!hasExpressionMarker && entry.HasExpressionMarker && (valueSource == BaseValueSourceInternal.ThemeStyle || valueSource == BaseValueSourceInternal.ThemeStyleTrigger || (valueSource == BaseValueSourceInternal.Style || valueSource == BaseValueSourceInternal.TemplateTrigger) || (valueSource == BaseValueSourceInternal.StyleTrigger || valueSource == BaseValueSourceInternal.ParentTemplate || valueSource == BaseValueSourceInternal.ParentTemplateTrigger)))
      {
        entry.BaseValueSourceInternal = valueSource;
        entry.SetExpressionValue(value, DependencyObject.ExpressionInAlternativeStore);
        entry.ResetAnimatedValue();
        entry.ResetCoercedValue();
      }
      else if (entry.IsExpression && entry.ModifiedValue.ExpressionValue == Expression.NoValue)
      {
        entry.SetExpressionValue(value, entry.ModifiedValue.BaseValue);
      }
      else
      {
        entry.BaseValueSourceInternal = valueSource;
        entry.ResetValue(value, hasExpressionMarker);
      }
      this._effectiveValues[(IntPtr) entryIndex.Index] = entry;
    }

    internal void UnsetEffectiveValue(EntryIndex entryIndex, DependencyProperty dp, PropertyMetadata metadata)
    {
      if (!entryIndex.Found)
        return;
      this.RemoveEntry(entryIndex.Index, dp);
      if (metadata == null || !metadata.IsInherited)
        return;
      --this.InheritableEffectiveValuesCount;
    }

    private void Initialize()
    {
      this.CanBeInheritanceContext = true;
      this.CanModifyEffectiveValues = true;
    }

    private EffectiveValueEntry GetEffectiveValue(EntryIndex entryIndex, DependencyProperty dp, RequestFlags requests)
    {
      EffectiveValueEntry effectiveValueEntry = this._effectiveValues[(IntPtr) entryIndex.Index];
      EffectiveValueEntry flattenedEntry = effectiveValueEntry.GetFlattenedEntry(requests);
      if ((requests & (RequestFlags) 20) != RequestFlags.FullyResolved || !flattenedEntry.IsDeferredReference)
        return flattenedEntry;
      if (!effectiveValueEntry.HasModifiers)
      {
        if (!effectiveValueEntry.HasExpressionMarker)
        {
          object obj = ((DeferredReference) effectiveValueEntry.Value).GetValue(effectiveValueEntry.BaseValueSourceInternal);
          if (!dp.IsValidValue(obj))
          {
            throw new InvalidOperationException(MS.Internal.WindowsBase.SR.Get("InvalidPropertyValue", obj, (object) dp.Name));
          }
          else
          {
            entryIndex = this.CheckEntryIndex(entryIndex, dp.GlobalIndex);
            effectiveValueEntry.Value = obj;
            this._effectiveValues[(IntPtr) entryIndex.Index] = effectiveValueEntry;
            return effectiveValueEntry;
          }
        }
      }
      else
      {
        ModifiedValue modifiedValue = effectiveValueEntry.ModifiedValue;
        DeferredReference deferredReference = (DeferredReference) null;
        bool flag = false;
        if (effectiveValueEntry.IsCoercedWithCurrentValue && !effectiveValueEntry.IsAnimated)
          deferredReference = modifiedValue.CoercedValue as DeferredReference;
        if (deferredReference == null && effectiveValueEntry.IsExpression && (!effectiveValueEntry.IsAnimated && !effectiveValueEntry.IsCoerced))
        {
          deferredReference = (DeferredReference) modifiedValue.ExpressionValue;
          flag = true;
        }
        if (deferredReference == null)
          return flattenedEntry;
        object obj = deferredReference.GetValue(effectiveValueEntry.BaseValueSourceInternal);
        if (!dp.IsValidValue(obj))
        {
          throw new InvalidOperationException(MS.Internal.WindowsBase.SR.Get("InvalidPropertyValue", obj, (object) dp.Name));
        }
        else
        {
          entryIndex = this.CheckEntryIndex(entryIndex, dp.GlobalIndex);
          if (flag)
            effectiveValueEntry.SetExpressionValue(obj, modifiedValue.BaseValue);
          else
            effectiveValueEntry.SetCoercedValue(obj, (object) null, true, effectiveValueEntry.IsCoercedWithCurrentValue);
          this._effectiveValues[(IntPtr) entryIndex.Index] = effectiveValueEntry;
          flattenedEntry.Value = obj;
        }
      }
      return flattenedEntry;
    }

    private PropertyMetadata SetupPropertyChange(DependencyProperty dp)
    {
      if (dp == null)
        throw new ArgumentNullException("dp");
      if (!dp.ReadOnly)
        return dp.GetMetadata(this.DependencyObjectType);
      throw new InvalidOperationException(MS.Internal.WindowsBase.SR.Get("ReadOnlyChangeNotAllowed", new object[1]
      {
        (object) dp.Name
      }));
    }

    private PropertyMetadata SetupPropertyChange(DependencyPropertyKey key, out DependencyProperty dp)
    {
      if (key == null)
        throw new ArgumentNullException("key");
      dp = key.DependencyProperty;
      dp.VerifyReadOnlyKey(key);
      return dp.GetMetadata(this.DependencyObjectType);
    }

    private void SetValueCommon(DependencyProperty dp, object value, PropertyMetadata metadata, bool coerceWithDeferredReference, bool coerceWithCurrentValue, OperationType operationType, bool isInternal)
    {
      if (this.IsSealed)
      {
        throw new InvalidOperationException(MS.Internal.WindowsBase.SR.Get("SetOnReadOnlyObjectNotAllowed", new object[1]
        {
          (object) this
        }));
      }
      else
      {
        Expression expr1 = (Expression) null;
        DependencySource[] dependencySourceArray = (DependencySource[]) null;
        EntryIndex entryIndex1 = this.LookupEntry(dp.GlobalIndex);
        if (value == DependencyProperty.UnsetValue)
        {
          this.ClearValueCommon(entryIndex1, dp, metadata);
        }
        else
        {
          bool flag1 = false;
          bool flag2 = value == DependencyObject.ExpressionInAlternativeStore;
          if (!flag2)
          {
            bool flag3 = isInternal ? dp.IsValidValueInternal(value) : dp.IsValidValue(value);
            if (!flag3 || dp.IsObjectType)
            {
              expr1 = value as Expression;
              if (expr1 != null)
              {
                if (!expr1.Attachable)
                  throw new ArgumentException(MS.Internal.WindowsBase.SR.Get("SharingNonSharableExpression"));
                dependencySourceArray = expr1.GetSources();
                DependencyObject.ValidateSources(this, dependencySourceArray, expr1);
              }
              else
              {
                flag1 = value is DeferredReference;
                if (!flag1 && !flag3)
                  throw new ArgumentException(MS.Internal.WindowsBase.SR.Get("InvalidPropertyValue", value, (object) dp.Name));
              }
            }
          }
          EffectiveValueEntry oldEntry;
          if (operationType == OperationType.ChangeMutableDefaultValue)
          {
            oldEntry = new EffectiveValueEntry(dp, BaseValueSourceInternal.Default);
            oldEntry.Value = value;
          }
          else
            oldEntry = this.GetValueEntry(entryIndex1, dp, metadata, RequestFlags.RawEntry);
          Expression expr2 = oldEntry.HasExpressionMarker ? DependencyObject._getExpressionCore(this, dp, metadata) : (oldEntry.IsExpression ? oldEntry.LocalValue as Expression : (Expression) null);
          bool flag4 = false;
          if (expr2 != null && expr1 == null)
          {
            if (flag1)
              value = ((DeferredReference) value).GetValue(BaseValueSourceInternal.Local);
            flag4 = expr2.SetValue(this, dp, value);
            entryIndex1 = this.CheckEntryIndex(entryIndex1, dp.GlobalIndex);
          }
          EffectiveValueEntry newEntry;
          if (flag4)
          {
            newEntry = !entryIndex1.Found ? EffectiveValueEntry.CreateDefaultValueEntry(dp, metadata.GetDefaultValue(this, dp)) : this._effectiveValues[(IntPtr) entryIndex1.Index];
            coerceWithCurrentValue = false;
          }
          else
          {
            if (coerceWithCurrentValue && expr2 != null)
              expr2 = (Expression) null;
            newEntry = new EffectiveValueEntry(dp, BaseValueSourceInternal.Local);
            if (expr2 != null)
            {
              DependencySource[] sources = expr2.GetSources();
              DependencyObject.UpdateSourceDependentLists(this, dp, sources, expr2, false);
              expr2.OnDetach(this, dp);
              expr2.MarkDetached();
              entryIndex1 = this.CheckEntryIndex(entryIndex1, dp.GlobalIndex);
            }
            if (expr1 == null)
            {
              newEntry.HasExpressionMarker = flag2;
              newEntry.Value = value;
            }
            else
            {
              this.SetEffectiveValue(entryIndex1, dp, dp.GlobalIndex, metadata, (object) expr1, BaseValueSourceInternal.Local);
              object defaultValue = metadata.GetDefaultValue(this, dp);
              EntryIndex entryIndex2 = this.CheckEntryIndex(entryIndex1, dp.GlobalIndex);
              this.SetExpressionValue(entryIndex2, defaultValue, (object) expr1);
              DependencyObject.UpdateSourceDependentLists(this, dp, dependencySourceArray, expr1, true);
              expr1.MarkAttached();
              expr1.OnAttach(this, dp);
              EntryIndex entryIndex3 = this.CheckEntryIndex(entryIndex2, dp.GlobalIndex);
              newEntry = this.EvaluateExpression(entryIndex3, dp, expr1, metadata, oldEntry, this._effectiveValues[(IntPtr) entryIndex3.Index]);
              entryIndex1 = this.CheckEntryIndex(entryIndex3, dp.GlobalIndex);
            }
          }
          int num = (int) this.UpdateEffectiveValue(entryIndex1, dp, metadata, oldEntry, ref newEntry, coerceWithDeferredReference, coerceWithCurrentValue, operationType);
        }
      }
    }

    private void ClearValueCommon(EntryIndex entryIndex, DependencyProperty dp, PropertyMetadata metadata)
    {
      if (this.IsSealed)
      {
        throw new InvalidOperationException(MS.Internal.WindowsBase.SR.Get("ClearOnReadOnlyObjectNotAllowed", new object[1]
        {
          (object) this
        }));
      }
      else
      {
        EffectiveValueEntry valueEntry = this.GetValueEntry(entryIndex, dp, metadata, RequestFlags.RawEntry);
        object localValue = valueEntry.LocalValue;
        Expression expr = valueEntry.IsExpression ? localValue as Expression : (Expression) null;
        if (expr != null)
        {
          DependencySource[] sources = expr.GetSources();
          DependencyObject.UpdateSourceDependentLists(this, dp, sources, expr, false);
          expr.OnDetach(this, dp);
          expr.MarkDetached();
          entryIndex = this.CheckEntryIndex(entryIndex, dp.GlobalIndex);
        }
        EffectiveValueEntry newEntry = new EffectiveValueEntry(dp, BaseValueSourceInternal.Local);
        int num = (int) this.UpdateEffectiveValue(entryIndex, dp, metadata, valueEntry, ref newEntry, false, false, OperationType.Unknown);
      }
    }

    private void ProcessCoerceValue(DependencyProperty dp, PropertyMetadata metadata, ref EntryIndex entryIndex, ref int targetIndex, ref EffectiveValueEntry newEntry, ref EffectiveValueEntry oldEntry, ref object oldValue, object baseValue, object controlValue, CoerceValueCallback coerceValueCallback, bool coerceWithDeferredReference, bool coerceWithCurrentValue, bool skipBaseValueChecks)
    {
      if (newEntry.IsDeferredReference && (!coerceWithDeferredReference || dp.OwnerType != metadata.CoerceValueCallback.Method.DeclaringType))
      {
        baseValue = ((DeferredReference) baseValue).GetValue(newEntry.BaseValueSourceInternal);
        newEntry.SetCoersionBaseValue(baseValue);
        entryIndex = this.CheckEntryIndex(entryIndex, targetIndex);
      }
      object obj = coerceWithCurrentValue ? controlValue : coerceValueCallback(this, baseValue);
      entryIndex = this.CheckEntryIndex(entryIndex, targetIndex);
      if (this.Equals(dp, obj, baseValue))
        return;
      if (obj == DependencyProperty.UnsetValue)
      {
        if (oldEntry.IsDeferredReference)
        {
          DeferredReference deferredReference = (DeferredReference) oldValue;
          oldValue = deferredReference.GetValue(oldEntry.BaseValueSourceInternal);
          entryIndex = this.CheckEntryIndex(entryIndex, targetIndex);
        }
        obj = oldValue;
      }
      if (!dp.IsValidValue(obj) && (!coerceWithCurrentValue || !(obj is DeferredReference)))
        throw new ArgumentException(MS.Internal.WindowsBase.SR.Get("InvalidPropertyValue", obj, (object) dp.Name));
      else
        newEntry.SetCoercedValue(obj, baseValue, skipBaseValueChecks, coerceWithCurrentValue);
    }

    private EffectiveValueEntry EvaluateExpression(EntryIndex entryIndex, DependencyProperty dp, Expression expr, PropertyMetadata metadata, EffectiveValueEntry oldEntry, EffectiveValueEntry newEntry)
    {
      object obj = expr.GetValue(this, dp);
      if (obj != DependencyProperty.UnsetValue && obj != Expression.NoValue)
      {
        if (!(obj is DeferredReference) && !dp.IsValidValue(obj))
          throw new InvalidOperationException(MS.Internal.WindowsBase.SR.Get("InvalidPropertyValue", obj, (object) dp.Name));
      }
      else
      {
        if (obj == Expression.NoValue)
        {
          newEntry.SetExpressionValue(Expression.NoValue, (object) expr);
          if (!dp.ReadOnly)
          {
            this.EvaluateBaseValueCore(dp, metadata, ref newEntry);
            obj = newEntry.GetFlattenedEntry(RequestFlags.FullyResolved).Value;
          }
          else
            obj = DependencyProperty.UnsetValue;
        }
        if (obj == DependencyProperty.UnsetValue)
          obj = metadata.GetDefaultValue(this, dp);
      }
      newEntry.SetExpressionValue(obj, (object) expr);
      return newEntry;
    }

    private EffectiveValueEntry EvaluateEffectiveValue(EntryIndex entryIndex, DependencyProperty dp, PropertyMetadata metadata, EffectiveValueEntry oldEntry, EffectiveValueEntry newEntry, OperationType operationType)
    {
      object obj = DependencyProperty.UnsetValue;
      bool flag1 = newEntry.BaseValueSourceInternal == BaseValueSourceInternal.Local;
      bool flag2 = flag1 && newEntry.Value == DependencyProperty.UnsetValue;
      bool flag3 = false;
      if (flag2)
      {
        newEntry.BaseValueSourceInternal = BaseValueSourceInternal.Unknown;
      }
      else
      {
        obj = flag1 ? newEntry.LocalValue : oldEntry.LocalValue;
        if (obj == DependencyObject.ExpressionInAlternativeStore)
          obj = DependencyProperty.UnsetValue;
        else
          flag3 = flag1 ? newEntry.IsExpression : oldEntry.IsExpression;
      }
      if (obj != DependencyProperty.UnsetValue)
      {
        newEntry = new EffectiveValueEntry(dp, BaseValueSourceInternal.Local);
        newEntry.Value = obj;
        if (flag3)
        {
          newEntry = this.EvaluateExpression(entryIndex, dp, (Expression) obj, metadata, oldEntry, newEntry);
          entryIndex = this.CheckEntryIndex(entryIndex, dp.GlobalIndex);
          obj = newEntry.ModifiedValue.ExpressionValue;
        }
      }
      if (!dp.ReadOnly)
      {
        this.EvaluateBaseValueCore(dp, metadata, ref newEntry);
        if (newEntry.BaseValueSourceInternal == BaseValueSourceInternal.Unknown)
          newEntry = EffectiveValueEntry.CreateDefaultValueEntry(dp, metadata.GetDefaultValue(this, dp));
        obj = newEntry.GetFlattenedEntry(RequestFlags.FullyResolved).Value;
        entryIndex = this.CheckEntryIndex(entryIndex, dp.GlobalIndex);
        if (oldEntry.IsAnimated)
        {
          newEntry.ResetCoercedValue();
          this.EvaluateAnimatedValueCore(dp, metadata, ref newEntry);
          obj = newEntry.GetFlattenedEntry(RequestFlags.FullyResolved).Value;
        }
      }
      if (obj == DependencyProperty.UnsetValue)
        newEntry = EffectiveValueEntry.CreateDefaultValueEntry(dp, metadata.GetDefaultValue(this, dp));
      return newEntry;
    }

    private static Expression GetExpression(DependencyObject d, DependencyProperty dp, PropertyMetadata metadata)
    {
      EntryIndex entryIndex = d.LookupEntry(dp.GlobalIndex);
      if (!entryIndex.Found)
        return (Expression) null;
      EffectiveValueEntry effectiveValueEntry = d._effectiveValues[(IntPtr) entryIndex.Index];
      if (effectiveValueEntry.HasExpressionMarker)
      {
        if (DependencyObject._getExpressionCore != null)
          return DependencyObject._getExpressionCore(d, dp, metadata);
        else
          return (Expression) null;
      }
      else if (effectiveValueEntry.IsExpression)
        return (Expression) effectiveValueEntry.LocalValue;
      else
        return (Expression) null;
    }

    private void SetInheritanceParent(DependencyObject newParent)
    {
      if (this._contextStorage != null)
      {
        this._contextStorage = (object) newParent;
      }
      else
      {
        if (newParent == null)
          return;
        if (this.IsSelfInheritanceParent)
          this.MergeInheritableProperties(newParent);
        else
          this._contextStorage = (object) newParent;
      }
    }

    private void MergeInheritableProperties(DependencyObject inheritanceParent)
    {
      EffectiveValueEntry[] effectiveValues = inheritanceParent.EffectiveValues;
      uint effectiveValuesCount = inheritanceParent.EffectiveValuesCount;
      for (uint index = 0U; index < effectiveValuesCount; ++index)
      {
        EffectiveValueEntry effectiveValueEntry = effectiveValues[(IntPtr) index];
        DependencyProperty dp = DependencyProperty.RegisteredPropertyList.List[effectiveValueEntry.PropertyIndex];
        if (dp != null)
        {
          PropertyMetadata metadata = dp.GetMetadata(this.DependencyObjectType);
          if (metadata.IsInherited)
          {
            object obj = inheritanceParent.GetValueEntry(new EntryIndex(index), dp, metadata, (RequestFlags) 12).Value;
            if (obj != DependencyProperty.UnsetValue)
              this.SetEffectiveValue(this.LookupEntry(dp.GlobalIndex), dp, dp.GlobalIndex, metadata, obj, BaseValueSourceInternal.Inherited);
          }
        }
      }
    }

    private EntryIndex CheckEntryIndex(EntryIndex entryIndex, int targetIndex)
    {
      if (this.EffectiveValuesCount > 0U && (long) this._effectiveValues.Length > (long) entryIndex.Index && this._effectiveValues[(IntPtr) entryIndex.Index].PropertyIndex == targetIndex)
        return new EntryIndex(entryIndex.Index);
      else
        return this.LookupEntry(targetIndex);
    }

    private void InsertEntry(EffectiveValueEntry entry, uint entryIndex)
    {
      if (!this.CanModifyEffectiveValues)
        throw new InvalidOperationException(MS.Internal.WindowsBase.SR.Get("LocalValueEnumerationInvalidated"));
      uint effectiveValuesCount = this.EffectiveValuesCount;
      if (effectiveValuesCount > 0U)
      {
        if ((long) this._effectiveValues.Length == (long) effectiveValuesCount)
        {
          int length = (int) ((double) effectiveValuesCount * (this.IsInPropertyInitialization ? 2.0 : 1.2));
          if ((long) length == (long) effectiveValuesCount)
            ++length;
          EffectiveValueEntry[] effectiveValueEntryArray = new EffectiveValueEntry[length];
          Array.Copy((Array) this._effectiveValues, 0L, (Array) effectiveValueEntryArray, 0L, (long) entryIndex);
          effectiveValueEntryArray[(IntPtr) entryIndex] = entry;
          Array.Copy((Array) this._effectiveValues, (long) entryIndex, (Array) effectiveValueEntryArray, (long) (entryIndex + 1U), (long) (effectiveValuesCount - entryIndex));
          this._effectiveValues = effectiveValueEntryArray;
        }
        else
        {
          Array.Copy((Array) this._effectiveValues, (long) entryIndex, (Array) this._effectiveValues, (long) (entryIndex + 1U), (long) (effectiveValuesCount - entryIndex));
          this._effectiveValues[(IntPtr) entryIndex] = entry;
        }
      }
      else
      {
        if (this._effectiveValues == null)
          this._effectiveValues = new EffectiveValueEntry[this.EffectiveValuesInitialSize];
        this._effectiveValues[0] = entry;
      }
      this.EffectiveValuesCount = effectiveValuesCount + 1U;
    }

    private void RemoveEntry(uint entryIndex, DependencyProperty dp)
    {
      if (!this.CanModifyEffectiveValues)
        throw new InvalidOperationException(MS.Internal.WindowsBase.SR.Get("LocalValueEnumerationInvalidated"));
      uint effectiveValuesCount = this.EffectiveValuesCount;
      Array.Copy((Array) this._effectiveValues, (long) (entryIndex + 1U), (Array) this._effectiveValues, (long) entryIndex, (long) (uint) ((int) effectiveValuesCount - (int) entryIndex - 1));
      uint num = effectiveValuesCount - 1U;
      this.EffectiveValuesCount = num;
      this._effectiveValues[(IntPtr) num].Clear();
    }

    private void SetExpressionValue(EntryIndex entryIndex, object value, object baseValue)
    {
      EffectiveValueEntry effectiveValueEntry = this._effectiveValues[(IntPtr) entryIndex.Index];
      effectiveValueEntry.SetExpressionValue(value, baseValue);
      effectiveValueEntry.ResetAnimatedValue();
      effectiveValueEntry.ResetCoercedValue();
      this._effectiveValues[(IntPtr) entryIndex.Index] = effectiveValueEntry;
    }

    private bool Equals(DependencyProperty dp, object value1, object value2)
    {
      if (dp.IsValueType || dp.IsStringType)
        return object.Equals(value1, value2);
      else
        return object.ReferenceEquals(value1, value2);
    }
  }
}
