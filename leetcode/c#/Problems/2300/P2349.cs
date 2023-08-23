namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/design-a-number-container-system/
///    Submission: https://leetcode.com/submissions/detail/755490757/
/// </summary>
internal class P2349
{
  public class NumberContainers
  {
    private readonly Dictionary<int, int> _indexToNumber = new();
    private readonly Dictionary<int, SortedSet<int>> _numberToIndex = new();

    public NumberContainers()
    {
    }

    public void Change(int index, int number)
    {
      if (_indexToNumber.ContainsKey(index))
      {
        if (_numberToIndex.ContainsKey(_indexToNumber[index]))
        {
          _numberToIndex[_indexToNumber[index]].Remove(index);
        }
      }

      _indexToNumber[index] = number;

      if (!_numberToIndex.ContainsKey(number))
      {
        _numberToIndex[number] = new SortedSet<int>();
      }

      _numberToIndex[number].Add(index);
    }

    public int Find(int number)
    {
      var set = _numberToIndex.GetValueOrDefault(number);
      return (set is null || set.Count == 0) ? -1 : set.Min;
    }
  }

  /**
   * Your NumberContainers object will be instantiated and called as such:
   * NumberContainers obj = new NumberContainers();
   * obj.Change(index,number);
   * int param_2 = obj.Find(number);
   */
}
