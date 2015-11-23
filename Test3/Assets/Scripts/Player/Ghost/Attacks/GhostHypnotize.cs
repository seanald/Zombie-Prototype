using UnityEngine;
using System.Collections;

public class GhostHypnotize : MonoBehaviour {

	private GameObject mytarget;
	private const int maxdistance = 10;
	public GameObject Bullet;
	public Vector3 GBoffset;

	void Fire(){
		if(this.GetComponent<Player>().right == true){
			Instantiate(Bullet, transform.position + GBoffset, transform.rotation);
		}
		if(this.GetComponent<Player>().right == false){
			Instantiate(Bullet, transform.position - GBoffset, transform.rotation);
		}
	}
	
	void Update () 
	{


		if (((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.JoystickButton1)) && this.GetComponentInParent<Plasma>().CurPlasma > 0) && GameObject.Find("GhostController").tag == "ActivePlayer")
		{
			Fire();

			this.GetComponentInParent<Plasma>().CurPlasma--;
		}
	}

}