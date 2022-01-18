/*
https://leetcode.com/problems/team-scores-in-football-tournament/
https://leetcode.com/submissions/detail/461033733/
Oracle
*/

/* Write your T-SQL query statement below */

;with cte as (
  select
    host_team h,
    guest_team g,
    case when host_goals > guest_goals then 3
         when host_goals = guest_goals then 1
         else 0 end hp,
    case when host_goals < guest_goals then 3
         when host_goals = guest_goals then 1
         else 0 end gp
  from
    Matches
)
select
  a.team_id,
  a.team_name,
  sum(a.num_points) num_points
from
(
  select t.team_id team_id, t.team_name, isnull(cte.hp, 0) num_points 
  from cte 
  right join Teams t on cte.h = t.team_id
  
  union all
  
  select t.team_id team_id, t.team_name, isnull(cte.gp, 0) num_points 
  from cte 
  right join Teams t on cte.g = t.team_id
) a
group by 
  a.team_id, 
  a.team_name
order by 
  sum(a.num_points) desc,
  a.team_id asc