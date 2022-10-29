using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWalletUI : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _wallet.OnCoinsValueChanged += OnCoinsValueChanged;
    }

    private void OnDisable()
    {
        _wallet.OnCoinsValueChanged -= OnCoinsValueChanged;
    }

    public void OnCoinsValueChanged(int value)
    {
        _text.text = value.ToString();
    }
}
