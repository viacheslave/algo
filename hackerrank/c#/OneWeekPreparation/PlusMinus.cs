using System.IO;

namespace HackerRank.TimeConversion;

class Result
{

  /*
   * Complete the 'timeConversion' function below.
   *
   * The function is expected to return a STRING.
   * The function accepts STRING s as parameter.
   */

  public static string timeConversion(string s)
  {
    var hrs = int.Parse(s.Substring(0, 2));
    var am = s.Substring(8, 2) == "AM";

    if (am)
    {
      if (hrs == 12) hrs = 0;
    }
    else
    {
      if (hrs != 12) hrs += 12;
    }

    return $"{hrs:D2}{s.Substring(2, 6)}";
  }

}
/*
class Solution
{
  public static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    string s = Console.ReadLine();

    string result = Result.timeConversion(s);

    textWriter.WriteLine(result);

    textWriter.Flush();
    textWriter.Close();
  }
}
*/