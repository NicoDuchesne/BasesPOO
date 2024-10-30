using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int dmg;

    private void OnTriggerEnter (Collider other)
    {
        if(other.TryGetComponent<HitZone>(out HitZone hitZone)) {
            hitZone.Damage(dmg);
        }
    }   
}
