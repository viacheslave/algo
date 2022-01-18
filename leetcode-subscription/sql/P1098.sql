/*
https://leetcode.com/problems/unpopular-books
https://leetcode.com/submissions/detail/451881786/

*/

/* Write your MySQL query statement below */
SELECT
  b.book_id,
  b.name
FROM 
(
  SELECT
    b.book_id,
    b.name,
    IFNULL(MIN(b.available_from), '20000101') av,
    IFNULL(SUM(CASE WHEN o.dispatch_date >= '2018-06-23' THEN o.quantity END), 0) q
  FROM
    Books b
  LEFT JOIN
    Orders o ON b.book_id = o.book_id
  GROUP BY
    b.book_id,
    b.name
) b
WHERE 
  b.av <= '2019-05-24' AND
  b.q < 10
