namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/the-number-of-the-smallest-unoccupied-chair/
///    Submission: https://leetcode.com/submissions/detail/527648951/
/// </summary>
internal class P1942
{
  public class Solution
  {
    public int SmallestChair(int[][] times, int targetFriend)
    {
      var chairs = new ChairManager();
      var takenChairs = new Dictionary<int, int>(); // visitor -> chair

      var data = new SortedDictionary<int, (List<int> outgoing, List<int> incoming)>();

      for (var i = 0; i < times.Length; i++)
      {
        if (!data.ContainsKey(times[i][0])) data.Add(times[i][0], (new List<int>(), new List<int>()));
        if (!data.ContainsKey(times[i][1])) data.Add(times[i][1], (new List<int>(), new List<int>()));

        data[times[i][0]].incoming.Add(i);
        data[times[i][1]].outgoing.Add(i);
      }

      foreach (var item in data)
      {
        foreach (var o in item.Value.outgoing)
        {
          var chair = takenChairs[o];
          chairs.Return(chair);
        }

        foreach (var i in item.Value.incoming)
        {
          var chair = chairs.Take();
          takenChairs[i] = chair;

          if (i == targetFriend)
            return chair;
        }
      }

      return -1;
    }

    class ChairManager
    {
      private int _nextChair;
      private readonly SortedSet<int> _empty = new SortedSet<int>();

      public int Take()
      {
        if (_empty.Count == 0)
        {
          var result = _nextChair;
          _nextChair++;
          return result;
        }

        var chair = _empty.Min;
        _empty.Remove(chair);

        return chair;
      }

      public void Return(int chair)
      {
        _empty.Add(chair);
      }
    }
  }
}
