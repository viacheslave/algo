"""
Problem: https://leetcode.com/problems/count-the-number-of-special-characters-ii/
Solution: https://leetcode.com/problems/count-the-number-of-special-characters-ii/submissions/1319982164/
"""

class Solution:
    def numberOfSpecialChars(self, word: str) -> int:
        map: dict[str][str] = {}
        for i, ch in enumerate(word):
            if ch.islower():
                map[ch] = i
            else:
                if ch not in map:
                    map[ch] = i

        ans = 0
        for k, v in map.items():
            if k.islower() and k.upper() in map and v < map[k.upper()]:
                ans += 1

        return ans