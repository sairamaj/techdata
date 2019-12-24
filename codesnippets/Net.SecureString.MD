### Secure string

#### Converting to managed
```csharp
String SecureStringToString(SecureString value) {
  IntPtr valuePtr = IntPtr.Zero;
  try {
    valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
    return Marshal.PtrToStringUni(valuePtr);
  } finally {
    Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
  }
}

## Another way
string theString = new NetworkCredential("", theSecureString).Password;
```
[source](https://stackoverflow.com/questions/818704/how-to-convert-securestring-to-system-string)

#### Witout converting to managed
```csharp
void HandleSecureString(SecureString value) {
  IntPtr valuePtr = IntPtr.Zero;
  try {
    valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
    for (int i=0; i < value.Length; i++) {
      short unicodeChar = Marshal.ReadInt16(valuePtr, i*2);
      // handle unicodeChar
    }
  } finally {
    Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
  }
}
```

#### String so SecureString
```csharp
    SecureString theSecureString = new NetworkCredential("", "myPass").SecurePassword;
```