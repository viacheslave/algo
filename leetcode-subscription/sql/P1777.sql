/*
https://leetcode.com/problems/products-price-for-each-store/
https://leetcode.com/submissions/detail/462263119/
Amazon
*/

SELECT 
  *
FROM  
(
  SELECT 
    product_id, 
    store,
    price   
  FROM Products
) s  

PIVOT  
(  
  SUM(price)  
  FOR store IN (
    [store1], 
    [store2], 
    [store3])  
) AS PivotTable; 