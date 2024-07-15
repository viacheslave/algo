"""
Problem: https://leetcode.com/problems/count-pairs-that-form-a-complete-day-ii/
Solution: https://leetcode.com/problems/count-pairs-that-form-a-complete-day-ii/submissions/1321568673/
"""

from typing import List


class Solution:
    def countCompleteDayPairs(self, hours: List[int]) -> int:
        map = { }

        for index, item in enumerate(hours):
            map.setdefault(item % 24, [])
            map[item % 24].append(index)

        ans = 0

        for k, v in map.items():
            if k % 12 == 0:
                ans += len(v) * (len(v) - 1) // 2
                continue

            if k < 12:
                r = 24 - k
                
                if map.get(r) is None:
                    continue
                
                seq = [(k, index) for index in v] + [(r, index) for index in map.get(r)]
                seq.sort(key=lambda c: c[1])

                f_count = len(v)
                r_count = len(map.get(r))

                for tuple in seq:
                    if tuple[0] == k:
                        ans += r_count
                        f_count -= 1
                    else:
                        ans += f_count
                        r_count -= 1

        return ans