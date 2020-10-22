#ifndef __MAIN_H__
#define __MAIN_H__

#include <windows.h>
#include <bits/stdc++.h>

using namespace std;

/*  To use this exported function of dll, include this header
 *  in your project.
 */

#ifdef BUILD_DLL
#define DLL_EXPORT __declspec(dllexport)
#else
#define DLL_EXPORT __declspec(dllimport)
#endif

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
            if(type == 0)
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

void error_log(int i){
   switch(i){
      case 0:
          {g<<"FAIL BOOTSECT"; break;}

      case 1: {g<<"FAIL BCDBOOT"; break;}
      case 2: {g<<"FAIL BCDEDIT"; break;}
      default: break;

   }


}

int bcdboot(char *format)
{
    string sformat (format);
    string s = "bcdboot " + sformat + "\\Windows /s " + sformat + "\\ /f all";
    string output = exec(s.c_str());
    output.erase(remove(output.begin(), output.end(), '\n'), output.end());
    g<<"OK BCDBOOT"<<endl;
    return output == "Boot files successfully created.";

}



int bootsect(char *format)
{
    string sformat (format);
    string s = "bootsect /NT60 " + sformat + " /force";
    string output = exec(s.c_str());
    output.erase(remove(output.begin(), output.end(), '\n'), output.end());
    g<<"OK BOOTSECT"<<endl;
    return output == "Bootcode was successfully updated on all targeted volumes.";

}




int bcdedit(char *format, char* nickname, int uefi1 = -1)
{
    string sformat(format);
    string snickname(nickname);
    string s = "bcdedit /copy {current} /d \"" + snickname + "\"";
    string output = exec(s.c_str());
    if(output == "The parameter is incorrect.")
    {
        return 0;
    }
    string code = output.substr(output.find("{"), output.find("}"));
    code.erase(remove(code.begin(), code.end(), '.'), code.end());
    code.erase(remove(code.begin(), code.end(), '\n'), code.end());
    string bcddevice = "bcdedit.exe /set " +  code + " device partition=" + sformat;
    string bcdosdevice = "bcdedit.exe /set " + code + " osdevice partition=" + sformat;
    output = exec(bcddevice.c_str());
    output.erase(remove(output.begin(), output.end(), '\n'), output.end());
    if(output == "The parameter is incorrect.")
    {
        return 0;
    }
    output = exec(bcdosdevice.c_str());
    output.erase(remove(output.begin(), output.end(), '\n'), output.end());
    if(output == "The parameter is incorrect.")
    {
        return 0;
    }
    string path;
    if(uefi1 == -1)
    {
        if(uefi() == 1)
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
        if(uefi1 == 1)
        {
            path = "Packages\\bcdedit.exe /set " + code + " path \\Windows\\system32\\winload.efi";
        }
        if(uefi1 == 0)
        {
            path = "Packages\\bcdedit.exe /set " + code + " path \\Windows\\system32\\winload.exe";
        }
    }

    output = exec(path.c_str());
    output.erase(remove(output.begin(), output.end(), '\n'), output.end());
    if(output == "The system cannot find the path specified.")
    {
        return 0;
    }
    string systemroot = "Packages\\bcdedit.exe /set " + code + " systemroot \\Windows";
    output = exec(systemroot.c_str());
    output.erase(remove(output.begin(), output.end(), '\n'), output.end());
    if(output == "The system cannot find the path specified.")
    {
        return 0;
    }
    g<<"OK BCDEDIT"<<endl;
    return 1;

}

extern "C"             //No name mangling
__declspec(dllexport)  //Tells the compiler to export the function
int                  //Function return type
__cdecl

complete(char *part, char *nick, int i)
{
    g<<part<<"  "<<nick;
    if(bootsect(part) == 0){
         error_log(0);
         return 0;
         }
    if(bcdboot(part) == 0){
         error_log(1);
         return 0;
    }
    if(bcdedit(part, nick, i)==0){
        error_log(2);
        return 0;
    }
   return 1;
}

#ifdef __cplusplus
extern "C"
{
#endif

void DLL_EXPORT SomeFunction(const LPCSTR sometext);

#ifdef __cplusplus
}
#endif

#endif // __MAIN_H__
