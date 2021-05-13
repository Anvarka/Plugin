using System.Collections.Generic;
using NUnit.Framework;
using Parser;
using Parser.ParserTest;


namespace Parser
{
    public class NumbersTest
    {
        [Test]
        public void IntegerNumberTest()
        {
            var input = "12345";
            TesterFunction.tester(input,TokenType.Number);
        }
        
        [Test]
        public void NotCorrectIntegerTest()
        {
            var input = "4 abc2";
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(TokenType.Number, "4"),
                new Token(TokenType.Identifier, "abc2")
            };
            Assert.AreEqual(expectedToken.Count, lexeme.Count);
            for (var i = 0; i < lexeme.Count; i++)
            {
                Assert.AreEqual(expectedToken[i].getType(), lexeme[i].getType());
                Assert.AreEqual(expectedToken[i].getVal(), lexeme[i].getVal());
            }
        }
        
        [Test]
        public void Decimal1NumberTest()
        {
            var input = "12345.";
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(TokenType.Number, "12345.")
            };
            Assert.AreEqual(expectedToken.Count, lexeme.Count);
            for (var i = 0; i < lexeme.Count; i++)
            {
                Assert.AreEqual(expectedToken[i].getType(), lexeme[i].getType());
                Assert.AreEqual(expectedToken[i].getVal(), lexeme[i].getVal());
            }
        }
        
        [Test]
        public void Decimal2NumberTest()
        {
            var input = "12345.54321";
            TesterFunction.tester(input, TokenType.Number);
        }
        
        [Test]
        public void SimpleRealNumberWithScaleFactorTest()
        {
            var input = "111.42E10";
            TesterFunction.tester(input, TokenType.Number);
        
            input = "111.42E+10";
            TesterFunction.tester(input, TokenType.Number);
        
            input = "111.42E-10";
            TesterFunction.tester(input, TokenType.Number);
        
            input = "111.E+10";
            TesterFunction.tester(input, TokenType.Number);
        }
        
        [Test]
        public void BinaryNumberTest()
        {
            var input = "%01011010";
            TesterFunction.tester(input, TokenType.BinaryNumber);
        }
        
        [Test]
        public void NotCorrectBinaryNumberTest()
        {
            var input = "%0110 20110";
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(TokenType.BinaryNumber, "%0110"),
                new Token(TokenType.Number, "20110")
            };
            Assert.AreEqual(expectedToken.Count, lexeme.Count);
            for (var i = 0; i < lexeme.Count; i++)
            {
                Assert.AreEqual(expectedToken[i].getType(), lexeme[i].getType());
                Assert.AreEqual(expectedToken[i].getVal(), lexeme[i].getVal());
            }
        }
        
        [Test]
        public void OctalNumberTest()
        {
            var input = "&01234567";
            TesterFunction.tester(input, TokenType.OctalNumber);
        }
        
        [Test]
        public void NotCorrectOctalNumberTest()
        {
            var input = "&64323327 889823";
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(TokenType.OctalNumber, "&64323327"),
                new Token(TokenType.Number, "889823")
            };
            Assert.AreEqual(expectedToken.Count, lexeme.Count);
            for (var i = 0; i < lexeme.Count; i++)
            {
                Assert.AreEqual(expectedToken[i].getType(), lexeme[i].getType());
                Assert.AreEqual(expectedToken[i].getVal(), lexeme[i].getVal());
            }
        }
        
        [Test]
        public void HexNumberTest()
        {
            var input = "$1234567890abcdefABCDEF";
            TesterFunction.tester(input, TokenType.HexadecimalNumber);
        }
        
        [Test]
        public void NotCorrectHexNumberTest()
        {
            var input = "$0123456789abcdef ghrABCDEF";
            PascalLexer lexer = new PascalLexer();
            var lexeme = lexer.getToken(input);
            var expectedToken = new List<Token>
            {
                new Token(TokenType.HexadecimalNumber, "$0123456789abcdef"),
                new Token(TokenType.Identifier, "ghrABCDEF")
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