"""
Problem: https://leetcode.com/problems/count-submatrices-with-top-left-element-and-sum-less-than-k/
Solution: https://leetcode.com/problems/count-submatrices-with-top-left-element-and-sum-less-than-k/submissions/1320572840/
"""

from typing import List


class Solution:
    def countSubmatrices(self, grid: List[List[int]], k: int) -> int:
        pr = []
        ans = 0

        """
        2D prefix sums
        """
        for i, row in enumerate(grid):
            running = 0

            prr = []
            pr.append(prr)

            for j, val in enumerate(row): 
                running += grid[i][j]
                
                val = running
                if i > 0:
                    val += pr[i - 1][j]

                prr.append(val)
                if (val <= k):
                    ans += 1

        return ans
