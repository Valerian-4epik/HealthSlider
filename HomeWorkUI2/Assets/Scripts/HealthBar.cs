using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Health _health;

    private float _incrementStep = 1;

    private void Start()
    {
        _slider.onValueChanged.AddListener((v) => { _text.text = v.ToString("0.00"); });
    }

    private void OnEnable()
    {
        _health.ChangedValue += RenderSliderValue;
    }

    private void OnDisable()
    {
        _health.ChangedValue -= RenderSliderValue;
    }

    private void RenderSliderValue(float value)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeValue(value));
    }

    private IEnumerator ChangeValue(float value)
    {
        var halfsecond = new WaitForSeconds(0.5f);
        
        while(_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _incrementStep);

            yield return halfsecond;
        }
    }
}
