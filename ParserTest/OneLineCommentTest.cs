using System.Collections.Generic;
using NUnit.Framework;
using Parser;

namespace ParserTest
{
    public class Tests
    {
        [Test]
        public void SimpleTest()
        {        
            PascalLexer lexer = new PascalLexer();

            var input = "//this is one comment123 dfsd \n";
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(TokenType.OneLineComment, "//this is one comment123 dfsd")
            };
            Assert.AreEqual(expectedToken.Count, lexeme.Count);
            for (var i = 0; i < lexeme.Count; i++)
            {
                Assert.AreEqual(expectedToken[i].getType(), lexeme[i].getType());
                Assert.AreEqual(expectedToken[i].getVal(), lexeme[i].getVal());
            }
        }
        
        [Test]
        public void ComboTest()
        {
            var input = "//this is comment\n" + "123\n";
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(TokenType.OneLineComment, "//this is comment"),
                new Token(TokenType.Number, "123")
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