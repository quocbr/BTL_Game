using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] protected float hitPoint;
    [SerializeField] protected float maxHitPoint = 5f;
    [SerializeField] protected int currentExp = 3;
    [SerializeField] protected GameObject Exp;
    [SerializeField] protected GameObject Hp;
    [SerializeField] protected GameObject fxDead;

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

            int randomNumber = Random.Range(0, 100);
            if (randomNumber <= 5)
            {
                GameObject hp = Instantiate(Hp, this.transform.position + new Vector3(0.3f, 0.2f, 0),
                    Quaternion.identity);
                int target1 = (PlayerHealth.Instance.GetHeathLost() * 10) / 100;
                hp.GetComponent<HpSetting>().SetHp(target);
            }
            
            FXManager.Instance.GetFXEnemy(this.transform.position);
            
            GameController.Instance.AddKillEnemy(1);
            Destroy(this.gameObject);
        }
    }

    public void DeHealth(float damage)
    {
        hitPoint -= damage;
        if (hitPoint < 0f) hitPoint = 0f;
    }

    protected bool IsDead()
    {
        return hitPoint <= 0;
    }
}