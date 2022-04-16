@echo off

rem */ Main /*
"..\BuildEmAll-CLI.exe" -buildroms "RD:..\ROMs" "PD:..\Patches" "XF:..\Xdelta\xdelta3-3.1.0-x86_64.exe" "DL: -- "

rem */ Pause /*
@pause
