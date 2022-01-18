/*
https://leetcode.com/problems/invalid-tweets/
https://leetcode.com/submissions/detail/451065018/
Twitter
*/

/* Write your T-SQL query statement below */
SELECT
  tweet_id
FROM
  Tweets
WHERE 
  LEN(content) > 15

