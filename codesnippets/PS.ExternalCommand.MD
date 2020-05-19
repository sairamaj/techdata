# Running External commands

```powershell
    # Arguments are passsed in array
    $args = @('arg1','arg2','arg3')

    [Environment]::CurrentDirectory = $PWD
    # Setting working diretory for nativie commands

    # Note: Careful in arguments. Each argument is in one array part
```

# Getting standard ouptut and error even with errors
[source](https://mnaoumov.wordpress.com/2015/01/11/execution-of-external-commands-in-powershell-done-right/)