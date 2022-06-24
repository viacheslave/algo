namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/construct-target-array-with-multiple-sums/
///    Submission: https://leetcode.com/submissions/detail/729909937/
/// </summary>
internal class P1354
{
  public class Solution
  {
    public bool IsPossible(int[] target)
    {
      // try reduce the target array to 1's
      // max-heap

      long sum = target.Sum(x => (long)x);

      var items = target.Select((t, i) => (new Item(t, i), new Item(t, i)));
      var pq = new PriorityQueue<Item, Item>(items);

      while (true)
      {
        // if max element is 1 - all are 1's

        if (pq.Peek().value == 1)
        {
          return true;
        }

        var item = pq.Dequeue();

        // reduce max element

        var prevSum = item.value;

        var sumExceptThis = sum - item.value;
        var el = prevSum - sumExceptThis;

        if (el < 1)
        {
          return false;
        }

        // shortcut
        // we can reduce greatest element by small portions
        // so, try reduce many times at once

        if (pq.Count > 0)
        {
          var diff = item.value - el;
          var secondGreatest = pq.Peek().value;

          if (secondGreatest <= el)
          {
            el = secondGreatest + ((item.value - secondGreatest) % diff);
          }
        }

        // if we couldn't reduce the element
        // return immediately

        if (el == item.value)
        {
          return false;
        }

        sum -= item.value - el;
        pq.Enqueue(new Item(el, item.index), new Item(el, item.index));
      }
    }

    private record Item(long value, int index) : IComparable<Item>
    {
      public int CompareTo(Item other) => other.value.CompareTo(this.value);
    }
  }
}
