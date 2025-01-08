using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private Health _health;
    [SerializeField] private int _regen;
    
    void IInteractable.Interaction()
    {
        Debug.Log("Interaction du chest");
        _health.ReceiveRegen(_regen);
    }
}
