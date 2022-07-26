namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/design-a-food-rating-system/
///    Submission: https://leetcode.com/submissions/detail/756968723/
/// </summary>
internal class P2353
{
  public class FoodRatings
  {
    private Dictionary<string, SortedList<int, SortedSet<string>>> _data = new();
    private Dictionary<string, int> _foodRating = new();
    private Dictionary<string, string> _foodCuisine = new();

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
      for (var i = 0; i < foods.Length; i++)
      {
        var food = foods[i];
        var cuisine = cuisines[i];
        var rating = ratings[i];

        if (!_data.ContainsKey(cuisine))
          _data[cuisine] = new SortedList<int, SortedSet<string>>();

        if (!_data[cuisine].ContainsKey(rating))
          _data[cuisine][rating] = new SortedSet<string>(StringComparer.Ordinal);

        _data[cuisine][rating].Add(food);

        _foodRating[food] = rating;
        _foodCuisine[food] = cuisine;
      }
    }

    public void ChangeRating(string food, int newRating)
    {
      var currentRating = _foodRating[food];
      var cuisine = _foodCuisine[food];

      _data[cuisine][currentRating].Remove(food);

      if (_data[cuisine][currentRating].Count == 0)
        _data[cuisine].Remove(currentRating);

      if (!_data[cuisine].ContainsKey(newRating))
        _data[cuisine][newRating] = new SortedSet<string>();

      _data[cuisine][newRating].Add(food);

      _foodRating[food] = newRating;
    }

    public string HighestRated(string cuisine)
    {
      var maxRating = _data[cuisine].Keys[^1];
      return _data[cuisine][maxRating].Min;
    }
  }
}
