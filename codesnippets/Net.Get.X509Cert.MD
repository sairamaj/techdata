### Loading X509 Certificate

```csharp
  public static X509Certificate2 GetCert(string thumbprint)
        {
            System.Console.WriteLine($"Get certificate: {thumbprint}");
            using (var certStore = new X509Store(StoreName.My, StoreLocation.LocalMachine))
            {
                certStore.Open(OpenFlags.ReadOnly);
                var certCollection = certStore.Certificates.Find(
                                           X509FindType.FindByThumbprint,
                                            thumbprint,
                                           false);
                System.Console.WriteLine($"cert collection: {certCollection.Count}");
                // Get the first cert with the thumbprint
                if (certCollection.Count > 0)
                {
                    X509Certificate2 cert = certCollection[0];
                    // Use certificate
                    Console.WriteLine(cert.FriendlyName);
                    return cert;
                }
            }
            throw new ArgumentException($"Certificate :{thumbprint} not found");
        }
```