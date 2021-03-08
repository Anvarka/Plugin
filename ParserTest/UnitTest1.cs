using NUnit.Framework;
using Parser;

namespace ParserTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var dumpVisitor = new DumpVisitor();
            new BinaryExpression(new Literal("1"), new Literal("2"), "+").Accept(dumpVisitor);

            var dumpVisitor1 = new DumpVisitor();
            var d = SimpleParser.Parse("1+2");
            d.Accept(dumpVisitor1);
            Assert.AreEqual("Binary(Literal(1)+Literal(2))", dumpVisitor.ToString());
            var dumpVisitor2 = new DumpVisitor();
            var d2 = SimpleParser.Parse("a+b*c");
            d2.Accept(dumpVisitor2);
            Assert.AreEqual("Binary(Variable(a)+Binary(Variable(b)*Variable(c)))", dumpVisitor2.ToString());

            var dumpVisitor3 = new DumpVisitor();
            var d3 = SimpleParser.Parse("(a+b)*c");
            d3.Accept(dumpVisitor3);
            Assert.AreEqual("Binary(Binary(Variable(a)+Variable(b))*Variable(c))", dumpVisitor3.ToString());

            var dumpVisitor4 = new DumpVisitor();
            var d4 = SimpleParser.Parse("(1+b)/c");
            d4.Accept(dumpVisitor4);
            Assert.AreEqual("Binary(Binary(Literal(1)+Variable(b))/Variable(c))", dumpVisitor4.ToString());


            var dumpVisitor5 = new DumpVisitor();
            var d5 = SimpleParser.Parse("(1+a)*(b+c)+2/3");
            d5.Accept(dumpVisitor5);
            Assert.AreEqual(
                "Binary(Binary(Binary(Literal(1)+Variable(a))*Binary(Variable(b)+Variable(c)))+Binary(Literal(2)/Literal(3)))",
                dumpVisitor5.ToString());

            var dumpVisitor6 = new DumpVisitor();
            var d6 = SimpleParser.Parse("((a+b)+c)*d");
            d6.Accept(dumpVisitor6);
            Assert.AreEqual(
                "Binary(Binary(Binary(Variable(a)+Variable(b))+Variable(c))*Variable(d))",
                dumpVisitor6.ToString());

            var dumpVisitor7 = new DumpVisitor();
            var d7 = SimpleParser.Parse("((a+b)*(c+c))*d");
            d7.Accept(dumpVisitor7);
            Assert.AreEqual(
                "Binary(Binary(Binary(Variable(a)+Variable(b))*Binary(Variable(c)+Variable(c)))*Variable(d))",
                dumpVisitor7.ToString());

            var dumpVisitor8 = new DumpVisitor();
            var d8 = SimpleParser.Parse("((1+4*b/c)*(3/c+d/5))*4");
            d8.Accept(dumpVisitor8);
            Assert.AreEqual(
                "Binary(Binary(Binary(Literal(1)+Binary(Binary(Literal(4)*Variable(b))/Variable(c)))*Binary(Binary(Literal(3)/Variable(c))+Binary(Variable(d)/Literal(5))))*Literal(4))",
                dumpVisitor8.ToString());
        }
    }
}