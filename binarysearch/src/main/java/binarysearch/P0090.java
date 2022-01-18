package binarysearch;

import java.util.AbstractMap;
import java.util.Map;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Rain-Catcher
 * Submission: v
 */
public class P0090 {
  class Solution {
    public int solve(int[] nums) {
      var ans = 0;

      var stack = new Stack<Map.Entry<Integer, Integer>>();

      for (var i = 0; i < nums.length; i++)
      {
        var h = nums[i];

        // if height descreases - just add it to stack
        if (stack.size() == 0 || h <= stack.peek().getKey())
        {
          stack.push(new AbstractMap.SimpleEntry<>(h, i));
          continue;
        }

        var current = stack.pop();

        // search through stack for the most prev element with height
        // greater than next, and stop when it's greater than current 'h'
        while (stack.size() > 0 && stack.peek().getKey() >= current.getKey())
        {
          var hh = Math.min(h, stack.peek().getKey()) - current.getKey();
          ans += hh * (i - stack.peek().getValue() - 1);

          current = stack.pop();

          if (current.getKey() >= h)
          {
            stack.push(current);
            break;
          }
        }

        stack.push(new AbstractMap.SimpleEntry<>(h, i));
      }

      return ans;
    }
  }
}