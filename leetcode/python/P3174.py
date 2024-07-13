"""
Problem: https://leetcode.com/problems/clear-digits/
Solution: https://leetcode.com/problems/clear-digits/submissions/1319521653/
"""

from typing import List

class Solution:
    def clearDigits(self, s: str) -> str:
        stack: List[str] = []

        for ch in s:
            if ch.isdigit():
                if len(stack) > 0 and stack[len(stack) - 1].isdigit() == False:
                    stack.pop()
            else:
                stack.append(ch)
        return "".join(stack)