### MSBuild properties
[Prop files](https://docs.microsoft.com/en-us/visualstudio/msbuild/customize-your-build?view=vs-2019)

### Examples
#### Package property in source directory
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project>
  <PropertyGroup>
    <Description>Assembly</Description>
    <Authors>Cutom</Authors>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="NuGet.Build.Tasks.Pack">
      <Version>1.0.0</Version>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>
</Project>
```
#### Test in test source directory
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project>
  <ItemGroup>
    <PackageReference Include="Microsoft.CodeCoverage">
      <Version>15.9.0</Version>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="NUnit3TestAdapter">
      <Version>3.11.0</Version>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>
</Project>
```

