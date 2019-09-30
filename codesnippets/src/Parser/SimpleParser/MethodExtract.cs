using System.Collections.Generic;
using System.Linq;
using SimpleParser.Exceptions;
using SimpleParser.Model;

namespace SimpleParser
{
    public class MethodExtract
    {
        public static MethodData Parse(IEnumerable<DslToken> tokens)
        {
            var stringTokens = tokens.Where(t => t.TokenType == TokenType.StringValue).ToList();
            if (!stringTokens.Any())
            {
                throw new DslParserException($"Method name missing.");
            }

            var methodName = stringTokens.First().Value;
            var parameters = new Dictionary<string, string>();
            foreach (var parameterToken in stringTokens.Skip(1))
            {
                var parts = parameterToken.Value.Split('=');
                if (parts.Length > 0)
                {
                    parameters[parts[0]] = parts[1];
                }
            }

            return new MethodData(methodName, parameters);
        }
    }
}
