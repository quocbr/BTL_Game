using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

interface  Bar
{

    protected virtual void UpdateBar(int currentValue, int maxValue)
    {
        //fillBar.fillAmount = (float)currentValue/(float)maxValue;
    }
}