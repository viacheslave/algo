"""
Problem: https://leetcode.com/problems/count-days-spent-together/
Solution: https://leetcode.com/submissions/detail/803072094/
"""
from datetime import date

class Solution:
    def countDaysTogether(self, arriveAlice: str, leaveAlice: str, arriveBob: str, leaveBob: str) -> int:
        alice_from = self.get_days(arriveAlice)
        alice_to = self.get_days(leaveAlice)
        bob_from = self.get_days(arriveBob)
        bob_to = self.get_days(leaveBob)

        if alice_to < bob_from or bob_to < alice_from:
            return 0

        if alice_from <= bob_from <= bob_to <= alice_to:
            return bob_to - bob_from + 1

        if bob_from <= alice_from <= alice_to <= bob_to:
            return alice_to - alice_from + 1

        if bob_from <= alice_from <= bob_to <= alice_to:
            return bob_to - alice_from + 1
        else:
            return alice_to - bob_from + 1

    def get_days(self, datestr):
        return date(2022, int(datestr.split('-')[0]), int(datestr.split('-')[1])).timetuple().tm_yday
        