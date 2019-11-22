## Recommended approach for passing parameters to deep in the dependency chain
[source](https://autofaccn.readthedocs.io/en/latest/faq/injecting-configured-parameters.html)

## Registering a Open ended Generic Type
```csharp
    builder.RegisterAssemblyTypes(config.SourceType.Assembly).AsClosedTypesOf(typeof(ISource<>));
    builder.RegisterAssemblyTypes(config.DestinationType.Assembly).AsClosedTypesOf(typeof(IDestination<>));
    builder.RegisterGeneric(typeof(DefaultDataMigration<>))
        .WithParameter(
            new ResolvedParameter(
                (pi, ctx) => pi.ParameterType == typeof(Settings),
                (pi, ctx) =>
                {
                    if (config.Settings == null)
                    {
                        return Settings.Default;
                    }
                    return config.Settings;
                }));

// Resolving them
    var dataMigrationType = typeof(DefaultDataMigration<>).MakeGenericType(new Type[] { config.ModelType });
    return (IDataMigration) this._container.Resolve(
        dataMigrationType
        , new Parameter[] {  });

```