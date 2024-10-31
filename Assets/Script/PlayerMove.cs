using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static Codice.Client.Commands.WkTree.WorkspaceTreeNode;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveInput;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField, ValidateInput(nameof(ValidateSpeed), "_maxValue must be beetween 1 and 3000 included")]
    private float _speed;

    [SerializeField] private bool _isCameraBased;
    [SerializeField, ShowIf("_isCameraBased")] Camera _cam;

    Coroutine _movementRoutine;
    private bool ValidateSpeed() => _speed > 0 && _speed <= 3000;

    private void Reset()
    {
        _speed = 1000;
    }

    private void Start()
    {
        _moveInput.action.started += StartMove;
        _moveInput.action.performed += MovePerformed;
        _moveInput.action.canceled += StopMove;
    }

    private void OnDestroy()
    {
        _moveInput.action.started -= StartMove;
        _moveInput.action.performed -= MovePerformed;
        _moveInput.action.canceled -= StopMove;
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        Debug.Log("Start");
        _animator.SetBool("IsRunning", true);

        _movementRoutine = StartCoroutine(Move());

        IEnumerator Move()
        {
            while (true)
            {
                var joystickDir = obj.ReadValue<Vector2>();

                //World Direction
                Vector3 realDirection = Vector3.zero;

                if (_isCameraBased) //The camera can imply the character direction
                {
                    realDirection = _cam.transform.forward * joystickDir.y + _cam.transform.right * joystickDir.x;
                    realDirection.Normalize();
                    realDirection.y = 0;
                } 
                else //move freely in world space
                {
                    realDirection = new Vector3(joystickDir.x, 0, joystickDir.y);
                }

                //Apply force for the movement
                _rb.AddForce(realDirection * _speed * Time.deltaTime);

                //Rotate Character in direction
                transform.LookAt(transform.position + realDirection);

                yield return new WaitForFixedUpdate();
            }

        }
    }

    private void MovePerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Perform");
    }

    private void StopMove(InputAction.CallbackContext obj)
    {
        Debug.Log("Cancel");
        StopCoroutine(_movementRoutine);
        _animator.SetBool("IsRunning", false);
    }
}
