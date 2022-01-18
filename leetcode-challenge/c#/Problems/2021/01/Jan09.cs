using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3598/
  ///    https://leetcode.com/submissions/detail/440605704/?from=explore&item_id=3598
  /// </summary>
  internal class Jan09
  {
    public class Solution
    {
      int min = int.MaxValue;

      public int LadderLength(string beginWord, string endWord, IList<string> wordList)
      {
        var pool = new HashSet<string>(wordList);
        if (!pool.Contains(endWord))
          return 0;

        pool.Add(beginWord);
        pool.Remove(endWord);

        var queue = new Queue<string>();
        queue.Enqueue(endWord);

        var map = new Dictionary<string, int>();
        map[endWord] = 0;

        while (queue.Count > 0)
        {
          var item = queue.Dequeue();

          var processed = new List<string>();

          foreach (var word in pool)
          {
            if (OneLetterOff(word, item))
            {
              //visited.Add(word);
              processed.Add(word);
              map[word] = map[item] + 1;

              queue.Enqueue(word);
            }
          }

          foreach (var pr in processed)
            pool.Remove(pr);
        }

        return map.ContainsKey(beginWord) ? (map[beginWord] + 1) : 0;
      }

      private bool OneLetterOff(string word, string current)
      {
        var diff = 0;

        for (var i = 0; i < word.Length; i++)
          if (word[i] != current[i])
            diff++;

        return diff == 1;
      }
    }
  }
}

