## Hello world Arm templates

```json
{
    "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {},
    "variables": {},
    "resources": [],
    "outputs": {
        "response": {
            "type": "string",
            "value": "Hello world"
        }
    }
}
```

### Deploy
```cmd
az group deployment create --name helloworldtest --resource-group mygroup --template-file .\hello.world.json
```

### Get Output
```powershell
$result = Get-AzResourceGroupDeployment -ResourceGroupName mygroup -Name helloworldtest
$result.outputs.response
```

you will see __String Hello world__ result.

