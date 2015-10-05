using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour
{
	private PlayerModel zombie;
	private PlayerModel ghost;

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

		zombie = GameObject.Find("ZombieController").GetComponent<PlayerModel>();
		ghost = GameObject.Find("GhostController").GetComponent<PlayerModel>();
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			if(this.zombie.IsActivePlayer)
			{
				zombie.IsActivePlayer = false;
				ghost.IsActivePlayer = true;

				zombie_On.SetActive (false);
				zombie_Off.SetActive (true);
	            ghost_On.SetActive (true);
	            ghost_Off.SetActive (false);
			}
			else if (this.ghost.IsActivePlayer)
			{
				this.ghost.IsActivePlayer = false;
				this.zombie.IsActivePlayer = true;

				zombie_On.SetActive(true);
				zombie_Off.SetActive (false);
				ghost_On.SetActive (false);
				ghost_Off.SetActive (true);
			}
		}
	}
}
