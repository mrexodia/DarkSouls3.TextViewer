using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSouls3.Structures
{
    public class Node<T>
    {
        public readonly T Value;
        public HashSet<Node<T>> Neighbors;

        public Node(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            return Value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }

    public class Graph<T>
    {
        private readonly HashSet<Node<T>> _nodes = new HashSet<Node<T>>();

        public void AddNode(Node<T> node)
        {
            _nodes.Add(node);
        }

        public void AddUndirectedEdge(Node<T> from, Node<T> to)
        {
            if (from == null || to == null)
                throw new ArgumentException();
            from.Neighbors.Add(to);
            to.Neighbors.Add(from);
        }

        public Node<T> FindNode(T value)
        {
            return _nodes.FirstOrDefault(n => n.Value.Equals(value));
        }

        public void RemoveNode(Node<T> node)
        {
            if (node == null)
                return;
            _nodes.Remove(node);
            foreach (var n in node.Neighbors)
                n.Neighbors.Remove(node);
        }

        public string ToDot()
        {
            var result = new StringBuilder();
            result.AppendLine("graph G {");
            result.AppendLine("    overlap = false;");
            result.AppendLine("    splines = true;");
            foreach (var node in _nodes)
                result.AppendFormat("    n{0} [label=\"{1}\"];\n", node.GetHashCode(), node);
            result.AppendLine();

            var connected = new HashSet<Tuple<Node<T>, Node<T>>>();
            foreach (var u in _nodes)
            {
                foreach (var v in u.Neighbors)
                {
                    var t1 = new Tuple<Node<T>, Node<T>>(u, v);
                    var t2 = new Tuple<Node<T>, Node<T>>(v, u);
                    if (connected.Contains(t1) || connected.Contains(t2))
                        continue;
                    connected.Add(t1);
                    connected.Add(t2);
                    result.AppendFormat("    n{0} -- n{1};\n", u.GetHashCode(), v.GetHashCode());
                }
            }

            result.AppendLine();
            result.AppendLine("}");
            return result.ToString();
        }
    }
}
