using UnityEngine;

public class Potion : Item
{
    [SerializeField] Health _health;
    [SerializeField] private int _regen;

    protected override void Effect()
    {
        _health.ReceiveHealth(_regen);
    }
    
    
}
