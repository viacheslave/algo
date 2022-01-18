/*
https://leetcode.com/problems/new-users-daily-count/
https://leetcode.com/submissions/detail/451593596/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  aa.login_date,
  COUNT(*) user_count
--FROM
--  Traffic a
--JOIN
FROM
(
  SELECT 
    user_id,
    MIN(activity_date) login_date
  FROM
    Traffic
  WHERE
    activity = 'login'
  GROUP BY
    user_id
) aa
--ON 
--  a.activity_date = aa.login_date AND
--  a.user_id = aa.user_id
WHERE
  aa.login_date BETWEEN DATEADD(day, -90, '2019-06-30') AND '2019-06-30'
GROUP BY
  aa.login_date
