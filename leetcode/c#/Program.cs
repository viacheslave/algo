using System.IO;
using LeetCode.Naive;
using Newtonsoft.Json;

public class Program
{
  public static void Main()
  {
    var root = new TreeNode(1);
    root.left = new TreeNode(4);
    root.right = new TreeNode(3);

    root.left.left = new TreeNode(7);
    root.left.right = new TreeNode(6);

    root.right.left = new TreeNode(8);
    root.right.right = new TreeNode(5);

    var ln = new ListNode(5);
    ln.next = new ListNode(2);
    ln.next.next = new ListNode(13);
    ln.next.next.next = new ListNode(3);
    ln.next.next.next.next = new ListNode(8);

    var param1 = JsonConvert.DeserializeObject<int[][]>("[[0,1],[1,2],[1,3],[3,4],[3,5]]");

    var arrStr = File.ReadAllText("./../../../json");
    var arr = JsonConvert.DeserializeObject<int[][]>(arrStr);
  }
}
