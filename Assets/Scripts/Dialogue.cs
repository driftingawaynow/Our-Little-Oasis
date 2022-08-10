using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public AudioSource tick;
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float textSpeed;
    private int index = 0;
    private float timer = 5f;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(typeLine());
        }
    }

    void Start()
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

    IEnumerator typeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            tick.Play();
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
    }
}
