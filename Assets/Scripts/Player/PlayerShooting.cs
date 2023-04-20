using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Rocket rocketPrefab;
    private ObjectPool<Rocket> pooledRockets;
    public float fireCooldown = 0;

    void Start()
    {
        pooledRockets = new ObjectPool<Rocket>(() =>
            {
                return Instantiate(rocketPrefab); //When we ask the object this function will run.
            }, rocket =>
            {
                rocket.gameObject.SetActive(true); //When we get the object this function will run.
            },
            rocket =>
            {
                rocket.gameObject.SetActive(false); //When we are done with object this function will run.
            },
            rocket =>
            {
                Destroy(rocket.gameObject); //When we need to destroy an object this function will run.
            },false,10,20);
    }

    private void Update()
    {
        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (fireCooldown <= 0)
        {
            var rocket = pooledRockets.Get();
            rocket.transform.position = transform.position + 2*Vector3.down;
            rocket.Init(ExplodeRocket);
            fireCooldown = 0.5f;
        }
    }

    void ExplodeRocket(Rocket rocket)
    {
        pooledRockets.Release(rocket);
        rocket.transform.position = transform.position + 2*Vector3.down;
    }
}