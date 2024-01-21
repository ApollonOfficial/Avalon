using UnityEngine;

public class PoisonBuff : Buff
{
    private float _poisonDamage;

    public PoisonBuff(float time = 10, float poisonDamage = 1) : base(time, "Buffs/poison_buff", BuffType.Poison)
    {
        _poisonDamage = poisonDamage;
    }

    public override Stats Countdown(Stats currentStats)
    {
        currentStats.Health -= _poisonDamage*Time.deltaTime;
        return base.Countdown(currentStats);
    }
}
