package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Embolden
 * Submission: https://binarysearch.com/problems/Embolden/submissions/6646418
 */
public class P0425 {
  class Solution {
    public String solve(String text, String[] patterns) {
      var mask = new int[text.length()];

      for (var pattern : patterns) {
        var start = 0;
        while (true) {
          var index = text.indexOf(pattern, start);
          if (index == -1)
            break;

          for (var j = 0; j < pattern.length(); j++) {
            mask[index + j] = 1;
          }

          start = index + 1;
        }
      }

      var sb = new StringBuilder();

      for (var i = 0; i < mask.length; i++) {
        if (i > 0 && mask[i] == 1 && mask[i - 1] == 0) {
          sb.append("<b>");
        }

        if (i > 0 && mask[i] == 0 && mask[i - 1] == 1) {
          sb.append("</b>");
        }

        sb.append(text.charAt(i));
      }

      if (mask[0] == 1)
        sb.insert(0, "<b>");
      if (mask[mask.length - 1] == 1)
        sb.append("</b>");

      return sb.toString();
    }
  }
}