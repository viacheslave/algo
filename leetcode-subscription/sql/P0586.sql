/*
https://leetcode.com/problems/customer-placing-the-largest-number-of-orders/
https://leetcode.com/submissions/detail/451453789/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  TOP 1 customer_number
FROM
  orders
GROUP BY
  customer_number
ORDER BY
  COUNT(*) DESC

