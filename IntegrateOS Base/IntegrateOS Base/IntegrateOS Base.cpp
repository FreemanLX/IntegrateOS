// IntegrateOS Base.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <Windows.h>
#include <stdio.h>
#include "Include/dismapi.h"
#include <fstream>
#include <string>
#include <vector>


using namespace std;

std::wstring stringtowstring(const std::string& s)
{
	int len;
	int slength = (int)s.length() + 1; ////size lui string + 1
	len = MultiByteToWideChar(CP_ACP, 0, s.c_str(), slength, 0, 0);/// char - 1 byte, wchar - n bytes
	wchar_t* buffer = new wchar_t[len];
	MultiByteToWideChar(CP_ACP, 0, s.c_str(), slength, buffer, len);
	std::wstring r(buffer); ///const char in string, const wchar in wstring
	///r = static_cast<wstring>(buffer);
	delete[] buffer;
	return r;
}


DismSession Session;
extern "C"             //No name mangling
__declspec(dllexport)  //Tells the compiler to export the function
int                  //Function return type     
__cdecl

mount_windows(char *loc1, char* loc2, int index) {
	DWORD dwUnmountFlags = DISM_DISCARD_IMAGE;
	std::wstring wloc1 = stringtowstring(loc1); ///wstring = wide string <=> vector<wchar>
	std::wstring wloc2 = stringtowstring(loc2);
	HRESULT hr = S_OK;
	hr = DismInitialize(DismLogErrorsWarningsInfo, L"Logs\\IntegrateOSLogs.txt", NULL);
	if (FAILED(hr)) {
		wprintf(L"DismInitialize Failed: %x\n", hr);
		return -1;
	}
	hr = DismMountImage(wloc1.c_str(), wloc2.c_str(), index, NULL, DismImageIndex, DISM_MOUNT_READWRITE, NULL, NULL, NULL);
	if (FAILED(hr)) {
		return 1;
	}
	return 3; ///mounted
}


extern "C"             //No name mangling
__declspec(dllexport)  //Tells the compiler to export the function
int                  //Function return type     
__cdecl
unmount_image(char* loc2, int commit_change)
{
	HRESULT hr = S_OK;
	std::wstring wloc2 = stringtowstring(loc2);
	hr = S_OK;
	if(commit_change == 1)
	hr = DismUnmountImage(wloc2.c_str(), DISM_COMMIT_IMAGE, NULL, NULL, NULL);
	else {
		hr = DismUnmountImage(wloc2.c_str(), DISM_DISCARD_IMAGE, NULL, NULL, NULL);
	}
	if (FAILED(hr)) {
		return 2;
	}
	hr = DismShutdown();
	if (FAILED(hr)) {
		return -1;
	}
	return 3; ///unmounted
}



extern "C"             //No name mangling
__declspec(dllexport)  //Tells the compiler to export the function
const char*                  //Function return type     
__cdecl


windowsinfo(char* path) {
	UINT ImageInfoCount = 0; ///UNIT = DWORD / 2 
	DismSession session = DISM_SESSION_DEFAULT;
	DWORD dwUnmountFlags = DISM_DISCARD_IMAGE;
	std::wstring wloc = stringtowstring(path); ///wstring = wide string <=> vector<wchar>
	DismImageInfo *ImageInfo = NULL;
	HRESULT hr = S_OK;
	hr = DismInitialize(DismLogErrorsWarningsInfo, L"Logs\\IntegrateOSLogs.txt", NULL);
	if (FAILED(hr)) {
		wprintf(L"DismInitialize Failed: %x\n", hr);
	}

	hr = DismGetImageInfo(wloc.c_str(), &ImageInfo, &ImageInfoCount);
	string g = "";
	if (hr == S_OK) {
		for (int i = 0; i < ImageInfoCount; i++) {
			wstring ws(ImageInfo[i].ImageName);
			string s(ws.begin(), ws.end());
			g += s + ";";	
			hr = DismShutdown();
	  }
	   return g.c_str();
	}


}



extern "C"             //No name mangling
__declspec(dllexport)  //Tells the compiler to export the function
int                 //Function return type     
__cdecl


windowsinfo_size(char *path) {
	UINT ImageInfoCount = 0; ///UNIT = DWORD / 2 
	DismSession session = DISM_SESSION_DEFAULT;
	DWORD dwUnmountFlags = DISM_DISCARD_IMAGE;
	std::wstring wloc = stringtowstring(path); ///wstring = wide string <=> vector<wchar>
	DismImageInfo *ImageInfo = NULL;
	HRESULT hr = S_OK;
	hr = DismInitialize(DismLogErrorsWarningsInfo, L"Logs\\IntegrateOSLogs.txt", NULL);
	if (FAILED(hr)) {
		return 0;
	}
	
	hr = DismGetImageInfo(wloc.c_str(), &ImageInfo, &ImageInfoCount);
	
	if (hr == S_OK) {
		return ImageInfoCount;
	}
	return 0;

}