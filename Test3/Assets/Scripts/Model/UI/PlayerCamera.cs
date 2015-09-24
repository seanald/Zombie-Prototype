using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
	public float LockedY = 0;
	public float LockedZ = 0;
	public GameObject player;
	public float dampTime = 1.15f;
	public GameObject leftBoundaryObject;
	public GameObject rightBoundaryObject;

	private Vector3 velocity = Vector3.zero;
	private float leftBoundary;
	private float rightBoundary;

	void Start ()
	{
		Camera cam = Camera.main;
		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;

		this.leftBoundary = this.leftBoundaryObject.transform.position.x + width/2;
		this.rightBoundary = this.rightBoundaryObject.transform.position.x - width/2;
	}

	void Update()
	{
		Vector3 pos = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x, LockedY, LockedZ), ref velocity, dampTime);
		pos.x = Mathf.Clamp(pos.x, this.leftBoundary, this.rightBoundary);
		transform.position = pos;
	}
}
