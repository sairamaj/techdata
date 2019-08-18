### Property Notify
```csharp
class FilterInfo : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;    

	public int? TimeThreshold
	{
        get => this._timeThreshold;
        set
        {
            this._timeThreshold = value;
            OnPropertyChanged(() => this.TimeThreshold);
        }
    }

    	protected void OnPropertyChanged<T>(Expression<Func<T>> selectorExpression)
		{
			if (selectorExpression == null)
			{
				throw new ArgumentNullException("selectorExpression");
			}

			var body = selectorExpression.Body as MemberExpression;
			if (body == null)
			{
				return;
			}

			var propertyName = body.Member.Name;

			PropertyChangedEventHandler handler = this.PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
}

```