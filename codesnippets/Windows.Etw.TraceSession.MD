## Trace Manager
```c
#include "stdafx.h"
#include "TraceSessionManager.h"
#include <combaseapi.h>

TraceSessionManager::TraceSessionManager()
{
	_pSession = NULL;
}


TraceSessionManager::~TraceSessionManager()
{
}

int TraceSessionManager::Start(LPCTSTR szProviderGuid, LPCTSTR szSessionName) {
	wprintf(L"In TraceSessionManager.Start");
	if (_pSession != NULL) {
		return -1;
	}

	GUID nodeGuid;

	ZeroMemory(&nodeGuid, sizeof(GUID));
	if (IIDFromString(szProviderGuid, &nodeGuid) != S_OK)
	{
		wprintf(L"Failed to get GUID from string:%s", szProviderGuid);
		return 1;
	}

	
	_pSession = new TraceSession(szSessionName);
	wprintf(L"Starting the trace:%s : for:%s...\n", szSessionName, szProviderGuid);
	if (!_pSession->Start()) {
		if (_pSession->Status() == ERROR_ALREADY_EXISTS) {
			if (!_pSession->Stop() || !_pSession->Start()) {
				wprintf(L"Error in trace session %d", _pSession->Status());
				return ERROR_ALREADY_EXISTS;
			}
		}
	}

	wprintf(L"Enable Provider...\n");
	if (!_pSession->EnableProvider(nodeGuid, TRACE_LEVEL_VERBOSE))
	{
		wprintf(L"Error in enabling provider %d", _pSession->Status());
	}
	return 0;
}
```
