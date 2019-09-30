using System.Collections.Generic;

namespace SimpleParser.Model
{
    public class MethodData
    {
        public MethodData(string name, IDictionary<string, string> parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }

        public string Name { get; private set; }
        public IDictionary<string, string> Parameters { get; private set; }
    }
}
