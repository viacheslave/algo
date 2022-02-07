package dsa;

import java.util.HashMap;
import java.util.Map;

public class Trie {
  private final TrieNode root = new TrieNode();

  /**
   * Adds a char sequence (or String) to the Trie
   */
  public void add(CharSequence charSequence) {
    var pointer = root;
    for (var i = 0; i < charSequence.length(); i++) {
      pointer = pointer.add(charSequence.charAt(i) - 'a');
    }
    pointer.setEnd();
  }

  public static class TrieNode {
    private final Map<Integer, TrieNode> nodes = new HashMap<>();
    private boolean end;

    /**
     * Returns if current node is the end of any inserted word.
     *
     * @return is word ending
     */
    public boolean isEnd() {
      return this.end;
    }

    /**
     * Sets word's end.
     */
    public void setEnd() {
      this.end = true;
    }

    public TrieNode add(int ch) {
      nodes.putIfAbsent(ch, new TrieNode());
      return nodes.get(ch);
    }
  }
}
