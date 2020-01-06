# NUnit Task Exception Validatio
```csharp
    class Test
    {
        public Task TestMethod(){
            // method which throws exception here.
        }
    }

    [Test]
    public asycn Task TestTestMethodForException()
    {
        Func<Task> method = async () =>{
            await new Test().TestMethod();
        }

        // Use Fluent assertion.
        await method.Should().ThrowAsync<Exception>();
    }
```