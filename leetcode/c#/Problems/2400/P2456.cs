namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/most-popular-video-creator/
///    Submission: https://leetcode.com/problems/most-popular-video-creator/submissions/833303490/
/// </summary>
internal class P2456
{
  public class Solution
  {
    public IList<IList<string>> MostPopularCreator(string[] creators, string[] ids, int[] views)
    {
      var data = Enumerable.Range(0, creators.Length)
        .Select(index => (creator: creators[index], video: ids[index], views: views[index]))
        .GroupBy(t => t.creator)
        .Select(g => (
          creator: g.Key,
          videos: g
            .Select(f => f.video).Zip(g.Select(f => f.views))
            .Select(z => (video: z.First, views: z.Second))
            .OrderByDescending(t => t.views)
            .ThenBy(t => t.video, StringComparer.OrdinalIgnoreCase)
            .ToArray(),
          viewSum: g.Sum(f => 1L * f.views)
        ));

      var maxViews = data.Max(f => 1L * f.viewSum);
      var bestCreators = data.Where(d => d.viewSum == maxViews).ToArray();

      return bestCreators
        .Select(c => (IList<string>)new List<string> { c.creator, c.videos[0].video })
        .ToList();
    }
  }
}
