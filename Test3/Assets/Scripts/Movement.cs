using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public float speed;
	public float jumpSpeed = 8.0f;

	private Rigidbody rb;
	private Animator animator;
	private bool walking = false;
	private bool kicking = false;


	private Vector3 moveDirection = Vector3.zero;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		animator = this.GetComponentInChildren<Animator>();
	}
	
	void FixedUpdate ()
	{
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			if (moveHorizontal != 0 || moveVertical != 0) {
				walking = true;
			} else {
				walking = false;
			}

			if (walking) {
				moveDirection = new Vector3 (moveHorizontal * 0.5f, 0.0f, moveVertical);
				moveDirection *= speed;
			}
			if (Input.GetKey (KeyCode.Space)) {
				moveDirection.y = jumpSpeed;
			}
		} else {
			walking = false;
		}
		animator.SetBool ("walking", walking);

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
		animator.SetBool ("kicking", kicking);

	}
}