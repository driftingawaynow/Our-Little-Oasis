using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    List<int> widths = new List<int>() {568, 960, 1280, 1920}; 
    List<int> heights = new List<int>() {320, 540, 800, 1080}; 
    [SerializeField] Slider sens;

    public void Start()
    {
        sens.value = PlayerPrefs.GetFloat("sens");
    }
    
    public void Options()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void setFullscreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }

    public void ChangeSens(float sens) {
        PlayerPrefs.SetFloat("sens", sens);
    }
}
