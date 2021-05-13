using System.Collections.Generic;
using NUnit.Framework;

namespace Parser.ParserTest
{
    public class MultiLineCommentTest
    {
        [Test]
        public void Simple1Test()
        {
            var input = "{this is comment in one line}";
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(TokenType.MultiLineComment, "{this is comment in one line}")
            };
            Assert.AreEqual(expectedToken.Count, lexeme.Count);
            for (var i = 0; i < lexeme.Count; i++)
            {
                Assert.AreEqual(expectedToken[i].getType(), lexeme[i].getType());
                Assert.AreEqual(expectedToken[i].getVal(), lexeme[i].getVal());
            }
        }
        
        [Test]
        public void Simple2Test()
        {
            var input = "{this is comment in one line}";
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(TokenType.MultiLineComment, "{this is comment in one line}")
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
            var input = "{this is comment \n" + "bla-bla \n" + "the end comment\n" +"}";
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(TokenType.MultiLineComment, "{this is comment \nbla-bla \nthe end comment\n}")
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