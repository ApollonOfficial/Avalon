using System.Collections.Generic;
using UnityEngine;

public class UISkillSystem : MonoBehaviour
{
    private List<SkillUI> _activeSkillsUI = new List<SkillUI>();
    private Queue<SkillUI> _skillsUI = new Queue<SkillUI>();
    [SerializeField] private Transform _PoolUI;
    [SerializeField] private Transform _SkillPanel;
    [SerializeField] private SkillUI _PrefabSkillUI;

    private void Awake()
    {
        SkillSystem.PlayerSkillAdd += AddPlayerSkill;
        SkillSystem.PlayerSkillUpdate += UpdateUI;
        for(int n_skillsUI = 0; n_skillsUI < 6; n_skillsUI++)
        {
            _skillsUI.Enqueue(Instantiate(_PrefabSkillUI, _PoolUI));
        }
    }

    private void OnDestroy()
    {
        SkillSystem.PlayerSkillAdd -= AddPlayerSkill;
        SkillSystem.PlayerSkillUpdate -= UpdateUI;
    }

    private void UpdateUI()
    {
        foreach(SkillUI skillUI in _activeSkillsUI)
        {
            skillUI.Countdown();
        }
    }

    private void AddPlayerSkill(Skill skill)
    {
        if(_skillsUI.TryDequeue(out SkillUI UI))
        {
            UI.SetSkill(skill);
            skill.SetSkillUI(UI);
            UI.transform.SetParent(_SkillPanel);
            UI.transform.localScale = Vector3.one;
            _activeSkillsUI.Add(UI);
        }
    }
}
