using System.Collections;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private CounterHandler _counterHandler;

    private void OnEnable() => _counterHandler.ChangedValue += ChangeValue;
    private void OnDisable() => _counterHandler.ChangedValue -= ChangeValue;

    private void ChangeValue(float value)
    {
        _counterText.text = value.ToString();
    }
}
