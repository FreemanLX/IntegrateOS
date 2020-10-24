// IntegrateOS Base.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <Windows.h>
#include <stdio.h>
#include "Include/dismapi.h"
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>


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


ofstream g("Logs\\IntegrateOSBase2Logs.txt");

std::string exec(const char* cmd, int type = 0)
{
	char buffer[128];
	std::string result = "";
	FILE* pipe = _popen(cmd, "r");
	if (!pipe) throw std::runtime_error("popen() failed!");
	try
	{
		while (fgets(buffer, sizeof buffer, pipe) != NULL)
		{
			if (type == 0)
				result = buffer;
			else
				result += buffer;
		}
	}
	catch (...)
	{
		_pclose(pipe);
		throw;
	}
	_pclose(pipe);
	return result;
}

int uefi()
{
	string t = exec("powershell $(Get-ComputerInfo).BiosFirmwareType", 1);
	t.erase(remove(t.begin(), t.end(), '\n'), t.end());
	return (t == "Uefi");
}

void error_log(int i) {
	switch (i) {
	case 0:
	{g << "FAIL BOOTSECT"; break; }

	case 1: {g << "FAIL BCDBOOT"; break; }
	case 2: {g << "FAIL BCDEDIT"; break; }
	default: break;

	}


}

int bcdboot(char *format)
{
	string sformat(format);
	string s = "bcdboot " + sformat + "\\Windows /s " + sformat + "\\ /f all";
	string output = exec(s.c_str());
	output.erase(remove(output.begin(), output.end(), '\n'), output.end());
	g << "OK BCDBOOT" << endl;
	return output == "Boot files successfully created.";

}



int bootsect(char *format)
{
	string sformat(format);
	string s = "bootsect /NT60 " + sformat + " /force";
	string output = exec(s.c_str());
	output.erase(remove(output.begin(), output.end(), '\n'), output.end());
	g << "OK BOOTSECT" << endl;
	return output == "Bootcode was successfully updated on all targeted volumes.";

}




int bcdedit(char *format, char* nickname, int uefi1 = -1)
{
	string sformat(format);
	string snickname(nickname);
	string s = "bcdedit /copy {current} /d \"" + snickname + "\"";
	string output = exec(s.c_str());
	if (output == "The parameter is incorrect.")
	{
		return 0;
	}
	string code = output.substr(output.find("{"), output.find("}"));
	code.erase(remove(code.begin(), code.end(), '.'), code.end());
	code.erase(remove(code.begin(), code.end(), '\n'), code.end());
	string bcddevice = "bcdedit.exe /set " + code + " device partition=" + sformat;
	string bcdosdevice = "bcdedit.exe /set " + code + " osdevice partition=" + sformat;
	output = exec(bcddevice.c_str());
	output.erase(remove(output.begin(), output.end(), '\n'), output.end());
	if (output == "The parameter is incorrect.")
	{
		return 0;
	}
	output = exec(bcdosdevice.c_str());
	output.erase(remove(output.begin(), output.end(), '\n'), output.end());
	if (output == "The parameter is incorrect.")
	{
		return 0;
	}
	string path;
	if (uefi1 == -1)
	{
		if (uefi() == 1)
		{
			path = "Packages\\bcdedit.exe /set " + code + " path \\Windows\\system32\\winload.efi";
		}
		else
		{
			path = "Packages\\bcdedit.exe /set " + code + " path \\Windows\\system32\\winload.exe";
		}
	}
	else
	{
		if (uefi1 == 1)
		{
			path = "Packages\\bcdedit.exe /set " + code + " path \\Windows\\system32\\winload.efi";
		}
		if (uefi1 == 0)
		{
			path = "Packages\\bcdedit.exe /set " + code + " path \\Windows\\system32\\winload.exe";
		}
	}

	output = exec(path.c_str());
	output.erase(remove(output.begin(), output.end(), '\n'), output.end());
	if (output == "The system cannot find the path specified.")
	{
		return 0;
	}
	string systemroot = "Packages\\bcdedit.exe /set " + code + " systemroot \\Windows";
	output = exec(systemroot.c_str());
	output.erase(remove(output.begin(), output.end(), '\n'), output.end());
	if (output == "The system cannot find the path specified.")
	{
		return 0;
	}
	g << "OK BCDEDIT" << endl;
	return 1;

}

extern "C"             //No name mangling
__declspec(dllexport)  //Tells the compiler to export the function
int                  //Function return type
__cdecl

complete(char *part, char *nick, int i)
{
	g << part << "  " << nick;
	if (bootsect(part) == 0) {
		error_log(0);
		return 0;
	}
	if (bcdboot(part) == 0) {
		error_log(1);
		return 0;
	}
	if (bcdedit(part, nick, i) == 0) {
		error_log(2);
		return 0;
	}
	return 1;
}