```xml
<?xml version="1.0" encoding="utf-8" ?>
<package>
	<metadata>
		<id>id here</id>
		<version>1.0.0</version>
		<authors>authoere</authors>
		<description>some description here.</description>
		<requireLicenseAcceptance>false</requireLicenseAcceptance>
    <tags>some tags here</tags>
  </metadata>
  <files>
    <file src=".\lib\net45\foo.dll" target="lib\net45"/>
  </files>
</package>

```
nuget pack 
nuget push foo.nupkg -source <uri> -apikey <apikey>

``` Adding extra files through Csrpoj
 <ItemGroup>
    <Content Include="App.config">
      <Pack>true</Pack>
      <PackagePath>lib\net462\Console.exe.config</PackagePath>
    </Content>
  </ItemGroup>
```
[source](https://developercommunity.visualstudio.com/content/problem/37360/nuget-pack-does-not-include-execonfig-for-tools-pr.html)