# Parses the token

```powershell
param(
    [paramter(Mandatory=$true)]
    $SasToken
)

$items = @{}
$SasToken -split '&' | ForEach-Object { ConvertFrom-String -Delimiter '=' -InputObject $_ -PropertyNames Name, Value} | % {$items[$_.Name] = [System.Web.HttpUtility]::UrlDecode($_.Value)}
$items
$startTime = [System.DateTime]::Parse($items["st"])
$endTime = [System.DateTime]::Parse($items["se"])
$startTime
$endTime
```