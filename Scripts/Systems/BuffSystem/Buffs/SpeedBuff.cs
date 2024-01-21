public class SpeedBuff : Buff
{
    private float _speedBoost;

    public SpeedBuff(float time = 5, float speedBoost = 10) : base(time, "Buffs/speed_buff", BuffType.Speed)
    {
        _speedBoost = speedBoost;
    }

    public override Stats DisableBuff(Stats currentStats, out BuffUI buffUI)
    {
        currentStats.Speed -= _speedBoost;
        return base.DisableBuff(currentStats, out buffUI);
    }

    public override Stats EnableBuff(Stats currentStats, BuffUI buffUI)
    {
        currentStats.Speed += _speedBoost;
        return base.EnableBuff(currentStats, buffUI);
    }
}
