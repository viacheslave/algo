/*
https://leetcode.com/problems/actors-and-directors-who-cooperated-at-least-three-times/
https://leetcode.com/submissions/detail/451190342/
Amazon
*/

/* Write your MySQL query statement below */
SELECT
  actor_id,
  director_id
FROM
  ActorDirector
GROUP BY
  actor_id,
  director_id
HAVING COUNT(*) >= 3

