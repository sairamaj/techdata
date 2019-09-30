using System;
using SimpleParser.Model;
using SimpleParser.SlowAndSimple;

namespace SimpleParser
{
    public class Parser
    {
        public static MethodData Parse(string expression)
        {
            var tokenizer = new SimpleRegexTokenizer();
            var tokens = tokenizer.Tokenize(expression);
            foreach (var token in tokens)
            {
                Console.WriteLine($"{token.TokenType}:{token.Value}");
            }

            return MethodExtract.Parse(tokens);
        }
    }
}
