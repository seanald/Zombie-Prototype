using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class names_GenPat : MonoBehaviour
{

    public static int namecounter;

    Text text;
    // Use this for initialization
    void Start()
    {
        namecounter = -1;
        text = GetComponent<Text>();
        text.text = "General Patton";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            if (namecounter == 1)
            {
                text.text = "Ghost Pat";
            }
            else if (namecounter == 0)
            {
                text.text = "General Patton";
                
            }
        }
    }
}