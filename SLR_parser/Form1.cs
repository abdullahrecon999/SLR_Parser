using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SLR_parser {
    public partial class Form1 : Form {

        public List<List<String>> Table = new List<List<string>>();
        public SLR_DFA dfa;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            String grammar = InputBox.Text;

            Preprocessor preprocessor1 = new Preprocessor();
            Tuple<int,String> output = preprocessor1.InitGrammar(grammar);

            if (output.Item1 == -1) {
                ErrorBox.Text = output.Item2;
            } else {
                ErrorBox.Text = output.Item2;
            }

            preprocessor1.Find_FirstSet();
            preprocessor1.Find_FollowSet();
            //Console.WriteLine(preprocessor1.FOLLOW_SET);

            // Display first and follow in GUI
            foreach (var item in preprocessor1.FIRST_SET) {
                String val = item.Key + " : { " + String.Join(", ", item.Value) + " } \n";
                FirstSetBox.Text = FirstSetBox.Text + val;
            }

            foreach (var item in preprocessor1.FOLLOW_SET) {
                String val = item.Key + " : { " + String.Join(", ", item.Value) + " } \n";
                FollowSetBox.Text = FollowSetBox.Text + val;
            }

            dfa = new SLR_DFA(preprocessor1.Rules, preprocessor1.nonterminals, preprocessor1.Start_symbol);

            dfa.augmentGrammar(preprocessor1.Rules, preprocessor1.nonterminals, preprocessor1.Start_symbol);
            dfa.statesDict[0] = new List<List<List<String>>>( dfa.findClosure(dfa.AugRules, dfa.AugRules[0][0][0]));
            dfa.generateStates(dfa.statesDict);
            Table = dfa.createParseTable(dfa.statesDict, dfa.stateMap, preprocessor1.terminals, preprocessor1.nonterminals, preprocessor1.FOLLOW_SET);

            //// Display GOTO in GUI
            foreach (var item in dfa.stateMap) {
                String val = "GOTO: ( I" + item.Key.Item1 + " , " + item.Key.Item2 + " ) = I" + item.Value + "\n";
                GotoBox.Text = GotoBox.Text + val;
            }

            // Display DFA
            foreach (var st in dfa.statesDict) {
                //Console.WriteLine("STATE : "+st.Key);
                DFABox.Text = DFABox.Text + "STATE I" + st.Key + ":\n";
                foreach (var item in dfa.statesDict[st.Key]) {
                    //Console.WriteLine("  "+ String.Join(" ", item[0]) + " -> "+String.Join(" ",item[1]));
                    if(!String.Join(" ", item[1]).Contains(".")) {
                        DFABox.Text = DFABox.Text + "  " + String.Join(" ", item[0]) + " -> " + String.Join(" ", item[1]) + " .\n";
                    } else {
                        DFABox.Text = DFABox.Text + "  " + String.Join(" ", item[0]) + " -> " + String.Join(" ", item[1]) + "\n";
                    }
                }
                DFABox.Text = DFABox.Text + "\n-----------------------------\n";
            }

            Ptable.ColumnCount = dfa.colss.Count+1;
            Ptable.AutoResizeColumns();
            Ptable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            int i = 1;
            Ptable.Columns[0].Name = "";
            foreach (var x in dfa.colss) {
                Ptable.Columns[i].Name = x;
                i++;
            }

            int count = 0;
            foreach (var x in Table) {
                //Console.WriteLine(count + ": " + String.Join("   ", x));
                x.Insert(0, "I" + count);
                Ptable.Rows.Add(x.ToArray());
                count++;
            }

            //Console.WriteLine(dfa.numbered_rules);

            foreach (var x in dfa.numbered_rules) {
                NumberedBox.Text = NumberedBox.Text + x.Key + ": " + String.Join(" ",x.Value[0])+" -> " + String.Join(" ", x.Value[1])+"\n";
            }

        }

        private void groupBox3_Enter(object sender, EventArgs e) {

        }

        private void ClearAll_Click(object sender, EventArgs e) {
            InputBox.Clear();
            GotoBox.Clear();
            DFABox.Clear();
            FirstSetBox.Clear();
            FollowSetBox.Clear();
            ErrorBox.Clear();
            Ptable.Columns.Clear();
            Ptable.Rows.Clear();
            Ptable.Refresh();
            NumberedBox.Clear();
            ParsingBox.Columns.Clear();
            ParsingBox.Rows.Clear();
            InputString.Clear();
        }

        private void Ptable_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void ParseButton_Click(object sender, EventArgs e) {

            ParsingBox.Columns.Clear();
            ParsingBox.Rows.Clear();

            InputParsing parser = new InputParsing(Table, dfa.numbered_rules);
            List<List<String>> outputTrace = parser.parse(InputString.Text, dfa.colss);

            ParsingBox.ColumnCount = 3;
            ParsingBox.AutoResizeColumns();
            ParsingBox.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            ParsingBox.Columns[0].Name = "STACK";
            ParsingBox.Columns[1].Name = "INPUT";
            ParsingBox.Columns[2].Name = "ACTION";

            foreach (var x in outputTrace) {
                ParsingBox.Rows.Add(x.ToArray());
            }
        }
    }
}
