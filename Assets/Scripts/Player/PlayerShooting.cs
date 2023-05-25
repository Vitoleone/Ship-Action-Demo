using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour,IShooter
{
    [SerializeField] private Rocket rocketPrefab;
    private ObjectPool<Rocket> pooledRockets;
    public float fireCooldown = 0;
    private Player player;
    

    [SerializeField] private GameObject crosshair; 

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    void Start()
    {
        CreateBulletPool();
    }

    public void Shoot(GameObject target)
    {
        if (fireCooldown <= 0 && player.playerAttributes.currentAmmo > 0)
        {
            var rocket = pooledRockets.Get();
            rocket.GetComponent<Rigidbody>().transform.DOMove(crosshair.transform.position, 0.45f);
            rocket.Init(ExplodeRocket);
            fireCooldown = 0.5f;
            player.playerAttributes.currentAmmo--;
            player.uiController.SetAmmoTextValues(player.playerAttributes.currentAmmo,player.playerAttributes.maxAmmo);
        }
    }

    public void CreateBulletPool()
    {
        pooledRockets = new ObjectPool<Rocket>(() =>
            {
                return Instantiate(rocketPrefab, player.transform); //When we ask the object this function will run.
            }, rocket =>
            {
                rocket.gameObject.SetActive(true);
                rocket.transform.position =
                    transform.position + 2 * Vector3.down; //When we get the object this function will run.
            },
            rocket =>
            {
                rocket.gameObject.SetActive(false);
                rocket.transform.position =
                    transform.position + 2 * Vector3.down; //When we are done with object this function will run.
            },
            rocket =>
            {
                Destroy(rocket.gameObject); //When we need to destroy an object this function will run.
            }, false, 10, 20);
    }


    private void Update()
    {
        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }
    }

    void ExplodeRocket(Rocket rocket)
    {
        pooledRockets.Release(rocket);
    }
    
}