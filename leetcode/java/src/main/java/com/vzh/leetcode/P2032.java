package com.vzh.leetcode;

import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/two-out-of-three/
 * Submission: https://leetcode.com/submissions/detail/583489100/
 */
public class P2032 {
  class Solution {
    public List<Integer> twoOutOfThree(int[] nums1, int[] nums2, int[] nums3) {
      var arr1 = Arrays.stream(nums1).boxed().collect(Collectors.toSet());
      var arr2 = Arrays.stream(nums2).boxed().collect(Collectors.toSet());
      var arr3 = Arrays.stream(nums3).boxed().collect(Collectors.toSet());

      var list = new HashSet<Integer>();
      for (var i = 0; i < nums1.length; i++)
        if (arr2.contains(nums1[i]) || arr3.contains((nums1[i])))
          list.add(nums1[i]);

      for (var i = 0; i < nums2.length; i++)
        if (arr1.contains(nums2[i]) || arr3.contains((nums2[i])))
          list.add(nums2[i]);

      for (var i = 0; i < nums3.length; i++)
        if (arr1.contains(nums3[i]) || arr2.contains((nums3[i])))
          list.add(nums3[i]);

      return list.stream().collect(Collectors.toList());
    }
  }
}