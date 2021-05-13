using NUnit.Framework;

namespace Parser.ParserTest
{
    public class SymbolTest
    {
    [Test]
    public void AssignTest()
    {
        var input = ":=";
        TesterFunction.tester(input, TokenType.AssignSymbol);
    }
    
    [Test]
    public void AddSymbolTest()
    {
        var input = "+";
        TesterFunction.tester(input, TokenType.AddSymbol);
    }
    }
}