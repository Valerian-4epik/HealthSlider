using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScripts : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    
    private void Start()
    {
        _slider.onValueChanged.AddListener((v) => { _text.text = v.ToString("0.00"); });
    }
}