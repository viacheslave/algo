namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/570/week-2-december-8th-december-14th/3562/
  ///    https://leetcode.com/submissions/detail/429502622/?from=explore&item_id=3562
  /// </summary>
  internal class Dec11
  {
    public class Solution
    {
      public int RemoveDuplicates(int[] nums)
      {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return 1;

        var start = 0;
        var end = 0;

        var count = nums.Length;

        for (int i = 1; i < count; i++)
        {
          if (i >= count)
            break;

          var cur = nums[i];
          var prev = nums[i - 1];

          if (cur == prev)
          {
            end = i;
            continue;
          }

          var length = end - start + 1;
          if (length <= 2)
          {
            start = i;
            end = i;
            continue;
          }

          var shiftLeft = start + 2;
          var steps = end - shiftLeft + 1;

          for (int j = shiftLeft; j < nums.Length - steps; j++)
            nums[j] = nums[j + steps];

          count -= end - (start + 1);

          start += 2;
          end = start;
          i = start;
        }

        // final
        if (end - start + 1 > 2)
          count -= end - (start + 1);

        return count;
      }
    }
  }
}
