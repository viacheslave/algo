/*
https://leetcode.com/problems/user-activity-for-the-past-30-days-i/
https://leetcode.com/submissions/detail/451071868/
Zoom
*/

/* Write your T-SQL query statement below */
SELECT
  a.activity_date day,
  COUNT(DISTINCT(a.user_id)) active_users
FROM
  Activity a
WHERE
  a.activity_date BETWEEN '2019-06-28' AND '2019-07-27'
GROUP BY 
  a.activity_date

