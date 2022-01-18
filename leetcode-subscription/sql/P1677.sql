/*
https://leetcode.com/problems/products-worth-over-invoices/
https://leetcode.com/submissions/detail/450703045/

*/

/* Write your T-SQL query statement below */
SELECT 
  p.name,
  SUM(i.rest) rest,
  SUM(i.paid) paid,
  SUM(i.canceled) canceled,
  SUM(i.refunded) refunded
FROM
  Product p
JOIN
  Invoice i ON p.product_id = i.product_id
GROUP BY
  p.name
ORDER BY
  p.name


