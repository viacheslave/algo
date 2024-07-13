"""
Problem: https://leetcode.com/problems/count-submatrices-with-equal-frequency-of-x-and-y/
Solution: https://leetcode.com/problems/count-submatrices-with-equal-frequency-of-x-and-y/submissions/1319513912/
"""

from typing import List

class Solution:
    def numberOfSubmatrices(self, grid: List[List[str]]) -> int:
        ans = 0
        
        """
        Collect prefix sums
        """
        prefixSums = []
        for row in range(len(grid)):
            rowSum = []
            running = []
            x = 0
            y = 0
            for col in range(len(grid[0])):
                if grid[row][col] == "X":
                    x += 1
                if grid[row][col] == "Y":
                    y += 1
                running.append((x, y))

                if row == 0:
                    rowSum.append(running[col])
                else:
                    rowSum.append(
                        (prefixSums[row - 1][col][0] + running[col][0], prefixSums[row - 1][col][1] + running[col][1]))

            prefixSums.append(rowSum)

        for row in range(len(grid)):
            for col in range(len(grid[0])):
                if prefixSums[row][col][0] > 0 and prefixSums[row][col][0] == prefixSums[row][col][1]:
                    ans += 1

        return ans 