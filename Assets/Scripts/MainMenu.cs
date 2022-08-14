using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    List<int> widths = new List<int>() {568, 960, 1280, 1920}; 
    List<int> heights = new List<int>() {320, 540, 800, 1080}; 
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("WestActive", 0);
        PlayerPrefs.SetInt("NorthActive", 0);
        PlayerPrefs.SetInt("EastActive", 0);
        PlayerPrefs.SetFloat("sens", 100);
        PlayerPrefs.SetFloat("musicVolume", 1);
        PlayerPrefs.SetFloat("sfxVolume", 1);
        PlayerPrefs.SetString("Checkpoint", "(0.0, 0.0, 0.0)");
        PlayerPrefs.SetInt("EndScreen", 0);
        SceneManager.LoadScene("Game");
    }

    public void ContinueGame()
    {
        if(!PlayerPrefs.HasKey("WestActive"))
        {
            NewGame();
        }
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
