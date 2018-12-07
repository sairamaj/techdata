```c
#define EXTERN_DLL_EXPORT extern "C" __declspec(dllexport)

TraceSessionManager g_Session;
EXTERN_DLL_EXPORT int Start(LPCTSTR szProviderGuid, LPCTSTR szSession) {
	return g_Session.Start(szProviderGuid, szSession);
}

EXTERN_DLL_EXPORT void Stop(LPCTSTR szSession) {
	::MessageBox(NULL, L"stop", szSession, 0);
}


```