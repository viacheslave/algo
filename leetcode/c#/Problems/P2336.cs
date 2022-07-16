namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/smallest-number-in-infinite-set/
///    Submission: https://leetcode.com/submissions/detail/743538733/
/// </summary>
internal class P2336
{
  public class SmallestInfiniteSet
  {
    private readonly SortedSet<int> _set = new SortedSet<int>(Enumerable.Range(1, 1000).ToArray());

    public SmallestInfiniteSet()
    {
    }

    public int PopSmallest()
    {
      var sm = _set.Min;
      _set.Remove(sm);

      return sm;
    }

    public void AddBack(int num)
    {
      _set.Add(num);
    }
  }

}
