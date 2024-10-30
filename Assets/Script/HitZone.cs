using UnityEngine;

public class HitZone : MonoBehaviour
{
    [SerializeField] Health _health;

    public void Damage(int damage)
    {
        _health.ReceiveDamage(damage); 
    }
}
