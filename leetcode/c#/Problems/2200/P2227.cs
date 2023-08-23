namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/encrypt-and-decrypt-strings/
///    Submission: https://leetcode.com/submissions/detail/677748002/
/// </summary>
internal class P2227
{
  public class Encrypter
  {
    private Dictionary<char, string> _map;
    private Dictionary<string, List<char>> _mapBack = new Dictionary<string, List<char>>();
    private Trie<char> _trie;

    public Encrypter(char[] keys, string[] values, string[] dictionary)
    {
      _map = Enumerable.Range(0, keys.Length)
        .Select(i => (keys[i], values[i]))
        .ToDictionary(x => x.Item1, x => x.Item2);

      for (var i = 0; i < values.Length; i++)
      {
        if (!_mapBack.ContainsKey(values[i]))
          _mapBack[values[i]] = new List<char>();

        _mapBack[values[i]].Add(keys[i]);
      }

      _trie = new Trie<char>();

      foreach (var d in dictionary)
        _trie.Add(d);
    }

    public string Encrypt(string word1)
    {
      var sb = new StringBuilder(word1.Length * 2);
      foreach (var ch in word1)
      {
        sb.Append(_map[ch]);
      }

      return sb.ToString();
    }

    public int Decrypt(string word2)
    {
      return Decrypt(word2, 0, _trie.Root);
    }

    public int Decrypt(string word, int index, Trie<char>.TrieNode node)
    {
      if (index == word.Length)
        return node.IsEnd ? 1 : 0;

      var sub = word.Substring(index, 2);
      if (!_mapBack.ContainsKey(sub))
        return 0;

      var keys = _mapBack[sub];
      var ans = 0;

      foreach (var key in keys)
      {
        node.Nodes.TryGetValue(key, out var child);
        if (child is null)
          continue;

        ans += Decrypt(word, index + 2, child);
      }

      return ans;
    }

    public class Trie<T>
    {
      public class TrieNode
      {
        public T Value { get; }

        public bool IsEnd { get; private set; }

        public Dictionary<T, TrieNode> Nodes { get; } = new Dictionary<T, TrieNode>();

        public TrieNode(T value)
        {
          Value = value;
        }

        public bool SetEnd() => IsEnd = true;

        public TrieNode Add(T value)
        {
          if (Nodes.ContainsKey(value))
            return Nodes[value];

          var node = new TrieNode(value);
          Nodes[value] = node;

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

  /**
   * Your Encrypter object will be instantiated and called as such:
   * Encrypter obj = new Encrypter(keys, values, dictionary);
   * string param_1 = obj.Encrypt(word1);
   * int param_2 = obj.Decrypt(word2);
   */

}
