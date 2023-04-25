using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Player player;
    private PlayerMovement playerMovement;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject basePoint;
    [SerializeField] private GameObject baseForward;
    [SerializeField] private GameObject flyPoint;

    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           PlayerInBase();
           SetAmmo();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateHealth();
        }
    }

    public void PlayerInBase()
    {
        cameraController.EnableBaseCam();
        playerMovement.isStoped = true;
        playerMovement.isReady = false;
        playerMovement.joystick.gameObject.SetActive(false);
        player.uiController.OpenUpgradeMenu();
        playerMovement.moveSpeed = 0;
        player.transform.DOMove(basePoint.transform.position, .75f);
        player.transform.DOLookAt(-baseForward.transform.position, .75f).OnComplete(() =>
        {
            player.uiController.OpenUpgradeMenu();
            player.uiController.OpenFlyButton();
        });
    }

    public void PlayerOutBase()
    {
        cameraController.EnablePlayerCam();
        player.uiController.CloseUpgradeMenu();
        player.uiController.CloseFlyButton();
        player.uiController.SetHealthBar(player.playerAttributes.currentHealth,player.playerAttributes.maxHealth);
        SetAmmo();
        playerMovement.isStoped = false;
        playerMovement.moveSpeed = 15f;
        player.transform.DOMove(flyPoint.transform.position, .75f).OnComplete(() =>
        {
            playerMovement.isReady = true;
            playerMovement.joystick.gameObject.SetActive(true);
        });
        player.transform.DOLookAt(flyPoint.transform.position, .75f);
    }

    public void UpdateHealth()
    {
        if (player.playerAttributes.currentHealth < player.playerAttributes.maxHealth)
        {
            player.playerAttributes.currentHealth += player.playerAttributes.maxHealth/10 * Time.deltaTime;
        }
        else
        {
            player.playerAttributes.currentHealth = player.playerAttributes.maxHealth;
        }
        
    }
    public void SetAmmo()
    {
        player.playerAttributes.currentAmmo = player.playerAttributes.maxAmmo;
        player.uiController.SetAmmoTextValues(player.playerAttributes.currentAmmo,player.playerAttributes.maxAmmo);
        
    }
}
