using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private SliderRenderer _slider;

    private float _health = 100;
    private float _value = 10;
    private float _incrementStep = 1;

    public float HealthValue => _health;

    public void ToDamage()
    {
        _health -= _value;
        _slider.RenderSliderValue(_health);
    }

    public void ToCure()
    {
        StartCoroutine(ChangeValue(_value));
    }

    private IEnumerator ChangeValue(float value)
    {
        var halfSecond = new WaitForSeconds(0.5f);

        for (int i = 0; i < _value; i++)
        {
            _health = Mathf.MoveTowards(_health, _health + _value, _incrementStep);
            _slider.RenderSliderValue(_health);

            yield return halfSecond;
        }
    }
}
