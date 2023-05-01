using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestUIController : MonoBehaviour
{
    public TextMeshProUGUI currentSoldierEnemyNum;
    public EnemiesList enemyList;
    public GameObject WinPanel;

    private void Start()
    {
        UpdateEnemyNumberTexts();
    }

    public void UpdateEnemyNumberTexts()
    {
        currentSoldierEnemyNum.text = enemyList.SoldierEnemy.Count.ToString();
    }

    public void WinGame()
    {
        Time.timeScale = 0;
        WinPanel.SetActive(true);
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
