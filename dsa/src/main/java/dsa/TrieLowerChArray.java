package dsa;

public class TrieLowerChArray {
  private final  TrieNode root = new TrieNode();

  public void add(CharSequence charSequence) {
    var pointer = root;
    for (var i = 0; i < charSequence.length(); i++) {
      pointer = pointer.add(charSequence.charAt(i) - 'a');
    }
    pointer.setEnd();
  }

  public static class TrieNode {
    private final TrieNode[] nodes = new TrieNode[26];
    private boolean end;

    public boolean isEnd() {
      return this.end;
    }

    public void setEnd() {
      this.end = true;
    }

    public TrieNode add(int ch) {
      if (nodes[ch] == null) {
        nodes[ch] = new TrieNode();
      }
      return nodes[ch];
    }
  }
}
