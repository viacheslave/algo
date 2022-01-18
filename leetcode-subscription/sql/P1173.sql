/*
https://leetcode.com/problems/immediate-food-delivery-i/
https://leetcode.com/submissions/detail/451414956/
DoorDash
*/

/* Write your T-SQL query statement below */
SELECT
  ROUND(100.0 * COUNT(CASE WHEN order_date = customer_pref_delivery_date THEN 1 END) / COUNT(*), 2) as immediate_percentage
FROM
  Delivery
