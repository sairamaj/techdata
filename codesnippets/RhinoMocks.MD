### Constraints
```csharp
userRepository.Stub(r => r.Save(ref Arg<User>.Ref(constraint: Rhino.Mocks.Constraints.Is.Anything(), returnValue: new User())))
```
[source](https://www.barbarianmeetscoding.com/wiki/rhino-mocks/)
