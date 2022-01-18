/*
https://leetcode.com/problems/find-customer-referee/
https://leetcode.com/submissions/detail/451175578/
Amazon
*/

/* Write your MySQL query statement below */
SELECT
  name
FROM
  customer
WHERE
  referee_id <> 2 OR referee_id IS NULL

