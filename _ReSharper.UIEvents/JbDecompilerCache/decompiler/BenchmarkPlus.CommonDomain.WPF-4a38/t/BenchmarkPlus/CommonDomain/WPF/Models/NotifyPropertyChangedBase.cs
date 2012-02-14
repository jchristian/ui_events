// Type: BenchmarkPlus.CommonDomain.WPF.Models.NotifyPropertyChangedBase
// Assembly: BenchmarkPlus.CommonDomain.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Dev\Temp\UIEvents\packages\BenchmarkPlus.CommonDomain.WPF.2012.131.910.139\lib\BenchmarkPlus.CommonDomain.WPF.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading;

namespace BenchmarkPlus.CommonDomain.WPF.Models
{
  public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
  {
    private PropertyChangedEventHandler PropertyChanged;
    private IDictionary<string, Action> _onPropertyChangedActions;

    public event PropertyChangedEventHandler PropertyChanged
    {
      add
      {
        PropertyChangedEventHandler changedEventHandler = this.PropertyChanged;
        PropertyChangedEventHandler comparand;
        do
        {
          comparand = changedEventHandler;
          changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.PropertyChanged, comparand + value, comparand);
        }
        while (changedEventHandler != comparand);
      }
      remove
      {
        PropertyChangedEventHandler changedEventHandler = this.PropertyChanged;
        PropertyChangedEventHandler comparand;
        do
        {
          comparand = changedEventHandler;
          changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.PropertyChanged, comparand - value, comparand);
        }
        while (changedEventHandler != comparand);
      }
    }

    protected NotifyPropertyChangedBase()
    {
      this._onPropertyChangedActions = (IDictionary<string, Action>) new Dictionary<string, Action>();
    }

    protected void RaisePropertyChanged<T>(Expression<Func<T>> expression)
    {
      string index = NotifyPropertyChangedBase.PropertyName<T>(expression);
      if (this.PropertyChanged != null)
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(index));
      if (!this._onPropertyChangedActions.ContainsKey(index))
        return;
      this._onPropertyChangedActions[index]();
    }

    protected void RegisterActionOnPropertyChanged<T>(Expression<Func<T>> expression, Action action)
    {
      string key = NotifyPropertyChangedBase.PropertyName<T>(expression);
      if (!this._onPropertyChangedActions.ContainsKey(key))
        this._onPropertyChangedActions.Add(key, (Action) (() => {}));
      this._onPropertyChangedActions[key] += action;
    }

    private static string PropertyName<T>(Expression<Func<T>> expression)
    {
      MemberExpression memberExpression = expression.Body as MemberExpression;
      if (memberExpression == null)
        throw new ArgumentException("expression must be a property expression");
      else
        return memberExpression.Member.Name;
    }
  }
}
