namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/total-cost-to-hire-k-workers/
///    Submission: https://leetcode.com/problems/total-cost-to-hire-k-workers/submissions/838190711/
/// </summary>
internal class P2462
{
  public class Solution
  {
    public long TotalCost(int[] costs, int k, int candidates)
    {
      int i = 0, j = costs.Length - 1;

      var pqLeft = new PriorityQueue<Cost, Cost>();
      var pqRight = new PriorityQueue<Cost, Cost>();

      for (int index = 0; index < candidates; index++)
      {
        if (j - i < 0)
          break;

        if (j - i >= 0)
        {
          pqLeft.Enqueue(new Cost(costs[i], i), new Cost(costs[i], i));
          i++;
        }

        if (j - i >= 0)
        {
          pqRight.Enqueue(new Cost(costs[j], j), new Cost(costs[j], j));
          j--;
        }
      }

      var ans = 0L;

      for (int index = 0; index < k; index++)
      {
        pqLeft.TryPeek(out var leftEl, out var leftIndex);
        pqRight.TryPeek(out var rightEl, out var rightIndex);

        if (leftEl is null && rightEl is null)
        {
          break;
        }

        var takeLeft = rightEl is null || leftEl?.CompareTo(rightEl) < 0;

        if (takeLeft)
        {
          ans += leftEl.cost;
          pqLeft.Dequeue();

          if (j - i >= 0)
          {
            pqLeft.Enqueue(new Cost(costs[i], i), new Cost(costs[i], i));
            i++;
          }
        }
        else
        {
          ans += rightEl.cost;
          pqRight.Dequeue();

          if (j - i >= 0)
          {
            pqRight.Enqueue(new Cost(costs[j], j), new Cost(costs[j], j));
            j--;
          }
        }
      }

      return ans;
    }

    private record Cost(int cost, int index) : IComparable<Cost>
    {
      public int CompareTo(Cost other)
      {
        if (this.cost == other.cost)
          return this.index.CompareTo(other.index);

        return this.cost.CompareTo(other.cost);
      }
    }
  }

}
