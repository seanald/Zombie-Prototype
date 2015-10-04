using UnityEngine;
using System.Collections;

public class PlayerWalking : MonoBehaviour
{	
	private CharacterController controller;
	private PlayerModel playerModel;

	void Start()
	{
		this.controller = this.GetComponentInParent<CharacterController>();
		this.playerModel = this.GetComponentInParent<PlayerModel>();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 moveDirection = Vector3.zero;

		if (this.playerModel.IsActivePlayer)
		{
			if (controller.isGrounded)
			{
				moveDirection = new Vector3(moveHorizontal, -8000f, moveVertical);
				moveDirection *= this.playerModel.WalkSpeed;
			}
		}

		moveDirection.y -=  Mathf.Round(8000 * Time.deltaTime);
		controller.Move(moveDirection * Time.deltaTime);
	}

}
