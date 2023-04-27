using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject player;
    

    private void Update()
    {
        gameObject.transform.position =
            new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        gameObject.transform.Rotate(new Vector3(0,0,player.transform.rotation.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.green;
        }
    }

    
}
