using UnityEngine;
using System.Collections;

public class FootballWolfMovement : MonoBehaviour {

	private Animator enemyAnimator;
	private Transform player;
	private bool isStunned = false;
	private float stunTime;
	float stunnedTime = 2f;
	public GameObject football;
	public Vector3 footballoffset;
	private bool thrown = false;
	public float movespeed;
	
	void Start()
	{
		movespeed = 100;
		this.enemyAnimator = this.gameObject.GetComponentInChildren<Animator>();
		this.player = GameObject.Find("ZombieController").transform;
	}
	// Update is called once per frame
	void Update () 
	{
		if(isStunned){
			this.enemyAnimator.Play("FootballWolf_Stunned");
		}
		if(!isStunned){
			if (Vector3.Distance(this.player.position, this.transform.position) > 400 && Vector3.Distance(this.player.position, this.transform.position) < 600)
			{
				float step = movespeed * Time.deltaTime;
				//move towards the player
				this.transform.position = Vector3.MoveTowards(transform.position, player.position, step);
				this.enemyAnimator.Play("FootballWolf_Walk");
			}
			else
			{
				if(Mathf.Round(Time.time)%4==0){
					this.enemyAnimator.Play("FootballWolf_Throw");
					if(!thrown){
						Instantiate(football, transform.position + footballoffset, transform.rotation);
						thrown = true;
					}
				}
				else{
					this.enemyAnimator.Play("FootballWolf_Stand");
					thrown=false;
				}
			}
		}
		else if (Time.time - stunTime >= stunnedTime)
		{
			isStunned = false;
		}
	}

	void OnCollisionEnter(Collision collision){
		
		if(collision.gameObject.tag == "GhostBullet"){
			isStunned = true;
			stunTime = Time.time;
		}
	}
}
