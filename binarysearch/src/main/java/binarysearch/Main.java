package binarysearch;

import binarysearch.templates.Tree;
import org.json.JSONArray;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {

  public static void main(String[] arg) {
    Scanner scanner = new Scanner(System.in);

    //final int length = 2;

    //var inputArr = new ArrayList<String>();
    //for (var i = 0; i < length; i++)
    //  inputArr.add(scanner.next());

    //var p1 = getArrayOfIntegers(inputArr.get(0));
    //var p2 = getArrayOfIntegers(inputArr.get(1));

    //var p2 = getArrayOfIntegers(inputArr.get(1));
    //var p3 = getArrayOfIntegers(inputArr.get(2));
    //var p4 = getArrayOfIntegers( inputArr.get(3));

    var root = new Tree();
    root.val = 1;

    root.left = new Tree();
    root.left.val = 2;

    root.right = new Tree();
    root.right.val = 3;

    /*
    var r = new Solution().solve(new int[] {7, 3, 1, -10, 3},
      new int[][]{
        new int[] {0, 0, 3},
        new int[] {1, 3, 2},
        new int[] {2, 3, 5},
      });*/

    var r = new Solution().solve(
      "cocoplaydae"
    );

    scanner.close();
  }

  private static int[] getArrayOfIntegers(String s) {
    var json = new JSONArray(s);
    var arr = new int[json.length()];
    for (int i = 0; i < json.length(); i++) {
      arr[i] = json.getInt(i);
    }

    return arr;
  }
}

