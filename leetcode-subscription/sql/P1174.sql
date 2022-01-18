/*
https://leetcode.com/problems/number-of-trusted-contacts-of-a-customer/
https://leetcode.com/submissions/detail/452496586/
Roblox
*/

/* Write your T-SQL query statement below */

SELECT
  i.invoice_id,
  c.customer_name,
  i.price,
  ISNULL(a.contacts_cnt, 0) contacts_cnt,
  ISNULL(a.trusted_contacts_cnt, 0) trusted_contacts_cnt
FROM
  Invoices i
JOIN 
  Customers c
  ON i.user_id = c.customer_id
LEFT JOIN
(
  SELECT
    c.customer_id,
    c.customer_name,
    COUNT(*) contacts_cnt,
    COUNT(CASE WHEN lc.email IS NOT NULL THEN 1 END) trusted_contacts_cnt
  FROM Customers c
  JOIN Contacts ct
    ON c.customer_id = ct.user_id
  LEFT JOIN
    Customers lc
    ON ct.contact_email = lc.email
  GROUP BY
    c.customer_id,
    c.customer_name
) a
ON i.user_id = a.customer_id
ORDER BY i.invoice_id

