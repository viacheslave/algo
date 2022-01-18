/*
https://leetcode.com/problems/number-of-calls-between-two-persons/
https://leetcode.com/submissions/detail/451544080/
Amazon
*/

/* Write your T-SQL query statement below */

SELECT
  a.id_from person1,
  a.id_to person2,
  COUNT(*) call_count,
  SUM(duration) total_duration
FROM
(
  SELECT
    CASE WHEN from_id > to_id THEN to_id ELSE from_id END as id_from,
    CASE WHEN from_id > to_id THEN from_id ELSE to_id END as id_to,
    duration
  FROM Calls
) a
GROUP BY
  a.id_from, a.Id_to

  

