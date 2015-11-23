using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class dialogue_beforeMatilda : MonoBehaviour {
	
	public static int counter;
	public GameObject textBox;
    public float timeLeft = 5.0f;

    Text text;
	// Use this for initialization
	void Start ()
	{
		counter = -1;
		text = GetComponent<Text>();
		text.text = "“Hey little girl, I’m looking for an evil witch. You wouldn’t happen to know where I can find her, would you?";
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (timeLeft <= 0.0f)
        {
            Application.LoadLevel("MenuScene");
        }
        else if (counter >= 27)
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
				text.text = "Don’t patron-size me you stupid zombie. I am the Great Witch Matilda!";
			}
			else if (counter == 1)
			{
				text.text = "Well aren’t you just the cutest thing. You know it’s dangerous to play in a forest like this by yourself! Are your parents around? I have to have a grown-up conversation with them.";
			}
			else if (counter == 2)
			{
				text.text = "You in-soylent fool! You dare mock me when you should be worshipping me! It just so happens that I gave you stupid zombies life so you can do my bidding. What gives you the right to address me so informally? No, seriously what. I may have to recast the spell.";
			}
			else if (counter == 3)
			{
				text.text = ".Really? You’re the Evil Witch? You’re some grand scheming mastermind behind everything? A little girl";
			}
			else if (counter == 4)
			{
				text.text = "Yes I Am! And for you’re information i’m over a hundred years old. Your reeaallly getting on my nerves you.. you.. big stupid meanie face.";
			}
			else if (counter == 5)
			{
				text.text = "Hey that’s not nice. You want me to put you in time out little missy?";
			}
			else if (counter == 6)
			{
				text.text = "Grrrr you think your sooo clever, well lets see wholl put who in time out";
			}
			else if (counter == 7)
			{
                counter = 8;
                text.text = "Don’t think you’ve won yet you stupid zombie.";
                textBox.transform.localPosition = new Vector3(textBox.transform.localPosition.x + 12000.0f, textBox.transform.localPosition.y, textBox.transform.localPosition.z);
                Time.timeScale = 1f;
            }
            else if (counter == 11)
            {
                names_Matilda.counter = 0;
                text.text = "Hey now don’t be a sore loser. It’s time to put you in time out.";
            }
            else if (counter == 12)
            {
                text.text = "Hehe..  you forget that I still have my Zombie Army!";
            }
            else if (counter == 13)
            {
                text.text = "You mean those guys outside? I took care of them before I got here..";
            }
            else if (counter == 15)
            {
                text.text = "But… but… noooooo my evil plan.";
            }
            else if (counter == 16)
            {
                text.text = "It’s over, now put everything back to the way it was and think about what you’ve done.";
            }
            else if (counter == 17)
            {
                text.text = "Nnnnno!";
            }
            else if (counter == 18)
            {
                text.text = "Matildaaa!";
            }
            else if (counter == 19)
            {
                text.text = "Noooooooooooooooo";
            }
            else if (counter == 20)
            {
                text.text = "One";
            }
            else if (counter == 21)
            {
                text.text = "No!No!No!";
            }
            else if (counter == 22)
            {
                text.text = "Twooooo";
            }
            else if (counter == 23)
            {
                text.text = "Waaaaaaaaaaah";
            }
            else if (counter == 24)
            {
                text.text = "Two and a half";
            }
            else if (counter == 25)
            {
                text.text = "Fine!";
            }
            else if (counter == 26)
            {
                text.text = "Good girl, now let’s go back to Town and apologize to everyone";
            }
        }
	}
}