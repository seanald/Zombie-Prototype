using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

	public float speed;
	public float jumpSpeed = 8.0f;
	public bool isActivePlayer;
	private Animator animator;
	private bool walking = false;
	private bool kicking = false;
	private Vector3 moveDirection = Vector3.zero;

	void Start()
	{
		this.animator = this.GetComponentInChildren<Animator>();
	}

	void FixedUpdate()
	{

		CharacterController controller = GetComponent<CharacterController>();

		if (this.isActivePlayer)
		{
			if (controller.isGrounded)
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

		moveDirection.y -= 20 * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		if (Input.GetKey(KeyCode.X))
		{
			kicking = true;
		}
		else
		{
			kicking = false;
		}

		if (this.animator)
		{
			animator.SetBool("kicking", kicking);
			animator.SetBool("walking", walking);
		}
	}
}