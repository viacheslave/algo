"""
Problem: https://leetcode.com/problems/minimum-money-required-before-transactions/
Solution: https://leetcode.com/submissions/detail/802892235/
"""
from typing import List

class Solution:
    def minimumMoney(self, transactions: List[List[int]]) -> int:
        positive = [a for a in transactions if a[0] - a[1] <= 0]
        negative = [a for a in transactions if a[0] - a[1] > 0]

        positive = sorted(positive, reverse=True, key=lambda x : x[0])
        negative = sorted(negative, key=lambda x : x[1])

        all = [*negative, *positive]

        balance = 0
        acc = 0
        
        for t in all:
          min_need = t[0]
          if balance < min_need:
            acc += min_need - balance
          
          balance = max(balance, min_need)
          balance -= t[0]
          balance += t[1]

        return acc
        