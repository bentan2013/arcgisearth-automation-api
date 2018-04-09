// CPPClient.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#import "C:\\Projects\\ben-arcgisearth-automation-api\\EarthAPITestClient\\EarthAPIDLL\\bin\\Release\\EarthAPIDLL.tlb" raw_interfaces_only

using namespace EarthAPIDLL;

int main()
{
	// Initialize COM.
	HRESULT hr = CoInitialize(NULL);

	// Create the interface pointer.
	IEarthAPIDLLPtr pAPI(__uuidof(EarthAPIDLLClass));
	char ctmp[256];
	BSTR result;
	result = SysAllocStringByteLen(ctmp, 256);
	hr = pAPI->Init(&result);
	Sleep(1000);
	hr = pAPI->GetCamera(&result);
	printf("hello");
	//ULONG lResult = 0;
	//// Call the Add method.
	//pICalc->Add(5, 10, &lResult);
	//wprintf(L"The result is %d", lResult);
	// Uninitialize COM.
	CoUninitialize();
	return 0;
}

