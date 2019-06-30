## If Usage
The storage template was taken from [here](https://github.com/Azure/azure-quickstart-templates/blob/master/101-storage-account-create/azuredeploy.json) and __if__ was added for demo purpose


```json
{
    "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "storageAccountType": {
            "type": "string",
            "defaultValue": "Standard_LRS",
            "allowedValues": [
                "Standard_LRS",
                "Standard_GRS",
                "Standard_ZRS",
                "Premium_LRS"
            ],
            "metadata": {
                "description": "Storage Account type"
            }
        },
        "location": {
            "type": "string",
            "defaultValue": "[resourceGroup().location]",
            "metadata": {
                "description": "Location for all resources."
            }
        },
        "servertype": {
            "type": "string",
            "metadata": {
                "description": "Demonstrates if usage"
            }
        }
    },
    "variables": {
        "storageAccountName": "[concat('delteme', if(equals(parameters('servertype'),'dev'), 'dev', 'prod'))]"
    },
    "resources": [{
        "type": "Microsoft.Storage/storageAccounts",
        "name": "[variables('storageAccountName')]",
        "location": "[parameters('location')]",
        "apiVersion": "2018-07-01",
        "sku": {
            "name": "[parameters('storageAccountType')]"
        },
        "kind": "StorageV2",
        "properties": {}
    }],
    "outputs": {
        "storageAccountName": {
            "type": "string",
            "value": "[variables('storageAccountName')]"
        }
    }
}
```
```cmd
az group deployment create --name iftest --resource-group deletemesai  --template-file .\if.demo.template.json --parameters servertype=dev
```

```powershell
$result = Get-AzResourceGroupDeployment -ResourceGroupName mygroup -Name helloworldtest
$result.outputs["storageAccountName"]
```