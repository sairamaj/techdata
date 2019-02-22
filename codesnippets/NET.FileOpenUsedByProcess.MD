### File open while the file being used by process
```csharp
using (var fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (var sr = new StreamReader(fs, Encoding.Default))
				{
					var line = string.Empty;
					while ((line = sr.ReadLine()) != null)
					{
						if (line.Contains(filter))
						{
							yield return line;
						}
					}
				}
        }
```