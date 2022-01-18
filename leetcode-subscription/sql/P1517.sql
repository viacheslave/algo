/*
https://leetcode.com/problems/find-users-with-valid-e-mails/
https://leetcode.com/submissions/detail/451095496/
*/

/* Write your MySQL query statement below*/
SELECT
  *
FROM
  Users
WHERE 
  REGEXP_LIKE(mail, '^[A-Za-z][0-9A-Za-z_.-]{0,}@leetcode.com$')

