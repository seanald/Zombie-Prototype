using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour
{
	public PlayerModel zombie;
	public PlayerModel ghost;

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
