//Pratik Niroula
//Jas Raj Dangi
// priyanka Chaudhary
// Samip Thapa
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class MainMenueManager : MonoBehaviour
{


    // fuction to start the gaame
   public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    // function to exit the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
