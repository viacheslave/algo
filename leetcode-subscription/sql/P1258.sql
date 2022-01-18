/*
https://leetcode.com/problems/find-the-start-and-end-number-of-continuous-ranges/
https://leetcode.com/submissions/detail/460231418/
Amazon
*/

/* Write your T-SQL query statement below */
with o as
(
  select
    a.log_id,
    --ap.log_id p,
    --an.log_id n,
    case when ap.id is null or (an.id is not null and ap.id is null) then 1 end s,
    case when an.id is null or (ap.id is not null and an.id is null) then 1 end e
  from (select row_number() over(order by log_id) id, log_id from logs) a
  left join (select row_number() over(order by log_id) id, log_id from logs) ap on a.log_id = ap.log_id + 1
  left join (select row_number() over(order by log_id) id, log_id from logs) an on a.log_id = an.log_id - 1
  where 
   ((case when ap.id is null or (an.id is not null and ap.id is null) then 1 end) is not null or
   (case when an.id is null or (ap.id is not null and an.id is null) then 1 end) is not null)
)
select 
  a1.log_id start_id,
  a2.log_id end_id
from
(
  select 
    row_number() over(order by o.log_id) id,
    o.log_id
  from o
  where o.s = 1
) a1
join
(
  select 
    row_number() over(order by o.log_id) id,
    o.log_id
  from o
  where o.e = 1
) a2 on a1.id = a2.id