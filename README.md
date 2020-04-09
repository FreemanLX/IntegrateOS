# IntegrateOS
A method to install every OS on every computer
The idea: I want to install any OS in every computer (including Raspberry PI) 
 
The problem: Windows 7 / 8 / 8.1 doesn’t work on ARM processors, MacOS doesn’t support all x64 / x86 processors, and Android doesn’t run on some computers with UEFI (without a tool). 
 
Solution (1 / 3) (until now): 
 
First of all we need to discover how to install Windows, Linux and Android. 
To install Windows without Windows Setup, we need to use AIK tools (imagex and dism), so this program uses dism tool by extracting wim file and installing Windows. (This technique is simple: installing Windows means extracting files from install.wim (or esd) in a selected drive).  
 
Details:  It was made using Visual C# language. 
Right now the program can install Windows, but in the next releases, I will happly implement the other Operating Systems.
