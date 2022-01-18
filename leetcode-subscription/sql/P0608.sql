/*
https://leetcode.com/problems/tree-node/
https://leetcode.com/submissions/detail/454494688/
Uber
*/

/* Write your T-SQL query statement below */
SELECT 
  a.id,
  CASE WHEN a.p_id IS NULL THEN 'Root'
       WHEN b.inn IS NULL THEN 'Leaf'
       ELSE 'Inner' END Type
FROM
  tree a
LEFT JOIN
(
  SELECT 
    DISTINCT a.p_id inn
  FROM
    tree a
  LEFT JOIN 
    tree b ON a.p_id = b.id
  WHERE 
    a.p_id IS NOT NULL
) b
ON a.id = b.inn