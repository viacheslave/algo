﻿using System.IO;

namespace HackerRank.MergeLists;

class Solution
{

  class SinglyLinkedListNode
  {
    public int data;
    public SinglyLinkedListNode next;

    public SinglyLinkedListNode(int nodeData)
    {
      this.data = nodeData;
      this.next = null;
    }
  }

  class SinglyLinkedList
  {
    public SinglyLinkedListNode head;
    public SinglyLinkedListNode tail;

    public SinglyLinkedList()
    {
      this.head = null;
      this.tail = null;
    }

    public void InsertNode(int nodeData)
    {
      SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

      if (this.head == null)
      {
        this.head = node;
      }
      else
      {
        this.tail.next = node;
      }

      this.tail = node;
    }
  }

  static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
  {
    while (node != null)
    {
      textWriter.Write(node.data);

      node = node.next;

      if (node != null)
      {
        textWriter.Write(sep);
      }
    }
  }

  // Complete the mergeLists function below.

  /*
   * For your reference:
   *
   * SinglyLinkedListNode {
   *     int data;
   *     SinglyLinkedListNode next;
   * }
   *
   */
  static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
  {
    var cleft = head1;
    var cright = head2;

    var result = new SinglyLinkedListNode(0);
    var cur = result;

    while (cleft != null || cright != null)
    {
      SinglyLinkedListNode node = null;

      if (cleft == null)
      {
        node = new SinglyLinkedListNode(cright.data);
        cright = cright.next;

        cur.next = node;
        cur = cur.next;
        continue;
      }

      if (cright == null)
      {
        node = new SinglyLinkedListNode(cleft.data);
        cleft = cleft.next;

        cur.next = node;
        cur = cur.next;
        continue;
      }

      if (cleft.data < cright.data)
      {
        node = new SinglyLinkedListNode(cleft.data);
        cleft = cleft.next;
      }
      else
      {
        node = new SinglyLinkedListNode(cright.data);
        cright = cright.next;
      }

      cur.next = node;
      cur = cur.next;
    }

    return result.next;

  }
  /*
  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int tests = Convert.ToInt32(Console.ReadLine());

    for (int testsItr = 0; testsItr < tests; testsItr++)
    {
      SinglyLinkedList llist1 = new SinglyLinkedList();

      int llist1Count = Convert.ToInt32(Console.ReadLine());

      for (int i = 0; i < llist1Count; i++)
      {
        int llist1Item = Convert.ToInt32(Console.ReadLine());
        llist1.InsertNode(llist1Item);
      }

      SinglyLinkedList llist2 = new SinglyLinkedList();

      int llist2Count = Convert.ToInt32(Console.ReadLine());

      for (int i = 0; i < llist2Count; i++)
      {
        int llist2Item = Convert.ToInt32(Console.ReadLine());
        llist2.InsertNode(llist2Item);
      }

      SinglyLinkedListNode llist3 = mergeLists(llist1.head, llist2.head);

      PrintSinglyLinkedList(llist3, " ", textWriter);
      textWriter.WriteLine();
    }

    textWriter.Flush();
    textWriter.Close();
  }
  */
}
