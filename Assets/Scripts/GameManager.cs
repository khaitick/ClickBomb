using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    public bool spawn;
    public bool gameOver;
    [Range(0,10)]
    public int spawnWave;
    public List<GameObject> targetPrefabs;

    private int score;
    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            GameObject target = Instantiate(targetPrefabs[index]);
        }
    }


    public void UpdateScore(int value)
    {
        score += value;
        scoreUI.text = score.ToString();
    }

    
}
