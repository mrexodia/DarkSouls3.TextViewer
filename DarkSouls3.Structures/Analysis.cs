using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSouls3.Structures
{
    public class Analysis
    {
        private readonly Dictionary<string, int> _nodeSet = new Dictionary<string, int>();
        private readonly string[] _blacklist;

        public Analysis(string[] blacklist)
        {
            _blacklist = blacklist ?? new string[0];
        }

        public IEnumerable<string> SplitText(string text)
        {
            foreach (var s in text.Split(new char[] { ' ', ',', '.', ';', ':', '\'', '"', '-', '?', '!', '\n', '\r', '\u2026', '/' }))
            {
                if (s.Length <= 2 || s.Contains('+') || s.Count(char.IsDigit) != 0 || _blacklist.Contains(s))
                    continue;
                yield return s;
            }
        }

        public void AddText(string text)
        {
            foreach (var s in SplitText(text))
            {
                var count = _nodeSet.ContainsKey(s) ? _nodeSet[s] : 0;
                _nodeSet[s] = count + 1;
            }
        }

        private readonly List<string> _nodeList = new List<string>();
        private readonly Dictionary<string, int> _nodeIndex = new Dictionary<string, int>();
        private int[,] _edges;

        public void Prepare()
        {
            foreach (var n in _nodeSet)
                _nodeList.Add(n.Key);
            _nodeSet.Clear();
            for (var i = 0; i < _nodeList.Count; i++)
                _nodeIndex[_nodeList[i]] = i;
            _edges = new int[_nodeList.Count, _nodeList.Count];
        }

        public void ConnectText(string text)
        {
            var split = SplitText(text).ToList();
            for (var i = 0; i < split.Count; i++)
                for (var j = i + 1; j < split.Count; j++)
                {
                    var idxi = _nodeIndex[split[i]];
                    var idxj = _nodeIndex[split[j]];
                    _edges[idxi, idxj]++;
                    _edges[idxj, idxi]++;
                }
        }

        public string ToDot()
        {
            var result = new StringBuilder();
            result.AppendLine("graph G {");
            foreach (var node in _nodeList)
                result.AppendFormat("    {0}\n", node);
            result.AppendLine();

            var w = _edges.GetLength(0);
            var nedges = new bool[w, w];
            for (var i = 0; i < w; i++)
                for (var j = 0; j < w; j++)
                    nedges[i, j] = _edges[i, j] > 0;
            for (var i = 0; i < w; i++)
                for (var j = 0; j < w; j++)
                    if (nedges[i, j] && i != j)
                    {
                        nedges[j, i] = false;
                        nedges[i, j] = false;
                        result.AppendFormat("    {0} -- {1} [weight={2}];\n", _nodeList[i], _nodeList[j], _edges[i, j]);
                    }

            result.AppendLine();
            result.AppendLine("}");
            return result.ToString();
        }
    }
}
