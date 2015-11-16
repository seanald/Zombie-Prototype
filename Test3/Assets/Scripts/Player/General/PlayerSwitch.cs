using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour
{
	private Player zombie;
	private Player ghost;

	public GameObject zombie_On; //zombie on text
	public GameObject zombie_Off; // zombie off text
	public GameObject ghost_On; // ghost on text
	public GameObject ghost_Off; // ghost off text

	void Start()
	{
		zombie_On.SetActive (true);
		zombie_Off.SetActive (false);
		ghost_On.SetActive (false);
		ghost_Off.SetActive (true);

		zombie = GameObject.Find("ZombieController").GetComponent<Player>();
		ghost = GameObject.Find("GhostController").GetComponent<Player>();
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton5))
		{
			if(this.zombie.isActivePlayer)
			{
				zombie.isActivePlayer = false;
				ghost.isActivePlayer = true;

				zombie_On.SetActive (false);
				zombie_Off.SetActive (true);
	            ghost_On.SetActive (true);
	            ghost_Off.SetActive (false);
			}
			else if (this.ghost.isActivePlayer)
			{
				this.ghost.isActivePlayer = false;
				this.zombie.isActivePlayer = true;

				zombie_On.SetActive(true);
				zombie_Off.SetActive (false);
				ghost_On.SetActive (false);
				ghost_Off.SetActive (true);
			}
		}
	}
}
