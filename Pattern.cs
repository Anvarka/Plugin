using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Parser
{
    public class Pattern
    {
        private Regex regex;
        private TokenType typeOfToken;
        private static List<Pattern> patterns = new()
        {
            new Pattern(@"^\s*[-+]?(\d+[.]?\d*(E|e)?[-+]?\d*|\d+)+\s*", TokenType.Number),
            new Pattern(@"^\s*%(0|1)+\s*", TokenType.BinaryNumber),
            new Pattern(@"^\s*&[0-7]+\s*", TokenType.OctalNumber),
            new Pattern(@"^\s*\$(\d|[a-fA-F])+\s*", TokenType.HexadecimalNumber),
            new Pattern(@"^\s*:=\s*", TokenType.AssignSymbol),
            new Pattern(@"^\s*[+-]\s*", TokenType.AddSymbol),
            new Pattern(@"^\s*[*\\]\s*", TokenType.MulSymbol),
            new Pattern(@"^\s*[<>]\s*", TokenType.CompareSymbol),
            new Pattern(@"\s*'([^']|'#\d+')*'\s*", TokenType.String),
            new Pattern(@"^\s*(function|for|begin|end|if|else|do|case|while|array|const|downto|mod|or|and|to|program|var)\s*",
                TokenType.SpecialWord),
            new Pattern(@"^\s*[_a-zA-Z][_a-zA-Z0-9]*\s*", TokenType.Identifier),
            new Pattern(@"^\s*//.*(\n|$)", TokenType.OneLineComment),
            new Pattern(@"^\s*{(.*\n?)*}", TokenType.MultiLineComment),
            new Pattern(@"^\s*{(.*\n?)*}", TokenType.MultiLineComment),
            new Pattern(@"^\s*(\{|\(\*|;|:|,|\[|\]|\.|\*\))\s*", TokenType.ProgramSymbol),
            new Pattern(@"\s*(\*\)|\})\s*", TokenType.EofSymbol),
        };

        public Pattern(string regexStr, TokenType type)
        {
            regex = new Regex(regexStr);
            typeOfToken = type;
        }

        public TokenType getType()
        {
            return typeOfToken;
        }

        public Regex getRegex()
        {
            return regex;
        }

        public static List<Pattern> getAllPatterns()
        {
            return patterns;
        }
    }
}
