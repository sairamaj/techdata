### Invoking a script as another user
```powershell
Function Invoke-ScriptAsUser{
    param(
    $User,
    $Password,
    $Script
    )

    $SecurePassword = ConvertTo-SecureString $Password -AsPlainText -Force
    $Credentials = New-Object System.Management.Automation.PSCredential ($User,$SecurePassword)
    
    Invoke-Command -ScriptBlock {
        param(
            $Script
        )
        Write-Host "Executing $Script"
        & $Script
    } -ComputerName $env:COMPUTERNAME -Credential $Credentials -Authentication Credssp -ArgumentList ($Script)
}
```