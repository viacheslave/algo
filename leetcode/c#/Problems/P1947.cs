namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-compatibility-score-sum/
///    Submission: https://leetcode.com/submissions/detail/528018459/
/// </summary>
internal class P1947
{
  public class Solution
  {
    public int MaxCompatibilitySum(int[][] students, int[][] mentors)
    {
      // calculate all pairs
      var pairs = new Dictionary<(int student, int mentor), int>();

      for (var i = 0; i < students.Length; i++)
      {
        for (var j = 0; j < mentors.Length; j++)
        {
          var sa = students[i];
          var ma = mentors[j];

          pairs[(i, j)] = Enumerable.Range(0, sa.Length)
            .Select(k => sa[k] == ma[k] ? 1 : 0)
            .Sum();
        }
      }

      var studentsSet = Enumerable.Range(0, students.Length).ToList();
      var mentorsSet = Enumerable.Range(0, mentors.Length).ToList();

      var ans = new int[1];
      var current = 0;

      CalcPermutations(pairs, studentsSet, mentorsSet, ans, current);

      return ans[0];
    }

    private void CalcPermutations(Dictionary<(int student, int mentor), int> pairs, List<int> studentsSet, List<int> mentorsSet, int[] ans, int current)
    {
      if (studentsSet.Count == 0)
      {
        ans[0] = Math.Max(ans[0], current);
        return;
      }

      for (var j = 0; j < mentorsSet.Count; j++)
      {
        var value = pairs[(studentsSet[0], mentorsSet[j])];

        current += value;

        var st = studentsSet.ToList();
        var mt = mentorsSet.ToList();

        st.Remove(studentsSet[0]);
        mt.Remove(mentorsSet[j]);

        CalcPermutations(pairs, st, mt, ans, current);

        current -= value;
      }
    }
  }
}
