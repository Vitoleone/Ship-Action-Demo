using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerUIController uiController;
    public PlayerAttributesScriptable playerAttributes;
    [SerializeField] private ParticleSystem playerDeathParticle;
    public Base baseClass;
    

    void Start()
    {
        uiController.SetHealthBar(playerAttributes.currentHealth,playerAttributes.maxHealth);
        uiController.SetAmmoTextValues(playerAttributes.currentAmmo,playerAttributes.maxAmmo);
        uiController.SetGoldTextValue(playerAttributes.money);
        uiController.SetAllLevelValues(playerAttributes.healthLevel,playerAttributes.ammoLevel,playerAttributes.damageLevel);
        Time.timeScale = 1;
    }
    
    public void GetDamaged(float damage)
    {
        if (playerAttributes.currentHealth > 0)
        {
            playerAttributes.currentHealth -= damage;
            uiController.SetHealthBar(playerAttributes.currentHealth, playerAttributes.maxHealth);
        }
        else
        {
            uiController.shootButton.SetActive(false);
            uiController.moveJoyStick.SetActive(false);
            gameObject.SetActive(false);
            Instantiate(playerDeathParticle, transform.position, quaternion.identity);
            Invoke("PlayerDeath",1.25f);
        }
    }

    public void UpgradeAmmo()
    {
        if (playerAttributes.money - playerAttributes.ammoLevel * 90 >= playerAttributes.ammoLevel * 90)
        {
            
            uiController.UpgradeAmmoTween();
            playerAttributes.ammoLevel++;
            uiController.SetAmmoLevel(playerAttributes.ammoLevel);
            playerAttributes.maxAmmo += playerAttributes.ammoLevel * 4;
            UseMoney(playerAttributes.ammoLevel * 90);
            playerAttributes.currentAmmo = playerAttributes.maxAmmo;
            uiController.SetAmmoTextValues(playerAttributes.currentAmmo,playerAttributes.maxAmmo);
        }
        
    }

    public void UpgradeHealth()
    {
        if (playerAttributes.money - playerAttributes.healthLevel * 130 >= playerAttributes.healthLevel * 130)
        {
            uiController.UpgradeHealthTween();
            playerAttributes.healthLevel++;
            uiController.SetHealthLevel(playerAttributes.healthLevel);
            playerAttributes.maxHealth += playerAttributes.healthLevel * 10;
            UseMoney(playerAttributes.healthLevel * 130);
            uiController.SetHealthBar(playerAttributes.currentHealth,playerAttributes.maxHealth);
        }
        
    }

    public void UpgradeDamage()
    {
        if (playerAttributes.money - playerAttributes.damageLevel * 180 >= playerAttributes.damageLevel * 180)
        {
            uiController.UpgradeDamageTween();
            playerAttributes.damageLevel++;
            uiController.SetDamageLevel(playerAttributes.damageLevel);
            playerAttributes.rocketDamage += playerAttributes.damageLevel * 5;
            UseMoney(playerAttributes.damageLevel * 180);
        }
    }

    public void UseMoney(int amount)
    {
        playerAttributes.money -= amount;
        uiController.SetGoldTextValue(playerAttributes.money);
    }
    public void GetMoney(int amount)
    {
        playerAttributes.money += amount;
        uiController.SetGoldTextValue(playerAttributes.money);
    }
    void PlayerDeath()
    {
        baseClass.PlayerInBase();
        gameObject.SetActive(true);
        
    }
    
}
