using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3662/
  /// 
  /// </summary>
  internal class Mar06
  {
    public class Solution
    {
      public int MinimumLengthEncoding(string[] words)
      {
        var trie = new Trie<char>();

        foreach (var word in words)
          trie.Add(word.Reverse());

        var lengths = new List<int>();
        Traverse(lengths, trie.Root, 0);

        return lengths.Sum(l => l + 1);
      }

      private void Traverse(List<int> lengths, Trie<char>.TrieNode node, int depth)
      {
        if (node.IsEnd && node.Nodes.Count == 0)
        {
          lengths.Add(depth);
          return;
        }

        foreach (var n in node.Nodes)
          Traverse(lengths, n, depth + 1);
      }

      public class Trie<T>
      {
        public class TrieNode
        {
          public T Value { get; }

          public bool IsEnd { get; private set; }

          public ICollection<TrieNode> Nodes => _nodes.Values;

          private Dictionary<T, TrieNode> _nodes { get; } = new Dictionary<T, TrieNode>();

          public TrieNode(T value)
          {
            Value = value;
          }

          public bool SetEnd() => IsEnd = true;

          public TrieNode Add(T value)
          {
            if (_nodes.ContainsKey(value))
              return _nodes[value];

            var node = new TrieNode(value);
            _nodes[value] = node;

            return node;
          }
        }

        public TrieNode Root { get; } = new TrieNode(default);

        public void Add(IEnumerable<T> seq)
        {
          var current = Root;

          foreach (var element in seq)
            current = current.Add(element);

          current.SetEnd();
        }
      }
    }
  }
}
