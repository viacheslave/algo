namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/frequency-tracker/
///    Submission: https://leetcode.com/problems/frequency-tracker/submissions/957574060/
/// </summary>
internal class P2671
{
  public class FrequencyTracker
  {
    private readonly Dictionary<int, int> _numbers = new();
    private readonly Dictionary<int, int> _frequencies = new();

    public FrequencyTracker()
    {
    }

    public void Add(int number)
    {
      var count = _numbers.GetValueOrDefault(number, 0);

      _numbers[number] = count + 1;

      if (_frequencies.GetValueOrDefault(count, 0) != 0)
      {
        _frequencies[count]--;
        if (_frequencies[count] == 0) _frequencies.Remove(count);
      }

      _frequencies[count + 1] = _frequencies.GetValueOrDefault(count + 1, 0) + 1;
    }

    public void DeleteOne(int number)
    {
      if (_numbers.GetValueOrDefault(number, 0) == 0)
        return;

      var count = _numbers[number];

      _numbers[number]--;

      if (_frequencies.GetValueOrDefault(count, 0) != 0)
      {
        _frequencies[count]--;
        if (_frequencies[count] == 0) _frequencies.Remove(count);
      }

      _frequencies[count - 1] = _frequencies.GetValueOrDefault(count - 1, 0) + 1;
    }

    public bool HasFrequency(int frequency)
    {
      return _frequencies.ContainsKey(frequency);
    }
  }
}
