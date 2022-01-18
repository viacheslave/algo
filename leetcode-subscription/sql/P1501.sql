/*
https://leetcode.com/problems/countries-you-can-safely-invest-in/
https://leetcode.com/submissions/detail/462727399/
*/

/* Write your T-SQL query statement below */
with av as
(
  select 1.0 * sum(duration) / count(*) aa from Calls
),
avc as
(
  select
    a.name,
    1.0 * sum(a.dur) / sum(a.c) dur
  from
  (
    select 
      c.name,
      sum(ca.duration) dur,
      count(ca.duration) c
    from Calls ca
    join Person p on ca.caller_id = p.id
    join Country c on substring(p.phone_number, 1, 3) = c.country_code
    group by c.name

    union all

    select 
      c.name,
      sum(ca.duration) dur,
      count(ca.duration) c
    from Calls ca
    join Person p on ca.callee_id = p.id
    join Country c on substring(p.phone_number, 1, 3) = c.country_code
    group by c.name
  ) a
  group by a.name
)
select avc.name country
from av
join avc on avc.dur > av.aa