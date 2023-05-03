using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance { get => _instance; }
    
    public GameObject GunPre1;
    public GameObject GunPre2;
    public GameObject GunPre3;

    protected void Awake()
    {
        PlayerController._instance = this;
    }

    public void AddSkill(int damage,int health,float range,float moveSpeed,int giap,float speedFire,int gun)
    {
        Weapon.Instance.AddDamage(damage);
        PlayerHealth.Instance.Addhealth(health);
        Magnet.Instance.AddRange(range);
        Player_Move.Instance.SetMoveSpeed(moveSpeed);
        PlayerHealth.Instance.AddGiap(giap);
        Weapon.Instance.AddSpeedFire(speedFire);
        this.Gun(gun);
    }

    private void SetActiveAllGun()
    {
        GunPre1.SetActive(false);
        GunPre2.SetActive(false);
        GunPre3.SetActive(false);
    }
    private void Gun(int gun)
    {
        if(gun == 0) return;
        
        
        
        if (gun == 1)
        {
            if (GunPre1.activeSelf == false)
            {
                this.SetActiveAllGun();
                GunPre1.SetActive(true);
            }
            else
            {
                Weapon.Instance.AddDamage(1);
                Weapon.Instance.AddSpeedFire(5);
            }   
        }else if (gun == 2)
        {
            if (GunPre2.activeSelf == false)
            {
                this.SetActiveAllGun();
                GunPre2.SetActive(true);
            }
            else
            {
                Weapon.Instance.AddDamage(1);
                Weapon.Instance.AddSpeedFire(5);
            }
        }
        else
        {
            if (GunPre3.activeSelf == false)
            {
                this.SetActiveAllGun();
                GunPre3.SetActive(true);
            }
            else
            {
                Weapon.Instance.AddDamage(1);
                Weapon.Instance.AddSpeedFire(5);
            }   
        }
    }
}
