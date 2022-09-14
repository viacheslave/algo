"""
Problem: https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/
Solution: https://leetcode.com/submissions/detail/799450744/
"""
from typing import Optional
from models import TreeNode

class Solution:
  def pseudoPalindromicPaths(self, root: Optional[TreeNode]) -> int:
    arr = dict()
    return self.traverse(root, arr)

  @staticmethod
  def traverse(node: Optional[TreeNode], arr: dict[int, int]) -> int:
    if node is None:
      return 0
    
    if (arr.get(node.val) is None):
      arr[node.val] = 0
    
    arr[node.val] += 1

    val = 0
    if node.left is None and node.right is None:
      val = 1 if Solution.is_palindrome(arr) else 0
    else:
      val = Solution.traverse(node.left, arr) + Solution.traverse(node.right, arr) 

    arr[node.val] -= 1
    return val

  @staticmethod
  def is_palindrome(arr) -> bool:
    odds = 0
    for k, v in arr.items():
      if (v % 2 == 1):
        odds += 1
    return odds <= 1
        