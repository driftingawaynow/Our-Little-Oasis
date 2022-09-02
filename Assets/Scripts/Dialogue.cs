using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public AudioSource tick;
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float textSpeed;
    private int index = 0;
    private float timer = 5f;
    private bool once = true;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(once)
            {
                once = false;
                StartCoroutine(TypeLine());
            }
        }
    }

    void Awake()
    {
        textComp.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(textComp.text == lines[index])
        {
            timer -= 1f * Time.deltaTime;
        }
        if(timer <= 0f)
        {
            timer = 5f;
            NextLine();
        }
    }

    /// <summary>
    /// Types out line of dialogue character by character on a set tick interval
    /// </summary>
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            tick.Play();
            Debug.Log(c);
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    /// <summary>
    /// Moves to the next line of dialogue. If all lines are finished, moves to main menu
    /// </summary>
    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            StartCoroutine(MainMenuSwitch());
        }
    }

    /// <summary>
    /// Moves to the main menu
    /// </summary>
    IEnumerator MainMenuSwitch()
    {   
        Debug.Log("Entering");
        PlayerPrefs.SetInt("EndScreen", 1);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(5);
        Debug.Log("Exiting");
        SceneManager.LoadScene("Menu");
    }
}
