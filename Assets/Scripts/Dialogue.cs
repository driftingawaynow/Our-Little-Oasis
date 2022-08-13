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
                StartCoroutine(typeLine());
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
        //Debug.Log(textComp.text);
        //Debug.Log(lines[index]);
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

    IEnumerator typeLine()
    {
        //Debug.Log(lines[0].ToCharArray());
        foreach (char c in lines[index].ToCharArray())
        {
            tick.Play();
            Debug.Log(c);
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(typeLine());
        }
        else
        {
            StartCoroutine(MainMenuSwitch());
        }
    }

    IEnumerator MainMenuSwitch()
    {   
        Debug.Log("Entering");
        yield return new WaitForSeconds(15);
        Debug.Log("Exiting");
        PlayerPrefs.SetInt("EndScreen", 1);
        SceneManager.LoadScene("Menu");
    }
}
