"""
Problem: https://leetcode.com/problems/count-the-number-of-special-characters-i/
Solution: https://leetcode.com/problems/count-the-number-of-special-characters-i/submissions/1319974087/
"""

class Solution:
    def numberOfSpecialChars(self, word: str) -> int:
        map: dict[str][str] = {ch: ch for ch in word}
        return len([k for k in map.keys() if k.islower() and k.upper() in map])