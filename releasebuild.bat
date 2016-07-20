%windir%\microsoft.net\framework\v3.5\msbuild src\SQLiteManager.sln /p:Configuration=Release
@IF %ERRORLEVEL% NEQ 0 GOTO err
@IF %ERRORLEVEL% NEQ 0 GOTO err
@exit /B 0
:err
@PAUSE
@exit /B 1