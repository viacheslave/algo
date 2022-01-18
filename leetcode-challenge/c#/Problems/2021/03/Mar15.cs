using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-3-march-15th-march-21st/3673/
  ///   
  /// </summary>
  internal class Mar15
  {
    public class Codec
    {

      // Encodes a URL to a shortened URL
      public string encode(string longUrl)
      {
        return "http://tinyurl.com/" + Convert.ToBase64String(Encoding.Unicode.GetBytes(longUrl));
      }

      // Decodes a shortened URL to its original URL.
      public string decode(string shortUrl)
      {
        var encoded = shortUrl.Substring(19);
        return Encoding.Unicode.GetString(Convert.FromBase64String(encoded));
      }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.decode(codec.encode(url));
  }
}
