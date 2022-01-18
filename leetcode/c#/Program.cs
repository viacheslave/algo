public class Solution
{
  public int MinJumps(int[] arr)
  {
    if (arr.Length == 1)
      return 0;

    var map = arr.Select((el, index) => (el, index))
      .GroupBy(x => x.el)
      .ToDictionary(x => x.Key, x => x.Select(a => a.index).OrderByDescending(a => a).ToList());

    // bfs
    var queue = new Queue<(int index, int steps)>();
    var visited = new HashSet<int>();

    queue.Enqueue((0, 0));
    visited.Add(0);

    while (queue.Count > 0)
    {
      var el = queue.Dequeue();

      if (el.index == arr.Length - 1)
        return el.steps;

      var indexes = new List<int>() { };
      indexes.AddRange(map[arr[el.index]]);

      if (indexes[0] < el.index + 1)
        indexes.Insert(0, el.index + 1);
      else
        indexes.Add(el.index + 1);

      indexes.AddRange(new[] { el.index - 1 });

      foreach (var n in indexes)
      {
        if (visited.Contains(n))
          continue;

        if (n < 0 || n == arr.Length)
          continue;

        queue.Enqueue((n, el.steps + 1));
        visited.Add(n);
      }
    }

    return -1;
  }

  public static void Main(string[] args)
  {
    new Solution().MinJumps(new[] { 7, 7, 7, 7, 11 });
  }
}
