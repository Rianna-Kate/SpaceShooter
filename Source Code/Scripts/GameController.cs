using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject hazard1;
    public GameObject hazard2;
    public GameObject hazard3;

    private int randNum;

    public Vector3 spawnValues;

    public int hazardCount;
    public float spawnWait;
    public float waveWait;

    public TMPro.TextMeshProUGUI playerScore;
    public TMPro.TextMeshProUGUI gameOverText;
    public TMPro.TextMeshProUGUI restartText;

    public bool gameOver;
    public bool restart;
    public int score;
    public Canvas canvas;
    string currentSceneName;

    void Start()
    {
        gameOver = false;
        restart = false;
        StartCoroutine(spawnWaves());
        gameOverText.text = "";
        restartText.text = "";
        score = 0;
        updateScore();
    }

    public void Update()
    {
        if (gameOver == true)
        {
            restartText.text = "Press 'r' to Restart \n or\n 'esc' to exit";
            gameOverText.text = "GAME OVER";
            restart = true;
        }

        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Scenes/" + SceneManager.GetActiveScene().name);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Scenes/Start");
        }
    }


    IEnumerator spawnWaves () 
    {
        
        while (true)
        {
            yield return new WaitForSeconds(spawnWait);
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                randNum = Random.Range(0, 4);

                if (randNum == 0)
                {
                    Instantiate(hazard, spawnPosition, spawnRotation);
                }
                if ( randNum == 1)
                {
                    Instantiate(hazard1, spawnPosition, spawnRotation);
                }
                if (randNum == 2)
                {
                    Instantiate(hazard2, spawnPosition, spawnRotation);
                }
                if (randNum == 3)
                {
                    Instantiate(hazard3, spawnPosition, spawnRotation);
                }
                

                yield return new WaitForSeconds(spawnWait);
            }

            if (gameOver == true)
            {
                break;
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    public void setGameState(bool currGameState)
    {
        gameOver = currGameState;
    }

    public void updateScore ()
    {
        playerScore.text = "Score: " + score;
    }

    public void addScore (int scoreVal)
    {
        score += scoreVal;
        updateScore();
    }
}
