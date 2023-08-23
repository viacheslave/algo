namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-good-triplets-in-an-array/
///    Submission: https://leetcode.com/submissions/detail/644641281/
/// </summary>
internal class P2179
{
  public class Solution
  {
    public long GoodTriplets(int[] nums1, int[] nums2)
    {
      var original = new Dictionary<int, int>();
      for (int i = 0; i < nums1.Length; i++)
      {
        original[nums1[i]] = i;
      }

      // modified arr is an array of indices
      // that are misplaced against the original

      var modified = new int[nums1.Length];
      for (var i = 0; i < nums2.Length; i++)
      {
        modified[i] = original[nums2[i]];
      }

      var ans = 0L;
      var sl = new SortedList<int, int>();

      var n = nums1.Length;

      // greedily go over modified
      // check how many indices are less to the left
      // and greater to the right

      foreach (var index in modified)
      {
        sl.Add(index, index);

        var count = sl.Count;

        var ind = sl.IndexOfKey(index);

        var less = ind;
        var more = count - less - 1;

        var left = less;
        var right = n - index - more - 1;

        if (left == 0 || right == 0)
          continue;

        ans += (long)left * right;
      }

      return ans;
    }
  }

}
