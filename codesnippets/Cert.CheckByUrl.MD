```powershell
[Net.ServicePointManager]::ServerCertificateValidationCallback = { $true }
$url = "https://www.microsoft.com/"
$req = [Net.HttpWebRequest]::Create($url)
$req.GetResponse() | Out-Null
$output = [PSCustomObject]@{
   URL = $url
   'Name' = $req.ServicePoint.Certificate.GetName()
   'Serial' = $req.ServicePoint.Certificate.GetSerialNumberString()
   'Cert Start Date' = $req.ServicePoint.Certificate.GetEffectiveDateString()
   'Cert End Date' = $req.ServicePoint.Certificate.GetExpirationDateString()
}
$output
```
[source](https://www.tutorialspoint.com/how-to-get-website-ssl-certificate-validity-dates-with-powershell)
