using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public enum InputType
{
    KeyBoard,
    Joystick
}

public class MovementInput : MonoBehaviour
{
    [SerializeField] private InputType _inputType;
    [SerializeField] private Joystick _joystick;

    private CompositeDisposable _disposable = new CompositeDisposable();
    public Vector2 InputValue { get; private set; } = new Vector2(0, 0);

    private void OnEnable()
        =>
            Observable.EveryUpdate().Subscribe(_ =>
            {
                switch (_inputType)
                {
                    case InputType.Joystick:
                        InputValue = new Vector2(_joystick.Horizontal, _joystick.Vertical);
                        break;
                    case InputType.KeyBoard:
                        InputValue = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                        break;
                }
            }).AddTo(_disposable);

    private void OnDisable() => _disposable.Clear();
}