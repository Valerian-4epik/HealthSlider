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

    public static Action<float> changeValue;

    public void ToDamage()
    {
        if (_health > _minHealth)
        {
            if(_health < _value)
            {
                _health = _minHealth;
            }
            else
            {
               _health -= _value;
            }
            
            changeValue?.Invoke(_health);
        }        
    }

    public void ToCure()
    {
        if (_health < _maxHealth)
        {
            if(_health+_value > _maxHealth)
            {
                _health = _maxHealth;
            }
            else
            {
                _health += _value;
            }
            
            changeValue?.Invoke(_health);
        }        
    }
}
