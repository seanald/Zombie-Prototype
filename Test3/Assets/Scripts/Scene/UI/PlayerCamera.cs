using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
	public float dampTime = 1.15f;
	public GameObject leftBoundaryObject;
	public GameObject rightBoundaryObject;

	private Vector3 velocity = Vector3.zero;
	private float leftBoundary;
	private float rightBoundary;

	void Start()
	{
		Camera cam = Camera.main;
		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;

		this.leftBoundary = this.leftBoundaryObject.transform.position.x + width / 2;
		this.rightBoundary = this.rightBoundaryObject.transform.position.x - width / 2;
	}

	void Update()
	{
		GameObject player = GameObject.FindWithTag("ActivePlayer");
		if (player)
		{
			Vector3 pos = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z), ref velocity, dampTime);
			pos.x = Mathf.Clamp(pos.x, this.leftBoundary, this.rightBoundary);
			transform.position = pos;
		}
	}
}
