using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class DamageSender : IDamageSender
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("Enemy"))
        {
            FXManager.Instance.GetFXHit(this.transform.position);
            other.gameObject.GetComponent<EnemyBehaviour>().DeHealth(damage);
            Destroy(this.gameObject);
        }
    }
}
