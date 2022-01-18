/*
https://leetcode.com/problems/game-play-analysis-iv/
https://leetcode.com/submissions/detail/450987748/
GSN Games, Facebook
*/

/* Write your T-SQL query statement below */
SELECT
  ROUND(1.0 * r1.np / r2.np, 2) as fraction
FROM
(
  SELECT
    COUNT(cc.np) as np
  FROM
  (
    SELECT 
      DISTINCT(a.player_id) as np
    FROM
    (
      SELECT
        bb.player_id,
        bb.event_date
      FROM
        Activity bb
    ) b
    JOIN
    (
      SELECT
        aa.player_id,
        MIN(aa.event_date) as event_date
      FROM
        Activity aa
      GROUP BY
        aa.player_id
    ) a 
    ON 
      b.player_id = a.player_id AND
      b.event_date = DATEADD(day, 1, a.event_date)
    ) cc
) r1
CROSS JOIN
(
  SELECT
    COUNT(cc.np) as np
  FROM
  (
    SELECT
      DISTINCT(player_id) as np
    FROM
      Activity a
    GROUP BY
      a.player_id
  ) cc
) r2

