### Using WCF with Autofac
[source](https://autofaccn.readthedocs.io/en/latest/integration/wcf.html)
```csharp
    To use without hard coding the address and bindig use '*' in channel factory.

    builder
  .Register(c => new ChannelFactory<ITrackListing>("*")
  .SingleInstance();
```