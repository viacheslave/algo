using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/design-a-leaderboard/
  ///    Submission: https://leetcode.com/submissions/detail/452782556/
  ///    Google
  /// </summary>
  internal class P1244
  {
    public class Leaderboard
    {
      Dictionary<int, int> _players = new Dictionary<int, int>();
      SortedSet<(int id, int score)> _set = new SortedSet<(int id, int score)>(new Comp());

      public Leaderboard()
      {

      }

      public void AddScore(int playerId, int score)
      {
        if (_players.ContainsKey(playerId))
        {
          var prev = _players[playerId];

          _set.Remove((playerId, prev));
          _set.Add((playerId, score + prev));

          _players[playerId] = score + prev;
        }
        else
        {
          _set.Add((playerId, score));
          _players[playerId] = score;
        }
      }

      public int Top(int K)
      {
        return _set.Take(K).Sum(x => x.score);
      }

      public void Reset(int playerId)
      {
        var score = _players[playerId];

        _set.Remove((playerId, score));
        _set.Add((playerId, 0));

        _players[playerId] = 0;
      }

      internal class Comp : IComparer<(int id, int score)>
      {
        public int Compare((int id, int score) x, (int id, int score) y)
        {
          if (x.score == y.score)
            return y.id.CompareTo(x.id);

          return y.score.CompareTo(x.score);
        }
      }
    }
  }
}
