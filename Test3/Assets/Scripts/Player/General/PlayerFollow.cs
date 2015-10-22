using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour
{
	public GameObject target;
	private Vector3 targetPosition;

	public Vector3 offset;

	private float distance;

	void FixedUpdate()
	{
		targetPosition = this.target.transform.position;
		distance = (transform.position - targetPosition).magnitude;

		float x = 0.0f;
		float y = 0.0f;
		float z = 0.0f;
		if (targetPosition != null)
		{
			x = targetPosition.x;
			y = targetPosition.y;
			z = targetPosition.z;
		}

		Vector3 target_pos = new Vector3(x, y, z);

		if (!this.GetComponentInChildren<Player>().isActivePlayer && distance > 100)
		{
			Vector3 moveVector = (target_pos + this.offset) - transform.position;
			this.GetComponentInChildren<Player>().RawMovement(moveVector.normalized);
		}
	}
}
