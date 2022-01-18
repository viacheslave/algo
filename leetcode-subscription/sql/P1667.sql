/*
https://leetcode.com/problems/fix-names-in-a-table/
https://leetcode.com/submissions/detail/450738727/
*/

/* Write your T-SQL query statement below */
SELECT
  user_id,
  SUBSTRING(UPPER(name), 1, 1) + SUBSTRING(LOWER(name), 2, LEN(name) - 1) as name
FROM 
  Users
ORDER BY
  user_id



