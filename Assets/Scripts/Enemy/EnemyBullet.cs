using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Action<EnemyBullet> explodeAction;
    private int damage = 10;

    public void Init( Action<EnemyBullet> explodeAction)
    {
        this.explodeAction = explodeAction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            explodeAction(this);
            other.GetComponent<Player>().GetDamaged(damage);
        }
    }
}
