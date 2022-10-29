using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class WorldTimer : MonoBehaviour
{
    [SerializeField] private int _startTimerValueInSeconds;

    public event Action TimerCompleated;
    public ReactiveProperty<int> CurrentTimeInSecond { get; private set; } = new ReactiveProperty<int>();

    private void Awake() => CurrentTimeInSecond.Value = _startTimerValueInSeconds;

    private void OnEnable()
    {
        StartCoroutine(Timing());
    }

    private void OnDisable() => StopAllCoroutines();

    private IEnumerator Timing()
    {
        while (true)
        {
            CurrentTimeInSecond.Value -= 1;
            if (CurrentTimeInSecond.Value <= 0)
            {
                TimerCompleated?.Invoke();
                enabled = false;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void AddTime(int seconds)
    {
        if (CurrentTimeInSecond.Value + seconds > _startTimerValueInSeconds)
        {
            CurrentTimeInSecond.Value = _startTimerValueInSeconds;
            return;
        }

        CurrentTimeInSecond.Value += seconds;
    }
}