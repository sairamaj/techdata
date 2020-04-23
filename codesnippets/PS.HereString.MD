### Litteral string
```powershell
$Request =@"
{
    "description": "$CacheName",
    "expirySettings": {
      "expiryDate": {
        "timeoutInSec": {
          "value": "$TimeoutInSeconds"
        }
      }
    }
  }
"@
```