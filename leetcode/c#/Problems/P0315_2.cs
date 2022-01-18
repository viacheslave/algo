namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-of-smaller-numbers-after-self
///    Submission: https://leetcode.com/submissions/detail/618428993/
/// </summary>
internal class P0315_2
{
  /// <summary>
  ///   Alternative
  /// </summary>
  public class Solution
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
