namespace HackerRank.CountingSort;

class Result
{

  /*
   * Complete the 'countingSort' function below.
   *
   * The function is expected to return an INTEGER_ARRAY.
   * The function accepts INTEGER_ARRAY arr as parameter.
   */

  public static List<int> countingSort(List<int> arr)
  {
    var result = new int[100];

    for (var i = 0; i < arr.Count; i++)
      result[arr[i]]++;

    return result.ToList();
  }

}
/*
class Solution
{
  public static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int n = Convert.ToInt32(Console.ReadLine().Trim());

    List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

    List<int> result = Result.countingSort(arr);

    textWriter.WriteLine(String.Join(" ", result));

    textWriter.Flush();
    textWriter.Close();
  }
}
*/