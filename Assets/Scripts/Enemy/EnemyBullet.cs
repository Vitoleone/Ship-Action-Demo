using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyBullet : MonoBehaviour,IBullet
{
    private Action<EnemyBullet> explodeAction;
    [SerializeField] private ParticleSystem bulletExplodeParticle;
    private int damage = 10;

    public void Init( Action<EnemyBullet> explodeAction)
    {
        this.explodeAction = explodeAction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            CreateBullet();
            other.GetComponent<Player>().GetHit(damage);
        }
    }

    public void CreateBullet()
    {
        Instantiate(bulletExplodeParticle, transform.position, quaternion.identity);
        explodeAction(this);
    }
}
