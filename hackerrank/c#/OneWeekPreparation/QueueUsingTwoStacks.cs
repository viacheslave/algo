using System;
using System.Collections.Generic;
using System.IO;

namespace HackerRank.QueueUsingTwoStacks;

class Solution
{
  /*
  static void Main(String[] args)
  {
    var count = int.Parse(Console.ReadLine());

    var q = new Q();

    for (var i = 0; i < count; i++)
    {
      var values = Console.ReadLine().Split(' ');

      if (values[0] == "1")
        q.Enqueue(int.Parse(values[1]));

      if (values[0] == "2")
        q.Dequeue();

      if (values[0] == "3")
        Console.WriteLine(q.Print());
    }
  }
  */
}

public class Q
{
  public Stack<int> sin = new Stack<int>();
  public Stack<int> sout = new Stack<int>();

  public void Enqueue(int x)
  {
    sin.Push(x);
  }

  public void Dequeue()
  {
    if (sout.Count > 0)
    {
      sout.Pop();
      return;
    }

    Rebalance();
    sout.Pop();
  }

  public int Print()
  {
    if (sout.Count > 0)
      return sout.Peek();

    Rebalance();

    if (sout.Count > 0)
      return sout.Peek();

    return -1;
  }

  private void Rebalance()
  {
    var temp = new Stack<int>();

    while (sout.Count > 0)
      temp.Push(sout.Pop());

    while (sin.Count > 0)
      sout.Push(sin.Pop());

    while (temp.Count > 0)
      sout.Push(temp.Pop());

  }
}

