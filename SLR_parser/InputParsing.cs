using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLR_parser {
    public class InputParsing {

        public List<String> ParsingStack = new List<string>();
        public List<String> InputTape = new List<string>();
        public List<List<String>> Table = new List<List<string>>();
        public List<List<String>> StackTable = new List<List<string>>();

        public IDictionary<int, List<List<String>>> numbered_rules = new Dictionary<int, List<List<String>>>();

        public InputParsing(List<List<String>> Table, IDictionary<int, List<List<String>>> numbered_rules) {
            
            int count = 0;
            foreach (var x in Table) {
                //Console.WriteLine(count + ": " + String.Join("   ", x));
                x.RemoveAt(0);
                count++;
            }

            this.Table = Table;
            this.numbered_rules = numbered_rules;
        }

        public List<List<String>> parse(String Input, List<String> cols) {
            // Convert Input to list and add $ at the end
            //InputTape.Add("((a),a,(a,a))".ToCharArray().Select(c => c.ToString()));

            foreach (var a in Input.ToCharArray()) {
                InputTape.Add(a.ToString());
            }
            InputTape.Add("$");

            // Add $0 to stack
            ParsingStack.Add("$0");
            
            //for(int i = 0; i<Table.Count; i++) {
            //    for(int j = 0; j<Table.Max(l => l.Count); j++) {
            //        Console.WriteLine("Row: "+i+" Col: "+j+" : "+Table[i][j]);
            //    }
            //}

            //for(int i = 0; i < cols.Count; i++) {
            //    Console.WriteLine("I: "+i+" : "+cols[i]);
            //}

            String Action = "";
            List<String> l1 = new List<string>();

            while(InputTape.Count >= 0) {

                l1.Clear();

                l1.Add(String.Join(" ", ParsingStack));
                l1.Add(String.Join(" ", InputTape));
                l1.Add(Action);

                String stackTop = ParsingStack[ParsingStack.Count - 1];
                String inputTop = InputTape[0];
                String TableLookup = Table[int.Parse(stackTop[1].ToString())][cols.IndexOf(inputTop)];

                if (TableLookup.Contains("S")) { // If Shift Rule Exists
                    InputTape.RemoveAt(0);
                    ParsingStack.Add(inputTop+TableLookup[1]);
                    //Console.WriteLine("ACTION: SHIFT-"+ TableLookup[1]);
                    Action = "SHIFT-"+ TableLookup[1];
                }

                else if (TableLookup.Contains("R")) { // If Reduce Rule Exists
                    //Console.WriteLine("R: "+ TableLookup[1]);
                    //Console.WriteLine(numbered_rules[TableLookup[1]][0] + " -> "+String.Join("", numbered_rules[TableLookup[1]][1]));
                    //Console.WriteLine(numbered_rules[int.Parse(TableLookup[1].ToString())][0]);
                    //Console.WriteLine(numbered_rules[int.Parse(TableLookup[1].ToString())][1].Count);

                    int pops = numbered_rules[int.Parse(TableLookup[1].ToString())][1].Count;

                    for(int pop = 0; pop < pops; pop++) {
                        ParsingStack.RemoveAt(ParsingStack.Count - 1);
                    }
                    //Console.WriteLine(int.Parse(ParsingStack[ParsingStack.Count - 1][1].ToString()));
                    //Console.WriteLine(cols.IndexOf(numbered_rules[int.Parse(TableLookup[1].ToString())][0][0]));
                    String num = Table[int.Parse(ParsingStack[ParsingStack.Count - 1][1].ToString())][cols.IndexOf(numbered_rules[int.Parse(TableLookup[1].ToString())][0][0])];
                    
                    ParsingStack.Add((numbered_rules[int.Parse(TableLookup[1].ToString())][0][0]).ToString()+num);
                    Action = "REDUCE " + numbered_rules[int.Parse(TableLookup[1].ToString())][0][0] + " -> "+String.Join(" ", numbered_rules[int.Parse(TableLookup[1].ToString())][1]);
                }

                else if (TableLookup.Contains("Accept")) { // Accepting at $ in input
                    //Console.WriteLine("ACCEPTED!");
                    Action = "Accept";
                    break;
                }

                else if(TableLookup.Contains("")) { // Error is no table entry exists
                    //Console.WriteLine("Error in Input");
                    Action = "Error";
                    break;
                }

                StackTable.Add(new List<String> (l1));
            }
            l1.Clear();

            l1.Add(String.Join(" ", ParsingStack));
            l1.Add(String.Join(" ", InputTape));
            l1.Add(Action);
            StackTable.Add(new List<String>(l1));

            return StackTable;
        }
    }
}
