using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class MovementVerTwo : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private float _forwardMoveSpeed = 1f;
    [SerializeField] private float _sidewaysMoveSpeed = 1f;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float minXPosition = -1f;
    [SerializeField] private float maxXPosition = 1f;
    Vector2 _moveDirection = Vector2.zero;

    [Header("Speed Increase Variables")]
    [SerializeField] private int _speedIncreaseIntervals = 10;
    [SerializeField] private int _secondsBetweenIntervals = 5;
    [SerializeField] private float _speedIncrease = 0.5f;
    const int SpeedAjuster = 8;


    [SerializeField] private UnityEvent _moveLeftAnimation, _moveRightAnimation, baseAnimation;
    [SerializeField] private InputAction _move;
    private void Start()
    {
        StartCoroutine(SpeedIncreases(0));
        //_moveRight.performed += ctx =>
        //{
        //    if (ctx.interaction is HoldInteraction)
        //        MovePlayer(1);
        //};
        //_moveLeft.performed += ctx => MovePlayer(-1);
    }
    //private void MovePlayer(int leftOrRight)
    //{
    //    transform.Translate(leftOrRight * _sidewaysMoveSpeed * Time.deltaTime, 0, 0);
    //}
    private void OnEnable()
    {
        _move.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, 0, _forwardMoveSpeed * Time.deltaTime);
        Vector3 currentPosition = transform.position;
        _moveDirection = _move.ReadValue<Vector2>();
        _rb.velocity = new Vector2(_moveDirection.x * _sidewaysMoveSpeed, 0);

        switch (_move.ReadValue<Vector2>().x)
        {
            case -1:
                _moveLeftAnimation.Invoke();
                break;
            case 0:
                baseAnimation.Invoke();
                break;
            case 1:
                _moveRightAnimation.Invoke();
                break;
        }
        
        Vector3 newPosition = currentPosition;
        newPosition.x = Mathf.Clamp(newPosition.x, minXPosition, maxXPosition);
        transform.position = newPosition;


        //if(transform.position.x > -2)
        //{
        //    _moveDirection.x = 0;
        //}
        //if(transform.position.x < 2)
        //{
        //    _moveDirection.x = 0;
        //}
        //if (input.getkey("a") && transform.position.x > -2)
        //{
        //    transform.translate(-_sidewaysmovespeed * time.deltatime, 0, 0);
        //}
        //if (input.getkey("d") && transform.position.x < 2)
        //{
        //    transform.translate(_sidewaysmovespeed * time.deltatime, 0, 0);
        //}
    }
    IEnumerator SpeedIncreases(int interval)
    {
        if(interval >= _speedIncreaseIntervals)
        {
            yield return null;
        } else
        {
            _forwardMoveSpeed += _speedIncrease;
            gameObject.GetComponent<Scoring>().SetSpeedMultiplier(_forwardMoveSpeed / SpeedAjuster);
            yield return new WaitForSeconds(_secondsBetweenIntervals);
            StopCoroutine(SpeedIncreases(interval++));
            StartCoroutine(SpeedIncreases(interval));
        }
    }
}
