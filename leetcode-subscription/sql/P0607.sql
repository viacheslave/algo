/*
https://leetcode.com/problems/sales-person/
https://leetcode.com/submissions/detail/450962972/

*/

/* Write your T-SQL query statement below */
SELECT
 s.name
FROM
  salesperson s
LEFT JOIN
(
  SELECT
    s.name,
    COUNT(*) as cnt
  FROM
    salesperson s
  JOIN
    orders o ON s.sales_id = o.sales_id
  JOIN 
    company c ON c.com_id = o.com_id
  WHERE 
    c.name = 'RED'
  GROUP BY
    s.name
) o ON s.name = o.name
WHERE
  o.cnt IS NULL