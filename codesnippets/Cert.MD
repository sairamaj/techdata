## PKCS7 (p7b) bag of certificates

#### General
* P7B file only contains certificates and chain certificates (Intermediate CAs), not the private key
* .pfx contains both public and private key and usually .cer contains public key and .key contains private key

#### powershell to read p7b
```powershell
[reflection.assembly]::LoadWithPartialName("System.SecurC:\Temp>"C:\Program Files\git\mingw64\bin\openssl" pkcs12 -in certificate-vault1234-dcdevtestbc6b5602-a2bf-4666-b738-0be636fa3a6d-20191011.pfx -out new.perm -nodesity")
$data = [System.IO.File]::ReadAllBytes("certificates.p7b")
$cms = new-object system.security.cryptography.pkcs.signedcms
$cms.Decode($data)
$cms.Certificates | foreach {New-Object System.Security.Cryptography.X509Certificates.X509Certificate2 $_} | echo
```
[source](https://blogs.technet.microsoft.com/vishalagarwal/2009/04/30/pkcs7-p7b-bag-of-certificates-and-powershell/)

### Change Password PFX
[source](https://blog.spaps.de/add-password-to-p12-pfx-certificate/)
```cmd
    openssl pkcs12 -in input.pfx -out out.perm -nodes
    openssl pkcs12 -export -out out.pfx -in new.perm
```
