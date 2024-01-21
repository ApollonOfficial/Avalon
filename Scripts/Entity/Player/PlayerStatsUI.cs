using UnityEngine.UI;
using UnityEngine;
using static MathsPro;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private Image _HealthBar;
    [SerializeField] private Image _EnergyBar;

    private void Awake()
    {
        PlayerStats.OnEditStats += UpdateStatsUI;
    }

    private void  OnDestroy()
    {
        PlayerStats.OnEditStats -= UpdateStatsUI;
    }

    private void UpdateStatsUI(Stats currentStats)
    {
        _HealthBar.fillAmount = DivideF(currentStats.Health, currentStats.MaxHealth);
        _EnergyBar.fillAmount = DivideF(currentStats.Energy, currentStats.MaxEnergy);
    }

}
