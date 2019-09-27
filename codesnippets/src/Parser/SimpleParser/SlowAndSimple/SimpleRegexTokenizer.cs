using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SimpleParser.Exceptions;

namespace SimpleParser.SlowAndSimple
{
    public class SimpleRegexTokenizer : ITokenizer
    {
        private List<TokenDefinition> _tokenDefinitions;

        public SimpleRegexTokenizer()
        {
            // ${getRelId(b1user1001,bank1)}
            _tokenDefinitions = new List<TokenDefinition>();

            _tokenDefinitions.Add(new TokenDefinition(TokenType.Dollar, "^\\$"));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.LeftFlowerBracket, "^{"));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.OpenParenthesis, "^\\("));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.CloseParenthesis, "^\\)"));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.RightFlowerBracket, "^}"));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.StringValue, "^\\w+=?\\w+"));
            _tokenDefinitions.Add(new TokenDefinition(TokenType.Comma, "^,"));
        }


        public IEnumerable<DslToken> Tokenize(string lqlText)
        {
            var tokens = new List<DslToken>();

            string remainingText = lqlText;

            while (!string.IsNullOrWhiteSpace(remainingText))
            {
                var match = FindMatch(remainingText);
                if (match.IsMatch)
                {
                    tokens.Add(new DslToken(match.TokenType, match.Value));
                    remainingText = match.RemainingText;
                }
                else
                {
                    if (IsWhitespace(remainingText))
                    {
                        remainingText = remainingText.Substring(1);
                    }
                    else
                    {
                        var invalidTokenMatch = CreateInvalidTokenMatch(remainingText);
                        tokens.Add(new DslToken(invalidTokenMatch.TokenType, invalidTokenMatch.Value));
                        remainingText = invalidTokenMatch.RemainingText;
                    }
                }
            }

            tokens.Add(new DslToken(TokenType.SequenceTerminator, string.Empty));

            return tokens;
        }

        private TokenMatch FindMatch(string lqlText)
        {
            foreach (var tokenDefinition in _tokenDefinitions)
            {
                var match = tokenDefinition.Match(lqlText);
                if (match.IsMatch)
                    return match;
            }

            return new TokenMatch() {  IsMatch = false };
        }

        private bool IsWhitespace(string lqlText)
        {
            return Regex.IsMatch(lqlText, "^\\s+");
        }

        private TokenMatch CreateInvalidTokenMatch(string lqlText)
        {
            var match = Regex.Match(lqlText, "(^\\S+\\s)|^\\S+");
            if (match.Success)
            {
                return new TokenMatch()
                {
                    IsMatch = true,
                    RemainingText = lqlText.Substring(match.Length),
                    TokenType = TokenType.Invalid,
                    Value = match.Value.Trim()
                };
            }

            throw new DslParserException("Failed to generate invalid token");
        }
    }
}
