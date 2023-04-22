using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
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
