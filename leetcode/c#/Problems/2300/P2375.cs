namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/construct-smallest-number-from-di-string/
///    Submission: https://leetcode.com/submissions/detail/773454476/
/// </summary>
internal class P2375
{
  public class Solution
  {
    public string SmallestNumber(string pattern)
    {
      var mask = new int[pattern.Length + 1];
      var buffer = new int[pattern.Length + 1];

      // recursive

      var ans = Build(pattern, 0, pattern.Length + 1, mask, buffer);
      return ans;
    }

    private string Build(string pattern, int index, int length, int[] mask, int[] buffer)
    {
      if (index == length)
      {
        return string.Join("", buffer);
      }

      for (int i = 0; i < length; i++)
      {
        if (mask[i] == 1)
          continue;

        if (index > 0)
        {
          if (buffer[index - 1] > i + 1 && pattern[index - 1] == 'I')
            continue;
          if (buffer[index - 1] < i + 1 && pattern[index - 1] == 'D')
            continue;
        }

        mask[i] = 1;

        buffer[index] = i + 1;

        var r = Build(pattern, index + 1, length, mask, buffer);
        if (r != null)
          return r;

        mask[i] = 0;
      }

      return null;
    }
  }

}
