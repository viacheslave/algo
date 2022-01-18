/*
https://leetcode.com/problems/friendly-movies-streamed-last-month/
https://leetcode.com/submissions/detail/451465394/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  DISTINCT c.title
FROM
  TVProgram tv
JOIN
  Content c
ON 
  tv.content_id = c.content_id
WHERE
  tv.program_date BETWEEN '2020-06-01' AND '2020-06-30' AND
  c.Kids_content = 'Y' AND
  c.content_type = 'Movies'

