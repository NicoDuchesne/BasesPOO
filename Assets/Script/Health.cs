using NaughtyAttributes;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField, ValidateInput(nameof(ValidateMaxHealth), "_maxValue must be beetween 1 and 1000 included")]
    private int _maxLife;
    public int MaxLife => _maxLife;

    [ShowNonSerializedField] 
    private int _currentLife;

    [SerializeField] UnityEvent _onDie;

    [SerializeField] Animator _animator;

    public event Action<int> OnTakeDamage;
    public event Action<int> OnRegenHealth;
    public event Action<int> OnGainHealth;

    public int CurrentLife
    {
        get { return _currentLife; }
        set {
                if (value < 0)
                {
                    Debug.LogError("Cannot set health to a negative");
                    return;
                }
                
                _currentLife = value; 
        }
    }

    #region Editor
    private void Reset()
    {
        _maxLife = 100;
    }

    private bool ValidateMaxHealth() => _maxLife > 0 && _maxLife <= 1000;
    #endregion

    //Events
    private void Awake()
    {
        _currentLife = _maxLife;
        OnTakeDamage += TakeDamage;
        OnRegenHealth += RegenHealth;
        OnGainHealth += GainHealth;
    }

    private void OnDestroy()
    {
        OnTakeDamage -= TakeDamage;
        OnRegenHealth -= RegenHealth;
        OnGainHealth -= GainHealth;
    }

    //Regen HPs
    private void RegenHealth(int regen)
    {
        //Guard
        if (regen <= 0)
        {
            Debug.LogError("The health regenerated must be positiv");
            return;
        }

        _currentLife = Mathf.Clamp(_currentLife + regen, 0, _maxLife);
    }

    public void ReceiveRegen(int regen)
    {
        OnRegenHealth?.Invoke(regen);
    }

    //Loose HPs
    private void TakeDamage(int damage)
    {
        
        //Guard
        if (damage <= 0)
        {
            Debug.LogError("The damage taken cannot be inferior to 1");
            return;
        }

        _currentLife = Mathf.Clamp(_currentLife-damage, 0, _maxLife);

        //Death
        if (_currentLife <= 0) {
            Die();
        }
    }

    public void ReceiveDamage(int damage)
    {
        OnTakeDamage?.Invoke(damage);
    }

    private void GainHealth(int gain)
    {
        //Guard
        if (gain <= 0)
        {
            Debug.LogError("The health gained must be positiv");
            return;
        }

        _maxLife += gain;
    }

    public void ReceiveHealth(int gain)
    {
        OnGainHealth?.Invoke(gain);
    }


    //Death
    private void Die()
    {
        
        var c1 = StartCoroutine(DieRoutine());
        //dynamic : var à la JS

        //StopCoroutine(c1);
    }

    IEnumerator DieRoutine()
    {
        Debug.Log("dying");
        Destroy(GetComponent<PlayerMove>());
        _animator.SetTrigger("Die");
        
        _onDie?.Invoke();
        yield return new WaitForSeconds(2f);
        //yield return new WaitForSecondsRealtime(2f);

        Destroy(this.gameObject);
    }

    //Test buttons
    [Button]
    private void TestTakeDamage10()
    {
        OnTakeDamage?.Invoke(10);
    }

    [Button]
    private void TestGainHealth10()
    {
        OnRegenHealth?.Invoke(10);
    }


}
