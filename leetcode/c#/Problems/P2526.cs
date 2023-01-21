namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-consecutive-integers-from-a-data-stream/
///    Submission: https://leetcode.com/problems/find-consecutive-integers-from-a-data-stream/submissions/877902465/
/// </summary>
internal class P2526
{
  public class DataStream
  {
    int _index = -1;
    int _value;
    int _k;

    // track last value and index
    int _lastIndex = -1;
    int _lastNum = -1;

    public DataStream(int value, int k)
    {
      _value = value;
      _k = k;
    }

    public bool Consec(int num)
    {
      _index++;

      if (_lastNum == -1)
      {
        _lastNum = num;
        _lastIndex = _index;
      }
      else
      {
        if (num != _lastNum)
        {
          _lastIndex = _index;
          _lastNum = num;
        }
      }

      return (_lastNum == _value && _index - _lastIndex >= _k - 1);
    }
  }

  /**
   * Your DataStream object will be instantiated and called as such:
   * DataStream obj = new DataStream(value, k);
   * bool param_1 = obj.Consec(num);
   */
}
