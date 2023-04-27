using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUIController : MonoBehaviour
{
    public TextMeshProUGUI currentSoldierEnemyNum;
    public EnemiesList enemyList;

    private void Start()
    {
        UpdateEnemyNumberTexts();
    }

    public void UpdateEnemyNumberTexts()
    {
        currentSoldierEnemyNum.text = enemyList.SoldierEnemy.Count.ToString();
    }
}
