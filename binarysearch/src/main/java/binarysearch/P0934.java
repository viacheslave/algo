package binarysearch;

import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Recursive-Voting
 * Submission: https://binarysearch.com/problems/Recursive-Voting/submissions/7498249
 */
public class P0934 {
  class Solution {
    public int solve(int[] votes) {
      var candidates = new int[votes.length];

      for (int i = 0; i < votes.length; i++) {
        resolve(i, votes, candidates);
      }

      return (int) Arrays.stream(candidates).filter(x -> x < 0).count();
    }

    private int resolve(int index, int[] votes, int[] candidates) {
      if (candidates[index] != 0) {
        return candidates[index];
      }

      var vote = votes[index];
      if (vote < 0) {
        candidates[index] = -1;
      }
      else if (vote >= votes.length) {
        candidates[index] = 1;
      }
      else {
        candidates[index] = resolve(vote, votes, candidates);
      }
      return candidates[index];
    }
  }
}