using NaughtyAttributes;
using System.Text.RegularExpressions;
using UnityEngine;

public class PowerUp : Item
{
    [SerializeField] Health _health;
    [SerializeField, ValidateInput(nameof(ValidateGain), "_healthGained must be beetween 1 and 100 included")]
    private int _healthGained;
    private bool ValidateGain() => _healthGained > 0 && _healthGained <= 100;

    private void Reset()
    {
        _healthGained = 50;
    }

    protected override void Effect()
    {
        _health.ReceiveHealth(_healthGained);
    }


}
