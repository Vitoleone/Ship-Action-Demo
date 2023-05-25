using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyShooting : MonoBehaviour,IShooter
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
        if (other.GetComponent<Player>() != null)
        {
            Shoot(other.gameObject);
        }
    }

  

    public float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    void ReleaseBullet(EnemyBullet bullet)
    {
        pooledBullets.Release(bullet);
    }

    public void Shoot(GameObject target)
    {
        Player player = target.GetComponent<Player>();
        if (fireCooldown <= 0)
        {
            var bullet = pooledBullets.Get();
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bullet.transform.eulerAngles = new Vector3(0,0,GetAngleFromVectorFloat( bullet.transform.position - player.transform.position ));
            bullet.transform.DOLocalRotate(player.transform.position - bullet.transform.position,0);
            bulletRb.transform.DOMove(player.transform.position, 0.35f).OnComplete(() =>
            {
                bullet.gameObject.SetActive(false);
            });
            bullet.Init(ReleaseBullet);
            fireCooldown = 0.35f;
        }
    }

    public void CreateBulletPool()
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
    
}
