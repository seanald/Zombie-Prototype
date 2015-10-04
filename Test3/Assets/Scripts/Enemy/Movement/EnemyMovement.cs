using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

	private Transform player;
	private EnemyController enemyController;

	// Use this for initialization
	void Start()
	{
		this.player = GameObject.Find("ZombieController").transform;
		this.enemyController = this.GetComponentInParent<EnemyController>();
	}
	
	void FixedUpdate()
	{
		if (player)
		{
			if (Vector3.Distance(player.transform.position, transform.position) < 10 && Vector3.Distance(player.transform.position, transform.position) > 1)
			{
				float step = enemyController.walkSpeed * Time.deltaTime;
				//move towards the player
				this.transform.position = Vector3.MoveTowards(transform.position, player.position, step);
			}
			
			if (Vector3.Distance(player.transform.position, transform.position) > 10)
			{
				enemyController.walkSpeed = Mathf.Abs(enemyController.walkSpeed);
			}
		}
	}

	void OnCollisionEnter(Collision collision){
		print(collision.gameObject.tag);
		if (collision.gameObject.tag == "GhostBullet")
		{
			enemyController.walkSpeed = 0;
		}
	}
}
