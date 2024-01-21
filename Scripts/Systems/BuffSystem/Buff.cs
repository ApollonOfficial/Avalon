using UnityEngine;

public enum BuffType : byte
{
    Poison,
    Speed,
    Resistance,
    Regeneration
}

public abstract class Buff
{
    private float _lastTime;
    private readonly string _iconName;

    public BuffType BuffType {get;}
    public BuffUI BuffUI {get; set;}
    public bool IsEndAnimActivate {get; set;} = false;

    public float LastTime => _lastTime;

    public Sprite GetIcon() => Resources.Load<Sprite>(_iconName);
    public void AddTime(float time) => _lastTime += time;

    public virtual Stats EnableBuff(Stats currentStats, BuffUI buffUI)
    {
        BuffUI = buffUI;
        return currentStats;
    }

    public virtual Stats DisableBuff(Stats currentStats, out BuffUI buffUI)
    {
        buffUI = BuffUI;
        return currentStats;
    }

    public virtual Stats Countdown(Stats currentStats)
    {
        _lastTime -= Time.deltaTime;
        if(_lastTime < 1.66f && !IsEndAnimActivate)
        {
            IsEndAnimActivate = true;
            BuffUI.PlayEndAnimation();
        }
        return currentStats;
    }

    public Buff(float lastTime, string iconName, BuffType buffType)
    {
        _lastTime = lastTime;
        _iconName = iconName;
        BuffType = buffType;
    }
}
