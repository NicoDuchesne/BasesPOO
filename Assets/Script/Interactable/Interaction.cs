using UnityEngine;

public class Interaction : MonoBehaviour
{
    private BoxCollider collider;

    public void Awake()
    {
        if (TryGetComponent(out BoxCollider c))
        {
            collider = c;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            interactable.Interaction();
        }
    }
}
