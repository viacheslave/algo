"""
Problem: https://leetcode.com/problems/maximum-matching-of-players-with-trainers/
Solution: https://leetcode.com/submissions/detail/803052052/
"""
from typing import List

class Solution:
    def matchPlayersAndTrainers(self, players: List[int], trainers: List[int]) -> int:
        players.sort(reverse=True)
        trainers.sort(reverse=True)

        ans = 0
        i, j = 0, 0

        while i < len(players) and j < len(trainers):
          if players[i] <= trainers[j]:
            ans += 1
            j += 1
          i += 1  

        return ans
        