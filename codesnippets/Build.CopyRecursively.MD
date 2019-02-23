### Copy task recursively through msbuild

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project DefaultTargets="CopyTask" ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <BuildConfiguration>Debug</BuildConfiguration>
  </PropertyGroup>

<Target Name="CopyTask">
    <ItemGroup>
            <SomeDirConfig Include="SomeDir\$(BuildConfiguration)\Config\**\*.*" />
    </ItemGroup>
    <Copy SourceFiles="@(SomeDirConfig)" DestinationFolder="c:\temp\deleteme\testms\mydest\%(RecursiveDir)" />
</Target>

</Project>        
```