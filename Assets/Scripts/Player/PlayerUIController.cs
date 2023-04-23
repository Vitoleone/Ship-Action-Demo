using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI currentAmmoText;
    [SerializeField] private TextMeshProUGUI maxAmmoText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private GameObject shootButton;
    [SerializeField] private GameObject moveJoyStick;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private GameObject ammoPanel;
    [SerializeField] private GameObject healthbarPanel;
    [SerializeField] private GameObject flyButton;

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

    public void OpenUpgradeMenu()
    {
        upgradePanel.SetActive(true);
        moveJoyStick.SetActive(false);
        shootButton.SetActive(false);
        healthbarPanel.SetActive(false);
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
        healthbarPanel.SetActive(true);
        ammoPanel.SetActive(true);
    }
}
