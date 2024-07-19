"""
Problem: https://leetcode.com/problems/find-occurrences-of-an-element-in-an-array/
Solution: https://leetcode.com/problems/find-occurrences-of-an-element-in-an-array/submissions/1326605032/
"""

from typing import List


class Solution:
    def occurrencesOfElement(self, nums: List[int], queries: List[int], x: int) -> List[int]:
        occ = []
        for i, e in enumerate(nums):
            if e == x:
                occ.append(i)

        ans = []
        for q in queries:
            ans.append(-1 if q > len(occ) else occ[q - 1])

        return ans