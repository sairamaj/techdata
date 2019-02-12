## Async for standard System.Diaganostic.Process Start method
```csharp
    			var tcs = new TaskCompletionSource<QueryResult>();

			var startInfo = new ProcessStartInfo(LogAnalyzerToolPath, $"\"{queryString}\"");
			startInfo.RedirectStandardOutput = true;
			startInfo.UseShellExecute = false;
			SaveQuery(LogAnalyzerToolPath, queryString, runInfo);
			var process = new Process()
			{
				StartInfo = startInfo,
				EnableRaisingEvents = true
			};
			process.Start();

			process.Exited += (s, e) =>
			{
				var output = process.StandardOutput.ReadToEnd();
				tcs.SetResult(output);
			};

			return tcs.Task;
``` 

[source](https://stackoverflow.com/questions/10788982/is-there-any-async-equivalent-of-process-start)