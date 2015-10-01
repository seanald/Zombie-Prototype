using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour
{
	private PlayerModel zombie;
	private PlayerModel ghost;

	void Start()
	{
		zombie = GameObject.Find("ZombieController").GetComponent<PlayerModel>();
		ghost = GameObject.Find("GhostController").GetComponent<PlayerModel>();
	}
	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.R))
		{
			if(this.zombie.IsActivePlayer)
			{
				zombie.IsActivePlayer = false;
				ghost.IsActivePlayer = true;
			}
			else if (this.ghost.IsActivePlayer)
			{
				this.ghost.IsActivePlayer = false;
				this.zombie.IsActivePlayer = true;
			}
		}
	}
}
