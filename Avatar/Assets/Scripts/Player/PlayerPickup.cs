using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private WorldTimer _worldTimer;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet.AddCoins(1);
            Destroy(coin.gameObject);
        }

        if (other.gameObject.TryGetComponent<TimeAddBonus>(out TimeAddBonus timeAddBonus))
        {
            _worldTimer.AddTime(timeAddBonus.Seconds);
            Destroy(timeAddBonus.gameObject);
        }
    }
}
