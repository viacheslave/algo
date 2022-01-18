package binarysearch;

import org.json.JSONArray;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {

  public static void main(String[] arg) {
    Scanner scanner = new Scanner(System.in);

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

