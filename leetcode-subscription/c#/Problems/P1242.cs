using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/web-crawler-multithreaded/
  ///    Submission: https://leetcode.com/submissions/detail/459825245/
  ///    Dropbox
  /// </summary>
  internal class P1242
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

        var ans = new System.Collections.Concurrent.ConcurrentDictionary<string, string>();

        Crawl(domain, startUrl, htmlParser, ans);

        return ans.Keys.ToList();
      }

      private void Crawl(Uri domain, string url, HtmlParser htmlParser, System.Collections.Concurrent.ConcurrentDictionary<string, string> ans)
      {
        if (ans.ContainsKey(url))
          return;

        ans.TryAdd(url, url);

        System.Threading.Tasks.Parallel.ForEach(htmlParser.GetUrls(url),
          new System.Threading.Tasks.ParallelOptions { MaxDegreeOfParallelism = 16 },
          (i) => {
            if (new Uri(i).Host == domain.Host)
              Crawl(domain, i, htmlParser, ans);
          });
      }
    }
  }
}
