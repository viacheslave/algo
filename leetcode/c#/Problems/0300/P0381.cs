namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/insert-delete-getrandom-o1-duplicates-allowed/
///    Submission: https://leetcode.com/problems/insert-delete-getrandom-o1-duplicates-allowed/submissions/863260036/
/// </summary>
internal class P0381
{
  public class RandomizedCollection
  {
    private readonly SortedList<string, int> _set = new();
    private readonly Dictionary<int, int> _buckets = new();

    private readonly Random _random = new((int)DateTime.Now.Ticks);

    public RandomizedCollection()
    {
    }

    public bool Insert(int val)
    {
      var count = _buckets.GetValueOrDefault(val);

      var key = $"{val}-{(count + 1)}";

      _set[key] = val;

      _buckets.TryAdd(val, 0);
      _buckets[val]++;

      return _buckets[val] <= 1;
    }

    public bool Remove(int val)
    {
      var count = _buckets.GetValueOrDefault(val);
      if (count == 0)
        return false;

      var key = $"{val}-{count}";

      _buckets[val]--;
      _set.Remove(key);

      return true;
    }

    public int GetRandom()
    {
      var key = _set.Keys[_random.Next(_set.Count)];
      return _set[key];
    }
  }
}
