using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Rocket : MonoBehaviour,IBullet
{
    private Action<Rocket> explodeAction;
    public PlayerAttributesScriptable playerAttributes;
    [SerializeField] private GameObject explosionParticle;
    
    public void Init( Action<Rocket> explodeAction)
    {
        this.explodeAction = explodeAction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IGround>() != null)
        {
            other.GetComponent<IGround>().GroundHit(explosionParticle,gameObject.transform.position-Vector3.down*2);
            explodeAction(this);
        }
        else if(other.GetComponent<Enemy>() != null)
        {
            CreateBullet();
            other.GetComponent<Enemy>().GetHit(playerAttributes.rocketDamage);
        }
    }
    public void CreateBullet()
    {
        Instantiate(explosionParticle, gameObject.transform.position - Vector3.down * 2, quaternion.identity);
        explodeAction(this);
    }
}
