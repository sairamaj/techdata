* dotnet add package Microsoft.IdentityModel.Clients.ActiveDirectory
```csharp
# acquring token using client id: secret
        public string Token {
            get {
                var clientId = this.deploymentCredentials.ClientId;
                var clientSecret = this.deploymentCredentials.ClientSecret;
                var uc = new ClientCredential (clientId, clientSecret);
                var context = new AuthenticationContext ("https://login.windows.net/" + this.deploymentCredentials.TenantId);
                var result = context.AcquireTokenAsync ("https://management.azure.com/", uc).Result;
                if (result == null) {
                    throw new InvalidOperationException ("Failed to obtain the JWT token");
                }

                return result.AccessToken;
            }
        }
```