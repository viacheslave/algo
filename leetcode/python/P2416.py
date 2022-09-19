"""
Problem: https://leetcode.com/problems/sum-of-prefix-scores-of-strings/
Solution: https://leetcode.com/submissions/detail/803580405/
"""

from typing import List

class Solution:
  def sumPrefixScores(self, words: List[str]) -> List[int]:
    trie = Solution.Trie()

    for w in words:
      trie.add(w)

    ans = []

    for w in words:
      count = 0
      node = trie.root
      for ch in w:
        count += node.nodes[ch].score
        node = node.nodes[ch]
      ans.append(count)

    return ans

  class TrieNode:
    def __init__(self, ch, score):
      self.ch = ch
      self.score = score
      self.nodes = dict()

    def add(self, ch):
      if self.nodes.get(ch):
        self.nodes[ch].score += 1
        return self.nodes[ch]

      node = Solution.TrieNode(ch, 1)
      self.nodes[ch] = node
      return node

  class Trie:
    def __init__(self):
      self.root = Solution.TrieNode(None, 0)

    def add(self, s: str):
      current = self.root
      for ch in s:
        current = current.add(ch)