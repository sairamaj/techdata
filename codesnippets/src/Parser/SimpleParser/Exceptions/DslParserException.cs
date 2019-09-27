using System;

namespace SimpleParser.Exceptions
{
    [Serializable]
    public class DslParserException : Exception
    {
        public DslParserException(string message)
            : base(message)
        {

        }
    }
}
