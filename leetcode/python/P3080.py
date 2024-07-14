"""
Problem: https://leetcode.com/problems/mark-elements-on-array-by-performing-queries/
Solution: https://leetcode.com/problems/mark-elements-on-array-by-performing-queries/submissions/1320506706/
"""

from heapq import heapify, heappop
from typing import List


class Solution:
    def unmarkedSumArray(self, nums: List[int], queries: List[List[int]]) -> List[int]:
        s = sum(nums)

        """
        Build pq over Nodes
        """
        pq = [Node(index, num) for index, num in enumerate(nums)]
        heapify(pq)

        marks = [False for _ in range(len(nums))]

        ans = []
        for query in queries:
            mi = query[0]
            mn = query[1]

            if not marks[mi]:
                marks[mi] = True
                s -= nums[mi]

            i = mn
            while i > 0:
                if not pq:
                    break
                
                pqitem = heappop(pq)
                print(pqitem)

                if marks[pqitem.index]:
                    continue

                marks[pqitem.index] = True
                s -= pqitem.val
                i -= 1

            ans.append(s)
        
        return ans

class Node:
    def __init__(self, index: int, val: int):
        self.index = index
        self.val = val

    def __lt__(self, other):
        if self.val == other.val:
            return self.index < other.index
        return self.val < other.val
    
    def __repr__(self) -> str:
        return f"{self.val} [{self.index}]"
            
