## Credential store
package: Meziantou.Framework.Win32.CredentialManager
```csharp
CredentialManager.DeleteCredential(credentialAppName);
var cred = CredentialManager.ReadCredential(credentialAppName);
CredentialManager.WriteCredential(credentialAppName, credential.UserName, credential.Password, CredentialPersistence.LocalMachine);
```