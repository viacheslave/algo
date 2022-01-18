/*
https://leetcode.com/problems/movie-rating/
https://leetcode.com/submissions/detail/451893669/
SAP
*/

/* Write your T-SQL query statement below */

SELECT 
  a.name as results
FROM (
  SELECT
    TOP 1 name
  FROM
    Movie_Rating mr
  JOIN
    Movies m ON mr.movie_id = m.movie_id
  JOIN 
    Users u ON mr.user_id = u.user_id
  GROUP BY
    name
  ORDER BY
    COUNT(*) DESC,
    name ASC
) a
  
UNION ALL

SELECT 
  a.name as results
FROM (
  SELECT
    TOP 1 title name
  FROM
    Movie_Rating mr
  JOIN
    Movies m ON mr.movie_id = m.movie_id
  WHERE
    mr.created_at BETWEEN '2020-02-01' AND '2020-02-29'
  GROUP BY
    title
  ORDER BY
    1.0 * SUM(rating) / COUNT(*) DESC
) a


