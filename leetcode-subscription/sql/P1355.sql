/*
https://leetcode.com/problems/activity-participants/
https://leetcode.com/submissions/detail/461022653/
IBM
*/

/* Write your T-SQL query statement below */
with cte as
(
  select
    activity,
    count(*) cnt
  from
    Friends
  group by
    activity
)
select activity
from Friends
group by activity
having 
  count(*) not in (select max(cnt) cnt from cte) and
  count(*) not in (select min(cnt) cnt from cte)