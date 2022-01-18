package codewars;

/*
* https://www.codewars.com/kata/593ff8b39e1cc4bae9000070
* https://www.codewars.com/kata/593ff8b39e1cc4bae9000070/train/java/61a7d09a62d240001670e9dd
* */
public class LongestCommonSubsequencePerformanceVersion {
  class Lcs {

    static String lcs(String str1, String str2) {
      var dp = new String[str1.length() + 1][str2.length() + 1];

      for (var i = 0; i <= str1.length(); i++)
        dp[i][0] = "";

      for (var j = 0; j <= str2.length(); j++)
        dp[0][j] = "";

      for (var i = 0; i < str1.length(); i++)
        for (var j = 0; j < str2.length(); j++)
          dp[i + 1][j + 1] = str1.charAt(i) == str2.charAt(j)
            ? dp[i][j] + str1.charAt(i)
            : dp[i + 1][j].length() > dp[i][j + 1].length()
            ? dp[i + 1][j]
            : dp[i][j + 1];

      return dp[str1.length()][str2.length()];
    }
  }
}
