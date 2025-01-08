using UnityEngine;

public class Sign : MonoBehaviour, IInteractable
{
    void IInteractable.Interaction()
    {
        Debug.Log("Interaction du sign");
    }
}
