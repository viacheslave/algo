using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class FraudulentActivityNotifications
  {

    class Result
    {

      /*
       * Complete the 'activityNotifications' function below.
       *
       * The function is expected to return an INTEGER.
       * The function accepts following parameters:
       *  1. INTEGER_ARRAY expenditure
       *  2. INTEGER d
       */

      public static int activityNotifications(List<int> expenditure, int d)
      {
        var left = new SortedSet<Item>();
        var right = new SortedSet<Item>();

        var ans = 0;

        for (var i = 0; i < expenditure.Count; i++)
        {
          if (i == 0)
          {
            continue;
          }

          Append(expenditure, i - 1, left, right);

          if (i < d)
          {
            continue;
          }

          if (i > d)
          {
            Remove(expenditure, i - d - 1, left, right);
          }

          var median = GetMedian(left, right);
          if (expenditure[i] >= 2 * median)
          {
            Console.WriteLine($"{expenditure[i]} - {median * 2}");

            ans++;
          }
        }

        return ans;
      }

      private static void Remove(List<int> expenditure, int i, SortedSet<Item> left, SortedSet<Item> right)
      {
        var item = new Item(expenditure[i], i);

        if (!right.Remove(item))
          left.Remove(item);

        Rebalance(left, right);
      }

      private static void Append(List<int> expenditure, int i, SortedSet<Item> left, SortedSet<Item> right)
      {
        right.Add(new Item(expenditure[i], i));

        var first = right.Min;
        right.Remove(first);
        left.Add(first);

        Rebalance(left, right);
      }

      private static void Rebalance(SortedSet<Item> left, SortedSet<Item> right)
      {
        while (left.Count > right.Count)
        {
          var last = left.Max;
          left.Remove(last);
          right.Add(last);
        }

        while (left.Count + 1 < right.Count)
        {
          var first = right.Min;
          right.Remove(first);
          left.Add(first);
        }
      }

      private static double GetMedian(SortedSet<Item> left, SortedSet<Item> right)
      {
        if (left.Count == right.Count)
        {
          return (left.Max.value + right.Min.value) / 2.0;
        }

        return right.Min.value;
      }

      public class Item : IComparable<Item>
      {
        public int value;
        public int index;

        public Item(int value, int index)
        {
          this.value = value;
          this.index = index;
        }

        public int CompareTo(Item other)
        {
          if (other.value == value)
            return index.CompareTo(other.index);

          return value.CompareTo(other.value);
        }

        public override bool Equals(object obj)
        {
          var other = (Item)obj;
          return other.value == value && other.index == index;
        }

        public override int GetHashCode()
        {
          unchecked
          {
            var res = value * 31;
            res = res ^ index;
            return res;
          }
        }
      }

    }
    /*
    class Solution
    {
      public static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> expenditure = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(expenditureTemp => Convert.ToInt32(expenditureTemp)).ToList();

        int result = Result.activityNotifications(expenditure, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
