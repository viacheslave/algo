using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3413/
  ///    https://leetcode.com/submissions/detail/376416796/?from=/explore/challenge/card/august-leetcoding-challenge
  /// </summary>
  internal class Aug05
  {
    public class WordDictionary
    {
      private TreeNode _root = new TreeNode();

      /** Initialize your data structure here. */
      public WordDictionary()
      {
      }

      /** Adds a word into the data structure. */
      public void AddWord(string word)
      {
        var currentNode = _root;

        for (int i = 0; i < word.Length; i++)
        {
          var ch = word[i];

          var node = currentNode.Children.FirstOrDefault(node => node.Ch == ch);
          if (node != null)
          {
            currentNode = node;
          }
          else
          {
            var newNode = new TreeNode() { Ch = ch };
            currentNode.Children.Add(newNode);

            currentNode = newNode;
          }

          if (i == word.Length - 1)
            currentNode.IsTerminal = true;
        }
      }

      /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
      public bool Search(string word)
      {
        var queue = new Queue<(TreeNode, int)>();

        queue.Enqueue((_root, 0));

        while (queue.Count > 0)
        {
          var item = queue.Dequeue();
          var node = item.Item1;
          var index = item.Item2;

          if (index == word.Length)
          {
            if (node.IsTerminal)
              return true;
            else
              continue;
          }

          var ch = word[index];
          if (ch == '.')
          {
            foreach (var child in node.Children)
            {
              queue.Enqueue((child, index + 1));
            }
          }

          else
          {
            var child = node.Children.FirstOrDefault(n => n.Ch == ch);
            if (child != null)
            {
              queue.Enqueue((child, index + 1));
            }
          }
        }

        return false;
      }

      private class TreeNode
      {
        public char Ch;
        public bool IsTerminal;
        public List<TreeNode> Children = new List<TreeNode>();
      }
    }

    /**
     * Your WordDictionary object will be instantiated and called as such:
     * WordDictionary obj = new WordDictionary();
     * obj.AddWord(word);
     * bool param_2 = obj.Search(word);
     */
  }
}
