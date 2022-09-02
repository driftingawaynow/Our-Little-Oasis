using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    List<int> widths = new List<int>() {320, 540, 1280, 1366, 1440, 1600, 1920, 2560, 3840}; 
    List<int> heights = new List<int>() {568, 960, 800, 768, 900, 900, 1080, 1440, 2160}; 
    [SerializeField] Slider sens;
    public Camera cameraB;
    public Material matB;

    public void Start()
    {
        sens.value = PlayerPrefs.GetFloat("sens");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Sets resolution of the game to the specified resolution
    /// </summary>
    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);

        // update portal resolution
        cameraB.targetTexture.Release();
        cameraB.targetTexture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
        matB.mainTexture = cameraB.targetTexture;
    }

    /// <summary>
    /// Toggle fullscreen enabled / disabled
    /// </summary>
    public void setFullscreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }

    /// <summary>
    /// Change mouse sensitivity
    /// </summary>
    public void ChangeSens(float sens) {
        PlayerPrefs.SetFloat("sens", sens);
    }
}
