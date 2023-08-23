namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-visible-people-in-a-queue/
///    Submission: https://leetcode.com/submissions/detail/527700516/
/// </summary>
internal class P1944
{
  public class Solution
  {
    public int[] CanSeePersonsCount(int[] heights)
    {
      var st = new Stack<int>();
      var ans = new int[heights.Length];

      for (var i = heights.Length - 1; i >= 0; i--)
      {
        var popCount = 0;

        while (st.Count > 0)
        {
          popCount++;

          var el = st.Pop();
          if (el > heights[i])
          {
            st.Push(el);
            break;
          }
        }

        st.Push(heights[i]);

        ans[i] = popCount;
      }

      return ans;
    }
  }
}
