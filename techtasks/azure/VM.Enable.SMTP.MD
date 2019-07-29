## Enabling SMTP on Azure Virtual machine
[source](https://www.dovetail.ie/blog/2015/azure-vm-smtp/#.XTouuIhKiUk)
* Test through Powershell
    
### Enabling Relay through powershell
```powershell
    $SmtpConfig = Get-WMIObject -Namespace root/MicrosoftIISv2 -ComputerName localhost -Query "Select * From IisSmtpServerSetting"

$RelayIpList = @( 24, 0, 0, 128, 32, 0, 0, 128, 60, 0, 0, 128, 68, 0, 0, 128, 1, 0, 0, 0, 76, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 76, 0, 0, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 127, 0, 0, 1 )

$SmtpConfig.RelayIPList = $RelayIPList

$SmtpConfig.Put()
```

```powershell
Send-MailMessage -From azuretest@test.com -To sairamaj@hotmail.com -Subject test -Body test -SmtpServer localhost
```

