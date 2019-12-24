```powershell
# Initialize hash table
    $x = @{"a"=1; "b"=2}
# Creating COM object
    $WshShell = New-Object -ComObject WScript.Shell
# Suppressting Console.writeline
    $stringWriter = New-Object System.IO.StringWriter
    [System.Console]::SetOut($stringWriter)

```