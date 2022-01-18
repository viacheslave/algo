/*
https://leetcode.com/problems/active-users/
https://leetcode.com/submissions/detail/461723638/
Amazon
*/

with cte as
(
  select
    l.id,
    l.login_date,
    row_number() over (partition by l.id order by l.login_date) row_num
  from
  (
    select 
      distinct 
       a.id, 
       a.login_date
    from 
      Logins a
  ) l
)
select distinct
  a.id,
  acc.name
from cte a
join cte b
  on a.id = b.id and a.row_num = b.row_num + 4
join Accounts acc
  on a.id = acc.id
where 
  datediff(dd, b.login_date, a.login_date) = 4