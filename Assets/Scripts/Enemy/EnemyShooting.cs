using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private EnemyBullet bulletPrefab;
    private ObjectPool<EnemyBullet> pooledBullets;
    public float fireCooldown = 0;

    void Start()
    {
        CreateBulletPool();
        
    }

    private void Update()
    {
        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Girdi");
            Player player = other.GetComponent<Player>();
            Shoot(player);
        }
    }

    void CreateBulletPool()
    {
        pooledBullets = new ObjectPool<EnemyBullet>(() =>
            {
                return Instantiate(bulletPrefab,transform); //When we ask the object this function will run.
            },bullet =>
            {
                bullet.gameObject.SetActive(true);
                bullet.transform.position = transform.position; //When we get the object this function will run.
            },
            bullet =>
            {
                bullet.gameObject.SetActive(false);
                bullet.transform.position =
                    transform.position; //When we are done with object this function will run.
            },
            bullet =>
            {
                Destroy(bullet.gameObject); //When we need to destroy an object this function will run.
            },false,10,20);
    }
    public void Shoot(Player player)
    {
        if (fireCooldown <= 0)
        {
            var bullet = pooledBullets.Get();
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.transform.DOMove(player.transform.position, 0.20f);
            bullet.transform.LookAt(player.transform);
            bullet.transform.DOLocalRotate(player.transform.position - bullet.transform.position,0);
            bullet.Init(ReleaseBullet);
            fireCooldown = 0.25f;
        }
    }

    void ReleaseBullet(EnemyBullet bullet)
    {
        pooledBullets.Release(bullet);
    }
}
