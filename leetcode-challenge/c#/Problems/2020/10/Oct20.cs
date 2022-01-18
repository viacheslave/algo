using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3501/
  ///    https://leetcode.com/submissions/detail/411010601/?from=/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3501/
  /// </summary>
  internal class Oct20
  {
    // Definition for a Node. 
    public class Node {
        public int val;
        public IList<Node> neighbors;

        public Node(){}
        public Node(int _val,IList<Node> _neighbors) {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class Solution
    {
      public Node CloneGraph(Node node)
      {
        if (node == null)
          return null;

        var map = new Dictionary<Node, Node>();
        map[node] = new Node(node.val, new List<Node>());

        var queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
          var item = queue.Dequeue();

          foreach (var nb in item.neighbors)
          {
            if (!map.TryGetValue(nb, out var nbb))
            {
              nbb = new Node(nb.val, new List<Node>());
              map[nb] = nbb;
              queue.Enqueue(nb);
            }

            map[item].neighbors.Add(nbb);
          }
        }

        return map[node];
      }
    }
  }
}
