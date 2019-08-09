### Get Azure VM Image

[source] (https://www.b-blog.info/en/get-all-images-list-for-vms-in-azure.html)

```powershell
param(
	$Location,
	$Publisher
)
#Login-AzureRmAccount;

if( $Location.length -eq 0 ){ 
	#Select Region
	$location = (Get-AzLocation).location | Out-GridView -Title "Select Azure location" -PassThru;
}
 
#Select publisher
if( $Publisher.length -eq 0){
    $Publisher = Get-AzVMImagePublisher -Location $location | Select-Object -ExpandProperty PublisherName | Out-GridView -Title "Select Publisher" -PassThru;
}

#Get all offers for selected publisher
$Alloffers = @(Get-AzVMImageOffer -Location $location -Publisher $publisher | Select-Object -ExpandProperty Offer);
#$Alloffers
return
 
#Get all images for all skus of all offers for the selected publisher
foreach ($Offer in $Alloffers)
{
    $Allskus = (Get-AzVMImageSku -Location $location -Publisher $publisher -Offer $offer | Select-Object  -ExpandProperty Skus);
    foreach ($sku in $Allskus)
    {
        $Allimages += @(Get-AzVMImage -Location $location -PublisherName $publisher -Offer $offer -Skus $sku);
    }
}
 
$Allversions = $Allimages | Select-Object Version,Skus,Offer,PublisherName | Sort-Object Skus;
 
Write-Output $Allversions;
```