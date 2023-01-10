using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.Model
{
    public class Edge
    {
        public static HashSet<Edge> Edges= new HashSet<Edge>();
        public Node Node1 { get; set; }
        public Node Node2 { get; set; }
        public int Distance { get; set; }

        public static Edge Parse(string input)
        {
            var parts = input.Split(' ');
            var node1 = Node.Parse(parts[0]);
            var node2 = Node.Parse(parts[1]);

            var edge = new Edge
            {
                Node1 = node1,
                Node2 = node2,
                Distance = int.Parse(parts[2])
            };

            node1.Edges.Add(edge);
            Edges.Add(edge);

            return edge;
        }

        public override string ToString()
        {
            return $"{Node1} - {Node2} => {Distance}";
        }
    }
}
