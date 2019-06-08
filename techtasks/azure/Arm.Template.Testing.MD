## Testing Arm template

### Create a  template with outputs, example
```json
{
    "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "environmentName": {
            "type": "string",
            "defaultValue": "[resourceGroup().name]"
        }
    },
    "variables": {},
    "resources": [],
    "outputs": {
        "response": {
            "type": "string",
            "value": "[parameters('environmentName')]"
        }
    }
}
```

### Run deployment and verify the output
```powershell
$results = New-AzResourceGroupDeployment -TemplateFile .\hello.world.json -ResourceGroupName deletemesai
$results.output.response
```