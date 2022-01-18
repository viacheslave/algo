/*
https://leetcode.com/problems/find-total-time-spent-by-each-employee/
https://leetcode.com/submissions/detail/450703045/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT 
  event_day as day,
  emp_id,
  SUM(out_time - in_time) as total_time
FROM
  Employees
GROUP BY
  event_day, emp_id

