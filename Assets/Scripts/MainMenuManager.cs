using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    //This is the Main Menu Manager - responsible for transitioning us into the level selection.
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject LevelSelectionCanvas;
    [SerializeField] GameObject[] LevelSelectionPanels;
    [SerializeField] Button[] LevelSelectionButtons;
    [SerializeField] int selectedLevelSet;

    //This function will start the game at your latest available level
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    //This function will show you the level selection screen
    public void SelectStage()
    {
        Debug.Log("Level Selection Screen Initiated.");
        mainMenuCanvas.SetActive(false);
        LevelSelectionCanvas.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Debug.Log("Returned to Main Menu.");
        mainMenuCanvas.SetActive(true);
        LevelSelectionCanvas.SetActive(false);
    }
    
    //This function will close the game
    public void QuitGame()
    {
        Debug.Log("Aplication Closing.");
        Application.Quit();

    }

    public void SelectLevelSet(int setID)
    {
        LevelSelectionPanels[selectedLevelSet].SetActive(false);
        LevelSelectionButtons[selectedLevelSet].interactable = true;
        selectedLevelSet = setID;
        LevelSelectionPanels[selectedLevelSet].SetActive(true);
        LevelSelectionButtons[selectedLevelSet].interactable = false;
    }

    public void GoToLevel(string LevelName) 
    {
        SceneManager.LoadScene(LevelName);
    }



}
