using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
	public float LockedY = 0;
	public float LockedZ = 0;
	public GameObject player;
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;

	void Update()
	{
		transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x, LockedY, LockedZ), ref velocity, dampTime);
	}
}
