## PKCS7 (p7b) bag of certificates

P7B file only contains certificates and chain certificates (Intermediate CAs), not the private key

#### powershell to read p7b
```powershell
[reflection.assembly]::LoadWithPartialName("System.Security")
$data = [System.IO.File]::ReadAllBytes("certificates.p7b")
$cms = new-object system.security.cryptography.pkcs.signedcms
$cms.Decode($data)
$cms.Certificates | foreach {New-Object System.Security.Cryptography.X509Certificates.X509Certificate2 $_} | echo
```
[source](https://blogs.technet.microsoft.com/vishalagarwal/2009/04/30/pkcs7-p7b-bag-of-certificates-and-powershell/)