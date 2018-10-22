```csharp
    public class Command
    {
        public string Name { get; set; }
    }
      [HttpPost]
    public void Post([FromBody] Command command)
    {

    }
```

```powershell
    # create hash
    $body = @{ name="stop"}

    Invoke-WebRequest $url -Method Post -Body ($body|ConvertTo-Json) -ContentType "application/json"

    # using parameter splatting.
    $parameaters = @{Uri=uri, Method='post'}
    Invoke-WebRequest @parameaters
```
