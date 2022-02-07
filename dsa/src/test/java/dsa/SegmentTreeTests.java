package dsa;

import org.junit.Assert;
import org.junit.Test;

public class SegmentTreeTests {
  private final int[] arr = new int[] {1,2,3,4,5};

  @Test
  public void sumTests() {
    SegmentTree tree = new SegmentTree(arr);

    Assert.assertEquals(1 + 2 + 3, tree.sum(0, 2));
    Assert.assertEquals(2, tree.sum(1, 1));
    Assert.assertEquals(2 + 3 + 4, tree.sum(1, 3));
    Assert.assertEquals(1 + 2 + 3 + 4 + 5, tree.sum(0, 4));
  }

  @Test
  public void updateTests() {
    SegmentTree tree = new SegmentTree(arr);

    tree.update(1, 10);

    Assert.assertEquals(10, tree.sum(1, 1));
    Assert.assertEquals(1 + 10, tree.sum(0, 1));
    Assert.assertEquals(10 + 3, tree.sum(1, 2));
  }
}
