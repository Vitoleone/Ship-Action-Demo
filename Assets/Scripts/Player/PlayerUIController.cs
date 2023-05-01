using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI currentAmmoText;
    [SerializeField] private TextMeshProUGUI maxAmmoText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI ammoLevelText;
    [SerializeField] private TextMeshProUGUI healthLevelText;
    [SerializeField] private TextMeshProUGUI damageLevelText;
    [SerializeField] public GameObject shootButton;
    [SerializeField] public GameObject moveJoyStick;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private GameObject ammoPanel;
    [SerializeField] private GameObject healthbarPanel;
    [SerializeField] private GameObject flyButton;
    [SerializeField] private GameObject upgradeAmmoButton;
    [SerializeField] private GameObject upgradeHealthButton;
    [SerializeField] private GameObject upgradeDamageButton;

    public void SetHealthBar(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = (currentHealth / maxHealth);
    }

    public void SetAmmoTextValues(int currentAmmo,int maxAmmo)
    {
        currentAmmoText.text = currentAmmo.ToString();
        maxAmmoText.text = maxAmmo.ToString();
        
    }

    public void SetGoldTextValue(int money)
    {
        goldText.text = money.ToString();
    }

    public void SetAmmoLevel(int level)
    {
        ammoLevelText.text = level.ToString();
    }
    public void SetDamageLevel(int level)
    {
        damageLevelText.text = level.ToString();
    }
    public void SetHealthLevel(int level)
    {
        healthLevelText.text = level.ToString();
    }

    public void SetAllLevelValues(int healthLevel,int ammoLevel,int damageLevel)
    {
        healthLevelText.text = healthLevel.ToString();
        damageLevelText.text = damageLevel.ToString();
        ammoLevelText.text = ammoLevel.ToString();
    }

    public void OpenUpgradeMenu()
    {
        upgradePanel.SetActive(true);
        moveJoyStick.SetActive(false);
        shootButton.SetActive(false);
        ammoPanel.SetActive(false);
    }

    public void OpenFlyButton()
    {
        flyButton.SetActive(true);
    }

    public void CloseFlyButton()
    {
        flyButton.SetActive(false);
    }
    public void CloseUpgradeMenu()
    {
        upgradePanel.SetActive(false);
        moveJoyStick.SetActive(true);
        shootButton.SetActive(true);
        ammoPanel.SetActive(true);
    }

    public void UpgradeAmmoTween()
    {
        upgradeAmmoButton.GetComponent<RectTransform>().transform.DOScale(new Vector2(.8f,.8f),0.2f).OnComplete(
            () =>
            {
                upgradeAmmoButton.GetComponent<RectTransform>().transform.DOScale(Vector2.one,0.2f);
            });
    }
    public void UpgradeHealthTween()
    {
        upgradeHealthButton.GetComponent<RectTransform>().transform.DOScale(new Vector2(.8f,.8f),0.2f).OnComplete(
            () =>
            {
                upgradeHealthButton.GetComponent<RectTransform>().transform.DOScale(Vector2.one,0.2f);
            });
    }
    public void UpgradeDamageTween()
    {
        upgradeDamageButton.GetComponent<RectTransform>().transform.DOScale(new Vector2(.8f,.8f),0.2f).OnComplete(
            () =>
            {
                upgradeDamageButton.GetComponent<RectTransform>().transform.DOScale(Vector2.one,0.2f);
            });
    }
}

