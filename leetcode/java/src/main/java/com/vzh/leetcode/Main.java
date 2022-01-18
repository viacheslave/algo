package com.vzh.leetcode;

import org.json.JSONArray;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {

  public static void main(String[] arg) {
    Scanner scanner = new Scanner(System.in);

    //final int length = 1;

    //var inputArr = new ArrayList<String>();
    //for (var i = 0; i < length; i++)
    //  inputArr.add(scanner.next());

    //var p1 = inputArr.get(0);
    //var p2 = Integer.parseInt(inputArr.get(1));

    //var p2 = getArrayOfIntegers(inputArr.get(1));
    //var p3 = getArrayOfIntegers(inputArr.get(2));
    //var p4 = getArrayOfIntegers( inputArr.get(3));
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

  private static int[][] getArrayOfIntegers2(String s) {
    var json = new JSONArray(s);
    var arr = new int[json.length()][];
    for (int i = 0; i < json.length(); i++) {
      var inner = json.getJSONArray(i);
      var innerArr = new int[inner.length()];
      for (int j = 0; j < inner.length(); j++) {
        innerArr[j] = inner.getInt(j);
      }

      arr[i] = innerArr;
    }

    return arr;
  }
}
