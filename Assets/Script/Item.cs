using NaughtyAttributes;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField, Tag] private string targetedTag;
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag(targetedTag))
        {
            Effect();
        }
    }

    protected abstract void Effect();
}
