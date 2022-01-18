/*
https://leetcode.com/problems/friend-requests-i-overall-acceptance-rate/
https://leetcode.com/submissions/detail/453212285/
Facebook
*/

/* Write your T-SQL query statement below */
 
SELECT 
  CASE WHEN b.cnt = 0 THEN 0.00
  ELSE ROUND(
    1.0 * a.cnt / b.cnt, 2
  ) END accept_rate
FROM
(
  SELECT 
    COUNT(*) cnt
  FROM
  ( 
    SELECT 
      DISTINCT requester_id as fr, accepter_id as tt
    FROM
      RequestAccepted
  ) a
) a
CROSS JOIN
(
  SELECT 
    COUNT(*) cnt
  FROM
  ( 
    SELECT 
      DISTINCT sender_id as fr, send_to_id as tt
    FROM
      FriendRequest
  ) b
) b

  

