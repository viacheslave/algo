namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/map-sum-pairs/
///    Submission: https://leetcode.com/submissions/detail/239005464/
/// </summary>
internal class P0677
{
  public class MapSum
  {
    SortedDictionary<string, int> sd = new SortedDictionary<string, int>();

    /** Initialize your data structure here. */
    public MapSum()
    {
    }

    public void Insert(string key, int val)
    {
      sd[key] = val;
    }

    public int Sum(string prefix)
    {
      return sd.Where(_ => _.Key.StartsWith(prefix)).Sum(_ => _.Value);
    }
  }
}
