using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public int enemyCount;
    public int enemyLimit;

    public Text enemyText;

    void Start()
    {
        DontDestroyOnLoad(scoreText);
        UpdateScore();
        UpdateEnemy();
        StartCoroutine(SpawnWaves());   
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int newScoreValue)
    {
        int tempScore = PlayerPrefs.GetInt("totalScore") + newScoreValue;
        PlayerPrefs.SetInt("totalScore", tempScore);
        UpdateScore();
    }

    public void AddEnemy(int val)
    {
        enemyCount += val;
        UpdateEnemy();
    }
    
    void UpdateScore()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("totalScore").ToString();
    }

    void UpdateEnemy()
    {
        enemyText.text = "Enemies Left: " + (enemyLimit - enemyCount).ToString();
    }

    void Update()
    {
        if (enemyCount >= enemyLimit)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.NextLevel();
        }
    }
}
