### Resource Group Update Tags

#### Cshap

```csharp

            // get token
            var tenantId = tenantId;
            var clientId = clientId;
            var clientSecret = secret;
            var uc = new ClientCredential (clientId, clientSecret);
            var context = new AuthenticationContext ("https://login.windows.net/" + tenantId);
            var result = context.AcquireTokenAsync ("https://management.azure.com/", uc).Result;
            if (result == null) {
                throw new InvalidOperationException ("Failed to obtain the JWT token");
            }

            return result.AccessToken;

            // Use the token to 
            var token = GetAuthorizationToken ();
            var tokenCredential = new TokenCredentials (token);
            var resourceManagementClient = new ResourceManagementClient (tokenCredential) {
                SubscriptionId = AzureSubscriptionId
            };

            var resourceGroup = await resourceManagementClient.ResourceGroups.GetAsync(name);
            resourceGroup.Tags["Tag1"] = "Tag1value";
            await resourceManagementClient.ResourceGroups.UpdateAsync(name, new ResourceGroupPatchable(){
                Tags = resourceGroup.Tags
            });

```