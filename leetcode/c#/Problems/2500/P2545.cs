namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sort-the-students-by-their-kth-score/
///    Submission: https://leetcode.com/problems/sort-the-students-by-their-kth-score/submissions/901877716/
/// </summary>
internal class P2545
{
  public class Solution
  {
    public int[][] SortTheStudents(int[][] score, int k)
    {
      return score.OrderByDescending(row => row[k]).ToArray();
    }
  }
}
