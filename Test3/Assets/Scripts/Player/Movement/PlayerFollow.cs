using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour
{
	private PlayerModel playerModel;
	void Start()
	{
		this.playerModel = this.GetComponentInParent<PlayerModel>();
	}

	void FixedUpdate()
	{
		if (!this.playerModel.isActivePlayer && Vector3.Distance(this.playerModel.followPlayerGameObject.transform.position, this.transform.position) > 100)
		{
			float step = this.playerModel.WalkSpeed * Time.deltaTime;
			//move towards the player
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.playerModel.followPlayerGameObject.transform.position, step);
		}
	}
}
