using UnityEngine;
using System.Collections;

public class Player : Character
{
	public bool isActivePlayer;
	public bool right;

	protected void Start()
	{
		base.Start();
	}

	void LateUpdate()
	{
		if (this.isActivePlayer)
		{
			this.gameObject.tag = "ActivePlayer";
		}
		else
		{
			this.gameObject.tag = "Player";
		}

		Vector3 scale = transform.localScale;

		if (forcesVec.x > 0 || this.moveVec.x > 0)
		{
			scale.x = 1;
			right = true;
		}
		else if (forcesVec.x < 0 || this.moveVec.x < 0)
		{
			scale.x = -1;
			right = false;
		}

		this.transform.localScale = scale;
	}

	public override Vector3 Forces()
	{
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 moveDirection = Vector3.zero;

		if (this.isActivePlayer)
		{
			if (controller.isGrounded)
			{
				moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
				moveDirection *= this.moveSpeed;
			}
		}

		moveDirection.y -= Mathf.Round(8000 * Time.deltaTime);

		return moveDirection;
	}
}
