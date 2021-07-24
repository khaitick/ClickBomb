using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject menuUI;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI healthUI;
    public TextMeshProUGUI gameOverUI;
    public Button restartUI;
    public bool spawn;
    public bool gameOver;
    [Range(0,10)]
    public int spawnWave;
    public List<GameObject> targetPrefabs;

    private int maxHealth = 3;
    private int health;
    private int score;
    private float maxSpawnRate = 1.0f;
    private float spawnRate;

    public void GameStart(int difficulty)
    {
        spawnRate = maxSpawnRate / difficulty;
        gameOver = false;
        menuUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
        restartUI.gameObject.SetActive(false);
        health = maxHealth;
        score = 0;
        UpdateHealth(0);
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            if (!gameOver)
            {
                int index = UnityEngine.Random.Range(0, targetPrefabs.Count);
                GameObject target = Instantiate(targetPrefabs[index]);
            }
        }
    }

    public void RestartButton()
    {
        menuUI.gameObject.SetActive(true);
        gameOverUI.gameObject.SetActive(false);
        restartUI.gameObject.SetActive(false);
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreUI.text = score.ToString();
    }

    public void UpdateHealth(int value)
    {
        health += value;
        healthUI.text = "";
        for (int i = 0; i < health; i++)
        {
            healthUI.text += "/";
        }
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver = true;
        gameOverUI.gameObject.SetActive(true);
        restartUI.gameObject.SetActive(true);
        GameObject[] remainingTarget = GameObject.FindGameObjectsWithTag("Target");
        for (int i = 0; i < remainingTarget.Length; i++)
        {
            remainingTarget[i].GetComponent<Target>().DestroyTarget();
        }
    }


}
