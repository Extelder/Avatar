using System;
using TMPro;
using UnityEngine;
using UniRx;

public class WorldTimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private WorldTimer _timer;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnEnable()
        =>
            _timer.CurrentTimeInSecond.Subscribe(_ =>
            {
                if (_ <= 0)
                    enabled = false;
                _text.text = _.ToString();
            }).AddTo(_disposable);

    private void OnDisable() => _disposable.Clear();
}