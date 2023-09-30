using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    //This is the Main Menu Manager - responsible for transitioning us into the level selection.

    //This function will start the game at your latest available level
    public void StartGame()
    {
        Debug.Log("Start Button Pressed, Starting latest available level.");
    }

    //This function will show you the level selection screen
    public void SelectStage()
    {
        Debug.Log("Level Selection Screen Initiated.");
    }
    
    //This function will close the game
    public void QuitGame()
    {
        Debug.Log("Aplication Closing.");
        Application.Quit();

    }



}
