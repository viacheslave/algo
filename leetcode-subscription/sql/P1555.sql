/*
https://leetcode.com/problems/bank-account-summary/
https://leetcode.com/submissions/detail/451515626/
Optum
*/

/* Write your MySQL query statement below */

SELECT
  u.user_id,
  u.user_name,
  u.credit + ISNULL(a.amount, 0) as credit,
  CASE WHEN u.credit + a.amount < 0 THEN 'Yes' ELSE 'No' END as credit_limit_breached
FROM
  Users u
LEFT JOIN
(
  SELECT
    ISNULL(u1.paid_by, u2.paid_to) user_id,
    SUM(ISNULL(u2.amount, 0) - ISNULL(u1.amount, 0)) as amount
  FROM
  (
    SELECT
      paid_by,
      SUM(amount) amount
    FROM
      Transactions
    GROUP BY
      paid_by 
  ) u1
  FULL OUTER JOIN
  (
    SELECT
      paid_to,
      SUM(amount) amount
    FROM
      Transactions
    GROUP BY
      paid_to
  ) u2
  ON u1.paid_by = u2.paid_to
  GROUP BY
    u1.paid_by,
    u2.paid_to
) a
ON u.user_id = a.user_id

