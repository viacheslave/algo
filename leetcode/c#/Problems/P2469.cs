namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/convert-the-temperature/
///    Submission: https://leetcode.com/problems/convert-the-temperature/submissions/842889092/
/// </summary>
internal class P2469
{
  public class Solution
  {
    public double[] ConvertTemperature(double celsius)
    {
      return new double[] { celsius + 273.15, celsius * 1.8 + 32 };
    }
  }
}
