using System.Collections.Generic;
using NUnit.Framework;

namespace Parser.ParserTest
{
    public class StressTest
    {
        [Test]
        public void stressTest()
        {
            // здесь нужно указать полный путь до файла
            string[] lines = System.IO.File.ReadAllLines(@"/home/anvar/CSharp/Parser/ParserTest/code.txt");
            PascalLexer lexer = new PascalLexer();
            foreach (string line in lines)
            {
                lexer.getToken(line);
            }
            
            var expectedToken = new List<Token>
            {
                new Token(TokenType.SpecialWord, "program"),
                new Token(TokenType.Identifier, "n_3_1"),
                new Token(TokenType.ProgramSymbol, ";"),
                new Token(TokenType.SpecialWord, "var"),
                new Token(TokenType.Identifier, "s"),
                new Token(TokenType.ProgramSymbol, ","),
                new Token(TokenType.Identifier, "i"),
                new Token(TokenType.ProgramSymbol, ":"),
                new Token(TokenType.Identifier, "integer"),
                new Token(TokenType.ProgramSymbol, ";"),
                new Token(TokenType.SpecialWord, "begin"),
                new Token(TokenType.Identifier, "s"),
                new Token(TokenType.AssignSymbol, ":="),
                new Token(TokenType.Number, "0"),
                new Token(TokenType.ProgramSymbol, ";"),
                new Token(TokenType.MultiLineComment, "{this is comment\n}"),
                new Token(TokenType.SpecialWord, "for"),
                new Token(TokenType.Identifier, "i"),
                new Token(TokenType.AssignSymbol, ":="),
                new Token(TokenType.Number, "1"),
                new Token(TokenType.SpecialWord, "to"),
                new Token(TokenType.Number, "10"),
                new Token(TokenType.SpecialWord, "do"),
                new Token(TokenType.SpecialWord, "begin"),
                new Token(TokenType.Identifier, "s"),
                new Token(TokenType.AssignSymbol, ":="),
                new Token(TokenType.Identifier, "s"),
                new Token(TokenType.AddSymbol, "+"),
                new Token(TokenType.Identifier, "a"),
                new Token(TokenType.ProgramSymbol, "["),
                new Token(TokenType.Identifier, "i"),
                new Token(TokenType.ProgramSymbol, "]"),
                new Token(TokenType.SpecialWord, "end"),
                new Token(TokenType.ProgramSymbol, ";"),
                new Token(TokenType.MultiLineComment, "(*It is second comment\nA lot of line\nklfdf 123 3423\n*)"),
                new Token(TokenType.SpecialWord, "end"),
                new Token(TokenType.ProgramSymbol, "."),
                new Token(TokenType.OneLineComment, "// Third comment about end"),
            };
            for (var i = 0; i < lexer.listOfTokens.Count; i++)
            {
                Assert.AreEqual(expectedToken[i].getType(), lexer.listOfTokens[i].getType());
                Assert.AreEqual(expectedToken[i].getVal(), lexer.listOfTokens[i].getVal());
            }
        }
    }
}