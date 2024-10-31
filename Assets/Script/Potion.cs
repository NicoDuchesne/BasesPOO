using NaughtyAttributes;
using UnityEngine;

public class Potion : Item
{
    [SerializeField] Health _health;
    [SerializeField, ValidateInput(nameof(ValidateRegen), "_regen must be beetween 1 and 100 included")]
    private int _regen;

    private bool ValidateRegen() => _regen > 0 && _regen <= 100;

    private void Reset()
    {
        _regen = 25;
    }

    protected override void Effect()
    {
        _health.ReceiveRegen(_regen);
    }
    
    
}
