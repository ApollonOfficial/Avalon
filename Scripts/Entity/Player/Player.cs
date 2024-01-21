using UnityEngine;
using NaughtyAttributes;

[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ShadowerTarget))]
[RequireComponent(typeof(Movement))]

public class Player : SkillUser, IEntity
{
    public static Player player;
    private PlayerStats _playerStats;

    public override Buffeble Entity => _playerStats;
    public override Stats Stats => _playerStats.Stats;

    public Movement Movement {get; private set;}

    public float Horizontal => _joystik.Horizontal;

    [SerializeField] private Joystick _joystik;

    private void Awake() 
    {
        player = this;
        _animator = GetComponent<Animator>();
        _playerStats = GetComponent<PlayerStats>();
        Movement = GetComponent<Movement>();
    }
    [Button] public void Boost()
    {
        ActivateSkill(0);
    }

    private void Update()
    {
        Movement.MoveUpdate();
    }
}
