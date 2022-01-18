/*
https://leetcode.com/problems/game-play-analysis-iii/
https://leetcode.com/submissions/detail/450967285/
GSN Games
*/

/* Write your T-SQL query statement below */
SELECT
  player_id,
  event_date,
  SUM(games_played) OVER (PARTITION BY player_id ORDER BY event_date) as games_played_so_far
FROM
  Activity