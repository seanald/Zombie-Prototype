using UnityEngine;
using System.Collections;

public class DecayHealth : Player {

	// Use this for initialization
	void Start () {
		InvokeRepeating("HealthDecay", 1, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void HealthDecay()
	{
		GameObject.Find("ZombieController").GetComponentInParent<Health>().CurHealth--;
	}
}
