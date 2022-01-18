/*
https://leetcode.com/problems/immediate-food-delivery-ii/
https://leetcode.com/submissions/detail/452499868/
DoorDash
*/

/* Write your T-SQL query statement below */
SELECT
  ROUND(100.0 * COUNT(CASE WHEN a.mark = 1 THEN 1 END) / COUNT(*), 2) as immediate_percentage
FROM
(
  SELECT 
    d.delivery_id,
    CASE WHEN d.order_date = customer_pref_delivery_date THEN 1 ELSE 0 END mark
  FROM
    Delivery d
  JOIN
  (
    SELECT
      customer_id,
      MIN(order_date) order_date
    FROM
      Delivery
    GROUP BY
      customer_id
  ) a
  ON 
    d.customer_id = a.customer_id AND
    d.order_date = a.order_date
) a
