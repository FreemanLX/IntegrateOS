///GLOBAL DEFINE

#define _WIN32_WINNT 0x0500
#define _CRT_SECURE_NO_WARNINGS

///INCLUDE ZONES

/* 
   void nume(){
       

	    part1:
		   ///cod cod
		   goto part2


		part2:
		   goto part1

*/


#include <vector>
#include <string>
#include <iostream>
#include <cstring>
#include <fstream>
#include <windows.h>
#include <cstdlib>
#include <tchar.h>
#include <ostream>
#include <sstream>
#include <commdlg.h>
#include <shlobj.h>
#include <fileapi.h>
#include <mfapi.h>
#include <direct.h>
#include "E:\Windows Kits\10\Assessment and Deployment Kit\Deployment Tools\SDKs\DismApi\Include\dismapi.h"
#include <stdio.h>
#include <libloaderapi.h>



///DEFINE ZONES

#define Openfilename OPENFILENAME
#define GetCurrentDir _getcwd ////

#ifndef NOMINMAX
#define NOMINMAX
#endif


///NAMESPACES

using namespace std;

namespace get_kernel_path {

	string get_kernel_path() {
		return "NULL";


	}



};


namespace get_current_path {
	string get_current_path() {
		char cCurrentPath[FILENAME_MAX];
		if (!GetCurrentDir(cCurrentPath, sizeof(cCurrentPath)))
		{
			cout << "Error getting path [CODE: 0x8]" << endl;
			exit(8);
		}

		cCurrentPath[sizeof(cCurrentPath) - 1] = '/0'; /* not really required */
		return static_cast<string>(cCurrentPath);
	}



};

namespace select_a_file {


	static int CALLBACK BrowseCallbackProc(HWND hwnd, UINT uMsg, LPARAM lParam, LPARAM lpData)
	{

		if (uMsg == BFFM_INITIALIZED)
		{
			std::string tmp = (const char *)lpData;
		///	std::cout << "path: " << tmp << std::endl;
			SendMessage(hwnd, BFFM_SETSELECTION, TRUE, lpData);
		}

		return 0;
	}

	std::string BrowseFolder_partition()
	{
		TCHAR path[MAX_PATH];
		std::string saved_path;
		const char * path_param = saved_path.c_str();

		BROWSEINFO bi = { 0 };
		bi.lpszTitle = ("Browse for folder / partition to install Windows");
		bi.ulFlags = BIF_RETURNONLYFSDIRS | BIF_NEWDIALOGSTYLE;
		bi.lpfn = BrowseCallbackProc;
		bi.lParam = (LPARAM)path_param;

		LPITEMIDLIST pidl = SHBrowseForFolder(&bi);

		if (pidl != 0)
		{
			//get the name of the folder and put it in path
			SHGetPathFromIDList(pidl, path);

			//free memory used
			IMalloc * imalloc = 0;
			if (SUCCEEDED(SHGetMalloc(&imalloc)))
			{
				imalloc->Free(pidl);
				imalloc->Release();
			}

			return path;
		}

		return "";
	}


	string select_a_file(string file_type, string message)
	{
		char filename[MAX_PATH];
		Openfilename ofn;
		ZeroMemory(&filename, sizeof(filename));
		ZeroMemory(&ofn, sizeof(ofn));
		ofn.lStructSize = sizeof(ofn);
		ofn.hwndOwner = NULL;
		///  ofn.lpstrFilter  = _T(file_type.c_str());
		ofn.lpstrFile = filename;
		ofn.nMaxFile = MAX_PATH;
		ofn.lpstrTitle = _T(message.c_str());
		ofn.Flags = OFN_FILEMUSTEXIST | OFN_PATHMUSTEXIST;

		if (GetOpenFileName(&ofn))
		{
			string filename_t = static_cast<string>(filename);
			char* s = strtok(filename, ".");
			s = strtok(NULL, ".");
			if (strcmp(s, file_type.c_str()) != 0) {
				std::cout << "You didn't chose the correct file" << endl;
				return static_cast<string>("NULL");
			}
			std::cout << "You chose the file \"" << filename_t << "\"\n";
			return filename_t;
		}
		else
		{
			DWORD error_type = CommDlgExtendedError();
			///DWORD = long long unsigned int
			switch (error_type)
			{
			case CDERR_DIALOGFAILURE: std::cout << "CDERR_DIALOGFAILURE\n";   break;
			case CDERR_FINDRESFAILURE: std::cout << "CDERR_FINDRESFAILURE\n";  break;
			case CDERR_INITIALIZATION: std::cout << "CDERR_INITIALIZATION\n";  break;
			case CDERR_LOADRESFAILURE: std::cout << "CDERR_LOADRESFAILURE\n";  break;
			case CDERR_LOADSTRFAILURE: std::cout << "CDERR_LOADSTRFAILURE\n";  break;
			case CDERR_LOCKRESFAILURE: std::cout << "CDERR_LOCKRESFAILURE\n";  break;
			case CDERR_MEMALLOCFAILURE: std::cout << "CDERR_MEMALLOCFAILURE\n"; break;
			case CDERR_MEMLOCKFAILURE: std::cout << "CDERR_MEMLOCKFAILURE\n";  break;
			case CDERR_NOHINSTANCE: std::cout << "CDERR_NOHINSTANCE\n";     break;
			case CDERR_NOHOOK: std::cout << "CDERR_NOHOOK\n";          break;
			case CDERR_NOTEMPLATE: std::cout << "CDERR_NOTEMPLATE\n";      break;
			case CDERR_STRUCTSIZE: std::cout << "CDERR_STRUCTSIZE\n";      break;
			case FNERR_BUFFERTOOSMALL: std::cout << "FNERR_BUFFERTOOSMALL\n";  break;
			case FNERR_INVALIDFILENAME: std::cout << "FNERR_INVALIDFILENAME\n"; break;
			case FNERR_SUBCLASSFAILURE: std::cout << "FNERR_SUBCLASSFAILURE\n"; break;
			default: std::cout << "You cancelled.\n";
			}
			return static_cast<string>("NULL");
		}
	}


}

namespace Graphics
{

	template <typename T>
	T getline_type(istream &in)
	{
		string read;
		in >> read;
		T temp;
		std::stringstream convert(read);
		convert >> temp;
		return temp;
	}


	void error(const char *file, int line, int err)
	{
		cout << file << "   " << line << " " << " " << err << endl;
	}

	class UI
	{
		static int transparency_t;
		static int backcolor_t;
		static int forecolor_t;

	public:
		UI()
		{

		}
		UI(int transparency, int forecolor, int backcolor)
		{
			transparency_t = transparency;
			forecolor_t = forecolor;
			backcolor_t = backcolor;
			string combination = static_cast<ostringstream*>( &(ostringstream() << backcolor) )->str() + static_cast<ostringstream*> ( &(ostringstream() << forecolor) )->str();
			string color = "color ";
			system((color + combination).c_str());
			HWND hWnd = GetConsoleWindow();
			LONG lRet = SetWindowLong(hWnd, GWL_EXSTYLE,
				GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_LAYERED);
			lRet = SetLayeredWindowAttributes(hWnd, 0, transparency, LWA_ALPHA);
			if (lRet)
			{
				cout << "Transparency imported successfully" << endl;
			}
			else
			{
				error(__FILE__, __LINE__, GetLastError());
			}
		}
		void hidden_setter(int transparency, int forecolor, int backcolor)
		{
			transparency_t = transparency;
			forecolor_t = forecolor;
			backcolor_t = backcolor;
		}
		static vector <int> getter()
		{
			vector <int> temp;
			temp.push_back(transparency_t);
			temp.push_back(backcolor_t);
			temp.push_back(forecolor_t);
			return temp;
		}
	};
	int UI::backcolor_t = 0;
	int UI::forecolor_t = 0;
	int UI::transparency_t = 250;


	void settings()
	{
		vector<int> e = UI::getter();
		for (int i = 0; i < e.size(); i++) {
			switch (i) {
			case 0: {
				cout << "Transparency: " << e[i] << endl;
				break; }

			case 1: {
				cout << "Backcolor: " << e[i] << endl;
				break; }

			case 2: {
				cout << "Forecolor: " << e[i] << endl;
				break; }
			default: {
				break;
			}
			}

		}
		cout << "Do you want to change the UI? (1 - Yes / 0 - No): ";
		int temp;
		try
		{
			do
			{
				cin >> temp;
				if (temp < 0 || temp > 1)
					cout << "You inserted a bad number ... retry" << endl;
			} while (!(temp >= 0 && temp <= 1));
		}
		catch (std::ios_base::failure &fail) {} ///catch {}
		cout << "Transparency:";
		int t;
		cin >> t;

	}

	void set_window_console()
	{
		cout << "Select one of 5 colors for background" << endl;
		cout << "Yellow (1), Red (2), Green (3), Blue (4), Black (0): ";
		int s = getline_type<int>(cin);
		int backcolor, forecolor;
		if (s == 1)
		{
			system("color 60");
			backcolor = 6;
			forecolor = 0;
		}
		if (s == 2)
		{
			system("color 47");
			backcolor = 4;
			forecolor = 7;
		}
		if (s == 3)
		{
			system("color 27");
			backcolor = 2;
			forecolor = 7;
		}
		if (s == 4)
		{
			system("color 17");
			backcolor = 1;
			forecolor = 7;
		}
		if (s == 0)
		{
			system("color");
			backcolor = 0;
			forecolor = 7;
		}
		if(s >= 5){
			exit(5); ////Error
		}
		cout << "Enable transparency: ";
		int t;
		do
		{
			t = getline_type<int>(cin);
			if (t == 0 || t == 1)
				break;
		} while (true);
		system("cls");
		UI* temp = new UI();
		temp->hidden_setter(180, forecolor, backcolor);
		cout << "Loading the application  " << endl;
		LONG lRet;
		HWND hWnd = GetConsoleWindow();
		cout << "Set the console title " << endl;
		system("timeout 1 > null");
		SetConsoleTitle("IntegrateOS Mini - alpha v0.0.0.1");
		if (t == 1)
		{
			cout << "Set the transparency " << endl;
			system("timeout 1 > null");
			lRet = SetWindowLong(hWnd, GWL_EXSTYLE,
				GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_LAYERED);
			lRet = SetLayeredWindowAttributes(hWnd, 0, 190, LWA_ALPHA); ///190 / 200 - opacitatea
			if (lRet)
			{
				cout << "Application loaded successfully" << endl;
			}
			else
			{
				error(__FILE__, __LINE__, GetLastError());
			}
		}
		else
		{

			cout << "Application loaded successfully" << endl;
		}
	}

};

namespace Message {
	void After_loading_message() {
		cout << "Verifying your computer to check your system requirements" << endl;
		SYSTEM_INFO SysInfo;
		GetSystemInfo(&SysInfo);
		///GetVersionEx(&SysInfo);
	   /// GlobalMemoryStatus(&SysInfo);
		printf("Hardware information: \n");
		printf("*OEM ID: %lu\n", SysInfo.dwOemId);
		printf("*Number of processors: %lu\n", SysInfo.dwNumberOfProcessors);
		printf("*Page size: %lu\n", SysInfo.dwPageSize);
		printf("*Processor type: %lu\n", SysInfo.dwProcessorType);
	}
	int Message_t() {
		cout << "Welcome user to IntegrateOS Mini." << endl;
		cout << "This program was made for low computers" << endl;
		cout << "You need to accept the following licence:" << endl;
		cout << "MIT License\n\n\nCopyright (c) 2020 Andreas Mihalea" << endl << endl;
		cout << "Permission is hereby granted, free of charge, to any person obtaining a copy\n\
of this software and associated documentation files (the \"Software\"), to deal\n\
in the Software without restriction, including without limitation the rights\n\
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell\n\
copies of the Software, and to permit persons to whom the Software is\n\
furnished to do so, subject to the following conditions:\n\
The above copyright notice and this permission notice shall be included in all\n\
copies or substantial portions of the Software.\n\
\n\
THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\n\
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\n\
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\n\
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\n\
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\n\
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\n\
SOFTWARE.\n";
		cout << "Accept licence?";
		cout << endl << "Yes / No: ";
		string s;
		do {
			cin >> s;
			if (s == "Yes" || s == "No")
				break;
			else {
				cout << endl << "Yes / No: ";
			}
		} while (true);
		if (s == "Yes") {
			system("cls");
			return 1;
		}
		else {
			return 0;
		}
	}
	void Everytype_message(int e) {
		switch (e) {
		case 1: {cout << "1. WIM: Windows Imaging Format is a file-based disk image format. (for advanced users only)" << endl; break; }
		case 2: {cout << "2. ESD: Electronic Software Download is a technology that is used for downloading purchased Microsoft products. (for advanced users only)." << endl; break; }
		case 3: {cout << "3. SWM: Is the same concept like WIM, but made for diskettes" << endl; break; }
		case 4: {cout << "4. ISO: It is an archive file that contains everything that would be written to an optical disc, sector by sector, including the optical disc file system." << endl; break; }
		case 5: {cout << "5. Folder: Select a Windows Root Folder, and this program will install the Windows!\n\
(It requires more space than usually)" << endl; break; }
		case 6: {cout << "2. IntegrateOS Tools" << endl; break; }
		case 7: {cout << "1. Select an operating System" << endl; break; }
		case 8: {cout << "3. IntegrateOS Settings" << endl; break; }
		default: {cout << " "; break; }
		}





	}
};

namespace Format_Partition {
	void format(string partition_t, string fs, string label = "Local Disk", string flag = "2048") {
		string complete = "format " + partition_t + " /fs: " + fs + " /v:" + label + " /q /a:" + flag;
		system(complete.c_str());
	}





};

namespace Install_Windows {

	string location, type, partition_letter;
	bool uefi = false;
	namespace Bcdboot {
		void Bcdboot() {
			string s;
			if (uefi == false) {
				s = "bcdboot " + partition_letter + "\\Windows /s " + partition_letter;
			}
			else {
				s = "bcdboot " + partition_letter + "\\Windows /s " + partition_letter + " /f all";
			}
			system(s.c_str());
		}

	};
	namespace Bcdedit {
		void Bcdedit() {


		}


	};
	namespace Bootsect {
		void Bootsect() {
			string s = "bootsect /NT60 " + partition_letter + " /force"; ///if is a partition
			system(s.c_str());
		}

	};
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

	namespace DISM {
		int getimginfo(string loc) {
			UINT ImageInfoCount = 0; ///UNIT = DWORD / 2 
				DismSession session = DISM_SESSION_DEFAULT;
				DWORD dwUnmountFlags = DISM_DISCARD_IMAGE;
			    std::wstring wloc = stringtowstring(loc); ///wstring = wide string <=> vector<wchar>
				//wide char
				DismImageInfo *ImageInfo = NULL;
				HRESULT hr = S_OK; 
				hr = DismInitialize(DismLogErrorsWarningsInfo, L"C:\\IntegrateOSLogs.txt", NULL);
				if (FAILED(hr)) {
					wprintf(L"DismInitialize Failed: %x\n", hr);
					return -1;
				}
				///wloc, wstring => const wchar
				hr = DismGetImageInfo(wloc.c_str(), &ImageInfo, &ImageInfoCount);
				if (hr == S_OK) {
					cout << "Select an Edition" << endl;
					for (UINT i = 0; i < ImageInfoCount; ++i) {
						cout << " " << i << ") ";
						wprintf(L"%s\n", ImageInfo[i].ImageName);
						
					}

					int e = Graphics::getline_type<int>(cin);
					hr = DismShutdown();
					return e;
				}
				else {
					cout << "Dism failed getting the image" << endl;
					exit(-1);
					return -1;
				}
			
			return 0;
		}

		int applying(int type, int index, string loc) {
			if (index == -1)
				return 0;
			cout << "Select a location / Partition" << endl;
			string applyimg = select_a_file::BrowseFolder_partition();
			string applyimg1 = applyimg + "\\e.test";
			//cout << applyimg1 << endl;
			//system("pause");
			//std::wstring e = stringtowstring(applyimg1);

			/*first_try:
				HANDLE hr = CreateFileW( ///wstring sau const wchar
					e.c_str(),           
					GENERIC_READ | GENERIC_WRITE,
					0, ///standard user sau guest / echivalent cu 3 (daca ai rulat ca administrator)
					NULL,
					CREATE_NEW,
					FILE_ATTRIBUTE_NORMAL, ///atrib 
					NULL);
				if (hr == INVALID_HANDLE_VALUE) {
					cout << "Is not writable! Error 0x6!" << endl;
					exit(6);
				}
*/                
			std::ofstream f(applyimg1);
			if (f) {
				f << "";
				if (f.bad()) {

					cout << "The selected folder isn't writable [CODE: 0x6]!" << endl;
					f.clear();
					exit(6);
				}
				f.clear();
				cout << "Your path is: " << applyimg;
				partition_letter = applyimg; ///move to general
				cout << "Do you really want to install Windows? [Y / N]" << endl;
				string e = Graphics::getline_type<string>(cin);
				if (e == "Yes" || e == "yes" || e == "y" || e == "Y") {
					   DismSession session = DISM_SESSION_DEFAULT;
					   DWORD dwUnmountFlags = DISM_DISCARD_IMAGE;
					   std::wstring wloc = stringtowstring(loc);
					///   DismImageInfo *ImageInfo = NULL;
					   HRESULT hr = S_OK;
					   if (type == 0) ///if the file type is WIM
					   {



					   }
					   if (type == 1) ///if the file type is ESD
					   {





					   }
					   if (type == 2) ///if the file type is SWM
					   {




					   }
					   ///installing windows;

				}
				else {
					cout << "You don't want to install Windows [WARNING: 0x11]" << endl;
					return 0;
				}
			}
			else {

				cout << "The selected folder isn't writable [CODE: 0x4]!" << endl;
				f.clear();
				exit(4);

			}

			return 0;



		}



	};
	namespace extractISO {
		void extractISO(string path) {
			string extract = "%COMSPEC% /c " + get_current_path::get_current_path() + "\\7z.exe  x " + path + "-y -oTemp";
			system(extract.c_str());
			string pathwim = get_current_path::get_current_path() + "\\Temp\\sources\\install.wim"; ///for wim;
			string pathesd = get_current_path::get_current_path() + "\\Temp\\sources\\install.esd"; ///for esd;
			string pathswm = get_current_path::get_current_path() + "\\Temp\\sources\\install.swm"; ///for swm;
			ifstream f(pathwim.c_str());
			if (f.bad()) {
				ifstream g(pathesd.c_str());
				if (g.bad()) {
					ifstream h(pathswm.c_str());
					if (h.bad()) {
						cout << "Not an eligble folder [WARNING: 0x10]" << endl;
						return;
					}
					else {
						if (DISM::applying(2, DISM::getimginfo(pathswm), pathswm) == 1) ///2 - for SWM
						{
							Bcdboot::Bcdboot();
							Bcdedit::Bcdedit();

						}
						else {
							cout << "Error extracting files [CODE: 0x3]!" << endl;
							exit(3);
						}
					}
					h.clear();
				}
				else {
					if (DISM::applying(1, DISM::getimginfo(pathesd), pathesd) == 1) ///2 - for SWM
					{
						Bcdboot::Bcdboot();
						Bcdedit::Bcdedit();

					}
					else {
						cout << "Error extracting files [CODE: 0x3]!" << endl;
						exit(3);
					}
					g.clear();
				}
			}
			else {
				if (DISM::applying(0, DISM::getimginfo(pathwim), pathwim) == 1) ///2 - for SWM
				{
					Bcdboot::Bcdboot();
					Bcdedit::Bcdedit();

				}
				else {
					cout << "Error extracting files [CODE: 0x3]!" << endl;
					exit(3);
				}
				f.clear();
				
			


			}

		}



	};
	namespace Windows {
		namespace WIM {
			void WIM() {
				string s = select_a_file::select_a_file(".wim", "Select a WIM file");
				if (s == "NULL")
					return;
				
				if (DISM::applying(0, DISM::getimginfo(s), s) == 1) ///0 - for wim
				{
					Bcdboot::Bcdboot();
					Bcdedit::Bcdedit();
				
				}
				else {
					cout << "Error extracting files [CODE: 0x3]!" << endl;
					exit(3);
				}
				

			}
		};
		namespace ESD {
			void ESD() {
				string s = select_a_file::select_a_file("esd", "Select an ESD file");
				if (s == "NULL")
					return;
				if (DISM::applying(1, DISM::getimginfo(s), s) == 1) ///0 - for esd
				{
					Bcdboot::Bcdboot();
					Bcdedit::Bcdedit();

				}
				else {
					cout << "Error extracting files [CODE: 0x3]!" << endl;
					exit(3);
				}

			}


		};
		namespace SWM {
			void SWM() {
				string s = select_a_file::select_a_file("swm", "Select the first SWM file");
				if (s == "NULL") return;
				if (DISM::applying(2, DISM::getimginfo(s), s) == 1) ///2 - for SWM
				{

					Bcdboot::Bcdboot();
					Bcdedit::Bcdedit();

				}
				else {
					cout << "Error extracting files [CODE: 0x3]!" << endl;
					exit(3);
				}
			}
		};
		namespace ISO {
			void ISO() {
				string s = select_a_file::select_a_file("iso", "Select an ISO file");
				if (s == "NULL")
					return;
				extractISO::extractISO(s);
			}
		};
		namespace Folder {
			void Folder() {
				TCHAR path[MAX_PATH];
				std::string saved_path;
				const char * path_param = saved_path.c_str();

				BROWSEINFO bi = { 0 };
				bi.lpszTitle = ("Browse for folder with Windows Files");
				bi.ulFlags = BIF_RETURNONLYFSDIRS | BIF_NEWDIALOGSTYLE;
				bi.lpfn = select_a_file::BrowseCallbackProc;
				bi.lParam = (LPARAM)path_param;

				LPITEMIDLIST pidl = SHBrowseForFolder(&bi);

				if (pidl != 0)
				{
					//get the name of the folder and put it in path
					SHGetPathFromIDList(pidl, path);

					//free memory used
					IMalloc * imalloc = 0;
					if (SUCCEEDED(SHGetMalloc(&imalloc)))
					{
						imalloc->Free(pidl);
						imalloc->Release();
					}

					string pathwim = static_cast<string>(path) + "\\sources\\install.wim"; ///for wim;
					string pathesd = static_cast<string>(path) + "\\sources\\install.esd"; ///for esd;
					string pathswm = static_cast<string>(path) + "\\sources\\install.swm"; ///for swm;
					ifstream f(pathwim.c_str());
					if (f.bad()) {
						ifstream g(pathesd.c_str());
							  if (g.bad()) {
								  ifstream h(pathswm.c_str());
									 if (h.bad()) {
										 cout << "Not an eligble folder [WARNING: 0x10]" << endl;
										 return;
									 }
									 else {
										 if (DISM::applying(2, DISM::getimginfo(pathswm), pathswm) == 1) ///2 - for SWM
										 {
											 Bcdboot::Bcdboot();
											 Bcdedit::Bcdedit();

										 }
										 else {
											 cout << "Error extracting files [CODE: 0x3]!" << endl;
											 exit(3);
										 }
									 }
							  }
							  else{
								  if (DISM::applying(1, DISM::getimginfo(pathesd), pathesd) == 1) ///2 - for SWM
								  {
									  Bcdboot::Bcdboot();
									  Bcdedit::Bcdedit();

								  }
								  else {
									  cout << "Error extracting files [CODE: 0x3]!" << endl;
									  exit(3);
								  }
							  }
					}
					else {
						if (DISM::applying(0, DISM::getimginfo(pathwim), pathwim) == 1) ///2 - for SWM
						{
							Bcdboot::Bcdboot();
							Bcdedit::Bcdedit();

						}
						else {
							cout << "Error extracting files [CODE: 0x3]!" << endl;
							exit(3);
						}


					}
					
				}

				return; ///it returns nothing, because it was canceled

			}

		};
		void Windows_INITIALIZE() {
			system("cls");
		}

	};



	namespace Windows_Phone {
		namespace FFU {};
		namespace Folder {};

	};

	void Windows_load() {
		cout << "Select the Installation type:" << endl;
		using namespace Message;
		Everytype_message(1);
		Everytype_message(2);
		Everytype_message(3);
		Everytype_message(4);
		Everytype_message(5);
		int e = Graphics::getline_type<int>(cin);
		Install_Windows::Windows::Windows_INITIALIZE();
		switch (e) {
		case 1: {Install_Windows::Windows::WIM::WIM(); break; }
		case 2: {Install_Windows::Windows::ESD::ESD(); break; }
		case 3: {Install_Windows::Windows::SWM::SWM(); break; }
		case 4: {Install_Windows::Windows::ISO::ISO(); break; }
		case 5: {Install_Windows::Windows::Folder::Folder(); break; }
		default: {break; }
		}
	}














};


namespace Install_Linux {

	namespace Linux {





	};


	namespace Android {








	};









};

namespace SelectOS {
	void SelectOS() {
		system("cls");
		cout << "What Operating System do you want to select?" << endl;
		cout << "1. Microsoft Operating Systems" << endl;
		cout << "2. Open Source Operating Systems" << endl;
		cout << "3. Apple Operating Systems*" << endl;
		cout << "4. Back" << endl;
		int e;
		cout << "@IntegrateOSMiniUser> ";
		e = Graphics::getline_type<int>(cin);
		switch (e) {
		case 1: { system("cls"); Install_Windows::Windows_load();  break; }
		case 2: { system("cls"); break; }
		case 3: { system("cls"); break; }
		case 4: { system("cls"); break; }
		default: break;
		}

	}




};


namespace Tools {


	void Tools() { cout << "Under construction" << endl; }












};

namespace Settings {


	void Settings() {
		do {
			system("cls");
			int ok = 0;
			int e;
			cout << "IntegrateOS Settings:" << endl;
			cout << "1. Graphics" << endl;
			cout << "2. Advanced settings" << endl;
			cout << "3. Back" << endl;
			cout << "@IntegrateOSMiniUser> ";
			e = Graphics::getline_type<int>(cin);
			switch (e) {
			case 1:
			{
				Graphics::settings();
				break;
			}
			case 2:
			{
				break;

			}
			case 3:
			{
				ok = 1;
				break;
			}

			default:
			{
				break;

			}

			}
			if (ok == 1) {
				system("cls");
				break;
			}
		} while (true);
	}












};

///FUNCTIONS

namespace Menu {
	void Menu() {
		do {

			cout << "IntegrateOS Menu:" << endl;
			Message::Everytype_message(7);
			Message::Everytype_message(6);
			Message::Everytype_message(8);
			cout << "4. Exit" << endl;
			cout << "@IntegrateOSMiniUser> ";
			int e;
			do {
				e = Graphics::getline_type<int>(cin);
				if (e == 1 || e == 2 || e == 3 || e == 4) {
					break;
				}
				else {
					cout << "Error! You selected a different number than the menu has." << endl;
					cout << "@IntegrateOSMiniUser> ";
				}
			} while (true);
			switch (e) {
			case 1: {
				SelectOS::SelectOS();
				break;
			}
			case 2: {
				system("cls");
				Tools::Tools();

				break;
			}
			case 3: {
				system("cls");
				Settings::Settings();
				break;
			}
			case 4: {
				system("cls");
				exit(1);
				break;
			}
			default: {
				system("cls");
				break;
			}





			}

		} while (true);
	}





};


///THE KERNEL OF THE PROGRAM

int main()
{

	Graphics::set_window_console();
	system("sleep 300");
	system("cls");
	Message::After_loading_message();
	system("cls");
	if (Message::Message_t() == 0)
		return 0;
	Menu::Menu();
	return 0;
}

