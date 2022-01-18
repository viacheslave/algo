using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/web-crawler/
  ///    Submission: https://leetcode.com/submissions/detail/459820989/
  ///    GoDaddy
  /// </summary>
  internal class P1236
  {
    public abstract class HtmlParser
    {
      public abstract List<string> GetUrls(string url);
    }

    class Solution
    {
      public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
      {
        var domain = new Uri(startUrl);

        var ans = new HashSet<string>();

        var q = new Queue<string>();
        q.Enqueue(startUrl);

        while (q.Count > 0)
        {
          var item = q.Dequeue();
          if (ans.Contains(item))
            continue;

          ans.Add(item);

          foreach (var url in htmlParser.GetUrls(item))
            if (new Uri(url).Host == domain.Host)
              q.Enqueue(url);
        }

        return ans.ToList();
      }
    }
  }
}
