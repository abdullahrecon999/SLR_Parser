using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SLR_parser {
    class Preprocessor {

        public IDictionary<String, List<List<String>>> Rules = new Dictionary<String, List<List<String>>>();
        private Regex regex = new Regex(@"^[a-z.(),\[\]0-9$#*;+-/]$");
        private Regex regexNonTerm = new Regex(@"^[A-Z]$");
        public List<string> nonterminals = new List<string>();
        public List<string> terminals = new List<string>();
        public String Start_symbol;
        public IDictionary<String, List<String>> FIRST_SET = new Dictionary<String, List<String>>();
        public IDictionary<String, List<String>> FOLLOW_SET = new Dictionary<String, List<String>>();

        public Tuple<int, String> InitGrammar(string grammar) {

            List<string> g0 = grammar.Split('\n').ToList();
            List<string> g1 = new List<string>();
            Start_symbol = g0[0].ElementAt(0).ToString();
            nonterminals.Add(Start_symbol+"'");
            nonterminals.Add(Start_symbol);

            // Adding Augment Rule
            List<String> a1 = new List<string>();
            List<List<String>> b1 = new List<List<string>>();
            String newStart = Start_symbol.Replace("'","");
            a1.Add(newStart);
            b1.Add(a1);
            Rules[Start_symbol+"'"] = b1;

            // Making | an new rule
            foreach (String a in g0) {

                if (a.Contains(" | ")) {
                    g1.Add(Regex.Split(a, "\\|")[0].ToString());
                    //Console.WriteLine("g1 here: " + Regex.Split(a, "\\|")[0].ToString());

                    List<String> rules = Regex.Split(a, "\\|").ToList();

                    for (int i = 1; i < rules.Count; i++) {
                        g1.Add(Regex.Split(a, "\\|")[0][0].ToString() + " ->" + rules[i]);
                        //Console.WriteLine("g1 here2: " + Regex.Split(a, " | ")[0][0].ToString() + " ->" + rules[i]);
                    }
                } else {
                    g1.Add(a);
                }
            }

            foreach(var rul in g1) {
                String prod = Regex.Split(rul, "->")[1];
                String nonterm = Regex.Replace(Regex.Split(rul, "->")[0], @"\s+", "");

                if (Rules.ContainsKey(nonterm)) {
                    Rules[nonterm].Add(Regex.Replace(prod, @"\s+", "").ToCharArray().Select(c => c.ToString()).ToList());
                } else {
                    var val = new List<List<String>>();
                    List<String> pro = Regex.Replace(prod, @"\s+", "").ToCharArray().Select(c => c.ToString()).ToList();
                    val.Add(pro);
                    Rules.Add(nonterm, val);
                }
            }

            //foreach(var r in Rules) {
            //    Console.WriteLine("NT: "+r.Key);
            //    foreach(var t in r.Value) {
            //        foreach(var v in t) {
            //            Console.WriteLine(v);
            //        }
            //    }
            //    Console.WriteLine("-------------");
            //}

            foreach (String a in g1) {
                String nonterm = Regex.Split(Regex.Replace(a, @"\s+", ""), "->")[0];

                if (!regexNonTerm.Match(nonterm).Success) {
                    return new Tuple<int, String>(-1, "[-] Non Terminal must be Capitalized::AT:: " + nonterm);
                } else {
                    nonterminals.Add(nonterm);
                }

            }

            nonterminals = nonterminals.Distinct().ToList();

            foreach (String a in g1) {
                String term = Regex.Split(a, "->")[1];

                foreach (String b in term.Split(' ')) {
                    if (regexNonTerm.Match(b).Success) {
                        if (!nonterminals.Contains(b)) {
                            return new Tuple<int, String>(-1, "[-] Remove Useless Symbol::AT:: " + b);
                        }
                    } else {
                        if (regex.Match(b).Success)
                            terminals.Add(b);
                    }
                }

            }

            terminals = terminals.Distinct().ToList();
            return new Tuple<int, String>(0, "[+] Success");
        }
        
        
        public List<String> Calc_FirstSet(String s, IDictionary<String, List<List<String>>> prod) {

            // Prod => { A:[ ['a','b'], ['e','d'] ], B: ... }
            List<String> first_set = new List<String>();

            for(int i = 0; i < prod[s].Count; i++) {
                for(int j = 0; j < prod[s][i].Count; j++) {
                    String item = prod[s][i][j];

                    if(item == s) {
                        break;
                    }

                    else if (regexNonTerm.Match(item).Success) {
                        var f = Calc_FirstSet(item, prod);
                        if (!f.Contains("#")) {
                            foreach(var k in f) {
                                first_set.Add(k);
                            }
                            break;
                        } else {
                            if(j == (prod[s][i].Count - 1)) {
                                foreach (var k in f) {
                                    first_set.Add(k);
                                }
                            } else {
                                f.Remove("#");
                                foreach (var k in f) {
                                    first_set.Add(k);
                                }
                            }
                        }
                    } else {
                        first_set.Add(item);
                        break;
                    }
                }
            }

            return first_set.Distinct().ToList();
        }

        public List<String> Calc_FollowSet(String s, IDictionary<String, List<List<String>>> prod) {

            List<String> follow_set = new List<String>();

            if (s.Length == 0) {
                return new List<String>();
            }

            if (s == prod.Keys.ElementAt(0)) {
                follow_set.Add("$");
            }

            foreach (String i in prod.Keys.ToArray()) {
                for (int j = 0; j < prod[i].Count; j++) {
                    if (prod[i][j].Contains(s)) {
                        int idx = prod[i][j].IndexOf(s);

                        if (idx == (prod[i][j].Count - 1)){
                            if (prod[i][j][idx] == i) {
                                break;
                            } else {
                                var f = Calc_FollowSet(i, prod);
                                foreach (var x in f) {
                                    follow_set.Add(x);
                                }
                            }
                        } else {
                            while (idx != (prod[i][j].Count - 1)) {
                                idx = idx + 1;

                                if (!regexNonTerm.Match(prod[i][j][idx]).Success) {
                                    follow_set.Add(prod[i][j][idx]);
                                    break;
                                } else {
                                    var f = Calc_FirstSet(prod[i][j][idx], prod);

                                    if (!f.Contains("#")) {
                                        foreach (var x in f) {
                                            follow_set.Add(x);
                                        }
                                        break;
                                    } else if (f.Contains("#") && idx != (prod[i][j].Count - 1)) {
                                        f.Remove("#");
                                        foreach (var k in f) {
                                            follow_set.Add(k);
                                        }
                                    } else if (f.Contains("#") && idx == (prod[i][j].Count - 1)) {
                                        f.Remove("#");
                                        foreach (var k in f) {
                                            follow_set.Add(k);
                                        }

                                        f = Calc_FollowSet(i, prod);
                                        foreach (var k in f) {
                                            follow_set.Add(k);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return follow_set.Distinct().ToList();
        }

        public void Find_FirstSet() {
            Console.WriteLine("--------------FIRST SET----------------");
            foreach (var item in nonterminals) {
                FIRST_SET.Add(item, Calc_FirstSet(item, Rules));
                Console.Write(item + " : ");
                foreach (var val in Calc_FirstSet(item, Rules)) {
                    Console.Write("  " + val);
                }
                Console.WriteLine("\n------------------------------");
            }
        }
        public void Find_FollowSet() {
            Console.WriteLine("---------------FOLLOW SET---------------");
            foreach (var item in nonterminals) {
                FOLLOW_SET.Add(item, Calc_FollowSet(item, Rules));
                Console.WriteLine("FOLLOW "+String.Join("",FOLLOW_SET[item]));
                Console.Write(item + " : ");
                foreach (var val in Calc_FollowSet(item, Rules)) {
                    Console.Write("  " + val);
                }
                Console.WriteLine("\n------------------------------");
            }
        }
    }
}
