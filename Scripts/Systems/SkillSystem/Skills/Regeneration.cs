using UnityEngine;

[CreateAssetMenu(fileName = "Regeneration", menuName = "Skills/New Regeneration")]
public class Regeneration : Skill
{
    public Regeneration() : base(SkillType.Regeneration)
    {}

    [Header("Skill Settings")]
    [SerializeField] private float _speed;

    public override void Activate(SkillUser skillUser)
    {
        BuffSystem.buffSystem.AddBuffOnEntity(skillUser.Entity, new SpeedBuff(5,_speed));
        BuffSystem.buffSystem.AddBuffOnEntity(skillUser.Entity, new PoisonBuff(6));
    }
}
