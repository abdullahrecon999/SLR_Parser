using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLR_parser
{
    class SemanticAnalyzer
    {
        string parseTree;
        string rules;
        public SemanticAnalyzer(string parseTree, string rules)
        {
            this.parseTree = parseTree;
            this.rules = rules;
        }
    }
}
