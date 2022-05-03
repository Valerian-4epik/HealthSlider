using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _health = 100;
    private float _value = 10;
    private float _incrementStep = 1;

    public float HealthValue => _health;

    public void ToDamage()
    {
        _health -= _value;
    }

    public void ToCure()
    {
        StartCoroutine(ChangeValue(_value));
    }

    private IEnumerator ChangeValue(float value)
    {
        for (int i = 0; i < _value; i++)
        {
            _health = Mathf.MoveTowards(_health, _health + _value, _incrementStep);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
