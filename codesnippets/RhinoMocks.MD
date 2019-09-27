### Constraints
```csharp
userRepository.Stub(r => r.Save(ref Arg<User>.Ref(constraint: Rhino.Mocks.Constraints.Is.Anything(), returnValue: new User())))
```
[source](https://www.barbarianmeetscoding.com/wiki/rhino-mocks/)

### Mocking different values for different inputs
```csharp
    obj.Stub( o=> o.DoSomething(val1)).Return(outval1).Repeat.Once();
    obj.Stub( o=> o.DoSomething(val2).Return(outval2).Repeat.Once();
```
