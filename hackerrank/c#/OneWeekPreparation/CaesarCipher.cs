﻿namespace HackerRank.CaesarCipher;

class Result
{

  /*
   * Complete the 'caesarCipher' function below.
   *
   * The function is expected to return a STRING.
   * The function accepts following parameters:
   *  1. STRING s
   *  2. INTEGER k
   */

  public static string caesarCipher(string s, int k)
  {
    var chs = s
      .Select(x =>
      {
        if (!char.IsLetter(x))
          return (char)x;

        var shift = char.IsLower(x) ? 97 : 65;
        return (char)(x + ((shift - 97) + k) % 26);

      })
      .ToArray();

    return new string(chs);
  }

}
/*
class Solution
{
  public static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int n = Convert.ToInt32(Console.ReadLine().Trim());

    string s = Console.ReadLine();

    int k = Convert.ToInt32(Console.ReadLine().Trim());

    string result = Result.caesarCipher(s, k);

    textWriter.WriteLine(result);

    textWriter.Flush();
    textWriter.Close();
  }
}
*/
