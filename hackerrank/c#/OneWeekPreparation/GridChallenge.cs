namespace HackerRank.GridChallenge;

class Result
{

  /*
   * Complete the 'gridChallenge' function below.
   *
   * The function is expected to return a STRING.
   * The function accepts STRING_ARRAY grid as parameter.
   */

  public static string gridChallenge(List<string> grid)
  {
    grid = grid.ConvertAll(arr => new string(arr.OrderBy(x => x).ToArray()));

    for (var c = 0; c < grid[0].Length; c++)
    {
      for (var r = 1; r < grid.Count; r++)
      {
        if (grid[r][c] < grid[r - 1][c])
          return "NO";
      }
    }

    return "YES";
  }

}
/*
class Solution
{
  public static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int t = Convert.ToInt32(Console.ReadLine().Trim());

    for (int tItr = 0; tItr < t; tItr++)
    {
      int n = Convert.ToInt32(Console.ReadLine().Trim());

      List<string> grid = new List<string>();

      for (int i = 0; i < n; i++)
      {
        string gridItem = Console.ReadLine();
        grid.Add(gridItem);
      }

      string result = Result.gridChallenge(grid);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }
}
*/