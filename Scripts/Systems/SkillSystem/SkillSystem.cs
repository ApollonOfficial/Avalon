using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public static event Action<Skill> PlayerSkillAdd;
    public static event Action PlayerSkillUpdate;
    private static List<Skill> _activeSkills = new List<Skill>();
    private List<SkillUser> skillUsers;

    private void Start()
    {
        skillUsers = GameObject.FindObjectsOfType<SkillUser>().ToList();
        foreach(SkillUser user in skillUsers)
        {
            foreach(Skill skill in user.Skills)
            {
                if(user == Player.player)
                {
                    PlayerSkillAdd?.Invoke(skill);
                }
                if(!skill.IsReady)
                {
                    _activeSkills.Add(skill);
                }
            }
        }
    }

    public static void ActivateSkillOnEntity(SkillUser entity, Skill skill)
    {
        _activeSkills.Add(skill);
        skill.Activate(entity);
        skill.SetTimeToReloading();
        skill.AddExpirience(50);
        entity.Stats.RemoveEnergy(skill.RequiredEnergy);
        if(entity == Player.player)
        {

        }
    }

    private void Update() 
    {
        if(GameTime.IsPause)
            return;

        for(int n_skill = 0; n_skill < _activeSkills.Count; n_skill++)
        {
            _activeSkills[n_skill].Countdown();
            PlayerSkillUpdate?.Invoke();
            if(_activeSkills[n_skill].IsReady)
            {
                _activeSkills.Remove(_activeSkills[n_skill]);
            }
        }
    }

    private SkillSystem()
    {}
}
