namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/duplicate-zeros/
///    Submission: https://leetcode.com/contest/weekly-contest-141/submissions/detail/236207067/
/// </summary>
internal class P1089
{
  public class Solution
  {
    public void DuplicateZeros(int[] arr)
    {
      var i = 0;

      while (i < arr.Length - 1)
      {
        if (arr[i] == 0)
        {
          Shift(arr, i);
          arr[i + 1] = 0;
          i += 2;
        }
        else
          i++;
      }
    }

    public void Shift(int[] arr, int index)
    {
      var current = arr.Length - 1;

      while (current >= index + 1)
      {
        arr[current] = arr[current - 1];
        current--;

      }
    }
  }
}
