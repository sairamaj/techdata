### Exposing C++ to PInvoke

```c
#define EXTERN_DLL_EXPORT extern "C" __declspec(dllexport)

EXTERN_DLL_EXPORT void Start(LPCTSTR szGuid, LPCTSTR szSession) {
	::MessageBox(NULL, szGuid, szSession, 0);

}
```

```csharp
  [DllImport("EventTraceViewerLib.dll", CharSet = CharSet.Unicode)]
        static extern void Start(string guid, string session);
```