[source](https://github.com/Azure-Samples/compute-dotnet-manage-vm/blob/master/Program.cs)
[playground](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachines/list)
[FluentApi](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/virtualmachines?view=azure-dotnet)
```cmd
dotnet add package Microsoft.Azure.Management.ResourceManager --version 3.7.1-preview
dotnet add package Microsoft.IdentityModel.Clients.ActiveDirectory --version 5.2.7
dotnet add package Microsoft.Azure.Management.Compute.Fluent
```

```csharp
var computeManagementClient = new ComputeManagementClient (this.TokenCredential) {
            SubscriptionId = this.SubscriptionId
        };

        await computeManagementClient.VirtualMachines.StartAsync (resourceGroup, vmName);
        return await GetStatus (resourceGroup, vmName);
```