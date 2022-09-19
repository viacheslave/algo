"""
Problem: https://leetcode.com/problems/smallest-even-multiple/
Solution: https://leetcode.com/submissions/detail/803482983/
"""

class Solution:
    def smallestEvenMultiple(self, n: int) -> int:
        return n if n % 2 == 0 else 2 * n
        
        