using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLR_parser {
    class ThreeAddrCode {
        private int tempCount = 0;

        public string GenerateCode(Node root) {
            StringBuilder sb = new StringBuilder();
            GenerateCode(root, sb);
            return sb.ToString();
        }

        private void GenerateCode(Node node, StringBuilder sb) {
            if (node.Left != null) {
                GenerateCode(node.Left, sb);
            }
            if (node.Right != null) {
                GenerateCode(node.Right, sb);
            }

            if (node.Value == "+") {
                string temp = GetTemp();
                sb.AppendLine($"{temp} = {node.Left.Value} + {node.Right.Value}");
                node.Value = temp;
            } else if (node.Value == "-") {
                string temp = GetTemp();
                sb.AppendLine($"{temp} = {node.Left.Value} - {node.Right.Value}");
                node.Value = temp;
            } else if (node.Value == "*") {
                string temp = GetTemp();
                sb.AppendLine($"{temp} = {node.Left.Value} * {node.Right.Value}");
                node.Value = temp;
            } else if (node.Value == "/") {
                string temp = GetTemp();
                sb.AppendLine($"{temp} = {node.Left.Value} / {node.Right.Value}");
                node.Value = temp;
            }
        }

        private string GetTemp() {
            return $"t{tempCount++}";
        }
    }
}

