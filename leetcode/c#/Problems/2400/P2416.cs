namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sum-of-prefix-scores-of-strings/
///    Submission: https://leetcode.com/submissions/detail/803573522/
/// </summary>
internal class P2416
{
  public class Solution
  {
    public int[] SumPrefixScores(string[] words)
    {
      var trie = new Trie();

      foreach (var word in words)
      {
        trie.Add(word);
      }

      var ans = new int[words.Length];

      for (var i = 0; i < words.Length; i++)
      {
        var word = words[i];
        var count = 0;

        var node = trie.Root;
        foreach (var ch in word)
        {
          count += node.Nodes[ch].Score;
          node = node.Nodes[ch];
        }

        ans[i] = count;
      }

      return ans;
    }

    public class Trie
    {
      public class TrieNode
      {
        public int Value;
        public int Score;
        public Dictionary<char, TrieNode> Nodes { get; } = new Dictionary<char, TrieNode>();

        public TrieNode(int value)
        {
          Value = value;
        }

        public TrieNode Add(char value)
        {
          if (Nodes.ContainsKey(value))
          {
            Nodes[value].Score++;
            return Nodes[value];
          }

          var node = new TrieNode(value);
          node.Score++;
          Nodes[value] = node;

          return node;
        }
      }

      public TrieNode Root { get; } = new TrieNode(default);

      public void Add(IEnumerable<char> seq)
      {
        var current = Root;

        foreach (var element in seq)
        {
          current = current.Add(element);
        }
      }
    }
  }
}
