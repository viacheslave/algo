/*
Problem: https://leetcode.com/problems/the-latest-login-in-2020/
Submission: https://leetcode.com/problems/the-latest-login-in-2020/submissions/863265914/
*/

/* Write your T-SQL query statement below */
select 
  l.user_id,
  max(l.time_stamp) as last_stamp
from Logins l
where l.time_stamp between '2020-01-01 00:00:00' and '2020-12-31 23:59:59'
group by l.user_id