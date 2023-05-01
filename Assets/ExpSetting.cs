using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSetting : MonoBehaviour
{
    [SerializeField] protected float exp = 1f;
    [SerializeField] protected float selfDestructTime = 5f; // Thời gian tự hủy (s)

    void Start()
    {
        StartCoroutine(DelayedDestruction());
    }

    IEnumerator DelayedDestruction()
    {
        yield return new WaitForSeconds(selfDestructTime);
        Destroy(gameObject);
    }
    public void SetExp(float _exp)
    {
        exp = _exp;
    }

    public float getExp()
    {
        return exp;
    }
}
