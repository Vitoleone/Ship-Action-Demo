using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Crosshair crosshair;
    private PlayerMovement playerMovement;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject basePoint;
    [SerializeField] private GameObject baseForward;
    [SerializeField] private GameObject flyPoint;
    private SphereCollider baseCollider;

    [SerializeField] private Animator cameraAnimator;
    [SerializeField] private bool playerCam = true;

    private bool inBase = false;

    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        baseCollider = gameObject.GetComponent<SphereCollider>();
        PlayerInBase();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           PlayerInBase();
           SetAmmo();
        }
    }

    private void Update()
    {
        if (inBase)
        {
            UpdateHealth();
        }
    }

    public void PlayerInBase()
    {
        baseCollider.enabled = false;
        inBase = true;
        SwitchCamera();
        crosshair.gameObject.SetActive(false);
        playerMovement.isStoped = true;
        playerMovement.isReady = false;
        playerMovement.joystick.gameObject.SetActive(false);
        player.uiController.OpenUpgradeMenu();
        playerMovement.moveSpeed = 0;
        player.transform.DOMove(basePoint.transform.position, .75f);
        player.transform.DORotate(new Vector3(10,0,0), .75f).OnComplete(() =>
        {
            player.uiController.OpenUpgradeMenu();
            player.uiController.OpenFlyButton();
        });
    }

    public void PlayerOutBase()
    {
        inBase = false;
        Invoke("UpdateBaseCollider",1f);
        SwitchCamera();
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
            crosshair.gameObject.SetActive(true);
        });
        player.transform.DOLookAt(flyPoint.transform.position, .75f);
    }

    public void UpdateHealth()
    {
        if (player.playerAttributes.currentHealth < player.playerAttributes.maxHealth)
        {
            player.playerAttributes.currentHealth += player.playerAttributes.maxHealth/5 * Time.deltaTime;
            player.uiController.SetHealthBar(player.playerAttributes.currentHealth,player.playerAttributes.maxHealth);
        }
        else
        {
            player.playerAttributes.currentHealth = player.playerAttributes.maxHealth;
            player.uiController.SetHealthBar(player.playerAttributes.currentHealth,player.playerAttributes.maxHealth);
        }
        
    }
    public void SetAmmo()
    {
        player.playerAttributes.currentAmmo = player.playerAttributes.maxAmmo;
        player.uiController.SetAmmoTextValues(player.playerAttributes.currentAmmo,player.playerAttributes.maxAmmo);
        
    }

    public void SwitchCamera()
    {
        if (playerCam)
        {
            cameraAnimator.Play("BaseCam");
        }
        else
        {
            cameraAnimator.Play("PlayerCam");
        }

        playerCam = !playerCam;
    }

    private void UpdateBaseCollider()
    {
        baseCollider.enabled = true;
    }
    
}
