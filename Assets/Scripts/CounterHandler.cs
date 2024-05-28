using System;
using UnityEngine;

public class CounterHandler : MonoBehaviour
{
    private bool _isPressed = false;

    public event Action<bool> StartedCounter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isPressed = !_isPressed;

            StartedCounter?.Invoke(_isPressed);
        }
    }
}
