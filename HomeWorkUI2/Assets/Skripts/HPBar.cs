using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;

    private float _incrementStep = 1;

    private void Start()
    {
        _slider.onValueChanged.AddListener((v) => { _text.text = v.ToString("0.00"); });
    }

    private void OnEnable()
    {
        Health.changeValue += RenderSliderValue;
    }

    private void OnDisable()
    {
        Health.changeValue -= RenderSliderValue;
    }

    private void RenderSliderValue(float value)
    {
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
