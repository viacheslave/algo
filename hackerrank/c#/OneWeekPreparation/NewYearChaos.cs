namespace HackerRank.NewYearChaos;

class Result
{

  /*
   * Complete the 'minimumBribes' function below.
   *
   * The function accepts INTEGER_ARRAY q as parameter.
   */

  public static void minimumBribes(List<int> q)
  {
    var arr = new int[q.Count];

    var ind = new int[q.Count];
    for (var i = 0; i < ind.Length; i++)
      ind[i] = i;

    Calculate(q, 0, q.Count - 1, arr, ind);

    for (var i = 0; i < arr.Length; i++)
    {
      if (arr[i] > 2)
      {
        Console.WriteLine("Too chaotic");
        return;
      }
    }

    var ans = arr.Sum();
    Console.WriteLine(ans);
  }

  private static void Calculate(List<int> q, int from, int to, int[] arr, int[] ind)
  {
    if (from == to)
      return;

    var mid = (from + to) >> 1;

    Calculate(q, from, mid, arr, ind);
    Calculate(q, mid + 1, to, arr, ind);

    // merge
    var ax = new int[to - from + 1];
    var i = from;
    var j = mid + 1;
    var k = 0;

    var itt = new int[to - from + 1];

    while (i <= mid && j <= to)
    {
      if (q[i] <= q[j])
      {
        ax[k] = q[i];
        itt[k] = ind[i];

        arr[ind[i]] += j - (mid + 1);

        i++; k++;
      }
      else
      {
        ax[k] = q[j];
        itt[k] = ind[j];

        j++; k++;
      }
    }

    while (i <= mid)
    {
      ax[k] = q[i];
      itt[k] = ind[i];

      arr[ind[i]] += (to - mid);

      i++; k++;
    }

    while (j <= to)
    {
      ax[k] = q[j];
      itt[k] = ind[j];

      j++; k++;
    }

    for (var a = 0; a < ax.Length; a++)
    {
      q[from + a] = ax[a];
      ind[from + a] = itt[a];
    }
  }
}
/*
class Solution
{
  public static void Main(string[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine().Trim());

    for (int tItr = 0; tItr < t; tItr++)
    {
      int n = Convert.ToInt32(Console.ReadLine().Trim());

      List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

      Result.minimumBribes(q);
    }
  }
}
*/
