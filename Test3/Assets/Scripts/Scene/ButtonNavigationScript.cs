using UnityEngine;
using System.Collections;

public class ButtonNavigationScript : MonoBehaviour {

	string[] buttonNames = { "Resume", "Main Menu"};
	bool[] buttons;
	int currentSelection = 0;
	// Use this for initialization
	void Start () {
		buttons = new bool[buttonNames.Length];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
