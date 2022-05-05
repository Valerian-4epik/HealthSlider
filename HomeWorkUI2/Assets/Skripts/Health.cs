using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    private float _health = 100;
    private float _maxHealth = 100;
    private float _minHealth = 0;
    private float _value = 10;

    public Action<float> ChangedValue;

    public void ToDamage()
    {
        _health = Mathf.Clamp(_health-_value, _minHealth, _maxHealth);
        ChangedValue?.Invoke(_health);
    }

    public void ToCure()
    {
        _health = Mathf.Clamp(_health+_value, _minHealth, _maxHealth);
        ChangedValue?.Invoke(_health);       
    }
}
