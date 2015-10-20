using UnityEngine;
using System.Collections;

public enum EnemyState
{
	Attacking,
	Strafing,
	Stunned,
	Fleeing,
	Standing,
	IsFeared
}

public class Enemy : MonoBehaviour
{
	public float moveSpeed = 100.0f;
	public int team = 0;

	public float drag = 10.0f;
	public bool applyGravity = true;
	public bool invincibleWhenHit = false;

	private Vector3 moveVec;
	private Vector3 forward;

	public Vector3 velocity
	{
		get;
		set;
	}

	private bool grounded = false;
	private bool invincible = false;

	private CharacterController controller;

	private EnemyState enemyState;

	void Start()
	{
		velocity = Vector3.zero;
		controller = (CharacterController)GetComponent(typeof(CharacterController));
		this.enemyState = EnemyState.Attacking;
	}

	void FixedUpdate()
	{
		Vector3 forcesVec = Vector3.zero;
		forcesVec += this.Gravity();
		forcesVec += this.Forces();

		if (forcesVec == Vector3.zero)
		{
			forcesVec = Vector3.up * 0.0001f;
		}

		var flags = controller.Move(forcesVec * Time.fixedDeltaTime);
		grounded = (flags & CollisionFlags.CollidedBelow) != 0;
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

	public EnemyState EnemyState
	{
		get {
			return enemyState;
		}
		set {
			enemyState = value;
		}
	}
}
