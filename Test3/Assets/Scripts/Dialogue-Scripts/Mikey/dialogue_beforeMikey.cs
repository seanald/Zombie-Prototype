using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class dialogue_beforeMikey : MonoBehaviour {
	
    public GameObject textBox;
    public float timeLeft = 5.0f;
    public static int counter;

    Text text;
	// Use this for initialization
	void Start ()
	{
		counter = -1;
		text = GetComponent<Text>();
		text.text = "So you’re the Monster that’s been attacking everyone!";
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (timeLeft <= 0.0f)
        {
            Application.LoadLevel("MallLevel");
        }
        else if (counter == 10)
        {
            text.text = "As I was saying before, I don’t actually want to hurt anyone.";
            counter++;
        }
        else if (counter == 20)
        {
            textBox.transform.localPosition = new Vector3(textBox.transform.localPosition.x + 12000.0f, textBox.transform.localPosition.y, textBox.transform.localPosition.z);
            print("countdownstarted");
            timeLeft -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Return))
		{
			counter++;
			if (counter == 0)
			{
				text.text = "What? Can we just ta-";
			}
			else if (counter == 1)
			{
				text.text = "ARE YOU THE MONSTER THAT’S BEEN ATTACKING EVERYONE?!";
			}
			else if (counter == 2)
			{
				text.text = "If you just quit howl";
			}
			else if (counter == 3)
			{
				text.text = "SO YOU’RE THE MONSTER THAT’S BEEN ATTACKING EVERYONE!!!";
			}
			else if (counter == 4)
			{
				text.text = "Stop with all the questions, you should just obey my command!";
			}
			else if (counter == 5)
			{
				text.text = "If you just let me exp-";
			}
			else if (counter == 6)
			{
				text.text = "Nah, bro! I’m not about all that noise! Don’t you throw that exposition at me! Let’s FIGHT! GO WILDCATS! ";
			}
			else if (counter == 7)
			{
                text.text = " ";
                Time.timeScale = 1f;
                textBox.transform.localPosition = new Vector3(textBox.transform.localPosition.x + 12000.0f, textBox.transform.localPosition.y, textBox.transform.localPosition.z);
                counter = 8;
                print(counter);
            }
            else if (counter == 9)
            {
                text.text = "As I was saying before, I don’t actually want to hurt anyone.";
            }
            else if (counter == 10)
            {
                text.text = "Wait you’re telling me you’re actually a Good Zombie!?";
            }
            else if (counter == 11)
            {
                text.text = "Yes, and if you just let me explain earlier without interrupt-";
            }
            else if (counter == 12)
            {
                text.text = "Oh, my b. You should’ve said something earlier. So what’s a Zombie doing here anyways?";
            }
            else if (counter == 13)
            {
                text.text = "A Witch resurrected the dead and wants to take over the world and i’m trying to stop her. Do you know where-?";
            }
            else if (counter == 14)
            {
                text.text = "Nah fam, I don’t know any witches, but my bud, Vlad, might. He works at the mall, you should go there.";
            }
            else if (counter == 15)
            {
                text.text = "Thanks, I’ll head there now-";
            }
            else if (counter == 16)
            {
                text.text = "Hold up! Before you roll out I’ll teach you how to do a Lunge Attack. It’s a great ability for closing the distance and attacking enemies.";
            }
            else if (counter == 17)
            {
                text.text = "Wow, that actually sounds useful?";
            }
            else if (counter == 18)
            {
                text.text = "Yeah! I use it to knock over the school bus! And since you don't go here, you won't get suspended like me";
                Time.timeScale = 1f;
            }
        }
	}
}