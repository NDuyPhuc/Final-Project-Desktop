@echo off
setlocal
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0scripts\publish-exe.ps1" %*
exit /b %ERRORLEVEL%
