using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    //This is the Main Menu Manager - responsible for transitioning us into the level selection.
    [SerializeField] private GameObject _mainMenuCanvas;
    [SerializeField] private GameObject _levelSelectionCanvas;
    [SerializeField] private GameObject[] _levelSelectionPanels;
    [SerializeField] private Button[] _levelSelectionButtons;
    [SerializeField] private int _selectedLevelSet;

    //This function will start the game at your latest available level
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    //This function will show you the level selection screen
    public void SelectStage()
    {
        Debug.Log("Level Selection Screen Initiated.");
        _mainMenuCanvas.SetActive(false);
        _levelSelectionCanvas.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Debug.Log("Returned to Main Menu.");
        _mainMenuCanvas.SetActive(true);
        _levelSelectionCanvas.SetActive(false);
    }
    
    //This function will close the game
    public void QuitGame()
    {
        Debug.Log("Aplication Closing.");
        Application.Quit();

    }

    public void SelectLevelSet(int setID)
    {
        _levelSelectionPanels[_selectedLevelSet].SetActive(false);
        _levelSelectionButtons[_selectedLevelSet].interactable = true;
        _selectedLevelSet = setID;
        _levelSelectionPanels[_selectedLevelSet].SetActive(true);
        _levelSelectionButtons[_selectedLevelSet].interactable = false;
    }

    public void GoToLevel(string LevelName) 
    {
        SceneManager.LoadScene(LevelName);
    }



}
