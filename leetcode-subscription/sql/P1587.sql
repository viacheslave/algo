/*
https://leetcode.com/problems/bank-account-summary-ii/
https://leetcode.com/submissions/detail/450723556/
*/

/* Write your MySQL query statement below */
SELECT
  name,
  SUM(amount) as balance
FROM
  Users
JOIN 
  Transactions ON Users.account = Transactions.account
GROUP BY 
  Users.account, Users.name
HAVING 
  SUM(amount) > 10000

