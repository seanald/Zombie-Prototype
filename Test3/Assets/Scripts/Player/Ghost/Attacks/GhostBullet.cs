using UnityEngine;
using System.Collections;

public class GhostBullet : MonoBehaviour {
	
	float Speed = 25f;
	float BulletLifeTime = 1f;
	private float startTime;
	private bool left;
	
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		if(GameObject.Find("GhostController").GetComponent<Player>().right == true){
			left=false;
		}
		if(GameObject.Find("GhostController").GetComponent<Player>().right == true){
			left=true;
		}
		print(left);
	}
	
	// Update is called once per frame
	void Update () {

		if(left==false){
			this.gameObject.transform.position += Speed * this.gameObject.transform.right * -1;
		}
		if(left==true){
			this.gameObject.transform.position += Speed * this.gameObject.transform.right;
		}

		
		if (Time.time - startTime >= BulletLifeTime)
		{
			Destroy(this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision collision){

			Destroy(this.gameObject);
		
		
	}
}



