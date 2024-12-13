//Pratik Niroula
//Jas Raj Dangi
// Priyanaka Chaudary
// Samip Thapa


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;

    public int round = 0;

    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;

    public TextMeshProUGUI roundNumber;
    public TextMeshProUGUI roundTextSurvived;
    public GameObject endscreen;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive == 0)
        {

            // increase the number os round played by the player and helps to print the content in the game over screen
            round++;
            NextWave(round);
            //this shows the text
            roundNumber.text = "Round: " + round.ToString();
        }
    }

    public void NextWave(int round)
    {   
        for(var x = 0; x< round; x++)
        {

            //this helps to respawn the zombiee randomly in 5 diffrent place whic are loacted in the game
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            // Increase the enemy when its is dies
            enemiesAlive++;
        }

    }
    // Function to restart the game and load the game screen
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    // Back to button helps to reload the the game

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        //reload the game main screen
        SceneManager.LoadScene(0);
    }


    // This function helps to show the text after the game ends
    public void EndGame()
    {
        Time.timeScale = 0;
        // make mouse cursor visible after the game end

        Cursor.lockState = CursorLockMode.None;
        // End screen is disable in my unity game and this helps to activate the game over screen when player helath is reduce to 0 or less than that

        endscreen.SetActive(true);
        // This shows the text how many round player survived and played

        roundTextSurvived.text = round.ToString();
    }
}

