/*
https://leetcode.com/problems/monthly-transactions-i/
https://leetcode.com/submissions/detail/458737068/

*/

/* Write your T-SQL query statement below */
SELECT
  FORMAT(trans_date, 'yyyy-MM') as 'month',
  country,
  COUNT(*) trans_count,
  COUNT(CASE WHEN state = 'approved' THEN 1 END) approved_count,
  SUM(amount) trans_total_amount,
  SUM(CASE WHEN state = 'approved' THEN amount ELSE 0 END) approved_total_amount
FROM
  Transactions
GROUP BY
  FORMAT(trans_date, 'yyyy-MM'),
  country


