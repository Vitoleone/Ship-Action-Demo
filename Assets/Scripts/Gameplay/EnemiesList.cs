using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesList : MonoBehaviour
{
    public List<Enemy> SoldierEnemy;
    public List<Enemy> TankEnemy;
    public List<Enemy> Base;
    
    public void KillSoldierEnemy(string enemyName, Enemy enemyObject)
    {
        switch (enemyName)
        {
            case "SoldierEnemy":
                SoldierEnemy.Remove(enemyObject); 
                break;
            case "TankEnemy":
                TankEnemy.Remove(enemyObject);
                break;
            case "Base":
                Base.Remove(enemyObject);
                break;
                
        }
    }
}
