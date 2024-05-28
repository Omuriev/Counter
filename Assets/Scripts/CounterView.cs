using System.Collections;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private CounterHandler _counterHandler;

    private float _currentCounterValue = 0;
    private float _delay = 0.5f;
    private float _changeValueStep = 1f;

    private Coroutine _changeCounterValueCoroutine = null;

    private void OnEnable() => _counterHandler.StartedCounter += ChangeValue;
    private void OnDisable() => _counterHandler.StartedCounter -= ChangeValue;

    private void ChangeValue(bool isPressed)
    {
        if (_changeCounterValueCoroutine != null)
            StopCoroutine(_changeCounterValueCoroutine);

        if (isPressed == true)
            _changeCounterValueCoroutine = StartCoroutine(ChangeCounterValue());
    }

    private IEnumerator ChangeCounterValue()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_delay);

        while (true)
        {
            _currentCounterValue += _changeValueStep;
            _counterText.text = _currentCounterValue.ToString();

            yield return waitTime;
        }
    }
}
