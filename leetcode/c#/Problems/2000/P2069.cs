namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/walking-robot-simulation-ii/
///    Submission: https://leetcode.com/submissions/detail/586577821/
/// </summary>
internal class P2069
{
  public class Robot
  {
    private (int x, int y) _pos;
    private string _face = "East";

    private readonly int _width;
    private readonly int _height;
    private readonly int _pathLength;

    private readonly Dictionary<string, string> _faces = new Dictionary<string, string>
    {
      ["East"] = "North",
      ["North"] = "West",
      ["West"] = "South",
      ["South"] = "East"
    };

    public Robot(int width, int height)
    {
      _width = width;
      _height = height;

      _pathLength = (_width * 2) + (_height * 2) - 4;
    }

    public void Move(int num)
    {
      num %= _pathLength;

      if (num == 0 && _pos == (0, 0))
        _face = "South";

      bool isInTheCorner = false;

      while (num > 0)
      {
        if (isInTheCorner)
          _face = _faces[_face];

        int corner;
        if (_face == "East")
        {
          corner = _width - _pos.x - 1;

          if (num >= corner)
          {
            _pos = (_width - 1, 0);
            num -= corner;
            isInTheCorner = true;
          }
          else
          {
            _pos = (_pos.x + num, _pos.y);
            num = 0;
            isInTheCorner = false;
          }
        }

        if (_face == "North")
        {
          corner = _height - _pos.y - 1;
          if (num >= corner)
          {
            _pos = (_width - 1, _height - 1);
            num -= corner;
            isInTheCorner = true;
          }
          else
          {
            _pos = (_pos.x, _pos.y + num);
            num = 0;
            isInTheCorner = false;
          }
        }

        if (_face == "West")
        {
          corner = _pos.x;

          if (num >= corner)
          {
            _pos = (0, _height - 1);
            num -= corner;
            isInTheCorner = true;
          }
          else
          {
            _pos = (_pos.x - num, _pos.y);
            num = 0;
            isInTheCorner = false;
          }
        }

        if (_face == "South")
        {
          corner = _pos.y;
          if (num >= corner)
          {
            _pos = (0, 0);
            num -= corner;
            isInTheCorner = true;
          }
          else
          {
            _pos = (_pos.x, _pos.y - num);
            num = 0;
            isInTheCorner = false;
          }
        }
      }
    }

    public int[] GetPos()
    {
      return new int[] { _pos.x, _pos.y };
    }

    public string GetDir()
    {
      return _face;
    }
  }

  /**
   * Your Robot object will be instantiated and called as such:
   * Robot obj = new Robot(width, height);
   * obj.Move(num);
   * int[] param_2 = obj.GetPos();
   * string param_3 = obj.GetDir();
   */
}
