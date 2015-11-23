using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class dialogue_beforeGenPat : MonoBehaviour {
	
	public static int counter;
	public GameObject textBox;
    public float timeLeft = 5.0f;

    Text text;
	// Use this for initialization
	void Start ()
	{
		counter = -1;
		text = GetComponent<Text>();
		text.text = "Hey who let this one through!? Oh well, a chance to grease up my shot with a little game.";
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (timeLeft <= 0.0f)
        {
            Application.LoadLevel("MenuScene");
        }
        else if (counter == 10)
        {
            text.text = "Are you out of bad one-liners yet?";
            counter++;
        }
        else if (counter == 27)
        {
            Time.timeScale = 1;
            textBox.transform.localPosition = new Vector3(textBox.transform.localPosition.x + 12000.0f, textBox.transform.localPosition.y, textBox.transform.localPosition.z);
            print("countdownstarted");
            timeLeft -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Return))
		{
			counter++;
            if (counter == 0)
            {
                text.text = "You like games? I know a fun one. It’s called ‘Hey Please Don’t Attack I Have to go Through This Everytime I Pass Through a New Place and I Never Actually Want to Fight any of You.’ ";
            }
            else if (counter == 1)
            {
                text.text = "“I have a better one. Have you ever shot a cow at a rocket before? I have. Wai- well you get the point, I’m gonna shoot rockets at your head";
            }
            else if (counter == 2)
            {
                text.text = "I feel like you actually rehearsed that line. Sorry it didn’t work out.";
            }
            else if (counter == 3)
            {
                text.text = "Hush! I’m here to kick ass and chew bubblegum. And I’m all out of ass.";
            }
            else if (counter == 4)
            {
                text.text = "Oh my god are you even hearing yourself? I’m actually on your side!";
            }
            else if (counter == 5)
            {
                text.text = "Don’t lie to me boy. It’s high time someone pushed.. daisies.. at you.";
            }
            else if (counter == 6)
            {
                text.text = "What?";
            }
            else if (counter == 7)
            {
                counter = 8;
                text.text = "Aghh!";
                textBox.transform.localPosition = new Vector3(textBox.transform.localPosition.x + 12000.0f, textBox.transform.localPosition.y, textBox.transform.localPosition.z);
                Time.timeScale = 1f;
            }
            else if (counter == 11)
            {
                text.text = "Aghh!";
            }
            else if (counter == 12)
            {
                text.text = "I just can't quit you";
            }
            else if (counter == 13)
            {
                text.text = "Oh, no.";
            }
            else if (counter == 14)
            {
                text.text = "You’re stronger than you look.";
            }
            else if (counter == 15)
            {
                text.text = "Do you give up?";
            }
            else if (counter == 16)
            {
                text.text = "Boy, I’m this Town’s last hope. It’s up to me to see that you monsters don’t make it out of here unless it’s in chunks.";
            }
            else if (counter == 17)
            {
                text.text = "I have no intentions of hurting anyone. I’m actually on my way to stop the Zombie Apocalypse";
            }
            else if (counter == 18)
            {
                text.text = "Well butter my Sheryl and call me biscuit. A zombie who doesn’t want to be a zombie";
            }
            else if (counter == 19)
            {
                text.text = "Okay biscuit, can you help me?";
            }
            else if (counter == 20)
            {
                text.text = "Don’t call me biscuit, boy.";
            }
            else if (counter == 21)
            {
                text.text = "I’ll call you whatever you want, can you just tell me where I can find a witch?";
            }
            else if (counter == 22)
            {
                text.text = "A witch. A Witch? A WITCH!... Yeah, we kicked her out last week for practicing magic. Not the cool birthday party coin-in-your-ear kind. Well, she actually did that once. But the coins never stopped coming and they weren’t even real. Things got.. a little weird.";
            }
            else if (counter == 23)
            {
                text.text = "Where can I find her?";
            }
            else if (counter == 24)
            {
                text.text = "We exiled her towards the forest on the outskirts of Town.";
            }
            else if (counter == 25)
            {
                text.text = "Thanks Lieutenant Lucifer.";
            }
            else if (counter == 26)
            {
                text.text = "...Get out of My Town boy.";
            }
        }
	}
}