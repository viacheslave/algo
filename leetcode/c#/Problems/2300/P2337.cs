namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/move-pieces-to-obtain-a-string/
///    Submission: https://leetcode.com/submissions/detail/743519459/
/// </summary>
internal class P2337
{
  public class Solution
  {
    public bool CanChange(string start, string target)
    {
      // check the order without underscores
      // if order is ok - check impossible cases where L is to the right or R is to the left

      var dryStart = start.Select((ch, i) => (ch, i)).Where(x => x.ch != '_').ToArray();
      var dryTarget = target.Select((ch, i) => (ch, i)).Where(x => x.ch != '_').ToArray();

      if (dryTarget.Length != dryStart.Length)
        return false;

      var len = dryStart.Length;

      for (int i = 0; i < len; i++)
      {
        if (dryStart[i].ch != dryTarget[i].ch)
          return false;
      }

      for (int i = 0; i < len; i++)
      {
        var ch = dryStart[i].ch;

        if (ch == 'L' && dryStart[i].i < dryTarget[i].i)
          return false;

        if (ch == 'R' && dryStart[i].i > dryTarget[i].i)
          return false;
      }

      return true;
    }
  }
}
