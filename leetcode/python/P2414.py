"""
Problem: https://leetcode.com/problems/length-of-the-longest-alphabetical-continuous-substring/
Solution: https://leetcode.com/submissions/detail/803481115/
"""

class Solution:
    def longestContinuousSubstring(self, s: str) -> int:
        ans, cur = 0, 0
        for i, ch in enumerate(s):
            if i == 0:
                cur += 1
                ans = max(ans, cur)
            else:
                if ord(ch) == ord(s[i - 1]) + 1:
                    cur += 1
                    ans = max(ans, cur)
                else:
                    cur = 1

        return ans
        
        