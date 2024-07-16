"""
Problem: https://leetcode.com/problems/find-the-minimum-area-to-cover-all-ones-i/
Solution: https://leetcode.com/problems/find-the-minimum-area-to-cover-all-ones-i/submissions/1323327660/
"""

from typing import List


class Solution:
    def minimumArea(self, grid: List[List[int]]) -> int:
        x_max = 0
        x_min = len(grid) - 1
        y_max = 0
        y_min = len(grid[0]) - 1
        has_one = False

        for i in range(len(grid)):
            for j in range(len(grid[0])):
                if grid[i][j] == 1:
                    has_one = True
                    x_min = min(x_min, i)
                    x_max = max(x_max, i)
                    y_min = min(y_min, j)
                    y_max = max(y_max, j)

        if has_one:
            return (x_max - x_min + 1) * (y_max - y_min + 1)
        
        return 0
