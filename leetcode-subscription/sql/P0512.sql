/*
https://leetcode.com/problems/game-play-analysis-ii/
https://leetcode.com/submissions/detail/450965728/
GSN Games
*/

/* Write your T-SQL query statement below */
SELECT 
  a.player_id,
  a.device_id
FROM 
  Activity a
JOIN
(
  SELECT
    player_id,
    MIN(event_date) as first_login
  FROM 
    Activity
  GROUP BY
    player_id
) o
ON
  a.player_id = o.player_id AND
  a.event_date = o.first_login