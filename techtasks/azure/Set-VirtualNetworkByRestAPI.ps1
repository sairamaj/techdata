param(
    [Parameter(Mandatory)]
    $ResourceGroupName,
    [Parameter(Mandatory)]
    $VirtualNetworkName,
    [Parameter(Mandatory)]
    [string[]]
    $DnsServers,
    [Parameter(Mandatory)]
    $TenantId,
    [Parameter(Mandatory)]
    $SubscriptionId,
    [Parameter(Mandatory)]  
    $ClientId,
    [Parameter(Mandatory)]
    $ClientSecret
)

Function Get-Token{
    $uri = "https://login.microsoftonline.com/$TenantId/oauth2/token" 
    $body = @{ }
    $body["grant_type"] = "client_credentials"
    $body["client_id"] = $ClientId
    $body["client_secret"] = $ClientSecret
    $body["resource"] = "https://management.azure.com/"

    # get access token.
    $response = Invoke-WebRequest -Method Post -Uri $uri -Body $body 
    $tokenInfo = ConvertFrom-Json $response.Content
    $tokenInfo.access_token
}

Function Get-VNet{
    param(
        $Token
    )
    $apiUrl = "https://management.azure.com/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Network/virtualNetworks/$($VirtualNetworkName)?api-version=2019-06-01&"
    $headers = @{"Authorization"="bearer "+  $Token}
    Invoke-RestMethod -Uri $apiUrl -Headers $headers
}

Function Set-VNet{
    param(
        $Token,
        $VNet
    )
    $apiUrl = "https://management.azure.com/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Network/virtualNetworks/$($VirtualNetworkName)?api-version=2019-06-01&"
    $headers = @{"Authorization"="bearer "+  $Token}
    $body = (ConvertTo-Json $VNet -Depth 10)
    $body
    Invoke-RestMethod -Uri $apiUrl -Headers $headers -Body $body -Method Put -ContentType "application/json"
}

$Token = Get-Token
$VNet = Get-VNet -Token $Token
# Update Dns server
$VNet.Properties.dhcpOptions.dnsServers = $DnsServers

Set-VNet -Token $Token -VNet $VNet



