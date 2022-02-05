package binarysearch.templates;

import java.util.Objects;

public class Pair {
  public int item1;
  public int item2;

  public Pair(int item1, int item2) {
    this.item1 = item1;
    this.item2 = item2;
  }

  @Override
  public boolean equals(Object o) {
    if (this == o) return true;
    if (o == null || getClass() != o.getClass()) return false;
    Pair pair = (Pair) o;
    return item1 == pair.item1 && item2 == pair.item2;
  }

  @Override
  public int hashCode() {
    return Objects.hash(item1, item2);
  }
}
