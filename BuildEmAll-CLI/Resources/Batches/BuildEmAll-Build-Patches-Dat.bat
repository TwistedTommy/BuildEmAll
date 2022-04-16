@echo off

rem */ Main /*
"..\BuildEmAll-CLI.exe" -buildpatchesdat "PD:..\Patches" "XF:..\Xdelta\xdelta3-3.1.0-x86_64.exe" "XC:-e -9 -s" "MN:YourMachineName" "DD:..\Dats" "CO:YourComment"

rem */ Pause /*
@pause
