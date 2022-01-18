/*
https://leetcode.com/problems/apples-oranges/
https://leetcode.com/submissions/detail/451654750/
Facebook
*/

/* Write your T-SQL query statement below */
SELECT
  sale_date,
  SUM(CASE WHEN fruit = 'apples' THEN sold_num END) -
    SUM(CASE WHEN fruit = 'oranges' THEN sold_num END) as diff
FROM
  Sales
GROUP BY
  sale_date
ORDER BY
  sale_date
  

