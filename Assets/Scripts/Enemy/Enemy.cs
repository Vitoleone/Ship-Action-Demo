using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public GameObject goldPrefab;

    public void TakeDamage(int damage)
    {
        if (health-damage > 0)
        {
            health -= damage;    
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                GameObject gold =  Instantiate(goldPrefab, transform.position + Vector3.up*2, quaternion.identity);
                gold.transform.DOMove(Random.insideUnitSphere * 5 + Vector3.up * 2, 0.30f);
            }
            Destroy(gameObject);
        }
    }
}
