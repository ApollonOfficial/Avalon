using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private Image _Icon;
    [SerializeField] private Image _CooldownImage;
    private Skill _skill;
    private SkillUser skillUser => Player.player;
    private event Action<SkillUser, Skill> _activateSkill;

    public void SetSkill(Skill skill)
    {
        _skill = skill;
        _activateSkill+= SkillSystem.ActivateSkillOnEntity;;
        SetIcon(skill.Icon);
    }

    private void SetIcon(Sprite icon)
    {
        _Icon.sprite = icon;
        _CooldownImage.sprite = icon;
    }

    public void Countdown()
    {
        _CooldownImage.fillAmount = _skill.CooldownAmount;
    }

    public void ActivateSkill()
    {
        _activateSkill?.Invoke(skillUser, _skill);
    }

}
