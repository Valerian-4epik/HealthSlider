using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _value = 10;
    private float _incrementStep = 1;

    public void ToDamage()
    {
        _slider.value -= _value;
    }

    public void ToCure()
    {
        StartCoroutine(ChangeValue(_value));
    }

    private IEnumerator ChangeValue(float value)
    {
        for(int i = 0; i < _value; i++)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _slider.value + _value, _incrementStep);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
