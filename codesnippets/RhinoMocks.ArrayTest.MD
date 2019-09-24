### Using Rhinomock constraint and FluidAssertion array comparision
```csharp
    class MethodWithDifferentArrayTest
    {
        public class PersonInternal
        {
            public string Name { get; set; }
        }

        public class PersonPublic
        {
            public string Name { get; set; }
            public string Age { get; set; }
        }

        public interface IStore
        {
            void Add(string id, IEnumerable<PersonInternal> persons);
        }

        public class PersonManager
        {
            public PersonManager(IStore store)
            {
                Store = store ?? throw new ArgumentNullException(nameof(store));
            }

            public IStore Store { get; }

            public void Add(string id,IEnumerable<PersonPublic> persons)
            {
                this.Store.Add(id, persons.Select(p=> new PersonInternal()
                {
                    Name = p.Name,
                }));
            }
        }

        [TestFixture]
        public class PersonManagerTest
        {
            [Test]
            public void AddSuccessful()
            {
                var mockStore = MockRepository.GenerateMock<IStore>();

                var pm = new PersonManager(mockStore);
                pm.Add("111", new PersonPublic[]
                {
                    new PersonPublic{ Name = "person1"},
                    new PersonPublic{ Name = "person2"}
                });

                mockStore.AssertWasCalled(store => store.Add( Arg<string>.Is.Equal("111"), 
                    Arg<IEnumerable<PersonInternal>>.Matches(passed => Compare(passed, new List <PersonInternal>
                {
                    new PersonInternal()
                    {
                        Name = "person1"
                    },
                    new PersonInternal()
                    {
                        Name = "person2"
                    }
                }))));
            }

            private bool Compare(IEnumerable<PersonInternal> expected, IEnumerable<PersonInternal> actual)
            {
                // fluidassertions
                actual.Should().BeEquivalentTo(expected);
                return true;
            }
        }
    }
```