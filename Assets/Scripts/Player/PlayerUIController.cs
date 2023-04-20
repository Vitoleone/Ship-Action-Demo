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

    public void SetHealthBar(int currentHealth, int maxHealth)
    {
        healthBar.fillAmount = ((float)currentHealth / (float)maxHealth);
    }

    public void SetAmmoTextValues(int currentAmmo,int maxAmmo)
    {
        currentAmmoText.text = currentAmmo.ToString();
        maxAmmoText.text = maxAmmo.ToString();
    }
}
