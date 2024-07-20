"""
Problem: https://leetcode.com/problems/find-the-maximum-length-of-valid-subsequence-i/
Solution: https://leetcode.com/problems/find-the-maximum-length-of-valid-subsequence-i/submissions/1327310857/
"""

from typing import List


class Solution:
    def maximumLength(self, nums: List[int]) -> int:
        even_count = len([x for x in nums if x % 2 == 0])
        odd_count = len([x for x in nums if x % 2 == 1])

        alt_count = 0
        current = None
        for num in nums:
            if current is None or current % 2 != num % 2:
                current = num
                alt_count += 1
                continue

        return max(max(even_count, odd_count), alt_count)