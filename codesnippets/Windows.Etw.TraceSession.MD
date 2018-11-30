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

TraceSession::TraceSession(LPCTSTR szSessionName) : _szSessionName(_tcsdup(szSessionName))
{
}

TraceSession::~TraceSession(void)
{
	delete[]_szSessionName;
	delete _pSessionProperties;
}

bool TraceSession::Start()
{
	if (!_pSessionProperties) {
		const size_t buffSize = sizeof(EVENT_TRACE_PROPERTIES) + (_tcslen(_szSessionName) + 1) * sizeof(TCHAR);
		_pSessionProperties = reinterpret_cast<EVENT_TRACE_PROPERTIES *>(malloc(buffSize));
		ZeroMemory(_pSessionProperties, buffSize);
		_pSessionProperties->Wnode.BufferSize = buffSize;
		_pSessionProperties->Wnode.ClientContext = 1;
		_pSessionProperties->LogFileMode = EVENT_TRACE_REAL_TIME_MODE;
		_pSessionProperties->LoggerNameOffset = sizeof(EVENT_TRACE_PROPERTIES);
	}

	// Create the trace session.
	_status = StartTrace(&hSession, _szSessionName, _pSessionProperties);

	return (_status == ERROR_SUCCESS);
}

bool TraceSession::EnableProvider(const GUID& providerId, UCHAR level, ULONGLONG anyKeyword, ULONGLONG allKeyword)
{
	_status = EnableTraceEx2(hSession, &providerId, EVENT_CONTROL_CODE_ENABLE_PROVIDER, level, anyKeyword, allKeyword, 0, NULL);
	return (_status == ERROR_SUCCESS);
}

bool TraceSession::CloseTrace()
{
	_status = ::CloseTrace(_hTrace);
	return (_status == ERROR_SUCCESS);
}

bool TraceSession::DisableProvider(const GUID& providerId)
{
	_status = EnableTraceEx2(hSession, &providerId, EVENT_CONTROL_CODE_DISABLE_PROVIDER, 0, 0, 0, 0, NULL);
	return (_status == ERROR_SUCCESS);
}

bool TraceSession::Stop()
{
	_status = ControlTrace(hSession, _szSessionName, _pSessionProperties, EVENT_TRACE_CONTROL_STOP);
	delete _pSessionProperties;
	_pSessionProperties = NULL;

	return (_status == ERROR_SUCCESS);
}

ULONG TraceSession::Status() const
{
	return _status;
}
```
