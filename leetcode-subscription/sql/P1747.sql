/*
https://leetcode.com/problems/leetflex-banned-accounts/
https://leetcode.com/submissions/detail/459835142/
Audible
*/

/* Write your T-SQL query statement below */
select
  distinct a.account_id
from
  LogInfo a
join
  LogInfo b on a.account_id = b.account_id and a.ip_address != b.ip_address
where
  a.login <= b.logout and
  b.login <= a.logout