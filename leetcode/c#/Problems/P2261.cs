namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/k-divisible-elements-subarrays/
///    Submission: https://leetcode.com/submissions/detail/691758019/
/// </summary>
internal class P2261
{
  public class Solution
  {
    public int CountDistinct(int[] nums, int k, int p)
    {
      var set = new HashSet<Arr>();

      for (var i = 0; i < nums.Length; i++)
      {
        var a = new List<int>();

        for (var c = i; c < nums.Length; c++)
        {
          a.Add(nums[c]);

          set.Add(new Arr { arr = a.ToArray() });
        }
      }

      var ans = 0;

      foreach (var s in set)
      {
        var els = 0;

        foreach (var e in s.arr)
        {
          if (e % p == 0)
            els++;
        }

        if (els <= k)
          ans++;
      }

      return ans;
    }

    private class Arr
    {
      public int[] arr;

      public override int GetHashCode()
      {
        unchecked
        {
          var hash = 17;

          foreach (var item in arr)
          {
            hash = hash * 23 + item;
          }

          return hash;
        }
      }

      public override bool Equals(object obj)
      {
        var other = obj as Arr;

        if (this.arr.Length != other.arr.Length)
          return false;

        for (var i = 0; i < this.arr.Length; i++)
          if (this.arr[i] != other.arr[i])
            return false;

        return true;
      }
    }
  }
}
