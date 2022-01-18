/*
https://leetcode.com/problems/average-time-of-process-per-machine/
https://leetcode.com/submissions/detail/450746902/
Facebook
*/

/* Write your T-SQL query statement below */
SELECT 
  a.machine_id,
  ROUND(AVG(b.timestamp - a.timestamp), 3) as processing_time
FROM
(
  SELECT
    machine_id,
    process_id,
    timestamp
  FROM
    Activity
  WHERE activity_type = 'start'
) a
JOIN
(
  SELECT
    machine_id,
    process_id,
    timestamp
  FROM
    Activity
  WHERE activity_type = 'end'
) b
ON a.machine_id = b.machine_id AND 
   a.process_id = b.process_id 
GROUP BY a.machine_id