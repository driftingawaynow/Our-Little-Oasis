using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("WestActive") == 1 || PlayerPrefs.GetInt("NorthActive") == 1 || PlayerPrefs.GetInt("EastActive") == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
