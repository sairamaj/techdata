### Finds the pid of app pool
```powershell
param(
    [parameter(Mandatory=$true)]
    $Name
)


$cmd = "c:\Windows\system32\inetsrv\appcmd"
$result = & $cmd list wp /apppool.name:"$Name" 
if( $result.Length -eq 0 ){
    Write-Error "Did not find apppool : $Name"
    return
}

(($result -split ' ')[1]).Trim('""')
```