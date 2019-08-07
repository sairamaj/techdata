## Adding local group member
```powershell
try{

    Add-LocalGroupMember -Group "Performance Log Users" -Member "PQA\FiservService"  -ErrorAction Stop
}catch [Microsoft.PowerShell.Commands.MemberExistsException] {
    Write-Warning "$member already in $group"
}
```

```xml
        <ListView ItemsSource="{Binding SingleObjectValues}">

            <ListView.Style>
                <Style>
                    <Setter Property="ListView.Visibility" Value="Visible" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding SingleObjectValues}" Value="{x:Null}">
                            <Setter Property="ListView.Visibility" Value="Hidden" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ListView.Style>

            <ListView.View>
                <GridView>
                    <GridViewColumn DisplayMemberBinding="{Binding Name}" Header="Name"   />
                    <GridViewColumn DisplayMemberBinding="{Binding Value}" Header="Value"/>
                </GridView>
            </ListView.View>
        </ListView>

```
```xml
		<ListView.ItemContainerStyle>
					<Style>
						<Style.Triggers>
							<DataTrigger Binding="{Binding highlighted}" Value="True">
								<Setter Property="ListView.Foreground" Value="Red" />
							</DataTrigger>
						</Style.Triggers>
					</Style>
				</ListView.ItemContainerStyle>
```

```csharp
INotifyPropertyChanged
public event PropertyChangedEventHandler PropertyChanged;


this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ServerRunOutputPath"));

		protected void OnPropertyChanged<T>(Expression<Func<T>> selectorExpression)
		{
			if (selectorExpression == null)
			{
				throw new ArgumentNullException("selectorExpression");
			}

			var body = selectorExpression.Body as MemberExpression;
			if (body == null)
			{
				return;
			}

			var propertyName = body.Member.Name;

			PropertyChangedEventHandler handler = this.PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	
 OnPropertyChanged(() => this.HttpStatus);

````

###RDP debugging
 - Boot screen
 [serialconsole](https://cloudopszone.com/azure-serial-console/)
 [ms serialconsole](https://docs.microsoft.com/en-us/azure/virtual-machines/troubleshooting/serial-console-windows)
             ( to enable run command-> Enable EMS-> Run and then restart VM)
   - cmd
   - Esc + Tab ( ch -si 1)
   - Enter credentials
   - powershell
   - Get-service | where name -like '*Remote*'
- IP Flow
- NIC=> IP address
- NSG rules



classes
	 A  => first octet (last 3 are network ids - lot ips)  ( 0-126)
	 B  => first 2  (last 2 are network ids)    (128-192)
	 C  => first 3  (last 1 is network id  - fiewer ips) (>192)
public ip address  => no 2 people cannot have
private ip adddress
     A  => anything starting 10 (10.0.0.0  - 10.255.255.255)
     B  => 172.16.0.0 - 172.31.255.255
     C  => 192.168.0.0 - 192.168.255.255
subnet masks
   will give info about the IP . Which numbers represent the network and which one is host.
 without subnet mask the IP cannot be inferred. all network devices need both.


Subnetting
   - Sub net work
   - Easier to manage big network
   - Organization
   - Performance
   - Security

## Multiple columns group

use anonymous type
```csharp
var statusSummary = results.GroupBy(r =>
						new
						{
							Server = r.Dictionary["server"],
							Status = r.Dictionary["sc-status"]
						});
			foreach (var info in statusSummary)
			{
				this.HttpStatusSummary.Add(new HttpStatusSummary(info.Key.Server.ToString(), info.Key.Status.ToString(), info.Count()));
			}
```

### WCF OperationContext

new OperationContextScope(clientChannel);
Now you can use OperationContext.Current



### Service Principal 
setspn -Q mssqlsvc/sqlserver.pqa.net

=SQLSERVER,CN=Computers,DC=pqa,DC=net
      TERMSRV/SQLSERVER
      TERMSRV/sqlServer.pqa.net
      MSSQLSvc/sqlServer.pqa.net:1433
      MSSQLSvc/sqlServer.pqa.net
      WSMAN/sqlServer
      WSMAN/sqlServer.pqa.net
      RestrictedKrbHost/SQLSERVER
      HOST/SQLSERVER
      RestrictedKrbHost/sqlServer.pqa.net
      HOST/sqlServer.pqa.net

setspn -D mssqlsvc/sqlserver.pqa.net:1433 SQLSERVER
setspn -D mssqlsvc/sqlserver.pqa.net SQLSERVER
klist purge (to purge kerborse tickets)
[using conditions in arm templates](https://azure.microsoft.com/en-us/blog/create-flexible-arm-templates-using-conditions-and-logical-functions/)

###Azure storage
* Use Storage explorer
* Use AzCopy

### Debugging Az commands
* Use -Debug option

### Azure tip
# Unable to send request : misspelled the container name.

## .NET memory cache 4.0 missing
cd C:\Windows\Microsoft.NET\Framework\v4.0.30319
lodctr netmemorycache.ini

problem: /signin-oidc and 404 when integrating Azure Open Id
solution: app.UseAuthentication()


### User account and computer account.
https://www.sqa.org.uk/e-learning/NetServerOS02CD/page_07.htm


* Check Authentication
```powershell
Test-WSMan -ComputerName watserver1 -Credential username -Authentication Default
(Get-PSSessionConfiguration -Name Microsoft.PowerShell).Permission
```
[more info](https://www.dtonias.com/enable-powershell-remoting-check-enabled/)
[more info](http://www.hurryupandwait.io/blog/understanding-and-troubleshooting-winrm-connection-and-authentication-a-thrill-seekers-guide-to-adventure)

# delegation to work
```powershell
	Enable-WSManCredSSP -Role server -Force
	Enable-WSManCredSSP -Role client -DelegateComputer * -Force
```

# Azure Extenions are downloaded
* C:\Packages\Plugins\Microsoft.Compute.CustomScriptExtension\1.9.3\Downloads

## Terraform
### null_resource every time
[source](https://www.kecklers.com/terraform-null-resource-execute-every-time/)
```terraform
resource "null_resource" "copyartifacts" {

    triggers {
        random_number = "${timestamp()}"        # introduced to make sure that this resource will run all the time.
    }
}
```

### Convert secure string to plain 
$y = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($x.Secret)
C:\dev\a\Try\Deployment\Web\Trying\AzureRMManagement> $y = [System.Runtime.InteropServices.Marsh
system.runtime.interopservices.marshal]::PtrToStringAuto($y)


## asp.net mvc
### Passing parameters through 
<td><a class="navbar-brand" asp-area="" asp-controller="Environment" asp-action="RemoveConfirm" asp-route-name="namehere..." >
            Remove  </a></td>

# All about Service principals
```powershell
    Get-AzADServicePrincipal -DisplayName <namehere>
    Get-AzRoleAssignment -ServicePrincipalName <appid>

    New-AzRoleAssignment -RoleDefinitionName Contributor -ServicePrincipalName <appid>
```

```csharp
 private T GetValue<T>(IDictionary<string, string> items, string name, T defaultValue)
        {
            if (configItems == null)
            {
                return defaultValue;
            }

            var finalValue = defaultValue;
            if (configItems.TryGetValue(name, out var value))
            {
                if (value != null)
                {
                    try
                    {
                        var converter = TypeDescriptor.GetConverter(typeof(T));
                        finalValue = converter.CanConvertFrom(typeof(string)) ?
                            (T)converter.ConvertFrom(value) :
                            defaultValue;
                    }
                    catch (System.Exception)
                    {
						// log here
                    }
                }
            }

            return finalValue;
        }
```

## dotnet.core
### static file content 
```csharp
IHostingEnvironment hostingEnvironment
```
### Asp.net core file logging
[source](https://nblumhardt.com/2016/10/aspnet-core-file-logger/)

### Package was not being restored in .NET core 
* Remvoed PrivateAssets attribute for the package.

#### Web jobs
* Location: wwwroot\App_Data\jobs\{triggered/continuous}\{jobname}
[source](https://stackoverflow.com/questions/24903168/azure-webjobs-size-limit)

### .NET Core
* To exlude 
    * <DefaultItemExcludes>$(DefaultItemExcludes);App_Data\**\*</DefaultItemExcludes>
* To exclude from compile
    *  <Compile Remove="wwwroot\**" /> [source](http://dan.clarke.name/2017/02/including-excluding-files-from-build-with-vs2017-and-net-core/)
* Copy subdirectories(including .cs)
```msbuild
<ItemGroup>
   <Content Include=".\App_Data\**">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </Content>  
</ItemGroup>
```

### Appservice/Web jobs advanced debugging
* [source](https://blogs.msdn.microsoft.com/waws/2016/02/01/troubleshooting-a-hung-or-long-running-webjob/)

[WebJobLogs](https://blog.kloud.com.au/2016/03/14/azure-webjob-logs-demystified/)


### Powershell - Script path.
$ScriptDir = Split-Path -parent $MyInvocation.MyCommand.Path

### .NET Core Generic host
[here](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-2.2)
