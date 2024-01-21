using System;
using UnityEngine;
public enum SkillType : byte
{
    Regeneration
}
public abstract class Skill : ScriptableObject
{
    public event Action<Skill> SetNextSkill;
    public readonly SkillType Type;

    [SerializeField] private Sprite _Icon;
    [SerializeField] private Skill _NextSkillOnTree;

    [SerializeField] private int _Expirience = 0;
    [SerializeField] private int _RequiredExpirience = 0;
    [SerializeField] private int _RequiredEnergy = 0;
    [SerializeField] private float _RequiredTimeToReloading = 0;
    [SerializeField] private float _timeToReloading = 0;
    private SkillUI _skillUI;
    
    public bool IsRequiredExpirience => _Expirience >= _RequiredExpirience;
    public int RequiredEnergy => _RequiredEnergy;
    public bool IsReady => _timeToReloading <= 0;
    public float CooldownAmount => _timeToReloading/_RequiredTimeToReloading;
    public Skill NextSkillOnTree => _NextSkillOnTree;
    public Sprite Icon => _Icon;

    public bool IsRequiredEnergy(int count) => count >= _RequiredEnergy;
    public void SetTimeToReloading() => _timeToReloading = _RequiredTimeToReloading;
    public void SetSkillUI(SkillUI skillUI) => _skillUI = skillUI;
    public SkillUI GetSkillUI() => _skillUI;

    public abstract void Activate(SkillUser skillUser);
    
    public virtual void Countdown()
    {
        if(_timeToReloading > 0)
        {
            _timeToReloading -= Time.deltaTime;
        }
        if(IsReady)
        {
            _timeToReloading = 0;
        }
    }

    public void AddExpirience(int count)
    {
        _Expirience += count;
        if(IsRequiredExpirience)
            SetNextSkill?.Invoke(NextSkillOnTree);
    }

    public Skill(SkillType type)
    {
        Type = type;
    }
}
