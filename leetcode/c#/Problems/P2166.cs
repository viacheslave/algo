namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/design-bitset/
///    Submission: https://leetcode.com/submissions/detail/635632203/
/// </summary>
internal class P2166
{
  public class Bitset
  {
    private readonly List<uint> _bitset = new List<uint>();
    private readonly int _size;
    private readonly int _length;
    private const int _segmentSize = 32;
    private int _ones = 0;

    public Bitset(int size)
    {
      _size = size;
      _length = size / _segmentSize + 1;

      for (var i = 0; i < _length; i++)
        _bitset.Add(0);
    }

    public void Fix(int idx)
    {
      var segment = idx / _segmentSize;
      var bit = idx % _segmentSize;

      var mask = ((uint)1) << idx;

      if ((_bitset[segment] & mask) == mask)
        return;

      _bitset[segment] += mask;
      _ones++;
    }

    public void Unfix(int idx)
    {
      var segment = idx / _segmentSize;
      var bit = idx % _segmentSize;

      var mask = ((uint)1) << idx;

      if ((_bitset[segment] & mask) == 0)
        return;

      _bitset[segment] -= mask;
      _ones--;
    }

    public void Flip()
    {
      for (var i = 0; i < _length; i++)
      {
        _bitset[i] = ~_bitset[i];
      }

      _ones = _size - _ones;
    }

    public bool All()
    {
      return _ones == _size;
    }

    public bool One()
    {
      return _ones > 0;
    }

    public int Count()
    {
      return _ones;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();

      for (var i = _length - 1; i >= 0; i--)
      {
        sb.Append(Convert.ToString(_bitset[i], 2).PadLeft(32, '0'));
      }

      var res = sb.ToString();
      if (res.Length > _size)
        res = res.Substring(res.Length - _size);

      return new string(res.Reverse().ToArray());
    }
  }

}
