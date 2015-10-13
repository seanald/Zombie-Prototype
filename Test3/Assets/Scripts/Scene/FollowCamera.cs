using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowCamera : MonoBehaviour
{
	public float dampTime = 1.15f;
	
	private string leftBoundsTag = "LeftCameraBounds";
	private string rightBoundsTag = "RightCameraBounds"; 
	private Vector3 velocity = Vector3.zero;
	private float leftBoundary;
	private float rightBoundary;
	private float width;
	private float height;
	
	void Start()
	{
		Camera cam = Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
	}
	
	void Update()
	{
		List<GameObject> rightBounds = new List<GameObject>(GameObject.FindGameObjectsWithTag(this.rightBoundsTag));
		List<GameObject> leftBounds = new List<GameObject>(GameObject.FindGameObjectsWithTag(this.leftBoundsTag));
		
		rightBounds.Sort(delegate(GameObject c1, GameObject c2){
			return Vector3.Distance(this.transform.position, c1.transform.position).CompareTo
				((Vector3.Distance(this.transform.position, c2.transform.position)));   
		});
		
		leftBounds.Sort(delegate(GameObject c1, GameObject c2){
			return Vector3.Distance(this.transform.position, c1.transform.position).CompareTo
				((Vector3.Distance(this.transform.position, c2.transform.position)));   
		});
		
		this.leftBoundary = leftBounds[0].transform.position.x + width / 2;
		this.rightBoundary = rightBounds[0].transform.position.x - width / 2;
		
		GameObject player = GameObject.FindWithTag("ActivePlayer");
		if (player)
		{
			Vector3 pos = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z), ref velocity, dampTime);
			pos.x = Mathf.Clamp(pos.x, this.leftBoundary, this.rightBoundary);
			transform.position = pos;
		}
	}
}