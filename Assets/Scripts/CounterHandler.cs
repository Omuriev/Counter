using System;
using System.Collections;
using UnityEngine;

public class CounterHandler : MonoBehaviour
{
    private const int StartCounterCommand = 0;

    private bool _isPressed = false;

    private float _currentCounterValue = 0;
    private float _delay = 0.5f;
    private float _changeValueStep = 1f;

    private Coroutine _changeCounterValueCoroutine = null;

    public event Action<float> ChangedValue;

    private void Start()
    {
        ChangedValue?.Invoke(_currentCounterValue);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(StartCounterCommand))
        {
            _isPressed = !_isPressed;

            if (_changeCounterValueCoroutine != null)
                StopCoroutine(_changeCounterValueCoroutine);

            if (_isPressed == true)
                _changeCounterValueCoroutine = StartCoroutine(ChangeCounterValue());
        }
    }

    private IEnumerator ChangeCounterValue()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_delay);

        while (true)
        {
            _currentCounterValue += _changeValueStep;
            ChangedValue?.Invoke(_currentCounterValue);

            yield return waitTime;
        }
    }
}
