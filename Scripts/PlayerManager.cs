//Pratik Niroula
//Jas Raj Dangi
// priyanka Chaudhary
// Samip Thapa

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMnager : MonoBehaviour
{
    // Start is called before the first frame update
    //FPS player health 
    public float health = 100;
    // Text variables to show for the screen
    public TextMeshProUGUI healthText;
    public GameManager gameManager;
    public void Hit(float damage)
    {

        //get damaged when Zombie touch the player

        health -= damage;
        // used to show the health status of the player on the screen
        healthText.text = "Health : " + health.ToString();

        // This helps to check the health and exits the game when player dies
        if (health <= 0)
        {
            //reload the screen to end the game
            gameManager.EndGame();
        }
    }
}

        
        
