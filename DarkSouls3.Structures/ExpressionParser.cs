using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSouls3.Structures
{
    public class ExpressionParser
    {
        class Token
        {
            public enum Type
            {
                Data,
                OpenBracket,
                CloseBracket,
                OperatorNot,
                OperatorAnd,
                OperatorOr
            }

            public enum Associativity
            {
                LeftToRight,
                RightToLeft,
                Unspecified
            }

            public override string ToString()
            {
                return string.Format("[data=\"{0}\", type={1}]", data, type);
            }

            public string data { get; private set; }
            public Type type { get; private set; }

            public Token(string data, Type type)
            {
                this.data = data;
                this.type = type;
            }

            public Associativity Assoc
            {
                get
                {
                    switch (type)
                    {
                        case Type.OperatorNot:
                            return Associativity.RightToLeft;
                        case Type.OperatorAnd:
                        case Type.OperatorOr:
                            return Associativity.LeftToRight;
                        default:
                            return Associativity.Unspecified;
                    }
                }
            }

            public int Precedence
            {
                get
                {
                    switch (type)
                    {
                        case Type.OperatorNot:
                            return 7;
                        case Type.OperatorAnd:
                            return 3;
                        case Type.OperatorOr:
                            return 1;
                        default:
                            return 0;
                    }
                }
            }

            public bool IsOperator
            {
                get { return type != Type.Data && type != Type.OpenBracket && type != Type.CloseBracket; }
            }
        }

        private readonly List<Token> _tokens = new List<Token>();
        private Token[] _prefixTokens;
        private string _curToken = "";

        public ExpressionParser(string expression)
        {
            tokenize(expression);
            shuntingYard();
        }

        private bool isUnaryOperator()
        {
            if (_curToken.Length != 0)
                return false;
            if (_tokens.Count == 0)
                return true;
            var lastToken = _tokens[_tokens.Count - 1];
            return lastToken.IsOperator;
        }

        private void tokenize(string expression)
        {
            foreach (var ch in expression)
            {
                switch (ch)
                {
                    case '(':
                        addOperatorToken(ch, Token.Type.OpenBracket);
                        break;
                    case ')':
                        addOperatorToken(ch, Token.Type.CloseBracket);
                        break;
                    case '~':
                        addOperatorToken(ch, Token.Type.OperatorNot);
                        break;
                    case '&':
                        addOperatorToken(ch, Token.Type.OperatorAnd);
                        break;
                    case '|':
                        addOperatorToken(ch, Token.Type.OperatorOr);
                        break;
                    default:
                        _curToken += ch;
                        break;
                }
            }
            if (_curToken.Length != 0)
                _tokens.Add(new Token(_curToken, Token.Type.Data));
        }

        private void shuntingYard()
        {
            //Implementation of Dijkstra's Shunting-yard algorithm
            var queue = new Queue<Token>(_tokens.Count);
            var stack = new Stack<Token>(_tokens.Count);
            foreach (var token in _tokens)
            {
                switch (token.type)
                {
                    case Token.Type.Data:
                        queue.Enqueue(token);
                        break;
                    case Token.Type.OpenBracket:
                        stack.Push(token);
                        break;
                    case Token.Type.CloseBracket:
                        while (true)
                        {
                            if (stack.Count == 0) //empty stack = bracket mismatch
                                throw new Exception("Mismatched parentheses");
                            var curToken = stack.Pop();
                            if (curToken.type == Token.Type.OpenBracket)
                                break;
                            queue.Enqueue(curToken);
                        }
                        break;
                    default: //operator
                        var o1 = token;
                        while (stack.Count != 0)
                        {
                            var o2 = stack.Peek();
                            if (o2.IsOperator &&
                                (o1.Assoc == Token.Associativity.LeftToRight && o1.Precedence <= o2.Precedence) ||
                                (o1.Assoc == Token.Associativity.RightToLeft && o1.Precedence < o2.Precedence))
                            {
                                queue.Enqueue(stack.Pop());
                            }
                            else
                                break;
                        }
                        stack.Push(o1);
                        break;
                }
            }
            while (stack.Count != 0)
            {
                var curToken = stack.Pop();
                if (curToken.type == Token.Type.OpenBracket || curToken.type == Token.Type.CloseBracket)
                    throw new Exception("Mismatched parentheses");
                queue.Enqueue(curToken);
            }
            _prefixTokens = queue.ToArray();
        }

        private void addOperatorToken(char ch, Token.Type type)
        {
            if (_curToken.Length > 0)
            {
                _tokens.Add(new Token(_curToken, Token.Type.Data));
                _curToken = "";
            }
            _tokens.Add(new Token(ch.ToString(), type));
        }

        public void Print()
        {
            if (_prefixTokens == null)
                return;
            foreach (var token in _prefixTokens)
                Console.WriteLine(token);
        }

        private void operation(Token.Type type, bool op1, bool op2, out bool result)
        {
            result = false;
            switch (type)
            {
                case Token.Type.OperatorNot:
                    result = !op1;
                    break;
                case Token.Type.OperatorAnd:
                    result = op1 & op2;
                    break;
                case Token.Type.OperatorOr:
                    result = op1 | op2;
                    break;
                default:
                    break;
            }
        }

        public delegate bool Evaluate(string value);

        public bool Calculate(Evaluate eval)
        {
            if (_prefixTokens == null)
                throw new Exception("No tokens to process");
            var stack = new Stack<bool>(_prefixTokens.Length);
            foreach (var token in _prefixTokens)
            {
                if (token.IsOperator)
                {
                    switch (token.type)
                    {
                        case Token.Type.OperatorNot:
                            {
                                if (stack.Count < 1)
                                    throw new Exception("Not enough operands");
                                var op1 = stack.Pop();
                                bool result;
                                operation(token.type, op1, false, out result);
                                stack.Push(result);
                            }
                            break;

                        case Token.Type.OperatorAnd:
                        case Token.Type.OperatorOr:
                            {
                                if (stack.Count < 2)
                                    throw new Exception("Not enough operands");
                                var op2 = stack.Pop();
                                var op1 = stack.Pop();
                                bool result;
                                operation(token.type, op1, op2, out result);
                                stack.Push(result);
                            }
                            break;

                        default: //do nothing
                            break;
                    }
                }
                else
                    stack.Push(eval(token.data));
            }
            if (stack.Count == 0)
                throw new Exception("Expression has no result.");
            return stack.Pop();
        }
    }
}