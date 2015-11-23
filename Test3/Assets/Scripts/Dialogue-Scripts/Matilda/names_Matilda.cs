using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class names_Matilda : MonoBehaviour
{

    public static int counter;

    Text text;
    // Use this for initialization
    void Start()
    {
        counter = -1;
        text = GetComponent<Text>();
        text.text = "Ghost Pat";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            counter++;
            if (counter == 0)
            {
                text.text = "Matilda";
            }
            else if (counter == 1)
            {
                text.text = "Ghost Pat";
                counter = -1;
            }
        }
    }
}