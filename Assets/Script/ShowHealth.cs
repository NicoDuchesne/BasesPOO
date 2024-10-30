using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class ShowHealth : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] Slider _slider;

    private RectTransform _lifeBar;
    private int _initialLifeBarSize = 300;
    private int _lifeBarSize;
    private int _initialLife;

    private void Awake()
    {
        _lifeBar = GameObject.Find("Lifebar").GetComponent<RectTransform>();
    }

    private void Start()
    {
        _health.OnTakeDamage += ShowSlider;
        _health.OnRegenHealth += ShowSlider;
        _health.OnGainHealth += UpdateSlider;
        _slider.value = _health.CurrentLife;

        _initialLife = _health.CurrentLife;
        _lifeBarSize = _initialLifeBarSize;
    }

    private void ShowSlider(int amount)
    {
        _slider.value = _health.CurrentLife;
    }

    private void UpdateSlider(int amount)
    {
        _slider.maxValue = _health.MaxLife;


        float temp = _lifeBarSize + ((float)amount / (float)_initialLife * (float)_initialLifeBarSize);
        _lifeBarSize = (int)temp;

        if(_lifeBarSize < 1900)
        {
            _lifeBar.sizeDelta = new Vector2(_lifeBarSize, 40);
        }
        

        
    }

    private void OnDestroy()
    {
        _health.OnTakeDamage -= ShowSlider;
        _health.OnGainHealth -= ShowSlider;
        _health.OnGainHealth += UpdateSlider;
    }

}
