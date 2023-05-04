using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSetting : MonoBehaviour
{
    [SerializeField] protected int hp = 1;
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
    public void SetHp(int _hp)
    {
        hp = _hp;
    }

    public int getHp()
    {
        return hp;
    }
}
