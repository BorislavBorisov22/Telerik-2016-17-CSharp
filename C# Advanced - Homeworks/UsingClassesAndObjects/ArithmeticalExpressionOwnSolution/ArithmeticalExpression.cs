namespace ArithmeticalExpression
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArithmeticalExpression
    {
        public static List<char> operators = new List<char> { '+', '-', '*', '/' };
        public static List<string> functions = new List<string> { "pow", "ln", "sqrt" };
        public static List<char> brackets = new List<char> { '(', ')' };

        public static string TrimInput(string input)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    result.Append(input[i]);
                }
            }


            return result.ToString();
        }

        public static List<string> SeparateTokens(string input)
        {
            var result = new List<string>();
            StringBuilder number = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' && (i == 0 || input[i - 1] == ',' || input[i - 1] == '('))
                {
                    number.Append("-");
                }
                else if (char.IsDigit(input[i]) || input[i] == '.')
                {
                    number.Append(input[i]);
                }
                else if (!char.IsDigit(input[i]) && input[i] != '.' && number.Length > 0)
                {
                    result.Add(number.ToString());
                    number.Clear();
                    i--;
                }
                else if (brackets.Contains(input[i]))
                {
                    result.Add(input[i].ToString());
                }
                else if (operators.Contains(input[i]))
                {
                    result.Add(input[i].ToString());
                }
                else if (i + 1 < input.Length && input.Substring(i, 2) == "ln")
                {
                    result.Add("ln");
                    i++;
                }
                else if (i + 2 < input.Length && input.Substring(i, 3) == "pow")
                {
                    result.Add("pow");
                    i += 2;
                }
                else if (i + 3 < input.Length && input.Substring(i, 4) == "sqrt")
                {
                    result.Add("sqrt");
                    i += 3;
                }
            }


            if (number.Length > 0)
            {
                result.Add(number.ToString());
            }
            return result;
        }

        public static int Precedence(string operation)
        {
            if (operation == "+" || operation == "-")
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public static Queue<string> ConvertToReversePolishNotation(List<string> input)
        {
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < input.Count; i++)
            {
                string currToken = input[i];
                double number;

                if (double.TryParse(currToken, out number))
                {
                    queue.Enqueue(currToken);
                }
                else if (functions.Contains(currToken))
                {
                    stack.Push(currToken);
                }
                else if (currToken == ",")
                {
                    if (!stack.Contains("("))
                    {
                        throw new ArgumentException("Misplaced brackets");
                    }

                    while (stack.Count != 0 && stack.Peek() != "(")
                    {
                        queue.Enqueue(stack.Pop());
                    }
                }
                else if (operators.Contains(currToken[0]))
                {
                    while (stack.Count > 0 && operators.Contains(stack.Peek()[0])
                        && Precedence(currToken) <= Precedence(stack.Peek()))
                    {
                        queue.Enqueue(stack.Pop());
                    }

                    stack.Push(currToken);
                }
                else if (currToken == "(")
                {
                    stack.Push(currToken);
                }
                else if (currToken == ")")
                {
                    if (!stack.Contains("("))
                    {
                        throw new ArgumentException("Misplaced brackets");
                    }

                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        queue.Enqueue(stack.Pop());
                    }

                    stack.Pop();
                    if (stack.Count > 0 && functions.Contains(stack.Peek()))
                    {
                        queue.Enqueue(stack.Pop());
                    }
                }



            }


            if (stack.Contains("(") || stack.Contains(")"))
            {
                throw new ArgumentException("Misplaced brackets");
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            return queue;
        }

        public static double CalculateReversePolishNotation(Queue<string> queue)
        {
            Stack<double> stack = new Stack<double>();

            while (queue.Count > 0)
            {
                string currToken = queue.Dequeue();
                double number;

                if (double.TryParse(currToken, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    if (currToken == "+")
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException("Invalid expression");
                        }

                        double firstNumber = stack.Pop();
                        double secondNumber = stack.Pop();

                        stack.Push(firstNumber + secondNumber);
                    }
                    else if (currToken == "-")
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException("Invalid expression");
                        }

                        double firstNumber = stack.Pop();
                        double secondNumber = stack.Pop();

                        stack.Push(secondNumber - firstNumber);
                    }
                    else if (currToken == "*")
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException("Invalid expression");
                        }

                        double firstNumber = stack.Pop();
                        double secondNumber = stack.Pop();

                        stack.Push(secondNumber * firstNumber);
                    }
                    else if (currToken == "/")
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException("Invalid expression");
                        }

                        double firstNumber = stack.Pop();
                        double secondNumber = stack.Pop();

                        stack.Push(secondNumber / firstNumber);
                    }
                    else if (currToken == "pow")
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException("Invalid expression");
                        }

                        double pow = stack.Pop();
                        double currNumber = stack.Pop();
                        stack.Push(Math.Pow(currNumber, pow));
                    }
                    else if (currToken == "sqrt")
                    {
                        if (stack.Count < 1)
                        {
                            throw new ArgumentException("Invalid expression");
                        }

                        double currNumber = stack.Pop();
                        stack.Push(Math.Sqrt(currNumber));
                    }
                    else if (currToken == "ln")
                    {
                        if (stack.Count < 1)
                        {
                            throw new ArgumentException("Invalid expression");
                        }

                        double currNumber = stack.Pop();
                        stack.Push(Math.Log(currNumber));
                    }

                }

            }
            
          
            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new ArgumentException("User input has too many values");
            }


        }

        public static void Calculate()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end")
                {
                    break;
                }

                try
                {
                    string trimmedInput = TrimInput(input);

                    var separatedTokens = SeparateTokens(trimmedInput);
                    var reversePolishNotation = ConvertToReversePolishNotation(separatedTokens);

                    double result = CalculateReversePolishNotation(reversePolishNotation);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void Main()
        {
            Calculate();
        }
    }
}
