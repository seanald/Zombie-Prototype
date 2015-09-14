using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

	public float speed;
	public float jumpSpeed = 8.0f;
	public bool isActivePlayer;
	private Animator animator;
	private bool walking = false;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	void Start()
	{
		this.animator = this.GetComponentInChildren<Animator>();
		this.controller = this.GetComponent<CharacterController>();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		if (moveHorizontal != 0 || moveVertical != 0)
		{
			walking = true;
		}
		else
		{
			walking = false;
		}

		if (this.isActivePlayer)
		{
			if (controller.isGrounded)
			{

				if (walking)
				{
					moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
					moveDirection *= speed;
				}
				else
				{
					moveDirection = Vector3.zero;
				}
				if (Input.GetKey(KeyCode.Space))
				{
					moveDirection.y = jumpSpeed;
				}

			}
			else
			{
				walking = false;
			}
		}
		else
		{
			this.moveDirection = Vector3.zero;
		}

		moveDirection.y -= 20 * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);



		if (this.animator)
		{
			animator.SetBool("walking", walking);
		}
	}

	public void setActivePlayer(bool active)
	{
		this.isActivePlayer = active;
	}
}
