/*
https://leetcode.com/problems/find-the-missing-ids/
https://leetcode.com/submissions/detail/460233489/
Amazon
*/

/* Write your T-SQL query statement below */
with gen as 
(
  select 1 AS num
  union all
  select num + 1 from gen where num + 1 <= 100
)
select 
  gen.num ids
from gen
left join Customers c on gen.num = c.customer_id
where c.customer_id is null
  --and gen.num >= (select min(customer_id) from Customers)
  and gen.num <= (select max(customer_id) from Customers)
option (maxrecursion 100)