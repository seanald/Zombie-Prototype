﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class names_Vlad : MonoBehaviour
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
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            counter++;
            if (counter == 0)
            {
                text.text = "Vlad";
            }
            else if (counter == 1)
            {
                text.text = "Ghost Pat";
                counter = -1;
            }
        }
    }
}