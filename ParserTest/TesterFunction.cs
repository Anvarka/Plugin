using System.Collections.Generic;
using NUnit.Framework;

namespace Parser.ParserTest
{
    public class TesterFunction
    {
        [Test]
        public static void tester(string input, TokenType type)
        {
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(type, input)
            };
            Assert.AreEqual(expectedToken.Count, lexeme.Count);
            for (var i = 0; i < lexeme.Count; i++)
            {
                Assert.AreEqual(expectedToken[i].getType(), lexeme[i].getType());
                Assert.AreEqual(expectedToken[i].getVal(), lexeme[i].getVal());
            }
        }
    }
}