// Type: System.Windows.Media.Visual
// Assembly: PresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\WPF\PresentationCore.dll

using MS.Internal;
using MS.Internal.Media;
using MS.Internal.Media3D;
using MS.Internal.PresentationCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Composition;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace System.Windows.Media
{
  public abstract class Visual : DependencyObject, DUCE.IResource
  {
    internal static readonly UncommonField<BitmapEffectState> BitmapEffectStateField = new UncommonField<BitmapEffectState>();
    private static readonly UncommonField<Dictionary<ICyclicBrush, int>> CyclicBrushToChannelsMapField = new UncommonField<Dictionary<ICyclicBrush, int>>();
    private static readonly UncommonField<Dictionary<DUCE.Channel, int>> ChannelsToCyclicBrushMapField = new UncommonField<Dictionary<DUCE.Channel, int>>();
    private static readonly UncommonField<Geometry> ClipField = new UncommonField<Geometry>();
    private static readonly UncommonField<double> OpacityField = new UncommonField<double>(1.0);
    private static readonly UncommonField<Brush> OpacityMaskField = new UncommonField<Brush>();
    private static readonly UncommonField<EdgeMode> EdgeModeField = new UncommonField<EdgeMode>();
    private static readonly UncommonField<BitmapScalingMode> BitmapScalingModeField = new UncommonField<BitmapScalingMode>();
    private static readonly UncommonField<ClearTypeHint> ClearTypeHintField = new UncommonField<ClearTypeHint>();
    private static readonly UncommonField<Transform> TransformField = new UncommonField<Transform>();
    private static readonly UncommonField<Effect> EffectField = new UncommonField<Effect>();
    private static readonly UncommonField<CacheMode> CacheModeField = new UncommonField<CacheMode>();
    private static readonly UncommonField<DoubleCollection> GuidelinesXField = new UncommonField<DoubleCollection>();
    private static readonly UncommonField<DoubleCollection> GuidelinesYField = new UncommonField<DoubleCollection>();
    private static readonly UncommonField<Visual.AncestorChangedEventHandler> AncestorChangedEventField = new UncommonField<Visual.AncestorChangedEventHandler>();
    private static readonly UncommonField<BitmapEffectState> UserProvidedBitmapEffectData = new UncommonField<BitmapEffectState>();
    private static readonly UncommonField<Rect?> ScrollableAreaClipField = new UncommonField<Rect?>(new Rect?());
    private static readonly UncommonField<TextRenderingMode> TextRenderingModeField = new UncommonField<TextRenderingMode>();
    private static readonly UncommonField<TextHintingMode> TextHintingModeField = new UncommonField<TextHintingMode>();
    private Rect _bboxSubgraph = Rect.Empty;
    internal int _parentIndex;
    internal DependencyObject _parent;
    internal VisualProxy _proxy;
    private Vector _offset;
    private VisualFlags _flags;
    private const VisualProxyFlags c_ProxyFlagsDirtyMask = 8160255U;
    private const VisualProxyFlags c_Viewport3DProxyFlagsDirtyMask = 24576U;
    private const uint TreeLevelLimit = 2047U;

    internal bool IsVisualChildrenIterationInProgress
    {
      [FriendAccessAllowed, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.CheckFlagsAnd(VisualFlags.IsVisualChildrenIterationInProgress);
      }
      [FriendAccessAllowed, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.SetFlags(value, VisualFlags.IsVisualChildrenIterationInProgress);
      }
    }

    internal bool IsRootElement
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.CheckFlagsAnd(VisualFlags.ShouldPostRender);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set
      {
        this.SetFlags(value, VisualFlags.ShouldPostRender);
      }
    }

    internal Rect VisualContentBounds
    {
      get
      {
        this.VerifyAPIReadWrite();
        return this.GetContentBounds();
      }
    }

    internal Rect VisualDescendantBounds
    {
      get
      {
        this.VerifyAPIReadWrite();
        Rect r = this.CalculateSubgraphBoundsInnerSpace();
        if (DoubleUtil.RectHasNaN(r))
        {
          r.X = double.NegativeInfinity;
          r.Y = double.NegativeInfinity;
          r.Width = double.PositiveInfinity;
          r.Height = double.PositiveInfinity;
        }
        return r;
      }
    }

    protected virtual int VisualChildrenCount
    {
      get
      {
        return 0;
      }
    }

    internal int InternalVisualChildrenCount
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.VisualChildrenCount;
      }
    }

    internal virtual int InternalVisual2DOr3DChildrenCount
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.VisualChildrenCount;
      }
    }

    internal bool HasVisualChildren
    {
      get
      {
        return (this._flags & VisualFlags.HasChildren) != VisualFlags.None;
      }
    }

    internal uint TreeLevel
    {
      get
      {
        return (uint) (this._flags & (VisualFlags.TreeLevelBit0 | VisualFlags.TreeLevelBit1 | VisualFlags.TreeLevelBit2 | VisualFlags.TreeLevelBit3 | VisualFlags.TreeLevelBit4 | VisualFlags.TreeLevelBit5 | VisualFlags.TreeLevelBit6 | VisualFlags.TreeLevelBit7 | VisualFlags.TreeLevelBit8 | VisualFlags.TreeLevelBit9 | VisualFlags.TreeLevelBit10)) >> 21;
      }
      set
      {
        if (value > 2047U)
          throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("LayoutManager_DeepRecursion", new object[1]
          {
            (object) 2047
          }));
        else
          this._flags = this._flags & ~(VisualFlags.TreeLevelBit0 | VisualFlags.TreeLevelBit1 | VisualFlags.TreeLevelBit2 | VisualFlags.TreeLevelBit3 | VisualFlags.TreeLevelBit4 | VisualFlags.TreeLevelBit5 | VisualFlags.TreeLevelBit6 | VisualFlags.TreeLevelBit7 | VisualFlags.TreeLevelBit8 | VisualFlags.TreeLevelBit9 | VisualFlags.TreeLevelBit10) | (VisualFlags) ((int) value << 21);
      }
    }

    protected DependencyObject VisualParent
    {
      get
      {
        this.VerifyAPIReadOnly();
        return this.InternalVisualParent;
      }
    }

    internal DependencyObject InternalVisualParent
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._parent;
      }
    }

    protected internal Transform VisualTransform
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.TransformField.GetValue((DependencyObject) this);
      }
      protected set
      {
        this.VerifyAPIReadWrite((DependencyObject) value);
        Transform transform1 = Visual.TransformField.GetValue((DependencyObject) this);
        if (transform1 == value)
          return;
        Transform transform2 = value;
        if (transform2 != null && !transform2.IsFrozen)
          transform2.Changed += this.TransformChangedHandler;
        if (transform1 != null)
        {
          if (!transform1.IsFrozen)
            transform1.Changed -= this.TransformChangedHandler;
          this.DisconnectAttachedResource(VisualProxyFlags.IsTransformDirty, (DUCE.IResource) transform1);
        }
        Visual.TransformField.SetValue((DependencyObject) this, transform2);
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsTransformDirty);
        this.TransformChanged((object) null, (EventArgs) null);
      }
    }

    protected internal Effect VisualEffect
    {
      get
      {
        this.VerifyAPIReadOnly();
        return this.VisualEffectInternal;
      }
      protected set
      {
        this.VerifyAPIReadWrite((DependencyObject) value);
        if (Visual.UserProvidedBitmapEffectData.GetValue((DependencyObject) this) != null)
        {
          if (value != null)
            throw new Exception(MS.Internal.PresentationCore.SR.Get("Effect_CombinedLegacyAndNew"));
        }
        else
          this.VisualEffectInternal = value;
      }
    }

    internal Effect VisualEffectInternal
    {
      get
      {
        if (this.NodeHasLegacyBitmapEffect)
          return (Effect) null;
        else
          return Visual.EffectField.GetValue((DependencyObject) this);
      }
      set
      {
        Effect effect1 = Visual.EffectField.GetValue((DependencyObject) this);
        if (effect1 == value)
          return;
        Effect effect2 = value;
        if (effect2 != null && !effect2.IsFrozen)
          effect2.Changed += this.EffectChangedHandler;
        if (effect1 != null)
        {
          if (!effect1.IsFrozen)
            effect1.Changed -= this.EffectChangedHandler;
          this.DisconnectAttachedResource(VisualProxyFlags.IsEffectDirty, (DUCE.IResource) effect1);
        }
        this.SetFlags(effect2 != null, VisualFlags.NodeHasEffect);
        Visual.EffectField.SetValue((DependencyObject) this, effect2);
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsEffectDirty);
        this.EffectChanged((object) null, (EventArgs) null);
      }
    }

    [Obsolete("BitmapEffects are deprecated and no longer function.  Consider using Effects where appropriate instead.")]
    protected internal BitmapEffect VisualBitmapEffect
    {
      get
      {
        this.VerifyAPIReadOnly();
        BitmapEffectState bitmapEffectState = Visual.UserProvidedBitmapEffectData.GetValue((DependencyObject) this);
        if (bitmapEffectState != null)
          return bitmapEffectState.BitmapEffect;
        else
          return (BitmapEffect) null;
      }
      protected set
      {
        this.VerifyAPIReadWrite((DependencyObject) value);
        Effect effect = Visual.EffectField.GetValue((DependencyObject) this);
        BitmapEffectState bitmapEffectState = Visual.UserProvidedBitmapEffectData.GetValue((DependencyObject) this);
        if (bitmapEffectState == null && effect != null)
        {
          if (value != null)
            throw new Exception(MS.Internal.PresentationCore.SR.Get("Effect_CombinedLegacyAndNew"));
        }
        else
        {
          BitmapEffect bitmapEffect1 = bitmapEffectState == null ? (BitmapEffect) null : bitmapEffectState.BitmapEffect;
          if (bitmapEffect1 == value)
            return;
          BitmapEffect bitmapEffect2 = value;
          if (bitmapEffect2 == null)
          {
            Visual.UserProvidedBitmapEffectData.SetValue((DependencyObject) this, (BitmapEffectState) null);
          }
          else
          {
            if (bitmapEffectState == null)
            {
              bitmapEffectState = new BitmapEffectState();
              Visual.UserProvidedBitmapEffectData.SetValue((DependencyObject) this, bitmapEffectState);
            }
            bitmapEffectState.BitmapEffect = bitmapEffect2;
          }
          if (bitmapEffect2 != null && !bitmapEffect2.IsFrozen)
            bitmapEffect2.Changed += new EventHandler(this.BitmapEffectEmulationChanged);
          if (bitmapEffect1 != null && !bitmapEffect1.IsFrozen)
            bitmapEffect1.Changed -= new EventHandler(this.BitmapEffectEmulationChanged);
          this.BitmapEffectEmulationChanged((object) null, (EventArgs) null);
        }
      }
    }

    [Obsolete("BitmapEffects are deprecated and no longer function.  Consider using Effects where appropriate instead.")]
    protected internal BitmapEffectInput VisualBitmapEffectInput
    {
      get
      {
        this.VerifyAPIReadOnly();
        BitmapEffectState bitmapEffectState = Visual.UserProvidedBitmapEffectData.GetValue((DependencyObject) this);
        if (bitmapEffectState != null)
          return bitmapEffectState.BitmapEffectInput;
        else
          return (BitmapEffectInput) null;
      }
      protected set
      {
        this.VerifyAPIReadWrite((DependencyObject) value);
        Effect effect = Visual.EffectField.GetValue((DependencyObject) this);
        BitmapEffectState bitmapEffectState = Visual.UserProvidedBitmapEffectData.GetValue((DependencyObject) this);
        if (bitmapEffectState == null && effect != null)
        {
          if (value != null)
            throw new Exception(MS.Internal.PresentationCore.SR.Get("Effect_CombinedLegacyAndNew"));
        }
        else
        {
          BitmapEffectInput bitmapEffectInput1 = bitmapEffectState == null ? (BitmapEffectInput) null : bitmapEffectState.BitmapEffectInput;
          BitmapEffectInput bitmapEffectInput2 = value;
          if (bitmapEffectInput1 == bitmapEffectInput2)
            return;
          if (bitmapEffectState == null)
          {
            bitmapEffectState = new BitmapEffectState();
            Visual.UserProvidedBitmapEffectData.SetValue((DependencyObject) this, bitmapEffectState);
          }
          bitmapEffectState.BitmapEffectInput = bitmapEffectInput2;
          if (bitmapEffectInput2 != null && !bitmapEffectInput2.IsFrozen)
            bitmapEffectInput2.Changed += new EventHandler(this.BitmapEffectEmulationChanged);
          if (bitmapEffectInput1 != null && !bitmapEffectInput1.IsFrozen)
            bitmapEffectInput1.Changed -= new EventHandler(this.BitmapEffectEmulationChanged);
          this.BitmapEffectEmulationChanged((object) null, (EventArgs) null);
        }
      }
    }

    internal bool BitmapEffectEmulationDisabled
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.CheckFlagsAnd(VisualFlags.BitmapEffectEmulationDisabled);
      }
      set
      {
        if (value == this.CheckFlagsAnd(VisualFlags.BitmapEffectEmulationDisabled))
          return;
        this.SetFlags(value, VisualFlags.BitmapEffectEmulationDisabled);
        this.BitmapEffectEmulationChanged((object) null, (EventArgs) null);
      }
    }

    internal BitmapEffect VisualBitmapEffectInternal
    {
      get
      {
        this.VerifyAPIReadOnly();
        if (this.NodeHasLegacyBitmapEffect)
          return Visual.BitmapEffectStateField.GetValue((DependencyObject) this).BitmapEffect;
        else
          return (BitmapEffect) null;
      }
      set
      {
        BitmapEffectState bitmapEffectState = Visual.BitmapEffectStateField.GetValue((DependencyObject) this);
        if ((bitmapEffectState == null ? (BitmapEffect) null : bitmapEffectState.BitmapEffect) == value)
          return;
        BitmapEffect bitmapEffect = value;
        if (bitmapEffect == null)
        {
          Visual.BitmapEffectStateField.SetValue((DependencyObject) this, (BitmapEffectState) null);
        }
        else
        {
          if (bitmapEffectState == null)
          {
            bitmapEffectState = new BitmapEffectState();
            Visual.BitmapEffectStateField.SetValue((DependencyObject) this, bitmapEffectState);
          }
          bitmapEffectState.BitmapEffect = bitmapEffect;
        }
      }
    }

    internal BitmapEffectInput VisualBitmapEffectInputInternal
    {
      get
      {
        this.VerifyAPIReadOnly();
        BitmapEffectState bitmapEffectState = Visual.BitmapEffectStateField.GetValue((DependencyObject) this);
        if (bitmapEffectState != null)
          return bitmapEffectState.BitmapEffectInput;
        else
          return (BitmapEffectInput) null;
      }
      set
      {
        this.VerifyAPIReadWrite();
        BitmapEffectState bitmapEffectState = Visual.BitmapEffectStateField.GetValue((DependencyObject) this);
        if ((bitmapEffectState == null ? (BitmapEffectInput) null : bitmapEffectState.BitmapEffectInput) == value)
          return;
        BitmapEffectInput bitmapEffectInput = value;
        if (bitmapEffectState == null)
        {
          bitmapEffectState = new BitmapEffectState();
          Visual.BitmapEffectStateField.SetValue((DependencyObject) this, bitmapEffectState);
        }
        bitmapEffectState.BitmapEffectInput = bitmapEffectInput;
      }
    }

    protected internal CacheMode VisualCacheMode
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.CacheModeField.GetValue((DependencyObject) this);
      }
      protected set
      {
        this.VerifyAPIReadWrite((DependencyObject) value);
        CacheMode cacheMode1 = Visual.CacheModeField.GetValue((DependencyObject) this);
        if (cacheMode1 == value)
          return;
        CacheMode cacheMode2 = value;
        if (cacheMode2 != null && !cacheMode2.IsFrozen)
          cacheMode2.Changed += this.CacheModeChangedHandler;
        if (cacheMode1 != null)
        {
          if (!cacheMode1.IsFrozen)
            cacheMode1.Changed -= this.CacheModeChangedHandler;
          this.DisconnectAttachedResource(VisualProxyFlags.IsCacheModeDirty, (DUCE.IResource) cacheMode1);
        }
        Visual.CacheModeField.SetValue((DependencyObject) this, cacheMode2);
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsCacheModeDirty);
        this.CacheModeChanged((object) null, (EventArgs) null);
      }
    }

    protected internal Rect? VisualScrollableAreaClip
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.ScrollableAreaClipField.GetValue((DependencyObject) this);
      }
      protected set
      {
        this.VerifyAPIReadWrite();
        Rect? nullable1 = Visual.ScrollableAreaClipField.GetValue((DependencyObject) this);
        Rect? nullable2 = value;
        if ((nullable1.HasValue != nullable2.HasValue ? 1 : (!nullable1.HasValue ? 0 : (nullable1.GetValueOrDefault() != nullable2.GetValueOrDefault() ? 1 : 0))) == 0)
          return;
        Visual.ScrollableAreaClipField.SetValue((DependencyObject) this, value);
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsScrollableAreaClipDirty);
        this.ScrollableAreaClipChanged((object) null, (EventArgs) null);
      }
    }

    protected internal Geometry VisualClip
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.ClipField.GetValue((DependencyObject) this);
      }
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] protected set
      {
        this.ChangeVisualClip(value, false);
      }
    }

    protected internal Vector VisualOffset
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._offset;
      }
      protected set
      {
        this.VerifyAPIReadWrite();
        if (!(value != this._offset))
          return;
        this._offset = value;
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsOffsetDirty);
        Visual.PropagateFlags(this, VisualFlags.IsSubtreeDirtyForPrecompute, VisualProxyFlags.IsSubtreeDirtyForRender);
      }
    }

    protected internal double VisualOpacity
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.OpacityField.GetValue((DependencyObject) this);
      }
      protected set
      {
        this.VerifyAPIReadWrite();
        if (Visual.OpacityField.GetValue((DependencyObject) this) == value)
          return;
        Visual.OpacityField.SetValue((DependencyObject) this, value);
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsOpacityDirty);
        Visual.PropagateFlags(this, VisualFlags.None, VisualProxyFlags.IsSubtreeDirtyForRender);
      }
    }

    protected internal EdgeMode VisualEdgeMode
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.EdgeModeField.GetValue((DependencyObject) this);
      }
      protected set
      {
        this.VerifyAPIReadWrite();
        if (Visual.EdgeModeField.GetValue((DependencyObject) this) == value)
          return;
        Visual.EdgeModeField.SetValue((DependencyObject) this, value);
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsEdgeModeDirty);
        Visual.PropagateFlags(this, VisualFlags.None, VisualProxyFlags.IsSubtreeDirtyForRender);
      }
    }

    protected internal BitmapScalingMode VisualBitmapScalingMode
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.BitmapScalingModeField.GetValue((DependencyObject) this);
      }
      protected set
      {
        this.VerifyAPIReadWrite();
        if (Visual.BitmapScalingModeField.GetValue((DependencyObject) this) == value)
          return;
        Visual.BitmapScalingModeField.SetValue((DependencyObject) this, value);
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsBitmapScalingModeDirty);
        Visual.PropagateFlags(this, VisualFlags.None, VisualProxyFlags.IsSubtreeDirtyForRender);
      }
    }

    protected internal ClearTypeHint VisualClearTypeHint
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.ClearTypeHintField.GetValue((DependencyObject) this);
      }
      set
      {
        this.VerifyAPIReadWrite();
        if (Visual.ClearTypeHintField.GetValue((DependencyObject) this) == value)
          return;
        Visual.ClearTypeHintField.SetValue((DependencyObject) this, value);
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsClearTypeHintDirty);
        Visual.PropagateFlags(this, VisualFlags.None, VisualProxyFlags.IsSubtreeDirtyForRender);
      }
    }

    protected internal TextRenderingMode VisualTextRenderingMode
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.TextRenderingModeField.GetValue((DependencyObject) this);
      }
      set
      {
        this.VerifyAPIReadWrite();
        if (Visual.TextRenderingModeField.GetValue((DependencyObject) this) == value)
          return;
        Visual.TextRenderingModeField.SetValue((DependencyObject) this, value);
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsTextRenderingModeDirty);
        Visual.PropagateFlags(this, VisualFlags.None, VisualProxyFlags.IsSubtreeDirtyForRender);
      }
    }

    protected internal TextHintingMode VisualTextHintingMode
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.TextHintingModeField.GetValue((DependencyObject) this);
      }
      set
      {
        this.VerifyAPIReadWrite();
        if (Visual.TextHintingModeField.GetValue((DependencyObject) this) == value)
          return;
        Visual.TextHintingModeField.SetValue((DependencyObject) this, value);
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsTextHintingModeDirty);
        Visual.PropagateFlags(this, VisualFlags.None, VisualProxyFlags.IsSubtreeDirtyForRender);
      }
    }

    protected internal Brush VisualOpacityMask
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.OpacityMaskField.GetValue((DependencyObject) this);
      }
      protected set
      {
        this.VerifyAPIReadWrite((DependencyObject) value);
        Brush brush1 = Visual.OpacityMaskField.GetValue((DependencyObject) this);
        if (brush1 == value)
          return;
        Brush brush2 = value;
        if (brush2 != null && !brush2.IsFrozen)
          brush2.Changed += this.OpacityMaskChangedHandler;
        if (brush1 != null)
        {
          if (!brush1.IsFrozen)
            brush1.Changed -= this.OpacityMaskChangedHandler;
          this.DisconnectAttachedResource(VisualProxyFlags.IsOpacityMaskDirty, (DUCE.IResource) brush1);
        }
        Visual.OpacityMaskField.SetValue((DependencyObject) this, brush2);
        this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsOpacityMaskDirty);
        this.OpacityMaskChanged((object) null, (EventArgs) null);
      }
    }

    protected internal DoubleCollection VisualXSnappingGuidelines
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.GuidelinesXField.GetValue((DependencyObject) this);
      }
      protected set
      {
        this.VerifyAPIReadWrite((DependencyObject) value);
        DoubleCollection doubleCollection1 = Visual.GuidelinesXField.GetValue((DependencyObject) this);
        if (doubleCollection1 == value)
          return;
        DoubleCollection doubleCollection2 = value;
        if (doubleCollection2 != null && !doubleCollection2.IsFrozen)
          doubleCollection2.Changed += this.GuidelinesChangedHandler;
        if (doubleCollection1 != null && !doubleCollection1.IsFrozen)
          doubleCollection1.Changed -= this.GuidelinesChangedHandler;
        Visual.GuidelinesXField.SetValue((DependencyObject) this, doubleCollection2);
        this.GuidelinesChanged((object) null, (EventArgs) null);
      }
    }

    protected internal DoubleCollection VisualYSnappingGuidelines
    {
      get
      {
        this.VerifyAPIReadOnly();
        return Visual.GuidelinesYField.GetValue((DependencyObject) this);
      }
      protected set
      {
        this.VerifyAPIReadWrite((DependencyObject) value);
        DoubleCollection doubleCollection1 = Visual.GuidelinesYField.GetValue((DependencyObject) this);
        if (doubleCollection1 == value)
          return;
        DoubleCollection doubleCollection2 = value;
        if (doubleCollection2 != null && !doubleCollection2.IsFrozen)
          doubleCollection2.Changed += this.GuidelinesChangedHandler;
        if (doubleCollection1 != null && !doubleCollection1.IsFrozen)
          doubleCollection1.Changed -= this.GuidelinesChangedHandler;
        Visual.GuidelinesYField.SetValue((DependencyObject) this, doubleCollection2);
        this.GuidelinesChanged((object) null, (EventArgs) null);
      }
    }

    internal EventHandler ClipChangedHandler
    {
      get
      {
        return new EventHandler(this.ClipChanged);
      }
    }

    internal EventHandler ScrollableAreaClipChangedHandler
    {
      get
      {
        return new EventHandler(this.ScrollableAreaClipChanged);
      }
    }

    internal EventHandler TransformChangedHandler
    {
      get
      {
        return new EventHandler(this.TransformChanged);
      }
    }

    internal EventHandler EffectChangedHandler
    {
      get
      {
        return new EventHandler(this.EffectChanged);
      }
    }

    internal EventHandler CacheModeChangedHandler
    {
      get
      {
        return new EventHandler(this.EffectChanged);
      }
    }

    internal EventHandler GuidelinesChangedHandler
    {
      get
      {
        return new EventHandler(this.GuidelinesChanged);
      }
    }

    internal EventHandler OpacityMaskChangedHandler
    {
      get
      {
        return new EventHandler(this.OpacityMaskChanged);
      }
    }

    internal EventHandler ContentsChangedHandler
    {
      get
      {
        return new EventHandler(this.ContentsChanged);
      }
    }

    bool NodeHasLegacyBitmapEffect
    {
      private get
      {
        if (this.CheckFlagsAnd(VisualFlags.NodeHasEffect))
          return Visual.BitmapEffectStateField.GetValue((DependencyObject) this) != null;
        else
          return false;
      }
    }

    internal event Visual.AncestorChangedEventHandler VisualAncestorChanged
    {
      add
      {
        Visual.AncestorChangedEventHandler changedEventHandler1 = Visual.AncestorChangedEventField.GetValue((DependencyObject) this);
        Visual.AncestorChangedEventHandler changedEventHandler2 = changedEventHandler1 != null ? changedEventHandler1 + value : value;
        Visual.AncestorChangedEventField.SetValue((DependencyObject) this, changedEventHandler2);
        Visual.SetTreeBits((DependencyObject) this, VisualFlags.SubTreeHoldsAncestorChanged, VisualFlags.RegisteredForAncestorChanged);
      }
      remove
      {
        if (this.CheckFlagsAnd(VisualFlags.SubTreeHoldsAncestorChanged))
          Visual.ClearTreeBits((DependencyObject) this, VisualFlags.SubTreeHoldsAncestorChanged, VisualFlags.RegisteredForAncestorChanged);
        Visual.AncestorChangedEventHandler changedEventHandler1 = Visual.AncestorChangedEventField.GetValue((DependencyObject) this);
        if (changedEventHandler1 == null)
          return;
        Visual.AncestorChangedEventHandler changedEventHandler2 = changedEventHandler1 - value;
        if (changedEventHandler2 == null)
          Visual.AncestorChangedEventField.ClearValue((DependencyObject) this);
        else
          Visual.AncestorChangedEventField.SetValue((DependencyObject) this, changedEventHandler2);
      }
    }

    static Visual()
    {
    }

    internal Visual(DUCE.ResourceType resourceType)
    {
      switch (resourceType)
      {
        case DUCE.ResourceType.TYPE_VIEWPORT3DVISUAL:
          this.SetFlags(true, VisualFlags.IsViewport3DVisual);
          break;
      }
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    protected Visual()
      : this(DUCE.ResourceType.TYPE_VISUAL)
    {
    }

    internal bool IsOnChannel(DUCE.Channel channel)
    {
      return this._proxy.IsOnChannel(channel);
    }

    DUCE.ResourceHandle DUCE.IResource.GetHandle(DUCE.Channel channel)
    {
      return this._proxy.GetHandle(channel);
    }

    DUCE.ResourceHandle DUCE.IResource.Get3DHandle(DUCE.Channel channel)
    {
      throw new NotImplementedException();
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    DUCE.ResourceHandle DUCE.IResource.AddRefOnChannel(DUCE.Channel channel)
    {
      return this.AddRefOnChannelCore(channel);
    }

    internal virtual DUCE.ResourceHandle AddRefOnChannelCore(DUCE.Channel channel)
    {
      DUCE.ResourceType resourceType = DUCE.ResourceType.TYPE_VISUAL;
      if (this.CheckFlagsAnd(VisualFlags.IsViewport3DVisual))
        resourceType = DUCE.ResourceType.TYPE_VIEWPORT3DVISUAL;
      this._proxy.CreateOrAddRefOnChannel((object) this, channel, resourceType);
      return this._proxy.GetHandle(channel);
    }

    internal virtual void ReleaseOnChannelCore(DUCE.Channel channel)
    {
      this._proxy.ReleaseOnChannel(channel);
    }

    void DUCE.IResource.RemoveChildFromParent(DUCE.IResource parent, DUCE.Channel channel)
    {
      DUCE.CompositionNode.RemoveChild(parent.GetHandle(channel), this._proxy.GetHandle(channel), channel);
    }

    int DUCE.IResource.GetChannelCount()
    {
      return this._proxy.Count;
    }

    DUCE.Channel DUCE.IResource.GetChannel(int index)
    {
      return this._proxy.GetChannel(index);
    }

    internal virtual Rect GetContentBounds()
    {
      return Rect.Empty;
    }

    internal virtual void RenderContent(RenderContext ctx, bool isOnChannel)
    {
    }

    internal virtual void RenderClose(IDrawingContent newContent)
    {
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal Rect CalculateSubgraphBoundsInnerSpace()
    {
      return this.CalculateSubgraphBoundsInnerSpace(false);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal Rect CalculateSubgraphRenderBoundsInnerSpace()
    {
      return this.CalculateSubgraphBoundsInnerSpace(true);
    }

    internal virtual Rect CalculateSubgraphBoundsInnerSpace(bool renderBounds)
    {
      Rect empty = Rect.Empty;
      int visualChildrenCount = this.VisualChildrenCount;
      for (int index = 0; index < visualChildrenCount; ++index)
      {
        Visual visualChild = this.GetVisualChild(index);
        if (visualChild != null)
        {
          Rect rect = visualChild.CalculateSubgraphBoundsOuterSpace(renderBounds);
          empty.Union(rect);
        }
      }
      Rect bounds = this.GetContentBounds();
      if (renderBounds && this.IsEmptyRenderBounds(ref bounds))
        bounds = Rect.Empty;
      empty.Union(bounds);
      return empty;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal Rect CalculateSubgraphBoundsOuterSpace()
    {
      return this.CalculateSubgraphBoundsOuterSpace(false);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal Rect CalculateSubgraphRenderBoundsOuterSpace()
    {
      return this.CalculateSubgraphBoundsOuterSpace(true);
    }

    private Rect CalculateSubgraphBoundsOuterSpace(bool renderBounds)
    {
      Rect empty = Rect.Empty;
      Rect rect1 = this.CalculateSubgraphBoundsInnerSpace(renderBounds);
      if (this.CheckFlagsAnd(VisualFlags.NodeHasEffect))
      {
        Effect effect = Visual.EffectField.GetValue((DependencyObject) this);
        if (effect != null)
        {
          Rect rect2 = new Rect(0.0, 0.0, 1.0, 1.0);
          Rect rect3 = effect.EffectMapping.TransformBounds(rect2);
          Rect rect4 = new Rect(Effect.UnitToWorld(rect3.TopLeft, rect1), Effect.UnitToWorld(rect3.BottomRight, rect1));
          rect1.Union(rect4);
        }
      }
      Geometry geometry = Visual.ClipField.GetValue((DependencyObject) this);
      if (geometry != null)
        rect1.Intersect(geometry.Bounds);
      Transform transform = Visual.TransformField.GetValue((DependencyObject) this);
      if (transform != null && !transform.IsIdentity)
      {
        Matrix matrix = transform.Value;
        MatrixUtil.TransformRect(ref rect1, ref matrix);
      }
      if (!rect1.IsEmpty)
      {
        rect1.X += this._offset.X;
        rect1.Y += this._offset.Y;
      }
      Rect? nullable = Visual.ScrollableAreaClipField.GetValue((DependencyObject) this);
      if (nullable.HasValue)
        rect1.Intersect(nullable.Value);
      if (DoubleUtil.RectHasNaN(rect1))
      {
        rect1.X = double.NegativeInfinity;
        rect1.Y = double.NegativeInfinity;
        rect1.Width = double.PositiveInfinity;
        rect1.Height = double.PositiveInfinity;
      }
      return rect1;
    }

    internal virtual void FreeContent(DUCE.Channel channel)
    {
    }

    void DUCE.IResource.ReleaseOnChannel(DUCE.Channel channel)
    {
      if (!this.IsOnChannel(channel) || this.CheckFlagsAnd(channel, VisualProxyFlags.IsDeleteResourceInProgress))
        return;
      this.SetFlags(channel, true, VisualProxyFlags.IsDeleteResourceInProgress);
      try
      {
        this.SetFlags(channel, false, VisualProxyFlags.IsConnectedToParent);
        if (this.CheckFlagsOr(VisualFlags.NodeIsCyclicBrushRoot) && channel.IsConnected && (!channel.IsSynchronous && this.IsCyclicBrushRootOnChannel(channel)))
          return;
        this.FreeContent(channel);
        Transform transform = Visual.TransformField.GetValue((DependencyObject) this);
        if (transform != null && !this.CheckFlagsAnd(channel, VisualProxyFlags.IsTransformDirty))
          transform.ReleaseOnChannel(channel);
        Effect effect = Visual.EffectField.GetValue((DependencyObject) this);
        if (effect != null && !this.CheckFlagsAnd(channel, VisualProxyFlags.IsEffectDirty))
          effect.ReleaseOnChannel(channel);
        Geometry geometry = Visual.ClipField.GetValue((DependencyObject) this);
        if (geometry != null && !this.CheckFlagsAnd(channel, VisualProxyFlags.IsClipDirty))
          geometry.ReleaseOnChannel(channel);
        Brush brush = Visual.OpacityMaskField.GetValue((DependencyObject) this);
        if (brush != null && !this.CheckFlagsAnd(channel, VisualProxyFlags.IsOpacityMaskDirty))
          brush.ReleaseOnChannel(channel);
        CacheMode cacheMode = Visual.CacheModeField.GetValue((DependencyObject) this);
        if (cacheMode != null && !this.CheckFlagsAnd(channel, VisualProxyFlags.IsCacheModeDirty))
          cacheMode.ReleaseOnChannel(channel);
        this.ReleaseOnChannelCore(channel);
        int visualChildrenCount = this.VisualChildrenCount;
        for (int index = 0; index < visualChildrenCount; ++index)
        {
          Visual visualChild = this.GetVisualChild(index);
          if (visualChild != null)
            visualChild.ReleaseOnChannel(channel);
        }
      }
      finally
      {
        if (this.IsOnChannel(channel))
          this.SetFlags(channel, false, VisualProxyFlags.IsDeleteResourceInProgress);
      }
    }

    internal virtual void AddRefOnChannelForCyclicBrush(ICyclicBrush cyclicBrush, DUCE.Channel channel)
    {
      Dictionary<DUCE.Channel, int> dictionary1 = Visual.ChannelsToCyclicBrushMapField.GetValue((DependencyObject) this);
      if (dictionary1 == null)
      {
        dictionary1 = new Dictionary<DUCE.Channel, int>();
        Visual.ChannelsToCyclicBrushMapField.SetValue((DependencyObject) this, dictionary1);
      }
      if (!dictionary1.ContainsKey(channel))
      {
        this.SetFlags(true, VisualFlags.NodeIsCyclicBrushRoot);
        dictionary1[channel] = 1;
      }
      else
      {
        Dictionary<DUCE.Channel, int> dictionary2;
        DUCE.Channel index;
        (dictionary2 = dictionary1)[index = channel] = dictionary2[index] + 1;
      }
      Dictionary<ICyclicBrush, int> dictionary3 = Visual.CyclicBrushToChannelsMapField.GetValue((DependencyObject) this);
      if (dictionary3 == null)
      {
        dictionary3 = new Dictionary<ICyclicBrush, int>();
        Visual.CyclicBrushToChannelsMapField.SetValue((DependencyObject) this, dictionary3);
      }
      if (!dictionary3.ContainsKey(cyclicBrush))
      {
        dictionary3[cyclicBrush] = 1;
      }
      else
      {
        Dictionary<ICyclicBrush, int> dictionary2;
        ICyclicBrush index;
        (dictionary2 = dictionary3)[index = cyclicBrush] = dictionary2[index] + 1;
      }
      cyclicBrush.RenderForCyclicBrush(channel, false);
    }

    internal virtual void ReleaseOnChannelForCyclicBrush(ICyclicBrush cyclicBrush, DUCE.Channel channel)
    {
      Dictionary<ICyclicBrush, int> dictionary1 = Visual.CyclicBrushToChannelsMapField.GetValue((DependencyObject) this);
      if (dictionary1[cyclicBrush] == 1)
        dictionary1.Remove(cyclicBrush);
      else
        dictionary1[cyclicBrush] = dictionary1[cyclicBrush] - 1;
      Dictionary<DUCE.Channel, int> dictionary2 = Visual.ChannelsToCyclicBrushMapField.GetValue((DependencyObject) this);
      dictionary2[channel] = dictionary2[channel] - 1;
      if (dictionary2[channel] != 0)
        return;
      dictionary2.Remove(channel);
      this.SetFlags(false, VisualFlags.NodeIsCyclicBrushRoot);
      Visual.PropagateFlags(this, VisualFlags.None, VisualProxyFlags.IsSubtreeDirtyForRender);
      if (this._parent != null && this.CheckFlagsAnd(channel, VisualProxyFlags.IsConnectedToParent) || this.IsRootElement)
        return;
      this.ReleaseOnChannel(channel);
    }

    internal void VerifyAPIReadOnly()
    {
      this.VerifyAccess();
    }

    internal void VerifyAPIReadOnly(DependencyObject value)
    {
      this.VerifyAPIReadOnly();
      MediaSystem.AssertSameContext((DispatcherObject) this, (DispatcherObject) value);
    }

    internal void VerifyAPIReadWrite()
    {
      this.VerifyAPIReadOnly();
      MediaContext.From(this.Dispatcher).VerifyWriteAccess();
    }

    internal void VerifyAPIReadWrite(DependencyObject value)
    {
      this.VerifyAPIReadWrite();
      MediaSystem.AssertSameContext((DispatcherObject) this, (DispatcherObject) value);
    }

    internal void Precompute()
    {
      if (!this.CheckFlagsAnd(VisualFlags.IsSubtreeDirtyForPrecompute))
        return;
      using (this.Dispatcher.DisableProcessing())
      {
        MediaContext mediaContext = MediaContext.From(this.Dispatcher);
        try
        {
          mediaContext.PushReadOnlyAccess();
          Rect bboxSubgraph;
          this.PrecomputeRecursive(out bboxSubgraph);
        }
        finally
        {
          mediaContext.PopReadOnlyAccess();
        }
      }
    }

    internal virtual void PrecomputeContent()
    {
      this._bboxSubgraph = this.GetHitTestBounds();
      if (!DoubleUtil.RectHasNaN(this._bboxSubgraph))
        return;
      this._bboxSubgraph.X = double.NegativeInfinity;
      this._bboxSubgraph.Y = double.NegativeInfinity;
      this._bboxSubgraph.Width = double.PositiveInfinity;
      this._bboxSubgraph.Height = double.PositiveInfinity;
    }

    internal void PrecomputeRecursive(out Rect bboxSubgraph)
    {
      if (this.Enter())
      {
        try
        {
          if (this.CheckFlagsAnd(VisualFlags.IsSubtreeDirtyForPrecompute))
          {
            this.PrecomputeContent();
            int visualChildrenCount = this.VisualChildrenCount;
            for (int index = 0; index < visualChildrenCount; ++index)
            {
              Visual visualChild = this.GetVisualChild(index);
              if (visualChild != null)
              {
                Rect bboxSubgraph1;
                visualChild.PrecomputeRecursive(out bboxSubgraph1);
                this._bboxSubgraph.Union(bboxSubgraph1);
              }
            }
            this.SetFlags(false, VisualFlags.IsSubtreeDirtyForPrecompute);
          }
          bboxSubgraph = this._bboxSubgraph;
          Geometry geometry = Visual.ClipField.GetValue((DependencyObject) this);
          if (geometry != null)
            bboxSubgraph.Intersect(geometry.Bounds);
          Transform transform = Visual.TransformField.GetValue((DependencyObject) this);
          if (transform != null && !transform.IsIdentity)
          {
            Matrix matrix = transform.Value;
            MatrixUtil.TransformRect(ref bboxSubgraph, ref matrix);
          }
          if (!bboxSubgraph.IsEmpty)
          {
            bboxSubgraph.X += this._offset.X;
            bboxSubgraph.Y += this._offset.Y;
          }
          Rect? nullable = Visual.ScrollableAreaClipField.GetValue((DependencyObject) this);
          if (nullable.HasValue)
            bboxSubgraph.Intersect(nullable.Value);
          if (!DoubleUtil.RectHasNaN(bboxSubgraph))
            return;
          bboxSubgraph.X = double.NegativeInfinity;
          bboxSubgraph.Y = double.NegativeInfinity;
          bboxSubgraph.Width = double.PositiveInfinity;
          bboxSubgraph.Height = double.PositiveInfinity;
        }
        finally
        {
          this.Exit();
        }
      }
      else
        bboxSubgraph = new Rect();
    }

    internal void Render(RenderContext ctx, uint childIndex)
    {
      DUCE.Channel channel = ctx.Channel;
      if (this.CheckFlagsAnd(channel, VisualProxyFlags.IsSubtreeDirtyForRender) || !this.IsOnChannel(channel))
        this.RenderRecursive(ctx);
      if (!this.IsOnChannel(channel) || this.CheckFlagsAnd(channel, VisualProxyFlags.IsConnectedToParent) || ctx.Root.IsNull)
        return;
      DUCE.CompositionNode.InsertChildAt(ctx.Root, this._proxy.GetHandle(channel), childIndex, channel);
      this.SetFlags(channel, true, VisualProxyFlags.IsConnectedToParent);
    }

    internal virtual void RenderRecursive(RenderContext ctx)
    {
      if (!this.Enter())
        return;
      try
      {
        DUCE.Channel channel = ctx.Channel;
        DUCE.ResourceHandle resourceHandle = DUCE.ResourceHandle.Null;
        bool isOnChannel = this.IsOnChannel(channel);
        DUCE.ResourceHandle handle;
        VisualProxyFlags flags;
        if (isOnChannel)
        {
          handle = this._proxy.GetHandle(channel);
          flags = this._proxy.GetFlags(channel);
        }
        else
        {
          handle = this.AddRefOnChannel(channel);
          this.SetFlags(channel, true, VisualProxyFlags.Viewport3DVisual_IsCameraDirty | VisualProxyFlags.Viewport3DVisual_IsViewportDirty);
          flags = VisualProxyFlags.IsSubtreeDirtyForRender | VisualProxyFlags.IsTransformDirty | VisualProxyFlags.IsClipDirty | VisualProxyFlags.IsContentDirty | VisualProxyFlags.IsOpacityDirty | VisualProxyFlags.IsOpacityMaskDirty | VisualProxyFlags.IsOffsetDirty | VisualProxyFlags.IsClearTypeHintDirty | VisualProxyFlags.IsGuidelineCollectionDirty | VisualProxyFlags.IsEdgeModeDirty | VisualProxyFlags.IsBitmapScalingModeDirty | VisualProxyFlags.IsEffectDirty | VisualProxyFlags.IsCacheModeDirty | VisualProxyFlags.IsScrollableAreaClipDirty | VisualProxyFlags.IsTextRenderingModeDirty | VisualProxyFlags.IsTextHintingModeDirty;
        }
        this.UpdateCacheMode(channel, handle, flags, isOnChannel);
        this.UpdateTransform(channel, handle, flags, isOnChannel);
        this.UpdateClip(channel, handle, flags, isOnChannel);
        this.UpdateOffset(channel, handle, flags, isOnChannel);
        this.UpdateEffect(channel, handle, flags, isOnChannel);
        this.UpdateGuidelines(channel, handle, flags, isOnChannel);
        this.UpdateContent(ctx, flags, isOnChannel);
        this.UpdateOpacity(channel, handle, flags, isOnChannel);
        this.UpdateOpacityMask(channel, handle, flags, isOnChannel);
        this.UpdateRenderOptions(channel, handle, flags, isOnChannel);
        this.UpdateChildren(ctx, handle);
        this.UpdateScrollableAreaClip(channel, handle, flags, isOnChannel);
        this.SetFlags(channel, false, VisualProxyFlags.IsSubtreeDirtyForRender);
      }
      finally
      {
        this.Exit();
      }
    }

    internal bool Enter()
    {
      if (this.CheckFlagsAnd(VisualFlags.ReentrancyFlag))
        return false;
      this.SetFlags(true, VisualFlags.ReentrancyFlag);
      return true;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void Exit()
    {
      this.SetFlags(false, VisualFlags.ReentrancyFlag);
    }

    internal void InvalidateHitTestBounds()
    {
      this.VerifyAPIReadWrite();
      Visual.PropagateFlags(this, VisualFlags.IsSubtreeDirtyForPrecompute, VisualProxyFlags.None);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal virtual Rect GetHitTestBounds()
    {
      return this.GetContentBounds();
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal HitTestResult HitTest(Point point)
    {
      return this.HitTest(point, true);
    }

    internal HitTestResult HitTest(Point point, bool include2DOn3D)
    {
      Visual.TopMostHitResult topMostHitResult = new Visual.TopMostHitResult();
      VisualTreeHelper.HitTest(this, include2DOn3D ? (HitTestFilterCallback) null : new HitTestFilterCallback(topMostHitResult.NoNested2DFilter), new HitTestResultCallback(topMostHitResult.HitTestResult), (HitTestParameters) new PointHitTestParameters(point));
      return topMostHitResult._hitResult;
    }

    internal void HitTest(HitTestFilterCallback filterCallback, HitTestResultCallback resultCallback, HitTestParameters hitTestParameters)
    {
      if (resultCallback == null)
        throw new ArgumentNullException("resultCallback");
      if (hitTestParameters == null)
        throw new ArgumentNullException("hitTestParameters");
      this.VerifyAPIReadWrite();
      this.Precompute();
      PointHitTestParameters pointParams = hitTestParameters as PointHitTestParameters;
      if (pointParams != null)
      {
        Point hitPoint = pointParams.HitPoint;
        try
        {
          int num = (int) this.HitTestPoint(filterCallback, resultCallback, pointParams);
        }
        catch
        {
          pointParams.SetHitPoint(hitPoint);
          throw;
        }
      }
      else
      {
        GeometryHitTestParameters geometryParams = hitTestParameters as GeometryHitTestParameters;
        if (geometryParams != null)
        {
          try
          {
            int num = (int) this.HitTestGeometry(filterCallback, resultCallback, geometryParams);
          }
          catch
          {
            geometryParams.EmergencyRestoreOriginalTransform();
            throw;
          }
        }
        else
          Invariant.Assert(0 != 0, string.Format((IFormatProvider) CultureInfo.InvariantCulture, "'{0}' HitTestParameters are not supported on {1}.", new object[2]
          {
            (object) hitTestParameters.GetType().Name,
            (object) this.GetType().Name
          }));
      }
    }

    internal HitTestResultBehavior HitTestPoint(HitTestFilterCallback filterCallback, HitTestResultCallback resultCallback, PointHitTestParameters pointParams)
    {
      Geometry visualClip = this.VisualClip;
      if (this._bboxSubgraph.Contains(pointParams.HitPoint) && (visualClip == null || visualClip.FillContains(pointParams.HitPoint)))
      {
        HitTestFilterBehavior testFilterBehavior = HitTestFilterBehavior.Continue;
        if (filterCallback != null)
        {
          testFilterBehavior = filterCallback((DependencyObject) this);
          switch (testFilterBehavior)
          {
            case HitTestFilterBehavior.ContinueSkipSelfAndChildren:
              return HitTestResultBehavior.Continue;
            case HitTestFilterBehavior.Stop:
              return HitTestResultBehavior.Stop;
          }
        }
        Point hitPoint1 = pointParams.HitPoint;
        Point point = hitPoint1;
        if (this.CheckFlagsAnd(VisualFlags.NodeHasEffect))
        {
          Effect effect = Visual.EffectField.GetValue((DependencyObject) this);
          if (effect != null)
          {
            GeneralTransform inverse = effect.EffectMapping.Inverse;
            if (inverse != Transform.Identity)
            {
              bool flag = false;
              Point? nullable = Effect.WorldToUnit(hitPoint1, this._bboxSubgraph);
              if (nullable.HasValue)
              {
                Point result = new Point();
                flag = inverse.TryTransform(nullable.Value, out result);
                if (flag)
                  point = Effect.UnitToWorld(result, this._bboxSubgraph);
              }
              if (!flag)
                return HitTestResultBehavior.Continue;
            }
          }
        }
        if (testFilterBehavior != HitTestFilterBehavior.ContinueSkipChildren)
        {
          for (int index = this.VisualChildrenCount - 1; index >= 0; --index)
          {
            Visual visualChild = this.GetVisualChild(index);
            if (visualChild != null)
            {
              Rect? nullable = Visual.ScrollableAreaClipField.GetValue((DependencyObject) visualChild);
              if (!nullable.HasValue || nullable.Value.Contains(point))
              {
                Point hitPoint2 = point - visualChild._offset;
                Transform transform = Visual.TransformField.GetValue((DependencyObject) visualChild);
                if (transform != null)
                {
                  Matrix matrix = transform.Value;
                  if (matrix.HasInverse)
                  {
                    matrix.Invert();
                    hitPoint2 *= matrix;
                  }
                  else
                    continue;
                }
                pointParams.SetHitPoint(hitPoint2);
                HitTestResultBehavior testResultBehavior = visualChild.HitTestPoint(filterCallback, resultCallback, pointParams);
                pointParams.SetHitPoint(hitPoint1);
                if (testResultBehavior == HitTestResultBehavior.Stop)
                  return HitTestResultBehavior.Stop;
              }
            }
          }
        }
        if (testFilterBehavior != HitTestFilterBehavior.ContinueSkipSelf)
        {
          pointParams.SetHitPoint(point);
          HitTestResultBehavior testResultBehavior = this.HitTestPointInternal(filterCallback, resultCallback, pointParams);
          pointParams.SetHitPoint(hitPoint1);
          if (testResultBehavior == HitTestResultBehavior.Stop)
            return HitTestResultBehavior.Stop;
        }
      }
      return HitTestResultBehavior.Continue;
    }

    internal GeneralTransform TransformToOuterSpace()
    {
      Matrix identity = Matrix.Identity;
      GeneralTransformGroup generalTransformGroup = (GeneralTransformGroup) null;
      if (this.CheckFlagsAnd(VisualFlags.NodeHasEffect))
      {
        Effect effect = Visual.EffectField.GetValue((DependencyObject) this);
        if (effect != null)
        {
          GeneralTransform generalTransform = effect.CoerceToUnitSpaceGeneralTransform(effect.EffectMapping, this.VisualDescendantBounds);
          Transform affineTransform = generalTransform.AffineTransform;
          if (affineTransform != null)
          {
            Matrix matrix2 = affineTransform.Value;
            MatrixUtil.MultiplyMatrix(ref identity, ref matrix2);
          }
          else
          {
            generalTransformGroup = new GeneralTransformGroup();
            generalTransformGroup.Children.Add(generalTransform);
          }
        }
        else
          Visual.BitmapEffectStateField.GetValue((DependencyObject) this);
      }
      Transform transform = Visual.TransformField.GetValue((DependencyObject) this);
      if (transform != null)
      {
        Matrix matrix2 = transform.Value;
        MatrixUtil.MultiplyMatrix(ref identity, ref matrix2);
      }
      identity.Translate(this._offset.X, this._offset.Y);
      GeneralTransform generalTransform1;
      if (generalTransformGroup == null)
      {
        generalTransform1 = (GeneralTransform) new MatrixTransform(identity);
      }
      else
      {
        generalTransformGroup.Children.Add((GeneralTransform) new MatrixTransform(identity));
        generalTransform1 = (GeneralTransform) generalTransformGroup;
      }
      generalTransform1.Freeze();
      return generalTransform1;
    }

    internal HitTestResultBehavior HitTestGeometry(HitTestFilterCallback filterCallback, HitTestResultCallback resultCallback, GeometryHitTestParameters geometryParams)
    {
      Geometry visualClip = this.VisualClip;
      if (visualClip != null && visualClip.FillContainsWithDetail((Geometry) geometryParams.InternalHitGeometry) == IntersectionDetail.Empty || !this._bboxSubgraph.IntersectsWith(geometryParams.Bounds))
        return HitTestResultBehavior.Continue;
      HitTestFilterBehavior testFilterBehavior = HitTestFilterBehavior.Continue;
      if (filterCallback != null)
      {
        testFilterBehavior = filterCallback((DependencyObject) this);
        switch (testFilterBehavior)
        {
          case HitTestFilterBehavior.ContinueSkipSelfAndChildren:
            return HitTestResultBehavior.Continue;
          case HitTestFilterBehavior.Stop:
            return HitTestResultBehavior.Stop;
        }
      }
      int visualChildrenCount = this.VisualChildrenCount;
      if (testFilterBehavior != HitTestFilterBehavior.ContinueSkipChildren)
      {
        for (int index = visualChildrenCount - 1; index >= 0; --index)
        {
          Visual visualChild = this.GetVisualChild(index);
          if (visualChild != null)
          {
            Rect? nullable = Visual.ScrollableAreaClipField.GetValue((DependencyObject) visualChild);
            if (!nullable.HasValue || new RectangleGeometry(nullable.Value).FillContainsWithDetail((Geometry) geometryParams.InternalHitGeometry) != IntersectionDetail.Empty)
            {
              Matrix identity = Matrix.Identity;
              identity.Translate(-visualChild._offset.X, -visualChild._offset.Y);
              Transform transform = Visual.TransformField.GetValue((DependencyObject) visualChild);
              if (transform != null)
              {
                Matrix matrix2 = transform.Value;
                if (matrix2.HasInverse)
                {
                  matrix2.Invert();
                  MatrixUtil.MultiplyMatrix(ref identity, ref matrix2);
                }
                else
                  continue;
              }
              geometryParams.PushMatrix(ref identity);
              HitTestResultBehavior testResultBehavior = visualChild.HitTestGeometry(filterCallback, resultCallback, geometryParams);
              geometryParams.PopMatrix();
              if (testResultBehavior == HitTestResultBehavior.Stop)
                return HitTestResultBehavior.Stop;
            }
          }
        }
      }
      if (testFilterBehavior != HitTestFilterBehavior.ContinueSkipSelf)
      {
        GeometryHitTestResult geometryHitTestResult = this.HitTestCore(geometryParams);
        if (geometryHitTestResult != null)
          return resultCallback((HitTestResult) geometryHitTestResult);
      }
      return HitTestResultBehavior.Continue;
    }

    internal virtual HitTestResultBehavior HitTestPointInternal(HitTestFilterCallback filterCallback, HitTestResultCallback resultCallback, PointHitTestParameters hitTestParameters)
    {
      HitTestResult result = this.HitTestCore(hitTestParameters);
      if (result != null)
        return resultCallback(result);
      else
        return HitTestResultBehavior.Continue;
    }

    protected virtual HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
    {
      if (hitTestParameters == null)
        throw new ArgumentNullException("hitTestParameters");
      if (this.GetHitTestBounds().Contains(hitTestParameters.HitPoint))
        return (HitTestResult) new PointHitTestResult(this, hitTestParameters.HitPoint);
      else
        return (HitTestResult) null;
    }

    protected virtual GeometryHitTestResult HitTestCore(GeometryHitTestParameters hitTestParameters)
    {
      if (hitTestParameters == null)
        throw new ArgumentNullException("hitTestParameters");
      IntersectionDetail intersectionDetail = new RectangleGeometry(this.GetHitTestBounds()).FillContainsWithDetail((Geometry) hitTestParameters.InternalHitGeometry);
      if (intersectionDetail != IntersectionDetail.Empty)
        return new GeometryHitTestResult(this, intersectionDetail);
      else
        return (GeometryHitTestResult) null;
    }

    protected virtual Visual GetVisualChild(int index)
    {
      throw new ArgumentOutOfRangeException("index", (object) index, MS.Internal.PresentationCore.SR.Get("Visual_ArgumentOutOfRange"));
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal Visual InternalGetVisualChild(int index)
    {
      return this.GetVisualChild(index);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal virtual DependencyObject InternalGet2DOr3DVisualChild(int index)
    {
      return (DependencyObject) this.GetVisualChild(index);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void InternalAddVisualChild(Visual child)
    {
      this.AddVisualChild(child);
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void InternalRemoveVisualChild(Visual child)
    {
      this.RemoveVisualChild(child);
    }

    protected void AddVisualChild(Visual child)
    {
      if (child == null)
        return;
      if (child._parent != null)
        throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("Visual_HasParent"));
      this.SetFlags(true, VisualFlags.HasChildren);
      child._parent = (DependencyObject) this;
      Visual.PropagateFlags(this, VisualFlags.IsSubtreeDirtyForPrecompute, VisualProxyFlags.IsSubtreeDirtyForRender);
      Visual.PropagateFlags(child, VisualFlags.IsSubtreeDirtyForPrecompute, VisualProxyFlags.IsSubtreeDirtyForRender);
      UIElement.PropagateResumeLayout(this, child);
      this.OnVisualChildrenChanged((DependencyObject) child, (DependencyObject) null);
      child.FireOnVisualParentChanged((DependencyObject) null);
    }

    protected void RemoveVisualChild(Visual child)
    {
      if (child == null || child._parent == null)
        return;
      if (child._parent != this)
        throw new ArgumentException(MS.Internal.PresentationCore.SR.Get("Visual_NotChild"));
      if (this.InternalVisual2DOr3DChildrenCount == 0)
        this.SetFlags(false, VisualFlags.HasChildren);
      for (int index = 0; index < this._proxy.Count; ++index)
      {
        DUCE.Channel channel = this._proxy.GetChannel(index);
        if (child.CheckFlagsAnd(channel, VisualProxyFlags.IsConnectedToParent))
        {
          child.SetFlags(channel, false, VisualProxyFlags.IsConnectedToParent);
          DUCE.IResource resource = (DUCE.IResource) child;
          resource.RemoveChildFromParent((DUCE.IResource) this, channel);
          resource.ReleaseOnChannel(channel);
        }
      }
      child._parent = (DependencyObject) null;
      Visual.PropagateFlags(this, VisualFlags.IsSubtreeDirtyForPrecompute, VisualProxyFlags.IsSubtreeDirtyForRender);
      UIElement.PropagateSuspendLayout(child);
      child.FireOnVisualParentChanged((DependencyObject) this);
      this.OnVisualChildrenChanged((DependencyObject) null, (DependencyObject) child);
    }

    [FriendAccessAllowed]
    internal void InvalidateZOrder()
    {
      if (this.VisualChildrenCount == 0)
        return;
      Visual.PropagateFlags(this, VisualFlags.IsSubtreeDirtyForPrecompute, VisualProxyFlags.IsSubtreeDirtyForRender);
      this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsChildrenZOrderDirty);
      InputManager.SafeCurrentNotifyHitTestInvalidated();
    }

    [FriendAccessAllowed]
    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void InternalSetOffsetWorkaround(Vector offset)
    {
      this.VisualOffset = offset;
    }

    [FriendAccessAllowed]
    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void InternalSetTransformWorkaround(Transform transform)
    {
      this.VisualTransform = transform;
    }

    internal void BitmapEffectEmulationChanged(object sender, EventArgs e)
    {
      BitmapEffectState bitmapEffectState = Visual.UserProvidedBitmapEffectData.GetValue((DependencyObject) this);
      BitmapEffect bitmapEffect = bitmapEffectState == null ? (BitmapEffect) null : bitmapEffectState.BitmapEffect;
      BitmapEffectInput bitmapEffectInput = bitmapEffectState == null ? (BitmapEffectInput) null : bitmapEffectState.BitmapEffectInput;
      if (bitmapEffect == null)
      {
        this.VisualBitmapEffectInternal = (BitmapEffect) null;
        this.VisualBitmapEffectInputInternal = (BitmapEffectInput) null;
        this.VisualEffectInternal = (Effect) null;
      }
      else if (bitmapEffectInput != null)
      {
        this.VisualEffectInternal = (Effect) null;
        this.VisualBitmapEffectInternal = bitmapEffect;
        this.VisualBitmapEffectInputInternal = bitmapEffectInput;
      }
      else if (RenderCapability.IsShaderEffectSoftwareRenderingSupported && bitmapEffect.CanBeEmulatedUsingEffectPipeline() && !this.CheckFlagsAnd(VisualFlags.BitmapEffectEmulationDisabled))
      {
        this.VisualBitmapEffectInternal = (BitmapEffect) null;
        this.VisualBitmapEffectInputInternal = (BitmapEffectInput) null;
        this.VisualEffectInternal = bitmapEffect.GetEmulatingEffect();
      }
      else
      {
        this.VisualEffectInternal = (Effect) null;
        this.VisualBitmapEffectInputInternal = (BitmapEffectInput) null;
        this.VisualBitmapEffectInternal = bitmapEffect;
      }
    }

    internal void ChangeVisualClip(Geometry newClip, bool dontSetWhenClose)
    {
      this.VerifyAPIReadWrite((DependencyObject) newClip);
      Geometry geometry = Visual.ClipField.GetValue((DependencyObject) this);
      if (geometry == newClip || dontSetWhenClose && geometry != null && (newClip != null && geometry.AreClose(newClip)))
        return;
      if (newClip != null && !newClip.IsFrozen)
        newClip.Changed += this.ClipChangedHandler;
      if (geometry != null)
      {
        if (!geometry.IsFrozen)
          geometry.Changed -= this.ClipChangedHandler;
        this.DisconnectAttachedResource(VisualProxyFlags.IsClipDirty, (DUCE.IResource) geometry);
      }
      Visual.ClipField.SetValue((DependencyObject) this, newClip);
      this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsClipDirty);
      this.ClipChanged((object) null, (EventArgs) null);
    }

    internal void DisconnectAttachedResource(VisualProxyFlags correspondingFlag, DUCE.IResource attachedResource)
    {
      bool flag = correspondingFlag == VisualProxyFlags.IsContentConnected;
      for (int index = 0; index < this._proxy.Count; ++index)
      {
        DUCE.Channel channel = this._proxy.GetChannel(index);
        if ((this._proxy.GetFlags(index) & correspondingFlag) != VisualProxyFlags.None == flag)
        {
          this.SetFlags(channel, true, correspondingFlag);
          attachedResource.ReleaseOnChannel(channel);
          if (flag)
            this._proxy.SetFlags(index, false, VisualProxyFlags.IsContentConnected);
        }
      }
    }

    internal virtual DrawingGroup GetDrawing()
    {
      this.VerifyAPIReadOnly();
      return (DrawingGroup) null;
    }

    internal virtual void FireOnVisualParentChanged(DependencyObject oldParent)
    {
      this.OnVisualParentChanged(oldParent);
      if (oldParent == null)
      {
        if (this.CheckFlagsAnd(VisualFlags.SubTreeHoldsAncestorChanged))
          Visual.SetTreeBits(this._parent, VisualFlags.SubTreeHoldsAncestorChanged, VisualFlags.RegisteredForAncestorChanged);
      }
      else if (this.CheckFlagsAnd(VisualFlags.SubTreeHoldsAncestorChanged))
        Visual.ClearTreeBits(oldParent, VisualFlags.SubTreeHoldsAncestorChanged, VisualFlags.RegisteredForAncestorChanged);
      Visual.ProcessAncestorChangedNotificationRecursive((DependencyObject) this, new AncestorChangedEventArgs((DependencyObject) this, oldParent));
    }

    protected internal virtual void OnVisualParentChanged(DependencyObject oldParent)
    {
    }

    protected internal virtual void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
    {
    }

    internal static void ProcessAncestorChangedNotificationRecursive(DependencyObject e, AncestorChangedEventArgs args)
    {
      if (e is Visual3D)
      {
        Visual3D.ProcessAncestorChangedNotificationRecursive(e, args);
      }
      else
      {
        Visual visual = e as Visual;
        if (!visual.CheckFlagsAnd(VisualFlags.SubTreeHoldsAncestorChanged))
          return;
        Visual.AncestorChangedEventHandler changedEventHandler = Visual.AncestorChangedEventField.GetValue((DependencyObject) visual);
        if (changedEventHandler != null)
          changedEventHandler((object) visual, args);
        int dor3DchildrenCount = visual.InternalVisual2DOr3DChildrenCount;
        for (int index = 0; index < dor3DchildrenCount; ++index)
        {
          DependencyObject e1 = visual.InternalGet2DOr3DVisualChild(index);
          if (e1 != null)
            Visual.ProcessAncestorChangedNotificationRecursive(e1, args);
        }
      }
    }

    public bool IsAncestorOf(DependencyObject descendant)
    {
      Visual visual;
      Visual3D visual3D;
      VisualTreeUtils.AsNonNullVisual(descendant, out visual, out visual3D);
      if (visual3D != null)
        return visual3D.IsDescendantOf((DependencyObject) this);
      else
        return visual.IsDescendantOf((DependencyObject) this);
    }

    public bool IsDescendantOf(DependencyObject ancestor)
    {
      if (ancestor == null)
        throw new ArgumentNullException("ancestor");
      VisualTreeUtils.EnsureVisual(ancestor);
      DependencyObject dependencyObject = (DependencyObject) this;
      while (dependencyObject != null && dependencyObject != ancestor)
      {
        Visual visual = dependencyObject as Visual;
        if (visual != null)
        {
          dependencyObject = visual._parent;
        }
        else
        {
          Visual3D visual3D = dependencyObject as Visual3D;
          dependencyObject = visual3D == null ? (DependencyObject) null : visual3D.InternalVisualParent;
        }
      }
      return dependencyObject == ancestor;
    }

    internal void SetFlagsToRoot(bool value, VisualFlags flag)
    {
      Visual visual1 = this;
      do
      {
        visual1.SetFlags(value, flag);
        Visual visual2 = visual1._parent as Visual;
        if (visual1._parent != null && visual2 == null)
        {
          ((Visual3D) visual1._parent).SetFlagsToRoot(value, flag);
          break;
        }
        else
          visual1 = visual2;
      }
      while (visual1 != null);
    }

    internal DependencyObject FindFirstAncestorWithFlagsAnd(VisualFlags flag)
    {
      Visual visual = this;
      while (!visual.CheckFlagsAnd(flag))
      {
        DependencyObject dependencyObject = visual._parent;
        visual = dependencyObject as Visual;
        if (visual == null)
        {
          Visual3D visual3D = dependencyObject as Visual3D;
          if (visual3D != null)
            return visual3D.FindFirstAncestorWithFlagsAnd(flag);
        }
        if (visual == null)
          return (DependencyObject) null;
      }
      return (DependencyObject) visual;
    }

    public DependencyObject FindCommonVisualAncestor(DependencyObject otherVisual)
    {
      this.VerifyAPIReadOnly(otherVisual);
      if (otherVisual == null)
        throw new ArgumentNullException("otherVisual");
      this.SetFlagsToRoot(false, VisualFlags.FindCommonAncestor);
      VisualTreeUtils.SetFlagsToRoot(otherVisual, true, VisualFlags.FindCommonAncestor);
      return this.FindFirstAncestorWithFlagsAnd(VisualFlags.FindCommonAncestor);
    }

    public GeneralTransform TransformToAncestor(Visual ancestor)
    {
      if (ancestor == null)
        throw new ArgumentNullException("ancestor");
      this.VerifyAPIReadOnly((DependencyObject) ancestor);
      return this.InternalTransformToAncestor(ancestor, false);
    }

    public GeneralTransform2DTo3D TransformToAncestor(Visual3D ancestor)
    {
      if (ancestor == null)
        throw new ArgumentNullException("ancestor");
      this.VerifyAPIReadOnly((DependencyObject) ancestor);
      return this.InternalTransformToAncestor(ancestor, false);
    }

    public GeneralTransform TransformToDescendant(Visual descendant)
    {
      if (descendant == null)
        throw new ArgumentNullException("descendant");
      this.VerifyAPIReadOnly((DependencyObject) descendant);
      return descendant.InternalTransformToAncestor(this, true);
    }

    public GeneralTransform TransformToVisual(Visual visual)
    {
      Visual ancestor = this.FindCommonVisualAncestor((DependencyObject) visual) as Visual;
      if (ancestor == null)
        throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("Visual_NoCommonAncestor"));
      GeneralTransform generalTransform1;
      Matrix simpleTransform1;
      bool flag1 = this.TrySimpleTransformToAncestor(ancestor, false, out generalTransform1, out simpleTransform1);
      GeneralTransform generalTransform2;
      Matrix simpleTransform2;
      bool flag2 = visual.TrySimpleTransformToAncestor(ancestor, true, out generalTransform2, out simpleTransform2);
      if (flag1 && flag2)
      {
        MatrixUtil.MultiplyMatrix(ref simpleTransform1, ref simpleTransform2);
        MatrixTransform matrixTransform = new MatrixTransform(simpleTransform1);
        matrixTransform.Freeze();
        return (GeneralTransform) matrixTransform;
      }
      else
      {
        if (flag1)
        {
          generalTransform1 = (GeneralTransform) new MatrixTransform(simpleTransform1);
          generalTransform1.Freeze();
        }
        else if (flag2)
        {
          generalTransform2 = (GeneralTransform) new MatrixTransform(simpleTransform2);
          generalTransform2.Freeze();
        }
        if (generalTransform2 == null)
          return generalTransform1;
        GeneralTransformGroup generalTransformGroup = new GeneralTransformGroup();
        generalTransformGroup.Children.Add(generalTransform1);
        generalTransformGroup.Children.Add(generalTransform2);
        generalTransformGroup.Freeze();
        return (GeneralTransform) generalTransformGroup;
      }
    }

    internal bool TrySimpleTransformToAncestor(Visual ancestor, bool inverse, out GeneralTransform generalTransform, out Matrix simpleTransform)
    {
      bool flag = false;
      DependencyObject reference = (DependencyObject) this;
      Matrix identity = Matrix.Identity;
      GeneralTransformGroup generalTransformGroup = (GeneralTransformGroup) null;
      while (VisualTreeHelper.GetParent(reference) != null && reference != ancestor)
      {
        Visual visual = reference as Visual;
        if (visual != null)
        {
          if (visual.CheckFlagsAnd(VisualFlags.NodeHasEffect))
          {
            Effect effect = Visual.EffectField.GetValue((DependencyObject) visual);
            if (effect != null)
            {
              GeneralTransform generalTransform1 = effect.CoerceToUnitSpaceGeneralTransform(effect.EffectMapping, visual.VisualDescendantBounds);
              Transform affineTransform = generalTransform1.AffineTransform;
              if (affineTransform != null)
              {
                Matrix matrix2 = affineTransform.Value;
                MatrixUtil.MultiplyMatrix(ref identity, ref matrix2);
              }
              else
              {
                if (generalTransformGroup == null)
                  generalTransformGroup = new GeneralTransformGroup();
                generalTransformGroup.Children.Add((GeneralTransform) new MatrixTransform(identity));
                identity = Matrix.Identity;
                generalTransformGroup.Children.Add(generalTransform1);
              }
            }
          }
          Transform transform = Visual.TransformField.GetValue((DependencyObject) visual);
          if (transform != null)
          {
            Matrix matrix2 = transform.Value;
            MatrixUtil.MultiplyMatrix(ref identity, ref matrix2);
          }
          identity.Translate(visual._offset.X, visual._offset.Y);
          reference = visual._parent;
        }
        else
        {
          Viewport2DVisual3D visual3D = reference as Viewport2DVisual3D;
          if (generalTransformGroup == null)
            generalTransformGroup = new GeneralTransformGroup();
          generalTransformGroup.Children.Add((GeneralTransform) new MatrixTransform(identity));
          identity = Matrix.Identity;
          Visual fromVisual;
          if (flag)
          {
            fromVisual = visual3D.Visual;
          }
          else
          {
            fromVisual = this;
            flag = true;
          }
          generalTransformGroup.Children.Add((GeneralTransform) new GeneralTransform2DTo3DTo2D(visual3D, fromVisual));
          reference = (DependencyObject) VisualTreeHelper.GetContainingVisual2D((DependencyObject) visual3D);
        }
      }
      if (reference != ancestor)
        throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get(inverse ? "Visual_NotADescendant" : "Visual_NotAnAncestor"));
      if (generalTransformGroup != null)
      {
        if (!identity.IsIdentity)
          generalTransformGroup.Children.Add((GeneralTransform) new MatrixTransform(identity));
        if (inverse)
          generalTransformGroup = (GeneralTransformGroup) generalTransformGroup.Inverse;
        if (generalTransformGroup != null)
          generalTransformGroup.Freeze();
        generalTransform = (GeneralTransform) generalTransformGroup;
        simpleTransform = new Matrix();
        return false;
      }
      else
      {
        generalTransform = (GeneralTransform) null;
        if (inverse)
        {
          if (!identity.HasInverse)
          {
            simpleTransform = new Matrix();
            return false;
          }
          else
            identity.Invert();
        }
        simpleTransform = identity;
        return true;
      }
    }

    internal bool TrySimpleTransformToAncestor(Visual3D ancestor, out GeneralTransform2DTo3D transformTo3D)
    {
      Viewport2DVisual3D containingVisual3D = VisualTreeHelper.GetContainingVisual3D((DependencyObject) this) as Viewport2DVisual3D;
      if (containingVisual3D == null)
        throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("Visual_NotAnAncestor"));
      GeneralTransform transform2D = this.TransformToAncestor(containingVisual3D.Visual);
      GeneralTransform3D transform3D = containingVisual3D.TransformToAncestor(ancestor);
      transformTo3D = new GeneralTransform2DTo3D(transform2D, containingVisual3D, transform3D);
      return true;
    }

    public Point PointToScreen(Point point)
    {
      this.VerifyAPIReadOnly();
      PresentationSource presentationSource = PresentationSource.FromVisual(this);
      if (presentationSource == null)
        throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("Visual_NoPresentationSource"));
      GeneralTransform generalTransform = this.TransformToAncestor(presentationSource.RootVisual);
      if (generalTransform == null || !generalTransform.TryTransform(point, out point))
        throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("Visual_CannotTransformPoint"));
      point = PointUtil.RootToClient(point, presentationSource);
      point = PointUtil.ClientToScreen(point, presentationSource);
      return point;
    }

    public Point PointFromScreen(Point point)
    {
      this.VerifyAPIReadOnly();
      PresentationSource presentationSource = PresentationSource.FromVisual(this);
      if (presentationSource == null)
        throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("Visual_NoPresentationSource"));
      point = PointUtil.ScreenToClient(point, presentationSource);
      point = PointUtil.ClientToRoot(point, presentationSource);
      GeneralTransform generalTransform = presentationSource.RootVisual.TransformToDescendant(this);
      if (generalTransform == null || !generalTransform.TryTransform(point, out point))
        throw new InvalidOperationException(MS.Internal.PresentationCore.SR.Get("Visual_CannotTransformPoint"));
      else
        return point;
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void ClipChanged(object sender, EventArgs e)
    {
      this.PropagateChangedFlags();
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void ScrollableAreaClipChanged(object sender, EventArgs e)
    {
      this.PropagateChangedFlags();
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void TransformChanged(object sender, EventArgs e)
    {
      this.PropagateChangedFlags();
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void EffectChanged(object sender, EventArgs e)
    {
      this.PropagateChangedFlags();
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void CacheModeChanged(object sender, EventArgs e)
    {
      this.PropagateChangedFlags();
    }

    internal void GuidelinesChanged(object sender, EventArgs e)
    {
      this.SetFlagsOnAllChannels(true, VisualProxyFlags.IsGuidelineCollectionDirty);
      this.PropagateChangedFlags();
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void OpacityMaskChanged(object sender, EventArgs e)
    {
      this.PropagateChangedFlags();
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal virtual void ContentsChanged(object sender, EventArgs e)
    {
      this.PropagateChangedFlags();
    }

    internal void SetFlagsOnAllChannels(bool value, VisualProxyFlags flagsToChange)
    {
      this._proxy.SetFlagsOnAllChannels(value, flagsToChange);
    }

    internal void SetFlags(DUCE.Channel channel, bool value, VisualProxyFlags flagsToChange)
    {
      this._proxy.SetFlags(channel, value, flagsToChange);
    }

    internal void SetFlags(bool value, VisualFlags flags)
    {
      this._flags = value ? this._flags | flags : this._flags & ~flags;
    }

    internal bool CheckFlagsOnAllChannels(VisualProxyFlags flagsToCheck)
    {
      return this._proxy.CheckFlagsOnAllChannels(flagsToCheck);
    }

    internal bool CheckFlagsAnd(DUCE.Channel channel, VisualProxyFlags flagsToCheck)
    {
      return (this._proxy.GetFlags(channel) & flagsToCheck) == flagsToCheck;
    }

    internal bool CheckFlagsAnd(VisualFlags flags)
    {
      return (this._flags & flags) == flags;
    }

    internal bool CheckFlagsOr(DUCE.Channel channel, VisualProxyFlags flagsToCheck)
    {
      return (this._proxy.GetFlags(channel) & flagsToCheck) != VisualProxyFlags.None;
    }

    internal bool CheckFlagsOr(VisualFlags flags)
    {
      if (flags != VisualFlags.None)
        return (this._flags & flags) > VisualFlags.None;
      else
        return true;
    }

    internal static void SetTreeBits(DependencyObject e, VisualFlags treeFlag, VisualFlags nodeFlag)
    {
      if (e != null)
      {
        Visual visual = e as Visual;
        if (visual != null)
          visual.SetFlags(true, nodeFlag);
        else
          ((Visual3D) e).SetFlags(true, nodeFlag);
      }
      for (; e != null; e = VisualTreeHelper.GetParent(e))
      {
        Visual visual = e as Visual;
        if (visual != null)
        {
          if (visual.CheckFlagsAnd(treeFlag))
            break;
          visual.SetFlags(true, treeFlag);
        }
        else
        {
          Visual3D visual3D = e as Visual3D;
          if (visual3D.CheckFlagsAnd(treeFlag))
            break;
          visual3D.SetFlags(true, treeFlag);
        }
      }
    }

    internal static void ClearTreeBits(DependencyObject e, VisualFlags treeFlag, VisualFlags nodeFlag)
    {
      if (e != null)
      {
        Visual visual = e as Visual;
        if (visual != null)
          visual.SetFlags(false, nodeFlag);
        else
          ((Visual3D) e).SetFlags(false, nodeFlag);
      }
      for (; e != null; e = VisualTreeHelper.GetParent(e))
      {
        Visual pe1 = e as Visual;
        if (pe1 != null)
        {
          if (pe1.CheckFlagsAnd(nodeFlag) || Visual.DoAnyChildrenHaveABitSet(pe1, treeFlag))
            break;
          pe1.SetFlags(false, treeFlag);
        }
        else
        {
          Visual3D pe2 = e as Visual3D;
          if (pe2.CheckFlagsAnd(nodeFlag) || Visual3D.DoAnyChildrenHaveABitSet(pe2, treeFlag))
            break;
          pe2.SetFlags(false, treeFlag);
        }
      }
    }

    internal static void PropagateFlags(Visual e, VisualFlags flags, VisualProxyFlags proxyFlags)
    {
      for (; e != null && (!e.CheckFlagsAnd(flags) || !e.CheckFlagsOnAllChannels(proxyFlags)); {
        Visual visual;
        e = visual;
      }
      )
      {
        if (e.CheckFlagsOr(VisualFlags.ShouldPostRender))
        {
          MediaContext mediaContext = MediaContext.From(e.Dispatcher);
          if (mediaContext.Channel != null)
            mediaContext.PostRender();
        }
        else if (e.CheckFlagsAnd(VisualFlags.NodeIsCyclicBrushRoot))
        {
          foreach (ICyclicBrush cyclicBrush in Visual.CyclicBrushToChannelsMapField.GetValue((DependencyObject) e).Keys)
            cyclicBrush.FireOnChanged();
        }
        e.SetFlags(true, flags);
        e.SetFlagsOnAllChannels(true, proxyFlags);
        if (e._parent == null)
          break;
        visual = e._parent as Visual;
        if (visual == null)
        {
          Visual3D.PropagateFlags((Visual3D) e._parent, flags, proxyFlags);
          break;
        }
      }
    }

    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal void PropagateChangedFlags()
    {
      Visual.PropagateFlags(this, VisualFlags.IsSubtreeDirtyForPrecompute, VisualProxyFlags.IsSubtreeDirtyForRender);
    }

    private bool IsEmptyRenderBounds(ref Rect bounds)
    {
      if (bounds.Width > 0.0)
        return bounds.Height <= 0.0;
      else
        return true;
    }

    private bool IsCyclicBrushRootOnChannel(DUCE.Channel channel)
    {
      bool flag = false;
      Dictionary<DUCE.Channel, int> dictionary = Visual.ChannelsToCyclicBrushMapField.GetValue((DependencyObject) this);
      int num;
      if (dictionary != null && dictionary.TryGetValue(channel, out num))
        flag = num > 0;
      return flag;
    }

    private void UpdateOpacity(DUCE.Channel channel, DUCE.ResourceHandle handle, VisualProxyFlags flags, bool isOnChannel)
    {
      if ((flags & VisualProxyFlags.IsOpacityDirty) == VisualProxyFlags.None)
        return;
      double alpha = Visual.OpacityField.GetValue((DependencyObject) this);
      if (isOnChannel || alpha < 1.0)
        DUCE.CompositionNode.SetAlpha(handle, alpha, channel);
      this.SetFlags(channel, false, VisualProxyFlags.IsOpacityDirty);
    }

    private void UpdateOpacityMask(DUCE.Channel channel, DUCE.ResourceHandle handle, VisualProxyFlags flags, bool isOnChannel)
    {
      if ((flags & VisualProxyFlags.IsOpacityMaskDirty) == VisualProxyFlags.None)
        return;
      Brush brush = Visual.OpacityMaskField.GetValue((DependencyObject) this);
      if (brush != null)
        DUCE.CompositionNode.SetAlphaMask(handle, brush.AddRefOnChannel(channel), channel);
      else if (isOnChannel)
        DUCE.CompositionNode.SetAlphaMask(handle, DUCE.ResourceHandle.Null, channel);
      this.SetFlags(channel, false, VisualProxyFlags.IsOpacityMaskDirty);
    }

    private void UpdateTransform(DUCE.Channel channel, DUCE.ResourceHandle handle, VisualProxyFlags flags, bool isOnChannel)
    {
      if ((flags & VisualProxyFlags.IsTransformDirty) == VisualProxyFlags.None)
        return;
      Transform transform = Visual.TransformField.GetValue((DependencyObject) this);
      if (transform != null)
        DUCE.CompositionNode.SetTransform(handle, transform.AddRefOnChannel(channel), channel);
      else if (isOnChannel)
        DUCE.CompositionNode.SetTransform(handle, DUCE.ResourceHandle.Null, channel);
      this.SetFlags(channel, false, VisualProxyFlags.IsTransformDirty);
    }

    private void UpdateEffect(DUCE.Channel channel, DUCE.ResourceHandle handle, VisualProxyFlags flags, bool isOnChannel)
    {
      if ((flags & VisualProxyFlags.IsEffectDirty) == VisualProxyFlags.None)
        return;
      Effect effect = Visual.EffectField.GetValue((DependencyObject) this);
      if (effect != null)
        DUCE.CompositionNode.SetEffect(handle, effect.AddRefOnChannel(channel), channel);
      else if (isOnChannel)
        DUCE.CompositionNode.SetEffect(handle, DUCE.ResourceHandle.Null, channel);
      this.SetFlags(channel, false, VisualProxyFlags.IsEffectDirty);
    }

    private void UpdateCacheMode(DUCE.Channel channel, DUCE.ResourceHandle handle, VisualProxyFlags flags, bool isOnChannel)
    {
      if ((flags & VisualProxyFlags.IsCacheModeDirty) == VisualProxyFlags.None)
        return;
      CacheMode cacheMode = Visual.CacheModeField.GetValue((DependencyObject) this);
      if (cacheMode != null)
        DUCE.CompositionNode.SetCacheMode(handle, cacheMode.AddRefOnChannel(channel), channel);
      else if (isOnChannel)
        DUCE.CompositionNode.SetCacheMode(handle, DUCE.ResourceHandle.Null, channel);
      this.SetFlags(channel, false, VisualProxyFlags.IsCacheModeDirty);
    }

    private void UpdateClip(DUCE.Channel channel, DUCE.ResourceHandle handle, VisualProxyFlags flags, bool isOnChannel)
    {
      if ((flags & VisualProxyFlags.IsClipDirty) == VisualProxyFlags.None)
        return;
      Geometry geometry = Visual.ClipField.GetValue((DependencyObject) this);
      if (geometry != null)
        DUCE.CompositionNode.SetClip(handle, geometry.AddRefOnChannel(channel), channel);
      else if (isOnChannel)
        DUCE.CompositionNode.SetClip(handle, DUCE.ResourceHandle.Null, channel);
      this.SetFlags(channel, false, VisualProxyFlags.IsClipDirty);
    }

    private void UpdateScrollableAreaClip(DUCE.Channel channel, DUCE.ResourceHandle handle, VisualProxyFlags flags, bool isOnChannel)
    {
      if ((flags & VisualProxyFlags.IsScrollableAreaClipDirty) == VisualProxyFlags.None)
        return;
      Rect? clip = Visual.ScrollableAreaClipField.GetValue((DependencyObject) this);
      if (isOnChannel || clip.HasValue)
        DUCE.CompositionNode.SetScrollableAreaClip(handle, clip, channel);
      this.SetFlags(channel, false, VisualProxyFlags.IsScrollableAreaClipDirty);
    }

    private void UpdateOffset(DUCE.Channel channel, DUCE.ResourceHandle handle, VisualProxyFlags flags, bool isOnChannel)
    {
      if ((flags & VisualProxyFlags.IsOffsetDirty) == VisualProxyFlags.None)
        return;
      if (isOnChannel || this._offset != new Vector())
        DUCE.CompositionNode.SetOffset(handle, this._offset.X, this._offset.Y, channel);
      this.SetFlags(channel, false, VisualProxyFlags.IsOffsetDirty);
    }

    private void UpdateGuidelines(DUCE.Channel channel, DUCE.ResourceHandle handle, VisualProxyFlags flags, bool isOnChannel)
    {
      if ((flags & VisualProxyFlags.IsGuidelineCollectionDirty) == VisualProxyFlags.None)
        return;
      DoubleCollection guidelinesX = Visual.GuidelinesXField.GetValue((DependencyObject) this);
      DoubleCollection guidelinesY = Visual.GuidelinesYField.GetValue((DependencyObject) this);
      if (isOnChannel || guidelinesX != null || guidelinesY != null)
        DUCE.CompositionNode.SetGuidelineCollection(handle, guidelinesX, guidelinesY, channel);
      this.SetFlags(channel, false, VisualProxyFlags.IsGuidelineCollectionDirty);
    }

    private void UpdateRenderOptions(DUCE.Channel channel, DUCE.ResourceHandle handle, VisualProxyFlags flags, bool isOnChannel)
    {
      if ((flags & VisualProxyFlags.IsEdgeModeDirty) == VisualProxyFlags.None && (flags & VisualProxyFlags.IsBitmapScalingModeDirty) == VisualProxyFlags.None && ((flags & VisualProxyFlags.IsClearTypeHintDirty) == VisualProxyFlags.None && (flags & VisualProxyFlags.IsTextRenderingModeDirty) == VisualProxyFlags.None) && (flags & VisualProxyFlags.IsTextHintingModeDirty) == VisualProxyFlags.None)
        return;
      MilRenderOptions renderOptions = new MilRenderOptions();
      EdgeMode edgeMode = Visual.EdgeModeField.GetValue((DependencyObject) this);
      if (isOnChannel || edgeMode != EdgeMode.Unspecified)
      {
        renderOptions.Flags |= MilRenderOptionFlags.EdgeMode;
        renderOptions.EdgeMode = edgeMode;
      }
      BitmapScalingMode bitmapScalingMode = Visual.BitmapScalingModeField.GetValue((DependencyObject) this);
      if (isOnChannel || bitmapScalingMode != BitmapScalingMode.Unspecified)
      {
        renderOptions.Flags |= MilRenderOptionFlags.BitmapScalingMode;
        renderOptions.BitmapScalingMode = bitmapScalingMode;
      }
      ClearTypeHint clearTypeHint = Visual.ClearTypeHintField.GetValue((DependencyObject) this);
      if (isOnChannel || clearTypeHint != ClearTypeHint.Auto)
      {
        renderOptions.Flags |= MilRenderOptionFlags.ClearTypeHint;
        renderOptions.ClearTypeHint = clearTypeHint;
      }
      TextRenderingMode textRenderingMode = Visual.TextRenderingModeField.GetValue((DependencyObject) this);
      if (isOnChannel || textRenderingMode != TextRenderingMode.Auto)
      {
        renderOptions.Flags |= MilRenderOptionFlags.TextRenderingMode;
        renderOptions.TextRenderingMode = textRenderingMode;
      }
      TextHintingMode textHintingMode = Visual.TextHintingModeField.GetValue((DependencyObject) this);
      if (isOnChannel || textHintingMode != TextHintingMode.Auto)
      {
        renderOptions.Flags |= MilRenderOptionFlags.TextHintingMode;
        renderOptions.TextHintingMode = textHintingMode;
      }
      if (renderOptions.Flags != (MilRenderOptionFlags) 0)
        DUCE.CompositionNode.SetRenderOptions(handle, renderOptions, channel);
      this.SetFlags(channel, false, VisualProxyFlags.IsClearTypeHintDirty | VisualProxyFlags.IsEdgeModeDirty | VisualProxyFlags.IsBitmapScalingModeDirty | VisualProxyFlags.IsTextRenderingModeDirty | VisualProxyFlags.IsTextHintingModeDirty);
    }

    private void UpdateContent(RenderContext ctx, VisualProxyFlags flags, bool isOnChannel)
    {
      if ((flags & VisualProxyFlags.IsContentDirty) == VisualProxyFlags.None)
        return;
      this.RenderContent(ctx, isOnChannel);
      this.SetFlags(ctx.Channel, false, VisualProxyFlags.IsContentDirty);
    }

    private void UpdateChildren(RenderContext ctx, DUCE.ResourceHandle handle)
    {
      DUCE.Channel channel = ctx.Channel;
      uint iPosition = this.CheckFlagsAnd(channel, VisualProxyFlags.IsContentNodeConnected) ? 1U : 0U;
      bool flag = this.CheckFlagsAnd(channel, VisualProxyFlags.IsChildrenZOrderDirty);
      int visualChildrenCount = this.VisualChildrenCount;
      if (flag)
        DUCE.CompositionNode.RemoveAllChildren(handle, channel);
      for (int index = 0; index < visualChildrenCount; ++index)
      {
        Visual visualChild = this.GetVisualChild(index);
        if (visualChild != null)
        {
          if (visualChild.CheckFlagsAnd(channel, VisualProxyFlags.IsSubtreeDirtyForRender) || !visualChild.IsOnChannel(channel))
            visualChild.RenderRecursive(ctx);
          if (visualChild.IsOnChannel(channel))
          {
            if (!visualChild.CheckFlagsAnd(channel, VisualProxyFlags.IsConnectedToParent) || flag)
            {
              DUCE.CompositionNode.InsertChildAt(handle, visualChild.GetHandle(channel), iPosition, channel);
              visualChild.SetFlags(channel, true, VisualProxyFlags.IsConnectedToParent);
            }
            ++iPosition;
          }
        }
      }
      this.SetFlags(channel, false, VisualProxyFlags.IsChildrenZOrderDirty);
    }

    private GeneralTransform InternalTransformToAncestor(Visual ancestor, bool inverse)
    {
      GeneralTransform generalTransform;
      Matrix simpleTransform;
      if (!this.TrySimpleTransformToAncestor(ancestor, inverse, out generalTransform, out simpleTransform))
        return generalTransform;
      MatrixTransform matrixTransform = new MatrixTransform(simpleTransform);
      matrixTransform.Freeze();
      return (GeneralTransform) matrixTransform;
    }

    private GeneralTransform2DTo3D InternalTransformToAncestor(Visual3D ancestor, bool inverse)
    {
      GeneralTransform2DTo3D transformTo3D = (GeneralTransform2DTo3D) null;
      if (!this.TrySimpleTransformToAncestor(ancestor, out transformTo3D))
        return (GeneralTransform2DTo3D) null;
      transformTo3D.Freeze();
      return transformTo3D;
    }

    private static bool DoAnyChildrenHaveABitSet(Visual pe, VisualFlags flag)
    {
      int visualChildrenCount = pe.VisualChildrenCount;
      for (int index = 0; index < visualChildrenCount; ++index)
      {
        Visual visualChild = pe.GetVisualChild(index);
        if (visualChild != null && visualChild.CheckFlagsAnd(flag))
          return true;
      }
      return false;
    }

    internal class TopMostHitResult
    {
      internal HitTestResult _hitResult;

      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
      public TopMostHitResult()
      {
      }

      internal HitTestResultBehavior HitTestResult(HitTestResult result)
      {
        this._hitResult = result;
        return HitTestResultBehavior.Stop;
      }

      internal HitTestFilterBehavior NoNested2DFilter(DependencyObject potentialHitTestTarget)
      {
        if (potentialHitTestTarget is Viewport2DVisual3D)
          return HitTestFilterBehavior.ContinueSkipChildren;
        else
          return HitTestFilterBehavior.Continue;
      }
    }

    internal delegate void AncestorChangedEventHandler(object sender, AncestorChangedEventArgs e);
  }
}
