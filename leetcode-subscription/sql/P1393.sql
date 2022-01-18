/*
https://leetcode.com/problems/capital-gainloss/
https://leetcode.com/submissions/detail/451924354/
Robinhood
*/

/* Write your T-SQL query statement below */
SELECT
  stock_name,
  SUM(CASE WHEN operation = 'Sell' THEN price ELSE -1 * price END) as capital_gain_loss
FROM
  Stocks
GROUP BY
  stock_name

