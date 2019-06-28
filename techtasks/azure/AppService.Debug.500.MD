### Debugging app service 500 error

[MSDN troubleshoot](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/azure-apps/troubleshoot?view=aspnetcore-2.2#aspnet-core-module-stdout-log)

[Configure FTP for diagnostic logs](https://danielhillebrand.com/2017/08/configure-ftp-account-to-download-azure-diagnostics-logs/)

### Enable stdout
* Through portal go to App service Resource explorer
* Open web.config
* Set stdoutLogEnabled=true (__note__ disable once your are done.)

### Tip:
* Use "User credentials in Deployment Credentials" for FTP and kudu

### Ftp diaganostic logs
* use ftp <ftp address copied from dashboard>
* for user name: give deployment credentials-> user credentials-> user name
* for password : give deployment credentiasl-> user credentials-> password
* cd logfiles
* get eventlog.xml
* quit ftp
* the eventlog.xml file is in our working directory
* open eventlog.xml file in your favorite editor

### connecting Kudu
* curl -k -v -u <deployment->user credential->username> https://<sitename>.scm.azurewebsites.net/api/logstream
* ![source](http://www.seirer.net/blog/2013/12/5/windows-azure-logstreaming-service-introducing-kudu)

### Error