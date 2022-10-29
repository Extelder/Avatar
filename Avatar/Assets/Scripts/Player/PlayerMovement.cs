using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private MovementInput _input;

    private Rigidbody _rigidBody;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake() => _rigidBody = GetComponent<Rigidbody>();

    private void OnEnable()
        =>
            Observable.EveryUpdate().Subscribe(_ =>
            {
                _rigidBody.velocity = new Vector3(_input.InputValue.x * _speed, _rigidBody.velocity.y,
                    _input.InputValue.y * _speed);
            }).AddTo(_disposable);

    private void OnDisable() => _disposable.Clear();
}