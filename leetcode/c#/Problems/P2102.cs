namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/contest/biweekly-contest-67/problems/sequentially-ordinal-rank-tracker/
///    Submission: https://leetcode.com/submissions/detail/600277314/
/// </summary>
internal class P2102
{
  public class SORTracker
  {
    SortedList<Location, Location> locations =
      new SortedList<Location, Location>();

    int query = 0;

    public SORTracker()
    {
    }

    public void Add(string name, int score)
    {
      var item = new Location() { name = name, score = score };
      locations[item] = item;
    }

    public string Get()
    {
      var ans = locations.Keys[query];

      query++;
      return ans.name;
    }

    public class Location : IComparable<Location>
    {
      public string name;
      public int score;

      public int CompareTo(Location other)
      {
        if (this.score == other.score)
          return this.name.CompareTo(other.name);

        return other.score.CompareTo(this.score);
      }

      public override bool Equals(object obj)
      {
        var o = (Location)obj;

        return this.name == o.name && this.score == o.score;
      }

      public override int GetHashCode() => HashCode.Combine(this.name, this.score);
    }
  }

}
