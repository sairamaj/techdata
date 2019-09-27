using System.Collections.Generic;
using System.Linq;
using SimpleParser.Exceptions;

namespace SimpleParser
{
    public class MethodInfo
    {
        public MethodInfo(IEnumerable<DslToken> tokens)
        {
            this.Parameters = new Dictionary<string, string>();
            Parse(tokens);
        }

        public string Name { get; set; }
        public IDictionary<string, string> Parameters { get; set; }

        private void Parse(IEnumerable<DslToken> tokens)
        {
            var stringTokens = tokens.Where(t => t.TokenType == TokenType.StringValue).ToList();
            if (!stringTokens.Any())
            {
                throw new DslParserException($"Method name missing.");
            }

            this.Name = stringTokens.First().Value;

            foreach (var parameterToken in stringTokens.Skip(1))
            {
                var parts = parameterToken.Value.Split('=');
                if (parts.Length > 0)
                {
                    this.Parameters[parts[0]] = parts[1];
                }
            }
        }
    }
}
