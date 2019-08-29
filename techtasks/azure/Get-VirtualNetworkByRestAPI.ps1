param(
    [Parameter(Mandatory)]
    $TenantId,
    [Parameter(Mandatory)]
    $SubscriptionId,
    [Parameter(Mandatory)]
    $ResourceGroupName,
    [Parameter(Mandatory)]
    $VirtualNetworkName,
    [Parameter(Mandatory)]
    $ClientId,
    [Parameter(Mandatory)]
    $ClientSecret
)

$uri = "https://login.microsoftonline.com/$TenantId/oauth2/token" 
$body = @{ }
$body["grant_type"] = "client_credentials"
$body["client_id"] = $ClientId
$body["client_secret"] = $ClientSecret
$body["resource"] = "https://management.azure.com/"

# get access token.
$response = Invoke-WebRequest -Method Post -Uri $uri -Body $body 
$tokenInfo = ConvertFrom-Json $response.Content


$apiUrl = "https://management.azure.com/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Network/virtualNetworks/$($VirtualNetworkName)?api-version=2019-06-01&"
$apiUrl
$headers = @{"Authorization"="bearer "+  $tokenInfo.access_token}
$x = Invoke-RestMethod -Uri $apiUrl -Headers $headers
$x.Properties.dhcpOptions
