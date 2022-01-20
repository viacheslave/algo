namespace HackerRank.PlusMinus;

class Result
{

  /*
   * Complete the 'miniMaxSum' function below.
   *
   * The function accepts INTEGER_ARRAY arr as parameter.
   */

  public static void miniMaxSum(List<int> arr)
  {
    arr.Sort();
    var min = arr.Select(x => (long)x).Take(arr.Count - 1).Sum();
    var max = arr.Select(x => (long)x).Skip(1).Take(arr.Count - 1).Sum();

    Console.WriteLine($"{min} {max}");
  }

}
/*
class Solution
{
  public static void Main(string[] args)
  {

    List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

    Result.miniMaxSum(arr);
  }
}
*/