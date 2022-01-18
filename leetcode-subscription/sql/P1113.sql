/*
https://leetcode.com/problems/reported-posts/
https://leetcode.com/submissions/detail/451155655/
Facebook
*/

/* Write your T-SQL query statement below */
SELECT
  extra report_reason,
  COUNT(DISTINCT(post_id)) as report_count
FROM
  Actions
WHERE
  extra IS NOT NULL AND
  action = 'report' AND
  action_date = '2019-07-04'
GROUP BY 
  extra

