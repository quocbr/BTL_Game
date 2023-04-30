using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Image fillBar;
    [SerializeField] protected TextMeshProUGUI valueText;

    public void UpdateBar(int currentValue, int maxValue)
    {
        fillBar.fillAmount = (float)currentValue/(float)maxValue;
        valueText.text = currentValue.ToString()+"/"+maxValue.ToString();
    }
}
