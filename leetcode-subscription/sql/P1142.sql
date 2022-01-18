/*
https://leetcode.com/problems/user-activity-for-the-past-30-days-ii/
https://leetcode.com/submissions/detail/451455798/
Facebook
*/

/* Write your T-SQL query statement below */
SELECT
  ISNULL(ROUND(1.0 * SUM(a.sessions) / COUNT(a.sessions), 2), 0.00) average_sessions_per_user
FROM
(
  SELECT
    user_id,
    COUNT(DISTINCT(session_id)) sessions
  FROM
    Activity
  WHERE
    activity_date BETWEEN '2019-06-28' AND '2019-07-27'
  GROUP BY
    user_id
) a
