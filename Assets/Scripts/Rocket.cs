using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Rocket : MonoBehaviour
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
        if (other.transform.CompareTag("Ground"))
        {
            Instantiate(explosionParticle,gameObject.transform.position-Vector3.down*2,quaternion.identity);
            explodeAction(this);
        }
        else if(other.transform.CompareTag("Enemy"))
        {
            Instantiate(explosionParticle,gameObject.transform.position-Vector3.down*2,quaternion.identity);
            explodeAction(this);
            other.GetComponent<Enemy>().TakeDamage(playerAttributes.rocketDamage);
            Debug.Log("Damaged");
        }
    }
}
