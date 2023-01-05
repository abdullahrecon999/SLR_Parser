using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLR_parser
{
    class Rules
    {

        private static string rule;
        private static string semantics;

        public static string getRule()
        {
            rule = "" + "1) exp -> exp + term\n" +
                        "2) exp -> exp - term\n" +
                        "3) exp -> term\n" +
                        "4) term -> term * factor\n" +
                        "5) term -> factor\n" +
                        "6) factor -> ( exp )\n" +
                        "7) factor -> number";

            return rule;
        }

        public static string getSemantics()
        {
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
}
