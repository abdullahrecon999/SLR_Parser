using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SLR_parser
{
    class Lexer
    {


        public Dictionary<string, Regex> dict = new Dictionary<string, Regex>();
        public List<List<string>> tokens = new List<List<string>>();
        public List<string> parsedInput = new List<string>();

        public string input;
        public string grammar;

        public Lexer(string input, string grammar)
        {
            this.input = input;
            this.grammar = grammar;
        }
        
        public List<List<string>> LexAnalysis()
        {
            Debug.WriteLine("Input In lexer", input);
            Debug.WriteLine("Grammar In lexer", grammar);

            //adding dictionary
            dict.Add("integer", new Regex(@"^[0-9]+$"));
            dict.Add("operator", new Regex(@"^[\+\-\*\(\)]$"));

            //splitting the input
            parsedInput = input.Split(' ').ToList<string>();

            //looping the parsedInput to match the tokens with dictionary
            foreach(string parsedChar in parsedInput)
            {
                Debug.WriteLine(parsedChar + "\n");
                //if(dict["integer"].Match(parsedChar))
                Debug.WriteLine(dict["integer"].IsMatch(parsedChar));
                if (dict["integer"].IsMatch(parsedChar))
                {
                    List<string> list = new List<string>
                    {
                        "Integer",
                        parsedChar
                    };
                    tokens.Add(list);
                }else if(dict["operator"].IsMatch(parsedChar))
                {
                    List<string> list = new List<string>
                    {
                        "Operator",
                        parsedChar
                    };
                    tokens.Add(list);
                }
            }
            return tokens;
        }

        
    }
}
