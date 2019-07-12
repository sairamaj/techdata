### Get Api routes from directory
#### todo: need to look when no route attributes pick default controllers and http verbs
```powershell
param(
    $Path
)


    $apiRoutes = @{}
    foreach($file in (Get-ChildItem -Path $Path -Filter *.dll) ){
        #Write-Host $file.FullName
        $asm = [System.Reflection.Assembly]::LoadFrom($file.FullName)
        try{

            $apiPaths = @()
            foreach($type in ($asm.GetTypes() | Where-Object { $_.Name.EndsWith("Controller") })){
                #Write-Output "`t $type"
                $prefixAttributes = $type.GetCustomAttributes($true) | Where-Object { $_ -like '*System.Web.Http.RoutePrefixAttribute*'}
                $routePrefix = ''
                if( $prefixAttributes.length -gt  0 ){
                    $routePrefix = $prefixAttributes[0].Prefix
                }
                foreach($method in $type.GetMethods()){
                
                    $routeAttributes = $method.GetCustomAttributes($true) | Where-Object { $_ -like '*System.Web.Http.RouteAttribute*'}
                    if( $routeAttributes.length -gt 0 ){
                    
                        #Write-Output "`t `t$($routePrefix)/$($routeAttributes[0].Template)   $($routeAttributes[0].Name)"
                        $apiPath = "$($routePrefix)/$($routeAttributes[0].Template)"
                        $apiPaths += $apiPath
                        #$apiRoutes.add($apiPath,$type.Fullname)
                    }
                }
           
               if($apiPaths.length -gt 0 ){
                    $apiRoutes[$type.FullName] = $apiPaths
               }

            }


        }catch{
            Write-Warning "$($_.Exception.Message) loading $($file.FullName)..."
        }
    }

    foreach($kv in $apiRoutes.GetEnumerator() ){
        Write-Output $kv.Key
        foreach($api in $kv.Value){
            Write-Output "`t $api"
        }
    }

```