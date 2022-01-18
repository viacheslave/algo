/*
https://leetcode.com/problems/winning-candidate/  
https://leetcode.com/submissions/detail/458421871/

*/

/* Write your T-SQL query statement below */
SELECT
  TOP 1 o.Name
FROM
(
  SELECT 
    c.id,
    c.Name,
    COUNT(*) num
  FROM
    Vote v
  JOIN 
    Candidate c
  ON
    v.CandidateId = c.id
  GROUP BY
    c.id, c.Name 
) o
ORDER BY
  o.num DESC


