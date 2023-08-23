namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-sum-of-squared-difference/
///    Submission: https://leetcode.com/problems/minimum-sum-of-squared-difference/submissions/837445779/
/// </summary>
internal class P2333
{
  public class Solution
  {
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
    {
      var length = nums1.Length;

      var arr = Enumerable
        .Range(0, length)
        .Select(i => Math.Abs(1L * nums1[i] - 1L * nums2[i]))
        .OrderByDescending(i => i)
        .ToArray();

      // k1 and k2 do not matter
      // care about their sum
      long reduce = k1 + k2;

      // build a map that shows width of the same diffs
      var steps = new Dictionary<long, int>();

      for (int i = 0; i < length; i++)
      {
        if (i == length - 1)
        {
          steps[arr[^1]] = length - 1;
          continue;
        }

        if (arr[i] != arr[i + 1])
        {
          steps[arr[i]] = i;
        }
      }

      // greedy
      // reduce one diff at a time

      var stepsOrdered = steps.OrderBy(s => s.Value).ToArray();

      for (var i = 0; i < stepsOrdered.Length; i++)
      {
        if (reduce == 0)
          break;

        long width = stepsOrdered[i].Value + 1;

        long height = i == stepsOrdered.Length - 1
          ? stepsOrdered[i].Key
          : stepsOrdered[i].Key - stepsOrdered[i + 1].Key;

        if (reduce >= width * height)
        {
          for (var j = 0; j < width; j++)
            arr[j] -= height;

          reduce -= width * height;
          continue;
        }

        var div = reduce / width;
        var mod = reduce % width;

        if (div > 0)
        {
          for (var j = 0; j < width; j++)
            arr[j] -= div;

          reduce -= width * div;
        }

        for (var j = 0; j < mod; j++)
        {
          reduce--;
          arr[j]--;
        }
      }

      var ans = arr.Sum(a => a * a);
      return ans;
    }
  }
}
