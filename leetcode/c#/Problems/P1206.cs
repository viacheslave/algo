namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/design-skiplist/
///    Submission: https://leetcode.com/submissions/detail/419145205/
/// </summary>
internal class P1206
{
  public class Skiplist
  {
    internal class Node
    {
      public int Key { get; }
      public Node[] ForwardNodes { get; }

      public Node(int key, int level)
      {
        Key = key;
        ForwardNodes = new Node[level + 1];
      }
    }

    private readonly int _maxLevel = 4;
    private readonly double _p = 0.5;
    private int _level;
    private Node _head;
    private readonly Random _rnd = new Random((int)DateTime.Now.Millisecond);

    private int GetRandomLevel()
    {
      var level = 0;
      var rnd = _rnd.NextDouble();

      while (rnd < _p && level < _maxLevel)
      {
        level++;
        rnd = _rnd.NextDouble();
      }

      return level;
    }

    public Skiplist()
    {
      _level = 0;
      _head = new Node(-1, _maxLevel);
    }

    public bool Search(int target)
    {
      (Node current, Node[] updateNodes) = GetUpdateNodes(target);
      return current != null && current.Key == target;
    }

    public void Add(int num)
    {
      (_, Node[] updateNodes) = GetUpdateNodes(num);

      var randomLevel = GetRandomLevel();
      if (randomLevel > _level)
      {
        for (var i = _level + 1; i < randomLevel + 1; i++)
          updateNodes[i] = _head;

        _level = randomLevel;
      }

      var node = new Node(num, randomLevel);

      for (int i = 0; i <= randomLevel; i++)
      {
        node.ForwardNodes[i] = updateNodes[i].ForwardNodes[i];
        updateNodes[i].ForwardNodes[i] = node;
      }
    }

    public bool Erase(int num)
    {
      (Node current, Node[] updateNodes) = GetUpdateNodes(num);

      if (current != null && current.Key == num)
      {
        for (int i = 0; i <= _level; i++)
        {
          if (updateNodes[i].ForwardNodes[i] != current)
            break;

          updateNodes[i].ForwardNodes[i] = current.ForwardNodes[i];
        }

        while (_level > 0 && _head.ForwardNodes[_level] == null)
          _level--;

        return true;
      }

      return false;
    }

    private (Node current, Node[] updateNodes) GetUpdateNodes(int key)
    {
      var current = _head;
      var updateNodes = new Node[_maxLevel + 1];

      for (int i = _level; i >= 0; i--)
      {
        while (current.ForwardNodes[i] != null && current.ForwardNodes[i].Key < key)
          current = current.ForwardNodes[i];

        updateNodes[i] = current;
      }

      return (current.ForwardNodes[0], updateNodes);
    }
  }
}
