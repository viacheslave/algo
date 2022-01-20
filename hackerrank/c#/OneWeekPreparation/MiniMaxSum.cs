namespace HackerRank.MiniMaxSum;

class Result
{

  /*
   * Complete the 'plusMinus' function below.
   *
   * The function accepts INTEGER_ARRAY arr as parameter.
   */

  public static void plusMinus(List<int> arr)
  {
    Console.WriteLine(1.0 * arr.Count(a => a > 0) / arr.Count);
    Console.WriteLine(1.0 * arr.Count(a => a < 0) / arr.Count);
    Console.WriteLine(1.0 * arr.Count(a => a == 0) / arr.Count);
  }

}
/*
class Solution
{
  public static void Main(string[] args)
  {
    int n = Convert.ToInt32(Console.ReadLine().Trim());

    List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

    Result.plusMinus(arr);
  }
}
*/