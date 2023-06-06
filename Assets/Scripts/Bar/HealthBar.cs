using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Slider slider;
    [SerializeField]protected Gradient gradient;
    [SerializeField]protected Image fill;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void AddMaxHealth(float health)
    {
        float temp = slider.maxValue;
        slider.maxValue = health;
        slider.value += slider.maxValue - temp;
        
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetHeart(float health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
