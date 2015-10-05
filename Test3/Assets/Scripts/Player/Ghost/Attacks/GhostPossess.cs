using UnityEngine;
using System.Collections;

public class GhostPossess : MonoBehaviour {

	public GameObject mytarget;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.T)/* && this.GetComponent<PlasmaController>().curPlasma > 0*/)
		{

			//mytarget.GetComponent<BaseballWolfMovement>.movespeed = -100;

		}
	}
	



}
