## Async

* LIbrary
    * Never block thread (don't use Result)
    * Library code should be written without any assumption of synchronization context or framework which calls from
    * If you need to support both sync and async interface, then you must implement the function twice, for both versions. 
    * Don’t even think about calling them from each other for code reuse. 
    * You have 2 options, 
        * either make your function sync, and use sync APIs to implement it, 
        * or make your function async and use async APIs to implement it. 
    * In case you need both you can and should implement both separately.
    * [source](https://medium.com/rubrikkgroup/understanding-async-avoiding-deadlocks-e41f8f2c6f5d)
* Task.Run
   * Schedules on threadpool thread
* Task is not a Thread.

* Best is
  * sync method using sync
  * async method is using async (don't mixup)

* SyncronizationContext 
    * generic way of queuing work for other threads
    * control how your tasks are executed
* TaskScheduler 
    * control how your tasks are executed
    * abstraction over this which handles the scheduling and execution of Tasks

* Async 
    [source](https://medium.com/rubrikkgroup/understanding-async-avoiding-deadlocks-e41f8f2c6f5d)
    ![Async](https://github.com/sairamaj/techdata/codesnippets/blob/master/images/async.png)

    * Only call async code only from async code. (dont mix sync with async)
    * Never block in async code. (never .Result, never lock)
    * If you need a lock, use SemaphoreSlim.WaitAsync()
    * Use async/await when dealing with Tasks, instead of ContinueWith/Unwrap, it makes the code cleaner.
    * It’s okay to provide both sync and async version of API, but never call one from the other. (this is one of the rare cases when code duplication is acceptable)

## Some alernatives when non async code calling async
[source](https://www.productiverage.com/i-didnt-understand-why-people-struggled-with-nets-async)
* Don't mix async and non-async code
* Always use ".ConfigureAwait(false)"
* Disabling the synchronization context before calling async code
* Use a custom INotifyCompletion implementation
* Use Task.Run( ()=>{}).Result (as workaround because Task.Run does not use SynchronizationContext and hence no dead lock problems)
