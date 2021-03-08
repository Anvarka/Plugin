using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{

    public interface IExpressionVisitor
    {
        void Visit(Literal expression);
        void Visit(Variable expression);
        void Visit(BinaryExpression expression);
        void Visit(ParenExpression expression);
    }

    public interface IExpression
    {
        void Accept(IExpressionVisitor visitor);
    }

    public class Literal : IExpression
    {
        public Literal(string value)
        {
            Value = value;
        }

        public readonly string Value;

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Variable : IExpression
    {
        public Variable(string name)
        {
            Name = name;
        }

        public readonly string Name;

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class BinaryExpression : IExpression
    {
        public readonly IExpression FirstOperand;
        public readonly IExpression SecondOperand;
        public readonly string Operator;

        public BinaryExpression(IExpression firstOperand, IExpression secondOperand, string @operator)
        {
            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operator = @operator;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ParenExpression : IExpression
    {
        public ParenExpression(IExpression operand)
        {
            Operand = operand;
        }

        public readonly IExpression Operand;

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class DumpVisitor : IExpressionVisitor
    {
        private readonly StringBuilder myBuilder;

        public DumpVisitor()
        {
            myBuilder = new StringBuilder();
        }

        public void Visit(Literal expression)
        {
            myBuilder.Append("Literal(" + expression.Value + ")");
        }

        public void Visit(Variable expression)
        {
            myBuilder.Append("Variable(" + expression.Name + ")");
        }

        public void Visit(BinaryExpression expression)
        {
            myBuilder.Append("Binary(");
            expression.FirstOperand.Accept(this);
            myBuilder.Append(expression.Operator);
            expression.SecondOperand.Accept(this);
            myBuilder.Append(")");
        }

        public void Visit(ParenExpression expression)
        {
            myBuilder.Append("Paren(");
            expression.Operand.Accept(this);
            myBuilder.Append(")");
        }

        public override string ToString()
        {
            return myBuilder.ToString();
        }
    }


    public class SimpleParser
    {
        public static IExpression Parse(string text)
        {
            var dumpVisitor = new DumpVisitor();
            Stack<IExpression> variableAndLetter = new Stack<IExpression>();
            Stack<char> operators = new Stack<char>();

            for (var i = 0; i < text.Length; i++)
            {
                var ch = text[i];
                if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                {
                    if (operators.Count == 0)
                    {
                        operators.Push(ch);
                    }
                    else if (isCurrentOpLessPriority(ch, operators.Peek()))
                    {
                        var highPriorOper = operators.Pop();
                        operators.Push(ch);
                        var secondEl = variableAndLetter.Pop();
                        var firstEl = variableAndLetter.Pop();
                        variableAndLetter.Push(new BinaryExpression(firstEl, secondEl, highPriorOper.ToString()));
                    }
                    else
                    {
                        operators.Push(ch);
                    }
                }

                else if (ch == '(')
                {
                    operators.Push(ch);
                }
                else if (ch == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        if (operators.Count == 0)
                        {
                            throw new FormatException("Incorrect expression");
                        }
                        char op = operators.Pop();
                        var  secondEl = variableAndLetter.Pop();
                        var firstEl = variableAndLetter.Pop();
                        variableAndLetter.Push( new BinaryExpression(firstEl, secondEl, op.ToString()));
                    }

                    operators.Pop();
                }
                else if (char.IsDigit(ch))
                {
                    variableAndLetter.Push(new Literal(ch.ToString()));
                }
                else if (char.IsLetter(ch))
                {
                    variableAndLetter.Push(new Variable(ch.ToString()));
                }
                else
                {
                    throw new FormatException("Incorrect element in expression");
                }
            }

            while (variableAndLetter.Count > 1)
            {
                char oper = operators.Pop();
                var second = variableAndLetter.Pop();
                var first = variableAndLetter.Pop();
                variableAndLetter.Push(new BinaryExpression(first, second, oper.ToString()));
            }

            return variableAndLetter.Pop();
        }
        
        public static bool isCurrentOpLessPriority(char curOp, char prevOp){
            if ((curOp == '+' || curOp == '-') && prevOp != '('){
                return true;
            }
            else
            {
                return (prevOp == '*' || prevOp == '\\');
            }
        }
    }
    
}