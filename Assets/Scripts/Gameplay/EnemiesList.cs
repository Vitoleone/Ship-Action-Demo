using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesList : MonoBehaviour
{
    public List<Enemy> SoldierEnemy;
    public List<Enemy> TankEnemy;
    public List<Enemy> Base;
    public int enemyNumber;

    private void Start()
    {
        enemyNumber = Base.Count + TankEnemy.Count + SoldierEnemy.Count;
    }

    public void KillSoldierEnemy(string enemyName, Enemy enemyObject)
    {
        switch (enemyName)
        {
            case "SoldierEnemy":
                SoldierEnemy.Remove(enemyObject);
                enemyNumber--;
                break;
            case "TankEnemy":
                TankEnemy.Remove(enemyObject);
                enemyNumber--;
                break;
            case "Base":
                Base.Remove(enemyObject);
                enemyNumber--;
                break;
                
        }
    }
}
