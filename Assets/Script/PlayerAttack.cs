using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static Codice.Client.Commands.WkTree.WorkspaceTreeNode;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private InputActionReference _attackInput;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _attack;

    Coroutine _attackRoutine;
    private void Awake()
    {
        _attack.SetActive(false);
    }

    private void Start()
    {
        _attackInput.action.started += StartAttack;
        _attackInput.action.performed += AttackPerformed;
        _attackInput.action.canceled += StopAttack;
    }

    private void OnDestroy()
    {
        _attackInput.action.started -= StartAttack;
        _attackInput.action.performed -= AttackPerformed;
        _attackInput.action.canceled -= StopAttack;
    }

    private void StartAttack(InputAction.CallbackContext obj)
    {
        Debug.Log("Attack");
        _animator.SetBool("IsAttacking", true);
        _attack.SetActive(true);
        _attackRoutine = StartCoroutine(Attack());


        IEnumerator Attack()
        {
            while (true)
            {
                Debug.Log("Attacking");
                yield return new WaitForFixedUpdate();
            }
        }
    }

    private void AttackPerformed(InputAction.CallbackContext obj)
    {
    }

    private void StopAttack(InputAction.CallbackContext obj)
    {
        StopCoroutine(_attackRoutine);
        _animator.SetBool("IsAttacking", false);
        _attack.SetActive(false);
    }
}
