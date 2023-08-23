namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/operations-on-tree/
///    Submission: https://leetcode.com/submissions/detail/550025579/
/// </summary>
internal class P1993
{
  public class LockingTree
  {
    private readonly TreeNode[] _nodes;

    public LockingTree(int[] parent)
    {
      _nodes = new TreeNode[parent.Length];

      var children = new int[parent.Length];

      for (var i = 0; i < parent.Length; i++)
      {
        _nodes[i] = new TreeNode { Id = i, ParentId = parent[i] };
        if (parent[i] != -1)
          children[parent[i]] = 1;
      }

      for (var i = 0; i < children.Length; i++)
      {
        var id = i;
        var parentId = _nodes[id].ParentId;

        while (parentId != -1)
        {
          _nodes[id].AncestorIds.Add(parentId);
          _nodes[parentId].DescendantIds.Add(id);

          parentId = _nodes[parentId].ParentId;
        }
      }
    }

    public bool Lock(int num, int user)
    {
      if (_nodes[num].LockedBy == 0)
      {
        _nodes[num].LockedBy = user;
        return true;
      }

      return false;
    }

    public bool Unlock(int num, int user)
    {
      if (_nodes[num].LockedBy == user)
      {
        _nodes[num].LockedBy = 0;
        return true;
      }

      return false;
    }

    public bool Upgrade(int num, int user)
    {
      if (_nodes[num].LockedBy != 0)
        return false;

      var hasLocked = false;
      foreach (var id in _nodes[num].DescendantIds)
      {
        if (_nodes[id].LockedBy != 0)
        {
          hasLocked = true;
          break;
        }
      }

      if (!hasLocked)
        return false;

      foreach (var id in _nodes[num].AncestorIds)
        if (_nodes[id].LockedBy != 0)
          return false;

      _nodes[num].LockedBy = user;

      foreach (var id in _nodes[num].DescendantIds)
        _nodes[id].LockedBy = 0;

      return true;
    }

    public class TreeNode
    {
      public int Id;
      public int ParentId;
      public int LockedBy;
      public List<int> AncestorIds = new List<int>();
      public List<int> DescendantIds = new List<int>();
    }
  }
}
