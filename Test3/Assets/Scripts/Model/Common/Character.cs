using UnityEngine;
using System.Collections;

public enum CharacterState
{
	Attacking,
	Stunned,
	Fleeing,
	Standing,
	Moving,
	Dying
}

public class Character : MonoBehaviour
{
	protected Health health;
	protected CharacterController controller;
	protected bool grounded = false;
	protected bool invincible = false;
	protected CharacterState state;
	protected Vector3 moveVec;
	protected Vector3 forward;
	protected Vector3 forcesVec;

	public float moveSpeed = 100.0f;
	public float drag = 10.0f;
	public int team = 0;
	public Vector3 velocity;
	public float stunnedTime = 1f;
	protected bool stunned;

	protected void Start()
	{
		moveVec = Vector3.zero;
		this.controller = (CharacterController)GetComponent(typeof(CharacterController));
		this.state = CharacterState.Standing;

		this.health = this.GetComponent<Health>();
	}

	protected void FixedUpdate()
	{
		this.forcesVec = Vector3.zero;
		this.moveVec = Vector3.zero;
		forcesVec += this.Gravity();
		forcesVec += this.Forces();

		if (forcesVec == Vector3.zero)
		{
			this.state = CharacterState.Standing;
			forcesVec = Vector3.up * 0.0001f;
		}

		Vector3 scale = transform.localScale;

		this.transform.localScale = scale;

		if (this.state != CharacterState.Attacking && this.state != CharacterState.Stunned && this.state != CharacterState.Dying)
		{
			var flags = controller.Move(forcesVec * Time.fixedDeltaTime);
			grounded = (flags & CollisionFlags.CollidedBelow) != 0;

			if (this.moveVec.z == 0 && forcesVec.z == 0 && this.moveVec.x == 0 && forcesVec.x == 0)
			{
				this.state = CharacterState.Standing;
			}
			else
			{
				this.state = CharacterState.Moving;
			}
		}
		else if (this.state == CharacterState.Stunned)
		{
			this.stunned = true;
			StartCoroutine(this.WaitForStun());
		}
	}

	public virtual Vector3 Forces()
	{
		Vector3 vec = Vector3.zero;

		if (velocity != Vector3.zero)
		{
			vec = velocity;

			if (velocity.magnitude > 0.01f)
			{
				velocity -= (velocity * drag * Time.fixedDeltaTime);
			}
			else
			{
				velocity = Vector3.zero;
			}
		}

		return vec;
	}

	public Vector3 Gravity()
	{
		Vector3 grav = Vector3.zero;
		if (!grounded)
		{
			grav = new Vector3(0.0f, -100.0f, 0.0f);
		}
		return grav;
	}

	public void RawMovement(Vector3 move)
	{
		moveVec = move * moveSpeed;
		if (move.magnitude > 0.15 && (transform.forward != move))
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

	IEnumerator WaitForStun()
	{
		yield return new WaitForSeconds(this.stunnedTime);
		this.state = CharacterState.Standing;
		this.stunned = false;
	}

	public CharacterState State
	{
		get {
			return state;
		}
		set {
			state = value;
		}
	}
}
