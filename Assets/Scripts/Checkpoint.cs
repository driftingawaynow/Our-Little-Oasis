using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class Checkpoint : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("c"))
        {
            // split string
            string[] xyz = PlayerPrefs.GetString("Checkpoint").Split(",");

            // remove parenthesis
            xyz[0] = xyz[0].Replace("(", "");
            xyz[2] = xyz[2].Replace(")", "");

            // convert to float
            float xf = float.Parse(xyz[0], CultureInfo.InvariantCulture.NumberFormat);
            float yf = float.Parse(xyz[1], CultureInfo.InvariantCulture.NumberFormat);
            float zf = float.Parse(xyz[2], CultureInfo.InvariantCulture.NumberFormat);

            // build new vector to teleport player
            player.transform.position = new Vector3(xf, yf, zf);
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerPrefs.SetString("Checkpoint", transform.position.ToString());
        }
    }
}
