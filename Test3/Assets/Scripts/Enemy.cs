using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int moveSpeed;
	public int init_health;

	private Transform player;

	void Update()
	{
		player = GameObject.Find("Zombie").transform;
		print(init_health);
	}

	void FixedUpdate()
	{
		if (player)
		{
			if (Vector3.Distance(player.transform.position, transform.position) < 10 && Vector3.Distance(player.transform.position, transform.position) > 1.5)
			{
				float step = moveSpeed * Time.deltaTime;
				//move towards the player
				this.transform.position = Vector3.MoveTowards(transform.position, player.position, step);
			}
		}
		if(init_health<=0)
		{
			Destroy(this.gameObject);
		}
	}
}
