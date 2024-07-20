"""
Problem: https://leetcode.com/problems/minimum-rectangles-to-cover-points/
Solution: https://leetcode.com/problems/minimum-rectangles-to-cover-points/submissions/1327475897/
"""

from typing import List


class Solution:
    def minRectanglesToCoverPoints(self, points: List[List[int]], w: int) -> int:
        list = [point[0] for point in points]
        list.sort()

        start = list[0]
        ans = 0

        for point in list:
            if start + w >= point:
                continue

            start = point
            ans += 1

        ans +=1
        return ans