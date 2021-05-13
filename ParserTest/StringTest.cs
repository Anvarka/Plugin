using System.Collections.Generic;
using NUnit.Framework;

namespace Parser.ParserTest
{
    public class StringTest
    {
        [Test]
        public void SimpleTest()
        {
            var input = "'simple comment'";
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new Token(TokenType.String, input);
            for (var i = 0; i < lexeme.Count; i++)
            {
                Assert.AreEqual(lexeme[i].getType(), expectedToken.getType());
                Assert.AreEqual(lexeme[i].getVal(), expectedToken.getVal());
            }
        }

        [Test]
        public void ComboTest()
        {
            var input = "'abc '\n" +
                        "'123'\n" +
                        "'This is begin: '#34'  and it is end'\n";
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(TokenType.String, "'abc '"),
                new Token(TokenType.String, "'123'"),
                new Token(TokenType.String, "'This is begin: '#34'  and it is end'"),
            };
            Assert.AreEqual(expectedToken.Count, lexeme.Count);
            for (var i = 0; i < lexeme.Count; i++) {
                Assert.AreEqual(expectedToken[i].getType() , lexeme[i].getType());
                Assert.AreEqual(expectedToken[i].getVal(), lexeme[i].getVal());
            }
            
        }
    }
}