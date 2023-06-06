using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private static PlayerHealth _instance;

    public static PlayerHealth Instance
    {
        get => _instance;
    }
    [SerializeField] protected float maxHealth = 100;
    [SerializeField] protected float currentHealth;
    [SerializeField] protected HealthBar healthBar;
    [SerializeField] protected int giap = 1;
    
    protected void Awake()
    {
        PlayerHealth._instance = this;
    }
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= ArmorPercent(damage);
        if (currentHealth < 0)
        {
            currentHealth = 0;
            SoundManager.Instance.OnPlaySound(SoundType.playerdead);
            UIManager.Instance.SetActivePanelGameOver();
        }
        healthBar.SetHeart(currentHealth);
    }

    public float ArmorPercent(int damage)
    {
        float y = (((6 * giap)* 1f / ((giap + 5) *1f)))/10f;
        float takeDamage = damage*1f - damage*1f * y;
        return takeDamage;
    }

    public void AddGiap(int g)
    {
        giap += g;
    }

    public void Addhealth(int h = 5)
    {
        maxHealth += (maxHealth*h/100);
        if (h == 0) return;
        healthBar.AddMaxHealth(maxHealth);
    }

    public float GetHeathLost()
    {
        return maxHealth - currentHealth;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hp"))
        {
            currentHealth += other.gameObject.GetComponent<HpSetting>().getHp();
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            healthBar.SetHeart(currentHealth);
            Destroy(other.gameObject);
        }
    }
}
