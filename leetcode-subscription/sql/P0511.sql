/*
https://leetcode.com/problems/game-play-analysis-i/
https://leetcode.com/submissions/detail/450964546/
GSN Games
*/

/* Write your T-SQL query statement below */
SELECT
  player_id,
  MIN(event_date) as first_login
FROM 
  Activity
GROUP BY
  player_id