using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Action<Rocket> explodeAction;
    // Start is called before the first frame update
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
    }
}
