/*
https://leetcode.com/problems/biggest-window-between-visits/
https://leetcode.com/submissions/detail/461716979/
*/

/* Write your T-SQL query statement below */

with cte as (
  select 
    user_id,
    visit_date,
    row_number() over (partition by user_id order by visit_date) as rownum
  from
  (
    select
      distinct u.user_id, a.d visit_date
    from 
      UserVisits u
    cross join (select '2021-01-01' d) a

    union

    select *
    from UserVisits
  ) b
)
select 
  a.user_id, 
  max(datediff(dd, b.visit_date, a.visit_date)) biggest_window
from cte a
join cte b  
  on a.user_id = b.user_id and a.rownum = b.rownum + 1
group by
  a.user_id
order by
  a.user_id