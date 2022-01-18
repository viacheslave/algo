/*
https://leetcode.com/problems/active-businesses/
https://leetcode.com/submissions/detail/458437400/
Yelp
*/

SELECT
  data.business_id
FROM
(
  SELECT
    e.business_id,
    e.event_type,
    e.occurences,
    av.vv vv
  FROM
    Events e
  JOIN
  (
    SELECT
      e.event_type,
      AVG(e.occurences) vv
    FROM
      Events e
    GROUP BY
      e.event_type
  ) av
  ON
    e.event_type = av.event_type
) data
GROUP BY
  data.business_id
  --data.event_type
HAVING 
  COUNT(CASE WHEN data.occurences > data.vv THEN 1 END) > 1

