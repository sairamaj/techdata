# Azure function creation
[source](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-azure-function-azure-cli)

## Using Azure function tools
* Install azure function tools

```cmd
npm i -g azure-functions-core-tools --unsafe-perm true
func --version
func init Math  (Initializes func environment)
cd to Math
func new  (creating a function - select HttpTrigger for api , give Add)
func new (creating another function , give Sub)

# edit Add.cs and Sub.cs to change function authorization level to Anonymous

# starting function locally
func start --build

```

you should see 2 Http functions when you run func start --build

From powershell
```powershell
invoke-restmethod http://localhost:7071/api/Add?name=something
```

## Deploy
```cmd
# Create resurce group
az group create --name functest --location westus
# Create storage 
az storage account create --name functeststorage123 --location westus --resource-group functest --sku Standard_LRS
# Create function app
az functionapp create --resource-group functest --consumption-plan-location westus --name funcappmath --storage-account  functeststorage123
# force is used to upgrade it to v2
func azure functionapp publish funcappmath --force
```

```powershell
Invoke-WebRequest -Uri "https://funcappmath.azurewebsites.net/api/Add?name=thisisadd"
```

```cmd
# remove
az group delete --name functest --yes --no-wait
```