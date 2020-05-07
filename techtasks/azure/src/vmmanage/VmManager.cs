using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.OData;

class VmManager {

    public VmManager (string tenantId, string subscriptionId, string clientId, string clientSecret) {
        if (string.IsNullOrWhiteSpace (tenantId)) {
            throw new ArgumentException ("tenantId cannot be null or empty.", nameof (tenantId));
        }

        if (string.IsNullOrWhiteSpace (subscriptionId)) {
            throw new ArgumentException ("subscriptionId cannot be null or empty.", nameof (subscriptionId));
        }

        if (string.IsNullOrWhiteSpace (clientId)) {
            throw new ArgumentException ("clientId cannot be null or empty.", nameof (clientId));
        }

        if (string.IsNullOrWhiteSpace (clientSecret)) {
            throw new ArgumentException ("clientSecret cannot be null or empty.", nameof (clientSecret));
        }

        TenantId = tenantId;
        SubscriptionId = subscriptionId;
        ClientId = clientId;
        ClientSecret = clientSecret;

        var token = GetAuthorizationToken ();
        this.TokenCredential = new TokenCredentials (token);
    }

    public string TenantId { get; }
    public string SubscriptionId { get; }
    public string ClientId { get; }
    public string ClientSecret { get; }
    public TokenCredentials TokenCredential { get; }

    public async Task<IEnumerable<string>> GetResourceGroups () {
        var resourceManagementClient = new ResourceManagementClient (this.TokenCredential) {
            SubscriptionId = this.SubscriptionId
        };

        var resourceGroups = new List<string> ();
        foreach (var group in
                await resourceManagementClient.ResourceGroups.ListAsync (new ODataQuery<ResourceGroupFilter> (rg =>
                    rg.TagName == "Source" && rg.TagValue == "some-tag-here"))) {

            resourceGroups.Add (group.Name);
        }

        return resourceGroups;
    }

    public async Task<IEnumerable<string>> GetVmsInResourceGroup (string resourceGroup) {
        var vms = new List<string> ();
        var computeManagementClient = new ComputeManagementClient (this.TokenCredential) {
            SubscriptionId = this.SubscriptionId
        };

        foreach (var vm in await computeManagementClient.VirtualMachines.ListAsync (resourceGroup)) {
            vms.Add (vm.Name);
        }

        return vms;
    }

    public async Task<string> GetStatus (string resourceGroup, string vmName) {
        var computeManagementClient = new ComputeManagementClient (this.TokenCredential) {
            SubscriptionId = this.SubscriptionId
        };

        var vm = await computeManagementClient.VirtualMachines.GetAsync (resourceGroup, vmName, InstanceViewTypes.InstanceView);

        var status = vm.InstanceView.Statuses.LastOrDefault ();
        return status == null ? null : status.Code;
    }

    public async Task<string> StopAsync (string resourceGroup, string vmName) {
        var computeManagementClient = new ComputeManagementClient (this.TokenCredential) {
            SubscriptionId = this.SubscriptionId
        };
        await computeManagementClient.VirtualMachines.PowerOffAsync (resourceGroup, vmName);
        return await GetStatus (resourceGroup, vmName);
    }

    public async Task<string> StartAsync (string resourceGroup, string vmName) {
        var computeManagementClient = new ComputeManagementClient (this.TokenCredential) {
            SubscriptionId = this.SubscriptionId
        };

        await computeManagementClient.VirtualMachines.StartAsync (resourceGroup, vmName);
        return await GetStatus (resourceGroup, vmName);
    }

    private string GetAuthorizationToken () {
        // todo: Move these to key valut and use managed identity to get them.
        var tenantId = this.TenantId;
        var clientId = this.ClientId;
        var clientSecret = this.ClientSecret;
        var uc = new ClientCredential (clientId, clientSecret);
        var context = new AuthenticationContext ("https://login.windows.net/" + tenantId);
        var result = context.AcquireTokenAsync ("https://management.azure.com/", uc).Result;
        if (result == null) {
            throw new InvalidOperationException ("Failed to obtain the JWT token");
        }
        return result.AccessToken;
    }
}