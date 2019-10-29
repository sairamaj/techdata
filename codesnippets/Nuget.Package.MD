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