namespace HackerRank.RecursiveDigitSum;

class Result
{

  /*
   * Complete the 'superDigit' function below.
   *
   * The function is expected to return an INTEGER.
   * The function accepts following parameters:
   *  1. STRING n
   *  2. INTEGER k
   */

  public static int superDigit(string n, int k)
  {
    var digits = n.ToCharArray()
      .Select(x => int.Parse(x.ToString()))
      .ToList();

    var sum = 1L * digits.Sum() * k;

    while (digits.Count > 1)
    {
      digits = sum.ToString()
        .ToCharArray()
        .Select(x => int.Parse(x.ToString()))
        .ToList();

      sum = digits.Sum();
    }

    return digits.Single();
  }

}
/*
class Solution
{
  public static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

    string n = firstMultipleInput[0];

    int k = Convert.ToInt32(firstMultipleInput[1]);

    int result = Result.superDigit(n, k);

    textWriter.WriteLine(result);

    textWriter.Flush();
    textWriter.Close();
  }
}
*/