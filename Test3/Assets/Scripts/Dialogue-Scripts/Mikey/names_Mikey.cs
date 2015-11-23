using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class names_Mikey : MonoBehaviour {
	
	public int counter;

	Text text;
	// Use this for initialization
	void Start ()
	{
		counter = -1;
		text = GetComponent<Text>();
		text.text = "Mikey";
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			counter++;
			if (counter == 0)
			{
				text.text = "Ghost Pat";
			}
			else if (counter == 1)
			{
				text.text = "Mikey";
				counter = -1;
			}
		}
	}
}