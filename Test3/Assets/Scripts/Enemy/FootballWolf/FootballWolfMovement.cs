using UnityEngine;
using System.Collections;

public class FootballWolfMovement : MonoBehaviour {

	private Animator enemyAnimator;
	private Transform player;
	
	void Start()
	{
		this.enemyAnimator = this.gameObject.GetComponentInChildren<Animator>();
		this.player = GameObject.Find("ZombieController").transform;
	}
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance(this.player.position, this.transform.position) > 400 && Vector3.Distance(this.player.position, this.transform.position) < 1000)
		{
			float step = 100 * Time.deltaTime;
			//move towards the player
			this.transform.position = Vector3.MoveTowards(transform.position, player.position, step);
			this.enemyAnimator.Play("FootballWolf_Walk");
		}
		else
		{
			this.enemyAnimator.Play("FootballWolf_Stand");
		}
	}
}
