using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SLR_parser {
    public class SLR_DFA {

        public IDictionary<String, List<List<String>>> Rules = new Dictionary<String, List<List<String>>>();
        public IDictionary<Tuple<int, String>, int> stateMap = new Dictionary<Tuple<int, String>, int>();
        public IDictionary<int, List<List<List<String>>>> statesDict = new Dictionary<int, List<List<List<String>>>>();
        public IDictionary<int, List<List<String>>> numbered_rules = new Dictionary<int, List<List<String>>>();
        public IDictionary<String, List<List<String>>> diction = new Dictionary<String, List<List<String>>>();
        public IDictionary<String, List<List<String>>> AugRulesNoDot = new Dictionary<String, List<List<String>>>();
        public List<String> colss = new List<string>();

        public List<List<List<String>>> AugRules = new List<List<List<String>>>();
        public List<string> nonterminals = new List<string>();

        public int stateCount = 0;
        public String start_symbol;
        public SLR_DFA(IDictionary<String, List<List<String>>> rules, List<String> nont, String start) {
            this.Rules = rules;
            this.nonterminals = nont;
            this.start_symbol = start;

            //Augment Rule
            List<String> a = new List<string>();
            List<List<String>> b = new List<List<string>>();
            a.Add(start);
            b.Add(a);
            AugRulesNoDot[start + "'"] = new List<List<string>>(b);

            // Old rules
            AugRulesNoDot[start] = new List<List<string>>(rules[start]);
            
        }

        public List<List<List<String>>> augmentGrammar(IDictionary<String, List<List<String>>> rules, List<String> nont, String start) {

            //IDictionary<String, List<String>> New_Rules = new Dictionary<String, List<String>>();

            if (start.Contains("'")) {
                start = start.Replace("'","");
            }

            String newChar = start + "'";
            //while (nont.Contains(newChar)) {
            //    newChar += "'";
            //}

            List<List<List<String>>> newRules = new List<List<List<String>>>();  // [ [[nonterm] , ['.','terms'...]], [[nonterm] , ['.','terms'...]], ... ]
            List<List<String>> inner_main = new List<List<String>>(); //   [[nonterm] , ['.','terms'...]]
            List<String> inner_rule = new List<String>(); // ['.','terms'...]

            //inner_main.Add(new List<String> { newChar });
            //inner_rule.Add(".");
            //inner_rule.Add(start);
            //inner_main.Add(new List<String>( inner_rule ));

            //newRules.Add(new List<List<String>>( inner_main )); // [ [ [E'], ['.','E'] ] ]

            foreach (var rul in rules) {
                foreach (List<String> ruls in rul.Value) { // A : [ [a,b], [c,d,#] ]
                    inner_main.Clear();
                    inner_rule.Clear();
                    inner_rule.Add(".");

                    foreach (String item in ruls) {
                        inner_rule.Add(item);
                    } // ['.', 'a', 'b']

                    inner_main.Add(new List<String> { rul.Key });
                    inner_main.Add(new List<String>(inner_rule));
                    newRules.Add(new List<List<String>>(inner_main));
                }
            }
            AugRules = newRules;

            // [ [ [nonterm] , ['.','terms'...] ], [[nonterm] , ['.','terms'...]], ... ]
            // Numbered _ Rules : {0: ["E'", ['E']], 1: ['E', ['E', '+', 't']], 2: ['E', ['t']]}
            List<String> a = new List<string>();
            List<String> b = new List<string>();
            List<List<String>> c = new List<List<string>>();

            List<List<List<String>>> mainList = new List<List<List<String>>>();

            for (int i = 0; i < newRules.Count; i++) {

                a.Clear();
                b.Clear();
                c.Clear();

                //Console.WriteLine("NTL :: "+newRules[i][0][0]);
                a.Add(newRules[i][0][0]);

                for(int j = 0; j < newRules[i][1].Count; j++) {
                    if(newRules[i][1][j] == ".") {
                        continue;
                    }
                    //Console.WriteLine("   TL :: " + newRules[i][1][j]);
                    b.Add(newRules[i][1][j]);
                }
                c.Add(new List<string>(a));
                c.Add(new List<string> (b));

                numbered_rules[i] = new List<List<string>> (c);
                //AugRulesNoDot[c[i][0]] = new List<List<string>>(c);

                //numbered_rules[i].Add( new List<List<string>>());
            }

            //Console.WriteLine(numbered_rules);

            return newRules;
        }

        public List<List<List<String>>> findClosure(List<List<List<String>>> input_state , String symbol) {
            List<List<List<String>>> closureset = new List<List<List<String>>>();

            // AugRule => [ [[nonterm] , ['.','terms'...]], [[nonterm] , ['.','terms'...]], ... ]
            if (symbol == start_symbol+"'") {
                foreach (var rule in AugRules) {
                    if (rule[0][0] == symbol) {
                        closureset.Add(new List<List<String>> (rule));
                    }
                }
            } else {
                closureset = new List<List<List<String>>> (input_state);
            }

            int prevlen = -1;

            while (prevlen != closureset.Count) {
                prevlen = closureset.Count;

                List<List<List<String>>> tempclosureset = new List<List<List<String>>>();

                foreach(var rule in closureset) {
                    int indexOfDot = rule[1].IndexOf(".");
                    if (!rule[1][rule[1].Count - 1][0].ToString().Equals(".")) {
                        String dotPointsHere = rule[1][indexOfDot + 1];
                        foreach (var in_rule in AugRules) {
                            // This Check is not working
                            //Console.WriteLine("TEST 1--- "+tempclosureset.Contains(in_rule));
                            //Console.WriteLine("dotPointsHere: "+ dotPointsHere);
                            //Console.WriteLine("in_rule[0][0]: "+ in_rule[0][0]);
                            //Console.WriteLine("TEST 2--- " + dotPointsHere.Equals(in_rule[0][0]));
                            if (dotPointsHere.Equals(in_rule[0][0]) && !tempclosureset.Contains(in_rule)) {
                                tempclosureset.Add(in_rule);
                            }
                        }
                    }
                }

                List<String> val = new List<string>();
                foreach (var r in closureset) {
                    val.Add(String.Join(" ",r[0])+String.Join(" ",r[1])); // E'. E
                }

                foreach (var rule in tempclosureset) {
                    // This check is now not working
                    // Create Flat ClouseSet String for comparison
                    String rule_string = String.Join(" ", rule[0]) + String.Join(" ", rule[1]);
                    if (!val.Contains(rule_string)) {
                        closureset.Add(new List<List<string>> (rule));
                    }
                }
            }
            //Console.WriteLine(closureset);
            
            return closureset;
        }


        public void generateStates(IDictionary<int, List<List<List<String>>>> statesDict) {
            int prev_len = -1;
            List<int> called_GOTO_on = new List<int>();
            List<int> keys = new List<int>();

            while (statesDict.Count != prev_len) {
                prev_len = statesDict.Count;
                keys = statesDict.Keys.ToList();

                foreach(var key in keys) {
                    if (!called_GOTO_on.Contains(key)) { // 1st Point
                        called_GOTO_on.Add(key);
                        compute_GOTO(key);
                    }
                }
            }
        }

        public void compute_GOTO(int state) {

            List<String> generateStatesFor = new List<String>();

            foreach (var rule in statesDict[state]) {
                if (!rule[1][rule[1].Count - 1][0].ToString().Equals(".")) { // 2nd point
                    int indexOfDot = rule[1].IndexOf(".");
                    String dotPointsHere = rule[1][indexOfDot + 1];
                    if (!generateStatesFor.Contains(dotPointsHere)) {
                        generateStatesFor.Add(dotPointsHere);
                    }
                }
            }

            if (generateStatesFor.Count != 0) {
                foreach(var symbol in generateStatesFor) {
                    GOTO(state, symbol);
                }
            }

        }

        public void GOTO(int state, String charNextToDot) {
            List<List<List<String>>> newState = new List<List<List<String>>>();

            foreach (var rule in statesDict[state]) {
                int indexOfDot = rule[1].IndexOf(".");  // 3rd point
                if (!rule[1][rule[1].Count - 1][0].ToString().Equals(".")) {
                    if (rule[1][indexOfDot+1] == charNextToDot) {

                        List<List<String>> shiftedRule = new List<List<string>>();

                        foreach(var r in rule) {
                            shiftedRule.Add(new List<String>(r));
                        }

                        shiftedRule[1][indexOfDot] = shiftedRule[1][indexOfDot + 1]; // TODO CAN HAVE ERRORS HERE
                        shiftedRule[1][indexOfDot + 1] = ".";
                        newState.Add(shiftedRule);

                    }
                }
            }

            List<List<List<String>>> addClosureRules = new List<List<List<String>>>();

            foreach(var rule in newState) {
                int indexOfDot = rule[1].IndexOf(".");
                if (!rule[1][rule[1].Count - 1][0].ToString().Equals(".")) {
                    List<List<List<String>>> closureRes = new List<List<List<string>>>();
                    closureRes = findClosure(newState, rule[1][indexOfDot + 1]);

                    foreach(var rule2 in closureRes) {
                        if(!addClosureRules.Contains(rule2) && !newState.Contains(rule2)) {
                            addClosureRules.Add(rule2);     // CHECK FOR ERRORS HERE
                        }
                    }
                }
            }

            foreach(var rule in addClosureRules) {
                newState.Add(new List<List<string>> (rule));
            }

            int stateExists = -1;

            // newState to String
            String newState_string = "";
            foreach (var x in newState) {
                newState_string = newState_string + x[0][0] + String.Join(" ", x[1]);
            }

            foreach(var state_num in statesDict.Keys) {
                String newStateDict_string = "";
                foreach (var x in statesDict[state_num]) {
                    newStateDict_string = newStateDict_string + x[0][0] + String.Join(" ", x[1]);
                }

                if(newStateDict_string.Equals(newState_string)) { // <----------- [ Problem ]
                    stateExists = state_num;
                    break;
                }
            }

            if(stateExists == -1) {
                stateCount += 1;
                statesDict[stateCount] = new List<List<List<String>>>(newState);
                stateMap[(state, charNextToDot).ToTuple()] = stateCount;
            } else {
                stateMap[(state, charNextToDot).ToTuple()] = stateExists;
            }

        }

        public List<List<String>> createParseTable(IDictionary<int, List<List<List<String>>>>  statesDict, IDictionary<Tuple<int, String>, int> stateMap, List<string> T, List<string> NT, IDictionary<String, List<String>> FOLLOW_SET) {

            List<int> rows = new List<int>();
            List<String> cols = new List<string>();
            rows = statesDict.Keys.ToList();
            IDictionary<int, List<List<List<String>>>> statesDict_copy = new Dictionary<int, List<List<List<String>>>>();

            // DEEP COPY DICT !!!

            foreach (var key in statesDict.Keys) {
                statesDict_copy[key] = new List<List<List<string>>>(statesDict[key]);
            }

            foreach (var a in T) {
                cols.Add(a);
            }
            cols.Add("$");
            foreach (var a in NT) {
                cols.Add(a);
            }

            List<List<String>> Table = new List<List<string>>();
            List<String> tempRow = new List<string>();

            for(int y = 0; y < cols.Count; y++) {
                tempRow.Add("");
            }

            for (int x = 0; x < rows.Count; x++) {
                Table.Add(new List<string> (tempRow));
            }

            foreach (var entry in stateMap) {
                int state = entry.Key.Item1;
                String symbol = entry.Key.Item2;

                int a = rows.IndexOf(state);
                int b = cols.IndexOf(symbol);

                if (NT.Contains(symbol)) {
                    Table[a][b] = Table[a][b] + stateMap[entry.Key];
                } else if (T.Contains(symbol)) {
                    Table[a][b] = Table[a][b] + "S" + stateMap[entry.Key];
                }
            }

            //IDictionary<int, List<List<String>>> numbered = new Dictionary<int, List<List<String>>>();
            //IDictionary<int, String> rules = new Dictionary<int, String>();
            //int key_count = 0;

            //Console.Write(statesDict);
            //foreach (var rulee in AugRules) {
            //    Console.Write(statesDict);
            //    List<List<String>> temprule = new List<List<string>>();
            //    temprule = new List<List<string>>(rulee);
            //    //temprule[1].Remove(".");
            //    numbered[key_count] = new List<List<String>>(temprule);
            //    key_count += 1;
            //}

            List<List<String>> val = new List<List<string>>();
            val.Add(new List<String> (AugRules[0][1]));
            Rules[AugRules[0][0][0]] = val;
            diction = Rules;

            // AugRule => [ [[nonterm] , ['.','terms'...]], [[nonterm] , ['.','terms'...]], ... ]
            //String addedR = AugRules[0][0][0] + "->" + String.Join(" ", AugRules[0][1]);
            //rules[0] = addedR;
            //foreach (var rul in rules ) {
            //    String[] k = Regex.Split(rul.Value,"->");
            //    k[0] = k[0].Trim();
            //    k[1] = k[1].Trim();
            //}
            //Console.Write(statesDict_copy);
            //Preprocessor p1 = new Preprocessor();
            //p1.Rules = AugRulesNoDot;
            //p1.Find_FollowSet();
            //Console.WriteLine(p1.FOLLOW_SET);
            foreach (var stateno in statesDict.Keys) {
                foreach (var rule in statesDict[stateno]) {
                    //Console.WriteLine("____---____: " + rule[1][rule[1].Count - 1][0]);
                    //Console.Write("EQUAL TEST: ");
                    //Console.WriteLine(rule[1][rule[1].Count - 1][0].ToString().Equals("."));
                    if (rule[1][rule[1].Count - 1][0].ToString().Equals(".")) {
                        List<List<String>> temprule2 = new List<List<string>>();
                        temprule2 = new List<List<string>>(rule);
                        temprule2[1].Remove(".");
                        foreach(var key in numbered_rules.Keys) {
                            //Console.WriteLine("Keys: "+key);
                            //Console.WriteLine(numbered_rules[key]);
                            //Console.WriteLine(String.Join("", temprule2[0]) + String.Join("",temprule2[1]));
                            //Console.WriteLine(String.Join(" ", numbered_rules[key][0]) + String.Join(" ", numbered_rules[key][1]));
                            String a1 = String.Join("", temprule2[0]) + String.Join("", temprule2[1]);
                            String a2 = String.Join("", numbered_rules[key][0]) + String.Join("", numbered_rules[key][1]);
                            if (a2.Equals(a1)) {
                                //List<String> follow_result = p1.Calc_FollowSet(rule[0][0], AugRulesNoDot);      // WATCH FOR ERRORS HERE (USE P1.FOLLOW_SET)
                                //Console.WriteLine("\nFOLOFLOLOFLOFLFO: ");
                                //Console.WriteLine(String.Join(" ", FOLLOW_SET["E"]));
                                //Console.WriteLine(rule[0][0]);
                                List<String> follow_result = FOLLOW_SET[rule[0][0]];
                                //Console.WriteLine("KEY: " + key + " StateNo I" + stateno + " Follow: " + String.Join(" ", follow_result));

                                foreach (var col in follow_result) {
                                    int index = cols.IndexOf(col);
                                    if(key == 0) {
                                        Table[stateno][index] = "Accept";
                                    } else {
                                        Table[stateno][index] = Table[stateno][index] + "R"+key;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            colss = cols;
            //Console.WriteLine("Parsing Table");
            //Console.WriteLine("I  "+String.Join("   ", cols));
            int count = 0;
            foreach (var x in Table) {
                //Console.WriteLine(count+": "+String.Join("   ",x));
                count++;
            }
            
            return Table;
        }
    }
}
