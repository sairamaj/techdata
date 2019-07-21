### Save .NET modules
* Run the below commands in windbg
    * .logopen c:\temp\module.txt
    * !dumpdomain
    * .logclose
* Run the powershell with path to save
    * Run this script in windbg
```powershell
param(
    $Path
)

    $moduleAddress = @{}
    $lines = (Get-Content c:\temp\module.txt)
    for($i=0 ; $i -lt $lines.Length ; $i++){
        if( $lines[$i] -like '*Module Name*' ){
            # next line is name and address
            $moduleInfo = $lines[++$i]
            if( $moduleInfo -notlike '*Dynamic Module*'){
                $parts = $moduleInfo.Split(@(" "),[System.StringSplitOptions]::RemoveEmptyEntries)
                $moduleAddress[$parts[0]] = ($moduleInfo -split '\\')[-1]
            }
        }
    }
    foreach($kv in $moduleAddress.GetEnumerator()){
        "!savemodule $($kv.Key) $($Path)\$($kv.Value)"
    }
```