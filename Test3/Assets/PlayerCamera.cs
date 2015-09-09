using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public float LockedY = 0;
	public float LockedZ = 0;
	
	
	public GameObject player;
	
	
	void Update()
	{
		transform.position = new Vector3(player.transform.position.x, LockedY, LockedZ);
	}
}
