
[System.Serializable] public class Stats
{
    public float Speed;
    public float JumpForce;
    public float SlopeForce;
    public float Health
    {
        get => _health;
        set
        {
            if(value >= 0 && value <= MaxHealth)
                _health = value;
        }
    }
    private float _health;
    public int MaxHealth;
    private int _energy;
    public int Energy
    {
        get => _energy;
        set
        {
            if(value >= 0 && value <= MaxEnergy)
                _energy = value;
        }
    }
    public int MaxEnergy;
    public float DamageIndex 
    {
        get => _damageIndex; 
        set 
        { 
            if(value > 0 && value < 10)
                _damageIndex = value;
        }
    }
    private float _damageIndex;

    public void RemoveEnergy(int count)
    {
        Energy -= count;
    }

    public Stats(float speed=5, float jumpForce=10, float slopeForce=10, int health=100, int energy=100, int damageIndex=1)
    {
        Speed = speed;
        JumpForce = jumpForce;
        SlopeForce = slopeForce;
        MaxHealth = health;
        Health = MaxHealth;
        MaxEnergy = energy;
        Energy = MaxEnergy;
        DamageIndex = damageIndex;
    }
}
