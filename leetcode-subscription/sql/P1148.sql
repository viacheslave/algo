/*
https://leetcode.com/problems/article-views-i/
https://leetcode.com/submissions/detail/451177141/
LinkedIn
*/

/* Write your MySQL query statement below */
SELECT
  DISTINCT(author_id) id
FROM
  Views
WHERE 
  author_id = viewer_id
ORDER BY 1

