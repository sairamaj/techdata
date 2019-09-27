using System.Collections.Generic;

namespace SimpleParser
{
    public interface ITokenizer
    {
        IEnumerable<DslToken> Tokenize(string queryDsl);
    }
}
