/*
https://leetcode.com/problems/ads-performance/
https://leetcode.com/submissions/detail/451075641/
Facebook
*/

/* Write your T-SQL query statement below */

SELECT
  a.ad_id,
  CASE WHEN a.clicked + a.viewed = 0 THEN 0 ELSE ROUND(100.0 * a.clicked / (a.clicked + a.viewed), 2) END as ctr
FROM
(
SELECT 
  ad_id,
  ISNULL(SUM(CASE WHEN action = 'Clicked' THEN 1 END), 0) as clicked,
  ISNULL(SUM(CASE WHEN action = 'Viewed' THEN 1 END), 0) as viewed
FROM
  Ads
GROUP BY
  ad_id
) a
ORDER BY
  2 DESC,
  1 ASC

