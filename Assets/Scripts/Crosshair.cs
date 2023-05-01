using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject player;
    private bool onEnemy = false;

    private void Start()
    {
        transform.DOLocalRotate(new Vector3(90, 180, 0), 1f).SetLoops(-1,LoopType.Restart);
    }

    private void Update()
    {
        gameObject.transform.position =
            new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        if (onEnemy)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.green; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            onEnemy = true;
        }
        else
        {
            onEnemy = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            onEnemy = false;
        }
    }
}
