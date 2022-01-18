/*
https://leetcode.com/problems/friend-requests-ii-who-has-the-most-friends/
https://leetcode.com/submissions/detail/458409969/
Amazon
*/

/* Write your T-SQL query statement below */
SELECT
  TOP 1
    o.a id,
    COUNT(*) num
FROM
(
SELECT
  requester_id a, accepter_id b
FROM 
  request_accepted
  
UNION

SELECT
  accepter_id a, requester_id b
FROM 
  request_accepted
) o
GROUP BY
  o.a
ORDER BY
  COUNT(*) DESC
