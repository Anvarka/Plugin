using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace Parser
{
    public enum TokenType
    {
        OneLineComment,
        MultiLineComment,
        Number,
        BinaryNumber,
        OctalNumber,
        HexadecimalNumber,
        AssignSymbol,
        AddSymbol,
        CompareSymbol,
        MulSymbol,
        String,
        SpecialWord,
        Identifier,
        ProgramSymbol,
        EofSymbol
    }

    public class Token
    {
        private TokenType tokenType;
        private string val;
        
        public Token(TokenType type, string value) {
            tokenType = type;
            val = value;
        }

        public TokenType getType()
        {
            return tokenType;
        }
        
        public string getVal()
        {
            return val;
        }
    }
}
