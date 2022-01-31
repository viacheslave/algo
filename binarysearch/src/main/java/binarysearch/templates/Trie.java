package binarysearch.templates;

import java.util.HashMap;
import java.util.Map;

public class Trie {
  private final TrieNode root = new TrieNode();

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

    public boolean isEnd() {
      return this.end;
    }

    public void setEnd() {
      this.end = true;
    }

    public TrieNode add(int ch) {
      nodes.putIfAbsent(ch, new TrieNode());
      return nodes.get(ch);
    }
  }
}
