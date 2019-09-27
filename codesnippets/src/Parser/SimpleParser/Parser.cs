using SimpleParser.SlowAndSimple;

namespace SimpleParser
{
    public class Parser
    {
        public static MethodInfo Parse(string expression)
        {
            var tokenizer = new SimpleRegexTokenizer();
            var tokens = tokenizer.Tokenize(expression);
            return new MethodInfo(tokens);
        }
    }
}
