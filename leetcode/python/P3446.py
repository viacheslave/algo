"""
Problem: https://leetcode.com/problems/sort-matrix-by-diagonals/
Solution: https://leetcode.com/problems/sort-matrix-by-diagonals/submissions/1568279199/
"""

from typing import List


class Solution:
    def sortMatrix(self, grid: List[List[int]]) -> List[List[int]]:
        for i in range(len(grid)):
            if i == 0: 
                continue
            self.sortDiagonal(grid, 0, i, False)
        
        for i in range(len(grid)):
            self.sortDiagonal(grid, i, 0, True)
        
        return grid
    
    def sortDiagonal(self, grid, x, y, sortOrder):
        temp = []
        for index in range(0, len(grid)):
            if x + index >= len(grid) or y + index >= len(grid):
                break
            temp.append(grid[x + index][y + index])

        temp.sort(reverse=sortOrder)
        for index in range(0, len(temp)):
            grid[x + index][y + index] = temp[index]
