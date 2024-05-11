using System.Text;

namespace thhylR.Helper
{
    public static class ExpressionAnalyzer
    {
        public static decimal getValue(string expression)
        {
            expression = expression.Replace("\r", "").Replace("\n", "");
            expression = expression.Replace(" ", "").Replace("\t", "");
            expression = expression.Replace("**", "\uFDD0").Replace("&&", "\uFDD1").Replace("||", "\uFDD2");
            expression = expression.Replace("==", "\uFDD3").Replace("!=", "\uFDD4").Replace("<=", "\uFDD5").Replace(">=", "\uFDD6");
            LinkedList<ExpressionOperators> expressionParts = new LinkedList<ExpressionOperators>();
            StringBuilder numericPart = new StringBuilder();
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (c == '.' || (c >= '0' && c <= '9'))
                {
                    numericPart.Append(c);
                }
                else
                {
                    if (numericPart.Length > 0)
                    {
                        decimal val = Convert.ToDecimal(numericPart.ToString());
                        expressionParts.AddLast(new ExpressionOperators(val));
                        numericPart.Clear();
                    }
                    expressionParts.AddLast(new ExpressionOperators(c.ToString()));
                }
            }
            if (numericPart.Length > 0)
            {
                decimal val = Convert.ToDecimal(numericPart.ToString());
                expressionParts.AddLast(new ExpressionOperators(val));
            }

            ExpressionOperators parenthese = new ExpressionOperators("(");
            ExpressionOperators backParenthese = new ExpressionOperators(")");

            var firstBackParenthese = expressionParts.Find(backParenthese);
            while (firstBackParenthese != null)
            {
                var node = firstBackParenthese;
                while (node.Previous != null && !node.Value.Equals(parenthese))
                {
                    node = node.Previous;
                }
                if (node.Value.Equals(parenthese))
                {
                    LinkedList<ExpressionOperators> currentExpression = new LinkedList<ExpressionOperators>();
                    var nodeToAdd = node.Next;
                    do
                    {
                        currentExpression.AddLast(nodeToAdd.Value);
                        nodeToAdd = nodeToAdd.Next;
                    } while (nodeToAdd != firstBackParenthese);
                    var result = calculateValue(currentExpression);
                    expressionParts.AddBefore(node, new ExpressionOperators(result));

                    var nodeToRemove = node;
                    var nextNode = nodeToRemove.Next;
                    while (nodeToRemove != firstBackParenthese)
                    {
                        expressionParts.Remove(nodeToRemove);
                        nodeToRemove = nextNode;
                        nextNode = nodeToRemove.Next;
                    }
                    expressionParts.Remove(firstBackParenthese);
                }
                else
                {
                    throw new Exception("unmatched parentheses");
                }
                firstBackParenthese = expressionParts.Find(backParenthese);
            }

            return calculateValue(expressionParts);
        }


        private static decimal calculateValue(LinkedList<ExpressionOperators> expressions)
        {
            List<int> allOpers = new List<int>();
            var node = expressions.First;
            if (node == null)
            {
                return 0;
            }
            do
            {
                if (node.Value.Oper != null && !allOpers.Contains(node.Value.Precedence))
                {
                    allOpers.Add(node.Value.Precedence);
                }
                node = node.Next;
            } while (node != null);
            allOpers.Sort();
            List<LinkedListNode<ExpressionOperators>> nodeToRemove = new List<LinkedListNode<ExpressionOperators>>();
            ExpressionOperators condOper1 = new ExpressionOperators("?");
            ExpressionOperators condOper2 = new ExpressionOperators(":");
            foreach (int precedence in allOpers)
            {
                node = expressions.First;
                do
                {
                    if (node.Value.Oper != null && node.Value.Precedence == precedence)
                    {
                        nodeToRemove.Clear();
                        if (node.Value.Type == OperType.Unary)
                        {
                            var calcNode = node;
                            var valueNode = node.Next;

                            if (valueNode == null || valueNode.Value.Oper != null)
                            {
                                throw new Exception("gramma error");
                            }
                            var tmpResult = calcNode.Value.Calculation(valueNode.Value.Value, 0, 0);
                            var newNode = expressions.AddBefore(calcNode, new ExpressionOperators(tmpResult));
                            expressions.Remove(calcNode);
                            expressions.Remove(valueNode);
                            node = newNode.Next;
                        }
                        else if (node.Value.Type == OperType.Conditional)
                        {
                            if (node.Value.Equals(condOper2))
                            {
                                throw new Exception("gramma error");
                            }
                            var valueNode1 = node.Previous;
                            if (valueNode1 == null || valueNode1.Value.Oper != null)
                            {
                                throw new Exception("gramma error");
                            }
                            var calcNode = node;
                            var valueNode2 = node.Next;
                            if (valueNode2 == null || valueNode2.Value.Oper != null)
                            {
                                throw new Exception("gramma error");
                            }
                            var calc2Node = valueNode2.Next;
                            if (calc2Node == null || !calc2Node.Value.Equals(condOper2))
                            {
                                throw new Exception("gramma error");
                            }
                            var valueNode3 = calc2Node.Next;

                            if (valueNode3 == null || valueNode3.Value.Oper != null)
                            {
                                throw new Exception("gramma error");
                            }

                            var tmpResult = calcNode.Value.Calculation(valueNode1.Value.Value, valueNode2.Value.Value, valueNode3.Value.Value);
                            var newNode = expressions.AddBefore(valueNode1, new ExpressionOperators(tmpResult));
                            expressions.Remove(valueNode1);
                            expressions.Remove(calcNode);
                            expressions.Remove(valueNode2);
                            expressions.Remove(calc2Node);
                            expressions.Remove(valueNode3);
                            node = newNode.Next;
                        }
                        else
                        {
                            var valueNode1 = node.Previous;
                            bool isUnary = false;
                            if (valueNode1 == null || valueNode1.Value.Oper != null)
                            {
                                if (node.Value.Type != OperType.MaybeUnary)
                                {
                                    throw new Exception("gramma error");
                                }
                                else
                                {
                                    isUnary = true;
                                }
                            }
                            var calcNode = node;
                            var valueNode2 = node.Next;
                            if (valueNode2 == null || valueNode2.Value.Oper != null)
                            {
                                throw new Exception("gramma error");
                            }
                            var tmpResult = 0m;
                            if (isUnary)
                            {
                                tmpResult = calcNode.Value.Calculation(0, valueNode2.Value.Value, 0);
                                var newNode = expressions.AddBefore(calcNode, new ExpressionOperators(tmpResult));
                                expressions.Remove(calcNode);
                                expressions.Remove(valueNode2);
                                node = newNode.Next;
                            }
                            else
                            {
                                tmpResult = calcNode.Value.Calculation(valueNode1.Value.Value, valueNode2.Value.Value, 0);
                                var newNode = expressions.AddBefore(valueNode1, new ExpressionOperators(tmpResult));
                                expressions.Remove(valueNode1);
                                expressions.Remove(calcNode);
                                expressions.Remove(valueNode2);
                                node = newNode.Next;
                            }
                        }
                    }
                    else
                    {
                        node = node.Next;
                    }
                } while (node != null);
            }
            return expressions.First.Value.Value;
        }

        public enum OperType
        {
            Default,
            Unary,
            Conditional,
            MaybeUnary
        }

        private class ExpressionOperators
        {
            public int Precedence { get; set; }
            public decimal Value { get; set; }
            public Func<decimal, decimal, decimal, decimal> Calculation { get; set; }
            public string Oper { get; set; }
            public OperType Type { get; set; }

            public ExpressionOperators(decimal value)
            {
                Value = value;
            }

            public ExpressionOperators(string @operator)
            {
                Oper = @operator;
                switch (@operator)
                {
                    case "(":
                    case ")":
                        Precedence = -1;
                        Calculation = (d1, d2, d3) => throw new Exception("unmatched parentheses");
                        break;
                    case "?":
                    case ":":
                        Precedence = 16;
                        Calculation = (d1, d2, d3) => d1 != 0 ? d2 : d3;
                        Type = OperType.Conditional;
                        break;
                    case "\uFDD2":
                        Precedence = 14;
                        Calculation = (d1, d2, d3) => (d1 != 0 || d2 != 0) ? 1 : 0;
                        break;
                    case "\uFDD1":
                        Precedence = 13;
                        Calculation = (d1, d2, d3) => (d1 != 0 && d2 != 0) ? 1 : 0;
                        break;
                    case "|":
                        Precedence = 12;
                        Calculation = (d1, d2, d3) => DecimalHelper.BitwiseOr(d1, d2);
                        break;
                    case "^":
                        Precedence = 11;
                        Calculation = (d1, d2, d3) => DecimalHelper.BitwiseXor(d1, d2);
                        break;
                    case "&":
                        Precedence = 10;
                        Calculation = (d1, d2, d3) => DecimalHelper.BitwiseAnd(d1, d2);
                        break;
                    case "\uFDD3":
                        Precedence = 9;
                        Calculation = (d1, d2, d3) => d1 == d2 ? 1 : 0;
                        break;
                    case "\uFDD4":
                        Precedence = 9;
                        Calculation = (d1, d2, d3) => d1 != d2 ? 1 : 0;
                        break;
                    case "<":
                        Precedence = 8;
                        Calculation = (d1, d2, d3) => d1 < d2 ? 1 : 0;
                        break;
                    case ">":
                        Precedence = 8;
                        Calculation = (d1, d2, d3) => d1 > d2 ? 1 : 0;
                        break;
                    case "\uFDD5":
                        Precedence = 8;
                        Calculation = (d1, d2, d3) => d1 <= d2 ? 1 : 0;
                        break;
                    case "\uFDD6":
                        Precedence = 8;
                        Calculation = (d1, d2, d3) => d1 >= d2 ? 1 : 0;
                        break;
                    case "+":
                        Precedence = 6;
                        Calculation = (d1, d2, d3) => d1 + d2;
                        Type = OperType.MaybeUnary;
                        break;
                    case "-":
                        Precedence = 6;
                        Calculation = (d1, d2, d3) => d1 - d2;
                        Type = OperType.MaybeUnary;
                        break;
                    case "*":
                        Precedence = 5;
                        Calculation = (d1, d2, d3) => d1 * d2;
                        break;
                    case "/":
                        Precedence = 5;
                        Calculation = (d1, d2, d3) => d1 / d2;
                        break;
                    case "\\":
                        Precedence = 5;
                        Calculation = (d1, d2, d3) => Math.Floor(d1 / d2);
                        break;
                    case "%":
                        Precedence = 5;
                        Calculation = (d1, d2, d3) => d1 % d2;
                        break;
                    case "\uFDD0":
                        Precedence = 4;
                        Calculation = (d1, d2, d3) => DecimalHelper.Pow(d1, d2);
                        break;
                    case "!":
                        Precedence = 2;
                        Calculation = (d1, d2, d3) => d1 == 0 ? 1 : 0;
                        Type = OperType.Unary;
                        break;
                    case "~":
                        Precedence = 2;
                        Calculation = (d1, d2, d3) => DecimalHelper.BitwiseNot(d1);
                        Type = OperType.Unary;
                        break;
                    default:
                        Precedence = -2;
                        Calculation = (d1, d2, d3) => throw new NotImplementedException();
                        break;
                }
            }

            public override bool Equals(object obj)
            {
                ExpressionOperators oper = obj as ExpressionOperators;
                if (oper == null) return false;
                if (Oper != oper.Oper) return false;
                if (Oper != null) return true;
                else if (Value == oper.Value) return true;
                return false;
            }

            public override int GetHashCode()
            {
                return Oper?.GetHashCode() ?? Value.GetHashCode();
            }

            public override string ToString()
            {
                if (Oper != null) return Oper;
                return Value.ToString();
            }

            private static class DecimalHelper
            {
                private class ExtractedDecimal
                {
                    public int Part0 { get; set; }
                    public int Part1 { get; set; }
                    public int Part2 { get; set; }
                    public bool IsNegative { get; set; }
                    public byte DecimalPointPos { get; set; }

                    public static implicit operator ExtractedDecimal(decimal d)
                    {
                        int[] parts = decimal.GetBits(d);
                        ExtractedDecimal result = new ExtractedDecimal();
                        result.IsNegative = (parts[3] & 0x80000000) != 0;
                        result.DecimalPointPos = (byte)((parts[3] >> 16) & 0x7F);
                        result.Part0 = parts[0];
                        result.Part1 = parts[1];
                        result.Part2 = parts[2];
                        return result;
                    }

                    public static explicit operator decimal(ExtractedDecimal d)
                    {
                        return new decimal(d.Part0, d.Part1, d.Part2, d.IsNegative, d.DecimalPointPos);
                    }
                }

                public static decimal BitwiseOr(decimal d1, decimal d2)
                {
                    ExtractedDecimal e1 = decimal.Floor(d1);
                    ExtractedDecimal e2 = decimal.Floor(d2);
                    ExtractedDecimal result = new ExtractedDecimal();
                    result.Part0 = e1.Part0 | e2.Part0;
                    result.Part1 = e1.Part1 | e2.Part1;
                    result.Part2 = e1.Part2 | e2.Part2;
                    result.IsNegative = e1.IsNegative || e2.IsNegative;
                    return (decimal)result;
                }

                public static decimal BitwiseAnd(decimal d1, decimal d2)
                {
                    ExtractedDecimal e1 = decimal.Floor(d1);
                    ExtractedDecimal e2 = decimal.Floor(d2);
                    ExtractedDecimal result = new ExtractedDecimal();
                    result.Part0 = e1.Part0 & e2.Part0;
                    result.Part1 = e1.Part1 & e2.Part1;
                    result.Part2 = e1.Part2 & e2.Part2;
                    result.IsNegative = e1.IsNegative && e2.IsNegative;
                    return (decimal)result;
                }

                public static decimal BitwiseXor(decimal d1, decimal d2)
                {
                    ExtractedDecimal e1 = decimal.Floor(d1);
                    ExtractedDecimal e2 = decimal.Floor(d2);
                    ExtractedDecimal result = new ExtractedDecimal();
                    result.Part0 = e1.Part0 ^ e2.Part0;
                    result.Part1 = e1.Part1 ^ e2.Part1;
                    result.Part2 = e1.Part2 ^ e2.Part2;
                    result.IsNegative = e1.IsNegative ^ e2.IsNegative;
                    return (decimal)result;
                }


                public static decimal BitwiseNot(decimal d1)
                {
                    ExtractedDecimal e1 = decimal.Floor(d1);
                    ExtractedDecimal result = new ExtractedDecimal();
                    result.Part0 = ~e1.Part0;
                    result.Part1 = ~e1.Part1;
                    result.Part2 = ~e1.Part2;
                    result.IsNegative = !e1.IsNegative;
                    return (decimal)result;
                }

                public static decimal Pow(decimal d1, decimal d2)
                {
                    d2 = decimal.Floor(d2);
                    decimal result = 1M;
                    if (d2 == 0) return 1M;
                    if (d2 < 0)
                    {
                        d1 = 1M / d1;
                        d2 = -d2;
                    }
                    while (d2 != 0)
                    {
                        if (d2 % 2 == 1)
                        {
                            result *= d1;
                            d2--;
                        }
                        d1 *= d1;
                        d2 /= 2;
                    }
                    return result;
                }
            }

        }
    }

}
