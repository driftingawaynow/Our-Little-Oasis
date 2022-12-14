using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Delete all player prefs and load fresh game instance
    /// </summary>
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("WestActive", 0);
        PlayerPrefs.SetInt("NorthActive", 0);
        PlayerPrefs.SetInt("EastActive", 0);
        PlayerPrefs.SetInt("FirstTimeSetup", 1);
        PlayerPrefs.SetFloat("sens", 100);
        PlayerPrefs.SetFloat("musicVolume", 1);
        PlayerPrefs.SetFloat("sfxVolume", 1);
        PlayerPrefs.SetString("Checkpoint", "(0.0, 0.0, 0.0)");
        PlayerPrefs.SetInt("EndScreen", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game");
    }

    public void ContinueGame()
    {
        // If no player prefs exist, starts a new game instead
        if(!PlayerPrefs.HasKey("WestActive"))
        {
            NewGame();
        }
        else {
            SceneManager.LoadScene("Game");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
