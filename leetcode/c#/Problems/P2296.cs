namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/design-a-text-editor/
///    Submission: https://leetcode.com/submissions/detail/714945557/
/// </summary>
internal class P2296
{
  public class TextEditor
  {
    private readonly Stack<char> _lq = new();
    private readonly Stack<char> _rq = new();

    public TextEditor()
    {
    }

    public void AddText(string text)
    {
      foreach (var ch in text)
      {
        _lq.Push(ch);
      }
    }

    public int DeleteText(int k)
    {
      var length = Math.Min(_lq.Count, k);

      for (int i = 0; i < length; i++)
      {
        _lq.Pop();
      }

      return length;
    }

    public string CursorLeft(int k)
    {
      var length = Math.Min(_lq.Count, k);

      for (int i = 0; i < length; i++)
      {
        var ch = _lq.Pop();
        _rq.Push(ch);
      }

      return new string(_lq.Take(Math.Min(_lq.Count, 10)).Reverse().ToArray());
    }

    public string CursorRight(int k)
    {
      var length = Math.Min(_rq.Count, k);

      for (int i = 0; i < length; i++)
      {
        var ch = _rq.Pop();
        _lq.Push(ch);
      }

      return new string(_lq.Take(Math.Min(_lq.Count, 10)).Reverse().ToArray());
    }
  }
}
