using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSetting : MonoBehaviour
{
    [SerializeField] protected int exp = 1;
    [SerializeField] protected int selfDestructTime = 5; // Thời gian tự hủy (s)

    void Start()
    {
        StartCoroutine(DelayedDestruction());
    }

    IEnumerator DelayedDestruction()
    {
        yield return new WaitForSeconds(selfDestructTime);
        Destroy(gameObject);
    }
    public void SetExp(int _exp)
    {
        exp = _exp;
    }

    public int getExp()
    {
        return exp;
    }
}
