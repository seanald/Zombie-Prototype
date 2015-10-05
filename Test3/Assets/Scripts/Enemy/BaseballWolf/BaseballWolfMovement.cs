using UnityEngine;
using System.Collections;

public class BaseballWolfMovement : MonoBehaviour {

	private Animator enemyAnimator;
	private Transform player;
	private float distance;
	private float maxdistance = 50f;
	
	void Start()
	{
		this.enemyAnimator = this.gameObject.GetComponentInChildren<Animator>();
		this.player = GameObject.Find("ZombieController").transform;
	}
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance(this.player.position, this.transform.position) > 50 && Vector3.Distance(this.player.position, this.transform.position) < 1000)
		{
			float step = 100 * Time.deltaTime;
			//move towards the player
			this.transform.position = Vector3.MoveTowards(transform.position, player.position, step);



				
			this.enemyAnimator.Play("Batwolf_Walk");

		}
		else
		{
			if(Vector3.Distance(this.player.position, this.transform.position) < 70){
				RaycastHit hit;
				Debug.DrawLine(transform.position, transform.right * 100, Color.green);
				if (Physics.Raycast(transform.position, transform.right, out hit))
				{
					distance = hit.distance;
					//print(distance);
					//print(hit.transform.tag);
					if (distance < maxdistance && hit.transform.tag == "Player")
					{
						GameObject enemyhit = hit.transform.gameObject;
						enemyhit.GetComponent<ZombieModel>().Health--;
					}
				}
				this.enemyAnimator.Play("Batwolf_Swing");
			}
			else{
				this.enemyAnimator.Play("Batwolf_Stand");
			}
		}
	}
}
