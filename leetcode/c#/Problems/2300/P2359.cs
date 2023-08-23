namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-closest-node-to-given-two-nodes/
///    Submission: https://leetcode.com/submissions/detail/761626867/
/// </summary>
internal class P2359
{
  public class Solution
  {
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
      var dist1 = GetDistance(edges, node1);
      var dist2 = GetDistance(edges, node2);

      var ans = -1;
      var dist = int.MaxValue;

      foreach (var item in dist1)
      {
        if (dist2.ContainsKey(item.Key))
        {
          var max = Math.Max(item.Value, dist2[item.Key]);
          if (dist >= max)
          {
            ans = (dist == max) ? Math.Min(item.Key, ans) : item.Key;
            dist = max;
          }
        }
      }

      return ans;
    }

    private Dictionary<int, int> GetDistance(int[] edges, int node)
    {
      var res = new Dictionary<int, int>();

      var current = node;
      var index = 0;
      while (current != -1)
      {
        if (res.ContainsKey(current))
          return res;

        res[current] = index++;
        current = edges[current];
      }

      return res;
    }
  }
}
