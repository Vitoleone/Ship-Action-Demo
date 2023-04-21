using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;

    public void TakeDamage(int damage)
    {
        if (health-damage > 0)
        {
            health -= damage;    
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
