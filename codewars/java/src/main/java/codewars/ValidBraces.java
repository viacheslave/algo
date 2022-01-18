package codewars;

import java.util.Stack;

/*
* https://www.codewars.com/kata/5277c8a221e209d3f6000b56
* https://www.codewars.com/kata/5277c8a221e209d3f6000b56/train/java/61a6805862d240000f2a88b4
* */
public class ValidBraces {
  public class BraceChecker {

    public boolean isValid(String s) {
      var stack = new Stack<Character>();

      for (int i = 0; i < s.length(); i++) {
        var ch = s.charAt(i);
        var peek = stack.empty() ? 'a' : stack.peek();

        var popped = false;
        if (ch == ')' && peek == '(') {
          stack.pop();
          popped = true;
        }
        if (ch == ']' && peek == '[') {
          stack.pop();
          popped = true;
        }
        if (ch == '}' && peek == '{') {
          stack.pop();
          popped = true;
        }

        if (!popped)
          stack.add(ch);
      }

      return stack.empty();
    }
  }
}
