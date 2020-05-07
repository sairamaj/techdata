using System;

namespace vmmanage {
    class Program {
        static void Main (string[] args) {
            var tenantId = System.Environment.GetEnvironmentVariable ("TenantId");
            var subscriptionId = System.Environment.GetEnvironmentVariable ("SubscriptionId");
            var clientId = System.Environment.GetEnvironmentVariable ("ClientId");
            var clientSecret = System.Environment.GetEnvironmentVariable ("ClientSecret");
            VmManager manager = new VmManager (
                tenantId,
                subscriptionId,
                clientId,
                clientSecret
            );

            // try {
            //     foreach (var rm in manager.GetResourceGroups ().Result) {
            //         System.Console.WriteLine (rm);
            //     }
            // } catch (System.Exception e) {
            //     System.Console.WriteLine (e);
            // }

            if (args.Length < 3) {
                System.Console.WriteLine ("Usage resourceGroup vmName action(start,stop,display)");
                System.Environment.Exit (-1);
            }

            var resourceGroupName = args[0];
            var vmName = args[1];
            var action = args[2];

            if (action == "stop") {
                StopVm (resourceGroupName, vmName, manager);
            } else if (action == "start") {
                StartVm (resourceGroupName, vmName, manager);
            } else {
                DisplayStatus (resourceGroupName, vmName, manager);
            }
            System.Console.WriteLine ("press any key to continue...");
            System.Console.ReadLine();
        }

        static void DisplayStatus (string resourceGroupName, string vmName, VmManager manager) {
            var status = manager.GetStatus (resourceGroupName, vmName).Result;
            System.Console.WriteLine (status);
        }
        static void StartVm (string resourceGroupName, string vmName, VmManager manager) {
            System.Console.WriteLine ("Starting...");
            manager.StartAsync (resourceGroupName, vmName).Wait ();
            System.Console.WriteLine ("Starting done");
            var status = manager.GetStatus (resourceGroupName, vmName).Result;
            System.Console.WriteLine (status);
        }

        static void StopVm (string resourceGroupName, string vmName, VmManager manager) {
            System.Console.WriteLine ("Stopping...");
            manager.StopAsync (resourceGroupName, vmName);
            System.Console.WriteLine ("Stop done");
            var status = manager.GetStatus (resourceGroupName, vmName).Result;
            System.Console.WriteLine (status);
        }
    }
}