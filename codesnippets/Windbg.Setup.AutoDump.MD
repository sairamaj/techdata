Here are the instructions (extracted from : http://msdn.microsoft.com/en-us/library/windows/desktop/bb787181(v=vs.85).aspx )
-	Type regedit at command prompt (“Administrator command prompt)
-	Create Key: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\Windows Error Reporting\LocalDumps
-	(Generaly the key upto HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\Windows Error Reporting exists already. In this case one has to create “LocalDumps” in this key.)
-	In this LocalDumps key create key called w3wp.exe
-	Under HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\Windows Error Reporting\LocalDumps\w3wp.exe key
o	Create DumpFolder  (String value) and set it to folder say (D:\CrashDumps)
o	Create the folder d:\CrashDumps
o	Make sure that enough disk space exists (typically dump can take 1.5 to 2GB and default dump limit is 10 )
o	Make sure D:\CrashDumps has been given access to the voyager user (apppool user)
o	Create DumpType (DWORD value) and set it to 2
