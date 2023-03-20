using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigator : MonoBehaviour
{
    //Coded by Noel Paredes
    //Polished by Brandon Lo and Jessie Archer
    [SerializeField] GameObject baseMenu;//A game object representing the base menu
    [SerializeField] GameObject settingsMenu;//A game object representing the 
    [SerializeField] string mainScene; //A string representing the main scene
    [SerializeField] string loadScene; //A string representing the loading scene/lobby

    [SerializeField]
    List<int> resWidths;//A list of screen size widths
    [SerializeField]
    List<int> resHeights;//A list of screen size heights
    //Sets Base Menu to Active
    public void GoToBase()
    {
        baseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    //Opens setting menu
    public void GoToSettings()
    {
        baseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    //Starts game
    public void OnStartGame()
    {
        SceneManager.LoadScene(loadScene);
    }
    //Quits game
    public void OnQuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    //Sets the screensize based on a selected option
    public void SetScreenRes(int index)
    {
        bool isFullscreen = Screen.fullScreen;
        int width = resWidths[index];
        int height = resHeights[index];
        Screen.SetResolution(width, height, isFullscreen);
    }
    //Determines fullscreen 
    public void SetFullscreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }

}
