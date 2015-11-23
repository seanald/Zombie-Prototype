using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class dialogue_beforeVlad : MonoBehaviour {
	
	public static int counter;
	public GameObject textBox;
    public float timeLeft = 5.0f;

    Text text;
	// Use this for initialization
	void Start ()
	{
		counter = -1;
		text = GetComponent<Text>();
		text.text = "Uh excuse me.. I was hoping you could help me find something?";
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timeLeft <= 0.0f)
        {
            Application.LoadLevel("TownLevel");
        }
        else if (counter == 8)
        {
            text.text = "Oh, my break’s over";
            counter++;
        }
        else if (counter == 21)
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
				text.text = "Um? I’m on my lunch break. Before I go back to serving the enslaved drones of the masses, I’d rather not waste my time engaging with the likes of you.";
			}
			else if (counter == 1)
			{
				text.text = "Lunch? It’s midnight. Also, are you wearing.. shutter shades? Are you actually wearing shutter shades? Indoors? At night?";
			}
			else if (counter == 2)
			{
				text.text = "You vile- I’ll have you know this uniform is the pinnacle of the post-grunge low-fi chillwave electroni-core squad goals indie aesthetic. I even bought and painted these shades black to imbue my work uniform with my keen sense of style.";
			}
			else if (counter == 3)
			{
				text.text = "You actually took the time to paint those? They stopped being popular seven years ago! They aren’t even practical! Look, will you just help me out?";
			}
			else if (counter == 4)
			{
				text.text = "THAT’S THE POINT! If you even have to ask you clearly don’t get it and now you’ve ruined my break. So now I’m done speaking. Come at me!";
			}
			else if (counter == 5)
			{
				text.text = "Yeah, and I’m sure that cape is part of the uniform too";
			}
			else if (counter == 6)
			{
                counter = 7;
				text.text = " ";
                Time.timeScale = 1;
                textBox.transform.localPosition = new Vector3(textBox.transform.localPosition.x + 12000.0f, textBox.transform.localPosition.y, textBox.transform.localPosition.z);
            }
            else if (counter == 7)
            {
                names_Vlad.counter = 0;
                text.text = "Oh, my break’s over";
            }
            else if (counter == 8)
            {
                text.text = "Wait, what?";
            }
            else if (counter == 9)
            {
                text.text = "I’ll see you at the counter. Hi, welcome to Hot Gothic. Can I help you with anything?";
            }
            else if (counter == 10)
            {
                text.text = "Uhh.. yea.. I’m looking for a witch. I was told you would know.";
            }
            else if (counter == 11)
            {
                text.text = "A witch? Oh. Wait. Last week I went to a donation drive and my blood was stolen by one";
            }
            else if (counter == 12)
            {
                text.text = "A vampire giving blood!?  Why does everything you do have to be drenched in like eight layers of irony?";
            }
            else if (counter == 13)
            {
                text.text = "Next level aesthetic. As it happens, our blood has many health benefits. It could’ve even saved your life before you died. How’d you die anyways?";
            }
            else if (counter == 14)
            {
                text.text = "Oh.. the Big ‘C’ I’m afraid.";
            }
            else if (counter == 15)
            {
                text.text = "Cereal… choked to death.";
            }
            else if (counter == 16)
            {
                text.text = "...And I’m supposed to be ironic? Well, I’d say she’d be passing through the Town at this point. Before you head off, I’ll teach you how to Chomp enemies, you should find it useful.";
            }
            else if (counter == 17)
            {
                text.text = "I can’t imagine that many parental groups would be too thrilled by me doing that. I’m undead, remember?";
            }
            else if (counter == 18)
            {
                text.text = "Meh.. it’s a town full of monsters, so you should be fine.";
            }
            else if (counter == 19)
            {
                text.text = "Well, if you’re sure";
            }
            else if (counter == 20)
            {
                text.text = "No problem bud. And remember, it’s always all about the aesthetic";
            }
        }
	}
}