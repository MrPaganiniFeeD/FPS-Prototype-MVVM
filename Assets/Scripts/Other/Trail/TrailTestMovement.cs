using System;
using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;

public class TrailTestMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }
    // Bad practice
    private void FixedUpdate()
    {
        var direction = _playerInput.OnFoot.Movement.ReadValue<Vector2>();
        var newDirection = (_transform.right * direction.x + _transform.forward * direction.y) * _speed * Time.deltaTime;
        _rigidbody.MovePosition(_transform.position + newDirection);
    }
    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
