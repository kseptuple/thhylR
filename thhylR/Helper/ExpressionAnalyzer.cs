using System.Text;

namespace thhylR.Helper
{
    public static class ExpressionAnalyzer
    {
        private static readonly List<string> multipleCharOperators = ["**", "&&", "||", "==", "!=", "<=", ">="];

        public static decimal GetValue(string expression)
        {
            expression = expression.Replace("\r", "").Replace("\n", "").Replace(" ", "").Replace("\t", "");
            var expressionTree = buildTree(expression, 0, out _);
            var result = calculateValue(expressionTree);
            if (result == null)
            {
                throw new Exception("gramma error");
            }
            return result.Value;
        }

        private static ExpressionTreeNode<ExpressionOperators> buildTree(string expression, int startPos, out int currentPos)
        {
            ExpressionTreeNode<ExpressionOperators> expressionTreeNodes = null;
            ExpressionTreeNode<ExpressionOperators> previousNode = null;
            ExpressionTreeNode<ExpressionOperators> currentNode = null;
            currentPos = startPos;

            StringBuilder numericPart = new StringBuilder();
            while (currentPos < expression.Length)
            {
                char c = expression[currentPos];
                if (c == '.' || (c >= '0' && c <= '9'))
                {
                    numericPart.Append(c);
                    currentPos++;
                }
                else
                {
                    if (numericPart.Length > 0)
                    {
                        decimal val = Convert.ToDecimal(numericPart.ToString());
                        currentNode = new ExpressionTreeNode<ExpressionOperators>(new ExpressionOperators(val));
                        numericPart.Clear();
                        insertIntoMainTree(ref expressionTreeNodes, ref previousNode, currentNode);
                    }
                    if (c == ':')
                    {
                        ExpressionTreeNode<ExpressionOperators> tmpNode = previousNode;
                        bool changeSuccess = false;
                        while (tmpNode != null)
                        {
                            if (tmpNode.Value.Type != OperType.Conditional || tmpNode.Value.IsParentheses)
                            {
                                tmpNode = tmpNode.Parent;
                            }
                            else
                            {
                                tmpNode.CurrentChildrenIndex = 2;
                                previousNode = tmpNode;
                                changeSuccess = true;
                                break;
                            }
                        }
                        if (!changeSuccess)
                        {
                            throw new Exception("gramma error");
                        }
                        currentPos++;
                    }
                    else if (c == '(')
                    {
                        currentNode = buildTree(expression, currentPos + 1, out int newPos);
                        currentNode.Value.Precedence = -1;
                        currentNode.Value.IsParentheses = true;
                        insertIntoMainTree(ref expressionTreeNodes, ref previousNode, currentNode);
                        currentPos = newPos;
                    }
                    else if (c == ')')
                    {
                        currentPos++;
                        return expressionTreeNodes;
                    }
                    else
                    {
                        currentNode = new ExpressionTreeNode<ExpressionOperators>(true);
                        if (currentPos <= expression.Length - 2)
                        {
                            var @operator = c.ToString() + expression[currentPos + 1];
                            for (int j = 0; j < multipleCharOperators.Count; j++)
                            {
                                if (@operator == multipleCharOperators[j])
                                {
                                    currentNode.Value = new ExpressionOperators(@operator,
                                        previousNode != null && previousNode.Value.Type == OperType.Number && !previousNode.Value.IsParentheses);
                                    currentPos++;
                                    break;
                                }
                            }
                        }

                        if (currentNode.Value == null)
                        {
                            currentNode.Value = new ExpressionOperators(c.ToString(),
                                previousNode != null && previousNode.Value.Type == OperType.Number && !previousNode.Value.IsParentheses);
                        }

                        currentNode.CurrentChildrenIndex = 1;
                        insertIntoMainTree(ref expressionTreeNodes, ref previousNode, currentNode);
                        currentPos++;
                    }

                }
            }

            if (numericPart.Length > 0)
            {
                decimal val = Convert.ToDecimal(numericPart.ToString());
                currentNode = new ExpressionTreeNode<ExpressionOperators>(new ExpressionOperators(val));
                numericPart.Clear();
                insertIntoMainTree(ref expressionTreeNodes, ref previousNode, currentNode);
            }

            return expressionTreeNodes;
        }

        private static void insertIntoMainTree(ref ExpressionTreeNode<ExpressionOperators> mainTree,
            ref ExpressionTreeNode<ExpressionOperators> previousNode, ExpressionTreeNode<ExpressionOperators> currentNode)
        {
            if (mainTree == null)
            {
                mainTree = currentNode;
                previousNode = currentNode;
                return;
            }
            ExpressionTreeNode<ExpressionOperators> childrenNode = null;
            while (previousNode != null && previousNode.Value.Precedence <= currentNode.Value.Precedence)
            {
                childrenNode = previousNode;
                previousNode = previousNode.Parent;
            }

            if (childrenNode != null)
            {
                if (currentNode.Children?[0] != null)
                {
                    ExpressionTreeNode<ExpressionOperators> newNode = new ExpressionTreeNode<ExpressionOperators>(
                        new ExpressionOperators("*", false), true);
                    newNode.CurrentChildrenIndex = 1;
                    newNode.Children[1] = currentNode;
                    currentNode = newNode;
                }
                currentNode.Children[0] = childrenNode;
            }

            if (previousNode != null)
            {
                previousNode.Children[previousNode.CurrentChildrenIndex] = currentNode;
            }
            else
            {
                mainTree = currentNode;
            }

            previousNode = currentNode;
        }

        private static decimal? calculateValue(ExpressionTreeNode<ExpressionOperators> expressions)
        {
            if (expressions == null)
            {
                return null;
            }
            if (expressions.Value.Type == OperType.Number)
            {
                return expressions.Value.Value;
            }
            else if (expressions.Value.Type == OperType.Conditional)
            {
                if (calculateValue(expressions.Children[0]) != 0)
                {
                    return calculateValue(expressions.Children[1]);
                }
                return calculateValue(expressions.Children[2]);
            }
            else if (expressions.Value.Type == OperType.SpecialOr)
            {
                if (calculateValue(expressions.Children[0]) != 0)
                {
                    return 1M;
                }
                return (calculateValue(expressions.Children[1]) != 0) ? 1M : 0M;
            }
            else if (expressions.Value.Type == OperType.SpecialAnd)
            {
                if (calculateValue(expressions.Children[0]) == 0)
                {
                    return 0M;
                }
                return (calculateValue(expressions.Children[1]) != 0) ? 1M : 0M;
            }
            else
            {
                return expressions.Value.Calculation(calculateValue(expressions.Children[0]), calculateValue(expressions.Children[1]));
            }
        }

        public enum OperType
        {
            Number,
            Conditional,
            NormalOper,
            SpecialAnd,
            SpecialOr
        }

        private class ExpressionOperators
        {
            public int Precedence { get; set; }
            public decimal Value { get; set; }
            public Func<decimal?, decimal?, decimal?> Calculation { get; set; }
            public string Oper { get; set; }
            public OperType Type { get; set; }
            public bool IsParentheses { get; set; } = false;

            public ExpressionOperators(decimal value)
            {
                Value = value;
                Precedence = -1;
                Type = OperType.Number;
            }

            public ExpressionOperators(string @operator, bool lastTokenIsNumber)
            {
                Oper = @operator;
                Type = OperType.NormalOper;
                switch (@operator)
                {
                    case "?":
                        Precedence = 16;
                        Type = OperType.Conditional;
                        break;
                    case "||":
                        Precedence = 14;
                        Type = OperType.SpecialOr;
                        break;
                    case "&&":
                        Precedence = 13;
                        Type = OperType.SpecialAnd;
                        break;
                    case "|":
                        Precedence = 12;
                        Calculation = DecimalHelper.BitwiseOr;
                        break;
                    case "^":
                        Precedence = 11;
                        Calculation = DecimalHelper.BitwiseXor;
                        break;
                    case "&":
                        Precedence = 10;
                        Calculation = DecimalHelper.BitwiseAnd;
                        break;
                    case "==":
                        Precedence = 9;
                        Calculation = (d1, d2) => d1 == d2 ? 1 : 0;
                        break;
                    case "!=":
                        Precedence = 9;
                        Calculation = (d1, d2) => d1 != d2 ? 1 : 0;
                        break;
                    case "<":
                        Precedence = 8;
                        Calculation = (d1, d2) => d1 < d2 ? 1 : 0;
                        break;
                    case ">":
                        Precedence = 8;
                        Calculation = (d1, d2) => d1 > d2 ? 1 : 0;
                        break;
                    case "<=":
                        Precedence = 8;
                        Calculation = (d1, d2) => d1 <= d2 ? 1 : 0;
                        break;
                    case ">=":
                        Precedence = 8;
                        Calculation = (d1, d2) => d1 >= d2 ? 1 : 0;
                        break;
                    case "+":
                        Precedence = 6;
                        if (!lastTokenIsNumber) Precedence = 2;
                        Calculation = (d1, d2) => (d1 ?? 0) + d2;
                        break;
                    case "-":
                        Precedence = 6;
                        if (!lastTokenIsNumber) Precedence = 2;
                        Calculation = (d1, d2) => (d1 ?? 0) - d2;
                        break;
                    case "*":
                        Precedence = 5;
                        Calculation = (d1, d2) => d1 * d2;
                        break;
                    case "/":
                        Precedence = 5;
                        Calculation = (d1, d2) => d1 / d2;
                        break;
                    case "\\":
                        Precedence = 5;
                        Calculation = (d1, d2) => (d1 == null || d2 == null) ? null : Math.Floor(d1.Value / d2.Value);
                        break;
                    case "%":
                        Precedence = 5;
                        Calculation = (d1, d2) => d1 % d2;
                        break;
                    case "**":
                        Precedence = 4;
                        Calculation = DecimalHelper.Pow;
                        break;
                    case "!":
                        Precedence = 2;
                        Calculation = (d1, d2) => d2 == 0 ? 1 : 0;
                        break;
                    case "~":
                        Precedence = 2;
                        Calculation = (d1, d2) => DecimalHelper.BitwiseNot(d2);
                        break;
                    default:
                        throw new NotImplementedException();
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

                public static decimal? BitwiseOr(decimal? d1, decimal? d2)
                {
                    if (d1 == null || d2 == null) return null;
                    ExtractedDecimal e1 = decimal.Floor(d1.Value);
                    ExtractedDecimal e2 = decimal.Floor(d2.Value);
                    ExtractedDecimal result = new ExtractedDecimal();
                    result.Part0 = e1.Part0 | e2.Part0;
                    result.Part1 = e1.Part1 | e2.Part1;
                    result.Part2 = e1.Part2 | e2.Part2;
                    result.IsNegative = e1.IsNegative || e2.IsNegative;
                    return (decimal)result;
                }

                public static decimal? BitwiseAnd(decimal? d1, decimal? d2)
                {
                    if (d1 == null || d2 == null) return null;
                    ExtractedDecimal e1 = decimal.Floor(d1.Value);
                    ExtractedDecimal e2 = decimal.Floor(d2.Value);
                    ExtractedDecimal result = new ExtractedDecimal();
                    result.Part0 = e1.Part0 & e2.Part0;
                    result.Part1 = e1.Part1 & e2.Part1;
                    result.Part2 = e1.Part2 & e2.Part2;
                    result.IsNegative = e1.IsNegative && e2.IsNegative;
                    return (decimal)result;
                }

                public static decimal? BitwiseXor(decimal? d1, decimal? d2)
                {
                    if (d1 == null || d2 == null) return null;
                    ExtractedDecimal e1 = decimal.Floor(d1.Value);
                    ExtractedDecimal e2 = decimal.Floor(d2.Value);
                    ExtractedDecimal result = new ExtractedDecimal();
                    result.Part0 = e1.Part0 ^ e2.Part0;
                    result.Part1 = e1.Part1 ^ e2.Part1;
                    result.Part2 = e1.Part2 ^ e2.Part2;
                    result.IsNegative = e1.IsNegative ^ e2.IsNegative;
                    return (decimal)result;
                }


                public static decimal? BitwiseNot(decimal? d1)
                {
                    if (d1 == null) return null;
                    ExtractedDecimal e1 = decimal.Floor(d1.Value);
                    ExtractedDecimal result = new ExtractedDecimal();
                    result.Part0 = ~e1.Part0;
                    result.Part1 = ~e1.Part1;
                    result.Part2 = ~e1.Part2;
                    result.IsNegative = !e1.IsNegative;
                    return (decimal)result;
                }

                public static decimal? Pow(decimal? d1, decimal? d2)
                {
                    if (d1 == null || d2 == null) return null;
                    d2 = decimal.Floor(d2.Value);
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
                            result *= d1.Value;
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

