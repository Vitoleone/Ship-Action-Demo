using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Action<Rocket> explodeAction;
    public PlayerAttributesScriptable playerAttributes;
    
    public void Init( Action<Rocket> explodeAction)
    {
        this.explodeAction = explodeAction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            explodeAction(this);
        }
        else if(other.transform.CompareTag("Enemy"))
        {
            explodeAction(this);
            other.GetComponent<Enemy>().TakeDamage(playerAttributes.rocketDamage);
            Debug.Log("Damaged");
        }
    }
}
