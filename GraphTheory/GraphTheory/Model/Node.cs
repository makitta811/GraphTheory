using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.Model
{
    public class Node
    {
        public string Name { get; set; }
        public List<Edge> Edges { get; private set; } = new List<Edge>();

        public static HashSet<Node> Nodes = new HashSet<Node>();

        public static Node Parse(string input)
        {
            var node = new Node()
            {
                Name = input,
            };

            Nodes.Add(node);
            return node;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Node node)
            {
                return node.Name == this.Name;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
