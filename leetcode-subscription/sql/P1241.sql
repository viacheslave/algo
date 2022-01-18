/*
https://leetcode.com/problems/number-of-comments-per-post/
https://leetcode.com/submissions/detail/451197150/
Facebook
*/

/* Write your T-SQL query statement below */

SELECT
  p.id post_id,
  COUNT(DISTINCT(s.sub_id)) number_of_comments
FROM
(
  SELECT
    DISTINCT(sub_id) id
  FROM
    Submissions
  WHERE
    parent_id IS NULL
) p
LEFT JOIN
  Submissions s
ON 
  p.id = s.parent_id
GROUP BY 
  p.id

