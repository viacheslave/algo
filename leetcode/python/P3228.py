"""
Problem: https://leetcode.com/problems/maximum-number-of-operations-to-move-ones-to-the-end/
Solution: https://leetcode.com/problems/maximum-number-of-operations-to-move-ones-to-the-end/submissions/1335891207/
"""

class Solution:
    def maxOperations(self, s: str) -> int:
        ans = 0
        running_ones = 0
        for index, ch in enumerate(s):
            if s[index] == '0' and (index == len(s) - 1 or s[index + 1] == '1'):
                ans += running_ones
                continue

            if s[index] == '1':
                running_ones += 1

        return ans