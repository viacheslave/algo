"""
Problem: https://leetcode.com/problems/alternating-groups-ii/
Solution: https://leetcode.com/problems/alternating-groups-ii/submissions/1321864535/
"""

from typing import List


class Solution:
    def numberOfAlternatingGroups(self, colors: List[int], k: int) -> int:
        """
        Sliding window
        """

        ans = 0
        start = 0
        end = 1
        color = colors[start]

        while start < len(colors):
            while True:
                if colors[end % len(colors)] == color:
                    start = end
                    end += 1
                    break
                if end == start + k - 1:
                    ans += 1
                    start += 1
                    color = colors[end % len(colors)]
                    end += 1
                    break
                    
                color = colors[end % len(colors)]
                end += 1

        return ans