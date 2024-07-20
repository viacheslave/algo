"""
Problem: https://leetcode.com/problems/find-the-number-of-distinct-colors-among-the-balls/
Solution: https://leetcode.com/problems/find-the-number-of-distinct-colors-among-the-balls/submissions/1327039372/
"""

from typing import List, Set

class Solution:
    def queryResults(self, limit: int, queries: List[List[int]]) -> List[int]:
        colors = {}
        items = {}
        ans = []

        for q in queries:
            i = q[0]
            c = q[1]

            if i not in items:
                items[i] = c
            else:
                pc = items[i]

                colors[pc].remove(i)
                if len(colors[pc]) == 0:
                    colors.pop(pc)

                items[i] = c

            colors.setdefault(c, set())
            colors[c].add(i)

            ans.append(len(colors))

        return ans