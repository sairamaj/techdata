### Building Linux provider on windows
```cmd
Building custom terraform - linux
set GOARCH=amd64
set GOOS=linux
go tool dist install -v pkg/runtime
go install -v -a std
```