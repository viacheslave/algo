/*
https://leetcode.com/problems/all-people-report-to-the-given-manager/
https://leetcode.com/submissions/detail/461028243/
Amazon
*/

/* Write your T-SQL query statement below */
with cte as
(
  select e.employee_id
  from Employees e
  where e.manager_id = 1 and e.employee_id != 1 
  
  union all
  
  select e.employee_id 
  from Employees e 
  join cte c on e.manager_id = c.employee_id
)
select * from cte
option(maxrecursion 4)

