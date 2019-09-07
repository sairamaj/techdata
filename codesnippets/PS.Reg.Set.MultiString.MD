## Setting up multi string registry
```powershell
  Write-Host "Checking DispatchEntries property for SMTP service registry key."
    $prop = Get-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Services\InetInfo\Parameters" -Name 'DispatchEntries' -ErrorAction SilentlyContinue
    if( $prop -eq $null ){
        Write-Host "Adding property DispatchEntries to InetInfo as it does not exists"
        New-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Services\InetInfo\Parameters" -Name 'DispatchEntries' -PropertyType MultiString -Value ('SMTPSVC')
    }else{
          Write-Host "Property DispatchEntries already exists."
    }
```