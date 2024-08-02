"""
Problem: https://leetcode.com/problems/minimum-length-of-string-after-operations/
Solution: https://leetcode.com/problems/minimum-length-of-string-after-operations/submissions/1342246637/
"""

class Solution:
    def minimumLength(self, s: str) -> int:
        map = {}
        for ch in s:
            map.setdefault(ch, 0)
            map[ch] += 1

        ans = 0
        for k, v in map.items():
            ans += 2 if v % 2 == 0 else 1

        return ans