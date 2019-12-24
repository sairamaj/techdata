
```
private T GetValue<T>(IDictionary<string, string> items, string name, T defaultValue)
        {
            if (configItems == null)
            {
                return defaultValue;
            }

            var finalValue = defaultValue;
            if (configItems.TryGetValue(name, out var value))
            {
                if (value != null)
                {
                    try
                    {
                        var converter = TypeDescriptor.GetConverter(typeof(T));
                        finalValue = converter.CanConvertFrom(typeof(string)) ?
                            (T)converter.ConvertFrom(value) :
                            defaultValue;
                    }
                    catch (System.Exception)
                    {
						// log here
                    }
                }
            }

            return finalValue;
        }
```