using System.Collections.Generic;
using UnityEngine;

public class SkillUser : MonoBehaviour
{
    public virtual Stats Stats {get;}
    public virtual Animator Animator => _animator;
    public virtual Buffeble Entity {get;}

    [SerializeField] private List<Skill> _skills = new List<Skill>();
    public List<Skill> Skills => _skills;

    protected Animator _animator;

    public virtual void ActivateSkill(int n_skill)
    {
        if(_skills[n_skill].IsRequiredEnergy(Stats.Energy) && _skills[n_skill].IsReady)
        {
            SkillSystem.ActivateSkillOnEntity(this,_skills[n_skill]);
        }
    }
}
