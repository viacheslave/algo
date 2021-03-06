namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-xor-with-an-element-from-array/
///    Submission: https://leetcode.com/submissions/detail/435192717/
/// </summary>
internal class P1707
{
  public class Solution
  {
    public int[] MaximizeXor(int[] nums, int[][] queries)
    {
      var ans = new int[queries.Length];

      // sort both nums and queries
      Array.Sort(nums);

      var qs = queries
        .Select((q, i) => (i: i, x: q[0], m: q[1]))
        .OrderBy(_ => _.m)
        .ToList();

      var mbl = Convert.ToString(Math.Max(nums.Max(), queries.Max(x => x[0])), 2).Length;
      var trie = new Trie();
      var numIndex = -1;

      for (var j = 0; j < qs.Count; j++)
      {
        var query = qs[j];
        var x = query.x;
        var m = query.m;

        // add to trie all nums that are less than m
        while (numIndex + 1 < nums.Length && nums[numIndex + 1] <= m)
        {
          ++numIndex;

          var n = nums[numIndex];
          var ch = new int[mbl];

          for (var i = 0; i < mbl; i++)
          {
            ch[mbl - 1 - i] = n % 2;
            n >>= 1;
          }

          trie.Add(ch);
        }

        var xch = new int[mbl];

        for (var i = 0; i < mbl; i++)
        {
          xch[mbl - 1 - i] = x % 2;
          x >>= 1;
        }

        var xor = 0;
        var xnum = 0;

        var node = trie.Root;
        var incomplete = false;

        // go down the trie to find the xor == 1 if possible
        for (var i = 0; i < mbl; i++)
        {
          Trie.TrieNode next = null;

          foreach (var child in node.Nodes)
          {
            var bit = xch[i] ^ child.Key;
            var power = child.Key == 1 ? (1 << (mbl - 1 - i)) : 0;

            if (bit == 1)
            {
              if (xnum + power <= m)
              {
                next = child.Value;
                xnum += power;
                xor += (1 << (mbl - 1 - i));
              }
            }
            else if (next == null)
            {
              next = child.Value;
            }
          }

          if (next != null)
            node = next;
          else
            incomplete = true;
        }

        ans[query.i] = incomplete ? -1 : xor;
      }

      return ans;
    }

    public class Trie
    {
      public class TrieNode
      {
        public int Value { get; }

        public bool IsEnd { get; private set; }

        public SortedDictionary<int, TrieNode> Nodes => _nodes;

        private SortedDictionary<int, TrieNode> _nodes { get; } = new SortedDictionary<int, TrieNode>();

        public TrieNode(int value)
        {
          Value = value;
        }

        public bool SetEnd() => IsEnd = true;

        public TrieNode Add(int value)
        {
          if (_nodes.ContainsKey(value))
            return _nodes[value];

          var node = new TrieNode(value);
          _nodes[value] = node;

          return node;
        }
      }

      public TrieNode Root { get; } = new TrieNode(default);

      public void Add(IEnumerable<int> seq)
      {
        var current = Root;

        foreach (var element in seq)
          current = current.Add(element);

        current.SetEnd();
      }
    }
  }
}
