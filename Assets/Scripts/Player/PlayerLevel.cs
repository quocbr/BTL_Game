using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] protected float expMax = 100;
    [SerializeField] protected float currentExp = 0;

    private void Update()
    {
        if(currentExp < expMax) return;

        currentExp = 0f;
        expMax = expMax + (int)(expMax*30f/100f);
        GameController.Instance.AddLevel();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exp"))
        {
            currentExp += other.gameObject.GetComponent<ExpSetting>().getExp();
            Destroy(other.gameObject);
        }
    }
}
