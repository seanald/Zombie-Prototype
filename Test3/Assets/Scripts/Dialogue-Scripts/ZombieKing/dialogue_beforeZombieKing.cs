using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dialogue_beforeZombieKing : MonoBehaviour
{
	
	public static int counter;
	public GameObject textBox;
	public static int zombieKingDead;
	public int zkd;
	public float timeLeft = 5.0f;
	Text text;
	// Use this for initialization
	void Start ()
	{
		counter = -1;
		text = GetComponent<Text> ();
		text.text = "Hey can you tell me where I am? Also how am I alive? Also who are you?";
		Time.timeScale = 0.0f;
		zombieKingDead = 0;
		zkd = zombieKingDead;
	}

	// Update is called once per frame
	void Update ()
	{
		if (timeLeft <= 0.0f) {
			Application.LoadLevel ("SchoolLevel");
		} else if (counter == 10) {
			text.text = "You fool!Do you realize what you’ve done!? ";
			counter++;
		} else if (counter == 19) {
			textBox.transform.localPosition = new Vector3 (textBox.transform.localPosition.x + 12000.0f, textBox.transform.localPosition.y, textBox.transform.localPosition.z);
			print ("countdownstarted");
			timeLeft -= Time.deltaTime;
		} else if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0)) {
			counter++;
			if (counter == 0) {
				text.text = "You there! Why aren’t you obeying my orders? You should be attacking the town.";
			} else if (counter == 1) {
				text.text = "..Why";
			} else if (counter == 2) {
				text.text = "For Matilda’s Revenge of course!";
			} else if (counter == 3) {
				text.text = "...Who";
			} else if (counter == 4) {
				text.text = "Stop with all the questions, you should just obey my command!";
			} else if (counter == 5) {
				text.text = "...Why";
			} else if (counter == 6) {
				text.text = "Enough! If you won’t listen i’ll just put back in the ground.";
			} else if (counter == 7) {
				text.text = "...How?";
			} else if (counter == 8) {
				text.text = " ";
				Time.timeScale = 1f;
				textBox.transform.localPosition = new Vector3 (textBox.transform.localPosition.x + 12000.0f, textBox.transform.localPosition.y, textBox.transform.localPosition.z);
				counter = 9;
				print (counter);
			}
            //print(counter);
            else if (counter == 10) {
				text.text = "You fool! Do you realize what you’ve done!?";
			} else if (counter == 12) {
				text.text = "...Not particularly, no.";
			} else if (counter == 13) {
				text.text = "Very well! I shall explain it to you… with exposition! I, the Great, the Mighty, the Handsome King of all the zombies…. George… have personally been tasked by the Evil Witch Matilda to lead her zombie army to take over the World! Mwahahaha";
			} else if (counter == 14) {
				text.text = "So if I stop this witch lady then I stop the zombie apocalypse?";
			} else if (counter == 15) {
				text.text = "What!? *cough * *cough * Noooooooo… I never said that.. like how I also never said that she also has the power to fully bring you back to life if you defeat her either";
			} else if (counter == 16) {
				text.text = "Cool, imma go do that.";
			} else if (counter == 17) {
				text.text = "Curses! Defeated by my own humerus.";
			} else if (counter == 18) {
				text.text = "...-hubris";
				Time.timeScale = 1f;
			}
		}
	}
}