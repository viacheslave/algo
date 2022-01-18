/*
https://leetcode.com/problems/recyclable-and-low-fat-products/
https://leetcode.com/submissions/detail/461707066/
Facebook
*/

/* Write your T-SQL query statement below */
select
  product_id
from
  Products
where
  low_fats = 'Y' and
  recyclable = 'Y'