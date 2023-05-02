using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance { get => _instance; }

    protected void Awake()
    {
        PlayerController._instance = this;
    }

    public void AddSkill(int damage,int health,float range,float moveSpeed,int giap,float speedFire)
    {
        Weapon.Instance.AddDamage(damage);
        PlayerHealth.Instance.Addhealth(health);
        Magnet.Instance.AddRange(range);
        Player_Move.Instance.SetMoveSpeed(moveSpeed);
        PlayerHealth.Instance.AddGiap(giap);
        Weapon.Instance.AddSpeedFire(speedFire);
    }
}
