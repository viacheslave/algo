namespace HackerRank.BalancedBrackets;

class Result
{

  /*
   * Complete the 'isBalanced' function below.
   *
   * The function is expected to return a STRING.
   * The function accepts STRING s as parameter.
   */

  public static string isBalanced(string s)
  {
    var st = new Stack<int>();

    foreach (var ch in s)
    {
      if (st.Count == 0)
      {
        st.Push(ch);
        continue;
      }

      if (st.Peek() == '(' && ch == ')')
      {
        st.Pop();
      }
      else if (st.Peek() == '{' && ch == '}')
      {
        st.Pop();
      }
      else if (st.Peek() == '[' && ch == ']')
      {
        st.Pop();
      }
      else
      {
        st.Push(ch);
      }
    }

    return st.Count == 0 ? "YES" : "NO";
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
      string s = Console.ReadLine();

      string result = Result.isBalanced(s);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }
}
*/