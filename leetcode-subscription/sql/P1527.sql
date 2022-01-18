/*
https://leetcode.com/problems/patients-with-a-condition/
https://leetcode.com/submissions/detail/450737489/
*/

/* Write your T-SQL query statement below */
SELECT
  *
FROM Patients
WHERE conditions LIKE '% DIAB1%'
   OR conditions LIKE 'DIAB1%'


