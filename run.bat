call npm run-script build
echo %errorlevel%
if %ERRORLEVEL% NEQ 0 goto error
node dist\upload\upload.js
goto done
:error
echo 'Error occurred'
:done
