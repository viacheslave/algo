/*
https://leetcode.com/problems/triangle-judgement/
https://leetcode.com/submissions/detail/450958765/

*/

/* Write your T-SQL query statement below */
SELECT 
  x,y,z,
  CASE
    WHEN (x + y > z) AND (z + y > x) AND (x + z > y) THEN 'Yes'
    ELSE 'No'
  END as triangle
FROM triangle