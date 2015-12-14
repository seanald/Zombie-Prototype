using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {

	private float offset;
	public float speed = 29.0f;
	public GUIStyle style;
	public Rect viewArea;
	
	private void Start()
	{
		this.offset = Screen.height;
	}
	
	private void Update()
	{
		this.offset -= Time.deltaTime * this.speed;
	}

	IEnumerator ResetGame()
	{
		yield return new WaitForSeconds(100.0f);
		Application.LoadLevel(Application.loadedLevel);
	}
	private void OnGUI()
	{
		GUI.BeginGroup(this.viewArea);
		
		var position = new Rect(0, this.offset, this.viewArea.width, this.viewArea.height);
		string text = @"THIS GAME WAS BROUGHT TO YOU IN PART BY





MATTHEW CASEY





MICHAEL RECKOFF





ZACHARY GOODLESS





SHANE GOSE





JACOB KHOSROWZADEH





SEAN MCDONALD





MARCO MICHILLI





WALTER SHUMAN





CHRISTOPHER URRISTE





KEVIN WILKINSON




  
SPECIAL THANKS TO:



GIDDEO SHBEEB



GOOGLE



THE MANY COFFEE HOUSES WHERE THE PROGRAMMERS WORKED


";
		
		GUI.TextField(position, text, this.style);
		
		GUI.EndGroup();
	}
}