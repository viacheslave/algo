"""
Problem: https://leetcode.com/problems/reverse-odd-levels-of-binary-tree/
Solution: https://leetcode.com/submissions/detail/803473778/
"""

from typing import List, Optional
from leetcode.python.models import TreeNode

class Solution:
    def reverseOddLevels(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        self.reverse([root], 0)
        return root

    def reverse(self, nodes: List[Optional[TreeNode]], level: int):
        if len(nodes) == 0:
            return
        
        if level % 2 == 1:
            for i in range(len(nodes) // 2):
                nodes[i].val, nodes[len(nodes) - 1 - i].val = nodes[len(nodes) - 1 - i].val, nodes[i].val

        nxt = []
        for node in nodes:
            if node.left is None:
                break
            
            nxt.append(node.left)
            nxt.append(node.right)
        self.reverse(nxt, level=level + 1)
        
        
        