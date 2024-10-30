using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] Slider _slider;

    private void Start()
    {
        _health.OnTakeDamage += ShowSlider;
        _health.OnGainHealth += ShowSlider;
        _slider.value = _health.CurrentLife;
    }

    private void ShowSlider(int amount)
    {
        _slider.value = _health.CurrentLife;
    }

    private void OnDestroy()
    {
        _health.OnTakeDamage -= ShowSlider;
        _health.OnGainHealth -= ShowSlider;
    }

}
