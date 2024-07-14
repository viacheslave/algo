"""
Problem: https://leetcode.com/problems/delete-nodes-from-linked-list-present-in-array/
Solution: https://leetcode.com/problems/delete-nodes-from-linked-list-present-in-array/submissions/1320822519/
"""

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next

from typing import List, Optional

class Solution:
    def modifiedList(self, nums: List[int], head: Optional[ListNode]) -> Optional[ListNode]:
        if head is None:
            return head
        
        nums_set = set(nums)
        node = head
        prev = None

        while node is not None:
            if node.val not in nums_set:
                prev = node
                node = node.next
                continue

            # remove node
            if node is head:
                prev = None
                node = node.next

                # adjust head
                head = node
                continue

            prev.next = node.next
            node = node.next

        return head
        