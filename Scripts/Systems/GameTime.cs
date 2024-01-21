using UnityEngine;

public class GameTime : MonoBehaviour
{
    public static bool IsPause {get; private set;} = false;

    public void SetPauseMode()
    {
        IsPause = !IsPause;
    }

    public void SetPauseMode(bool _isPause)
    {
        IsPause = _isPause;
    }

    private GameTime()
    {}
}
