using System;
using Superpower;

namespace SuppaParser
{
    public class CParser
    {
        private readonly Tokenizer<CToken> tokenizer;

        public CParser(Tokenizer<CToken> tokenizer)
        {
            this.tokenizer = tokenizer;
        }

        public CSyntax Parse(string input)
        {
            var tokenList = tokenizer.Tokenize(input);
            return ParserCombinators.Program.Parse(tokenList);            
        }
    }
}
