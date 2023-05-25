using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour,IHitable
{
    public float health = 100;
    public float damage = 10;
    public GameObject goldPrefab;
    public QuestUIController questUIController;
    private EnemiesList enemyList;
    

    private void Awake()
    {
        enemyList = GameObject.Find("EnemiesList").GetComponent<EnemiesList>();
    }
    
    private void EnemyKilled()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject gold =  Instantiate(goldPrefab, transform.position + Vector3.up*2, quaternion.identity);
            gold.transform.DOMove(transform.position + new Vector3(Random.insideUnitSphere.x*15,15,Random.insideUnitSphere.z*15), 0.30f);
        }
        enemyList.KillSoldierEnemy(gameObject.name,this);
        questUIController.UpdateEnemyNumberTexts();
        Destroy(gameObject);
    }

    public void GetHit(float damage)
    {
        if (health-damage > 0)
        {
            health -= damage;    
        }
        else
        {
            EnemyKilled();
        }
    }
}
