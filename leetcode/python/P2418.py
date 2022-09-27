"""
Problem: https://leetcode.com/problems/sort-the-people/
Solution: https://leetcode.com/submissions/detail/808129228/
"""

from typing import List

class Solution:
    def sortPeople(self, names: List[str], heights: List[int]) -> List[str]:
        data = sorted([(name, height) for (name, height) in zip(names, heights)], key=lambda t: t[1], reverse=True)
        return [s for s in map(lambda item: item[0], data)]