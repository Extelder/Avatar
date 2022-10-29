using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int _maxCoinsValue;

    private int _currentValue;
    private const int _minCoinsValue = 0;

    public event Action<int> OnCoinsValueChanged;
    
    public void AddCoins(int value)
    {
        if (_currentValue + value > _maxCoinsValue)
        {
            _currentValue = _maxCoinsValue;
            OnCoinsValueChanged?.Invoke(_currentValue);
            return;
        }

        _currentValue += value;
        OnCoinsValueChanged?.Invoke(_currentValue);
    }

    public int GetCurrentCoins() => _currentValue;
}
