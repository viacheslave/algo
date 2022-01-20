package binarysearch;

import binarysearch.templates.LLNode;
import binarysearch.templates.Tree;

import java.util.*;
import java.util.stream.Collectors;

class Solution {
  public int solve(int[] nums) {
    if (nums.length == 0)
      return 0;

    nums = new TreeSet<Integer>(Arrays.stream(nums).boxed().collect(Collectors.toList()))
      .stream().mapToInt(x -> x).toArray();

    var ans = 1;
    var length = 1;

    for (var i = 1; i < nums.length; i++) {
      if (nums[i] == nums[i - 1] + 1) {
        length++;
      }
      else {
        length = 1;
      }

      ans = Math.max(ans, length);
    }

    return ans;
  }
}