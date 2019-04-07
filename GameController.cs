using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;


    public GameObject explostion;
    public GameObject Enemy;
    public GameObject[] Enemies;

    private int score;

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardcount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private bool gameOver;
    private bool restart;

    private void Start()
    {
        score = 0;
        SetScoreText();
        StartCoroutine (SpawnWaves());
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (score == 100)
        {
            winText.text = "You win!";
            gameOver = true;
            restart = true;

            Enemies = GameObject.FindGameObjectsWithTag("astroids");

            for (var i = 0; i < Enemies.Length; i++)
            {
                Destroy(Enemies[i]);
                Instantiate(explostion, new Vector3(0,0,12), transform.rotation);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardcount; i++)
            {
                GameObject hazard = hazards[Random.Range(0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'I' to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        SetScoreText();

    }
    void SetScoreText()
    {
        scoreText.text = "POINTS : " + score.ToString();
    }
    public void GameOver()
    {
        gameOverText.text = "GAME OVER!";
        gameOver = true;
    }
}
