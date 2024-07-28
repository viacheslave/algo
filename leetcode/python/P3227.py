"""
Problem: https://leetcode.com/problems/vowels-game-in-a-string/
Solution: https://leetcode.com/problems/vowels-game-in-a-string/submissions/1335290516/
"""

class Solution:
    def doesAliceWin(self, s: str) -> bool:
        vowels = set(['a', 'e', 'i', 'o', 'u'])
        vowels_count = len([ch for ch in s if ch in vowels])

        return vowels_count > 0
        