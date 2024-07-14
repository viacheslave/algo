"""
Problem: https://leetcode.com/problems/find-the-n-th-value-after-k-seconds/
Solution: https://leetcode.com/problems/find-the-n-th-value-after-k-seconds/submissions/1320875824/
"""

class Solution:
    def valueAfterKSeconds(self, n: int, k: int) -> int:
        arr = [[1 for _ in range(n)]]
        sum = [1 for _ in range(n)]
        row = [1 for _ in range(n)]
        mod = int(1e9 + 7)

        for t in range(k):
            row[0] = 1
            for i in range(n - 1):
                val = (sum[i] + row[i]) % mod
                row[i + 1] = val

            for i in range(n):
                sum[i] += row[i]
                sum[i] %= mod

            arr.append(row)

        return arr[k][n - 1]
        