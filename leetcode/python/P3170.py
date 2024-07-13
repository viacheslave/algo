"""
Problem: https://leetcode.com/problems/lexicographically-minimum-string-after-removing-stars/
Solution: https://leetcode.com/problems/lexicographically-minimum-string-after-removing-stars/submissions/1319788743/
"""

class Solution:
    def clearStars(self, s: str) -> str:
        map = [[] for _ in range(26)]

        removals = dict()

        for index in range(len(s)):
            if s[index] == '*':
                for arr in map:
                    if len(arr) > 0:
                        removals.setdefault(arr[len(arr) - 1])
                        arr.pop()
                        break
            else:
                map[ord(s[index]) - 97].append(index)

        chars = []
        for index in range(len(s)):
            if index in removals:
                continue

            if s[index] != '*':
                chars.append(s[index])

        return "".join(chars)