using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    void IInteractable.Interaction()
    {
        Debug.Log("Interaction du switch");
    }  
}
