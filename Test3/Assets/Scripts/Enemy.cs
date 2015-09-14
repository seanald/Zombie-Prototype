using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int moveSpeed;

	private Transform player;

	void Update()
	{
		player = GameObject.Find("Zombie").transform;
	}

	void FixedUpdate()
	{
		if (player)
		{
			if (Vector3.Distance(player.transform.position, transform.position) < 10 && Vector3.Distance(player.transform.position, transform.position) > 1)
			{
				float step = moveSpeed * Time.deltaTime;
				//move towards the player
				this.transform.position = Vector3.MoveTowards(transform.position, player.position, step);
			}

			if (Vector3.Distance(player.transform.position, transform.position) > 10)
			{
				moveSpeed = Mathf.Abs(moveSpeed);
			}
		}
	}
}
