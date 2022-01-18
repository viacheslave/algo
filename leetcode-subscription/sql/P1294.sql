/*
https://leetcode.com/problems/weather-type-in-each-country/
https://leetcode.com/submissions/detail/451084232/
Point72
*/

/* Write your T-SQL query statement below */

SELECT
  c.country_name,
  CASE WHEN (1.0 * SUM(w.weather_state) / COUNT(w.weather_state) <= 15) THEN 'Cold'
       WHEN (1.0 * SUM(w.weather_state) / COUNT(w.weather_state) >= 25) THEN 'Hot'
       ELSE 'Warm' END as weather_type
FROM
  Countries c
JOIN
  Weather w
ON 
  c.country_id = w.country_id
WHERE 
  w.day BETWEEN '2019-11-01' AND '2019-11-30'
GROUP BY
  c.country_name

