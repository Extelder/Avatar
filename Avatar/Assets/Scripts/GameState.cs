using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _loseCanvas;
    [SerializeField] private WorldTimer _timer;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _timer.TimerCompleated += OnTimerCompleated;
        _wallet.OnCoinsValueChanged += OnCoinValueChanged;
    }

    private void OnDisable()
    {
        _timer.TimerCompleated -= OnTimerCompleated;
        _wallet.OnCoinsValueChanged -= OnCoinValueChanged;
    }

    private void OnTimerCompleated()
    {
        Lose();
        enabled = false;
    }

    private void OnCoinValueChanged(int value)
    {
        if (_spawner.SpawnedCoins == value)
        {
            Win();
            enabled = false;
        }
    }

    public void Win()
    {
        Time.timeScale = 0;
        _winCanvas.SetActive(true);
    }

    public void Lose()
    {
        Time.timeScale = 0;
        _loseCanvas.SetActive(true);
    }
}
