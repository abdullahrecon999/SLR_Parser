using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLR_parser {

    class Node {
        public string Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(string value) {
            Value = value;
        }
    }

    class MainSyntaxTree {

        public Node getRoot(string[] postfixExpression) {
            Stack<Node> stack = new Stack<Node>();

            foreach (string token in postfixExpression) {
                if (IsOperator(token)) {
                    Node node = new Node(token);
                    node.Right = stack.Pop();
                    node.Left = stack.Pop();
                    stack.Push(node);
                } else if (token == "(") {
                    // Do nothing
                } else if (token == ")") {
                    stack.Push(stack.Pop());
                } else {
                    stack.Push(new Node(token));
                }
            }

            //return stack.Pop();

            stack.Pop();
            return stack.Pop();
        }
        public string GenerateSyntaxTree(string[] postfixExpression) {
            Stack<Node> stack = new Stack<Node>();

            foreach (string token in postfixExpression) {
                if (IsOperator(token)) {
                    Node node = new Node(token);
                    node.Right = stack.Pop();
                    node.Left = stack.Pop();
                    stack.Push(node);
                } else if (token == "(") {
                    // Do nothing
                } else if (token == ")") {
                    stack.Push(stack.Pop());
                } else {
                    stack.Push(new Node(token));
                }
            }

            //return stack.Pop();

            stack.Pop();
            Node outNode = stack.Pop();

            String output = PrintTree(outNode);

            Console.WriteLine("Expression Tree:");

            //Stack<Node> stack = new Stack<Node>();
            //stack.Push(val);
            //int level = 0;
            //while (stack.Count > 0) {
            //    Node node = stack.Pop();

            //    if (node != null) {
            //        Console.WriteLine(new String(' ', level * 2) + "| " + node.Value + " |");
            //        output += new String(' ', level * 2) + "| " + node.Value + " |" + "\n";

            //        if (node.Right != null) {
            //            stack.Push(node.Right);
            //        }

            //        if (node.Left != null) {
            //            stack.Push(node.Left);
            //        }

            //        if (node.Left != null || node.Right != null) {
            //            level++;
            //        }
            //    } else {
            //        level--;
            //    }
            //}

            Console.WriteLine(output);
            return output;
        }

        public string PrintTree(Node root) {
            string outp = "";
            Stack<Tuple<Node, string, bool>> stack = new Stack<Tuple<Node, string, bool>>();
            stack.Push(Tuple.Create(root, "", true));

            while (stack.Count > 0) {
                Tuple<Node, string, bool> tuple = stack.Pop();
                Node node = tuple.Item1;
                string indent = tuple.Item2;
                bool last = tuple.Item3;

                Console.Write(indent);
                outp += indent;
                if (last) {
                    Console.Write("\\-");
                    outp += "\\-";
                    indent += "  ";
                } else {
                    Console.Write("|-");
                    outp += "|-";
                    indent += "| ";
                }

                Console.WriteLine(node.Value);
                outp += node.Value + "\n";

                if (node.Right != null) {
                    stack.Push(Tuple.Create(node.Right, indent, true));
                }
                if (node.Left != null) {
                    stack.Push(Tuple.Create(node.Left, indent, node.Right == null));
                }
            }
            Console.WriteLine(outp);
            return outp;
        }

        private static bool IsOperator(string token) {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        public string PrintSyntaxTree(Node root) {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            int level = 0;
            String output = "";
            while (stack.Count > 0) {
                Node node = stack.Pop();

                if (node != null) {
                    Console.WriteLine(new String(' ', level * 2) + " " + node.Value);
                    output += new String(' ', level * 2) + " " + node.Value + "\n";

                    if (node.Right != null) {
                        stack.Push(node.Right);
                    }

                    if (node.Left != null) {
                        stack.Push(node.Left);
                    }

                    if (node.Left != null || node.Right != null) {
                        Console.WriteLine(new String(' ', level * 2) + "|");
                        output += new String(' ', level * 2) + "|" + "\n";
                        level++;
                    }
                } else {
                    level--;
                }
            }
            Console.WriteLine(output);
            return output;
        }

        //static void Main(string[] args) {
        //    string[] postfixExpression = { "2", "3", "(", "4", "*", ")", "+" };
        //    Node root = GenerateSyntaxTree(postfixExpression);

        //    PrintSyntaxTree(root, 0);
        //}

        public string InfixToPostfix(string infix) {
            Console.WriteLine("INFIX: "+infix);
            // Create a stack to store operators
            Stack<char> stack = new Stack<char>();

            // Create a string to store the postfix expression
            string postfix = "";

            // Loop through the infix expression
            for (int i = 0; i < infix.Length; i++) {
                // Get the current character
                char c = infix[i];

                // If the current character is a digit, add it to the postfix expression
                if (char.IsDigit(c)) {
                    // Check if the next character is also a digit
                    while (i + 1 < infix.Length && char.IsDigit(infix[i + 1])) {
                        // If the next character is a digit, add it to the postfix expression
                        postfix += c;
                        i++;
                        c = infix[i];
                    }
                    // Add the last digit and a space to the postfix expression
                    postfix += c + " ";
                }
                // If the current character is an opening parenthesis, push it to the stack
                else if (c == '(') {
                    stack.Push(c);
                }
                // If the current character is a closing parenthesis, pop all the operators from the stack and add them to the postfix expression until you find an opening parenthesis
                else if (c == ')') {
                    while (stack.Peek() != '(') {
                        postfix += stack.Pop() + " ";
                    }
                    stack.Pop();
                }
                // If the current character is an operator, pop all the operators from the stack and add them to the postfix expression until you find an operator with a lower precedence
                else if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^') {
                    while (stack.Count > 0 && GetPrecedence(c) <= GetPrecedence(stack.Peek())) {
                        postfix += stack.Pop() + " ";
                    }
                    stack.Push(c);
                }
            }

            // Pop all the remaining operators from the stack and add them to the postfix expression
            while (stack.Count > 0) {
                postfix += stack.Pop() + " ";
            }

            // Return the postfix expression
            Console.WriteLine("POSTFIX: ");
            Console.WriteLine(postfix.ToString());
            return postfix;
        }

        // Method to get the precedence of an operator
        public int GetPrecedence(char c) {
            if (c == '+' || c == '-') {
                return 1;
            } else if (c == '*' || c == '/') {
                return 2;
            } else if (c == '^') {
                return 3;
            } else {
                return 0;
            }
        }
    }
}
