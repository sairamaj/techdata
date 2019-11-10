### Geerate assembly from source files

```csharp
        private Assembly CreateAssembly(IEnumerable<string> sources, IEnumerable<Assembly> assemblyReferences)
        {
            var cp = new CompilerParameters()
            {
                OutputAssembly = "test.dll"
            };
            var provider = new CSharpCodeProvider();
            assemblyReferences = assemblyReferences.ToList();
            assemblyReferences.ToList().ForEach(a => cp.ReferencedAssemblies.Add(new Uri(a.CodeBase).AbsolutePath));
            var referencedAssemblies = GetReferencedAssemblies(assemblyReferences);
            referencedAssemblies.ToList().ForEach(r=> cp.ReferencedAssemblies.Add(r));
            var cr = provider.CompileAssemblyFromFile(cp, sources.ToArray());

            if (cr.Errors.Count > 0)
            {
                var errorMessage = new StringBuilder();
                // Gather compilation errors.
                errorMessage.AppendFormat("Errors building ");
                foreach (var ce in cr.Errors)
                {
                    errorMessage.AppendFormat("{0}\r\n", ce);
                }

                throw new Exception(errorMessage.ToString());
            }

            //return cr.CompiledAssembly;
            return null;
        }

        private static IEnumerable<string> GetReferencedAssemblies(IEnumerable<Assembly> assemblies)
        {
            foreach (var asm in assemblies)
            {
                foreach (var refAsm in asm.GetReferencedAssemblies())
                {
                    Console.WriteLine(refAsm.Name);
                    if (refAsm.Name.StartsWith("System"))
                    {
                        yield return $"{refAsm.Name}.dll";
                    }
                }
            }

            yield return "System.dll";
        }
```