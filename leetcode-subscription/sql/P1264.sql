/*
https://leetcode.com/problems/page-recommendations/
https://leetcode.com/submissions/detail/459806671/
Facebook
*/

/* Write your T-SQL query statement below */
SELECT
  DISTINCT page_id recommended_page
FROM
  Likes
WHERE
  user_id
  IN
  (
  SELECT
    DISTINCT
    CASE WHEN user1_id = 1 THEN user2_id
         WHEN user2_id = 1 THEN user1_id
    END fr
  FROM
    Friendship
  ) AND
  page_id NOT IN
  (
    SELECT page_id FROM Likes WHERE user_id = 1
  )