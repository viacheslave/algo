"""
Problem: https://leetcode.com/problems/lexicographically-smallest-string-after-operations-with-constraint/
Solution: https://leetcode.com/problems/lexicographically-smallest-string-after-operations-with-constraint/submissions/1328208870/
"""

class Solution:
    def getSmallestString(self, s: str, k: int) -> str:
        chars = []
        for ch in s:
            lower = min(ord(ch) - ord('a'), k)
            upper = 1 + ord('z') - ord(ch)
            if upper <= k and upper <= lower:
                chars.append('a')
                k -= upper
            else:
                chars.append(chr(ord(ch) - lower))
                k -= lower

        return ''.join(chars)