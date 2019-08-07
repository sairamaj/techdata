### Encoding
```powershell
$Text = ‘This is a secret and should be hidden’
$Bytes = [System.Text.Encoding]::Unicode.GetBytes($Text)
$EncodedText =[Convert]::ToBase64String($Bytes)
$EncodedText
```
### Decoding
```powershell
$EncodedText = “VABoAGkAcwAgAGkAcwAgAGEAIABzAGUAYwByAGUAdAAgAGEAbgBkACAAcwBoAG8AdQBsAGQAIABiAGUAIABoAGkAZABlAG4A”
$DecodedText = [System.Text.Encoding]::Unicode.GetString([System.Convert]::FromBase64String($EncodedText))
$DecodedText
```
[source](https://adsecurity.org/?p=478)