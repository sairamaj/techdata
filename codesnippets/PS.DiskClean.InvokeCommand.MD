### Cleaning up disk spaces on all computers
```powershell

    $Servers = @("ServerA")

    $Servers | % {
    Invoke-Command -ComputerName $_ -ScriptBlock {

        Write-Host "Running $($env:COMPUTERNAME) ..."

        Function Clean-Dir
        {
            param($Path)

            Write-Host "Cleaning $Path"

            foreach($file in (Get-ChildItem -Path $Path -Recurse) )
            {
                Write-Host "Removing $file.FullName"
                Remove-Item $file.FullName -Recurse -ErrorAction SilentlyContinue
            }
        }

        $paths = @("C:\Windows\SoftwareDistribution","c:\windows\temp")
        $paths | %{ Clean-Dir $_ }
    }
    }

```