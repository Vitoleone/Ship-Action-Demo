using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
   public EnemiesList enemyList;
   public QuestUIController questUiController;

   private void Update()
   {
      if (enemyList.enemyNumber <= 0)
      {
         WinGame();
      }
   }

   public void WinGame()
   {
      questUiController.WinGame();
   }
   
}