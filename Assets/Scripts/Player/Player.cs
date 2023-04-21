using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerUIController uiController;
    public PlayerAttributesScriptable playerAttributes;
    

    void Start()
    {
        uiController.SetHealthBar(playerAttributes.currentHealth,playerAttributes.maxHealth);
        uiController.SetAmmoTextValues(playerAttributes.currentHealth,playerAttributes.maxAmmo);
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
        if (playerAttributes.currentHealth > 0)
        {
            playerAttributes.currentHealth -= damage;
            uiController.SetHealthBar(playerAttributes.currentHealth, playerAttributes.maxHealth);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpgradeAmmo()
    {
        playerAttributes.ammoLevel++;
        playerAttributes.maxAmmo += playerAttributes.ammoLevel * 4;
    }

    public void UpgradeHealth()
    {
        playerAttributes.healthLevel++;
        playerAttributes.maxHealth += playerAttributes.healthLevel * 10;
    }

    public void UpgradeDamage()
    {
        playerAttributes.damageLevel++;
        playerAttributes.rocketDamage += playerAttributes.damageLevel * 2;
    }
}
