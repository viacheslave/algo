/*
Problem: https://leetcode.com/problems/human-traffic-of-stadium/
Submission: https://leetcode.com/problems/human-traffic-of-stadium/submissions/865846336/
*/

/* Write your T-SQL query statement below */
select 
    r.id, 
    r.visit_date, 
    r.people
from
(
    select distinct(o.id)
    from
    (
        (
            select a.id
            from Stadium a
            join Stadium b on a.id = b.id + 1
            join Stadium c on b.id = c.id + 1
            where a.people >= 100 
            and b.people >= 100
            and c.people >= 100
        )
        union all
        (
            select a.id
            from Stadium a
            join Stadium b on a.id = b.id - 1
            join Stadium c on b.id = c.id - 1
            where a.people >= 100 
            and b.people >= 100
            and c.people >= 100
        )
        union all
        (
            select a.id
            from Stadium a
            join Stadium b on a.id = b.id + 1
            join Stadium c on a.id = c.id - 1
            where a.people >= 100 
            and b.people >= 100
            and c.people >= 100
        )
    ) o
) ids 
join Stadium r on ids.id = r.id
order by r.visit_date