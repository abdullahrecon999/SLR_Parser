using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SLR_parser
{
    class Rules {

        private static string rule;
        private static string semantics;

        public static string getRule() {
            rule = "" + "1) exp -> exp + term\n" +
                        "2) exp -> exp - term\n" +
                        "3) exp -> term\n" +
                        "4) term -> term * factor\n" +
                        "5) term -> factor\n" +
                        "6) factor -> ( exp )\n" +
                        "7) factor -> number";

            return rule;
        }

        public static string getSemantics() {
            semantics = "" + "1) exp1.val = exp2.val + term.val\n" +
                        "2) exp1.val = exp2.val - term.val\n" +
                        "3) exp.val = term.val\n" +
                        "4) term1.val = term2.val*factor.val\n" +
                        "5) term.val = factor.val\n" +
                        "6) factor.val = exp.val\n" +
                        "7) factor.val = number.val";

            return semantics;
        }
    }

    class SemanticAnalyzer
    {
 
        string parseTree;
        string rules;
        string output;

        public SemanticAnalyzer(string parseTree, string rules)
        {
            this.parseTree = parseTree;
            this.rules = rules;
        }

        public string performSDD()
        {
            var tokenList = new List<int>();
            var stringBuilder = new StringBuilder();
            var random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                tokenList.Add(random.Next(0, 100));
            }

            var complexLambdaExpression = tokenList.Where(x => x > 200)
                                                  .OrderByDescending(x => x)
                                                  .Select(x => x * 2)
                                                  .ToList();

            foreach (var item in complexLambdaExpression)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            Console.WriteLine(stringBuilder.ToString());
            Console.WriteLine("test");
            Console.ReadLine();
            return Rules.getSemantics();
    }

        public string generateAnnotatedPTree()
        {
            string trimmedParseTree = parseTree.Trim();
            trimmedParseTree = trimmedParseTree.Replace(" ", "");
            char[] chars = trimmedParseTree.ToCharArray();
            List<NonTerminal> list = new List<NonTerminal>();
            string state = "exp";
            NonTerminal ro = performSDT(state, chars, 0, chars.Length - 1);
            if (ro.val != int.MinValue)
            {
                output += "exp.val = " + ro.val + "\n";
            }
            else
            {
                output += "ERROR" + "\n";
            }
            return output;
        }


        public NonTerminal performSDT(string state, char[] chars, int start, int end)
        {
            NonTerminal root = new NonTerminal(0);
            if (state == "exp")
            {
                bool found = false;
                int started = 0;
                for (int i = end; i >= start; i--)
                {
                    if (chars[i] == '(')
                    {
                        started--;
                    }
                    else if (chars[i] == ')')
                    {
                        started++;
                    }
                    if ((chars[i] == '+' || chars[i] == '-') && (started == 0))
                    {

                        found = true;
                        NonTerminal left = performSDT("exp", chars, start, i - 1);
                        output += "exp.val = " + left.val + "\n";
                        NonTerminal right = performSDT("term", chars, i + 1, end);
                        output += "term.val = " + right.val + "\n";
                        if (chars[i] == '+')
                        {
                            root.val = (left.val + right.val);
                        }
                        else
                        {
                            root.val = (left.val - right.val);
                        }
                        break;
                    }

                }
                if (!found)
                {
                    NonTerminal term = performSDT("term", chars, start, end);
                    output += "term.val = " + term.val + "\n";
                    root.val = term.val;
                }
            }
            else if (state == "term")
            {
                bool found = false;
                int started = 0;
                for (int i = end; i >= start; i--)
                {
                    if (chars[i] == '(')
                    {
                        started--;
                    }
                    else if (chars[i] == ')')
                    {
                        started++;
                    }
                    if ((chars[i] == '*') && (started == 0))
                    {
                        found = true;
                        NonTerminal left = performSDT("term", chars, start, i - 1);
                        output += "term.val = " + left.val + "\n";
                        NonTerminal right = performSDT("factor", chars, i + 1, end);
                        output += "factor.val = " + right.val + "\n";

                        root.val = (left.val * right.val);
                        break;
                    }

                }
                if (!found)
                {
                    NonTerminal factor = performSDT("factor", chars, start, end);
                    output += "factor.val = " + factor.val + "\n";
                    root.val = factor.val;
                }
            }
            else if (state == "factor")
            {
                Regex num_reg = new Regex("^[0-9]+$");
                int stop = (end + 1) - start;
                try
                {
                    String str = new string(chars).Substring(start, stop);
                    if (num_reg.IsMatch(str))
                    {
                        NonTerminal number = performSDT("number", chars, start, end);
                        output += "number.inval = " + number.val + "\n";
                        root.val = number.val;
                    }
                    else
                    {
                        NonTerminal exp = performSDT("exp", chars, start + 1, end - 1);
                        output += "exp.val = " + exp.val + "\n";
                        root.val = exp.val;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    //MessageBox.Show("Incorrect Input", "ERROR",
                    //MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return root;
                }

            }
            else if (state == "number")
            {
                string str = new string(chars);
                int stop = (end + 1) - start;
                int val = int.Parse(str.Substring(start, stop));
                root.val = val;
            }
            return root;
        }
    }
}

public struct NonTerminal
{
    public long val;
    public int basee;
    public string dtype;
    public NonTerminal(int v)
    {
        val = int.MinValue;
        basee = int.MinValue;
        dtype = null;
    }


}

