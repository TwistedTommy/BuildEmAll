@echo off

rem */ Main /*
"..\BuildEmAll-CLI.exe" -buildpatches "RD:..\ROMs" "PD:..\Patches" "XF:..\Xdelta\xdelta3-3.1.0-x86_64.exe" "XC:-e -9 -s" "DL: -- " "DF:..\Dats\YourDatPPDXMLFile.ppd"

rem */ Pause /*
@pause
