/*
https://leetcode.com/problems/find-followers-count/
https://leetcode.com/submissions/detail/450706616/
Tesla
*/

/* Write your MySQL query statement below */
SELECT
  user_id,
  COUNT(follower_id) as followers_count
FROM 
  Followers
GROUP BY
  user_id
ORDER BY
  user_id

