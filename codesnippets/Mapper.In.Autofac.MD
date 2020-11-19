### Automapper in Autofac
```csharp
            builder.Register(ctx => new ConfigurationStore(new TypeMapFactory(), MapperRegistry.AllMappers()))
                .AsImplementedInterfaces()
                .SingleInstance()
                .OnActivating(x =>
                {
                    x.Instance.AddProfile(new MappingProfile());
                });

            builder.RegisterType<MappingEngine>().As<IMappingEngine>().SingleInstance();
```
