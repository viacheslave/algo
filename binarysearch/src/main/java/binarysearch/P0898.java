package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/XOR-Range-Queries
 * Submission: https://binarysearch.com/problems/XOR-Range-Queries/submissions/6646495
 */
public class P0898 {
  class Solution {
    public int[] solve(int[] nums, int[][] queries) {
      var prefixXor = new int[nums.length + 1];

      for (var i = 0; i < nums.length; i++)
        prefixXor[i + 1] = prefixXor[i] ^ nums[i];

      var ans = new int[queries.length];

      for (var i = 0; i < queries.length; i++) {
        var query = queries[i];
        ans[i] = prefixXor[query[1] + 1] ^ prefixXor[query[0]];
      }

      return ans;
    }
  }
}