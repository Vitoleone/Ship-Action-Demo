using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Upgrades
    public int ammoUpgrade = 1;
    public int healthUpgrade = 1;
    public int damageUpgrade = 1;
    
    //Ammo attributes
    public int currentAmmo;
    public int maxAmmo;
    
    //Health attributes
    public int maxHealth;
    public int currentHealth;
    
    //Damage attribute
    public int rocketDamage;
    //Money attribute
    public int money;
    
    public PlayerUIController uiController;
    
    
    public PlayerAttributesScriptable playerAttributes;
    
    private void Awake()
    {
        SetScriptableValues();
    }

    void Start()
    {
        uiController.SetHealthBar(currentHealth,maxHealth);
        uiController.SetAmmoTextValues(currentAmmo,maxAmmo);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetDamaged(5);
        }
    }

    public void GetDamaged(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            uiController.SetHealthBar(currentHealth, maxHealth);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpgradeAmmo()
    {
        ammoUpgrade++;
        maxAmmo += ammoUpgrade * 4;
    }

    public void UpgradeHealth()
    {
        healthUpgrade++;
        maxHealth += healthUpgrade * 10;
    }

    public void UpgradeDamage()
    {
        damageUpgrade++;
        rocketDamage += damageUpgrade * 2;
    }
    //On game starts player gets the values on scriptable
    //The reason why we dont use direct values on scriptable is need a default values for different levels.
    void SetScriptableValues()
    {
        ammoUpgrade = playerAttributes.ammoLevel;
        healthUpgrade = playerAttributes.healthLevel;
        damageUpgrade = playerAttributes.damageLevel;
        currentAmmo = playerAttributes.currentAmmo;
        maxAmmo = playerAttributes.maxAmmo;
        maxHealth = playerAttributes.maxHealth;
        currentHealth = playerAttributes.currentHealth;
        rocketDamage = playerAttributes.rocketDamage;
        money = playerAttributes.money;
    }
}
