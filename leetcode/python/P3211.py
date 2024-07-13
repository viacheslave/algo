"""
Problem: https://leetcode.com/problems/generate-binary-strings-without-adjacent-zeros/
Solution: https://leetcode.com/problems/generate-binary-strings-without-adjacent-zeros/submissions/1319486378/
"""

from typing import List

class Solution:
    def validStrings(self, n: int) -> List[str]:
        res = list()
        arr = ["0"] * n
        self.rec(res, arr, 0)
        return res

    def rec(self, res: List[str], arr: List[str], index: int) -> None:
        if index == len(arr):
            res.append("".join(arr))
            return
        
        arr[index] = "1"
        self.rec(res, arr, index + 1)

        if index == 0:
            arr[index] = "0"
            self.rec(res, arr, index + 1)
            
        else:
            if arr[index - 1] == "1":
                arr[index] = "0"
                self.rec(res, arr, index + 1)