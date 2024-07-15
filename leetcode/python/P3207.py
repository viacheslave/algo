"""
Problem: https://leetcode.com/problems/maximum-points-after-enemy-battles/
Solution: https://leetcode.com/problems/maximum-points-after-enemy-battles/submissions/1321827347/
"""

from typing import List


class Solution:
    def maximumPoints(self, enemyEnergies: List[int], currentEnergy: int) -> int:
        """
        Greedy
        """
        enemyEnergies.sort()

        if currentEnergy < enemyEnergies[0]:
            return 0
        
        ans = 0
        while len(enemyEnergies) > 0:
            points = currentEnergy // enemyEnergies[0]
            currentEnergy -= points * enemyEnergies[0]
            ans += points

            item = enemyEnergies.pop()
            currentEnergy += item

        return ans