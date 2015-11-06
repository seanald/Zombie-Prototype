using UnityEngine;
using System.Collections;

public enum PlayerState
{
	standing,
	moving,
	attacking,
	stunned
}

public class Player : MonoBehaviour
{

	public bool isActivePlayer;
	public float moveSpeed = 100.0f;

	public float drag = 10.0f;
	public bool applyGravity = true;
	public bool invincibleWhenHit = false;
	
	public GameObject followPlayerGameObject;

	private Vector3 moveVec;
	private Vector3 forward;

	public Vector3 velocity
	{
		get;
		set;
	}

	private bool grounded = false;
	private CharacterController controller;

	private PlayerState playerState;

	void Start()
	{
		velocity = Vector3.zero;
		controller = (CharacterController)GetComponent(typeof(CharacterController));
		playerState = PlayerState.standing;
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
	}

	void FixedUpdate()
	{
		if (this.playerState != PlayerState.attacking)
		{
			Vector3 forcesVec = Vector3.zero;
			forcesVec += this.Gravity();
			forcesVec += this.Forces();

			if (forcesVec == Vector3.zero)
			{
				this.playerState = PlayerState.standing;
				forcesVec = Vector3.up * 0.0001f;
			}

			var flags = controller.Move(forcesVec * Time.fixedDeltaTime);
			grounded = (flags & CollisionFlags.CollidedBelow) != 0;

			Vector3 scale = transform.localScale;

			if (this.moveVec.x > 0 || forcesVec.x > 0)
			{
				scale.x = 1;
			}
			else if (this.moveVec.x < 0 || forcesVec.x < 0)
			{
				scale.x = -1;
			}

			if (this.moveVec.z == 0 && forcesVec.z == 0 && this.moveVec.x == 0 && forcesVec.x == 0)
			{
				this.playerState = PlayerState.standing;
			}
			else
			{
				this.playerState = PlayerState.moving;
			}

			this.transform.localScale = scale;
		}
	}

	public Vector3 Gravity()
	{
		Vector3 grav = Vector3.zero;
		if (applyGravity && !grounded)
		{
			grav = new Vector3(0.0f, -100.0f, 0.0f);
		}
		return grav;
	}

	public Vector3 Forces()
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

	public void AddForce(Vector3 force)
	{
		velocity += force;
	}

	public Vector3 GetForce()
	{
		return velocity;
	}

	public void Movement(float xaxis, float yaxis)
	{
		if (xaxis == 0 && yaxis == 0)
		{
			return;
		}

		moveVec = transform.forward * moveSpeed * yaxis;

		transform.position += moveVec;
	}

	public void RawMovement(Vector3 move)
	{
		RawMovement(move, true, false);
	}

	public void RawMovement(Vector3 move, bool align)
	{
		RawMovement(move, align, false);
	}

	public void RawMovement(Vector3 move, bool align, bool forceLook)
	{
		moveVec = move * moveSpeed;
		if (align && move.magnitude > 0.15 && (transform.forward != move))
		{
			Vector3 lookVec = move;
		}

		var flags = controller.Move(moveVec * Time.fixedDeltaTime);
		grounded = (flags & CollisionFlags.CollidedBelow) != 0;
	}

	public void RawMotion(Vector3 move)
	{
		var originalSpeed = moveSpeed;
		moveSpeed = 1.0f;
		RawMovement(move);
		moveSpeed = originalSpeed;
	}

	public void OnKill()
	{
		Destroy(gameObject);
	}

	public Vector3 GetGridPos(Vector3 pos)
	{
		Vector3 snappedPos = pos;
		snappedPos.x = Mathf.Round(snappedPos.x);
		snappedPos.z = Mathf.Round(snappedPos.z);

		return snappedPos;
	}

	public Vector3 GetForwardGridPos()
	{
		forward = transform.TransformDirection(Vector3.forward);
		return GetGridPos(transform.position + forward);
	}

	public void SetMoveVec(Vector3 vec)
	{
		this.moveVec = vec;
	}

	public PlayerState PlayerState
	{
		get {
			return playerState;
		}
		set {
			playerState = value;
		}
	}
}
