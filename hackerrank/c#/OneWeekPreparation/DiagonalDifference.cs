namespace HackerRank.DiagonalDifference;

class Result
{

  /*
   * Complete the 'diagonalDifference' function below.
   *
   * The function is expected to return an INTEGER.
   * The function accepts 2D_INTEGER_ARRAY arr as parameter.
   */

  public static int diagonalDifference(List<List<int>> arr)
  {
    var n = arr.Count;

    var d1 = 0;
    var d2 = 0;

    for (var i = 0; i < n; i++)
    {
      d1 += arr[i][i];
      d2 += arr[i][n - 1 - i];
    }

    return Math.Abs(d1 - d2);
  }

}
/*
class Solution
{
  public static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int n = Convert.ToInt32(Console.ReadLine().Trim());

    List<List<int>> arr = new List<List<int>>();

    for (int i = 0; i < n; i++)
    {
      arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
    }

    int result = Result.diagonalDifference(arr);

    textWriter.WriteLine(result);

    textWriter.Flush();
    textWriter.Close();
  }
}
*/
