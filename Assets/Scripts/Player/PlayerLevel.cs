using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] protected int expMax = 100;
    [SerializeField] protected int currentExp = 0;
    [SerializeField] protected ExpBar expBar;
    
    void Start()
    {
        currentExp = 0;
        expBar.SetMaxExp(expMax);
    }
    private void Update()
    {
        if(currentExp < expMax) return;

        currentExp = 0;
        expMax = expMax + (int)(expMax*30f/100f);
        expBar.SetMaxExp(expMax);
        
        UIManager.Instance.SetActivePanelLevelUp(true);
        GameController.Instance.AddLevel();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exp"))
        {
            currentExp += other.gameObject.GetComponent<ExpSetting>().getExp();
            expBar.SetExp(currentExp);
            Destroy(other.gameObject);
        }
    }
}
