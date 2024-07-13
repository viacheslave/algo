"""
Problem: https://leetcode.com/problems/find-the-encrypted-string/
Solution: https://leetcode.com/problems/find-the-encrypted-string/submissions/1319464934/
"""

class Solution:
    def getEncryptedString(self, s: str, k: int) -> str:
        return "".join([s[(i + k) % len(s)] for i in range(len(s))])