using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine.Events;

public class PlayerStats : Buffeble
{
    public static event UnityAction<Stats> OnEditStats;

    public Stats Stats => _currentStats;
    public override List<Buff> ActiveBuffs { get => _activeBuffs; set => _activeBuffs = value; }
    public override Transform BuffTable => _BuffTable;

    [SerializeField] private Transform _BuffTable;

    private Stats _baseStats;
    private Stats _currentStats;
    private List<Buff> _activeBuffs = new List<Buff>();

    private void OnEnable()
    {
        InventorySystem.EnableArtifact += EnableModificateStatsByArtifact;
        InventorySystem.DisableArtifact += DisableModificateStatsByArtifact;
    }
    private void OnDisable()
    {
        InventorySystem.EnableArtifact -= EnableModificateStatsByArtifact;
        InventorySystem.DisableArtifact -= DisableModificateStatsByArtifact;
    }

    private void Awake()
    {
        _baseStats = new Stats(7,15,10,100,100,1);
        _currentStats = _baseStats;
    }

    void Start()
    {
        OnEditStats?.Invoke(Stats);
    }

    public override void AddBuff(Buff buff, BuffUI buffUI)
    {
        _currentStats = buff.EnableBuff(_currentStats, buffUI);
        _activeBuffs.Add(buff);
        base.SetBuffUI(buff,buffUI);
        OnEditStats?.Invoke(Stats);
    }

    public override void RemoveBuff(Buff buff, out BuffUI buffUI)
    {
        _activeBuffs.Remove(buff);
        _currentStats = buff.DisableBuff(_currentStats, out BuffUI _buffUI);
        buffUI = _buffUI;
        OnEditStats?.Invoke(Stats);
    }

    public override void Countdown(Buff buff)
    {
        _currentStats = buff.Countdown(_currentStats);
        OnEditStats?.Invoke(Stats);
    }

    private void EnableModificateStatsByArtifact(Stats modificate)
    {
        
    }
    private void DisableModificateStatsByArtifact(Stats modificate)
    {

    }
}
