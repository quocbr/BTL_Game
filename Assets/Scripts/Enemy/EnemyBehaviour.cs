using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] protected float hitPoint;
    [SerializeField] protected float maxHitPoint = 5f;
    [SerializeField] protected int currentExp = 3;
    [SerializeField] protected GameObject Exp;

    private void Start()
    {
        hitPoint = maxHitPoint;
    }

    private void Update()
    {
        if (IsDead() == true)
        {
             GameObject exp = Instantiate(Exp, this.transform.position, Quaternion.identity);
                    int target = currentExp * (GameController.Instance.Level - 1) * 20 / 100;
                    exp.GetComponent<ExpSetting>().SetExp(currentExp + target);
                    GameController.Instance.AddKillEnemy(1);
                    Destroy(this.gameObject);
        }
        
    }
    

    public void DeHealth(float damage)
    {
        hitPoint -= damage;
        if(hitPoint < 0f) hitPoint = 0f;
    }

    protected bool IsDead()
    {
        return hitPoint <= 0;
    }
}
