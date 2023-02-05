using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigator : MonoBehaviour
{
    [SerializeField] GameObject baseMenu;
    [SerializeField] GameObject settingsMenu;

    [SerializeField]
    List<int> resWidths;
    [SerializeField]
    List<int> resHeights;

    public void GoToBase()
    {
        baseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void GoToSettings()
    {
        baseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnQuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    public void SetScreenRes(int index)
    {
        bool isFullscreen = Screen.fullScreen;
        int width = resWidths[index];
        int height = resHeights[index];
        Screen.SetResolution(width, height, isFullscreen);
    }

    public void SetFullscreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }

}
