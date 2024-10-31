using NaughtyAttributes;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField, ValidateInput(nameof(ValidateDamage), "dmg must be beetween 1 and 1000 included")]
    private int _dmg;

    private bool ValidateDamage() => _dmg > 0 && _dmg <= 100;

    private void Reset()
    {
        _dmg = 50;
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.TryGetComponent<HitZone>(out HitZone hitZone)) {
            hitZone.Damage(_dmg);
        }
    }   
}
