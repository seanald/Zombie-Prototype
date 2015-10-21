using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour
{
	private PlayerModel playerModel;
	private Vector3 targetPosition;

	public Vector3 offset;

	// How much we
	public float followDamping = 2.0f;

	private Transform focusPoint;
	private float distance;

	void Start()
	{
		this.playerModel = this.GetComponentInParent<PlayerModel>();

		targetPosition = this.playerModel.followPlayerGameObject.transform.position;
		distance = (transform.position - targetPosition).magnitude;
	}

	void FixedUpdate()
	{
		targetPosition = this.playerModel.followPlayerGameObject.transform.position;

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

		if (!this.playerModel.isActivePlayer && distance > 100)
		{
			transform.position = Vector3.Lerp(transform.position, target_pos + this.offset,
				followDamping * Time.deltaTime);
		}
	}
}
