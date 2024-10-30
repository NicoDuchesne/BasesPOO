using UnityEngine;

public class PowerUp : Item
{
    [SerializeField] Health _health;
    [SerializeField] private int _healthGained;

    protected override void Effect()
    {
        _health.ReceiveHealth(_healthGained);
    }


}
