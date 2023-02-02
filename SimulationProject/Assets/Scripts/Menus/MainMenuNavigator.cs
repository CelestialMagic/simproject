using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigator : MonoBehaviour
{
    [SerializeField] GameObject baseMenu;
    [SerializeField] GameObject settingsMenu;

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

}
