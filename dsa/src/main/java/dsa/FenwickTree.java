package dsa;

public class FenwickTree {
  private final int[] tree;

  /**
   * Constructs new Fenwick Tree (binary indexed tree)
   *
   * @param arr source array
   */
  public FenwickTree(int[] arr) {
    tree = new int[arr.length + 1];

    System.arraycopy(arr,
      0, tree,
      1, arr.length);

    for (var i = 1; i < tree.length; i++) {
      var parent = i + lsb(i);

      if (parent < tree.length)
        tree[parent] += tree[i];
    }
  }

  /**
   * Returns sum of elements [from, to]
   *
   * @param from - start el (1-based)
   * @param to - end el (1-based)
   * @return range sum
   */
  public int sum(int from, int to) {
    if (from == 1)
      return sum(to);
    return sum(to) - sum(from - 1);
  }

  /**
   * Add a value to an item at index
   *
   * @param index - el index
   * @param value - el extra value
   */
  public void add(int index, int value) {
    var i = index;
    while (i < tree.length) {
      tree[i] += value;
      i = i + lsb(i);
    }
  }

  /**
   * Updates a value at index
   *
   * @param index - el index
   * @param value - el extra value
   */
  public void set(int index, int value) {
    var diff = value - tree[index];
    add(index, diff);
  }

  private int sum(int to) {
    var value = 0;
    while (to > 0) {
      value += tree[to];
      var lsb = lsb(to);
      to -= lsb;
    }
    return value;
  }

  private int lsb(int i) {
    return Integer.lowestOneBit(i);
  }
}
