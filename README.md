# IntegrateOS
A method to install every OS on every computer
The idea: I want to install any OS in every computer (including Raspberry PI) 
 
The problem: Windows 7 / 8 / 8.1 doesn’t work on ARM processors, MacOS doesn’t support all x64 / x86 processors, and Android doesn’t run on some computers with UEFI (without a tool). 
 
Solution (1 / 3) (until now): 
 
First of all we need to discover how to install Windows, Linux and Android. 
To install Windows without Windows Setup, we need to use AIK tools (imagex and dism), so this program uses dism tool by extracting wim file and installing Windows. (This technique is simple: installing Windows means extracting files from install.wim (or esd) in a selected drive).  
 
Details:  It was made using Visual C# language. 
Right now the program can install Windows, but in the next releases, I will happly implement the other Operating Systems.

<b> System Requirements: </b>\
 	Windows 10 / 8.1 / 8 / 7 (not tested) with powershell 5+ and Microsoft Net 4.5\
 	At least 1 GB RAM (32 BITS) and 2 GB RAM (64 BITS)\
 	At least 100 MB space for both.
        
If you don't have Powershell 5+ you have the link below to download:\
 https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-core-on-windows?view=powershell-7
 
 PS: You need Windows 7+ to work 
 
<b>Update - beta v0.2.3.0 VERSION 1</b>
What is new:\
        1. Visual bugs fixed.\
	2. Added and enabled the linux option button\
	3. You can download 9 different linux distros depending the architecture. (32 BITS and 64 BITS until now)\
	4. Implemented a download section to download linux\
	5. Now you are able to format in EXT4.\
	6. Implemented the discutils license (you can find in github)\
	7. Updated and fixed font bugs in the license section
	
Bugs:\
       1. It doesn't work well the format drive thanks to Windows, I will fix in the next release.\
       2. The program doesn't install the linux, because I didn't implemented yet.

<b>Update - beta v0.2.1.5 VERSION 2</b>

What is new:\
        1. All bugs except visual fixed.

<b>Update - beta v0.2.1.5</b>

What is new:\
         1. Imported a new form to select the format type.\
	 2. Imported a new form to name the boot entry\
	 3. Fixed bug, now It does create a correctly boot entry.\
	 4. Fixed almost all visual bugs.\
	 5. Fixed the problem with esd.

Bugs:\
         1. During the Windows installation you'll encounter several visual bugs.


<b>Update - beta v0.2.0.1</b>



What is new:\
	1. Updating the License section form\
    	2. Introduced a new form "Selection-OS" to make a choice between Windows, Linux or Android (ps: doesn’t work the Linux and Android buttons)\
	3. Updated a new algorithm to format the selected disk drive (in the next update, you can choice the format type)\
	4. Introduced WIM API to extract WIM without using DISM (now it is unusuable, until the next update)\
	5. Now the application and the source code is more structured, and fixed\
	6. Now you can select every path of wim to install Windows\
	7. New visuals added.

Fixed bugs:\
   	1. Fixed the 0.1.8.1 bug (with freeze)\
    	2. Fixed the format bug by implementing a new algorithm\
    	3. Fixed minor bugs and visual.

Detected bugs:\
       1. It doesn't create a corectly boot entry, this will be fixed in the next release.\
       2. Minor visual bugs, this will be fixed in the next release.\
       3. If you choose the esd option, the program freezes, this will be fixed in the next release.


<b>Update - alpha v0.1.8.1</b>
 
What is new: 
  1) The IntegrateOS license has been updated. 
  2) Right now, the app doesn't go to full screen.
  3) New optimization algorithms has been implemented to this app. 
  4) Introduced another 2 options to install Windows:
     1) Install by selecting a Windows Folder
     2) Install by selecting a ISO

Bugs:
 
 During the Windows Installation the app freezes, but it installs.
  To complete the installation you have to use the following commands:
  1) bcdboot {driveletter}:\Windows /s {driveletter} /f all (%works even in UEFI)
     If doesn't work write the command: "bootsect /NT60 {driveletter}:" and press enter, if is successfully retry the command above.
  2) bcedit /copy {current} /d "The entry name"; (You ll retrieve a code in parantases {})
     Copy that code and copy to a text document where you want to save it.
     Ok let's define entry_code as a pseudoname for that code in parantases so you ll have the following commands:
       1) bcedit /set {entry_code} device partition = {driveletter}
       2) bcedit /set {entry_code} path \Windows\system32\winload.exe
       3) bcedit /set {entry_code} systemroot \Windows
 
 If the commands successfully worked, you done!
 
 
