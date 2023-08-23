namespace LeetCode.Naive.Problems;

internal class P0315
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-of-smaller-numbers-after-self/
  ///    Submission: https://leetcode.com/submissions/detail/243879621/
  /// </summary>
  public class Solution
  {
    public IList<int> CountSmaller(int[] nums)
    {
      if (nums.Length == 0)
        return new List<int>();

      var ans = new List<int>() { 0 };
      var root = new No(nums[nums.Length - 1], 1);

      for (int i = nums.Length - 2; i >= 0; i--)
      {
        CheckWith(root, null, nums[i], ans, 0, 0);
      }

      ans.Reverse();
      return ans;
    }

    private void CheckWith(No node, No parent, int value, List<int> ans, int side, int count)
    {
      if (node == null)
      {
        ans.Add(count);

        if (parent != null)
        {
          if (side == 0)
            parent.left = new No(value, 1);
          else
            parent.right = new No(value, 1);
        }

        return;
      }

      if (node.val.Item1 == value)
      {
        ans.Add(count + (node.left != null ? node.left.val.Item2 : 0));
        node.val = (node.val.Item1, node.val.Item2 + 1);
        return;
      }

      if (value < node.val.Item1)
        CheckWith(node.left, node, value, ans, 0, count);

      if (value > node.val.Item1)
        CheckWith(node.right, node, value, ans, 1, count + node.val.Item2 - (node.right != null ? node.right.val.Item2 : 0));

      node.val = (node.val.Item1, node.val.Item2 + 1);
    }

    public class No
    {
      public (int, int) val;
      public No left;
      public No right;
      public No(int x, int count) { val = (x, count); }
    }
  }

  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-of-smaller-numbers-after-self
  ///    Submission: https://leetcode.com/submissions/detail/618428993/
  /// </summary>
  public class Solution2
  {
    public IList<int> CountSmaller(int[] nums)
    {
      var arr = new int[nums.Length];

      var ind = new int[nums.Length];
      for (var i = 0; i < ind.Length; i++)
        ind[i] = i;

      Calculate(nums, 0, nums.Length - 1, arr, ind);

      return arr;
    }

    private static void Calculate(int[] q, int from, int to, int[] arr, int[] ind)
    {
      if (from == to)
        return;

      var mid = (from + to) >> 1;

      Calculate(q, from, mid, arr, ind);
      Calculate(q, mid + 1, to, arr, ind);

      // merge
      var ax = new int[to - from + 1];
      var i = from;
      var j = mid + 1;
      var k = 0;

      var itt = new int[to - from + 1];

      while (i <= mid && j <= to)
      {
        if (q[i] <= q[j])
        {
          ax[k] = q[i];
          itt[k] = ind[i];

          arr[ind[i]] += j - (mid + 1);

          i++; k++;
        }
        else
        {
          ax[k] = q[j];
          itt[k] = ind[j];

          j++; k++;
        }
      }

      while (i <= mid)
      {
        ax[k] = q[i];
        itt[k] = ind[i];

        arr[ind[i]] += (to - mid);

        i++; k++;
      }

      while (j <= to)
      {
        ax[k] = q[j];
        itt[k] = ind[j];

        j++; k++;
      }

      for (var a = 0; a < ax.Length; a++)
      {
        q[from + a] = ax[a];
        ind[from + a] = itt[a];
      }
    }
  }
}
